using SPiApp.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SPiApp.Settings
{
    public static class MapSettings
    {
        /// <summary>
        /// Get the settings of the specified type for the specified name.
        /// </summary>
        /// <param name="settings">The dictionary that is going to hold all the settings.</param>
        /// <param name="mapName">The name of the map/mod.</param>
        /// <returns>The key value pairs as found in the settings file.</returns>
        private static void LoadFromFile(ref Dictionary<string, string> settings, string type, string name)
        {
            // The file to load from, look for our own file
            string path = string.Format("{0}\\settings\\{1}\\{2}.settings", Environment.CurrentDirectory, type, name);
            if (!File.Exists(path))
            {
                // Only maps have settings
                if (type != Template.DIRECTORY_MAPS)
                    return;

                // If it does not exist check for the original
                path = string.Format("{0}\\bin\\CoD4CompileTools\\{1}.settings", Preferences.InstallPath, name);
                if (!File.Exists(path))
                    return;
            }

            string data = File.ReadAllText(path);
            Parser parser = new Parser(data);

            while (!parser.IsComplete())
            {
                string key = parser.GetToken(true);

                if (!parser.IsMatch(",", false))
                    return;

                string value = parser.GetToken(false);

                // Do not add empty lines
                if (!string.IsNullOrEmpty(key) || !string.IsNullOrEmpty(value))
                {
                    settings.Add(key, Utility.Sanitize(value));
                }
            }
        }

        /// <summary>
        /// Load the specified map's settings file.
        /// </summary>
        /// <param name="settings">The dictionary to store the settings in.</param>
        /// <param name="mapName">The name of the map.</param>
        public static void LoadMapSettings(ref Dictionary<string, string> settings, string mapName)
        {
            LoadFromFile(ref settings, Template.DIRECTORY_MAPS, mapName);
        }

        /// <summary>
        /// Load the specified mod's settings file.
        /// </summary>
        /// <param name="settings">The dictionary to store the settings in.</param>
        /// <param name="modName">The name of the mod.</param>
        public static void LoadModSettings(ref Dictionary<string, string> settings, string modName)
        {
            LoadFromFile(ref settings, Template.DIRECTORY_MODS, modName);
        }

        /// <summary>
        /// Save the settings of the specified type to the specified name.
        /// </summary>
        /// <param name="settings">The dictionary that holds all the settings.</param>
        /// <param name="type">The type of of contents.</param>
        /// <param name="name">The name of the map/mod.</param>
        /// <returns>The key value pairs as found in the settings file.</returns>
        private static void SaveToFile(ref Dictionary<string, string> settings, string type, string name)
        {
            StringBuilder builder = new StringBuilder();

            foreach (KeyValuePair<string, string> pair in settings)
            {
                string value = pair.Value.ToLower();
                if (value == "true" || value == "false")
                {
                    builder.AppendFormat("{0},{1}\n", pair.Key, pair.Value);
                }
                else
                {
                    builder.AppendFormat("{0},\"{1}\"\n", pair.Key, pair.Value);
                }
            }

            string path = string.Format("{0}\\settings\\{1}\\{2}.settings", Environment.CurrentDirectory, type, name);
            File.WriteAllText(path, builder.ToString());

#if FALSE
            // We need to store it in the original directory as well
            if (type == "maps" && Preferences.SyncTools)
            {
                builder = new StringBuilder();

                foreach (KeyValuePair<string, string> pair in settings)
                {
                    builder.AppendFormat("{0},{1}\n", pair.Key, pair.Value);
                }

                path = string.Format("{0}\\bin\\CoD4CompileTools\\{1}.settings", Preferences.InstallPath, name);
                File.WriteAllText(path, builder.ToString());
            }
#endif
        }

        /// <summary>
        /// Save the map's settings to the specified file.
        /// </summary>
        /// <param name="settings">The dictionary holding the map's settings.</param>
        /// <param name="mapName">The name of the map.</param>
        public static void SaveMapSettings(ref Dictionary<string, string> settings, string mapName)
        {
            SaveToFile(ref settings, Template.DIRECTORY_MAPS, mapName);
        }

        /// <summary>
        /// Save the mod's settings to the specified file.
        /// </summary>
        /// <param name="settings">The dictionary holding the mod's settings.</param>
        /// <param name="modName">The name of the mod.</param>
        public static void SaveModSettings(ref Dictionary<string, string> settings, string modName)
        {
            SaveToFile(ref settings, Template.DIRECTORY_MODS, modName);
        }
    }
}
