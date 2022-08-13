using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Timberman
{
    /// <summary>
    /// Player class
    /// </summary>
    class Player
    {
        public int position;
        private Character character;
        private int y = 53;
        private int x1, x2;

        private int side = 0;

        /// <summary>
        /// Player can be only on left or right side of the tree. The sides are indicated by numbers: left is 0, right is 1.
        /// Setter prevents the side from being assigned value different than 0 or 1.
        /// </summary>
        public int Side
        {
            get { return side; }
            set { 
                side = value;
                if (side != 0 && side != 1)
                    throw new BadValueException();
            }
        }

        /// <summary>
        /// Constructor without parameters. Changes the postion appropriate for single player mode, and changes the character to lumber jack.
        /// </summary>
        public Player()
        {
            x1 = 84;
            x2 = x1 + 15;
            position = x1;
            character = new Lumberjack();
        }

        /// <summary>
        /// Creates player with single player postion and selected character.
        /// </summary>
        /// <param name="choice">Character that is selected</param>
        public Player(int choice)
        {
            x1 = 84;
            x2 = x1 + 15;
            position = x1;
            switch (choice)
            {
                case 0:
                    character = new Lumberjack();
                    break;
                case 1:
                    character = new Boxer();
                    break;
                case 2:
                    character = new BruceLee();
                    break;
                default:
                    throw new Exception();
            }
        }

        /// <summary>
        /// Creates player with specified character and position
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="x1"></param>
        public Player(int choice, int x1)
        {
            Side = 0;
            y = 53;
            this.x1 = x1;
            this.x2 = x1 + 15;
            position = x1;
            switch (choice)
            {
                case 0:
                    character = new Lumberjack();
                    break;
                case 1:
                    character = new Boxer();
                    break;
                case 2:
                    character = new BruceLee();
                    break;
                default:
                    throw new Exception();
            }
        }

        /// <summary>
        /// Cuting the tree
        /// </summary>
        /// <param name="side"></param>
        /// <param name="tree"></param>
        /// <param name="score"></param>
        /// <param name="level"></param>
        public void Cut(ConsoleKeyInfo side, Tree tree, ref int score, ref int? level)
        {
            character.Clear(position, y);

            if(side.Key == ConsoleKey.LeftArrow || side.Key == ConsoleKey.A || side.Key == ConsoleKey.J) //Changes player side and postion based on input
            {
                Side = 0;
                position = x1;
            }
            else if (side.Key == ConsoleKey.RightArrow || side.Key == ConsoleKey.D || side.Key == ConsoleKey.L)
            {
                Side = 1;
                position = x2;
            }

            if (tree.BranchHit(this)) //If player hit a branch method ends
                return;

            character.AnimationOn();

            tree.Cut();

            score++; //Incrementing score during successful cut 

            if(level != null) //Level is null in pvp game mode
                if (score % 20 == 0) //Level is increased every 20 cuts
                    level++;

            tree.Add(); 
        }

        /// <summary>
        /// Displays player
        /// </summary>
        public void Display()
        {
            character.Display(side, position, y);
        }

        /// <summary>
        /// Dipslays player's grave
        /// </summary>
        public void DisplayGrave()
        {
            Console.SetCursorPosition(position-3, y);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("       ");
            Cursor.Down(8);
            Console.Write("         ");
            Cursor.Down(9);
            Console.Write("   RIP   ");
            Cursor.Down(9);
            for (int i = 0; i < 4; i++)
            {
                Console.Write("         ");
                Cursor.Down(9);
            }
            Console.ResetColor();
        }
    }
}
