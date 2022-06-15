using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SPiApp.Common
{
    internal static class Win32
    {
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        internal static extern bool AdjustWindowRectEx(ref RECT lpRect, int dwStyle, bool bMenu, int dwExStyle);

        [StructLayout(LayoutKind.Explicit)]
        internal struct RECT
        {
            [FieldOffset(0x00)] internal int left;
            [FieldOffset(0x04)] internal int top;
            [FieldOffset(0x08)] internal int right;
            [FieldOffset(0x0C)] internal int bottom;
        }

        /// <summary>
        /// Get the total window size for the desired client size.
        /// </summary>
        /// <param name="cp">The create params of the window.</param>
        /// <param name="width">
        /// In: The desired width of the client area.
        /// Out: The total window width.
        /// </param>
        /// <param name="height">
        /// In: The desired height of the client area.
        /// Out: The total window height.
        /// </param>
        private static void GetFullWindowSize(CreateParams cp, ref int width, ref int height)
        {
            RECT rect = new RECT();
            rect.left = 0;
            rect.top = 0;
            rect.right = width;
            rect.bottom = height;

            bool result = AdjustWindowRectEx(ref rect, cp.Style, false, cp.ExStyle);
            Debug.Assert(result == true);

            width = (rect.right - rect.left);
            height = (rect.bottom - rect.top);
        }
    }
}
