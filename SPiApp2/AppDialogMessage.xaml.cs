using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace SPiApp2
{
    public enum MessageButtons
    {
        OK,
        YesNo,
        YesNoCancel
    }

    public enum MessageIcon
    {
        None,
        Error,
        Information,
        Question,
        Warning
    }

    public enum MessageResult
    {
        OK,
        Yes,
        No,
        Cancel
    }

    /// <summary>
    /// Interaction logic for AppDialogMessage.xaml
    /// </summary>
    public partial class AppDialogMessage : SPiApp2.Controls.CompilerWindow
    {
        private MessageButtons buttons;
        private MessageIcon icon;
        private string message;

        public MessageResult Result { get; private set; } = MessageResult.Cancel;

        public AppDialogMessage() :
            this("No message has been set.", "Missing message", MessageButtons.OK, MessageIcon.Error)
        {
            ; // NOTE: Actually handled by the other constructor
        }

        public AppDialogMessage(string message, string title, MessageButtons buttons, MessageIcon icon)
        {
            InitializeComponent();
            CenterOnParent();

            this.message = message;
            this.Title = title;
            this.buttons = buttons;
            this.icon = icon;

            Loaded += OnLoaded;
        }

        public override void GetWindowChrome(out WindowChrome chrome)
        {
            chrome = this.chrome;
        }

        public static MessageResult Show(string message, string title, MessageButtons buttons, MessageIcon icon)
        {
            AppDialogMessage dialog = new AppDialogMessage(message, title, buttons, icon);
            dialog.ShowDialog();
            return dialog.Result;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            // Content
            ctrlText.Text = message;

            // Icons
            switch (icon)
            {
                case MessageIcon.Information:
                    break;

                case MessageIcon.Question:
                    break;

                case MessageIcon.Warning:
                    break;

                case MessageIcon.Error:
                    break;

                case MessageIcon.None:
                default:
                    break;
            }

            // Buttons
            switch (buttons)
            {
                case MessageButtons.YesNo:
                    button2.Visibility = Visibility.Hidden;
                    button1.Content = "Yes";
                    button0.Content = "No";
                    button1.Focus();
                    break;

                case MessageButtons.YesNoCancel:
                    button2.Content = "Yes";
                    button1.Content = "No";
                    button0.Content = "Cancel";
                    button2.Focus();
                    break;

                case MessageButtons.OK:
                    button2.Visibility = Visibility.Hidden;
                    button1.Visibility = Visibility.Hidden;
                    button0.Content = "OK";
                    button0.Focus();
                    break;
            }
        }

        public void Click_Button(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Debug.Assert(button != null);

            if (buttons == MessageButtons.YesNo)
            {
                if (button == button1)
                {
                    Result = MessageResult.Yes;
                }
                else
                {
                    Debug.Assert(button == button0);
                    Result = MessageResult.No;
                }
            }
            else if (buttons == MessageButtons.YesNoCancel)
            {
                if (button == button2)
                {
                    Result = MessageResult.Yes;
                }
                else if (button == button1)
                {
                    Result = MessageResult.No;
                }
                else
                {
                    Debug.Assert(button == button0);
                    Result = MessageResult.Cancel;
                }
            }
            else
            {
                Debug.Assert(buttons == MessageButtons.OK);
                Debug.Assert(button == button0);
                Result = MessageResult.OK;
            }

            // This makes it actually return!
            DialogResult = true;
        }

        public void Click_Copy(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(message);
        }
    }
}
