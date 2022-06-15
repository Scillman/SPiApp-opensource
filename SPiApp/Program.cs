using System;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Diagnostics;
using SPiApp.Exceptions;

namespace SPiApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enforce the use of American English.
            CultureInfo enUS = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentCulture = enUS;

            // Actually start our window application.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Debug.Assert(Application.CurrentCulture == enUS);
                Application.Run(new Form1());
            }
            catch (InstallationException ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show(ex.Message, "Corrupted installation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("A fatal error has occured. Terminating the application.", "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
