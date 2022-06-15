using SPiApp2.Components.Settings;
using System.Diagnostics;
using System.IO;

namespace SPiApp2.Components
{
    public static class Validator
    {
        /// <summary>
        /// Validates the currently set install path.
        /// </summary>
        /// <returns>true if the install path is considered valid; otherwise, false.</returns>
        public static bool ValidateInstallPath()
        {
            const string SUB_MESSAGE = " Please select a valid Call of Duty 4 installation directory.";

            // 1) Check the directory itself
            string directory = Preferences.InstallPath;
            if (!Directory.Exists(directory))
            {
                SPiApp2.Controls.Console.WriteLine(string.Format(
                    "The prefered installation path at '{0}' does not exist.{1}", directory, SUB_MESSAGE));
                return false;
            }

            // 2) Check variable files from CD/DVD, Steam, patches, etc.
            string[] varFiles =
            {
                "iw3sp.exe",
                "iw3mp.exe"
            };

            foreach (string varFile in varFiles)
            {
                string path = string.Format("{0}{1}{2}", directory, System.IO.Path.DirectorySeparatorChar, varFile);
                if (!File.Exists(path))
                {
                    SPiApp2.Controls.Console.WriteLine(string.Format(
                        "Could not locate '{0}'.{1}", path, SUB_MESSAGE));
                    return false;
                }
            }

            // 3) Mod tools bin directory
            string binDirectory = string.Format("{0}{1}bin", directory, System.IO.Path.DirectorySeparatorChar);
            if (!Directory.Exists(binDirectory))
            {
                SPiApp2.Controls.Console.WriteLine(string.Format(
                    "The prefered installation does not seem to have the mod tools installed."));
                return false;
            }

            // 4) Tools executables
            HashFile[] toolFiles =
            {
                // Tools - User applications
                new HashFile( "sp_tool.exe", Security.HASH_SP_TOOL ),
                new HashFile( "mp_tool.exe", Security.HASH_MP_TOOL ),
                new HashFile( string.Format("bin{0}asset_manager.exe", System.IO.Path.DirectorySeparatorChar), Security.HASH_ASSET_MANAGER ),
                new HashFile( string.Format("bin{0}CoD4EffectsEd.exe", System.IO.Path.DirectorySeparatorChar), Security.HASH_EFFECTS_ED ),
                new HashFile( string.Format("bin{0}CoD4Radiant.exe", System.IO.Path.DirectorySeparatorChar), Security.HASH_RADIANT ),

                // Tools - Conversion and builders
                new HashFile( string.Format("bin{0}cod4map.exe", System.IO.Path.DirectorySeparatorChar), Security.HASH_COD4MAP ),
                new HashFile( string.Format("bin{0}cod4rad.exe", System.IO.Path.DirectorySeparatorChar), Security.HASH_COD4RAD ),
                new HashFile( string.Format("bin{0}converter.exe", System.IO.Path.DirectorySeparatorChar), Security.HASH_CONVERTER ),
                new HashFile( string.Format("bin{0}linker_pc.exe", System.IO.Path.DirectorySeparatorChar), Security.HASH_LINKER_PC )
            };

            foreach (HashFile toolFile in toolFiles)
            {
                string path = string.Format("{0}{1}{2}", directory, System.IO.Path.DirectorySeparatorChar, toolFile);
                if (!File.Exists(path))
                {
                    SPiApp2.Controls.Console.WriteLine(string.Format(
                        "Could not locate '{0}'.{1}", path, SUB_MESSAGE));
                    return false;
                }

                if (Security.CreateMD5(path, out byte[] hash))
                {
                    if (0 != toolFile.CompareTo(hash))
                    {
                        SPiApp2.Controls.Console.WriteLine(string.Format(
                            "Hash of '{0}' does not match that of the same binary" +
                                " as found in the lastest version of the mod tools.", toolFile.FileName));
                        break;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Validates the currently set zipper executable.
        /// </summary>
        /// <returns>true if valid; otherwise, false.</returns>
        public static bool ValidateZipper()
        {
            return ValidateFile(Preferences.Zipper, Security.ZIPPER_HASH);
        }

        /// <summary>
        /// Validates a single file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="hash">The hash of the file.</param>
        /// <returns></returns>
        public static bool ValidateFile(string path, byte[] hash = null)
        {
            if (!File.Exists(path))
            {
                // Alternative path
                string altPath = string.Format("{0}{1}{2}", Preferences.InstallPath,
                    System.IO.Path.DirectorySeparatorChar, path);

                if (!File.Exists(altPath))
                {
                    SPiApp2.Controls.Console.WriteLine(string.Format(
                        "Could not locate file at '{0}'", path));
                    return false;
                }

                // Override the path with the alternative path
                path = altPath;
            }

            if (hash != null && Security.CreateMD5(path, out byte[] fileHash))
            {
                for (int i = 0; i < 16; i++)
                {
                    if (hash[i] != fileHash[i])
                    {
                        SPiApp2.Controls.Console.WriteLine(string.Format(
                            "Hash of file '{0}' does not match that of the one delivered with the mod tools.", path));
                        break;
                    }
                }
            }

            return true;
        }

    }
}
