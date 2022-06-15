using SPiApp2.Components.Common;
using System;
using System.IO;

namespace SPiApp2.Components.Settings
{
    public class MapSettings : SettingsFile
    {
        private static MapSettings _instance = null;

        public static MapSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MapSettings();
                }

                return _instance;
            }
        }

        // Compile Options
        private const string COMPILE_BSP = "bsp";
        private const string COMPILE_LIGHTING = "light";
        private const string CONNECT_PATHS = "paths";

        // BSP Options
        private const string BSP_ONLY_ENTS = "onlyents";
        private const string BSP_BLOCK_SIZE_KEY = "blocksize";
        private const string BSP_BLOCK_SIZE_VAL = "blocksize_value";
        private const string BSP_SAMPLE_SCALE_KEY = "samplescale";
        private const string BSP_SAMPLE_SCALE_VAL = "samplescale_value";
        private const string BSP_DEBUG_LIGHTMAPS = "debugLightmaps";
        private const string BSP_COMMAND_LINE_KEY = "bspcustom";
        private const string BSP_COMMAND_LINE_VAL = "bspoptions";

        // Light Options
        private const string LIGHT_FAST = "fast";
        private const string LIGHT_EXTRA = "extra";
        private const string LIGHT_VERBOSE = "verbose";
        private const string LIGHT_MODEL_SHADOW = "modelshadow";
        private const string LIGHT_NO_MODEL_SHADOW = "nomodelshadow";
        private const string LIGHT_DUMP_OPTIONS = "dumpoptions";
        private const string LIGHT_TRACES_KEY = "traces";
        private const string LIGHT_TRACES_VAL = "traces_value";
        private const string LIGHT_JITTER_KEY = "jitter";
        private const string LIGHT_JITTER_VAL = "jitter_value";
        private const string LIGHT_COMMAND_LINE_KEY = "lightcustom";
        private const string LIGHT_COMMAND_LINE_VAL = "lightoptions";

        private MapSettings() :
            base(true)
        {
            Utility.GetWindow(out MainWindow window);

            // Compile
            Bind(COMPILE_BSP, ref window.ctrlMapCompileBSP);
            Bind(COMPILE_LIGHTING, ref window.ctrlMapCompileLighting);
            Bind(CONNECT_PATHS, ref window.ctrlMapConnectPaths);

            // BSP Options
            Bind(BSP_ONLY_ENTS, ref window.ctrlMapBSPOnlyEnts);
            Bind(BSP_BLOCK_SIZE_KEY, ref window.ctrlMapBSPBlockSizeKey);
            Bind(BSP_BLOCK_SIZE_VAL, ref window.ctrlMapBSPBlockSizeValue);
            Bind(BSP_SAMPLE_SCALE_KEY, ref window.ctrlMapBSPSampleScaleKey);
            Bind(BSP_SAMPLE_SCALE_VAL, ref window.ctrlMapBSPSampleScaleValue);
            Bind(BSP_DEBUG_LIGHTMAPS, ref window.ctrlMapBSPDebugLightmaps);
            Bind(BSP_COMMAND_LINE_KEY, ref window.ctrlMapBSPCommandLineKey);
            Bind(BSP_COMMAND_LINE_VAL, ref window.ctrlMapBSPCommandLineValue);

            // Light Options
            Bind(LIGHT_FAST, ref window.ctrlMapLightFast);
            Bind(LIGHT_EXTRA, ref window.ctrlMapLightExtra);
            Bind(LIGHT_VERBOSE, ref window.ctrlMapLightVerbose);
            Bind(LIGHT_MODEL_SHADOW, ref window.ctrlMapLightModelShadow);
            Bind(LIGHT_NO_MODEL_SHADOW, ref window.ctrlMapLightNoModelShadow);
            Bind(LIGHT_DUMP_OPTIONS, ref window.ctrlMapLightDumpOptions);
            Bind(LIGHT_TRACES_KEY, ref window.ctrlMapLightTracesKey);
            Bind(LIGHT_TRACES_VAL, ref window.ctrlMapLightTracesValue);
            Bind(LIGHT_JITTER_KEY, ref window.ctrlMapLightJitterKey);
            Bind(LIGHT_JITTER_VAL, ref window.ctrlMapLightJitterValue);
            Bind(LIGHT_COMMAND_LINE_KEY, ref window.ctrlMapLightCommandLineKey);
            Bind(LIGHT_COMMAND_LINE_VAL, ref window.ctrlMapLightCommandLineValue);
        }

        protected override string GetPath()
        {
            return string.Format("{0}{1}settings{1}maps{1}{2}.settings",
                Environment.CurrentDirectory, Path.DirectorySeparatorChar, UserData.SelectedMap);
        }

        protected override string GetAltPath()
        {
            return string.Format("{0}{1}bin{1}CoD4CompileTools{1}{2}.settings",
                Preferences.InstallPath, Path.DirectorySeparatorChar, UserData.SelectedMap);
        }

        public string CompileBSP
        {
            get
            {
                if (GetBool(COMPILE_BSP))
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
        }

        public string CompileLighting
        {
            get
            {
                if (GetBool(COMPILE_LIGHTING))
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
        }

        public string ConnectPaths
        {
            get
            {
                if (GetBool(CONNECT_PATHS))
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
        }

        public string OnlyEnts
        {
            get
            {
                if (GetBool(BSP_ONLY_ENTS))
                {
                    return "-onlyents";
                }
                else
                {
                    return null;
                }
            }
        }

        public string BlockSize
        {
            get
            {
                if (GetBool(BSP_BLOCK_SIZE_KEY))
                {
                    return string.Format("-blocksize {0}", GetString(BSP_BLOCK_SIZE_VAL));
                }
                else
                {
                    return null;
                }
            }
        }

        public string SampleScale
        {
            get
            {
                if (GetBool(BSP_SAMPLE_SCALE_KEY))
                {
                    return string.Format("-samplescale {0}", GetString(BSP_SAMPLE_SCALE_VAL));
                }
                else
                {
                    return null;
                }
            }
        }

        public string DebugLightmaps
        {
            get
            {
                if (GetBool(BSP_DEBUG_LIGHTMAPS))
                {
                    return "-debugLightmaps";
                }
                else
                {
                    return null;
                }
            }
        }

        public string BSPOptions
        {
            get
            {
                if (GetBool(BSP_COMMAND_LINE_KEY))
                {
                    return GetString(BSP_COMMAND_LINE_VAL);
                }
                else
                {
                    return null;
                }
            }
        }

        public string Fast
        {
            get
            {
                if (GetBool(LIGHT_FAST))
                {
                    return "-fast";
                }
                else
                {
                    return null;
                }
            }
        }

        public string Extra
        {
            get
            {
                if (GetBool(LIGHT_EXTRA))
                {
                    return "-extra";
                }
                else
                {
                    return null;
                }
            }
        }

        public string Verbose
        {
            get
            {
                if (GetBool(LIGHT_VERBOSE))
                {
                    return "-verbose";
                }
                else
                {
                    return null;
                }
            }
        }

        public string ModelShadow
        {
            get
            {
                if (GetBool(LIGHT_MODEL_SHADOW))
                {
                    return "-modelshadow";
                }
                else
                {
                    return null;
                }
            }
        }

        public string NoModelShadow
        {
            get
            {
                if (GetBool(LIGHT_NO_MODEL_SHADOW))
                {
                    return "-nomodelshadow";
                }
                else
                {
                    return null;
                }
            }
        }

        public string DumpOptions
        {
            get
            {
                if (GetBool(LIGHT_DUMP_OPTIONS))
                {
                    return "-dumpoptions";
                }
                else
                {
                    return null;
                }
            }
        }

        public string Traces
        {
            get
            {
                if (GetBool(LIGHT_TRACES_KEY))
                {
                    return string.Format("-traces {0}", GetString(LIGHT_TRACES_VAL));
                }
                else
                {
                    return null;
                }
            }
        }

        public string Jitter
        {
            get
            {
                if (GetBool(LIGHT_JITTER_KEY))
                {
                    return string.Format("-jitter {0}", GetString(LIGHT_JITTER_VAL));
                }
                else
                {
                    return null;
                }
            }
        }

        public string LightOptions
        {
            get
            {
                if (GetBool(LIGHT_COMMAND_LINE_KEY))
                {
                    return GetString(LIGHT_COMMAND_LINE_VAL);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
