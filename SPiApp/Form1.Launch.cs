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
        /// Launches an application.
        /// </summary>
        /// <param name="exeName">The program's executable name.</param>
        /// <param name="workingDirectory">The program's working directory.</param>
        /// <param name="arguments">The arguments to pass to the program; null if none to pass.</param>
        private void LaunchApplication(string exeName, string workingDirectory, string arguments = null)
        {
            if (!Directory.Exists(workingDirectory))
            {
                MessageBox.Show("Invalid Call of Duty 4 installation.", "Corrupted installation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!File.Exists(exeName) && !File.Exists(string.Format("{0}\\{1}", workingDirectory, exeName)))
            {
                MessageBox.Show("Can't locate program executable.", "Corrupted installation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = exeName;
                info.WorkingDirectory = workingDirectory;

                if (!string.IsNullOrEmpty(arguments))
                {
                    info.Arguments = arguments;
                }
#if FALSE
                info.UseShellExecute = false;
                info.RedirectStandardError = true;
                info.RedirectStandardOutput = true;

                Process process = new Process();
                process.StartInfo = info;
                process.ErrorDataReceived += (sender, line) => Debug.WriteLine(line.Data);
                process.OutputDataReceived += (sender, line) => Debug.WriteLine(line.Data);

                process.Start();
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();

                process.WaitForExit();

#else
                info.UseShellExecute = true;
                Process.Start(info);
#endif
            }
        }

        private void PressCompileBSP(object sender, EventArgs e)
        {
            string installPath = Preferences.InstallPath;

            // Global options
            string treepath = installPath;
            string mapname = UserData.SelectedMap;

            string compileBSP = (ctrlCompile.GetItemChecked(0) ? "1" : "0");
            string compileLight = (ctrlCompile.GetItemChecked(1) ? "1" : "0");
            string compilePaths = (ctrlCompile.GetItemChecked(2) ? "1" : "0");

            // BSP options
            string parmBSPOptions = string.Empty;
            {
                if (ctrlBspEnts.Checked)
                    parmBSPOptions = string.Format("{0} -onlyents", parmBSPOptions);

                if (ctrlBspBlock.Checked)
                    parmBSPOptions = string.Format("{0} -blocksize {1}", parmBSPOptions, ctrlBspBlockValue.Text);

                if (ctrlBspSample.Checked)
                    parmBSPOptions = string.Format("{0} -samplescale {1}", parmBSPOptions, ctrlBspSampleValue.Text);

                if (ctrlBspDebug.Checked)
                    parmBSPOptions = string.Format("{0} -debugLightmaps", parmBSPOptions);

                if (ctrlBspCustom.Checked)
                    parmBSPOptions = string.Format("{0} {1}", parmBSPOptions, ctrlBspCustomValue.Text);
            }

            if (parmBSPOptions.Length == 0)
                parmBSPOptions = "-";


            // Light options
            string parmLightOptions = string.Empty;
            {
                if (ctrlLightFast.Checked)
                    parmLightOptions = string.Format("{0} -fast", parmLightOptions);

                if (ctrlLightExtra.Checked)
                    parmLightOptions = string.Format("{0} -extra", parmLightOptions);

                if (ctrlLightVerbose.Checked)
                    parmLightOptions = string.Format("{0} -verbose", parmLightOptions);

                if (ctrlLightShadow.Checked)
                    parmLightOptions = string.Format("{0} -modelshadow", parmLightOptions);

                if (ctrlLightNoShadow.Checked)
                    parmLightOptions = string.Format("{0} -nomodelshadow", parmLightOptions);

                if (ctrlLightDump.Checked)
                    parmLightOptions = string.Format("{0} -dumpoptions", parmLightOptions);

                if (ctrlLightTraces.Checked)
                    parmLightOptions = string.Format("{0} -traces {1}", parmLightOptions, ctrlLightTracesValue.Text);

                if (ctrlLightJitter.Checked)
                    parmLightOptions = string.Format("{0} -jitter {1}", parmLightOptions, ctrlLightJitterValue.Text);

                if (ctrlLightCustom.Checked)
                    parmLightOptions = string.Format("{0} {1}", parmLightOptions, ctrlLightCustomValue.Text);
            }

            if (parmLightOptions.Length == 0)
                parmLightOptions = "-";

            string arguments = string.Format("\"{0}\" {1} \"{2}\" \"{3}\" {4} {5} {6}",
                treepath, mapname, parmBSPOptions, parmLightOptions,
                compileBSP, compileLight, compilePaths
            );

            LaunchApplication(
                string.Format("{0}\\bin\\map_compile.bat", Environment.CurrentDirectory),
                Preferences.InstallPath,
                arguments
            );
        }

        private void PressCompileReflections(object sender, EventArgs e)
        {
            string arguments = string.Format("\"{0}\" {1}", Preferences.InstallPath, UserData.SelectedMap);

            LaunchApplication(
                string.Format("{0}\\bin\\map_reflections.bat", Environment.CurrentDirectory),
                Preferences.InstallPath,
                arguments
            );
        }

        private void PressBuildMapFF(object sender, EventArgs e)
        {
            string arguments = string.Format("\"{0}\" {1} {2}", Preferences.InstallPath, Preferences.Language.ToLower(), UserData.SelectedMap);

            LaunchApplication(
                string.Format("{0}\\bin\\map_build.bat", Environment.CurrentDirectory),
                Preferences.InstallPath,
                arguments
            );
        }

        private void PressRunMap(object sender, EventArgs e)
        {
            string arguments = string.Format("\"{0}\" {1}", Preferences.InstallPath, UserData.SelectedMap);
            string optional = string.Empty;
            string exename = Preferences.Executable;

            // Enable developer
            if (ctrlMapOptions.GetItemChecked(0))
                optional = string.Format("{0} +set developer 1", optional);

            // Enable developer_scipt
            if (ctrlMapOptions.GetItemChecked(1))
                optional = string.Format("{0} +set developer_scipt 1", optional);

            // Enable cheats
            if (ctrlMapOptions.GetItemChecked(2))
                optional = string.Format("{0} +set thereisacow 1337", optional);

            // Enable custom command line options
            if (ctrlMapOptions.GetItemChecked(3))
                optional = string.Format("{0} {1}", optional, ctrlMapCustom.Text);

            LaunchApplication(
                string.Format("{0}\\bin\\map_run.bat", Environment.CurrentDirectory),
                Preferences.InstallPath,
                string.Format("{0} \"{1}\" \"{2}\"", arguments, optional, exename)
            );
        }

        private void PressStartGrid(object sender, EventArgs e)
        {
            object item = ctrlGridType.Items[ctrlGridType.SelectedIndex];
            string selected = item as string;
            Debug.Assert(!string.IsNullOrEmpty(selected));

            string treepath = Preferences.InstallPath;
            string cullxmodel = (ctrlGridCollectDots.Checked ? "0" : "1");
            string makelog = (selected == "Make New Grid" ? "1" : "2");
            string mapname = UserData.SelectedMap;
            string exename = Preferences.Executable;

            string arguments = string.Format("\"{0}\" {1} {2} {3} \"{4}\"",
                treepath, makelog, cullxmodel, mapname, exename);

            LaunchApplication(
                string.Format("{0}\\bin\\map_grid.bat", Environment.CurrentDirectory),
                Preferences.InstallPath,
                arguments
            );
        }

        private void PressUpdateModIWD(object sender, EventArgs e)
        {
            string zipper = string.Format("{0}\\bin\\7za.exe", Preferences.InstallPath);
            string arguments = string.Format("\"{0}\" \"{1}\" {2}", Preferences.InstallPath, zipper, UserData.SelectedMod);

            LaunchApplication(
                string.Format("{0}\\bin\\mod_iwd.bat", Environment.CurrentDirectory),
                Preferences.InstallPath,
                arguments
            );
        }

        private void PressBuildModFF(object sender, EventArgs e)
        {
            string arguments = string.Format("\"{0}\" {1} {2}", Preferences.InstallPath, Preferences.Language.ToLower(), UserData.SelectedMod);

            LaunchApplication(
                string.Format("{0}\\bin\\mod_build.bat", Environment.CurrentDirectory),
                Preferences.InstallPath,
                arguments
            );
        }

        private void PressRunMod(object sender, EventArgs e)
        {
            string arguments = string.Format("\"{0}\" {1}", Preferences.InstallPath, UserData.SelectedMod);
            string optional = string.Empty;
            string exename = Preferences.Executable;

            // Enable developer
            if (ctrlModOptions.GetItemChecked(0))
                optional = string.Format("{0} +set developer 1", optional);

            // Enable developer_scipt
            if (ctrlModOptions.GetItemChecked(1))
                optional = string.Format("{0} +set developer_scipt 1", optional);

            // Enable cheats
            if (ctrlModOptions.GetItemChecked(2))
                optional = string.Format("{0} +set thereisacow 1337", optional);

            // Enable custom command line options
            if (ctrlModOptions.GetItemChecked(3))
                optional = string.Format("{0} {1}", optional, ctrlModCustom.Text);

            LaunchApplication(
                string.Format("{0}\\bin\\mod_run.bat", Environment.CurrentDirectory),
                Preferences.InstallPath,
                string.Format("{0} \"{1}\" \"{2}\"", arguments, optional, exename)
            );
        }


        /// <summary>
        /// Called when Radiant has to be started.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppStartRadiant(object sender, EventArgs e)
        {
            LaunchApplication("CoD4Radiant.exe", string.Format("{0}\\bin", Preferences.InstallPath));
        }

        /// <summary>
        /// Called when EffectsEd has to be started.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppStartEffectsEd(object sender, EventArgs e)
        {
            LaunchApplication("CoD4EffectsEd.exe", string.Format("{0}\\bin", Preferences.InstallPath));
        }

        /// <summary>
        /// Called when the Assets Manager has to be started.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppStartAssetManager(object sender, EventArgs e)
        {
            LaunchApplication("asset_manager.exe", string.Format("{0}\\bin", Preferences.InstallPath));
        }

        /// <summary>
        /// Called when the Converter has to be started.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppStartConverter(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "The converter overwrites exisiting files in the raw directory." +
                " This may hinder your ability to create mods and maps." +
                " Are you sure you want to run the converter?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LaunchApplication("converter.exe", string.Format("{0}\\bin", Preferences.InstallPath));
            }
        }

        private void PressFileRadiant(object sender, EventArgs e)
        {
            string selected = string.Format("{0}\\map_source\\{1}.map", Preferences.InstallPath, UserData.SelectedMap);

            if (!File.Exists(selected))
            {
                MessageBox.Show(string.Format("Could not locate the map's source file at '{0}'", selected),
                    "Missing map source", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                LaunchApplication(
                    "CoD4Radiant.exe",
                    string.Format("{0}\\bin", Preferences.InstallPath),
                    string.Format("\"{0}\"", selected)
                );
            }
        }

        private void PressFileAssetManager(object sender, EventArgs e)
        {
            string selected = string.Format("{0}\\source_data\\{1}.gdt", Preferences.InstallPath, UserData.SelectedMap);

            if (!File.Exists(selected))
            {
                MessageBox.Show(string.Format("Could not locate the map's asset source file at '{0}'", selected),
                    "Missing asset source", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                LaunchApplication(
                    "asset_manager.exe",
                    string.Format("{0}\\bin", Preferences.InstallPath),
                    string.Format("\"{0}\"", selected)
                );
            }
        }

        private void PressFileEffectsEditor(object sender, EventArgs e)
        {
#if FALSE
            string selected = string.Format("{0}\\raw\\maps\\{1}.d3dbsp", Preferences.InstallPath, UserData.SelectedMap);

            if (!File.Exists(selected))
            {
                MessageBox.Show(string.Format("Could not locate the map's binary file at '{0}'", selected),
                    "Missing map binary", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string devraw = string.Format("{0}\\devraw\\maps", Preferences.InstallPath);
                string edOriginal = string.Format("{0}\\effectsEd_box.d3dbsp", devraw);
                string edBackup = string.Format("{0}\\effectsEd_box.d3dbsp.bak", devraw);

                // Check if we made a backup before; if not create a backup
                if (!File.Exists(edBackup))
                {
                    File.Copy(edOriginal, edBackup, false);
                }
                Debug.Assert(File.Exists(edBackup));

                // Copy our map binary
                File.Copy(selected, edOriginal, true);

                // Start the effects editor, with our own map
                AppStartEffectsEd(null, EventArgs.Empty);
            }
#else
            // Start the effects editor, with our own map
            AppStartEffectsEd(null, EventArgs.Empty);
#endif
        }
    }
}
