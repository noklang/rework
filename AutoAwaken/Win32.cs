using System.Runtime.InteropServices;

namespace AutoAwaken
{
    /// <summary>
    /// The few Windows API calls that WinForms does not offer on its own:
    /// global hotkeys, simulated mouse clicks and the dark title bar.
    /// </summary>
    static class Win32
    {
        public const int WM_HOTKEY = 0x0312;

        const int MOUSEEVENTF_LEFTDOWN = 0x02;
        const int MOUSEEVENTF_LEFTUP = 0x04;

        public const byte VK_0 = 0x30;
        const int KEYEVENTF_KEYUP = 0x02;
        const uint MAPVK_VK_TO_VSC = 0;

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int modifiers, int virtualKey);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        static extern void mouse_event(int flags, int dx, int dy, int data, int extraInfo);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte virtualKey, byte scanCode, int flags, int extraInfo);

        [DllImport("user32.dll")]
        static extern uint MapVirtualKey(uint code, uint mapType);

        [DllImport("dwmapi.dll")]
        static extern int DwmSetWindowAttribute(IntPtr hWnd, int attribute, ref int value, int size);

        /// <summary>Makes the window's title bar dark (Windows 10 20H1 and newer; ignored elsewhere).</summary>
        public static void UseDarkTitleBar(IntPtr hWnd)
        {
            const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
            int enabled = 1;
            DwmSetWindowAttribute(hWnd, DWMWA_USE_IMMERSIVE_DARK_MODE, ref enabled, sizeof(int));
        }

        /// <summary>Moves the mouse to (x, y) and does one left click there.</summary>
        public static void ClickAt(int x, int y)
        {
            Cursor.Position = new Point(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        /// <summary>Presses and releases one key in the focused window. Sends the scan code too, so games pick it up.</summary>
        public static void PressKey(byte virtualKey)
        {
            byte scanCode = (byte)MapVirtualKey(virtualKey, MAPVK_VK_TO_VSC);
            keybd_event(virtualKey, scanCode, 0, 0);
            keybd_event(virtualKey, scanCode, KEYEVENTF_KEYUP, 0);
        }
    }
}
