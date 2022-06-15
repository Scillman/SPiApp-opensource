using System;
using System.Diagnostics;

namespace SPiApp2.Components.Exceptions
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
    [Serializable]
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
            MessageIcon icon;
            string title;

            switch (ex.Type)
            {
                case DescriptiveType.Information:
                    icon = MessageIcon.Information;
                    title = "Information";
                    break;

                case DescriptiveType.Warning:
                    icon = MessageIcon.Warning;
                    title = "Warning";
                    break;

                case DescriptiveType.Error:
                    icon = MessageIcon.Error;
                    title = "Error";
                    break;

                default:
                    icon = MessageIcon.None;
                    title = string.Empty;
                    break;
            }

            SPiApp2.Controls.Console.WriteLine(ex.Message);
            AppDialogMessage.Show(ex.Message, title, MessageButtons.OK, icon);
        }
    }
}
