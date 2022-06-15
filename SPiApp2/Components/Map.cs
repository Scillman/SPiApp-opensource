using SPiApp2.Components.Common;
using SPiApp2.Components.Settings;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;

namespace SPiApp2.Components
{
    public static class Map
    {
        /// <summary>
        /// Opens the Create Map dialog and allows the creation of a new map.
        /// </summary>
        /// <returns>true if a new map has been created; otherwise, false.</returns>
        public static bool CreateMap()
        {
            WinCreateMap dialog = new WinCreateMap();

            bool? result = dialog.ShowDialog();
            if (result != null && result.HasValue && result.Value == true)
            {
                RefreshList(true, dialog.SelectedMap);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Call this to start compiling the selected map.
        /// </summary>
        public static void CompileBSP()
        {
            UserData.Instance.Save();

            MapSettings settings = MapSettings.Instance;

            // First and foremost save the settings
            settings.Save();

            // Compose the BSP Options arguments
            string paramBSPOptions = string.Empty;
            {
                string[] parameters =
                {
                    settings.OnlyEnts,
                    settings.BlockSize,
                    settings.SampleScale,
                    settings.DebugLightmaps,
                    settings.BSPOptions
                };

                foreach (string parameter in parameters)
                {
                    if (parameter != null)
                    {
                        paramBSPOptions = string.Format("{0} {1}", paramBSPOptions, parameter);
                    }
                }

                if (paramBSPOptions.Length == 0)
                {
                    paramBSPOptions = "-";
                }
                else
                {
                    paramBSPOptions = paramBSPOptions.TrimStart();
                }
            }

            // Compose the Light Options arguments
            string paramLightOptions = string.Empty;
            { 
                string[] parameters =
                {
                    settings.Fast,
                    settings.Extra,
                    settings.Verbose,
                    settings.ModelShadow,
                    settings.NoModelShadow,
                    settings.DumpOptions,
                    settings.Traces,
                    settings.Jitter,
                    settings.LightOptions
                };

                foreach (string parameter in parameters)
                {
                    if (parameter != null)
                    {
                        paramLightOptions = string.Format("{0} {1}", paramLightOptions, parameter);
                    }
                }

                if (paramLightOptions.Length == 0)
                {
                    paramLightOptions = "-";
                }
                else
                {
                    paramLightOptions = paramLightOptions.TrimStart();
                }
            }

            // Compose the batch file argument
            string arguments = string.Format("\"{0}\" {1} \"{2}\" \"{3}\" {4} {5} {6}",
                Preferences.InstallPath, UserData.SelectedMap, paramBSPOptions, paramLightOptions,
                settings.CompileBSP, settings.CompileLighting, settings.ConnectPaths
            );

            // Launch the batch file
            SPiApp2.Components.Application.Launch(
                string.Format("{0}{1}bin{1}map_compile.bat", Environment.CurrentDirectory, System.IO.Path.DirectorySeparatorChar),
                Preferences.InstallPath,
                arguments
            );
        }

        /// <summary>
        /// Call this to start compiling the reflections for the selected map.
        /// </summary>
        public static void CompileReflections()
        {
            UserData.Instance.Save();

            SPiApp2.Components.Application.Launch(
                string.Format("{0}{1}bin{1}map_reflections.bat", Environment.CurrentDirectory, System.IO.Path.DirectorySeparatorChar),
                Preferences.InstallPath,
                string.Format("\"{0}\" {1} {2}", Preferences.InstallPath, UserData.SelectedMap, GetMultiplayerSign())
            );
        }

        /// <summary>
        /// Call this to build the fast file for the selected map.
        /// </summary>
        public static void BuildFastFile()
        {
            UserData.Instance.Save();

            SPiApp2.Components.Application.Launch(
                string.Format("{0}{1}bin{1}map_build.bat", Environment.CurrentDirectory, System.IO.Path.DirectorySeparatorChar),
                Preferences.InstallPath,
                string.Format("\"{0}\" {1} {2}", Preferences.InstallPath, Preferences.Language.ToLower(), UserData.SelectedMap)
            );
        }

        /// <summary>
        /// Call this to open the dialog window for editing the selected map's zone file.
        /// </summary>
        public static void UpdateZoneFile()
        {
            UserData.Instance.Save();
            (new WinZoneMap()).ShowDialog();
        }

        /// <summary>
        /// Call this to run the selected map.
        /// </summary>
        public static void RunSelectedMap()
        {
            // First save the settings
            UserData.Instance.Save();

            string arguments = string.Format("\"{0}\" {1}", Preferences.InstallPath, UserData.SelectedMap);
            string optional = string.Empty;
            string exename = Preferences.Executable;

            // Enable developer
            if (UserData.MapDeveloper)
                optional = string.Format("{0} +set developer 1", optional);

            // Enable developer_scipt
            if (UserData.MapDeveloperScript)
                optional = string.Format("{0} +set developer_script 1", optional);

            // Enable cheats
            if (UserData.MapCheats)
                optional = string.Format("{0} +set thereisacow 1337", optional);

            // Enable custom command line options
            if (UserData.MapCustom)
                optional = string.Format("{0} {1}", optional, UserData.MapOptions);

            SPiApp2.Components.Application.Launch(
                string.Format("{0}{1}bin{1}map_run.bat", Environment.CurrentDirectory, System.IO.Path.DirectorySeparatorChar),
                Preferences.InstallPath,
                string.Format("{0} \"{1}\" \"{2}\" {3}", arguments, optional, exename, GetMultiplayerSign())
            );
        }

        /// <summary>
        /// Call this to start the grid collection process.
        /// </summary>
        public static void StartGrid()
        {
            // First save the settings
            UserData.Instance.Save();

            string treepath = Preferences.InstallPath;
            string cullxmodel = (UserData.GridModelDots ? "0" : "1");
            string makelog = (UserData.GridEditType == "Make New Grid" ? "1" : "2");
            string mapname = UserData.SelectedMap;
            string exename = Preferences.Executable;

            string arguments = string.Format("\"{0}\" {1} {2} {3} \"{4}\", {5}",
                treepath, makelog, cullxmodel, mapname, exename, GetMultiplayerSign());

            SPiApp2.Components.Application.Launch(
                string.Format("{0}{1}bin{1}map_grid.bat", Environment.CurrentDirectory, System.IO.Path.DirectorySeparatorChar),
                Preferences.InstallPath,
                arguments
            );
        }

        /// <summary>
        /// Call this to open the selected map in Radiant.
        /// </summary>
        public static void OpenInRadiant()
        {
            char sep = Path.DirectorySeparatorChar;
            string installPath = Preferences.InstallPath;
            string selectedMap = UserData.SelectedMap;

            string bin = string.Format("{0}{1}bin", installPath, sep);
            string exe = "CoD4Radiant.exe";

            if (UserData.RadiantLoadMap)
            {
                string map = string.Format("{0}{1}map_source{1}{2}.map", installPath, sep, selectedMap);

                if (File.Exists(map))
                {
                    SPiApp2.Components.Application.Launch(exe, bin, Utility.EscapeSmart(map));
                }
                else
                {
                    AppDialogMessage.Show(string.Format("Could not locate map file at:\n{0}", map),
                        "Could not locate map", MessageButtons.OK, MessageIcon.Error);
                }
            }
            else
            {
                SPiApp2.Components.Application.Launch(exe, bin);
            }
        }

        /// <summary>
        /// Call this to refresh the list of available maps.
        /// </summary>
        /// <param name="target">The name of the map to select after refresh.</param>
        public static void RefreshList(bool select, string target = null)
        {
            Utility.GetWindow(out MainWindow window);
            ListBox list = window.ctrlMapList;

            list.SelectionChanged -= ChangedSelectedMap;
            list.Items.Clear();

            string directory = string.Format("{0}{1}map_source", Preferences.InstallPath, System.IO.Path.DirectorySeparatorChar);
            if (Directory.Exists(directory))
            {
                string[] files = Directory.GetFiles(directory, "*.map", SearchOption.TopDirectoryOnly);
                Debug.Assert(files.Length > 0);

                foreach (string file in files)
                {
                    int start = directory.Length + 1;
                    int length = file.Length - start - 4;
                    string name = file.Substring(start, length);

                    if (!string.IsNullOrWhiteSpace(name) && Utility.IsValid(name))
                    {
                        list.Items.Add(name);
                    }
                }

                if (select)
                {
                    if (target == null)
                    {
                        target = UserData.SelectedMap;
                    }

                    Utility.SelectValue(ref list, target);

                    if (list.SelectedItem is string selected)
                    {
                        UserData.SelectedMap = selected;
                    }
                    else
                    {
                        UserData.SelectedMap = string.Empty;
                    }

                    MapSettings.Instance.Load();
                }
            }

            list.SelectionChanged += ChangedSelectedMap;
        }

        private static void ChangedSelectedMap(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                object item = e.AddedItems[0];

                if (item != null)
                {
                    string name = item as string;
                    Debug.Assert(name != null);

                    UserData.SelectedMap = name;
                    MapSettings.Instance.Load();
                }
            }
        }

        private static string GetMultiplayerSign()
        {
            if (IsMultiplayerMap())
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public static bool IsMultiplayerMap()
        {
            string mapName = UserData.SelectedMap;
            return mapName.StartsWith("mp_");
        }
    }
}
