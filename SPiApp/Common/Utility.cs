using System;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SPiApp.Common
{
    /// <summary>
    /// Contains functions often use accross different pieces of code.
    /// </summary>
    static class Utility
    {
        private const string STRING_FILTER = "^[a-zA-Z_]{1}([a-zA-Z0-9_]{1,})?$";

        /// <summary>
        /// Validates whether the string is a valid field or file name.
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns>true if valid; otherwise, false.</returns>
        public static bool IsValid(string str)
        {
            return Regex.IsMatch(str, STRING_FILTER);
        }

        /// <summary>
        /// Sanitizes the input string into a valid C# managed string value.
        /// </summary>
        /// <param name="str">The string to sanitize</param>
        /// <returns>The sanatized string.</returns>
        public static string Sanitize(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            // Is it a string?
            if (str[0] == '"' && str[str.Length - 1] == '"')
            {
                str = str.Substring(1, str.Length - 2);
            }

            // Escape character
            return str.Replace("\\\"", "\"");
        }

        /// <summary>
        /// Escapes a string.
        /// </summary>
        /// <param name="value">The value that has to be escaped.</param>
        /// <returns>The escaped value.</returns>
        public static string EscapeString(string value)
        {
            return value.Replace("\"", "\\\"");
        }

        /// <summary>
        /// Determines whether the file at the given path is a text file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>true if considered a text file; otherwise, false.</returns>
        public static bool IsTextFile(string path)
        {
            // Extensions of supported text files
            string[] extensions =
            {
                ".arena", ".atr",
                ".cfg", ".csv",
                ".gdt", ".gsc",
                ".h",
                ".inc",
                ".map", ".menu",
                ".script", ".str",
                ".txt"
            };

            foreach (string extension in extensions)
            {
                if (path.EndsWith(extension))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether the file at the given path is an executable file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>true if considered an executable file; otherwise, false.</returns>
        public static bool IsExecutableFile(string path)
        {
            // Extensions of supported executable files
            string[] extensions =
            {
                ".bat",
                ".exe",
                ".sh"
            };

            foreach (string extension in extensions)
            {
                if (path.EndsWith(extension))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the index that corresponds to the value.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static int GetValueIndex(IList list, string value)
        {
            Debug.Assert(list.Count > 0);

            int i;

            for (i = 0; i < list.Count; i++)
            {
                string name = (list[i]) as string;
                if (name.Equals(value))
                {
                    return i;
                }
            }

            if (i == list.Count && list.Count > 0)
            {
                return 0;
            }

            throw new IndexOutOfRangeException(string.Format("List doesn't index {0} in [0, {1})", value, list.Count));
        }

        /// <summary>
        /// Select the item of the control.
        /// </summary>
        /// <param name="obj">The object on whom we need to select a value.</param>
        /// <param name="value">The value that has to be selected.</param>
        public static void SelectValue(ref ListBox obj, string value)
        {
            obj.SelectedIndex = GetValueIndex(obj.Items, value);
        }

        /// <summary>
        /// Select the item of the control.
        /// </summary>
        /// <param name="obj">The object on whom we need to select a value.</param>
        /// <param name="value">The value that has to be selected.</param>
        public static void SelectValue(ref ComboBox obj, string value)
        {
            obj.SelectedIndex = GetValueIndex(obj.Items, value);
        }

        /// <summary>
        /// Select the item of the control.
        /// </summary>
        /// <param name="obj">The object on whom we need to select a value.</param>
        /// <param name="value">The value that has to be selected.</param>
        public static void SelectValue(ref TabControl obj, int value)
        {
            Debug.Assert(obj.TabPages.Count > 0);

            if (value < 0 || value >= obj.TabPages.Count)
            {
                obj.SelectedIndex = 0;
            }
            else
            {
                obj.SelectedIndex = value;
            }
        }
    }
}
