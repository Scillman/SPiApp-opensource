using SPiApp2.Components;
using SPiApp2.Components.Common;
using SPiApp2.Components.Settings;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shell;
using System.Windows.Threading;

namespace SPiApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SPiApp2.Controls.CompilerWindow
    {
        private bool HasLoaded { get; set; } = false;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += OnLoaded;
        }

        public override void GetWindowChrome(out WindowChrome chrome)
        {
            chrome = this.chrome;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            // Suspend to prevent the data from being saved during load
            Preferences.Instance.Load();
            UserData.Instance.Load();

            // Hide the resource viewer
            tabResourceViewer.Visibility = Visibility.Hidden;

            // Validates and loads
            if (Validate_CompilerInstallation())
            {
                Load_PreferencesData();

                if (!Validate_Preferences())
                {
                    Compiler_SetInteraction(false);
                }

                HasLoaded = true;
            }
            else
            {
                AppDialogMessage.Show("Compiler installation has been detected to be corrupted. Please reinstall the tools." +
                    " Additional information has been copied to the clipboard.",
                    "Corrupted installation", MessageButtons.OK, MessageIcon.Error);
                Click_CopyConsole(null, null);
                Close();
            }
        }

        /// <summary>
        /// Called when the user switches from one of the root tabs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Compiler_SwitchedRootTab(object sender, SelectionChangedEventArgs e)
        {
            Debug.Assert(e.Source != null);

            if (e.Source == rootTabs)
            {
                TabItem item = rootTabs.SelectedItem as TabItem;
                Debug.Assert(item != null);

                if (item == tabCompiling)
                {
                    Dispatcher.Invoke(() =>
                    {
                        Map.RefreshList(true);
                        Mod.RefreshList(true);
                    }, DispatcherPriority.Loaded);
                }

                // Save tab indices
                if (HasLoaded)
                {
                    if (item == tabPreferences || item == tabCompiling ||
                        item == tabBrowsing || item == tabApplications ||
                        item == tabResourceViewer)
                    {
                        UserData.Instance.Save();
                    }
                }
            }
        }

        /// <summary>
        /// Enables or disables interaction with the controls relying on third-party files.
        /// </summary>
        private void Compiler_SetInteraction(bool enable)
        {
            if (!enable)
            {
                Debug.Assert(rootTabs.Items.Count > 0);
                rootTabs.SelectedIndex = 0;
            }

            for (int i = 1; i < rootTabs.Items.Count; i++)
            {
                TabItem item = rootTabs.Items[i] as TabItem;
                Debug.Assert(item != null);
                item.IsEnabled = enable;
            }
        }

        /// <summary>
        /// Validate the 
        /// </summary>
        /// <returns></returns>
        private bool Validate_CompilerInstallation()
        {
            const string SUB_MESSAGE = " Please reinstall the tools.";

            // 1) Check for the existence of the bin directory
            string directory = string.Format("{0}{1}bin", Environment.CurrentDirectory, System.IO.Path.DirectorySeparatorChar);
            if (!Directory.Exists(directory))
            {
                SPiApp2.Controls.Console.WriteLine(string.Format(
                    "Could not locate the bin directory.{0}", SUB_MESSAGE));
                return false;
            }

            string[] files =
            {
                "map_build.bat",
                "map_compile.bat",
                "map_grid.bat",
                "map_reflections.bat",
                "map_run.bat",
                "mod_build.bat",
                "mod_iwd.bat",
                "mod_run.bat"
            };

            // 2) Check for the existence of all the batch files
            foreach (string file in files)
            {
                string path = string.Format("{0}{1}{2}", directory, System.IO.Path.DirectorySeparatorChar, file);
                if (!File.Exists(path))
                {
                    SPiApp2.Controls.Console.WriteLine(string.Format(
                        "Missing compiler file '{0}'.{1}", file, SUB_MESSAGE));
                    return false;
                }
            }

            // 3) Create the settings directories
            string settingsDirectory = string.Format("{0}{1}settings", Environment.CurrentDirectory, System.IO.Path.DirectorySeparatorChar);
            if (!Directory.Exists(settingsDirectory))
            {
                Directory.CreateDirectory(settingsDirectory);
            }

            string mapsSettings = string.Format("{0}{1}maps", settingsDirectory, System.IO.Path.DirectorySeparatorChar);
            if (!Directory.Exists(mapsSettings))
            {
                Directory.CreateDirectory(mapsSettings);
            }

            string modsSettings = string.Format("{0}{1}mods", settingsDirectory, System.IO.Path.DirectorySeparatorChar);
            if (!Directory.Exists(modsSettings))
            {
                Directory.CreateDirectory(modsSettings);
            }

            return true;
        }

        /// <summary>
        /// Called when the preferences data has to be loaded into the controls.
        /// </summary>
        private void Load_PreferencesData()
        {
            // Always load the theme first
            Themes.LoadAvailableThemes(ref ctrlThemes);
            ctrlThemes.SelectionChanged += Select_CompilerThemeChanged;
        }

        private bool Validate_PreferencesRequired()
        {
            if (!Validator.ValidateInstallPath() ||
                !Validator.ValidateZipper())
            {
                return false;
            }

            return true;
        }

        private bool Validate_PreferencesAdvanced()
        {
            string executable = Preferences.Executable;
            if (!Validator.ValidateFile(executable))
            {
                return false;
            }

            string[] textEditor = Utility.Split(Preferences.TextEditor);
            if (textEditor.Length > 0)
            {
                if (!string.IsNullOrWhiteSpace(textEditor[0]))
                {
                    if (!Validator.ValidateFile(textEditor[0]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool Validate_Preferences()
        {
            if (!Validate_PreferencesRequired() ||
                !Validate_PreferencesAdvanced())
            {
                return false;
            }

            return true;
        }

#region Preferences

#region Peferences - Required

        /// <summary>
        /// Called when the user pressed the Browse button for the InstallPath variable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_BrowseInstallPath(object sender, RoutedEventArgs e)
        {
            AppDialogBrowse dialog = new AppDialogBrowse(BrowseType.Directories, new string[] { "*.*", "All directories" });
            bool? result = dialog.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                ctrlInstallPath.Text = dialog.SelectedPath;
            }
        }

        /// <summary>
        /// Called when the user pressed the Browse button for the 7za.exe executable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_BrowseZipper(object sender, RoutedEventArgs e)
        {
            AppDialogBrowse dialog = new AppDialogBrowse(BrowseType.Files, new string[] { "*.exe", "Executables" });
            bool? result = dialog.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                ctrlZipper.Text = dialog.SelectedPath;
            }
        }

        /// <summary>
        /// Called when the user wants to save the settings in the Required Preferences tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_PreferencesSaveRequired(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = ctrlLanguage.SelectedItem as ComboBoxItem;
            Debug.Assert(item != null);

            string language = item.Content as string;
            Debug.Assert(language != null);

            Preferences.Instance.Save();

            // Check the new settings
            if (Validate_PreferencesRequired())
            {
                Compiler_SetInteraction(true);
            }
            else
            {
                Compiler_SetInteraction(false);
                AppDialogMessage.Show("One or more settings were found to be invalid. Check the console for more information",
                        "Invalid settings", MessageButtons.OK, MessageIcon.Information);
            }
        }

#endregion

#region Peferences - Advanced

        /// <summary>
        /// Called when the user wishes to select a new executable file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_BrowseExecutable(object sender, RoutedEventArgs e)
        {
            AppDialogBrowse dialog = new AppDialogBrowse(BrowseType.Files, new string[] { "*.exe", "Executables" });
            bool? result = dialog.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                string path = dialog.SelectedPath;
                string installPath = Preferences.InstallPath;

                int index = path.IndexOf(installPath);
                if (index != -1)
                {
                    int start = installPath.Length + 1;
                    int length = (path.Length - installPath.Length - 1);
                    path = path.Substring(start, length);
                }

                ctrlExecutable.Text = path;
            }
        }

        /// <summary>
        /// Called when the user wishes to change the prefered text editor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_BrowseEditor(object sender, RoutedEventArgs e)
        {
            AppDialogBrowse dialog = new AppDialogBrowse(BrowseType.Files, new string[] { "*.exe", "Executables" });
            bool? result = dialog.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                ctrlEditor.Text = dialog.SelectedPath;
            }
        }

        /// <summary>
        /// Called when the user changes the theme of the compiler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Select_CompilerThemeChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageResult result = AppDialogMessage.Show(
                "Changing the theme requires a restart of the application. Do you still want to change the theme?",
                "Change theme?", MessageButtons.YesNo, MessageIcon.Question);

            // Always remove the theme event handler before changing
            ctrlThemes.SelectionChanged -= Select_CompilerThemeChanged;

            if (result == MessageResult.Yes)
            {
                Themes.ChangeTheme(e.AddedItems[0] as string);
            }
            else
            {
                ComboBox obj = sender as ComboBox;
                Debug.Assert(obj != null);
                obj.SelectedItem = e.RemovedItems[0];
            }

            // When done rebind the event handler
            ctrlThemes.SelectionChanged += Select_CompilerThemeChanged;
        }

        /// <summary>
        /// Clicked when the user wishes to reset the advanced preferences values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_PreferencesAdvancedReset(object sender, RoutedEventArgs e)
        {
            Preferences.ResetAdvanced();
        }

        /// <summary>
        /// Called when the user wishes to save the advanced preferences values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_PreferencesAdvancedSave(object sender, RoutedEventArgs e)
        {
            Preferences.Instance.Save();

            if (Validate_PreferencesAdvanced())
            {
                Compiler_SetInteraction(true);
            }
            else
            {
                Compiler_SetInteraction(false);
                AppDialogMessage.Show("One or more settings were found to be invalid. Check the console for more information",
                    "Invalid settings", MessageButtons.OK, MessageIcon.Information);
            }
        }

