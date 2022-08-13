using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Timberman
{
    /// <summary>
    /// Chosing character
    /// </summary>
    class CharacterMenu:Menu
    {
        public CharacterMenu()
        {
            Configure(new string[] {"Lumberjack", "Boxer", "Bruce Lee"});
            x = 80;
            y = (Console.WindowHeight / 2) - elements.Length / 2;
        }

        /// <summary>
        /// Opens menu
        /// </summary>
        /// <returns>User's choice</returns>
        public override int Open()
        {
            int choice = 0;
            ConsoleKeyInfo key;

            do
            {
                Console.SetCursorPosition(x, y);
                for (int i = 0; i < elements.Length; i++) //Selecting character
                {
                    if (i == choice)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(elements[i].PadRight(longest));
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(elements[i].PadRight(longest));
                    }
                    Cursor.Down(longest);
                }

                ShowSkin(choice);

                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow && choice > 0) //Changing selected option
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
        /// Displays selected skin with it's animation next to menu
        /// </summary>
        /// <param name="choice"></param>
        private void ShowSkin(int choice)
        {
            ClearBuffer buffer = new ClearBuffer();
            Character skin = null;
            switch(choice)
            {
                case 0:
                    skin = new Lumberjack();
                    break;
                case 1:
                    skin = new Boxer();
                    break;
                case 2:
                    skin = new BruceLee();
                    break;
            }
            Console.ResetColor();
            do
            {
                skin.DisplayLeft(100, 30);
                System.Threading.Thread.Sleep(200);
                buffer.Clear(95, 30, 20, 10);
                skin.AnimateLeft(100, 30);
                System.Threading.Thread.Sleep(70);
                buffer.Clear(95, 30, 20, 10);
            } while (!Console.KeyAvailable);
        }
    }
}
