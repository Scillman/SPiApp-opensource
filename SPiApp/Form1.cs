using SPiApp.Common;
using SPiApp.Exceptions;
using SPiApp.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SPiApp
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> mapSettings = new Dictionary<string, string>();
        private Dictionary<string, string> modSettings = new Dictionary<string, string>();
        private bool mapSettingsUpdating = true;

        public Form1()
        {
            InitializeComponent();
            CreateDefaultDirectories();
            ValidateBinDirectory();
        }

        /// <summary>
        /// Called when the form has been initialized.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnInitialized(object sender, EventArgs e)
        {
            // Suspend the saving of persistence data while initializing
            Preferences.Suspend();
            UserData.Suspend();

            try
            {
                // Set the default values
                SetDefaultValues();
                SetCustomControls();

                bool validInstallPath;
                try
                {
                    validInstallPath = CheckInstallPath();
                }
                catch (InvalidGameException)
                {
                    // At the initialization stage this exception is allowed to occur
                    // and will result in the user being locked out of the other tabs.
                    validInstallPath = false;
                }

                // Disable the tabs if the stored install path is no longer valid
                if (!validInstallPath)
                {
                    ctrlMain.SelectedIndex = 0;
                    SetTabsState(false);
                }
                else
                {
                    RefreshDataLists();
                }
            }
            catch (DescriptiveException ex)
            {
                DescriptiveException.Handle(ex);
            }

            // Resume storing persistence data after the initialization
            UserData.Resume(false);
            Preferences.Resume(false);
        }

        /// <summary>
        /// Refreshes both the maps and mods lists data.
        /// </summary>
        private void RefreshDataLists()
        {
            // Refresh both lists of maps
            RefreshMaps(null, EventArgs.Empty);
            RefreshMods(null, EventArgs.Empty);

            // Switch to the previous selected tabs
            Utility.SelectValue(ref ctrlMain, UserData.SelectedTab);
            Utility.SelectValue(ref ctrlOptionsTab, UserData.SelectedTabOptions);
        }

        /// <summary>
        /// Called to create all the default directories for our application.
        /// </summary>
        private void CreateDefaultDirectories()
        {
            string directory = Environment.CurrentDirectory;
            string[] paths = new string[8];

            // Application, Maps and Mods settings
            paths[0] = string.Format("{0}\\settings", directory);
            paths[1] = string.Format("{0}\\settings\\{1}", directory, Template.DIRECTORY_MAPS);
            paths[2] = string.Format("{0}\\settings\\{1}", directory, Template.DIRECTORY_MODS);

            // Templates are stored in these
            paths[3] = string.Format("{0}\\templates", directory);
            paths[4] = string.Format("{0}\\templates\\{1}", directory, Template.DIRECTORY_MAPS);
            paths[5] = string.Format("{0}\\templates\\{1}", directory, Template.DIRECTORY_MODS);
            paths[6] = string.Format("{0}\\templates\\{1}\\default", directory, Template.DIRECTORY_MAPS);
            paths[7] = string.Format("{0}\\templates\\{1}\\default", directory, Template.DIRECTORY_MODS);

            for (int i = 0; i < paths.Length; i++)
            {
                string path = paths[i];

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }

        /// <summary>
        /// Validates the bin directory and its files.
        /// </summary>
        /// <returns>null if succesful; otherwise, a message with more information.</returns>
        private void ValidateBinDirectory()
        {
            string subMessage = " Please reinstall the tools.";

            string directory = string.Format("{0}\\bin", Environment.CurrentDirectory);
            if (!Directory.Exists(directory))
            {
                throw new InstallationException(string.Format("Could not find bin directory.{0}", subMessage));
            }
            else
            {
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

                foreach (string file in files)
                {
                    string path = string.Format("{0}\\{1}", directory, file);
                    if (!File.Exists(path))
                    {
                        throw new InstallationException(string.Format("Could not find '{0}'.{1}", file, subMessage));
                    }
                }
            }
        }

        /// <summary>
        /// Sets the global default values that are always accesible.
        /// </summary>
        private void SetDefaultValues()
        {
            // Preferences
            PreferencesSubTabChanged(null, null);

            // Grid
            ctrlGridCollectDots.Checked = UserData.GridModelDots;
            Utility.SelectValue(ref ctrlGridType, UserData.GridEditType);

            // Map Options
            ctrlMapOptions.SetItemChecked(0, UserData.MapDeveloper);
            ctrlMapOptions.SetItemChecked(1, UserData.MapDeveloperScript);
            ctrlMapOptions.SetItemChecked(2, UserData.MapCheats);
            ctrlMapOptions.SetItemChecked(3, UserData.MapCustom);
            ctrlMapCustom.Text = UserData.MapOptions;

            // Mod Options
            ctrlModOptions.SetItemChecked(0, UserData.ModDeveloper);
            ctrlModOptions.SetItemChecked(1, UserData.ModDeveloperScript);
            ctrlModOptions.SetItemChecked(2, UserData.ModCheats);
            ctrlModOptions.SetItemChecked(3, UserData.ModCustom);
            ctrlModCustom.Text = UserData.ModOptions;
        }

        /// <summary>
        /// Checks the prefered installation path.
        /// </summary>
        /// <returns>true if the path leads to a valid installation directory; otherwise, false.</returns>
        private bool CheckInstallPath()
        {
            return CheckInstallPath(Preferences.InstallPath);
        }

        /// <summary>
        /// Checks the installation path.
        /// </summary>
        /// <param name="path">The path to check; otherwise, null to check against the stored install path.</param>
        /// <returns>true if the path leads to a valid installation directory; otherwise, false.</returns>
        private bool CheckInstallPath(string path)
        {
            return
                !string.IsNullOrEmpty(path) &&
                ValidateGameBinaries(path);
        }

        /// <summary>
        /// Validates the installation directory.
        /// </summary>
        /// <param name="installPath">The path to the installation directory.</param>
        /// <returns>true if valid; otherwise, false.</returns>
        private bool ValidateGameBinaries(string installPath)
        {
            string subMessage = " Please set a valid Call of Duty 4 installation as the preferd installation path.";

            if (!Directory.Exists(installPath))
            {
                throw new InvalidGameException(string.Format("The prefered installation path does not exist.{0}", subMessage));
            }

            string[] files =
            {
                // iw3sp/iw3mp executable
                Preferences.Executable,

                // Tools - User applications
                "sp_tool.exe",
                "mp_tool.exe",
                "bin\\asset_manager.exe",
                "bin\\CoD4EffectsEd.exe",
                "bin\\CoD4Radiant.exe",

                // Tools - Conversion and builders,
                "bin\\cod4map.exe",
                "bin\\cod4rad.exe",
                "bin\\converter.exe",
                "bin\\linker_pc.exe"
            };

            foreach (string file in files)
            {
                if (!File.Exists(string.Format("{0}\\{1}", installPath, file)))
                {
                    throw new InvalidGameException(string.Format("Could not locate '{0}' in the prefered installation path.{1}", file, subMessage));
                }
            }

            return true;
        }

        /// <summary>
        /// Changes the state of the tab pages.
        /// </summary>
        /// <param name="enabled">true to enable the pages; false, to disable the pages.</param>
        private void SetTabsState(bool enabled)
        {
            for (int i = 1; i < ctrlMain.TabPages.Count; i++)
            {
                ((Control)(ctrlMain.TabPages[i])).Enabled = enabled;
            }
        }

        /// <summary>
        /// Called when one of the top tabs has switched.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTabChanged(object sender, TabControlEventArgs e)
        {
            UserData.SelectedTab = ctrlMain.SelectedIndex;
        }

        /// <summary>
        /// Called when the user has changed the prefered tools synchronization.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SyncToolsChanged(object sender, EventArgs e)
        {
            if (ctrlSyncTools.Checked == true)
            {
                MessageBox.Show("This option is disabled during the behind the scenes rework.", "Unavailable option", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlSyncTools.Checked = false;
            }
        }

        private void CreateNewMap(object sender, EventArgs e)
        {
            FormM1 mapForm = new FormM1();
            mapForm.StartPosition = FormStartPosition.CenterParent;
            mapForm.ShowDialog(this);

            if (mapForm.DialogResult == DialogResult.OK)
            {
                bool selected = false;
                string selectedMap = mapForm.SelectedMap;
                RefreshMaps(null, EventArgs.Empty);
                SetSelectedMap(selectedMap);

                // Apply default settings
                if (selected)
                {
                    ctrlCompile.SetItemChecked(0, true);
                    ctrlCompile.SetItemChecked(1, true);
                    ctrlCompile.SetItemChecked(2, true);
                    OnMapSettingsChanged(ctrlCompile, EventArgs.Empty);

                    ctrlLightExtra.Checked = true;
                    OnMapSettingsChanged(ctrlLightExtra, EventArgs.Empty);
                }
            }
        }

        private void RefreshMaps(object sender, EventArgs e)
        {
            string mapSource = string.Format("{0}\\map_source", Preferences.InstallPath);

            if (!Directory.Exists(mapSource))
                return;

            string[] files = Directory.GetFiles(mapSource, "*.map", SearchOption.TopDirectoryOnly);

            mapSettingsUpdating = true;

            ctrlMapList.SuspendLayout();
            ctrlMapList.Items.Clear();

            foreach (string file in files)
            {
                int start = mapSource.Length + 1;
                int length = file.Length - start - 4;
                string name = file.Substring(start, length);

                if (Utility.IsValid(name))
                {
                    ctrlMapList.Items.Add(name);
                }
            }

            ctrlMapList.ResumeLayout(true);
            SetSelectedMap(UserData.SelectedMap);
            mapSettingsUpdating = false;
        }

        private void SetSelectedMap(string mapName)
        {
            Utility.SelectValue(ref ctrlMapList, mapName);
        }

        private void SelectedMap(object sender, EventArgs e)
        {
            int index = ctrlMapList.SelectedIndex;
            object item = ctrlMapList.Items[index];
            string itemName = item as string;

            if (!string.IsNullOrEmpty(itemName))
            {
                mapSettings.Clear();
                UserData.SelectedMap = itemName;
                MapSettings.LoadMapSettings(ref mapSettings, itemName);
                ApplyMapSettings();
            }
        }
        
        private bool GetMapBool(string key)
        {
            if (!mapSettings.ContainsKey(key))
            {
                mapSettings.Add(key, "False");
            }

            return (mapSettings[key].ToLower() == "true");
        }

        private void SetMapBool(string key, bool value)
        {
            mapSettings[key] = (value == true ? "True" : "False");
        }

        private string GetMapString(string key)
        {
            if (!mapSettings.ContainsKey(key))
            {
                mapSettings.Add(key, string.Empty);
            }

            return mapSettings[key];
        }

        private void SetMapString(string key, string value)
        {
            mapSettings[key] = value;
        }

        private void ApplyMapSettings()
        {
            // Compile
            ctrlCompile.SetItemChecked(0, GetMapBool("bsp"));
            ctrlCompile.SetItemChecked(1, GetMapBool("light"));
            ctrlCompile.SetItemChecked(2, GetMapBool("paths"));

            // BSP Options
            ctrlBspEnts.Checked = GetMapBool("onlyents");
            ctrlBspBlock.Checked = GetMapBool("blocksize");
            ctrlBspSample.Checked = GetMapBool("samplescale");
            ctrlBspDebug.Checked = GetMapBool("debugLightmaps");
            ctrlBspCustom.Checked = GetMapBool("bspcustom");

            ctrlBspBlockValue.Text = GetMapString("blocksize_value");
            ctrlBspSampleValue.Text = GetMapString("samplescale_value");
            ctrlBspCustomValue.Text = GetMapString("bspoptions");

            // Light Options
            ctrlLightFast.Checked = GetMapBool("fast");
            ctrlLightExtra.Checked = GetMapBool("extra");
            ctrlLightVerbose.Checked = GetMapBool("verbose");
            ctrlLightShadow.Checked = GetMapBool("modelshadow");
            ctrlLightNoShadow.Checked = GetMapBool("nomodelshadow");
            ctrlLightDump.Checked = GetMapBool("dumpoptions");
            ctrlLightTraces.Checked = GetMapBool("traces");
            ctrlLightJitter.Checked = GetMapBool("jitter");
            ctrlLightCustom.Checked = GetMapBool("lightcustom");

            ctrlLightTracesValue.Text = GetMapString("traces_value");
            ctrlLightJitterValue.Text = GetMapString("jitter_value");
            ctrlLightCustomValue.Text = GetMapString("lightoptions");
        }

        private void OnMapSettingsChanged(object sender, EventArgs e)
        {
            if (sender == ctrlMapOptions)
            {
                UserData.MapDeveloper = ctrlMapOptions.GetItemChecked(0);
                UserData.MapDeveloperScript = ctrlMapOptions.GetItemChecked(1);
                UserData.MapCheats = ctrlMapOptions.GetItemChecked(2);
                UserData.MapCustom = ctrlMapOptions.GetItemChecked(3);
            }
            else if (sender == ctrlMapCustom)
            {
                UserData.MapOptions = ctrlMapCustom.Text;
            }
            else if (sender == ctrlGridCollectDots)
            {
                UserData.GridModelDots = ctrlGridCollectDots.Checked;
            }
            else if (sender == ctrlGridType)
            {
                UserData.GridEditType = ctrlGridType.Text;
            }

            // The following are affected by the map's settings
            else if (!mapSettingsUpdating)
            {
                // Compile
                if (sender == ctrlCompile)
                {
                    SetMapBool("bsp", ctrlCompile.GetItemChecked(0));
                    SetMapBool("light", ctrlCompile.GetItemChecked(1));
                    SetMapBool("paths", ctrlCompile.GetItemChecked(2));
                }

                // BSP Options
                if (sender == ctrlBspEnts) SetMapBool("onlyents", ctrlBspEnts.Checked);
                if (sender == ctrlBspBlock) SetMapBool("blocksize", ctrlBspBlock.Checked);
                if (sender == ctrlBspSample) SetMapBool("samplescale", ctrlBspSample.Checked);
                if (sender == ctrlBspDebug) SetMapBool("debugLightmaps", ctrlBspDebug.Checked);
                if (sender == ctrlBspCustom) SetMapBool("bspcustom", ctrlBspCustom.Checked);

                if (sender == ctrlBspBlockValue) SetMapString("blocksize_value", ctrlBspBlockValue.Text);
                if (sender == ctrlBspSampleValue) SetMapString("samplescale_value", ctrlBspSampleValue.Text);
                if (sender == ctrlBspCustomValue) SetMapString("bspoptions", ctrlBspCustomValue.Text);

                // Light Options
                if (sender == ctrlLightFast) SetMapBool("fast", ctrlLightFast.Checked);
                if (sender == ctrlLightExtra) SetMapBool("extra", ctrlLightExtra.Checked);
                if (sender == ctrlLightVerbose) SetMapBool("verbose", ctrlLightVerbose.Checked);
                if (sender == ctrlLightShadow) SetMapBool("modelshadow", ctrlLightShadow.Checked);
                if (sender == ctrlLightNoShadow) SetMapBool("nomodelshadow", ctrlLightNoShadow.Checked);
                if (sender == ctrlLightDump) SetMapBool("dumpoptions", ctrlLightDump.Checked);
                if (sender == ctrlLightTraces) SetMapBool("traces", ctrlLightTraces.Checked);
                if (sender == ctrlLightJitter) SetMapBool("jitter", ctrlLightJitter.Checked);
                if (sender == ctrlLightCustom) SetMapBool("lightcustom", ctrlLightCustom.Checked);

                if (sender == ctrlLightTracesValue) SetMapString("traces_value", ctrlLightTracesValue.Text);
                if (sender == ctrlLightJitterValue) SetMapString("jitter_value", ctrlLightJitterValue.Text);
                if (sender == ctrlLightCustomValue) SetMapString("lightoptions", ctrlLightCustomValue.Text);

                MapSettings.SaveMapSettings(ref mapSettings, UserData.SelectedMap);
            }
        }

        private void PressUpdateMapZone(object sender, EventArgs e)
        {
            FormZ1 zoneForm = new FormZ1();
            zoneForm.StartPosition = FormStartPosition.CenterParent;
            zoneForm.ShowDialog(this);
        }

        private void CreateNewMod(object sender, EventArgs e)
        {
            FormM2 modForm = new FormM2();
            modForm.StartPosition = FormStartPosition.CenterParent;
            modForm.ShowDialog(this);

            if (modForm.DialogResult == DialogResult.OK)
            {
                string selected = modForm.SelectedMod;
                RefreshMods(null, EventArgs.Empty);
                SetSelectedMod(selected);
            }
        }

        private void RefreshMods(object sender, EventArgs e)
        {
            string mods = string.Format("{0}\\mods", Preferences.InstallPath);

            if (!Directory.Exists(mods))
                return;

            string[] files = Directory.GetDirectories(mods, "*", SearchOption.TopDirectoryOnly);

            ctrlModList.SuspendLayout();
            ctrlModList.Items.Clear();

            foreach (string file in files)
            {
                int start = mods.Length + 1;
                int length = file.Length - start;
                string name = file.Substring(start, length);

                if (Utility.IsValid(name))
                {
                    ctrlModList.Items.Add(name);
                }
            }

            ctrlModList.ResumeLayout(true);
            SetSelectedMod(UserData.SelectedMod);
        }

        private void SetSelectedMod(string modName)
        {
            Utility.SelectValue(ref ctrlModList, modName);
        }

        private void SelectedMod(object sender, EventArgs e)
        {
            int index = ctrlModList.SelectedIndex;
            object item = ctrlModList.Items[index];
            string itemName = item as string;

            if (!string.IsNullOrEmpty(itemName))
            {
                MapSettings.SaveModSettings(ref modSettings, itemName);
                modSettings.Clear();

                UserData.SelectedMod = itemName;
                MapSettings.LoadMapSettings(ref modSettings, itemName);
            }
        }

        private void OnModSettingsChanged(object sender, EventArgs e)
        {
            if (sender == ctrlModOptions)
            {
                UserData.ModDeveloper = ctrlModOptions.GetItemChecked(0);
                UserData.ModDeveloperScript = ctrlModOptions.GetItemChecked(1);
                UserData.ModCheats = ctrlModOptions.GetItemChecked(2);
                UserData.ModCustom = ctrlModOptions.GetItemChecked(3);
            }
            else if (sender == ctrlModCustom)
            {
                UserData.ModOptions = ctrlModCustom.Text;
            }
        }

        private void PressUpdateModZone(object sender, EventArgs e)
        {
            FormZ2 zoneForm = new FormZ2();
            zoneForm.StartPosition = FormStartPosition.CenterParent;
            zoneForm.ShowDialog(this);
        }

        private void OnTabMapOptions(object sender, TabControlEventArgs e)
        {
            UserData.SelectedTabOptions = ctrlOptionsTab.SelectedIndex;
        }

        private void OptionalBinaryKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Executable name
                if (sender == ctrlExeName)
                {
                    string exeName = ctrlExeName.Text;
                    string path = string.Format("{0}\\{1}", Preferences.InstallPath, exeName);

                    if (!File.Exists(path))
                    {
                        MessageBox.Show(string.Format("Could not find single player executable file at '{0}'.", path),
                            "Missing executable", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        // Always reset the visible text!
                        ctrlExeName.Text = Preferences.Executable;
                    }
                    else
                    {
                        Preferences.Executable = exeName;
                    }
                }

                // Text editor
                else if (sender == ctrlTextEditor)
                {
                    string editor = ctrlTextEditor.Text;

                    if (editor != string.Empty && !File.Exists(editor))
                    {
                        MessageBox.Show(string.Format("Could not find the executable file for the text editor at '{0}'.", editor),
                            "Missing executable", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        // Always reset the visible text!
                        ctrlTextEditor.Text = Preferences.TextEditor;
                    }
                    else
                    {
                        Preferences.TextEditor = editor;
                    }
                }
            }
        }

        private void PreferencesSubTabChanged(object sender, TabControlEventArgs e)
        {
            int index = ctrlPreferences.SelectedIndex;

            // Required
            if (index == 0)
            {
                ctrlInstallPath.Text = Preferences.InstallPath;
                Utility.SelectValue(ref ctrlLanguageSelect, Preferences.Language);
                ctrlZipper.Text = Preferences.Zipper;
            }

            // Advanced
            else if (index == 1)
            {
                ctrlExeName.Text = Preferences.Executable;
                ctrlTextEditor.Text = Preferences.TextEditor;
                ctrlSyncTools.Checked = Preferences.SyncTools;
            }

            // Optional
            else
            {
                Debug.Assert(index == 2);

                ctrlC0Text.Text = Preferences.Custom0Text;
                ctrlC1Text.Text = Preferences.Custom1Text;
                ctrlC2Text.Text = Preferences.Custom2Text;
                ctrlC3Text.Text = Preferences.Custom3Text;

                ctrlC0Value.Text = Preferences.Custom0Value;
                ctrlC1Value.Text = Preferences.Custom1Value;
                ctrlC2Value.Text = Preferences.Custom2Value;
                ctrlC3Value.Text = Preferences.Custom3Value;
            }
        }

        private void ClickPreferencesSave(object sender, EventArgs e)
        {
            // Required
            if (sender == ctrlRequiredSave)
            {
                Preferences.Suspend();

                Preferences.InstallPath = ctrlInstallPath.Text;
                Preferences.Language = ctrlLanguageSelect.Items[ctrlLanguageSelect.SelectedIndex] as string;
                Preferences.Zipper = ctrlZipper.Text;

                Preferences.Resume(true);
            }

            // Advanced
            else if (sender == ctrlAdvancedSave)
            {
                Preferences.Suspend();

                Preferences.Executable = ctrlExeName.Text;
                Preferences.TextEditor = ctrlTextEditor.Text;
                Preferences.SyncTools = ctrlSyncTools.Checked;

                Preferences.Resume(true);
            }

            // Optional
            else
            {
                Debug.Assert(sender == ctrlCustomSave);

                Preferences.Suspend();

                Preferences.Custom0Text = ctrlC0Text.Text;
                Preferences.Custom1Text = ctrlC1Text.Text;
                Preferences.Custom2Text = ctrlC2Text.Text;
                Preferences.Custom3Text = ctrlC3Text.Text;

                Preferences.Custom0Value = ctrlC0Value.Text;
                Preferences.Custom1Value = ctrlC1Value.Text;
                Preferences.Custom2Value = ctrlC2Value.Text;
                Preferences.Custom3Value = ctrlC3Value.Text;

                // Do this before saving as it alters data!
                SetCustomControls();

                Preferences.Resume(true);
            }
        }

        /// <summary>
        /// Called when the user wants to select a different installation path.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickBrowseInstallPath(object sender, EventArgs e)
        {
            DialogResult result = dialogInstallPath.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                string path = dialogInstallPath.SelectedPath;
                Debug.Assert(Directory.Exists(path));

                try
                {
                    bool valid = CheckInstallPath(path);
                    Debug.Assert(valid == true);

                    if (valid)
                    {
                        ctrlInstallPath.Text = path;
                        SetTabsState(true);
                    }
                    else
                    {
                        SetTabsState(false);
                    }
                }
                catch (InvalidGameException ex)
                {
                    MessageBox.Show(ex.Message, "Invalid directory selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Called when the user wants to browse for a custom zipper location.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickBrowseZipper(object sender, EventArgs e)
        {
            string installPath = Preferences.InstallPath;
            dialogZipper.InitialDirectory = installPath;

            DialogResult result = dialogZipper.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                string path = dialogZipper.FileName;
                Debug.Assert(File.Exists(path));

                if (-1 != path.IndexOf(installPath))
                {
                    path = path.Substring(installPath.Length + 1);
                }

                ctrlZipper.Text = path;
            }
        }

        /// <summary>
        /// Called when the user wants to select a different executable file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickBrowseExecutable(object sender, EventArgs e)
        {
            string installPath = Preferences.InstallPath;
            dialogExeName.InitialDirectory = installPath;

            DialogResult result = dialogExeName.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                string path = dialogExeName.FileName;
                Debug.Assert(File.Exists(path));

                if (-1 == path.IndexOf(installPath))
                {
                    MessageBox.Show("The executable must be located in the same directory as Call of Duty.",
                        "Invalid location", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ctrlExeName.Text = path.Substring(installPath.Length + 1);
                }
            }
        }

        /// <summary>
        /// Called when the user wants to select a text editor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickBrowseTextEditor(object sender, EventArgs e)
        {
            dialogTextEditor.InitialDirectory = Preferences.InstallPath;

            DialogResult result = dialogTextEditor.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                string path = dialogTextEditor.FileName;
                Debug.Assert(File.Exists(path));
                ctrlTextEditor.Text = path;
            }
        }

        /// <summary>
        /// Resets optional advanced fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickResetAdvanced(object sender, EventArgs e)
        {
            ctrlExeName.Text = "iw3sp.exe";
            ctrlTextEditor.Text = string.Empty;
            ctrlSyncTools.Checked = false;
        }

        /// <summary>
        /// Called when a custom browse button has been pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickBrowseCustom(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Debug.Assert(button != null);

            TextBox textBox;
            if (sender == ctrlC0Browse)
            {
                textBox = ctrlC0Value;
            }
            else if (sender == ctrlC1Browse)
            {
                textBox = ctrlC1Value;
            }
            else if (sender == ctrlC2Browse)
            {
                textBox = ctrlC2Value;
            }
            else
            {
                Debug.Assert(sender == ctrlC3Browse);
                textBox = ctrlC3Value;
            }

            DialogResult result = dialogCustom.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                string path = dialogCustom.FileName;
                Debug.Assert(File.Exists(path));
                textBox.Text = string.Format("\"{0}\"", path);
            }
        }

        /// <summary>
        /// Called when the user pressed the button to clear all the custom button fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickClearOptional(object sender, EventArgs e)
        {
            ctrlC0Text.Text = string.Empty;
            ctrlC1Text.Text = string.Empty;
            ctrlC2Text.Text = string.Empty;
            ctrlC3Text.Text = string.Empty;

            ctrlC0Value.Text = string.Empty;
            ctrlC1Value.Text = string.Empty;
            ctrlC2Value.Text = string.Empty;
            ctrlC3Value.Text = string.Empty;
        }
    }
}