#endregion

#region Peferences - Optional

        /// <summary>
        /// Common function for browsing related to the custom buttons.
        /// </summary>
        /// <param name="cText">The TextBox object with the control text.</param>
        /// <param name="cValue">The TextBox object with the action text.</param>
        private void Common_BrowseCustom(ref TextBox cText, ref TextBox cValue)
        {
            AppDialogBrowse dialog = new AppDialogBrowse(BrowseType.All, new string[] { "*.*", "All files" });
            bool? result = dialog.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                string path = dialog.SelectedPath;

                // Do a check to see if it can be set directly...
                if (string.IsNullOrWhiteSpace(cText.Text))
                {
                    string[] tokens = path.Split('\\', '/');
                    if (tokens.Length > 0)
                    {
                        cText.Text = tokens[tokens.Length - 1];
                    }
                }

                cValue.Text = path;
            }
        }

        /// <summary>
        /// Called when the user wants to browse for the first custom button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_BrowseCustom0(object sender, RoutedEventArgs e)
        {
            Common_BrowseCustom(ref ctrlCustom0Text, ref ctrlCustom0Value);
        }

        /// <summary>
        /// Called when the user wants to browse for the second custom button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_BrowseCustom1(object sender, RoutedEventArgs e)
        {
            Common_BrowseCustom(ref ctrlCustom1Text, ref ctrlCustom1Value);
        }

        /// <summary>
        /// Called when the user wants to browse for the third custom button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_BrowseCustom2(object sender, RoutedEventArgs e)
        {
            Common_BrowseCustom(ref ctrlCustom2Text, ref ctrlCustom2Value);
        }

        /// <summary>
        /// Called when the user wants to browse for the fourth custom button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_BrowseCustom3(object sender, RoutedEventArgs e)
        {
            Common_BrowseCustom(ref ctrlCustom3Text, ref ctrlCustom3Value);
        }

        /// <summary>
        /// Called when the user wants to reset the custom buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_PreferencesOptionalReset(object sender, RoutedEventArgs e)
        {
            Preferences.ResetOptional();
        }

        /// <summary>
        /// Called when the user wishes to save the custom button data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_PreferencesOptionalSave(object sender, RoutedEventArgs e)
        {
            Preferences.Instance.Save();
        }

