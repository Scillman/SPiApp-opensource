using SPiApp2.Components.Common;
using System.Diagnostics;
using System.Windows.Controls;

namespace SPiApp2.Controls
{
    public static class Console
    {
        /// <summary>
        /// Writes a line to the console.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void WriteLine(string message, params object[] args)
        {
            string output = string.Format(message + "\r\n", args);
            Utility.GetWindow(out MainWindow window);
            window.ctrlConsole.Text += output;
        }
    }
}
