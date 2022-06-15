using SPiApp.Common;
using SPiApp.Settings;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SPiApp
{
    /// <summary>
    /// Create Map form.
    /// </summary>
    public partial class FormM1 : Form
    {
        /// <summary>
        /// Get the name of the selected map.
        /// </summary>
        public string SelectedMap
        {
            get;
            private set;
        }

        public FormM1()
        {
            InitializeComponent();
            SelectedMap = "<none>";
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Called when the form has completed initialization.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitializeTemplates(object sender, EventArgs e)
        {
            List<string> templates = new List<string>();
            Template.GetTemplates(ref templates, TemplateType.Maps);

            ctrlTemplates.Items.Clear();
            ctrlTemplates.Items.AddRange(templates.ToArray());

            string storedTemplate = UserData.SelectedMapTemplate;

            for (int i = 0; i < ctrlTemplates.Items.Count; i++)
            {
                object item = ctrlTemplates.Items[i];
                string template = item as string;

                if (!string.IsNullOrEmpty(template))
                {
                    if (template == storedTemplate)
                    {
                        ctrlTemplates.SelectedIndex = i;
                        return;
                    }
                }
            }

            // Select the default value
            ctrlTemplates.SelectedIndex = 0;
        }

        /// <summary>
        /// Called when the user has selected an other template.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedTemplate(object sender, EventArgs e)
        {
            int index = ctrlTemplates.SelectedIndex;
            object item = ctrlTemplates.Items[index];
            string template = item as string;

            if (!string.IsNullOrEmpty(template))
            {
                UserData.SelectedMapTemplate = template;
            }
        }

        /// <summary>
        /// Called when the user is typing in the mod name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuickCreate(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CreateMap(null, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Called when the user has pressed the Create Map button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateMap(object sender, EventArgs e)
        {
            string template = UserData.SelectedMapTemplate;
            string mapName = ctrlMapName.Text;

            if (!Utility.IsValid(mapName))
            {
                MessageBox.Show("The given map name is not valid.", "Invalid map name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (template == "<none>")
            {
                MessageBox.Show("Please select a template.", "Template?", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SelectedMap = mapName;
                Template.Install(TemplateType.Maps, template, mapName);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
