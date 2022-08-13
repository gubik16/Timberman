using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timberman
{
    /// <summary>
    /// Easier way to slightly change cursor position
    /// </summary>
    static class Cursor
    {
        // Moves cursor 1 line down and 1 character to the left
        public static void OneDown()
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;

            if (left > 0 && top > 0)
                Console.SetCursorPosition(left - 1, top + 1);
        }
        // Moves cursor 1 line up and 1 character to the left
        public static void OneUp()
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;

            if (left > 0 && top > 0)
                Console.SetCursorPosition(left - 1, top - 1);
        }
        // x is supposed to be lenght of a string, moves cursor one line down so that strings can be displayed one under another
        public static void Down(int x) 
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;

            if (left > 0 && top > 0)
                Console.SetCursorPosition(left - x, top + 1);
        }
        // Moves cursor down, doesn't change horizontal position
        public static void Down()
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;

            if (left > 0 && top > 0)
                Console.SetCursorPosition(left, top + 1);
        }
        // Centers cursor
        public static void Center() 
        {
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
        }
    }
}
