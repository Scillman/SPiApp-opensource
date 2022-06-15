using System;

namespace SPiApp2.Components.Settings
{
    public class ModSettings : SettingsFile
    {
        private static ModSettings _instance = null;

        public static ModSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ModSettings();
                }

                return _instance;
            }
        }

        private ModSettings() :
            base(false)
        {
        }

        protected override string GetPath()
        {
            return string.Format("{0}{1}settings{1}mods{1}{2}.settings",
                Environment.CurrentDirectory, System.IO.Path.DirectorySeparatorChar, UserData.SelectedMod);
        }

        protected override string GetAltPath()
        {
            return null;
        }
    }
}
