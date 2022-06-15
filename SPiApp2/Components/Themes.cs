using SPiApp2.Components.Common;
using SPiApp2.Components.Settings;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace SPiApp2.Components
{
    public static class Themes
    {
        public const string THEME_DEFAULT = "Default (built-in)";
        private const string THEME_VERSION = "200216";

        /// <summary>
        /// Get the full path to the themes directory.
        /// </summary>
        /// <returns>The full path to the themes directory.</returns>
        public static string GetThemesPath()
        {
            return string.Format("{0}{1}themes", Environment.CurrentDirectory, Path.DirectorySeparatorChar);
        }

        /// <summary>
        /// Get an indicator to whether the theme is the default theme or not.
        /// </summary>
        /// <param name="theme">The name of the theme.</param>
        /// <returns>true if default; otherwise, false.</returns>
        public static bool IsDefaultTheme(string theme)
        {
            return (!string.IsNullOrEmpty(theme) && theme == THEME_DEFAULT);
        }

        /// <summary>
        /// Load the names of all available themes into the control.
        /// </summary>
        /// <param name="control">The control to load the theme names into.</param>
        public static void LoadAvailableThemes(ref ComboBox control)
        {
            control.Items.Clear();

            // Always add the built-in theme and set it as the default (at least for now!)
            control.Items.Add(THEME_DEFAULT);

            // Load all non-default theme names
            string directory = GetThemesPath();
            if (Directory.Exists(directory))
            {
                string[] files = Directory.GetFiles(directory, "*.xaml", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    string theme = Path.GetFileNameWithoutExtension(file);

                    if (IsValidTheme(theme))
                    {
                        control.Items.Add(theme);
                    }
                    else
                    {
                        SPiApp2.Controls.Console.WriteLine(string.Format(
                            "Theme '{0}' has been found invalid.", theme));
                    }
                }
            }

            // Get the theme
            string preferedTheme = Preferences.Theme;

            // Select the used theme in the ComboBox control
            Utility.SelectValue(ref control, preferedTheme);

            // Apply prefered theme
            ApplyTheme(preferedTheme);
        }

        /// <summary>
        /// Get an indicator to whether or not the theme is supported by the application.
        /// </summary>
        /// <param name="theme">The name of the theme.</param>
        /// <returns>true if supported; false, otherwise.</returns>
        private static bool IsValidTheme(string theme)
        {
            ResourceDictionary dict = LoadThemeFile(theme);
            return IsValidTheme(ref dict);
        }

        /// <summary>
        /// Get an indicator to whether or not the theme is supported by the application.
        /// </summary>
        /// <param name="dict">The dictionary holding the theme.</param>
        /// <returns>true if supported; false, otherwise.</returns>
        private static bool IsValidTheme(ref ResourceDictionary dict)
        {
            if (dict == null)
                return false;

            string version = dict["ThemeVersion"] as string;
            if (string.IsNullOrEmpty(version))
                return false;

            if (float.TryParse(THEME_VERSION, out float builtVersion) &&
                float.TryParse(version, out float themeVersion))
            {
                return themeVersion >= builtVersion;
            }

            return false;
        }

        /// <summary>
        /// Load a theme file into a resource dictionary.
        /// </summary>
        /// <param name="theme">The name of the theme to load.</param>
        /// <returns>null on failure; otherwise, the theme as a ResourceDictionary object.</returns>
        private static ResourceDictionary LoadThemeFile(string theme)
        {
            string path = string.Format("{0}{1}{2}.xaml", GetThemesPath(), Path.DirectorySeparatorChar, theme);

            if (File.Exists(path))
            {
                try
                {
                    StreamReader stream = new StreamReader(path);

                    ResourceDictionary dict = XamlReader.Load(stream.BaseStream) as ResourceDictionary;
                    if (dict == null)
                    {
                        //dict.Name = string.Format("Themes/{0}", theme);
                    }

                    return dict;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            return null;
        }

        /// <summary>
        /// Called when the user wants to change the theme.
        /// </summary>
        /// <param name="theme">The theme name.</param>
        public static void ChangeTheme(string theme)
        {
            string path = string.Format("{0}{1}{2}.xaml", GetThemesPath(), Path.DirectorySeparatorChar, theme);

            // Get a reference to the application
            App app = System.Windows.Application.Current as App;

            // If the default theme save and continue
            if (IsDefaultTheme(theme))
            {
                Preferences.Theme = THEME_DEFAULT;
                app.Restart();
            }
            else if (File.Exists(path))
            {
                Preferences.Theme = theme;
                app.Restart();
            }
        }

        /// <summary>
        /// Applies a theme to the application.
        /// </summary>
        /// <param name="theme">The name of the theme.</param>
        private static void ApplyTheme(string theme)
        {
            if (!IsDefaultTheme(theme))
            {
                // Load the theme
                ResourceDictionary dict = LoadThemeFile(theme);
                if (dict != null)
                {
                    // Ensure the theme is valid
                    if (!IsValidTheme(ref dict))
                    {
                        Preferences.Theme = THEME_DEFAULT;
                    }
                    else
                    {
                        // Get a reference to the application
                        App app = System.Windows.Application.Current as App;
                        Debug.Assert(app != null);

                        // Get a list of all the merged dictionaries
                        Collection<ResourceDictionary> merged = app.Resources.MergedDictionaries;

                        // Loop over all the dictionaries
                        for (int i = 0; i < merged.Count; i++)
                        {
                            string str = merged[i].Source.OriginalString;

                            if (str.StartsWith("Themes/"))
                            {
                                /* foreach (var key in dict.Keys)
                                {
                                    Debug.WriteLine(string.Format("{0} ==> \"{1}\"", key, dict[key]));
                                } */

                                merged[i] = dict;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
