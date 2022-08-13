using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Timberman
{
    /// <summary>
    /// Counts from 3 to 1 and displays this numbers. Used to indicate start of a pvp round
    /// </summary>
    class Countdown
    {
        /// <summary>
        /// Starts count down
        /// </summary>
        public void Start()
        {
            Display3();
            Thread.Sleep(1000);
            Clear();
            Display2();
            Thread.Sleep(1000);
            Clear();
            Display1();
            Thread.Sleep(1000);
            Clear();
            DisplayGO();
        }

        /// <summary>
        /// Displays number 3
        /// </summary>
        private void Display3()
        {
            Console.SetCursorPosition(88, 5);
            Console.Write("\u2588\u2588\u2588\u2588");
            Cursor.Down(5);
            Console.Write("\u2588    \u2588");
            Cursor.OneDown();
            Console.Write("\u2588");
            Cursor.Down(3);
            Console.Write("\u2588\u2588");
            Cursor.Down();
            Console.Write("\u2588");
            Cursor.Down(6);
            Console.Write("\u2588    \u2588");
            Cursor.Down(5);
            Console.Write("\u2588\u2588\u2588\u2588");
        }

        /// <summary>
        /// Displays number 2
        /// </summary>
        private void Display2()
        {
            Console.SetCursorPosition(88, 5);
            Console.Write("\u2588\u2588\u2588\u2588");
            Cursor.Down(5);
            Console.Write("\u2588    \u2588");
            Cursor.Down(2);
            Console.Write("\u2588");
            Cursor.Down(2);
            Console.Write("\u2588");
            Cursor.Down(2);
            Console.Write("\u2588");
            Cursor.Down(2);
            Console.Write("\u2588");
            Cursor.Down(2);
            Console.Write("\u2588\u2588\u2588\u2588\u2588\u2588");
        }

        /// <summary>
        /// Displays number 1
        /// </summary>
        private void Display1()
        {
            Console.SetCursorPosition(89, 5);
            Console.Write("\u2588\u2588");
            Cursor.Down(3);
            Console.Write("\u2588 \u2588");
            Cursor.Down(4);
            Console.Write("\u2588  \u2588");
            Cursor.OneDown();
            Console.Write("\u2588");
            Cursor.OneDown();
            Console.Write("\u2588");
            Cursor.OneDown();
            Console.Write("\u2588");
            Cursor.Down(4);
            Console.Write("\u2588\u2588\u2588\u2588\u2588\u2588");
        }

        /// <summary>
        /// Displays "GO!"
        /// </summary>
        private void DisplayGO()
        {
            Console.SetCursorPosition(80, 5);
            Console.Write(" \u2588\u2588\u2588\u2588      \u2588\u2588\u2588\u2588    \u2588");
            Cursor.Down(20);
            Console.Write("\u2588    \u2588    \u2588    \u2588   \u2588");
            Cursor.Down(20);
            Console.Write("\u2588         \u2588    \u2588   \u2588");
            Cursor.Down(20);
            Console.Write("\u2588         \u2588    \u2588   \u2588");
            Cursor.Down(20);
            Console.Write("\u2588   \u2588\u2588\u2588   \u2588    \u2588   \u2588");
            Cursor.Down(20);
            Console.Write("\u2588    \u2588    \u2588    \u2588    ");
            Cursor.Down(20);
            Console.Write(" \u2588\u2588\u2588\u2588      \u2588\u2588\u2588\u2588    \u2588");
        }

        /// <summary>
        /// Clears previous number
        /// </summary>
        private void Clear()
        {
            ClearBuffer buffer = new ClearBuffer();
            buffer.Clear(87, 5, 6, 7);
        }
    }
}
