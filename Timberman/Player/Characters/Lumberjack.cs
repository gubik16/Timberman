using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Timberman
{
    /// <summary>
    /// Lumberjack skin. This is the default skin.
    /// </summary>
    class Lumberjack:Character
    {
        public override void DisplayLeft(int Position, int y)
        {
            Console.SetCursorPosition(Position, y);
            Console.Write("O  |>");
            Console.SetCursorPosition(Position, y + 1);
            Console.Write(@"|  |");
            Console.SetCursorPosition(Position - 2, y + 2);
            Console.Write("/ |--|");
            Console.SetCursorPosition(Position - 2, y + 3);
            Console.Write(@"| |");
            Console.SetCursorPosition(Position, y + 4);
            Console.Write(@"|");
            Console.SetCursorPosition(Position - 1, y + 5);
            Console.Write(@"/ \");
            Console.SetCursorPosition(Position - 2, y + 6);
            Console.Write(@"|   |");
        }
        public override void DisplayRight(int Position, int y)
        {
            Console.SetCursorPosition(Position - 4, y);
            Console.Write(@"<|  O");
            Console.SetCursorPosition(Position - 3, y + 1);
            Console.Write(@"|  |");
            Console.SetCursorPosition(Position - 3, y + 2);
            Console.Write(@"|--| \");
            Console.SetCursorPosition(Position, y + 3);
            Console.Write(@"| |");
            Console.SetCursorPosition(Position, y + 4);
            Console.Write(@"|");
            Console.SetCursorPosition(Position - 1, y + 5);
            Console.Write(@"/ \");
            Console.SetCursorPosition(Position - 2, y + 6);
            Console.Write(@"|   |");
        }
        public override void AnimateLeft(int Position, int y)
        {
            Clear(Position, y);

            Console.SetCursorPosition(Position, y);
            Console.Write(@"O    />");
            Console.SetCursorPosition(Position, y + 1);
            Console.Write(@"|   /");
            Console.SetCursorPosition(Position - 2, y + 2);
            Console.Write(@"/ |--/");
            Console.SetCursorPosition(Position - 2, y + 3);
            Console.Write(@"| |");
            Console.SetCursorPosition(Position, y + 4);
            Console.Write(@"|");
            Console.SetCursorPosition(Position - 1, y + 5);
            Console.Write(@"/ \");
            Console.SetCursorPosition(Position - 2, y + 6);
            Console.Write(@"|   |");
        }
        public override void AnimateRight(int Position, int y)
        {
            Clear(Position, y);

            Console.SetCursorPosition(Position - 6, y);
            Console.Write(@"<\    O");
            Console.SetCursorPosition(Position - 4, y + 1);
            Console.Write(@"\   |");
            Console.SetCursorPosition(Position - 3, y + 2);
            Console.Write(@"\--| \");
            Console.SetCursorPosition(Position, y + 3);
            Console.Write(@"| |");
            Console.SetCursorPosition(Position, y + 4);
            Console.Write(@"|");
            Console.SetCursorPosition(Position - 1, y + 5);
            Console.Write(@"/ \");
            Console.SetCursorPosition(Position - 2, y + 6);
            Console.Write(@"|   |");
        }
    }
}
