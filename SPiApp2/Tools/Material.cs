using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Path = System.IO.Path;
using SPiApp2.Components.Settings;

namespace SPiApp2.Tools
{
    public class Material : Asset
    {
        public Material(string name) :
            base(name)
        {
            ; // Do something...
        }

        public static string[] GetAvailable()
        {
            string directory = string.Format("{0}{1}raw{1}materials{1}",
                Preferences.InstallPath, Path.DirectorySeparatorChar);

            string[] files = Directory.GetFiles(directory, "*", SearchOption.TopDirectoryOnly);

            // Drop the directory path
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileName(files[i]);
            }

            return files;
        }

        protected override string GetPath()
        {
            return string.Format("{0}{1}raw{1}materials{1}{2}",
                Preferences.InstallPath, Path.DirectorySeparatorChar, Name);
        }

        protected override void _Load()
        {
            throw new NotImplementedException();
        }

        protected override string GetInfo()
        {
            return "Material";
        }
    }
}
