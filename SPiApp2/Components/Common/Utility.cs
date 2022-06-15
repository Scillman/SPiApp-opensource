using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace SPiApp2.Components.Common
{
    /// <summary>
    /// Contains functions often use accross different pieces of code.
    /// </summary>
    static class Utility
    {
        /// <summary>
        /// Validates whether the string is a valid field or file name.
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns>true if valid; otherwise, false.</returns>
        public static bool IsValid(string str)
        {
            return Regex.IsMatch(str, "^[a-zA-Z_]{1}([a-zA-Z0-9_]{1,})?$");
        }

        /// <summary>
        /// Get an indicator to whether the string contains whitespaces.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>true if it contains one or more whitespace characters; otherwise, false.</returns>
        public static bool ContainsWhitespace(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                int cur = value[i];
                if (cur <= 0x20)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Splits the string into substrings while taking the escape character into account.
        /// </summary>
        /// <param name="value">The string to split.</param>
        /// <returns>The string split into respective values.</returns>
        public static string[] Split(string value)
        {
            List<string> arguments = new List<string>();

            int next = 0;

            for (int i = 0; i < value.Length; i++)
            {
                int s, e;

                // Search for an opening string quote
                for (s = i; s < value.Length; s++)
                {
                    if (value[s] == '\"' && (s == 0 || (s > 0 && value[s - 1] != '\\')))
                    {
                        break;
                    }
                }

                // An opening quot has been found, look for a closing quote
                if (s != value.Length)
                {
                    // Copy from the previous...
                    if (next < s)
                    {
                        int length = (s - next);
                        string sub = value.Substring(next, length).Trim();
                        if (!string.IsNullOrEmpty(sub))
                        {
                            arguments.Add(sub);
                        }
                    }

                    // Search for closing quote
                    for (e = s + 1; e < value.Length; e++)
                    {
                        if (value[e] == '\"' && value[e - 1] != '\\')
                        {
                            break;
                        }
                    }

                    // Closing character
                    if (e != value.Length)
                    {
                        int length = (e - (s + 1));
                        string sub = value.Substring(s + 1, length).Trim();
                        if (!string.IsNullOrEmpty(sub))
                        {
                            arguments.Add(sub);
                        }

                        i = e;
                    }

                    // No closing character but opening character
                    else
                    {
                        int length = (e - (s + 1));
                        string sub = value.Substring(s + 1, length).Trim();
                        if (!string.IsNullOrEmpty(sub))
                        {
                            arguments.Add(sub);
                        }

                        i = e - 1;
                    }

                    // Set the next character...
                    next = i + 1;
                }
            }

            // If a part of the string is missing we got to copy it too
            if (next < value.Length)
            {
                int length = (value.Length - next);

                string sub = value.Substring(next, length).Trim();
                if (!string.IsNullOrEmpty(sub))
                {
                    arguments.Add(sub);
                }
            }

            return arguments.ToArray();
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
        /// Escapes a string and puts it in between quotes if necessary.
        /// </summary>
        /// <param name="value">The value that has to be escaped.</param>
        /// <returns>The escaped value.</returns>
        public static string EscapeSmart(string value)
        {
            value = EscapeString(value);

            if (!string.IsNullOrEmpty(value) && !Regex.IsMatch(value, "^([a-zA-Z0-9_]{1,})?$"))
            {
                return string.Format("\"{0}\"", value);
            }

            return value;
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
            if (list.Count > 0 && !string.IsNullOrEmpty(value))
            {
                int i;

                for (i = 0; i < list.Count; i++)
                {
                    object child = list[i];
                    string name;

                    if (child.GetType().IsSubclassOf(typeof(ContentControl)))
                    {
                        ContentControl item = child as ContentControl;
                        name = item.Content as string;
                        Debug.Assert(name != null);
                    }
                    else
                    {
                        Debug.Assert(child.GetType() == typeof(string));
                        name = (list[i]) as string;
                    }

                    if (value.Equals(name))
                    {
                        return i;
                    }
                }

                if (i == list.Count)
                {
                    return 0;
                }
            }

            return -1;
        }

        /// <summary>
        /// Select the item of the control.
        /// </summary>
        /// <param name="obj">The object on whom we need to select a value.</param>
        /// <param name="value">The value that has to be selected.</param>
        public static void SelectValue(ref ListBox obj, string value)
        {
            int index = GetValueIndex(obj.Items, value);

            if (index == -1)
            {
                obj.UnselectAll();
            }
            else
            { 
                obj.SelectedIndex = index;
                obj.ScrollIntoView(obj.SelectedItem);
            }
        }

        /// <summary>
        /// Select the item of the control.
        /// </summary>
        /// <param name="obj">The object on whom we need to select a value.</param>
        /// <param name="value">The value that has to be selected.</param>
        public static void SelectValue(ref ComboBox obj, string value)
        {
            int index = GetValueIndex(obj.Items, value);

            if (index != -1)
            {
                obj.SelectedIndex = index;
            }
        }

        /// <summary>
        /// Select the item of the control.
        /// </summary>
        /// <param name="obj">The object on whom we need to select a value.</param>
        /// <param name="value">The value that has to be selected.</param>
        public static void SelectValue(ref TabControl obj, int value)
        {
            Debug.Assert(obj.Items.Count > 0);

            if (value < 0 || value >= obj.Items.Count)
            {
                obj.SelectedIndex = 0;
            }
            else
            {
                obj.SelectedIndex = value;
            }
        }

        /// <summary>
        /// Gets the referenc to the application object.
        /// </summary>
        /// <param name="app">The app object.</param>
        public static void GetApp(out App app)
        {
            app = System.Windows.Application.Current as App;
            Debug.Assert(app != null);
        }

        /// <summary>
        /// Gets the reference to the main window object.
        /// </summary>
        /// <param name="window">The window object</param>
        public static void GetWindow(out MainWindow window)
        {
            GetApp(out App app);
            window = app.MainWindow as MainWindow;
            Debug.Assert(window != null);
        }

        /// <summary>
        /// Get an indicator to whether or not the parameter has been set.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <returns>true if set; otherwise, false.</returns>
        public static bool IsParameterSet(string param)
        {
            // Sanity check
            Debug.Assert(param == param.ToLower());

            string commandLine = Environment.CommandLine;
            string[] args = Split(commandLine);

            for (int i = 1; i < args.Length; i++)
            {
                string token = args[i];
                char indicator = token[0];

                // Only when the first option is a parameter
                if (indicator == '-' || indicator == '/')
                {
                    token = token.Substring(1, token.Length - 1).ToLower();

                    // If they match it has been set
                    if (token == param)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
