using SPiApp2.Components.Common;
using SPiApp2.Components.Settings.Converters;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Controls;

namespace SPiApp2.Components.Settings
{
    public abstract class SettingsFile
    {
        private Dictionary<string, object> settings = new Dictionary<string, object>();

        /// <summary>
        /// Get an indicator to whether or not synchronization
        /// between the 'Path' and 'AltPath' has to take place.
        /// </summary>
        private bool Synchronize
        {
            get
            {
                return allowSync && Preferences.SyncTools;
            }
        }
        private readonly bool allowSync;

        /// <summary>
        /// Creates a new SettingsFile object.
        /// </summary>
        /// <param name="allowSync">Whether the file can be synched with the original compiler.</param>
        public SettingsFile(bool allowSync)
        {
            this.allowSync = allowSync;
        }

        /// <summary>
        /// Binds a group <see cref="System.Windows.Controls.RadioButton"/> controls to the SettingsFile.
        /// </summary>
        /// <param name="key">The key to bind the controls to.</param>
        /// <param name="controls">The controls to bind.</param>
        protected void BindGroup(string key, params RadioButton[] controls)
        {
            settings.Add(key, new RadioGroupConverter(controls));
        }

        /// <summary>
        /// Binds a <see cref="System.Windows.Controls.CheckBox"/> control to the SettingsFile.
        /// </summary>
        /// <param name="key">The key to bind the control to.</param>
        /// <param name="control">The control to bind.</param>
        protected void Bind(string key, ref CheckBox control)
        {
            settings.Add(key, new CheckBoxConverter(ref control));
        }

        /// <summary>
        /// Binds a <see cref="System.Windows.Controls.ComboBox"/> control to the SettingsFile.
        /// </summary>
        /// <param name="key">The key to bind the control to.</param>
        /// <param name="control">The control to bind.</param>
        protected void Bind(string key, ref ComboBox control)
        {
            settings.Add(key, new ComboBoxConverter(ref control));
        }

        /// <summary>
        /// Binds a <see cref="System.Windows.Controls.ListBox"/> control to the SettingsFile.
        /// </summary>
        /// <param name="key">The key to bind the control to.</param>
        /// <param name="control">The control to bind.</param>
        protected void Bind(string key, ref ListBox control)
        {
            settings.Add(key, new ListBoxConverter(ref control));
        }

        /// <summary>
        /// Binds a <see cref="System.Windows.Controls.TabControl"/> control to the SettingsFile.
        /// </summary>
        /// <param name="key">The key to bind the control to.</param>
        /// <param name="control">The control to bind.</param>
        protected void Bind(string key, ref TabControl control)
        {
            settings.Add(key, new TabControlConverter(ref control));
        }

        /// <summary>
        /// Binds a <see cref="System.Windows.Controls.TextBox"/> control to the SettingsFile.
        /// </summary>
        /// <param name="key">The key to bind the control to.</param>
        /// <param name="control">The control to bind.</param>
        protected void Bind(string key, ref TextBox control)
        {
            settings.Add(key, new TextBoxConverter(ref control));
        }

        /// <summary>
        /// Adds a <see cref="System.String" /> object to the SettingsFile.
        /// </summary>
        /// <remarks>Does not store with references like the Control objects.</remarks>
        /// <param name="key">The key to add.</param>
        /// <param name="value">The value to bind to the key.</param>
        protected void Bind(string key, string value)
        {
            settings.Add(key, new StringConverter(value));
        }

        /// <summary>
        /// Adds a <see cref="System.Int32" /> object to the SettingsFile.
        /// </summary>
        /// <remarks>Does not store with references like the Control objects.</remarks>
        /// <param name="key">The key to add.</param>
        /// <param name="value">The value to bind to the key.</param>
        protected void Bind(string key, int value)
        {
            settings.Add(key, new IntConverter(value));
        }

        /// <summary>
        /// Adds a <see cref="System.Boolean" /> object to the SettingsFile.
        /// </summary>
        /// <remarks>Does not store with references like the Control objects.</remarks>
        /// <param name="key">The key to add.</param>
        /// <param name="value">The value to bind to the key.</param>
        protected void Bind(string key, bool value)
        {
            settings.Add(key, new BoolConverter(value));
        }

