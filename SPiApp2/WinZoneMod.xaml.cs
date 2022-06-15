using SPiApp2.Components.Settings;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Shell;
using System.Windows.Threading;

namespace SPiApp2
{
    /// <summary>
    /// Interaction logic for WinZoneMod.xaml
    /// </summary>
    public partial class WinZoneMod : SPiApp2.Controls.CompilerWindow
    {
        private string MissingMods
        {
            get;
            set;
        }

        private string ZoneFile
        {
            get;
            set;
        }

        public WinZoneMod()
        {
            InitializeComponent();
            CenterOnParent();
            Loaded += OnLoaded;
        }

        public override void GetWindowChrome(out WindowChrome chrome)
        {
            chrome = this.chrome;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            // Set the controls
            clearMod.IsChecked = UserData.ClearModMod;

            // Get repeating settings
            string selectedMod = UserData.SelectedMod;
            string installPath = Preferences.InstallPath;

            // ugh...
            char sep = System.IO.Path.DirectorySeparatorChar;

            // Create the relative paths
            string relMods = string.Format("mods{0}{1}{0}missingasset.csv", sep, selectedMod);
            string relZone = string.Format("mods{0}{1}{0}mod.csv", sep, selectedMod);

            // Apply the relative to the headers
            headerMissingMods.Header = relMods;
            headerZoneMod.Header = relZone;

            // Create and store the absolute paths
            MissingMods = string.Format("{0}{1}{2}", installPath, sep, relMods);
            ZoneFile = string.Format("{0}{1}{2}", installPath, sep, relZone);

            // Start the dispatcher
            Dispatcher.Invoke(LoadData, DispatcherPriority.Normal);
        }

        private void LoadData()
        {
            if (!File.Exists(ZoneFile))
            {
                AppDialogMessage.Show(string.Format("Could not locate the mod's zone_source file at '{0}'", ZoneFile),
                    "Missing zone file", MessageButtons.OK, MessageIcon.Warning);
                DialogResult = true;
            }
            else
            {
                textZone.Text = File.ReadAllText(ZoneFile, Encoding.ASCII);

                if (File.Exists(MissingMods))
                {
                    textMods.Text = File.ReadAllText(MissingMods, Encoding.ASCII);
                }
            }
        }

        private void Click_Save(object sender, RoutedEventArgs e)
        {
            // First save the settings
            UserData.ClearModMod = clearMod.IsChecked.Value;

            // Write the zone file
            File.WriteAllText(ZoneFile, textZone.Text, Encoding.ASCII);

            // Clear the file is the user so desires
            if (UserData.ClearModMod)
            {
                File.WriteAllText(MissingMods, "\n", Encoding.ASCII);
            }

            // Set the result to true
            DialogResult = true;
        }
    }
}
