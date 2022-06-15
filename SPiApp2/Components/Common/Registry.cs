using Microsoft.Win32;
using System.Diagnostics;

namespace SPiApp.Common
{
    /// <summary>
    /// Windows registry interop.
    /// </summary>
    internal static class Registry
    {
        /// <summary>
        /// Get a registry value from the Local Machine subtree of the system registry.
        /// </summary>
        /// <param name="value">The destination to store the value.</param>
        /// <param name="name">The name of the tree.</param>
        /// <param name="key">The key to get the value from.</param>
        /// <returns>true if the value of the key has been stored on the value; otherwise, false.</returns>
        public static bool CheckKey(ref string value, string name, string key)
        {
            using (var view = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
            {
                using (var reg = view.OpenSubKey(name, false))
                {
                    if (reg != null)
                    {
                        object temp = reg.GetValue(key);
                        if (temp != null)
                        {
                            value = temp as string;
                            return true;
                        }
                        else
                        {
                            Debug.WriteLine(temp);
                        }
                    }

                    return false;
                }
            }
        }
    }
}
