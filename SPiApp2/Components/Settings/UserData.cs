using SPiApp2.Components.Common;
using System;
using System.IO;

namespace SPiApp2.Components.Settings
{
    /// <summary>
    /// Settings as stored by the application for user convenience.
    /// </summary>
    public class UserData : SettingsFile
    {
        private static UserData _instance = null;

        public static UserData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserData();
                }

                return _instance;
            }
        }

        // Controls
        private const string SELECTED_TAB = "SelectedTab";
        private const string SELECTED_TAB_OPTIONS = "SelectedTabOptions";
        private const string ZONE_MAP_TAB = "ZoneMapTab";

        // Map
        private const string SELECTED_MAP = "SelectedMap";
        private const string SELECTED_MAP_TEMPLATE = "SelectedMapTemplate";
        private const string MAP_DEVELOPER = "MapDeveloper";
        private const string MAP_DEVELOPER_SCRIPT = "MapDeveloperScript";
        private const string MAP_CHEATS = "MapCheats";
        private const string MAP_CMD_KEY = "MapCustom";
        private const string MAP_CMD_VAL = "MapOptions";

        // Mod
        private const string SELECTED_MOD = "SelectedMod";
        private const string SELECTED_MOD_TEMPLATE = "SelectedModTemplate";
        private const string MOD_EXE_TARGET = "ModExeTarget";
        private const string MOD_DEVELOPER = "ModDeveloper";
        private const string MOD_DEVELOPER_SCRIPT = "ModDeveloperScript";
        private const string MOD_CHEATS = "ModCheats";
        private const string MOD_USE_MAP = "ModUseMap";
        private const string MOD_CMD_KEY = "ModCustom";
        private const string MOD_CMD_VAL = "ModOptions";

        // Miscellaneous
        private const string GRID_MODEL_DOTS = "GridEnable";
        private const string GRID_EDIT_TYPE = "GridValue";
        private const string CLEAR_MAP_MAIN = "ClearMapMain";
        private const string CLEAR_MAP_MOD = "ClearMapMod";
        private const string CLEAR_MOD_MOD = "ClearModMod";
        private const string RADIANT_USE_MAP = "RadiantUseMap";

        private UserData() :
            base(false)
        {
            Utility.GetWindow(out MainWindow window);

            // Controls
            Bind(SELECTED_TAB, ref window.rootTabs);
            Bind(SELECTED_TAB_OPTIONS, ref window.ctrlMapOptions);
            Bind(ZONE_MAP_TAB, 0);

            // Map
            Bind(SELECTED_MAP, string.Empty);
            Bind(SELECTED_MAP_TEMPLATE, "<none>");
            Bind(MAP_DEVELOPER, ref window.ctrlMapDeveloper);
            Bind(MAP_DEVELOPER_SCRIPT, ref window.ctrlMapDeveloperScript);
            Bind(MAP_CHEATS, ref window.ctrlMapCheats);
            Bind(MAP_CMD_KEY, ref window.ctrlMapCommandLineKey);
            Bind(MAP_CMD_VAL, ref window.ctrlMapCommandLineValue);

            // Mod
            Bind(SELECTED_MOD, string.Empty);
            Bind(SELECTED_MOD_TEMPLATE, "<none>");
            Bind(MOD_DEVELOPER, ref window.ctrlModDeveloper);
            Bind(MOD_DEVELOPER_SCRIPT, ref window.ctrlModDeveloperScript);
            Bind(MOD_CHEATS, ref window.ctrlModCheats);
            Bind(MOD_USE_MAP, ref window.ctrlModUseMap);
            Bind(MOD_CMD_KEY, ref window.ctrlModCommandLineKey);
            Bind(MOD_CMD_VAL, ref window.ctrlModCommandLineValue);
            BindGroup(MOD_EXE_TARGET, window.ctrlModTargetSP, window.ctrlModTargetMP);

            // Miscellaneous
            Bind(GRID_MODEL_DOTS, ref window.ctrlMapGridKey);
            Bind(GRID_EDIT_TYPE, ref window.ctrlMapGridValue);
            Bind(CLEAR_MAP_MAIN, false);
            Bind(CLEAR_MAP_MOD, false);
            Bind(CLEAR_MOD_MOD, false);
            Bind(RADIANT_USE_MAP, ref window.ctrlRadiantLoadMap);
        }

        protected override string GetPath()
        {
            return string.Format("{0}{1}settings{1}app.state",
                Environment.CurrentDirectory, Path.DirectorySeparatorChar);
        }

        protected override string GetAltPath()
        {
            return null;
        }

        /// <summary>
        /// Get the last selected tab.
        /// </summary>
        public static int SelectedTab
        {
            get
            {
                return Instance.GetInt(SELECTED_TAB);
            }
        }

        /// <summary>
        /// Get the last selected tab options.
        /// </summary>
        public static int SelectedTabOptions
        {
            get
            {
                return Instance.GetInt(SELECTED_TAB_OPTIONS);
            }
        }

        /// <summary>
        /// Get or set the last selected map.
        /// </summary>
        public static string SelectedMap
        {
            get
            {
                return Instance.GetString(SELECTED_MAP);
            }
            set
            {
                Instance.SetString(SELECTED_MAP, value);
            }
        }

        /// <summary>
        /// Get or set the last selected map template.
        /// </summary>
        public static string SelectedMapTemplate
        {
            get
            {
                return Instance.GetString(SELECTED_MAP_TEMPLATE);
            }
            set
            {
                Instance.SetString(SELECTED_MAP_TEMPLATE, value);
            }
        }
        
        /// <summary>
        /// Get whether developer mode should be enabled when launching maps.
        /// </summary>
        public static bool MapDeveloper
        {
            get
            {
                return Instance.GetBool(MAP_DEVELOPER);
            }
        }

        /// <summary>
        /// Get whether developer_script should be enabled when launching maps.
        /// </summary>
        public static bool MapDeveloperScript
        {
            get
            {
                return Instance.GetBool(MAP_DEVELOPER_SCRIPT);
            }
        }

        /// <summary>
        /// Get whether thereisacow should be enabled when launching maps.
        /// </summary>
        public static bool MapCheats
        {
            get
            {
                return Instance.GetBool(MAP_CHEATS);
            }
        }

        /// <summary>
        /// Get whether the custom command line for maps is to be used.
        /// </summary>
        public static bool MapCustom
        {
            get
            {
                return Instance.GetBool(MAP_CMD_KEY);
            }
        }

        /// <summary>
        /// Get the custom command line options for maps.
        /// </summary>
        public static string MapOptions
        {
            get
            {
                return Instance.GetString(MAP_CMD_VAL);
            }
        }

        /// <summary>
        /// Get or set the last selected mod.
        /// </summary>
        public static string SelectedMod
        {
            get
            {
                return Instance.GetString(SELECTED_MOD);
            }
            set
            {
                Instance.SetString(SELECTED_MOD, value);
            }
        }

        /// <summary>
        /// Get or set the last selected mod template.
        /// </summary>
        public static string SelectedModTemplate
        {
            get
            {
                return Instance.GetString(SELECTED_MOD_TEMPLATE);
            }
            set
            {
                Instance.SetString(SELECTED_MOD_TEMPLATE, value);
            }
        }

        /// <summary>
        /// Gets an indicator to which target is set (SP or MP).
        /// </summary>
        public static bool ModIsSingleplayer
        {
            get
            {
                return (Instance.GetString(MOD_EXE_TARGET) == "SP");
            }
            set
            {
                if (value)
                {
                    Instance.SetString(MOD_EXE_TARGET, "SP");
                }
                else
                {
                    Instance.SetString(MOD_EXE_TARGET, "MP");
                }
            }
        }

        /// <summary>
        /// Get whether developer mode should be enabled when launching mods.
        /// </summary>
        public static bool ModDeveloper
        {
            get
            {
                return Instance.GetBool(MOD_DEVELOPER);
            }
        }

        /// <summary>
        /// Get whether developer_script should be enabled when launching mods.
        /// </summary>
        public static bool ModDeveloperScript
        {
            get
            {
                return Instance.GetBool(MOD_DEVELOPER_SCRIPT);
            }
        }

        /// <summary>
        /// Get whether thereisacow should be enabled when launching mods.
        /// </summary>
        public static bool ModCheats
        {
            get
            {
                return Instance.GetBool(MOD_CHEATS);
            }
        }

        /// <summary>
        /// Get whether to start with the selected map when starting a mod.
        /// </summary>
        public static bool ModUseMap
        {
            get
            {
                return Instance.GetBool(MOD_USE_MAP);
            }
        }

        /// <summary>
        /// Get whether the custom command line for mods is to be used.
        /// </summary>
        public static bool ModCustom
        {
            get
            {
                return Instance.GetBool(MOD_CMD_KEY);
            }
        }

        /// <summary>
        /// Get the custom command line options for mods.
        /// </summary>
        public static string ModOptions
        {
            get
            {
                return Instance.GetString(MOD_CMD_VAL);
            }
        }

        /// <summary>
        /// Get whether to collect model dots when performing a grid edit.
        /// </summary>
        public static bool GridModelDots
        {
            get
            {
                return Instance.GetBool(GRID_MODEL_DOTS);
            }
        }

        /// <summary>
        /// Get the type of grid editing to perfom.
        /// </summary>
        public static string GridEditType
        {
            get
            {
                return Instance.GetString(GRID_EDIT_TYPE);
            }
        }

        /// <summary>
        /// Get or set whether to clear the missingasset.csv file in the main directory when
        /// editing the assets file of a map.
        /// </summary>
        public static bool ClearMapMain
        {
            get
            {
                return Instance.GetBool(CLEAR_MAP_MAIN);
            }
            set
            {
                Instance.SetBool(CLEAR_MAP_MAIN, value);
            }
        }

        /// <summary>
        /// Get or set whether to clear the missingasset.csv file in the selected mod's
        /// directory when editing the assets file of a map.
        /// </summary>
        public static bool ClearMapMod
        {
            get
            {
                return Instance.GetBool(CLEAR_MAP_MOD);
            }
            set
            {
                Instance.SetBool(CLEAR_MAP_MOD, value);
            }
        }

        /// <summary>
        /// Get or set whether to clear the missingasset.csv file in the selected mod's
        /// directory when editing the assets file of the mod.
        /// </summary>
        public static bool ClearModMod
        {
            get
            {
                return Instance.GetBool(CLEAR_MOD_MOD);
            }
            set
            {
                Instance.SetBool(CLEAR_MOD_MOD, value);
            }
        }

        /// <summary>
        /// Get or set the number of the tab selected in the map's Zone Update dialog.
        /// </summary>
        public static int ZoneMapTab
        {
            get
            {
                return Instance.GetInt(ZONE_MAP_TAB);
            }
            set
            {
                Instance.SetInt(ZONE_MAP_TAB, value);
            }
        }

        /// <summary>
        /// Get or set whether the selected map should be loaded when starting radiant.
        /// </summary>
        public static bool RadiantLoadMap
        {
            get
            {
                return Instance.GetBool(RADIANT_USE_MAP);
            }
            set
            {
                Instance.SetBool(RADIANT_USE_MAP, value);
            }
        }
    }
}
