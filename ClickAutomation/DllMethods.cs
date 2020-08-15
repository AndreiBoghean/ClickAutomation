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
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
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
            SetCursorPos(SecondPos.X, SecondPos.Y);
            mouse_event((int)mouseEventFlagsArr[1]);
        }
    }
}