#endregion

#endregion

#region Compiling

#region Maps

        private void Click_MapCreateNew(object sender, RoutedEventArgs e)
        {
            Map.CreateMap();
        }

        private void Click_MapRefreshList(object sender, RoutedEventArgs e)
        {
            Map.RefreshList(true);
        }

        private void Click_MapCompileBSP(object sender, RoutedEventArgs e)
        {
            Map.CompileBSP();
        }

        private void Click_MapCompileReflections(object sender, RoutedEventArgs e)
        {
            Map.CompileReflections();
        }

        private void Click_MapBuildFastFile(object sender, RoutedEventArgs e)
        {
            Map.BuildFastFile();
        }

        private void Click_MapUpdateZone(object sender, RoutedEventArgs e)
        {
            Map.UpdateZoneFile();
        }

        private void Click_MapRunSelected(object sender, RoutedEventArgs e)
        {
            Map.RunSelectedMap();
        }

        private void Click_MapStartGrid(object sender, RoutedEventArgs e)
        {
            Map.StartGrid();
        }

        private void Click_MapOpenRadiant(object sender, RoutedEventArgs e)
        {
            Map.OpenInRadiant();
        }

#region Map - Browsing

        private void Click_MapBrowseFileMap(object sender, RoutedEventArgs e)
        {
            UserData.Instance.Save();

            char sep = System.IO.Path.DirectorySeparatorChar;
            string directory = string.Format("{0}{1}raw{1}maps", Preferences.InstallPath, sep);

            if (Map.IsMultiplayerMap())
            {
                directory = string.Format("{0}{1}mp", directory, sep);
            }

            SPiApp2.Components.Application.OpenTextFile(directory,
                string.Format("{0}.gsc", UserData.SelectedMap));
        }

        private void Click_MapBrowseFileCode(object sender, RoutedEventArgs e)
        {
            UserData.Instance.Save();

            char sep = System.IO.Path.DirectorySeparatorChar;
            string directory = string.Format("{0}{1}raw{1}maps", Preferences.InstallPath, sep);

            if (Map.IsMultiplayerMap())
            {
                directory = string.Format("{0}{1}mp", directory, sep);
            }

            SPiApp2.Components.Application.OpenTextFile(directory,
                string.Format("{0}_code.gsc", UserData.SelectedMap));
        }

        private void Click_MapBrowseFileAnim(object sender, RoutedEventArgs e)
        {
            UserData.Instance.Save();

            char sep = System.IO.Path.DirectorySeparatorChar;
            string directory = string.Format("{0}{1}raw{1}maps", Preferences.InstallPath, sep);

            if (Map.IsMultiplayerMap())
            {
                directory = string.Format("{0}{1}mp", directory, sep);
            }

            SPiApp2.Components.Application.OpenTextFile(directory,
                string.Format("{0}_anim.gsc", UserData.SelectedMap));
        }

        private void Click_MapBrowseFileFx(object sender, RoutedEventArgs e)
        {
            UserData.Instance.Save();

            char sep = System.IO.Path.DirectorySeparatorChar;
            string directory = string.Format("{0}{1}raw{1}maps", Preferences.InstallPath, sep);

            if (Map.IsMultiplayerMap())
            {
                directory = string.Format("{0}{1}mp", directory, sep);
            }

            SPiApp2.Components.Application.OpenTextFile(directory,
                string.Format("{0}_fx.gsc", UserData.SelectedMap));
        }

        private void Click_MapBrowseFileStrings(object sender, RoutedEventArgs e)
        {
            UserData.Instance.Save();

            SPiApp2.Components.Application.OpenTextFile(
                string.Format("{0}{1}raw{1}{2}{1}localizedstrings", Preferences.InstallPath, System.IO.Path.DirectorySeparatorChar,
                    Preferences.Language.ToLower()),
                string.Format("{0}.str", UserData.SelectedMap));
        }

        private void Click_MapBrowseFileSounds(object sender, RoutedEventArgs e)
        {
            UserData.Instance.Save();

            SPiApp2.Components.Application.OpenTextFile(
                string.Format("{0}{1}raw{1}soundaliases", Preferences.InstallPath, System.IO.Path.DirectorySeparatorChar),
                string.Format("{0}.csv", UserData.SelectedMap));
        }

