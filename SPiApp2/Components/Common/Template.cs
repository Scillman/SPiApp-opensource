using SPiApp2.Components.Exceptions;
using SPiApp2.Components.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace SPiApp2.Components.Common
{
    [Flags]
    public enum TemplateType
    {
        Default = 0,
        Maps = 1,
        Mods = 2
    };

    public class Template
    {
        public const string DIRECTORY_MAPS = "maps";
        public const string DIRECTORY_MODS = "mods";

        public const string KEYWORD_MAPS = "yourmapname";
        public const string KEYWORD_MODS = "yourmodname";

        private const string KEYWORD_NONE = "<none>";

        /// <summary>
        /// Creates a new template class that copies the template files.
        /// </summary>
        /// <param name="directory">The directory holding the template's files.</param>
        /// <param name="keyword">The keyword that has to be replaced.</param>
        /// <param name="replacement">The word that needs to replace the keyword.</param>
        private Template(string directory, string keyword, string replacement)
        {
            Dictionary<string, string> info = new Dictionary<string, string>();
            GeneratePathPairs(ref info, directory, keyword, replacement);

            if (AllowFileWriting(info))
            {
                CopyTemplateFiles(info, keyword, replacement);
            }
        }

        /// <summary>
        /// Generates source/destination pairs for all the files in the template.
        /// </summary>
        /// <param name="info">The destination to store the pairs into.</param>
        /// <param name="directory">The directory to query for files.</param>
        /// <param name="keyword">The keyword that has to be replaced.</param>
        /// <param name="replacement">The word that needs to replace the keyword.</param>
        private void GeneratePathPairs(ref Dictionary<string, string> info, string directory, string keyword, string replacement)
        {
            string[] files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);

            // Generate a srcPath/destPath pair
            foreach (string file in files)
            {
                int start = file.IndexOf(directory) + directory.Length + 1;
                int length = file.Length - start;

                Debug.Assert(start > 0 && start < file.Length);
                Debug.Assert(length > 0 && length < file.Length - 4);

                string relPath = file.Substring(start, length).Replace(keyword.ToLower(), replacement.ToLower());
                string destPath = string.Format("{0}{1}{2}", Preferences.InstallPath, Path.DirectorySeparatorChar, relPath);

                destPath = destPath.Replace(keyword, replacement);
                info.Add(file, destPath);
            }
        }

        /// <summary>
        /// Checks if the code is allowed to write the template files to their destination.
        /// </summary>
        /// <remarks>
        /// Writing is allowed when:
        ///  - The destination files do not exist;
        ///  - The destination files do exist but the user allows overwriting.
        /// </remarks>
        /// <param name="info">The source/destination path of files to copy.</param>
        /// <returns>true if copying of the template files is allowed; otherwise, false.</returns>
        private bool AllowFileWriting(Dictionary<string, string> info)
        {
            bool filesExist = false;
            bool overwrite = false;

            // Check if one or more template files already exist
            foreach (KeyValuePair<string, string> pair in info)
            {
                if (File.Exists(pair.Value))
                {
                    MessageResult result = AppDialogMessage.Show("One or more files of the template already exist. Do you want to overwrite them?",
                        "Overwrite?", MessageButtons.YesNo, MessageIcon.Question);

                    filesExist = true;
                    overwrite = (result == MessageResult.Yes);
                    break;
                }
            }

            return (!filesExist || (filesExist && overwrite));
        }

        /// <summary>
        /// Copies all the files within in template to their destination.
        /// </summary>
        /// <param name="info">The source/destination path of files to copy.</param>
        /// <param name="keyword">The keyword that has to be replaced.</param>
        /// <param name="replacement">The word that needs to replace the keyword.</param>
        private void CopyTemplateFiles(Dictionary<string, string> info, string keyword, string replacement)
        {
            foreach (KeyValuePair<string, string> pair in info)
            {
                // Create the destination directory if it does not exist;
                // as file creation does not allow them to be created.
                string directory = Path.GetDirectoryName(pair.Value);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Binary files must be copied as is; text files need to
                // have their content checked for the keyword as well.
                if (!Utility.IsTextFile(pair.Key))
                {
                    File.Copy(pair.Key, pair.Value, true);
                }
                else
                {
                    string data = File.ReadAllText(pair.Key, Encoding.ASCII);
                    data = ReplaceKeyword(data, keyword, replacement);
                    File.WriteAllText(pair.Value, data, Encoding.ASCII);
                }
            }
        }

        /// <summary>
        /// Replaces a keyword in the data with the replacement and
        /// takes into account UPPERCASE/Mixed/lowercase options.
        /// </summary>
        /// <param name="data">The data to replace the keyword in.</param>
        /// <param name="keyword">The keyword that needs to be replaced.</param>
        /// <param name="replacement">The word that needs to replace the keyword.</param>
        /// <returns>The data with the keywords replaced by their respective values.</returns>
        private static string ReplaceKeyword(string data, string keyword, string replacement)
        {
            StringBuilder builder = new StringBuilder();
            int start, length, copied = 0;

            int index = data.IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase);
            while (index != -1)
            {
                // 1) The data without the keyword
                start = copied;
                length = (index - start);
                builder.Append(data.Substring(start, length));
                copied += length;

                // 2) Copy the keyword, but it has to be done case sensitive
                string word = data.Substring(copied, keyword.Length);
                if (word == keyword.ToUpper())
                { // KEYWORD => UPPERCASE
                    builder.Append(replacement.ToUpper());
                }
                else if (word[0] == (keyword.ToUpper()[0]))
                { // Keyword => Original
                    builder.Append(replacement);
                }
                else
                { // keyword => lowercase
                    builder.Append(replacement.ToLower());
                }
                copied += keyword.Length;

                // 3) Search for another occurence of index
                index = data.IndexOf(keyword, copied, StringComparison.CurrentCultureIgnoreCase);
            }

            // Add the remaining bytes
            if (copied != data.Length)
            {
                start = copied;
                length = (data.Length - start);
                builder.Append(data.Substring(start, length));
                copied += length;
            }

            return builder.ToString();
        }

        /// <summary>
        /// Installs a template.
        /// </summary>
        /// <param name="type">The type of the template.</param>
        /// <param name="template">The name of the template.</param>
        /// <param name="name">The name the keyword has to be replaced with.</param>
        public static void Install(TemplateType type, string template, string name)
        {
            // These are user values, so verify them
            Debug.Assert(!string.IsNullOrEmpty(template));
            Debug.Assert(!string.IsNullOrEmpty(name));

            // The user does not want to use a template.
            if (template == KEYWORD_NONE)
            {
                return;
            }

            string directory, keyword;

            if (type == TemplateType.Maps)
            {
                directory = DIRECTORY_MAPS;
                keyword = KEYWORD_MAPS;
            }
            else
            {
                Debug.Assert(type == TemplateType.Mods);
                directory = DIRECTORY_MODS;
                keyword = KEYWORD_MODS;
            }

            directory = string.Format("{0}{1}templates{1}{2}{1}{3}", Environment.CurrentDirectory, Path.DirectorySeparatorChar, directory, template);
            if (!Directory.Exists(directory))
            {
                throw new DescriptiveException(DescriptiveType.Warning,
                    string.Format("Could not locate template directory at '{0}'", directory));
            }

            // The template class does the actual loading and copying
            new Template(directory, keyword, name);
        }

        /// <summary>
        /// Get a list of all the available templates for the given type.
        /// </summary>
        /// <param name="typeName">The sub-directory type name.</param>
        /// <returns>An array of template names.</returns>
        public static void GetTemplates(ref List<string> templates, TemplateType type)
        {
            templates.Add(KEYWORD_NONE);

            string typeName;
            if (type == TemplateType.Maps)
            {
                typeName = DIRECTORY_MAPS;
            }
            else
            {
                Debug.Assert(type == TemplateType.Mods);
                typeName = DIRECTORY_MODS;
            }

            string templatesDirectory = string.Format("{0}{1}templates{1}{2}", Environment.CurrentDirectory, Path.DirectorySeparatorChar, typeName);
            if (!Directory.Exists(templatesDirectory))
            {
                return;
            }

            string[] foundTemplates = Directory.GetDirectories(templatesDirectory, "*", SearchOption.TopDirectoryOnly);

            // Trim the template names
            for (int i = 0; i < foundTemplates.Length; i++)
            {
                string template = foundTemplates[i];

                int start = templatesDirectory.Length + 1;
                int length = template.Length - start;
                string name = template.Substring(start, length);

                if (Utility.IsValid(name))
                {
                    templates.Add(name);
                }
            }
        }

        /// <summary>
        /// Replaces all the keywords in the string with their replacements.
        /// </summary>
        /// <param name="str">The string to replace the keywords of.</param>
        /// <returns>The string with the keywords replaced.</returns>
        public static string ReplaceAllKeywords(string data)
        {
            data = ReplaceKeyword(data, KEYWORD_MAPS, UserData.SelectedMap);
            return ReplaceKeyword(data, KEYWORD_MODS, UserData.SelectedMod);
        }
    }
}
