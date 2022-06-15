using SPiApp.Common;

namespace SPiApp.Settings
{
    /// <summary>
    /// The preferences as set by the user.
    /// </summary>
    public static class Preferences
    {
        private static PersistenceFile pers = new PersistenceFile("app.pref");

        /// <summary>
        /// Suspends the autosave ability for the preferences file.
        /// </summary>
        public static void Suspend()
        {
            pers.Suspend();
        }

        /// <summary>
        /// Resumes the autosave ability for the preferences file.
        /// </summary>
        /// <param name="save">An indicator to whether or not changed have to be save immediately or not.</param>
        public static void Resume(bool save = true)
        {
            pers.Resume(save);
        }

        /// <summary>
        /// Get the user's default installation path.
        /// </summary>
        /// <returns>The user's default installation path.</returns>
        private static string GetDefaultInstallPath()
        {
            if (_installPath == null)
            {
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
                _installPath = "C:\\Program Files (x86)\\Activision\\Call of Duty 4";
            }

            return _installPath;
        }
        private static string _installPath = null;

        /// <summary>
        /// Get or set the installation path.
        /// </summary>
        public static string InstallPath
        {
            get
            {
                return pers.GetValue(INSTALL_PATH, GetDefaultInstallPath());
            }
            set
            {
                pers.SetValue(INSTALL_PATH, value);
            }
        }
        const string INSTALL_PATH = "InstallPath";

        /// <summary>
        /// Get or set the prefered language.
        /// </summary>
        public static string Language
        {
            get
            {
                return pers.GetValue(LANGUAGE, "English");
            }
            set
            {
                pers.SetValue(LANGUAGE, value);
            }
        }
        const string LANGUAGE = "Language";

        /// <summary>
        /// Get or set the synchronization between these and the original compile tools.
        /// </summary>
        public static bool SyncTools
        {
            get
            {
                return pers.GetValue(SYNC_TOOLS, false);
            }
            set
            {
                pers.SetValue(SYNC_TOOLS, value);
            }
        }
        const string SYNC_TOOLS = "SyncTools";

        /// <summary>
        /// Get or set the prefered executable for running Call of Duty 4 Single Player.
        /// </summary>
        public static string Executable
        {
            get
            {
                return pers.GetValue(EXECUTABLE, "iw3sp.exe");
            }
            set
            {
                pers.SetValue(EXECUTABLE, value);
            }
        }
        const string EXECUTABLE = "Executable";

        /// <summary>
        /// Get or set the prefered zipper for packing IWD files with.
        /// </summary>
        public static string Zipper
        {
            get
            {
                return pers.GetValue(ZIPPER, "mods\\ModWarfare\\7za.exe");
            }
            set
            {
                pers.SetValue(ZIPPER, value);
            }
        }
        const string ZIPPER = "Zipper";

        /// <summary>
        /// Get or set the prefered text editor for code editing.
        /// </summary>
        public static string TextEditor
        {
            get
            {
                return pers.GetValue(TEXT_EDITOR, string.Empty);
            }
            set
            {
                pers.SetValue(TEXT_EDITOR, value);
            }
        }
        const string TEXT_EDITOR = "TextEditor";

        /// <summary>
        /// Get or set the text for custom control #0.
        /// </summary>
        public static string Custom0Text
        {
            get
            {
                return pers.GetValue(CUSTOM0_TEXT, string.Empty);
            }
            set
            {
                pers.SetValue(CUSTOM0_TEXT, value);
            }
        }
        const string CUSTOM0_TEXT = "Custom0Text";

        /// <summary>
        /// Get or set the text for custom control #1.
        /// </summary>
        public static string Custom1Text
        {
            get
            {
                return pers.GetValue(CUSTOM1_TEXT, string.Empty);
            }
            set
            {
                pers.SetValue(CUSTOM1_TEXT, value);
            }
        }
        const string CUSTOM1_TEXT = "Custom1Text";

        /// <summary>
        /// Get or set the text for custom control #2.
        /// </summary>
        public static string Custom2Text
        {
            get
            {
                return pers.GetValue(CUSTOM2_TEXT, string.Empty);
            }
            set
            {
                pers.SetValue(CUSTOM2_TEXT, value);
            }
        }
        const string CUSTOM2_TEXT = "Custom2Text";

        /// <summary>
        /// Get or set the text for custom control #3.
        /// </summary>
        public static string Custom3Text
        {
            get
            {
                return pers.GetValue(CUSTOM3_TEXT, string.Empty);
            }
            set
            {
                pers.SetValue(CUSTOM3_TEXT, value);
            }
        }
        const string CUSTOM3_TEXT = "Custom3Text";

        /// <summary>
        /// Get or set the destination for custom control #0.
        /// </summary>
        public static string Custom0Value
        {
            get
            {
                return pers.GetValue(CUSTOM0_VALUE, string.Empty);
            }
            set
            {
                pers.SetValue(CUSTOM0_VALUE, value);
            }
        }
        const string CUSTOM0_VALUE = "Custom0Value";

        /// <summary>
        /// Get or set the destination for custom control #1.
        /// </summary>
        public static string Custom1Value
        {
            get
            {
                return pers.GetValue(CUSTOM1_VALUE, string.Empty);
            }
            set
            {
                pers.SetValue(CUSTOM1_VALUE, value);
            }
        }
        const string CUSTOM1_VALUE = "Custom1Value";

        /// <summary>
        /// Get or set the destination for custom control #2.
        /// </summary>
        public static string Custom2Value
        {
            get
            {
                return pers.GetValue(CUSTOM2_VALUE, string.Empty);
            }
            set
            {
                pers.SetValue(CUSTOM2_VALUE, value);
            }
        }
        const string CUSTOM2_VALUE = "Custom2Value";

        /// <summary>
        /// Get or set the destination for custom control #3.
        /// </summary>
        public static string Custom3Value
        {
            get
            {
                return pers.GetValue(CUSTOM3_VALUE, string.Empty);
            }
            set
            {
                pers.SetValue(CUSTOM3_VALUE, value);
            }
        }
        const string CUSTOM3_VALUE = "Custom3Value";
    }
}