#endregion

#endregion

#region Custom

        private void Compiler_CommonCustomButtonUpdate(ref Button button, ref TextBox text, ref TextBox value)
        {
            if (string.IsNullOrWhiteSpace(text.Text) &&
                string.IsNullOrWhiteSpace(value.Text))
            {
                button.Content = "<none>";
                button.IsEnabled = false;
            }
            else
            {
                button.IsEnabled = true;
                button.Content = text.Text;
            }
        }

        private void Compiler_CommonCustomTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox control = sender as TextBox;
            Debug.Assert(control != null);

            if (control == ctrlCustom0Text)
            {
                Compiler_CommonCustomButtonUpdate(ref ctrlCustom0, ref ctrlCustom0Text, ref ctrlCustom0Value);
            }
            else if (control == ctrlCustom1Text)
            {
                Compiler_CommonCustomButtonUpdate(ref ctrlCustom1, ref ctrlCustom1Text, ref ctrlCustom1Value);
            }
            else if (control == ctrlCustom2Text)
            {
                Compiler_CommonCustomButtonUpdate(ref ctrlCustom2, ref ctrlCustom2Text, ref ctrlCustom2Value);
            }
            else
            {
                Debug.Assert(control == ctrlCustom3Text);
                Compiler_CommonCustomButtonUpdate(ref ctrlCustom3, ref ctrlCustom3Text, ref ctrlCustom3Value);
            }
        }

        private void Compiler_ExecuteCustomCommand(string value)
        {
            try
            {
                // Only execute the command when there is data
                if (value.Length > 0)
                {
                    // First replace all the keywords
                    value = SPiApp2.Components.Common.Template.ReplaceAllKeywords(value);

                    // Split the data and take the path
                    string[] data = Utility.Split(value);
                    string path = data[0];

                    if (File.Exists(path))
                    {
                        string directory = Path.GetDirectoryName(path);
                        string filename = Path.GetFileName(path);

                        if (Utility.IsTextFile(filename))
                        {
                            SPiApp2.Components.Application.OpenTextFile(directory, filename);
                        }
                        else if (Utility.IsExecutableFile(filename))
                        {
                            // NOTE: Safe as 0 is the program executable!
                            string[] arguments = new string[data.Length - 1];
                            for (int i = 1; i < data.Length; i++)
                            {
                                arguments[i - 1] = data[i];
                            }

                            SPiApp2.Components.Application.Launch(filename, directory, arguments);
                        }
                        else
                        {
                            SPiApp2.Components.Application.Browse(directory, filename);
                        }
                    }
                    else if (Directory.Exists(path))
                    {
                        SPiApp2.Components.Application.Browse(path);
                    }
                    else
                    {
                        AppDialogMessage.Show(string.Format("Target at {0} isn't a directory or a file.", path),
                            "Missing target", MessageButtons.OK, MessageIcon.Warning);
                    }
                }
            }
            catch (Exception)
            {
                AppDialogMessage.Show("An unknown error occured while processing your custom commands.",
                    "Corrupted commands", MessageButtons.OK, MessageIcon.Error);
            }

#if OLD_VERSION

                    if (!string.IsNullOrEmpty(data[1]))
                    {
                        LaunchApplication(filename, directory, data[1]);
                    }
                    else
                    {
                        LaunchApplication(filename, directory);
                    }
#endif
        }

        private void Click_CommonCustom(object sender, RoutedEventArgs e)
        {
            Button control = sender as Button;
            Debug.Assert(control != null);

            if (control == ctrlCustom0)
            {
                Compiler_ExecuteCustomCommand(Preferences.Custom0Value);
            }
            else if (control == ctrlCustom1)
            {
                Compiler_ExecuteCustomCommand(Preferences.Custom1Value);
            }
            else if (control == ctrlCustom2)
            {
                Compiler_ExecuteCustomCommand(Preferences.Custom2Value);
            }
            else
            {
                Debug.Assert(control == ctrlCustom3);
                Compiler_ExecuteCustomCommand(Preferences.Custom3Value);
            }
        }

