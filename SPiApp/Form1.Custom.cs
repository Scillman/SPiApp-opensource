using SPiApp.Common;
using SPiApp.Settings;
using System;
using System.IO;
using System.Windows.Forms;

namespace SPiApp
{
    partial class Form1
    {
        /// <summary>
        /// Splits the value into a file/program and arguments.
        /// </summary>
        /// <param name="value">The string to split.</param>
        /// <returns>The program and its arguments.</returns>
        private string[] SplitCustomValue(string value)
        {
            string[] values = new string[2];

            // Empty string
            if (value == string.Empty)
            {
                values[0] = value;
                return values;
            }

            // Does it start with a quote?
            if (value[0] == '\"')
            {
                int index;

                // Extract the program name
                index = value.IndexOf('\"', 1);
                if (index == -1)
                {
                    values[0] = value.Substring(1, value.Length - 1);
                }
                else
                {
                    values[0] = value.Substring(1, index - 1);

                    // Extract the program parameters
                    if (value.Length > index)
                    {
                        values[1] = value.Substring(index + 1, (value.Length - 1 - index));
                        values[1] = Template.ReplaceAllKeywords(values[1]);
                    }
                }
            }
            else
            {
                values[0] = value;
            }

            // Replace the keywords in the tokens
            values[0] = Template.ReplaceAllKeywords(values[0]);

            return values;
        }

        /// <summary>
        /// Get an indicator as to whether the custom value is valid.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsCustomValueValid(string value)
        {
            string file = (SplitCustomValue(value))[0];

            if (string.IsNullOrEmpty(file))
            {
                return false;
            }

            // Target contains keywords
            if (value.IndexOf(Template.KEYWORD_MAPS, StringComparison.CurrentCultureIgnoreCase) != -1 ||
                value.IndexOf(Template.KEYWORD_MODS, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return true;
            }

            // If it does not contain keyword verify it exists
            return (File.Exists(file) || Directory.Exists(file));
        }

        /// <summary>
        /// Sets a single custom control button.
        /// </summary>
        /// <param name="button">The button to set the text on.</param>
        /// <param name="text">The text to set on the button.</param>
        /// <param name="value">The value associated with the button.</param>
        /// <returns>true if the button is enabled; otherwise, false.</returns>
        private bool SetCustomControl(ref Button button, ref TextBox cText, ref TextBox cValue, string text, string value)
        {
            cText.Text = text;
            cValue.Text = value;

            if (string.IsNullOrEmpty(text) || !IsCustomValueValid(value))
            {
                button.Text = "< not set >";
                button.Enabled = false;
                return false;
            }
            else
            {
                button.Text = text;
                button.Enabled = true;
                return true;
            }
        }

        /// <summary>
        /// Enables custom controls if they are set through the preferences file.
        /// </summary>
        private void SetCustomControls()
        {
            SetCustomControl(ref ctrlCustom0, ref ctrlC0Text, ref ctrlC0Value, Preferences.Custom0Text, Preferences.Custom0Value);
            SetCustomControl(ref ctrlCustom1, ref ctrlC1Text, ref ctrlC1Value, Preferences.Custom1Text, Preferences.Custom1Value);
            SetCustomControl(ref ctrlCustom2, ref ctrlC2Text, ref ctrlC2Value, Preferences.Custom2Text, Preferences.Custom2Value);
            SetCustomControl(ref ctrlCustom3, ref ctrlC3Text, ref ctrlC3Value, Preferences.Custom3Text, Preferences.Custom3Value);
        }

        /// <summary>
        /// Called when the value associated with a custom control has to be executed.
        /// </summary>
        /// <param name="value">The value associated with the custom control.</param>
        private void ExecuteCustomControl(string value)
        {
            string[] data = SplitCustomValue(value);
            string path = data[0];

            if (File.Exists(path))
            {
                string directory = Path.GetDirectoryName(path);
                string filename = Path.GetFileName(path);

                if (Utility.IsTextFile(filename))
                {
                    OpenCodeFile(directory, filename);
                }
                else if (Utility.IsExecutableFile(filename))
                {
                    if (!string.IsNullOrEmpty(data[1]))
                    {
                        LaunchApplication(filename, directory, data[1]);
                    }
                    else
                    {
                        LaunchApplication(filename, directory);
                    }
                }
                else
                {
                    OpenExplorer(directory, filename);
                }
            }
            else if (Directory.Exists(path))
            {
                OpenExplorer(path);
            }
            else
            {
                MessageBox.Show(string.Format("Target at {0} isn't a directory or a file.", path),
                    "Missing target", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Called when a custom control buttons has been pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PressCustomControl(object sender, EventArgs e)
        {
            if (sender == ctrlCustom0)
            {
                ExecuteCustomControl(Preferences.Custom0Value);
            }
            else if (sender == ctrlCustom1)
            {
                ExecuteCustomControl(Preferences.Custom1Value);
            }
            else if (sender == ctrlCustom2)
            {
                ExecuteCustomControl(Preferences.Custom2Value);
            }
            else if (sender == ctrlCustom3)
            {
                ExecuteCustomControl(Preferences.Custom3Value);
            }
        }
    }
}
