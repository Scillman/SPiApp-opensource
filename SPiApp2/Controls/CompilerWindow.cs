using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace SPiApp2.Controls
{
    public abstract class CompilerWindow : Window
    {
        public abstract void GetWindowChrome(out WindowChrome chrome);

        public double CaptionHeight
        {
            get
            {
                if (_captionHeight == double.MaxValue)
                {
                    GetWindowChrome(out WindowChrome chrome);
                    Debug.Assert(chrome != null);
                    _captionHeight = chrome.CaptionHeight;
                }

                return _captionHeight;
            }

        }
        private double _captionHeight = double.MaxValue;

        #region OnWindowStateChanged

        private WindowState prevWindowState = WindowState.Normal;

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            if (prevWindowState != WindowState)
            {
                prevWindowState = WindowState;
                (new WindowBorderConverter()).Convert(this, true);
            }

            base.OnRenderSizeChanged(sizeInfo);
        }

        #endregion

        #region Frame Controls

        protected void CommandBinding_CanExecute_1(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        protected void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        protected void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }

        protected void CommandBinding_Executed_3(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        protected void CommandBinding_Executed_4(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.RestoreWindow(this);
        }

        #endregion

        #region Utility

        protected void CenterOnParent()
        {
            Application curApp = Application.Current;
            Window mainWindow = curApp.MainWindow;
            Debug.Assert(mainWindow != null);
            this.Left = (mainWindow.Left + (mainWindow.Width / 2)) - (this.Width / 2);
            this.Top = (mainWindow.Top + (mainWindow.Height / 2)) - (this.Height / 2);
        }

        #endregion
    }
}
