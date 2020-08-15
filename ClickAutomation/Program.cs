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

using static ClickAutomation.DllMethods;
using static ClickAutomation.MacroActions;
namespace ClickAutomation
{
    static class Program
    {
        public static List<MacroActions.Action> MacroActions = new List<MacroActions.Action>();
        private static int _loop;
        static int loop
        {
            get
            { return _loop; }
            set
            { if (value  >= 1) { _loop = value; } else { _loop = 1; } }
        }
        static void Main()
        {
            do
            {
                AddInput();
            }
            while (GetSelection("add more?", new string[] { "y", "n" }) == "y");

            Console.WriteLine("what interval do you want to use between each click? (in ms)");
            int count = Convert.ToInt32(Regex.Replace(Console.ReadLine(), "[^0-9]", ""));
            Console.WriteLine("how many times to loop?");
            loop = int.Parse(Console.ReadLine());
            Console.WriteLine("press enter to start");
            Console.ReadLine();
            for (int i = 0; i < loop; i++)
            {
                foreach (var MacroEvent in MacroActions)
                {
                    System.Threading.Thread.Sleep(count);
                    MacroEvent.Execute();
                }
            }
            Console.WriteLine("press enter to close...."); Console.ReadLine();
        }

        public static void AddInput()
        {
            switch (GetSelection("what input would you like to send, mouse or keyboard ?", new string[]{ "m", "k"}))
            {
                case "m":
                    bool IsDrag = "d" == GetSelection("click or drag?", new string[]{ "c", "d" });

                    string selection = GetSelection("what mouse button to press?", new string[] { "l", "r", "m" });
                    MouseEventFlags[] selected = MouseEventParent.left;
                    switch (selection)
                    {
                        case "l": selected = MouseEventParent.left; break;
                        case "r": selected = MouseEventParent.right; break;
                        case "m": selected = MouseEventParent.middle; break;
                    }

                    Point[] ClickPoints = new Point[2];
                    Console.WriteLine("press enter, with this window focused, to add the current mouse position");
                    Console.ReadLine();
                    ClickPoints[0] = System.Windows.Forms.Cursor.Position;
                    if (IsDrag)
                    {
                        Console.WriteLine("press enter, with this window focused, to add the current mouse position");
                        Console.ReadLine();
                        ClickPoints[1] = System.Windows.Forms.Cursor.Position;
                        MacroActions.Add(new MacroActions.MouseAction(ClickPoints, 'd', selected));
                    }
                    else
                    {
                        MacroActions.Add(new MacroActions.MouseAction(ClickPoints, 'c', selected));
                    }
                    break;

                case "k":
                    Console.WriteLine("what text would you like to type?");
                    MacroActions.Add(new KeyboardAction(Console.ReadLine()));
                    break;
            }
        }

        static string GetSelection(string question, string[] matches)
        {
            question += " (";
            foreach (var charc in matches)
            {
                question += " / " + charc;
            }
            question += ")";
            question = Regex.Replace(question, "\\( / ", "(");
            question = Regex.Replace(question, " / \\)", ")");
            string Inp = "";

            while (true)
            {
                Console.WriteLine(question);
                Inp = Console.ReadLine().ToLower();

                if (matches.Any(match => match == Inp))
                {
                    return Inp;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("invalid input, try again");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}