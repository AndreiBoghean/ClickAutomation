using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;

using System.Windows.Input;
namespace ClickAutomation
{
    class Program
    {
        public static List<MacroActions.Action> TouchPoints = new List<MacroActions.Action>();
        void Main()
        {
            while (true)
            {
                AddInput();
                Console.WriteLine("add more? (y / n)");
                string inp = Console.ReadLine();

                while (true)
                {
                    if ((inp.ToLower() == "y") || (inp.ToLower() == "n")) break;
                    Console.WriteLine("invalid input, retry input (y / n)");
                }
                if (inp == "n") break;
            }
            Console.WriteLine("what interval do you want to use between each click? (in ms)");
            int count = Convert.ToInt32(Regex.Replace(Console.ReadLine(), "[^0-9]", ""));
            count = Math.Abs(count);
            Console.WriteLine("press enter to close...."); Console.ReadLine();
        }

        public void AddInput()
        {
            string Inp = "";
            bool validInp = false;

            while (!validInp)
            {
                Console.WriteLine("what input would you like to send, mouse or keyboard? (m / k)");
                Inp = Console.ReadLine();

                validInp = (Inp == "m" || Inp == "k");
            }

            switch (Inp)
            {
                case "m":
                    Console.WriteLine("press enter, with this window focused, to add the current mouse position");
                    Console.ReadLine();
                    TouchPoints.Add(new MacroActions.MouseAction(new Point[]{ System.Windows.Forms.Cursor.Position }, MacroActions.MouseAction.MouseActionType.Click) );
                    break;
                case "k":
                    Console.WriteLine("what text would you like to write?");
                    Inp = Console.ReadLine();
                    break;
            }
        }
    }
}