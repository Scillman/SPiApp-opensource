using SPiApp2.Components.Common;
using SPiApp2.Components.Settings;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;

namespace SPiApp2.Components
{
    public static class Mod
    {
        public static bool CreateMod()
        {
            WinCreateMod dialog = new WinCreateMod();

            bool? result = dialog.ShowDialog();
            if (result != null && result.HasValue && result.Value == true)
            {
                RefreshList(true, dialog.SelectedMod);
                return true;
            }

            return false;
        }

        public static void BrowseFolder()
        {
            UserData.Instance.Save();

            string selectedMod = UserData.SelectedMod;
            string installPath = Preferences.InstallPath;
            char sep = System.IO.Path.DirectorySeparatorChar;

            if (!string.IsNullOrWhiteSpace(selectedMod))
            {
                string path = string.Format("{0}{1}mods{1}{2}", installPath, sep, selectedMod);
                SPiApp2.Components.Application.Browse(path);
            }
        }

        public static void BuildFastFile()
        {
            UserData.Instance.Save();

            SPiApp2.Components.Application.Launch(
                string.Format("{0}{1}bin{1}mod_build.bat", Environment.CurrentDirectory, System.IO.Path.DirectorySeparatorChar),
                Preferences.InstallPath,
                string.Format("\"{0}\" {1} {2}", Preferences.InstallPath, Preferences.Language.ToLower(), UserData.SelectedMod)
            );
        }

        public static void BuildIWD()
        {
            UserData.Instance.Save();

            char sep = System.IO.Path.DirectorySeparatorChar;
            string installPath = Preferences.InstallPath;
            string zipper = Preferences.Zipper;

            if (!File.Exists(zipper))
            {
                zipper = string.Format("{0}{1}{2}", installPath, sep, zipper);
                Debug.Assert(File.Exists(zipper));
            }

            SPiApp2.Components.Application.Launch(
                string.Format("{0}{1}bin{1}mod_iwd.bat", Environment.CurrentDirectory, sep),
                installPath,
                string.Format("\"{0}\" \"{1}\" {2}", installPath, zipper, UserData.SelectedMod)
            );
        }

        public static void UpdateZoneFile()
        {
            UserData.Instance.Save();
            (new WinZoneMod()).ShowDialog();
        }

        public static void RunSelectedMod()
        {
            // First save the settings
            UserData.Instance.Save();

            ModSettings settings = ModSettings.Instance;
            settings.Save();

            string installPath = Preferences.InstallPath;
            string optional = string.Empty;

            // Enable developer
            if (UserData.ModDeveloper)
                optional = string.Format("{0} +set developer 1", optional);

            // Enable developer_scipt
            if (UserData.ModDeveloperScript)
                optional = string.Format("{0} +set developer_script 1", optional);

            // Enable cheats
            if (UserData.ModCheats)
                optional = string.Format("{0} +set thereisacow 1337", optional);

            // Use selected map
            if (UserData.ModUseMap)
                optional = string.Format("{0} +devmap {1}", optional, UserData.SelectedMap);

            // Enable custom command line options
            if (UserData.ModCustom)
                optional = string.Format("{0} {1}", optional, UserData.ModOptions);

            SPiApp2.Components.Application.Launch(
                string.Format("{0}{1}bin{1}mod_run.bat", Environment.CurrentDirectory, System.IO.Path.DirectorySeparatorChar),
                installPath,
                string.Format("\"{0}\" {1} \"{2}\" {3} \"{4}\"", installPath, UserData.SelectedMod, Preferences.Executable, GetMultiplayerSign(), optional)
            );
        }

        public static void RefreshList(bool select, string target = null)
        {
            Utility.GetWindow(out MainWindow window);
            ListBox list = window.ctrlModList;

            list.SelectionChanged -= ChangedSelectedMod;
            list.Items.Clear();

            string directory = string.Format("{0}{1}mods", Preferences.InstallPath, System.IO.Path.DirectorySeparatorChar);
            if (Directory.Exists(directory))
            {
                string[] files = Directory.GetDirectories(directory, "*", SearchOption.TopDirectoryOnly);

                foreach (string file in files)
                {
                    int start = directory.Length + 1;
                    int length = file.Length - start;
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
                        target = UserData.SelectedMod;
                    }

                    Utility.SelectValue(ref list, target);

                    if (list.SelectedItem is string selected)
                    {
                        UserData.SelectedMod = selected;
                    }
                    else
                    {
                        UserData.SelectedMod = string.Empty;
                    }

                    ModSettings.Instance.Load();
                }
            }

            list.SelectionChanged += ChangedSelectedMod;
        }

        private static void ChangedSelectedMod(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                object item = e.AddedItems[0];

                if (item != null)
                {
                    string name = item as string;
                    Debug.Assert(name != null);

                    UserData.SelectedMod = name;
                    ModSettings.Instance.Load();
                }
            }
        }

        private static string GetMultiplayerSign()
        { 
            if (UserData.ModIsSingleplayer)
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }
    }
}
