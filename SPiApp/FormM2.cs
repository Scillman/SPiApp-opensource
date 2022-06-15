using SPiApp.Common;
using SPiApp.Settings;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SPiApp
{
    /// <summary>
    /// Create Mod form.
    /// </summary>
    public partial class FormM2 : Form
    {
        /// <summary>
        /// Get the name of the selected mod.
        /// </summary>
        public string SelectedMod
        {
            get;
            private set;
        }

        public FormM2()
        {
            InitializeComponent();
            SelectedMod = "<none>";
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
            Template.GetTemplates(ref templates, TemplateType.Mods);

            ctrlTemplates.Items.Clear();
            ctrlTemplates.Items.AddRange(templates.ToArray());

            string storedTemplate = UserData.SelectedModTemplate;

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
                UserData.SelectedModTemplate = template;
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
                CreateMod(null, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Called when the user has pressed the Create Mod button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateMod(object sender, EventArgs e)
        {
            string template = UserData.SelectedModTemplate;
            string modName = ctrlModName.Text;

            if (!Utility.IsValid(modName))
            {
                MessageBox.Show("The given mod name is not valid.", "Invalid mod name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (template == "<none>")
            {
                MessageBox.Show("Please select a template.", "Template?", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SelectedMod = modName;
                Template.Install(TemplateType.Mods, template, modName);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
