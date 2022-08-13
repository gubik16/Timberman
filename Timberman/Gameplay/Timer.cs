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
    /// Counts time in single player game
    /// </summary>
    class Timer
    {
        Thread thread = null;
        Task ct;
        private float multiplier;
        private int time;
        public int? level;

        /// <summary>
        /// Setters prevent time value from being higher than 30
        /// </summary>
        public int Time
        {
            get { return time; }
            set
            {
                if (time < 30)
                    time = value;
            }
        }

        public Timer(float multiplier)
        {
            this.multiplier = multiplier;
            time = 15;
            level = 1;
        }

        /// <summary>
        /// Starts counting time in a separate task
        /// </summary>
        public void Start()
        {
            thread = null;
            ct = Task.Run(() => { thread = Thread.CurrentThread; Console.CursorVisible = false; CountTime(); });
        }

        /// <summary>
        /// Counts time
        /// </summary>
        private void CountTime()
        {
            while (true) //Decrements time variable
            {
                Thread.Sleep(Clock());
                if (IsGameOver(time)) //Breaks loop if game is over
                    break;
                time--;
            }
        }

        /// <summary>
        /// Counts how fast the time should decrement. Time goes faster with each level.
        /// </summary>
        /// <returns></returns>
        private int Clock()
        {
            double result = 1000;
            for (int i = 0; i < level; i++)
            {
                result *= multiplier;
            }
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Displays the time
        /// </summary>
        public void Display()
        {
            Console.SetCursorPosition(88, 3);
            Console.Write($"Level  {level}");

            Console.SetCursorPosition(77, 4);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(String.Concat(Enumerable.Repeat(" ", 30)));
            Console.SetCursorPosition(77, 4);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write(String.Concat(Enumerable.Repeat(" ", time)));
            Console.ResetColor();
        }
    }
}