#endregion

#region Mods

        private void Click_ModCreateNew(object sender, RoutedEventArgs e)
        {
            Mod.CreateMod();
        }

        private void Click_ModRefreshList(object sender, RoutedEventArgs e)
        {
            Mod.RefreshList(true);
        }

        private void Click_ModBrowseFolder(object sender, RoutedEventArgs e)
        {
            Mod.BrowseFolder();
        }

        private void Click_ModBuildFF(object sender, RoutedEventArgs e)
        {
            Mod.BuildFastFile();
        }

        private void Click_ModBuildIWD(object sender, RoutedEventArgs e)
        {
            Mod.BuildIWD();
        }

        private void Click_ModUpdateZone(object sender, RoutedEventArgs e)
        {
            Mod.UpdateZoneFile();
        }

        private void Click_ModRunSelected(object sender, RoutedEventArgs e)
        {
            Mod.RunSelectedMod();
        }

#endregion

#endregion

#region Browsing

        /// <summary>
        /// Called when any of the buttons in the Browsing tab has been clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Common_ClickBrowse(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Debug.Assert(button != null);

            string browse = null;

            if (button == ctrlBrowseLocalized || button == ctrlMapBrowseLocalized)
            {
                browse = string.Format("raw/{0}/localizedstrings", Preferences.Language.ToLower());
            }
            else if (button == ctrlBrowseImagesMain)
            {
                browse = "main/images";

                // Extract the images if the directory does not exist
                string imagesMain = string.Format("{0}{1}main{1}images", Preferences.InstallPath, System.IO.Path.DirectorySeparatorChar);
                if (!Directory.Exists(imagesMain))
                {
                    MessageResult result = AppDialogMessage.Show("main/images could not be located. Do you wish the compiler to extract the .iwi files for you?",
                        "Create main/images directory?", MessageButtons.YesNo, MessageIcon.Question);
                    if (result == MessageResult.Yes)
                    {
                        // NOTE: We do not need to handle the result
                        AppDialogExtract dialog = new AppDialogExtract();
                        dialog.ShowDialog();
                    }
                }
            }
            else
            {
                browse = button.Tag as string;
                Debug.Assert(browse != null);
            }

            // Replace all the seperators for the system's path seperator
            browse = browse.Replace('/', System.IO.Path.DirectorySeparatorChar);

            // Create the destination path and try to open it
            string path = string.Format("{0}{1}{2}", Preferences.InstallPath, System.IO.Path.DirectorySeparatorChar, browse);
            if (!Directory.Exists(path))
            {
                AppDialogMessage.Show(string.Format("Could not locate directory at '{0}'.", path),
                    "Missing directory", MessageButtons.OK, MessageIcon.Warning);
            }
            else
            {
                SPiApp2.Components.Application.Browse(path);
            }
        }

