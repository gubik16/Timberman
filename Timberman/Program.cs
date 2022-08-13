using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Timberman
{
    /// <summary>
    /// Main program
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(180, 62); //Setting window size and buffer
            Console.SetBufferSize(180, 62);
            Console.CursorVisible = false; //Turning off visible cursor
            Console.OutputEncoding = Encoding.Unicode; //Setting console's encoding to unicode
           
            Menu menu = new Menu(new string[] {"Play", "Characters", "Back"});
            Game game = null;

            while (true) //Main program loop
            {
                Console.Clear();
                DisplayTitle();

                int mode = ChoseGamemode(); //Selecting game mode

                if (mode == -1 || mode == 2)
                    break;
                else if (mode == 0)
                    game = new Game();
                else if (mode == 1)
                    game = new PvP();

                while(true) //Game mode menu loop
                {
                    Console.Clear();

                    DisplayTitle();

                    int choice = menu.Open();

                    if (choice == -1 || choice == 2)
                        break;

                    Console.Clear();

                    switch (choice)
                    {
                        case 0:
                            game.Start(); //Starting the game
                            break;
                        case 1:
                            game.CharacterSelection(); //Selecting character
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// Chosing game mode
        /// </summary>
        /// <returns></returns>
        static int ChoseGamemode()
        {
            Menu gameModeMenu = new Menu(new string[] {"Solo", "Two Players", "Exit"});
            int mode = gameModeMenu.Open();
            return mode;
        }

        //Displaying game title above menu
        static void DisplayTitle()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(60, 15);
            Console.Write(" _______ _           _                                     ");
            Cursor.Down(59);
            Console.Write("|__   __(_)         | |                                    ");
            Cursor.Down(59);
            Console.Write("   | |   _ _ __ ___ | |__   ___ _ __ _ __ ___   __ _ _ __  ");
            Cursor.Down(59);
            Console.Write(@"   | |  | | '_ ` _ \| '_ \ / _ \ '__| '_ ` _ \ / _` | '_ \ ");
            Cursor.Down(59);
            Console.Write("   | |  | | | | | | | |_) |  __/ |  | | | | | | (_| | | | |");
            Cursor.Down(59);
            Console.Write(@"   |_|  |_|_| |_| |_|_.__/ \___|_|  |_| |_| |_|\__,_|_| |_|");
            Console.ResetColor();
        }
    }
}
