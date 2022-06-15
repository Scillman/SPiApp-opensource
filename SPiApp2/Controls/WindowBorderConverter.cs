using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Shell;

namespace SPiApp2.Controls
{
    public class WindowBorderConverter : IValueConverter
    {

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Prevent designer errors
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return new Thickness(23);
            }

            Debug.Assert(value != null);
            return Convert(value as Grid);
        }

        public object Convert(Grid grid)
        {
            object sender = Window.GetWindow(grid);
            Debug.Assert(sender != null);

            CompilerWindow window = sender as CompilerWindow;
            Debug.Assert(window != null);

            return Convert(window, false);
        }

        public object Convert(CompilerWindow window, bool adjustCaption)
        {
            // Get the border size
            double border = GetWindowBorderSize(window);

            if (adjustCaption)
            {
                // Adjust the caption height
                AdjustCaptionHeight(window, border);
            }

            // Return the size of the border
            return new Thickness(border);
        }

        private void AdjustCaptionHeight(CompilerWindow window, double border)
        {
            // We need the WindowChrome data
            window.GetWindowChrome(out WindowChrome chrome);

            // The original caption height
            double captionHeight = window.CaptionHeight;

            if (window.WindowState == WindowState.Maximized)
            {
                // Set the new caption height (extends beyond the visible screen!)
                chrome.CaptionHeight = (captionHeight + border - chrome.ResizeBorderThickness.Top);
            }
            else
            {
                chrome.CaptionHeight = captionHeight;
            }
        }

        private double GetWindowBorderSize(CompilerWindow window)
        {
            // We need the WindowChrome data
            window.GetWindowChrome(out WindowChrome chrome);

            // We use the default
            if (window.WindowState != WindowState.Maximized)
            {
                return chrome.ResizeBorderThickness.Left;
            }

            // Get the window handle
            IntPtr handle = (new WindowInteropHelper(window)).Handle;

            // Get the window styles
            uint style = GetWindowLongA(handle, -16);
            uint exStyle = GetWindowLongA(handle, -20);

            // NOTE: Can be anything, I prefer to keep it safe (aka on-screen)
            const int WIN_WIDTH = 640;
            const int WIN_HEIGHT = 480;

            // Fill with desired position (left/top) and size (right/bottom)
            RECT rect = new RECT()
            {
                left = 0,
                right = WIN_WIDTH,
                top = 0,
                bottom = WIN_HEIGHT
            };

            // Make the call to WIN32
            if (AdjustWindowRectEx(ref rect, style, false, exStyle))
            {
                // Perform calculations to perform a check during debugging
                RECT dest = new RECT()
                {
                    left = Math.Abs(rect.left),
                    top = Math.Abs(rect.top),
                    right = (rect.right - WIN_WIDTH),
                    bottom = (rect.bottom - WIN_HEIGHT)
                };
                Debug.Assert(dest.left == dest.right && dest.left == dest.bottom);

                return Math.Abs(dest.left);
            }
            else
            {
                Debug.WriteLine(chrome.ResizeBorderThickness.Left);
                // Failsafe, use the exisiting border size
                return chrome.ResizeBorderThickness.Left;
            }
        }

        #region WIN32

        [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 16)]
        internal struct RECT
        {
            [FieldOffset(0)]
            public int left;

            [FieldOffset(4)]
            public int top;

            [FieldOffset(8)]
            public int right;

            [FieldOffset(12)]
            public int bottom;
        };

        [DllImport("user32.dll", EntryPoint = "AdjustWindowRectEx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool AdjustWindowRectEx(ref RECT rect, uint style, [MarshalAs(UnmanagedType.Bool)] bool hasMenu, uint exStyle);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongA")]
        [return: MarshalAs(UnmanagedType.U4)]
        internal static extern uint GetWindowLongA(IntPtr hWnd, int nIndex);

        #endregion WIN32
    }
}
