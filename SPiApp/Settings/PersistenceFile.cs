using SPiApp.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SPiApp.Settings
{
    /// <summary>
    /// Defines an object holding values stored in a persistence file.
    /// </summary>
    public class PersistenceFile
    {
        private Dictionary<string, object> pers = new Dictionary<string, object>();
        private bool autosave = true;

        /// <summary>
        /// Get or set the path to the persistent file.
        /// </summary>
        private string Path
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a new persistenc file object using the given file name.
        /// </summary>
        /// <param name="name">The name of the file.</param>
        public PersistenceFile(string name)
        {
            Path = string.Format("{0}\\settings\\{1}", Environment.CurrentDirectory, name);
            Load();
        }

        /// <summary>
        /// Parses a string value to its object value.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        /// <returns>The string value as an object value.</returns>
        private object ParseStringToValue(string value)
        {
            if (bool.TryParse(value, out bool bResult))
            {
                return bResult;
            }

            if (int.TryParse(value, out int iResult))
            {
                return iResult;
            }

            return value;
        }

        /// <summary>
        /// Parses an object value to its string value.
        /// </summary>
        /// <param name="value">The object value to convert.</param>
        /// <returns>The object value as a string value.</returns>
        private string ParseValueToString(object value)
        {
            if (value.GetType() == typeof(bool))
            {
                return ((bool)value).ToString();
            }

            if (value.GetType() == typeof(int))
            {
                return ((int)value).ToString();
            }

            return value as string;
        }

        /// <summary>
        /// Loads persistent data from the file at the set path.
        /// </summary>
        private void Load()
        {
            if (File.Exists(Path))
            {
                Suspend();

                string data = File.ReadAllText(Path, Encoding.ASCII);
                Parser parser = new Parser(data);

                while (!parser.IsComplete())
                {
                    string key = parser.GetToken(true);

                    if (!parser.IsMatch("=", false))
                        break;
                
                    string value = parser.GetToken(false);
                    if (!string.IsNullOrEmpty(key) && value != null)
                    {
                        value = Utility.Sanitize(value);
                        pers[key] = ParseStringToValue(value);
                    }
                }

                Resume(false);
            }
        }

        /// <summary>
        /// Saves the persistent data to the file at the set path.
        /// </summary>
        private void Save()
        {
            StringBuilder data = new StringBuilder();

            foreach (KeyValuePair<string, object> pair in pers)
            {
                string value = ParseValueToString(pair.Value);
                string format;

                if (value.Contains(" ") || value.Contains("\t"))
                {
                    format = "{0}=\"{1}\"\n";
                }
                else
                {
                    format = "{0}={1}\n";
                }

                data.Append(string.Format(format, pair.Key, Utility.EscapeString(value)));
            }

            File.WriteAllText(Path, data.ToString(), Encoding.ASCII);
        }

        /// <summary>
        /// Suspends the autosave ability for the persistence file.
        /// </summary>
        public void Suspend()
        {
            autosave = false;
        }

        /// <summary>
        /// Resumes the autosave ability for the persistence file.
        /// </summary>
        /// <param name="save">An indicator to whether or not changed have to be save immediately or not.</param>
        /// <remarks>
        /// These functions are only to be used when multiple values are changed.
        /// This is as to prevent execcesive reading and writing to the files. But
        /// as we have to resume operations we can assume multiple values have changed.
        /// </remarks>
        public void Resume(bool save = true)
        {
            autosave = true;

            if (save)
            {
                Save();
            }
        }

        /// <summary>
        /// Get the object value associated with the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="def">The default value.</param>
        /// <returns>The object value associated with the key.</returns>
        private object GetValue(string key, object def)
        {
            if (!pers.ContainsKey(key))
            {
                pers[key] = def;
                return def;
            }

            return pers[key];
        }

        /// <summary>
        /// Get the string value associated with the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="def">The default value.</param>
        /// <returns>The string value associated with the key.</returns>
        public string GetValue(string key, string def)
        {
            return (string)GetValue(key, (object)def);
        }

        /// <summary>
        /// Get the boolean value associated with the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="def">The default value.</param>
        /// <returns>The boolean value associated with the key.</returns>
        public bool GetValue(string key, bool def)
        {
            return (bool)GetValue(key, (object)def);
        }

        /// <summary>
        /// Get the integer value associated with the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="def">The default value.</param>
        /// <returns>The integer value associated with the key.</returns>
        public int GetValue(string key, int def)
        {
            return (int)GetValue(key, (object)def);
        }

        /// <summary>
        /// Set the value of the associated key.
        /// </summary>
        /// <param name="key">The key whoms value to change.</param>
        /// <param name="value">The value to associate with the key.</param>
        public void SetValue(string key, object value)
        {
            if (!pers.ContainsKey(key))
            {
                pers[key] = value;
            }
            else
            {
                object oldValue = pers[key];
                if (!oldValue.Equals(value))
                {
                    pers[key] = value;

                    if (autosave)
                    {
                        Save();
                    }
                }
            }
        }
    }
}
