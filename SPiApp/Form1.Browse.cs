using SPiApp.Settings;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SPiApp
{
    partial class Form1
    {
        /// <summary>
        /// Opens explorer to the specified path; if the file has been specified it will also select the file.
        /// </summary>
        /// <param name="path">The path to select.</param>
        /// <param name="file">The file to select.</param>
        private void OpenExplorer(string path, string file = null)
        {
            if (!Directory.Exists(path))
            {
                MessageBox.Show(string.Format("Directory at '{0}' could not be located.", path), "Missing directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!string.IsNullOrEmpty(file) && !File.Exists(string.Format("{0}\\{1}", path, file)))
            {
                MessageBox.Show(string.Format("File at '{0}\\{1}' could not be located.", path, file), "Missing file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "explorer.exe";
                info.WorkingDirectory = path;
                info.UseShellExecute = true;

                if (string.IsNullOrEmpty(file))
                {
                    info.Arguments = path;
                }
                else
                {
                    info.Arguments = string.Format("/select,{0}\\{1}", path, file);
                }

                Process.Start(info);
            }
        }

        private void PressBrowseMod(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\mods\\{1}", Preferences.InstallPath, UserData.SelectedMod)
            );
        }

        private void BrowseMods(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\mods", Preferences.InstallPath)
            );
        }

        private void BrowseZoneSource(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\zone_source", Preferences.InstallPath)
            );
        }

        private void BrowseSourceData(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\source_data", Preferences.InstallPath)
            );
        }

        private void BrowseMain(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\main", Preferences.InstallPath)
            );
        }

        private void BrowseLocalizedstrings(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\raw\\{1}\\localizedstrings", Preferences.InstallPath, Preferences.Language.ToLower())
            );
        }

        private void BrowseMaps(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\raw\\maps", Preferences.InstallPath)
            );
        }

        private void BrowseSound(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\raw\\sound", Preferences.InstallPath)
            );
        }

        private void BrowseSoundaliases(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\raw\\soundaliases", Preferences.InstallPath)
            );
        }

        private void BrowseImageMain(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\main\\images", Preferences.InstallPath)
            );
        }

        private void BrowseImages(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\raw\\images", Preferences.InstallPath)
            );
        }

        private void BrowseMaterials(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\raw\\materials", Preferences.InstallPath)
            );
        }

        private void BrowseMaterialProperties(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\raw\\material_properties", Preferences.InstallPath)
            );
        }

        private void BrowseSun(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\raw\\sun", Preferences.InstallPath)
            );
        }

        private void BrowseVision(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\raw\\vision", Preferences.InstallPath)
            );
        }

        private void BrowseUI(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\raw\\ui", Preferences.InstallPath)
            );
        }

        private void BrowseWeapons(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\raw\\weapons\\sp", Preferences.InstallPath)
            );
        }

        private void BrowseXanims(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\raw\\xanim", Preferences.InstallPath)
            );
        }

        private void BrowseXmodels(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\raw\\xmodel", Preferences.InstallPath)
            );
        }

        private void BrowseXparts(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\raw\\xmodelparts", Preferences.InstallPath)
            );
        }

        private void BrowseXsurfs(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\raw\\xmodelsurfs", Preferences.InstallPath)
            );
        }

        private void BrowseVideo(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\main\\video", Preferences.InstallPath)
            );
        }

        private void BrowseBin(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\bin", Preferences.InstallPath)
            );
        }

        private bool OpenCodeFile(string path, string file)
        {
            string textEditor = Preferences.TextEditor;

            if (!Directory.Exists(path))
            {
                MessageBox.Show(string.Format("Directory at '{0}' could not be located.", path), "Missing directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!string.IsNullOrEmpty(file) && !File.Exists(string.Format("{0}\\{1}", path, file)))
            {
                MessageBox.Show(string.Format("File at '{0}\\{1}' could not be located.", path, file), "Missing file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(textEditor) || !File.Exists(textEditor))
            {
                OpenExplorer(path, file);
                return true;
            }
            else
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = textEditor;
                info.WorkingDirectory = path;
                info.UseShellExecute = true;
                info.Arguments = file;

                Process.Start(info);
                return true;
            }
        }

        private void ShowFileMap(object sender, EventArgs e)
        {
            OpenCodeFile(
                string.Format("{0}\\raw\\maps", Preferences.InstallPath),
                string.Format("{0}.gsc", UserData.SelectedMap)
            );
        }

        private void ShowFileCode(object sender, EventArgs e)
        {
            OpenCodeFile(
                string.Format("{0}\\raw\\maps", Preferences.InstallPath),
                string.Format("{0}_code.gsc", UserData.SelectedMap)
            );
        }

        private void ShowFileAnim(object sender, EventArgs e)
        {
            OpenCodeFile(
                string.Format("{0}\\raw\\maps", Preferences.InstallPath),
                string.Format("{0}_anim.gsc", UserData.SelectedMap)
            );
        }

        private void ShowFileFx(object sender, EventArgs e)
        {
            OpenCodeFile(
                string.Format("{0}\\raw\\maps", Preferences.InstallPath),
                string.Format("{0}_fx.gsc", UserData.SelectedMap)
            );
        }

        private void ShowFileLocalizedstrings(object sender, EventArgs e)
        {
            OpenCodeFile(
                string.Format("{0}\\raw\\{1}\\localizedstrings", Preferences.InstallPath, Preferences.Language.ToLower()),
                string.Format("{0}.str", UserData.SelectedMap)
            );
        }

        private void ShowFileSoundaliases(object sender, EventArgs e)
        {
            OpenCodeFile(
                string.Format("{0}\\raw\\soundaliases", Preferences.InstallPath),
                string.Format("{0}.csv", UserData.SelectedMap)
            );
        }

        private void BrowseMapSource(object sender, EventArgs e)
        {
            OpenExplorer(
                string.Format("{0}\\map_source", Preferences.InstallPath)
            );
        }
    }
}
