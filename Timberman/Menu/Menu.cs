using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Timberman.Cursor;
namespace Timberman
{
    /// <summary>
    /// Game menu
    /// </summary>
    class Menu
    {
        protected string[] elements = new string[0]; //Array that stores menu options
        protected int longest; //Length of the longest string
        protected int x, y;
        public int Y
        {
            get { return y; }
        }
        public Menu() { } //Empty constructor that is called when creating derived class
        public Menu(string[] elements)
        {
            Configure(elements);

            x = (Console.WindowWidth / 2) - (longest / 2);
            y = (Console.WindowHeight / 2) - elements.Length / 2;
        }

        /// <summary>
        /// Add elements to array and count longest string's length
        /// </summary>
        /// <param name="elements"></param>
        protected void Configure(string[] elements)
        {
            if (elements != null)
            {
                this.elements = elements;
                longest = elements[0].Length;
            }

            for (int i = 0; i < this.elements.Length; i++)
                if (this.elements[i].Length > longest)
                    longest = this.elements[i].Length;
        }

        /// <summary>
        /// Opens menu
        /// </summary>
        /// <returns>User's choice</returns>
        public virtual int Open()
        {
            int choice = 0;
            ConsoleKeyInfo key;

            do
            {
                Console.SetCursorPosition(x, y);
                for (int i = 0; i < elements.Length; i++) //Selecting option
                {
                    if (i == choice)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        DisplayElement(i);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        DisplayElement(i);
                    }
                    Console.SetCursorPosition(x, y + i + 1);
                }

                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow && choice > 0) //Changing selection
                    choice--;
                else if (key.Key == ConsoleKey.DownArrow && choice < elements.Length - 1)
                    choice++;
                else if (key.Key == ConsoleKey.Escape)
                    choice = -1;
            } while (key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Enter);

            Console.ResetColor();

            return choice;
        }

        /// <summary>
        /// Displays element
        /// </summary>
        /// <param name="i"></param>
        private void DisplayElement(int i)
        {
            Console.Write("".PadRight(longest));
            Console.SetCursorPosition(x + ((longest / 2) - (elements[i].Length / 2)), y + i);
            Console.Write(elements[i]);
        }
    }
}
