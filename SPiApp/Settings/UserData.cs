namespace SPiApp.Settings
{
    /// <summary>
    /// Settings as stored by the application for user convenience.
    /// </summary>
    public static class UserData
    {
        private static PersistenceFile pers = new PersistenceFile("app.state");

        /// <summary>
        /// Suspends the autosave ability for the user data file.
        /// </summary>
        public static void Suspend()
        {
            pers.Suspend();
        }

        /// <summary>
        /// Resumes the autosave ability for the user data file.
        /// </summary>
        /// <param name="save">An indicator to whether or not changed have to be save immediately or not.</param>
        public static void Resume(bool save = true)
        {
            pers.Resume(save);
        }

        /// <summary>
        /// Get or set the last selected tab.
        /// </summary>
        public static int SelectedTab
        {
            get
            {
                return pers.GetValue(SELECTED_TAB, 0);
            }
            set
            {
                pers.SetValue(SELECTED_TAB, value);
            }
        }
        const string SELECTED_TAB = "SelectedTab";

        /// <summary>
        /// Get or set the last selected tab options.
        /// </summary>
        public static int SelectedTabOptions
        {
            get
            {
                return pers.GetValue(SELECTED_TAB_OPTIONS, 0);
            }
            set
            {
                pers.SetValue(SELECTED_TAB_OPTIONS, value);
            }
        }
        const string SELECTED_TAB_OPTIONS = "SelectedTabOptions";

        /// <summary>
        /// Get or set the last selected map.
        /// </summary>
        public static string SelectedMap
        {
            get
            {
                return pers.GetValue(SELECTED_MAP, string.Empty);
            }
            set
            {
                pers.SetValue(SELECTED_MAP, value);
            }
        }
        const string SELECTED_MAP = "SelectedMap";

        /// <summary>
        /// Get or set the last selected map template.
        /// </summary>
        public static string SelectedMapTemplate
        {
            get
            {
                return pers.GetValue(SELECTED_MAP_TEMPLATE, "<none>");
            }
            set
            {
                pers.SetValue(SELECTED_MAP_TEMPLATE, value);
            }
        }
        const string SELECTED_MAP_TEMPLATE = "SelectedMapTemplate";

        /// <summary>
        /// Get or set whether developer mode should be enabled when launching maps.
        /// </summary>
        public static bool MapDeveloper
        {
            get
            {
                return pers.GetValue(MAP_DEVELOPER, false);
            }
            set
            {
                pers.SetValue(MAP_DEVELOPER, value);
            }
        }
        const string MAP_DEVELOPER = "MapDeveloper";

        /// <summary>
        /// Get or set whether developer_script should be enabled when launching maps.
        /// </summary>
        public static bool MapDeveloperScript
        {
            get
            {
                return pers.GetValue(MAP_DEVELOPER_SCRIPT, false);
            }
            set
            {
                pers.SetValue(MAP_DEVELOPER_SCRIPT, value);
            }
        }
        const string MAP_DEVELOPER_SCRIPT = "MapDeveloperScript";

        /// <summary>
        /// Get or set whether thereisacow should be enabled when launching maps.
        /// </summary>
        public static bool MapCheats
        {
            get
            {
                return pers.GetValue(MAP_CHEATS, false);
            }
            set
            {
                pers.SetValue(MAP_CHEATS, value);
            }
        }
        const string MAP_CHEATS = "MapCheats";

        /// <summary>
        /// Get or set whether the custom command line for maps is to be used.
        /// </summary>
        public static bool MapCustom
        {
            get
            {
                return pers.GetValue(MAP_CUSTOM, false);
            }
            set
            {
                pers.SetValue(MAP_CUSTOM, value);
            }
        }
        const string MAP_CUSTOM = "MapCustom";

        /// <summary>
        /// Get or set the custom command line options for maps.
        /// </summary>
        public static string MapOptions
        {
            get
            {
                return pers.GetValue(MAP_OPTIONS, string.Empty);
            }
            set
            {
                pers.SetValue(MAP_OPTIONS, value);
            }
        }
        const string MAP_OPTIONS = "MapOptions";

        /// <summary>
        /// Get or set the last selected mod.
        /// </summary>
        public static string SelectedMod
        {
            get
            {
                return pers.GetValue(SELECTED_MOD, string.Empty);
            }
            set
            {
                pers.SetValue(SELECTED_MOD, value);
            }
        }
        const string SELECTED_MOD = "SelectedMod";

        /// <summary>
        /// Get or set the last selected mod template.
        /// </summary>
        public static string SelectedModTemplate
        {
            get
            {
                return pers.GetValue(SELECTED_MOD_TEMPLATE, "<none>");
            }
            set
            {
                pers.SetValue(SELECTED_MOD_TEMPLATE, value);
            }
        }
        const string SELECTED_MOD_TEMPLATE = "SelectedModTemplate";

        /// <summary>
        /// Get or set whether developer mode should be enabled when launching mods.
        /// </summary>
        public static bool ModDeveloper
        {
            get
            {
                return pers.GetValue(MOD_DEVELOPER, false);
            }
            set
            {
                pers.SetValue(MOD_DEVELOPER, value);
            }
        }
        const string MOD_DEVELOPER = "ModDeveloper";

        /// <summary>
        /// Get or set whether developer_script should be enabled when launching mods.
        /// </summary>
        public static bool ModDeveloperScript
        {
            get
            {
                return pers.GetValue(MOD_DEVELOPER_SCRIPT, false);
            }
            set
            {
                pers.SetValue(MOD_DEVELOPER_SCRIPT, value);
            }
        }
        const string MOD_DEVELOPER_SCRIPT = "ModDeveloperScript";

        /// <summary>
        /// Get or set whether thereisacow should be enabled when launching mods.
        /// </summary>
        public static bool ModCheats
        {
            get
            {
                return pers.GetValue(MOD_CHEATS, false);
            }
            set
            {
                pers.SetValue(MOD_CHEATS, value);
            }
        }
        const string MOD_CHEATS = "ModCheats";

        /// <summary>
        /// Get or set whether the custom command line for mods is to be used.
        /// </summary>
        public static bool ModCustom
        {
            get
            {
                return pers.GetValue(MOD_CUSTOM, false);
            }
            set
            {
                pers.SetValue(MOD_CUSTOM, value);
            }
        }
        const string MOD_CUSTOM = "ModCustom";

        /// <summary>
        /// Get or set the custom command line options for mods.
        /// </summary>
        public static string ModOptions
        {
            get
            {
                return pers.GetValue(MOD_OPTIONS, string.Empty);
            }
            set
            {
                pers.SetValue(MOD_OPTIONS, value);
            }
        }
        const string MOD_OPTIONS = "ModOptions";

        /// <summary>
        /// Get or set whether to collect model dots when performing a grid edit.
        /// </summary>
        public static bool GridModelDots
        {
            get
            {
                return pers.GetValue(GRID_MODEL_DOTS, false);
            }
            set
            {
                pers.SetValue(GRID_MODEL_DOTS, value);
            }
        }
        const string GRID_MODEL_DOTS = "GridEnable";

        /// <summary>
        /// Get or set the type of grid editing to perfom.
        /// </summary>
        public static string GridEditType
        {
            get
            {
                return pers.GetValue(GRID_EDIT_TYPE, "Edit Exisiting Grid");
            }
            set
            {
                pers.SetValue(GRID_EDIT_TYPE, value);
            }
        }
        const string GRID_EDIT_TYPE = "GridValue";

        /// <summary>
        /// Get or set whether to clear the missingasset.csv file in the main directory when
        /// editing the assets file of a map.
        /// </summary>
        public static bool ClearMapMain
        {
            get
            {
                return pers.GetValue(CLEAR_MAP_MAIN, false);
            }
            set
            {
                pers.SetValue(CLEAR_MAP_MAIN, value);
            }
        }
        const string CLEAR_MAP_MAIN = "ClearMapMain";

        /// <summary>
        /// Get or set whether to clear the missingasset.csv file in the selected mod's
        /// directory when editing the assets file of a map.
        /// </summary>
        public static bool ClearMapMod
        {
            get
            {
                return pers.GetValue(CLEAR_MAP_MOD, false);
            }
            set
            {
                pers.SetValue(CLEAR_MAP_MOD, value);
            }
        }
        const string CLEAR_MAP_MOD = "ClearMapMod";

        /// <summary>
        /// Get or set whether to clear the missingasset.csv file in the selected mod's
        /// directory when editing the assets file of the mod.
        /// </summary>
        public static bool ClearModMod
        {
            get
            {
                return pers.GetValue(CLEAR_MOD_MOD, false);
            }
            set
            {
                pers.SetValue(CLEAR_MOD_MOD, value);
            }
        }
        const string CLEAR_MOD_MOD = "ClearModMod";

        /// <summary>
        /// Get or set the number of the tab selected in the map's Zone Update dialog.
        /// </summary>
        public static int ZoneMapTab
        {
            get
            {
                return pers.GetValue(ZONE_MAP_TAB, 0);
            }
            set
            {
                pers.GetValue(ZONE_MAP_TAB, value);
            }
        }
        const string ZONE_MAP_TAB = "ZoneMapTab";
    }
}
