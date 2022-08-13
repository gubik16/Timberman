using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Timberman.GameOver;

namespace Timberman
{
    /// <summary>
    /// Keeps track of point in pvp game
    /// </summary>
    class Scoreboard
    {
        private Dictionary<string, int> scoreboard = new Dictionary<string, int>(); //Saving player's score in dictionary
        private string player1, player2;
        public int winner;

        public Scoreboard()
        {
            player1 = "player 1";
            player2 = "player 2";
            Add();
        }

        /// <summary>
        /// Adds players to dictionary
        /// </summary>
        private void Add()
        {
            scoreboard.Add(player1, 0);
            scoreboard.Add(player2, 0);
        }

        /// <summary>
        /// Adds score to winner
        /// </summary>
        public void AddScore()
        {
            if (winner == 1)
                scoreboard[player1]++;
            else if (winner == 2)
                scoreboard[player2]++;
        }

        /// <summary>
        /// Check if any player won the game
        /// </summary>
        /// <returns>True if any player reached 3 points</returns>
        public bool CheckForWin()
        {
            if (scoreboard[player1] == 3)
            {
                Display($"{player1} won!", DrawColor.p1);
                return true;
            }
            else if (scoreboard[player2] == 3)
            {
                Display($"{player2} won!", DrawColor.p2);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Shows how many points players have
        /// </summary>
        public void Show()
        {
            Console.SetCursorPosition(44, 5);
            Console.ForegroundColor = DrawColor.p1;
            DrawBoxes(scoreboard[player1]);
            Console.SetCursorPosition(133, 5);
            Console.ForegroundColor = DrawColor.p2;
            DrawBoxes(scoreboard[player2]);
            Console.ResetColor();
        }

        /// <summary>
        /// Draws 3 empty or filled boxes that indicate how many points player has
        /// </summary>
        /// <param name="a"></param>
        private void DrawBoxes(int a)
        {
            switch (a)
            {
                case 0:
                    Console.Write("\u25a1 \u25a1 \u25a1");
                    break;
                case 1:
                    Console.Write("\u2580 \u25a1 \u25a1");
                    break;
                case 2:
                    Console.Write("\u2580 \u2580 \u25a1");
                    break;
                case 3:
                    Console.Write("\u2580 \u2580 \u2580");
                    break;
            }
        }
    }   
}
