using SPiApp.Common;
using SPiApp.Settings;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SPiApp
{
    /// <summary>
    /// Zone Update form for mods.
    /// </summary>
    public partial class FormZ2 : Form
    {
        /// <summary>
        /// Get or set the path to the missing assets file.
        /// </summary>
        private string MissingAssets
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the path to the mod's assets file.
        /// </summary>
        private string ModAssets
        {
            get;
            set;
        }

        public FormZ2()
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;
            ctrlClearMissing.Checked = UserData.ClearModMod;

            string installPath = Preferences.InstallPath;
            string modName = UserData.SelectedMod;

            ModAssets = string.Format("{0}\\mods\\{1}\\mod.csv", installPath, modName);
            MissingAssets = string.Format("{0}\\mods\\{1}\\missingasset.csv", installPath, modName);
        }

        /// <summary>
        /// Called when the user has clicked the clear checkbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClearChanged(object sender, EventArgs e)
        {
            if (sender == ctrlClearMissing)
            {
                UserData.ClearModMod = ctrlClearMissing.Checked;
            }
        }

        /// <summary>
        /// Called when the form has completed initialization.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadData(object sender, EventArgs e)
        {
            if (!File.Exists(ModAssets))
            {
                MessageBox.Show("Could not locate mods assets file. Please verify the file exists in the respective mods directory.",
                    "Missing assets file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
            else
            {
                ctrlAssetsFile.Text = File.ReadAllText(ModAssets, Encoding.ASCII);
            }

            if (File.Exists(MissingAssets))
            {
                ctrlMissingFile.Text = File.ReadAllText(MissingAssets, Encoding.ASCII);
            }
        }

        /// <summary>
        /// Called when the user presses the Save button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PressSave(object sender, EventArgs e)
        {
            File.WriteAllText(ModAssets, ctrlAssetsFile.Text, Encoding.ASCII);

            if (ctrlClearMissing.Checked && File.Exists(MissingAssets))
            {
                File.WriteAllText(MissingAssets, "\n", Encoding.ASCII);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
