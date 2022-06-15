using SPiApp2.Components.Common;
using SPiApp2.Components.Settings;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shell;
using ComTemplate = SPiApp2.Components.Common.Template;

namespace SPiApp2
{
    /// <summary>
    /// Interaction logic for WinCreateMap.xaml
    /// </summary>
    public partial class WinCreateMap : SPiApp2.Controls.CompilerWindow
    {
        /// <summary>
        /// Get the name of the newly created map.
        /// </summary>
        public string SelectedMap
        {
            get;
            private set;
        }

        /// <summary>
        /// Called when the Create Map dialog is created.
        /// </summary>
        public WinCreateMap()
        {
            InitializeComponent();
            CenterOnParent();
            Loaded += OnLoaded;
        }

        public override void GetWindowChrome(out WindowChrome chrome)
        {
            chrome = this.chrome;
        }

        /// <summary>
        /// Called when the window has completed initialization.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            List<string> templates = new List<string>();
            ComTemplate.GetTemplates(ref templates, TemplateType.Maps);

            ctrlTemplates.Items.Clear();
            foreach (string template in templates)
            {
                ctrlTemplates.Items.Add(template);
            }

            Utility.SelectValue(ref ctrlTemplates, UserData.SelectedMapTemplate);
        }

        /// <summary>
        /// Called when the ENTER key is pressed when typing the name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyDown_CreateMap(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Click_CreateMap(null, null);
            }
        }

        /// <summary>
        /// Called when the user wishes to create the map.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_CreateMap(object sender, RoutedEventArgs e)
        {
            // Save the selected template
            string template = ctrlTemplates.SelectedItem as string;
            if (!string.IsNullOrEmpty(template))
            {
                UserData.SelectedMapTemplate = template;
            }

            // Save the data
            UserData.Instance.Save();

            // Get the map name
            string mapName = ctrlMapName.Text;
            if (!Utility.IsValid(mapName))
            {
                AppDialogMessage.Show(string.Format("The given map name of '{0}' is not valid.", mapName),
                    "Invalid map name", MessageButtons.OK, MessageIcon.Warning);
            }
            else
            {
                SelectedMap = mapName;
                ComTemplate.Install(TemplateType.Maps, template, mapName);
                DialogResult = true;
            }            
        }
    }
}
