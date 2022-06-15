using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SPiApp.Exceptions
{
    /// <summary>
    /// The various descriptive types for exceptions.
    /// </summary>
    public enum DescriptiveType
    {
        Information,
        Warning,
        Error
    }

    /// <summary>
    /// A descriptive exception as throw by SPiApp code.
    /// </summary>
    public class DescriptiveException : Exception
    {
        /// <summary>
        /// Get the descriptive type of the exception.
        /// </summary>
        public DescriptiveType Type
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates a new descriptive type exception.
        /// </summary>
        /// <param name="type">The descriptive type of the exception.</param>
        /// <param name="message">The message of the exception.</param>
        public DescriptiveException(DescriptiveType type, string message) :
            base(message)
        {
            Type = type;
        }

        /// <summary>
        /// Common handler for handling descriptive exceptions.
        /// </summary>
        /// <param name="ex">The received descriptive exception.</param>
        public static void Handle(DescriptiveException ex)
        {
            MessageBoxIcon icon;
            string title;

            switch (ex.Type)
            {
                case DescriptiveType.Information:
                    icon = MessageBoxIcon.Information;
                    title = "Information";
                    break;

                case DescriptiveType.Warning:
                    icon = MessageBoxIcon.Warning;
                    title = "Warning";
                    break;

                case DescriptiveType.Error:
                    icon = MessageBoxIcon.Error;
                    title = "Error";
                    break;

                default:
                    icon = MessageBoxIcon.None;
                    title = string.Empty;
                    break;
            }

            Debug.WriteLine(ex.Message);
            MessageBox.Show(ex.Message, title, MessageBoxButtons.OK, icon);
        }
    }
}
