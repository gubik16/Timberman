using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timberman
{
    /// <summary>
    /// Stores colors that are often used. They can be changed by modifying member's values instead of changing all references.
    /// </summary>
    static class DrawColor
    {
        private static ConsoleColor player1 = ConsoleColor.Green;
        private static ConsoleColor player2 = ConsoleColor.Blue;

        public static ConsoleColor p1
        {
            get { return player1; }
        }
        public static ConsoleColor p2
        {
            get { return player2; }
        }
      
    }
}
