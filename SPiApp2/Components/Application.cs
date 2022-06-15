using SPiApp2.Components.Common;
using SPiApp2.Components.Settings;
using System.Diagnostics;
using System.IO;
using Path = System.IO.Path;

namespace SPiApp2.Components
{
    public static class Application
    {
        /// <summary>
        /// Launches an executable file.
        /// </summary>
        /// <param name="exePath">The absolute or relative path to the executable.</param>
        /// <param name="workingDirectory">The working directory to used by the executable.</param>
        /// <param name="arguments">The arguments to pass to the application.</param>
        public static void Launch(string exePath, string workingDirectory, params string[] args)
        {
            string arguments = (args.Length > 0) ? Utility.EscapeSmart(args[0]) : string.Empty;
            for (int i = 1; i < args.Length; i++)
            {
                arguments = string.Format("{0} {1}", arguments, Utility.EscapeSmart(args[i]));
            }

            Launch(exePath, workingDirectory, arguments);
        }

        /// <summary>
        /// Launches an executable file.
        /// </summary>
        /// <param name="exePath">The absolute or relative path to the executable.</param>
        /// <param name="workingDirectory">The working directory to used by the executable.</param>
        /// <param name="arguments">The arguments to pass to the application.</param>
        public static void Launch(string exePath, string workingDirectory, string arguments = null)
        {
            if (!Directory.Exists(workingDirectory))
            {
                AppDialogMessage.Show(string.Format("Could not locate directory at path '{0}'.", workingDirectory),
                    "Missing directory", MessageButtons.OK, MessageIcon.Error);
            }
            else
            {
                if (!File.Exists(exePath))
                {
                    string altPath = string.Format("{0}{1}{2}", workingDirectory, Path.DirectorySeparatorChar, exePath);

                    if (!File.Exists(altPath))
                    {
                        AppDialogMessage.Show(string.Format("Could not locate executable file at '{0}' or '{1}'.", exePath, altPath),
                            "Missing executable", MessageButtons.OK, MessageIcon.Error);
                    }
                    else
                    {
                        exePath = altPath;
                    }
                }

                ProcessStartInfo info = new ProcessStartInfo();
                info.UseShellExecute = true;
                info.FileName = exePath;
                info.WorkingDirectory = workingDirectory;

                if (!string.IsNullOrEmpty(arguments))
                {
                    info.Arguments = arguments;
                }

                Process.Start(info);
            }
        }

#if FALSE
        /// <summary>
        /// Opens explorer to the specified path; if the file has been specified it will also select the file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static void Browse(string path)
        {
            string directory = Path.GetDirectoryName(path);
            string filename = Path.GetFileName(path);

            Browse(directory, filename);
        }
#endif

        /// <summary>
        /// Opens explorer to the specified path; if the file has been specified it will also select the file.
        /// </summary>
        /// <param name="directory">The path to directory in which the file resides.</param>
        /// <param name="filename">The name of the file to browse for.</param>
        public static void Browse(string directory, string filename = null)
        {
            char sep = Path.DirectorySeparatorChar;
            string path = string.Format("{0}{1}{2}", directory, sep, filename);

            if (!Directory.Exists(directory))
            {
                AppDialogMessage.Show(string.Format("Directory at '{0}' could not be located.", directory),
                    "Missing directory", MessageButtons.OK, MessageIcon.Warning);
            }
            else if (!string.IsNullOrEmpty(filename) && !File.Exists(path))
            {
                AppDialogMessage.Show(string.Format("File at '{0}' could not be located.", path),
                    "Missing file", MessageButtons.OK, MessageIcon.Warning);
            }
            else
            {
                Explorer(path);
            }
        }

        /// <summary>
        /// Get the text editor executable and the arguments.
        /// </summary>
        /// <param name="editor">The path to the text editor.</param>
        /// <param name="arguments">The parameters for the text editor.</param>
        /// <returns>true if found valid; otherwise, false.</returns>
        private static bool GetTextEditor(out string editor, out string arguments)
        {
            string textEditor = Preferences.TextEditor;

            // Set the output to null as a default
            editor = null;
            arguments = null;

            // No text editor has been set
            if (string.IsNullOrEmpty(textEditor))
            {
                return false;
            }

            // Split them into tokens
            string[] tokens = Utility.Split(textEditor);
            Debug.Assert(tokens.Length > 0);

            // The first argument is the path to the editor
            editor = tokens[0];

            // The editor must exist
            if (!File.Exists(editor))
            {
                return false;
            }

            // There are arguments.
            if (tokens.Length > 1)
            {
                arguments = Utility.EscapeSmart(tokens[1]);

                for (int i = 2; i < tokens.Length; i++)
                {
                    arguments = string.Format("{0} {1}", arguments, Utility.EscapeSmart(tokens[i]));
                }
            }

            return true;
        }

#if FALSE
        /// <summary>
        /// Opens the text file if an editor is set. Otherwise it is displayed in explorer.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static void OpenTextFile(string path)
        {
            string directory = Path.GetDirectoryName(path);
            string filename = Path.GetFileName(path);

            OpenTextFile(directory, filename);
        }
#endif

        /// <summary>
        /// Opens the text file if an editor is set. Otherwise it is displayed in explorer.
        /// </summary>
        /// <param name="directory">The path to the directory in which the file resides.</param>
        /// <param name="filename">The name of the file to open.</param>
        public static void OpenTextFile(string directory, string filename)
        {
            string path = string.Format("{0}{1}{2}", directory, Path.DirectorySeparatorChar, filename);

            if (!Directory.Exists(directory))
            {
                AppDialogMessage.Show(string.Format("Directory at '{0}' could not be located.", directory),
                    "Missing directory", MessageButtons.OK, MessageIcon.Warning);
            }
            else if (string.IsNullOrEmpty(filename) || !File.Exists(path))
            {
                AppDialogMessage.Show(string.Format("File at '{0}' could not be located.", path),
                    "Missing file", MessageButtons.OK, MessageIcon.Warning);
            }
            else
            {
                if (GetTextEditor(out string editor, out string arguments))
                {
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = editor;
                    info.WorkingDirectory = directory;
                    info.UseShellExecute = true;

                    if (!string.IsNullOrEmpty(arguments))
                    {
                        info.Arguments = string.Format("{0} {1}", arguments, Utility.EscapeSmart(filename));
                    }
                    else
                    {
                        info.Arguments = filename;
                    }

                    Process.Start(info);
                }
                else
                {
                    Explorer(directory, filename);
                }
            }
        }

#if FALSE
        private static void Explorer(string path)
        {
            string directory = Path.GetDirectoryName(path);
            string filename = Path.GetFileName(path);

            Explorer(directory, filename);
        }
#endif

        private static void Explorer(string directory, string filename = null)
        {
            Debug.Assert(Directory.Exists(directory));

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer.exe";
            info.WorkingDirectory = directory;
            info.UseShellExecute = true;

            if (string.IsNullOrEmpty(filename))
            {
                info.Arguments = directory;
            }
            else
            {
                info.Arguments = string.Format("/select,{0}{1}{2}", directory, Path.DirectorySeparatorChar, filename);
            }

            Process.Start(info);
        }
    }
}
