using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Numerics;
using System.Reflection.Emit;
using System.Data;

using static ClickAutomation.MacroActions;
namespace ClickAutomation
{
    
    public static class DllMethods
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwflags, int dx = 0, int dy = 0, int dwData = 0, int dwExtraInfo = 0);

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x0002,
            LEFTUP = 0x0004,
            RIGHTDOWN = 0x0008,
            RIGHTUP = 0x0010,
            MIDDLEDOWN = 0x0020,
            MIDDLEUP = 0x0040,
            ABSOLUTE = 0x00008000
        }

        public static class MouseEventParent
        {
            public static readonly MouseEventFlags[] left = new MouseEventFlags[] { MouseEventFlags.LEFTDOWN, MouseEventFlags.LEFTUP };
            public static readonly MouseEventFlags[] right = new MouseEventFlags[] { MouseEventFlags.RIGHTDOWN, MouseEventFlags.RIGHTUP };
            public static readonly MouseEventFlags[] middle = new MouseEventFlags[] { MouseEventFlags.MIDDLEDOWN, MouseEventFlags.MIDDLEUP };
        }

        public static void Click(MouseEventFlags[] mouseEventFlagsArr, Point Pos)
        {
            SetCursorPos(Pos.X, Pos.Y);
            mouse_event((int)mouseEventFlagsArr[0]);
            mouse_event((int)mouseEventFlagsArr[1]);
        }
        public static void Drag(MouseEventFlags[] mouseEventFlagsArr, Point FirstPos, Point SecondPos)
        {
            SetCursorPos(FirstPos.X, FirstPos.Y);
            mouse_event((int)mouseEventFlagsArr[0]);
            System.Threading.Thread.Sleep(1000);
            SetCursorPos(SecondPos.X, SecondPos.Y);
            mouse_event((int)mouseEventFlagsArr[1]);
        }
    }
}