        /// <summary>
        /// Ambiobuously gets the value without knowing the type in advance.
        /// </summary>
        /// <param name="key">The key associated with the value.</param>
        /// <returns>The string value associated with the object.</returns>
        private string GetAmbiguous(string key)
        {
            Debug.Assert((!string.IsNullOrWhiteSpace(key)),
                string.Format("SettingsFile tried to get a key ({0}) that has no reference.", key));

            if (settings.ContainsKey(key))
            {
                IConverter converter = settings[key] as IConverter;
                Debug.Assert(converter != null);
                return converter.Ambiguous;
            }
            else
            {
                // obj.GetType() == typeof(string)
                return string.Empty;
            }
        }

        /// <summary>
        /// Ambiboguously sets the value without knowing the type in advance.
        /// </summary>
        /// <param name="key">The key to set.</param>
        /// <param name="value">The value to set.</param>
        private void SetAmbiguous(string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                value = Utility.Sanitize(value);

                if (settings.ContainsKey(key))
                {
                    IConverter converter = settings[key] as IConverter;
                    Debug.Assert(converter != null);
                    converter.Ambiguous = value;
                }
                else
                {
                    Bind(key, value);
                    Debug.WriteLine(string.Format("SettingsFile has bound key ({0}) as ambiguous.", key));
                }
            }
            else
            {
                Debug.WriteLine(string.Format("SettingsFile loaded with a key ({0}) that has no reference.", key));
            }
        }

        /// <summary>
        /// Get the boolean value associated with the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The value associated with the key.</returns>
        protected bool GetBool(string key)
        {
            Debug.Assert(settings.ContainsKey(key));

            IConverter<bool> converter = settings[key] as IConverter<bool>;
            Debug.Assert(converter != null);

            return converter.Value;
        }

        /// <summary>
        /// Set the boolean value associated with the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value associated with the key.</param>
        protected void SetBool(string key, bool? value)
        {
            Debug.Assert(settings.ContainsKey(key));

            IConverter<bool> converter = settings[key] as IConverter<bool>;
            Debug.Assert(converter != null);

            converter.Value = (value != null && value.HasValue == true && value.Value == true);
        }

        /// <summary>
        /// Set the default boolean value associated with the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The default value associated with the key.</param>
        protected void SetDefaultBool(string key, bool? value)
        {
            Debug.Assert(settings.ContainsKey(key));

            IConverter<bool> converter = settings[key] as IConverter<bool>;
            Debug.Assert(converter != null);

            converter.SetDefault(value != null && value.HasValue == true && value.Value == true);
        }

        /// <summary>
        /// Get the integer value associated with the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The value associated with the key.</returns>
        protected int GetInt(string key)
        {
            Debug.Assert(settings.ContainsKey(key));

            IConverter<int> converter = settings[key] as IConverter<int>;
            Debug.Assert(converter != null);

            return converter.Value;
        }

        /// <summary>
        /// Set the integer value associated with the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value associated with the key.</param>
        protected void SetInt(string key, int value)
        {
            Debug.Assert(settings.ContainsKey(key));

            IConverter<int> converter = settings[key] as IConverter<int>;
            Debug.Assert(converter != null);

            converter.Value = value;
        }

        /// <summary>
        /// Set the default integer value associated with the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The default value associated with the key.</param>
        protected void SetDefaultInt(string key, int value)
        {
            Debug.Assert(settings.ContainsKey(key));

            IConverter<int> converter = settings[key] as IConverter<int>;
            Debug.Assert(converter != null);

            converter.SetDefault(value);
        }

        /// <summary>
        /// Get the string value associated with the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The value associated with the key.</returns>
        protected string GetString(string key)
        {
            Debug.Assert(settings.ContainsKey(key));

            IConverter<string> converter = settings[key] as IConverter<string>;
            Debug.Assert(converter != null);

            return converter.Value;
        }

        /// <summary>
        /// Set the string value associated with the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value associated with the key.</param>
        protected void SetString(string key, string value)
        {
            Debug.Assert(settings.ContainsKey(key));

            IConverter<string> converter = settings[key] as IConverter<string>;
            Debug.Assert(converter != null);

            converter.Value = value;
        }

        /// <summary>
        /// Set the default string value associated with the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The default value associated with the key.</param>
        protected void SetDefaultString(string key, string value)
        {
            Debug.Assert(settings.ContainsKey(key));

            IConverter<string> converter = settings[key] as IConverter<string>;
            Debug.Assert(converter != null);

            converter.SetDefault(value);
        }

