using SPiApp2.Components.Settings;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shell;
using System.Windows.Threading;

namespace SPiApp2
{
    /// <summary>
    /// Interaction logic for AppDialogExtract.xaml
    /// </summary>
    public partial class AppDialogExtract : SPiApp2.Controls.CompilerWindow
    {
        /// <summary>
        /// Setting this to true will abort the extraction thread.
        /// </summary>
        private volatile bool abort = false;

        public AppDialogExtract()
        {
            InitializeComponent();
            CenterOnParent();
            Closed += Terminate;
            Loaded += OnLoaded;
        }

        public override void GetWindowChrome(out WindowChrome chrome)
        {
            chrome = this.chrome;
        }

        /// <summary>
        /// Called when the extraction thread has to terminate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Terminate(object sender, EventArgs e)
        {
            abort = true;
        }

        /// <summary>
        /// Called when the window has been loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Extract);
            thread.Start();
        }

        delegate void ParametrizedResult(bool result);
        delegate void ParametrizedUpdate(int x, int y);

        /// <summary>
        /// Sets the DialogResult in a thread-safe manner.
        /// </summary>
        /// <param name="result">The result to set.</param>
        private void SetResult(bool result)
        {
            if (!abort)
            {
                if (!Dispatcher.CheckAccess())
                {
                    Dispatcher.Invoke(new ParametrizedResult(SetResult), result);
                }
                else
                {
                    DialogResult = result;
                }
            }
        }

        /// <summary>
        /// Updates the x of y files text.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void UpdateFile(int x, int y)
        {
            if (!abort)
            {
                if (!Dispatcher.CheckAccess())
                {
                    Dispatcher.Invoke(new ParametrizedUpdate(UpdateFile), x, y);
                }
                else
                {
                    ctrlExtracting.Content = string.Format("Extracting {0} of {1} iwd files...", x, y);
                }
            }
        }

        /// <summary>
        /// Updates the x of y entries text.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void UpdateEntry(int x, int y)
        {
            if (!abort)
            {
                if (!Dispatcher.CheckAccess())
                {
                    Dispatcher.Invoke(new ParametrizedUpdate(UpdateEntry), x, y);
                }
                else
                {
                    ctrlExamining.Content = string.Format("Examining file {0} of {1}...", x, y);
                }
            }
        }

        /// <summary>
        /// Performs the actual extraction of the data.
        /// </summary>
        private void Extract()
        {
            // NOTE: The order is important, keep it this way!
            string[] files =
            {
                "iw_00",
                "iw_01",
                "iw_02",
                "iw_03",
                "iw_04",
                "iw_05",
                "iw_06",
                "iw_07",
                "iw_08",
                "iw_09",
                "iw_10",
                "iw_11",
                "localized_english_iw00",
                "localized_english_iw01",
                "localized_english_iw02",
                "localized_english_iw03",
                "localized_english_iw04",
                "localized_english_iw05",
                "iw_12",    // DLC1
                "iw_13"     // DLC2
            };

            try
            {
                char sep = System.IO.Path.DirectorySeparatorChar;
                string mainDirectory = string.Format("{0}{1}main", Preferences.InstallPath, sep);

                string imagesDirectory = string.Format("{0}{1}images", mainDirectory, sep);
                if (!Directory.Exists(imagesDirectory))
                {
                    Directory.CreateDirectory(imagesDirectory);
                }

                for (int y = 0; y < files.Length && !abort; y++)
                {
                    UpdateFile(y + 1, files.Length);

                    string file = files[y];

                    string srcPath = string.Format("{0}{1}{2}.iwd", mainDirectory, sep, file);
                    using (ZipArchive archive = ZipFile.Open(srcPath, ZipArchiveMode.Read))
                    {
                        ReadOnlyCollection<ZipArchiveEntry> entries = archive.Entries;

                        for (int x = 0; x < entries.Count && !abort; x++)
                        {
                            UpdateEntry(x + 1, entries.Count);

                            ZipArchiveEntry entry = entries[x];
                            string fileName = entry.FullName;

                            if (fileName.StartsWith("images/") && entry.Name.Length > 0)
                            {
                                string destPath = string.Format("{0}{1}{2}", imagesDirectory, sep, entry.Name);
                                entry.ExtractToFile(destPath, true);
                            }
                        }
                    }
                }

                SetResult(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                SetResult(false);
            }
        }
    }
}
