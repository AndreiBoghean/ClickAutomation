using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public enum MouseActionType
            {
                Click, Drag
            }
            private Point[] ClickPoints;
            private MouseActionType SelectedMouseAction;

            public MouseAction(Point[] Points, MouseActionType actionType)
            {
                ClickPoints = Points;
                SelectedMouseAction = actionType;
            }

            public override void Execute()
            {
                switch (SelectedMouseAction)
                {
                    case MouseActionType.Click:
                        DllMethods.Click( new DllMethods.MouseEventFlags[]{ DllMethods.MouseEventFlags.LEFTDOWN, DllMethods.MouseEventFlags.LEFTUP}, ClickPoints[0]);
                        break;
                    case MouseActionType.Drag:
                        break;
                }
            }
        }

    }
}