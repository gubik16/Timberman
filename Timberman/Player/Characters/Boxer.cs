using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timberman
{
    /// <summary>
    /// Boxer skin
    /// </summary>
    class Boxer:Character
    {
        public override void DisplayLeft(int Position, int y)
        {
            Clear(Position, y);

            Console.SetCursorPosition(Position, y);
            Console.Write("O");
            Console.SetCursorPosition(Position, y + 1);
            Console.Write("|");
            Console.SetCursorPosition(Position - 2, y + 2);
            Console.Write(@"/ | \");
            Console.SetCursorPosition(Position - 2, y + 3);
            Console.Write(@"| | |");
            Console.SetCursorPosition(Position - 2, y + 4);
            Console.Write(@"o | o");
            Console.SetCursorPosition(Position - 1, y + 5);
            Console.Write(@"/ \");
            Console.SetCursorPosition(Position - 2, y + 6);
            Console.Write(@"|   |");
        }
        public override void DisplayRight(int Position, int y)
        {
            DisplayLeft(Position, y);
        }
        public override void AnimateLeft(int Position, int y)
        {
            Clear(Position, y);

            Console.SetCursorPosition(Position, y);
            Console.Write(@"O");
            Console.SetCursorPosition(Position, y + 1);
            Console.Write(@"|");
            Console.SetCursorPosition(Position - 2, y + 2);
            Console.Write("/ | \u2015\u2015\u2015\u2015o");
            Console.SetCursorPosition(Position - 2, y + 3);
            Console.Write(@"| |");
            Console.SetCursorPosition(Position - 2, y + 4);
            Console.Write(@"o |");
            Console.SetCursorPosition(Position - 1, y + 5);
            Console.Write(@"/ \");
            Console.SetCursorPosition(Position - 2, y + 6);
            Console.Write(@"|   |");

        }
        public override void AnimateRight(int Position, int y)
        {
            Clear(Position, y);

            Console.SetCursorPosition(Position, y);
            Console.Write(@"O");
            Console.SetCursorPosition(Position, y + 1);
            Console.Write(@"|");
            Console.SetCursorPosition(Position - 6, y + 2);
            Console.Write("o\u2015\u2015\u2015\u2015"); Console.Write(@" | \");
            Console.SetCursorPosition(Position , y + 3);
            Console.Write(@"| |");
            Console.SetCursorPosition(Position, y + 4);
            Console.Write(@"| o");
            Console.SetCursorPosition(Position - 1, y + 5);
            Console.Write(@"/ \");
            Console.SetCursorPosition(Position - 2, y + 6);
            Console.Write(@"|   |");
        }
    }
}
