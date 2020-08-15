using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static ClickAutomation.DllMethods;
using SendKeys = System.Windows.Forms.SendKeys;
namespace ClickAutomation
{
    class MacroActions
    {
        public abstract class Action
        {
            public abstract void Execute();
        }

        public class MouseAction : Action
        {

            private Point[] ClickPoints;
            private char SelectedMouseAction;
            private MouseEventFlags[] BtnsToClick;
            public MouseAction(Point[] Points, char actionType, MouseEventFlags[] ButtonToClick)
            {
                ClickPoints = Points;
                BtnsToClick = ButtonToClick;
                SelectedMouseAction = actionType;
            }

            public override void Execute()
            {
                switch (SelectedMouseAction)
                {
                    case 'c':
                        Click( BtnsToClick, ClickPoints[0]);
                        break;
                    case 'd':
                        Drag(BtnsToClick, ClickPoints[0], ClickPoints[1]);
                        break;
                }
            }
        }

        public class KeyboardAction : Action
        {
            string str = "";
            public KeyboardAction(string inp)
            { str = inp; }
            public override void Execute()
            {
                SendKeys.SendWait(str);
            }
        }

    }
}