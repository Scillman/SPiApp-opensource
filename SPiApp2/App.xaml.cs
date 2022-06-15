using SPiApp2.Components;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Markup;

namespace SPiApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        /// <summary>
        /// WPF compliant restart.
        /// </summary>
        public void Restart()
        {
            // Get the original arguments
            string[] arguments = Environment.GetCommandLineArgs();
            string argument = string.Empty;

            // Compose the new command-line from the original
            if (arguments.Length > 1)
            {
                argument = string.Format("\"{0}\"", arguments[1]);

                for (int i = 2; i < arguments.Length; i++)
                {
                    argument = string.Format("{0} \"{1}\"", argument, arguments[i]);
                }
            }

            // Start the application with the original parameters intact
            System.Diagnostics.Process.Start(ResourceAssembly.Location, argument);
            Current.Shutdown();
        }
    }
}
