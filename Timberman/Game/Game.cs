using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using static Timberman.GameOver;

namespace Timberman
{
    /// <summary>
    /// Singleplayer game
    /// </summary>
    class Game
    {
        protected ClearBuffer buffer;
        private Player player;

        private int score;
        private int bestScore;
        private int skin;

        public Game()
        {
            LoadConfig();
            score = 0;
            buffer = new ClearBuffer();
            player = new Player(skin);
        }
        
        /// <summary>
        /// Starts the game
        /// </summary>
        public virtual void Start()
        {
            
            while (true) //Main game loop
            {
                Timer timer = new Timer(0.9f); //Creating new timer. Float argument determines how time accerelates with each level

                Tree tree = new Tree(); //Creating tree

                ConsoleKeyInfo input; //Variable to store user's input

                player.Display(); //Displaying player and tree before the start of new round
                tree.Display();

                Hint();

                timer.Start(); //Starting timer

                do //This is round loop
                {
                    input = Console.ReadKey(true);
                    switch (input.Key)
                    {
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.A:
                        case ConsoleKey.D:
                        case ConsoleKey.J:
                        case ConsoleKey.L:
                            player.Cut(input, tree, ref score, ref timer.level);
                            timer.Time++; //Add time if player succesfully cuts the tree
                            Update(player, tree, score, timer);
                            break;
                        case ConsoleKey.Escape:
                            break;
                    }

                } while (input.Key != ConsoleKey.Escape && IsGameOver(tree, player) == false && IsGameOver(timer.Time) == false);

                buffer.Clear();
                tree.Display(); //Displaying tree, player's grave, and stats after game over
                GameOver.Display(score, bestScore);
                player.DisplayGrave();

                if (score > bestScore)
                    bestScore = score; //Setting high score

                score = 0;

                tree.Clear();

                if (input.Key == ConsoleKey.Escape)
                    break; //Breaks game loop if user presses escape

                while (true) //Waiting for user to press continue key
                {
                    input = Console.ReadKey(true);
                    if (input.Key == ConsoleKey.Spacebar || input.Key == ConsoleKey.Enter || input.Key == ConsoleKey.Escape)
                        break;
                }
                if (input.Key == ConsoleKey.Escape)
                    break; //Breaking game loop if user presses escape

                SaveConfig();

                buffer.Clear();

                GC.Collect(); //Just in case
            }
        }
        
        /// <summary>
        /// Selecting character/skin
        /// </summary>
        public virtual void CharacterSelection()
        {
            CharacterMenu menu = new CharacterMenu();
            int choice = menu.Open();
            if (choice != -1)
            {
                player = new Player(choice); //Creates new Player with selected character
                skin = choice; //Skin value is later saved and loaded when starting new game
            }
        }

        /// <summary>
        /// Loop that updates the screen
        /// </summary>
        /// <param name="player"></param>
        /// <param name="tree"></param>
        /// <param name="score"></param>
        /// <param name="timer"></param>
        protected virtual void Update(Player player, Tree tree, int score, Timer timer)
        {
            do
            {
                buffer.Clear();
                tree.Display();
                player.Display();
                DisplayScore(score, 88);
                timer.Display();
                Thread.Sleep(10);
            } while (!Console.KeyAvailable && IsGameOver(tree, player) == false && IsGameOver(timer.Time) == false); //Break when game is over or user presses a key
        }

        /// <summary>
        /// Displays score in selected horizontal position
        /// </summary>
        /// <param name="score"></param>
        /// <param name="pos">Cursor position from left</param>
        protected void DisplayScore(int score, int pos)
        {
            Console.SetCursorPosition(pos, 2);
            Console.Write($"Score: {score}");
            Console.ResetColor();
        }
        
        /// <summary>
        /// Displays flickering "Cut" boxes at the beginning of a round
        /// </summary>
        private void Hint()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;

            Task hint;
            var ts = new CancellationTokenSource(); 
            CancellationToken ct = ts.Token;
            hint = Task.Run(() =>      //Using new task to display hints so there is no delay when user presses a key during Thread.Sleep()
            {
                while (!ct.IsCancellationRequested) {
                    Console.SetCursorPosition(60, 45);
                    Console.Write(" <-A ");
                    Console.SetCursorPosition(119, 45);
                    Console.Write(" D-> ");
                    Thread.Sleep(300);
                    Console.SetCursorPosition(60, 45);
                    Console.Write("     ");
                    Console.SetCursorPosition(119, 45);
                    Console.Write("     ");
                    Thread.Sleep(300);
                }
            }, ct);
            while (!Console.KeyAvailable) { } //Doing nothing and letting the task run until user presses a key
            ts.Cancel(); //Stopping the task
            Console.ResetColor();
        }
        
        /// <summary>
        /// Loads or creates high score and skin from config file
        /// </summary>
        private void LoadConfig()
        {
            if(!File.Exists("config.txt")) //Creating config file if it doesn't exist
                File.WriteAllText("config.txt", Convert.ToString(0)+"\n"+ Convert.ToString(0));
            else
            {
                int[] config = new int[2];
                int i = 0;
                foreach(var line in File.ReadLines("config.txt")) //Loading each line from config file to array
                {
                    config[i] = Convert.ToInt32(line);
                    i++;
                }
                bestScore = config[0];
                skin = config[1];
            }
        }

        /// <summary>
        /// Saves high score and skin to config file
        /// </summary>
        private void SaveConfig()
        {
            File.WriteAllText("config.txt", Convert.ToString(bestScore) + "\n" + Convert.ToString(skin));
        }
    }
}
