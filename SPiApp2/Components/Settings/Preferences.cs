using SPiApp.Common;
using SPiApp2.Components.Common;
using System;
using Path = System.IO.Path;

namespace SPiApp2.Components.Settings
{
    /// <summary>
    /// The preferences as set by the user.
    /// </summary>
    public class Preferences : SettingsFile
    {
        private static Preferences _instance = null;

        public static Preferences Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Preferences();
                }

                return _instance;
            }
        }

        // Required
        private const string INSTALL_PATH = "InstallPath";
        private const string LANGUAGE = "Language";
        private const string ZIPPER = "Zipper";

        // Advanced
        private const string EXECUTABLE = "Executable";
        private const string TEXT_EDITOR = "TextEditor";
        private const string THEME = "CompilerTheme";
        private const string SYNC_TOOLS = "SyncTools";

        // Optional
        private const string CUSTOM0_TEXT = "Custom0Text";
        private const string CUSTOM1_TEXT = "Custom1Text";
        private const string CUSTOM2_TEXT = "Custom2Text";
        private const string CUSTOM3_TEXT = "Custom3Text";
        private const string CUSTOM0_VALUE = "Custom0Value";
        private const string CUSTOM1_VALUE = "Custom1Value";
        private const string CUSTOM2_VALUE = "Custom2Value";
        private const string CUSTOM3_VALUE = "Custom3Value";

        private Preferences() :
            base(false)
        {
            Utility.GetWindow(out MainWindow window);

            // Required
            Bind(INSTALL_PATH, ref window.ctrlInstallPath);
            Bind(LANGUAGE, ref window.ctrlLanguage);
            Bind(ZIPPER, ref window.ctrlZipper);

            // Advanced
            Bind(EXECUTABLE, ref window.ctrlExecutable);
            Bind(TEXT_EDITOR, ref window.ctrlEditor);
            Bind(THEME, Themes.THEME_DEFAULT);
            Bind(SYNC_TOOLS, ref window.ctrlSynchronize);

            // Optional
            Bind(CUSTOM0_TEXT, ref window.ctrlCustom0Text);
            Bind(CUSTOM1_TEXT, ref window.ctrlCustom1Text);
            Bind(CUSTOM2_TEXT, ref window.ctrlCustom2Text);
            Bind(CUSTOM3_TEXT, ref window.ctrlCustom3Text);
            Bind(CUSTOM0_VALUE, ref window.ctrlCustom0Value);
            Bind(CUSTOM1_VALUE, ref window.ctrlCustom1Value);
            Bind(CUSTOM2_VALUE, ref window.ctrlCustom2Value);
            Bind(CUSTOM3_VALUE, ref window.ctrlCustom3Value);

            // Default values
            SetDefaultString(INSTALL_PATH, GetDefaultInstallPath());
            SetDefaultString(ZIPPER, string.Format("mods{0}ModWarfare{0}7za.exe", Path.DirectorySeparatorChar));
            SetDefaultString(EXECUTABLE, "iw3sp.exe");
        }

        protected override string GetPath()
        {
            return string.Format("{0}{1}settings{1}app.pref",
                Environment.CurrentDirectory, Path.DirectorySeparatorChar);
        }

        protected override string GetAltPath()
        {
            return null;
        }

        /// <summary>
        /// Get the user's default installation path.
        /// </summary>
        /// <returns>The user's default installation path.</returns>
        private string GetDefaultInstallPath()
        {
            string _installPath = null;

            // 64-bit from DVD
            if (Registry.CheckKey(ref _installPath, "SOFTWARE\\WOW6432Node\\Activision\\Call of Duty 4", "InstallPath"))
            {
                return _installPath;
            }

            // 64-bit from Steam
            if (Registry.CheckKey(ref _installPath, "SOFTWARE\\WOW6432Node\\Valve\\Steam\\Apps\\7940", "installpath"))
            {
                return _installPath;
            }

            // 32-bit from DVD
            if (Registry.CheckKey(ref _installPath, "SOFTWARE\\Activision\\Call of Duty 4", "InstallPath"))
            {
                return _installPath;
            }

            // 32-bit from Steam
            if (Registry.CheckKey(ref _installPath, "SOFTWARE\\Valve\\Steam\\Apps\\7940", "installpath"))
            {
                return _installPath;
            }

            // Otherwise there is no directory, set the default
            return string.Format("C:{0}Program Files (x86){0}Activision{0}Call of Duty 4", Path.DirectorySeparatorChar);
        }

        /// <summary>
        /// Reset all the advanced values.
        /// </summary>
        public static void ResetAdvanced()
        {
            Preferences settings = Instance;

            settings.Clear(EXECUTABLE);
            settings.Clear(TEXT_EDITOR);
            settings.Clear(SYNC_TOOLS);

            settings.Save();
        }

        /// <summary>
        /// Reset all the optional values
        /// </summary>
        public static void ResetOptional()
        {
            Preferences settings = Instance;

            settings.Clear(CUSTOM0_TEXT);
            settings.Clear(CUSTOM1_TEXT);
            settings.Clear(CUSTOM2_TEXT);
            settings.Clear(CUSTOM3_TEXT);

            settings.Clear(CUSTOM0_VALUE);
            settings.Clear(CUSTOM1_VALUE);
            settings.Clear(CUSTOM2_VALUE);
            settings.Clear(CUSTOM3_VALUE);

            settings.Save();
        }

        /// <summary>
        /// Get the installation path.
        /// </summary>
        public static string InstallPath
        {
            get
            {
                return Instance.GetString(INSTALL_PATH);
            }
        }

        /// <summary>
        /// Get the prefered language.
        /// </summary>
        public static string Language
        {
            get
            {
                return Instance.GetString(LANGUAGE);
            }
        }

        /// <summary>
        /// Get the synchronization between these and the original compile tools.
        /// </summary>
        public static bool SyncTools
        {
            get
            {
                return Instance.GetBool(SYNC_TOOLS);
            }
        }

        /// <summary>
        /// Get the prefered executable for running Call of Duty 4 Single Player.
        /// </summary>
        public static string Executable
        {
            get
            {
                return Instance.GetString(EXECUTABLE);
            }
        }

        /// <summary>
        /// Get the prefered zipper for packing IWD files with.
        /// </summary>
        public static string Zipper
        {
            get
            {
                return Instance.GetString(ZIPPER);
            }
        }
        
        /// <summary>
        /// Get or set the prefered compiler theme.
        /// </summary>
        public static string Theme
        {
            get
            {
                return Instance.GetString(THEME);
            }
            set
            {
                Instance.SetString(THEME, value);

                // NOTE:
                //   Theme is operated using special written code. As
                //   a result we want to perform a save every change.
                Instance.Save();
            }
        }

        /// <summary>
        /// Get the prefered text editor for code editing.
        /// </summary>
        public static string TextEditor
        {
            get
            {
                return Instance.GetString(TEXT_EDITOR);
            }
        }

        /// <summary>
        /// Get the text for custom control #0.
        /// </summary>
        public static string Custom0Text
        {
            get
            {
                return Instance.GetString(CUSTOM0_TEXT);
            }
        }

        /// <summary>
        /// Get the text for custom control #1.
        /// </summary>
        public static string Custom1Text
        {
            get
            {
                return Instance.GetString(CUSTOM1_TEXT);
            }
        }

        /// <summary>
        /// Get the text for custom control #2.
        /// </summary>
        public static string Custom2Text
        {
            get
            {
                return Instance.GetString(CUSTOM2_TEXT);
            }
        }

        /// <summary>
        /// Get the text for custom control #3.
        /// </summary>
        public static string Custom3Text
        {
            get
            {
                return Instance.GetString(CUSTOM3_TEXT);
            }
        }

        /// <summary>
        /// Get the destination for custom control #0.
        /// </summary>
        public static string Custom0Value
        {
            get
            {
                return Instance.GetString(CUSTOM0_VALUE);
            }
        }

        /// <summary>
        /// Get the destination for custom control #1.
        /// </summary>
        public static string Custom1Value
        {
            get
            {
                return Instance.GetString(CUSTOM1_VALUE);
            }
        }

        /// <summary>
        /// Get the destination for custom control #2.
        /// </summary>
        public static string Custom2Value
        {
            get
            {
                return Instance.GetString(CUSTOM2_VALUE);
            }
        }

        /// <summary>
        /// Get the destination for custom control #3.
        /// </summary>
        public static string Custom3Value
        {
            get
            {
                return Instance.GetString(CUSTOM3_VALUE);
            }
        }
    }
}
