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

namespace ClickAutomation
{
    class Program
    {
        public static List<Point> TouchPoints = new List<Point>();
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("press enter with this window focused to add mouse pos as a point");
                Console.ReadLine();

                TouchPoints.Add(System.Windows.Forms.Cursor.Position);

                Console.WriteLine("add more? (y / n)");
                string inp = Console.ReadLine();

                while (true)
                {
                    if ((inp.ToLower() == "y") || (inp.ToLower() == "n")) break;
                    Console.WriteLine("invalid input, retry input (y / n)");
                }
                if (inp == "n") break;
            }
            Console.WriteLine("what interval do you want to use between each click?");
            int count = Convert.ToInt32(Regex.Replace(Console.ReadLine(), "^[0-9]", ""));
            //count = Math.

            Console.WriteLine("press enter to begin click routine");
            Console.ReadLine();

            foreach (var position in TouchPoints)
            {
                System.Threading.Thread.Sleep(2500);
                DllMethods.Click(new DllMethods.MouseEventFlags[] { DllMethods.MouseEventFlags.LEFTDOWN, DllMethods.MouseEventFlags.LEFTUP }, position);
            }

            Console.WriteLine("press enter to close...."); Console.ReadLine();
        }
    }
}