#endregion

#region Applications

        private void Click_LaunchRadiant(object sender, RoutedEventArgs e)
        {
            SPiApp2.Components.Application.Launch("CoD4Radiant.exe",
                string.Format("{0}{1}bin", Preferences.InstallPath, System.IO.Path.DirectorySeparatorChar));
        }

        private void Hover_LaunchRadiant(object sender, MouseEventArgs e)
        {
            ctrlAppDescription.Text =
                "Radiant allows you to create an entirely new level for" +
                " either single player or multiplayer. Build your own" +
                " geometry and place entities such as models and light" +
                " in the level.";
        }

        private void Click_LaunchAssetManager(object sender, RoutedEventArgs e)
        {
            SPiApp2.Components.Application.Launch("asset_manager.exe",
                string.Format("{0}{1}bin", Preferences.InstallPath, System.IO.Path.DirectorySeparatorChar));
        }

        private void Hover_LaunchAssetManager(object sender, MouseEventArgs e)
        {
            ctrlAppDescription.Text =
                "Asset manager is the hub of most settings in the game." +
                " This is where you go to tweak weapon settings, turret" +
                " settings, AI types. It is also for adding new textures, " +
                " models and animations into the game.";
        }

        private void Click_LaunchEffectsEd(object sender, RoutedEventArgs e)
        {
            SPiApp2.Components.Application.Launch("CoD4EffectsEd.exe",
                string.Format("{0}{1}bin", Preferences.InstallPath, System.IO.Path.DirectorySeparatorChar));
        }

        private void Hover_LaunchEffectsEd(object sender, MouseEventArgs e)
        {
            ctrlAppDescription.Text =
                "The effects editor allows you to create or edit the" +
                " effects you see in game. For example make a new" +
                " explosion for your level or make a custom muzzleflash" +
                " for you weapon.";
        }

        private void Click_RunConverter(object sender, RoutedEventArgs e)
        {
            MessageResult result = AppDialogMessage.Show(
                "The converter overwrites exisiting files in the raw directory." +
                " This may hinder your ability to create mods and maps." +
                " Are you sure you want to run the converter?", "Are you sure?",
                MessageButtons.YesNo, MessageIcon.Question);

            if (result == MessageResult.Yes)
            {
                SPiApp2.Components.Application.Launch("converter.exe",
                    string.Format("{0}{1}bin", Preferences.InstallPath, System.IO.Path.DirectorySeparatorChar));
            }
        }

        private void Hover_RunConverter(object sender, MouseEventArgs e)
        {
            ctrlAppDescription.Text =
                "Run converter.exe with the appropriate settings" +
                " to convert any new or modified assets that you" +
                " changed in Asset Manager. Anytime you add" +
                " something or change something in Asset Manager" +
                " you must run converter to generate the game data" +
                " based on Asset Manager settings." +
                "\n\nNOTE:\n" +
                "This approach is not recommended.";
        }

        #endregion

        #region Resource Viewer

        private void Click_ResourceViewerMaterials(object sender, RoutedEventArgs e)
        {
            string[] materials = Tools.Material.GetAvailable();

            ctrlResourcesMaterialList.SelectionChanged -= Compiler_ResourceViewerSelectedMaterialChanged;
            ctrlResourcesMaterialList.Items.Clear();

            foreach (string material in materials)
            {
                ctrlResourcesMaterialList.Items.Add(new Tools.Material(material));
            }
            
            ctrlResourcesMaterialList.SelectionChanged += Compiler_ResourceViewerSelectedMaterialChanged;
        }

        private void Compiler_ResourceViewerSelectedMaterialChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                if (e.AddedItems[0] is Tools.Material material)
                {
                    ctrlResourceViewImageInfo.Text = material.ToString();
                }
            }
        }

        private void Click_ResourceViewerImages(object sender, RoutedEventArgs e)
        {
            string[] imageNames = Tools.Image.GetAvailable();

#if FALSE
            foreach (string imageName in imageNames)
            {
                using (Tools.Image image = new Tools.Image(imageName))
                {
                    image.Load();
                }
            }

#endif

            ctrlResourcesImageList.SelectionChanged -= Compiler_ResourceViewerSelectedImageChanged;
            ctrlResourcesImageList.Items.Clear();

            foreach (string imageName in imageNames)
            {
                ctrlResourcesImageList.Items.Add(new Tools.Image(imageName));
            }

            ctrlResourcesImageList.SelectionChanged += Compiler_ResourceViewerSelectedImageChanged;
        }

        private void Compiler_ResourceViewerSelectedImageChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                if (e.AddedItems[0] is Tools.Image image)
                {
                    using (image)
                    {
                        image.Load();
                        ctrlResourceViewImageInfo.Text = image.Info;
                    }
                }
            }
        }

#endregion

#region Console

        /// <summary>
        /// Called when the user wants to toggle the visibility of the console.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_ToggleConsole(object sender, RoutedEventArgs e)
        {
            TextBox console = ctrlConsole;
            Visibility vis = Visibility.Collapsed;

            if (console.Visibility != Visibility.Visible)
            {
                vis = Visibility.Visible;
            }

            console.Visibility = vis;
            ctrlConsoleCopy.Visibility = vis;
        }

        /// <summary>
        /// Called when the user wants to copy the console contents to the clipboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_CopyConsole(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(ctrlConsole.Text, TextDataFormat.Text);
        }

#endregion

    }
}
