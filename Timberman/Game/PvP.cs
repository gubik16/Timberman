using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static Timberman.GameOver;

namespace Timberman
{
    /// <summary>
    /// Pvp game mode for 2 players
    /// </summary>
    class PvP : Game
    {
        Player player1 = new Player(0, 39); //Creating 2 player, each one in different position
        Player player2 = new Player(0, 127);

        Countdown countdown = new Countdown(); //Creating new scoreboard and countdown
        Scoreboard scoreboard = new Scoreboard();

        private int score1; //Player 1 score
        private int score2; //Player 2 score
        private int lead; 
        private int? nullValue = null; //Null value that is passed to player's Cut method instead of level
        public PvP()
        {
            score1 = 0;
            score2 = 0;
            lead = 20;
            buffer = new ClearBuffer();
        }
        public override void Start()
        {
            while (true) //Main game loop
            {
                buffer.Clear();

                Tree tree1 = new Tree(45); //Creating trees in different positions
                Tree tree2 = new Tree(133);

                ConsoleKeyInfo input;

                //Displaying players, tree, scores at the start
                player1.Display();
                player2.Display();
                tree1.Display();
                tree2.Display();
                DisplayScore(score1, 43, DrawColor.p1);
                DisplayScore(score2, 131, DrawColor.p2);
                scoreboard.Show();
                ShowLead();

                countdown.Start(); //Starting count down

                buffer.ClearInputBuffer(); //Clearing input buffer, without this line if user pressed keys during count down, they would be read from console input buffer into input variable

                do //Round loop
                {
                    input = Console.ReadKey(true);
                    switch (input.Key)
                    {
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.RightArrow:
                            player2.Cut(input, tree2, ref score2, ref nullValue);
                            Update(tree1, tree2, scoreboard);
                            break;
                        case ConsoleKey.A:
                        case ConsoleKey.D:
                            player1.Cut(input, tree1, ref score1, ref nullValue);
                            Update(tree1, tree2, scoreboard);
                            break;
                        case ConsoleKey.Escape:
                            break;
                    }
                } while (input.Key != ConsoleKey.Escape && IsPvPOver(player1, player2, tree1, tree2, lead, ref scoreboard) == false && !scoreboard.CheckForWin());

                scoreboard.AddScore(); //If player won a round he gains a score
                player1.Display();
                player2.Display();
                score1 = 0;
                score2 = 0;
                tree1.Clear();
                tree2.Clear();

                if (input.Key == ConsoleKey.Escape) //Ends game if user pressed escape
                    break;

                if (scoreboard.CheckForWin()) //Checking if any player won the game. Game is best of 5.
                {
                    scoreboard.Show();
                    while(Console.ReadKey(true).Key != ConsoleKey.Enter) //Displaying end message
                    {
                        EndMessage();
                    }
                    break;
                }
                Thread.Sleep(2000); //Waiting 2s after round is over so the users can clearly see who won
            }
        }
        
        /// <summary>
        /// Selecting character for each player
        /// </summary>
        public override void CharacterSelection()
        {
            CharacterMenu menu = new CharacterMenu();
            ShowChosingPlayer(menu.Y - 5, DrawColor.p1, 1);
            int choice = menu.Open();
            if (choice != -1)
                player1 = new Player(choice, 39);
            ShowChosingPlayer(menu.Y - 5, DrawColor.p2, 2);
            choice = menu.Open();
            if (choice != -1)
                player2 = new Player(choice, 129);
        }

        /// <summary>
        /// Shows which player is chosing his character
        /// </summary>
        /// <param name="y"></param>
        /// <param name="color"></param>
        /// <param name="player"></param>
        private void ShowChosingPlayer(int y, ConsoleColor color, int player)
        {
            Console.SetCursorPosition(84, y);
            Console.ForegroundColor = color;
            Console.Write($"Player {player} choses");
            Console.ResetColor();
        }

        /// <summary>
        /// Loop that updates the screen
        /// </summary>
        /// <param name="tree1"></param>
        /// <param name="tree2"></param>
        /// <param name="scoreboard"></param>
        private void Update(Tree tree1, Tree tree2, Scoreboard scoreboard)
        {
            do
            {
                buffer.Clear();
                player1.Display();
                player2.Display();
                tree1.Display();
                tree2.Display();
                DisplayScore(score1, 43, DrawColor.p1);
                DisplayScore(score2, 133, DrawColor.p2);
                scoreboard.Show();
                ShowLead();
                Thread.Sleep(10);
            } while (!Console.KeyAvailable && !IsPvPOver(player1, player2, tree1, tree2, lead, ref scoreboard));
        }

        /// <summary>
        /// Displays score in selected horizontal position and color
        /// </summary>
        /// <param name="score"></param>
        /// <param name="pos"></param>
        /// <param name="color"></param>
        protected void DisplayScore(int score, int pos, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            base.DisplayScore(score, pos);
            Console.ResetColor();
        }

        /// <summary>
        /// Show which player is leading (has more score)
        /// </summary>
        private void ShowLead()
        {
            lead = score1 - score2 + 20;

            Console.SetCursorPosition(70, 4);
            Console.BackgroundColor = DrawColor.p2;
            Console.Write(String.Concat(Enumerable.Repeat(" ", 40)));
            Console.SetCursorPosition(70, 4);
            Console.BackgroundColor = DrawColor.p1;
            Console.Write(String.Concat(Enumerable.Repeat(" ", lead)));
            Console.ResetColor();
        }

        /// <summary>
        /// Flickering hint message at the end of the game
        /// </summary>
        private void EndMessage()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            while (!Console.KeyAvailable)
            {
                Console.SetCursorPosition(85, 20);
                Console.Write("Press Enter");
                Thread.Sleep(300);
                Console.SetCursorPosition(85, 20);
                Console.Write("           ");
                Thread.Sleep(300);
            }
            Console.ResetColor();
        }
    }
}
