using SPiApp2.Components.Settings;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Shell;
using System.Windows.Threading;

namespace SPiApp2
{
    /// <summary>
    /// Interaction logic for WinZoneMap.xaml
    /// </summary>
    public partial class WinZoneMap : SPiApp2.Controls.CompilerWindow
    {
        private string MissingMain
        {
            get;
            set;
        }

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

        public WinZoneMap()
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
            clearMain.IsChecked = UserData.ClearMapMain;
            clearMod.IsChecked = UserData.ClearMapMod;
            tabMissing.SelectedIndex = UserData.ZoneMapTab;

            // Get repeating settings
            string selectedMap = UserData.SelectedMap;
            string selectedMod = UserData.SelectedMod;
            string installPath = Preferences.InstallPath;

            // ugh...
            char sep = System.IO.Path.DirectorySeparatorChar;

            // Create the relative paths
            string relMain = string.Format("main{0}missingasset.csv", sep);
            string relMods = string.Format("mods{0}{1}{0}missingasset.csv", sep, selectedMod);
            string relMap = string.Format("zone_source{0}{1}.csv", sep, selectedMap);

            // Apply the relative to the headers
            headerMissingMain.Header = relMain;
            headerMissingMods.Header = relMods;
            headerZoneMap.Header = relMap;

            // Create and store the absolute paths
            MissingMain = string.Format("{0}{1}{2}", installPath, sep, relMain);
            MissingMods = string.Format("{0}{1}{2}", installPath, sep, relMods);
            ZoneFile = string.Format("{0}{1}{2}", installPath, sep, relMap);

            // Start the dispatcher
            Dispatcher.Invoke(LoadData, DispatcherPriority.Normal);
        }

        private void LoadData()
        {
            if (!File.Exists(ZoneFile))
            {
                AppDialogMessage.Show(string.Format("Could not locate the map's zone_source file at '{0}'", ZoneFile),
                    "Missing zone file", MessageButtons.OK, MessageIcon.Warning);
                DialogResult = true;
            }
            else
            {
                textZone.Text = File.ReadAllText(ZoneFile, Encoding.ASCII);

                if (File.Exists(MissingMain))
                {
                    textMain.Text = File.ReadAllText(MissingMain, Encoding.ASCII);
                }

                if (File.Exists(MissingMods))
                {
                    textMods.Text = File.ReadAllText(MissingMods, Encoding.ASCII);
                }
            }
        }

        private void Click_Save(object sender, RoutedEventArgs e)
        {
            // First save the settings
            UserData.ClearMapMain = clearMain.IsChecked.Value;
            UserData.ClearMapMod = clearMod.IsChecked.Value;
            UserData.Instance.Save();

            // Write the zone file
            File.WriteAllText(ZoneFile, textZone.Text, Encoding.ASCII);

            // Clear the files is the user so desires
            if (UserData.ClearMapMain)
            {
                File.WriteAllText(MissingMain, "\n", Encoding.ASCII);
            }

            if (UserData.ClearMapMod)
            {
                File.WriteAllText(MissingMods, "\n", Encoding.ASCII);
            }

            // Set the result to true
            DialogResult = true;
        }
    }
}