        /// <summary>
        /// Clear all the values of the associated controls.
        /// </summary>
        private void ClearAll()
        {
            foreach (KeyValuePair<string, object> pair in settings)
            {
                IConverter converter = pair.Value as IConverter;
                Debug.Assert(converter != null);
                converter.Default();
            }
        }

        /// <summary>
        /// Clears the value of the associated control.
        /// </summary>
        /// <param name="key">The key whoms value to reset to clear.</param>
        protected void Clear(string key)
        {
            Debug.Assert(settings.ContainsKey(key));

            IConverter converter = settings[key] as IConverter;
            Debug.Assert(converter != null);

            converter.Default();
        }

        /// <summary>
        /// Load the data from file.
        /// </summary>
        public void Load()
        {
            // Clear the previous settings before setting the new settings;
            // before loading files as these contain default values.
            ClearAll();

            string path = GetPath();
            bool fileExists = File.Exists(path);

            // Check whether a file exists to load from
            if (!fileExists)
            {
                string altPath = GetAltPath();
                if (!string.IsNullOrEmpty(altPath))
                {
                    path = altPath;
                    fileExists = File.Exists(path);
                }
            }

            // If the file exists load the data
            if (fileExists)
            {
                string data = File.ReadAllText(path, Encoding.ASCII);
                Parser parser = new Parser(data);
                LinkedList<KeyValuePair<string, string>> tokens = new LinkedList<KeyValuePair<string, string>>();

                // 1) Parse the file
                while (!parser.IsComplete())
                {
                    string key = parser.GetToken(true);

                    string token = parser.GetToken(false);
                    if (token != "," && token != "=")
                        break;

                    string value = parser.GetToken(false);
                    KeyValuePair<string, string> pair = new KeyValuePair<string, string>(key, value);

                    // If they are bound to controls there will be a load order!
                    if (settings.ContainsKey(key))
                    {
                        IConverter converter = settings[key] as IConverter;
                        Debug.Assert(converter != null);

                        // Tab controls need to be done last!
                        if (converter.Type == typeof(TabControl))
                        {
                            tokens.AddLast(pair);
                        }
                        else
                        {
                            tokens.AddFirst(pair);
                        }
                    }
                    else
                    {
                        tokens.AddFirst(pair);
                    }
                }

                // 2) Apply the settings
                LinkedListNode<KeyValuePair<string, string>> node = tokens.First;
                while (node != null)
                {
                    KeyValuePair<string, string> pair = node.Value;
                    SetAmbiguous(pair.Key, pair.Value);
                    node = node.Next;
                }
            }
        }

        /// <summary>
        /// Save the data to file.
        /// </summary>
        public void Save()
        {
            // Add all the paths
            List<string> paths = new List<string>
            {
                GetPath()
            };

            // Add the alternative path if we need to synchronize
            if (Synchronize)
            {
                paths.Add(GetAltPath());
            }

            StringBuilder builder = new StringBuilder();

            // Build the settings file
            foreach (KeyValuePair<string, object> pair in settings)
            {
                string value = Utility.EscapeSmart(GetAmbiguous(pair.Key));
                builder.AppendFormat("{0},{1}\n", pair.Key, value);
            }

            // Save all the files
            foreach (string path in paths)
            {
                File.WriteAllText(path, builder.ToString(), Encoding.ASCII);
            }
        }

        /// <summary>
        /// Get the path to the file used for load and save operations.
        /// </summary>
        /// <returns>The path to the file.</returns>
        protected abstract string GetPath();

        /// <summary>
        /// Get the alternative path to the file used for load and save operations.
        /// </summary>
        /// <remarks>Only used when synchronization is active.</remarks>
        /// <returns>The path to the file.</returns>
        protected abstract string GetAltPath();

        /// <summary>
        /// Get an indicator to whether the file already exists or not.
        /// </summary>
        /// <returns>true if it exists; otherwise, false.</returns>
        public bool Exists()
        {
            if (File.Exists(GetPath()))
            {
                return true;
            }

            string altPath = GetAltPath();
            if (altPath != null)
            {
                return File.Exists(altPath);
            }

            return false;
        }

        /// <summary>
        /// Converts the value of this instance to a <see cref="System.String"/>
        /// </summary>
        /// <returns>A string whose value is the same as this instance.</returns>
        public override string ToString()
        {
            return GetPath();
        }   
    }
}
