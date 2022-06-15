using SPiApp.Common;
using SPiApp.Settings;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SPiApp
{
    /// <summary>
    /// Zone Update form for maps.
    /// </summary>
    public partial class FormZ1 : Form
    {
        /// <summary>
        /// Get or set the path to the missing assets file in the main directory.
        /// </summary>
        private string MainAssets
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the path to the missing assets file in the selected mod's directory.
        /// </summary>
        private string ModAssets
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the path to the map's assets file.
        /// </summary>
        private string MapAssets
        {
            get;
            set;
        }

        public FormZ1()
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;
            tabMissingMod.Text = string.Format("mods/{0}/missingasset.csv", UserData.SelectedMod);
            ctrlClearMain.Checked = UserData.ClearMapMain;
            ctrlClearMod.Checked = UserData.ClearMapMod;
            tabMissing.SelectedIndex = UserData.ZoneMapTab;

            string installPath = Preferences.InstallPath;
            MainAssets = string.Format("{0}\\main\\missingasset.csv", installPath);
            ModAssets = string.Format("{0}\\mods\\{1}\\missingasset.csv", installPath, UserData.SelectedMod);
            MapAssets = string.Format("{0}\\zone_source\\{1}.csv", installPath, UserData.SelectedMap);
        }

        /// <summary>
        /// Called when the user has clicked any of the clear checkboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClearChanged(object sender, EventArgs e)
        {
            if (sender == ctrlClearMain)
            {
                UserData.ClearMapMain = ctrlClearMain.Checked;
            }
            else if (sender == ctrlClearMod)
            {
                UserData.ClearMapMod = ctrlClearMod.Checked;
            }
        }

        /// <summary>
        /// Called when the user has switched tabs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSwitchedTab(object sender, TabControlEventArgs e)
        {
            UserData.ZoneMapTab = tabMissing.SelectedIndex;
        }

        /// <summary>
        /// Called when the form has completed initialization.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadData(object sender, EventArgs e)
        {
            if (!File.Exists(MapAssets))
            {
                MessageBox.Show("Could not locate maps assets file. Please verify the file exists in the zone_source directory.",
                    "Missing assets file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
            else
            {
                ctrlAssetsFile.Text = File.ReadAllText(MapAssets, Encoding.ASCII);
            }

            if (File.Exists(MainAssets))
            {
                ctrlMissingMainValue.Text = File.ReadAllText(MainAssets, Encoding.ASCII);
            }

            if (File.Exists(ModAssets))
            {
                ctrlMissingModValue.Text = File.ReadAllText(ModAssets, Encoding.ASCII);
            }
        }

        /// <summary>
        /// Called when the user presses the Save button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PressSave(object sender, EventArgs e)
        {
            File.WriteAllText(MapAssets, ctrlAssetsFile.Text, Encoding.ASCII);

            if (ctrlClearMain.Checked && File.Exists(MainAssets))
            {
                File.WriteAllText(MainAssets, "\n", Encoding.ASCII);
            }

            if (ctrlClearMod.Checked && File.Exists(ModAssets))
            {
                File.WriteAllText(ModAssets, "\n", Encoding.ASCII);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
