using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timberman
{
    /// <summary>
    /// Checks if game is over
    /// </summary>
    static class GameOver
    {
        /// <summary>
        /// Checks if player hit a branch
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="player"></param>
        /// <returns>True if player hit a branch and died</returns>
        public static bool IsGameOver(Tree tree, Player player)
        {
            if (tree.BranchHit(player))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if player ran out of time
        /// </summary>
        /// <param name="time"></param>
        /// <returns>True if time reached 0</returns>
        public static bool IsGameOver(int time)
        {
            if (time <= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if pvp round is over, and displays which player won
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <param name="tree1"></param>
        /// <param name="tree2"></param>
        /// <param name="lead"></param>
        /// <param name="scoreboard"></param>
        /// <returns>True if round is over</returns>
        public static bool IsPvPOver(Player player1, Player player2, Tree tree1, Tree tree2, int lead, ref Scoreboard scoreboard)
        {
            if (lead <= 0)
            {
                Display("Player 1 won the round", DrawColor.p1);
                scoreboard.winner = 1;
                return true;
            }
            else if (lead >= 40)
            {
                Display("Player 2 won the round", DrawColor.p2);
                scoreboard.winner = 2;
                return true;
            }
            else if (tree1.BranchHit(player1))
            {
                Display("Player 2 won the round", DrawColor.p2);
                scoreboard.winner = 2;
                return true;
            }
            else if (tree2.BranchHit(player2))
            {
                Display("Player 1 won the round", DrawColor.p1);
                scoreboard.winner = 1;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Displays information box if game is over
        /// </summary>
        /// <param name="score"></param>
        /// <param name="bestScore"></param>
        public static void Display(int score, int bestScore)
        {
            if (score > bestScore)
                bestScore = score;

            Console.SetCursorPosition(79, 24);
            Console.Write("                          ");
            Cursor.Down(26);
            Console.Write("\u250c"); Console.Write(String.Concat(Enumerable.Repeat("\u2500", 24))); Console.Write("\u2510");
            Cursor.Down(26);
            Console.Write("\u2502       Game Over!       \u2502");
            Cursor.Down(26);
            Console.Write($"\u2502                        \u2502");
            Cursor.Down(26);
            Console.Write($"\u2502                        \u2502");
            Cursor.Down(26);
            Console.Write($"\u2502                        \u2502");
            Cursor.Down(26);
            Console.Write($"\u2502  Press Space or Enter  \u2502");
            Cursor.Down(26);
            Console.Write("\u2514"); Console.Write(String.Concat(Enumerable.Repeat("\u2500", 24))); Console.Write("\u2518");
            Cursor.Down(26);
            Console.Write("                          ");
            Console.SetCursorPosition(85, 27);
            Console.Write($"Best score: {bestScore}");
            Console.SetCursorPosition(88, 28);
            Console.Write($"Score: {score}");
        }

        /// <summary>
        /// Displays given string in given color
        /// </summary>
        /// <param name="s"></param>
        /// <param name="color"></param>
        public static void Display(string s, ConsoleColor color)
        {
            Console.SetCursorPosition(70, 4);
            Console.Write(String.Concat(Enumerable.Repeat(" ", 42)));
            Console.SetCursorPosition(Console.WindowWidth / 2 - s.Length/2, 4);
            Console.BackgroundColor = color;
            Console.Write(s);
            Console.ResetColor();
        }
    }
}
