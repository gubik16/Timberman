using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timberman
{
    /// <summary>
    /// Clear console in more efficient way than Console.Clear() method
    /// </summary>
    class ClearBuffer
    {
        protected string clearBuffer = null;

        /// <summary>
        /// Creates string of spaces as big as console buffer
        /// </summary>
        public ClearBuffer()
        {
            string line = "".PadRight(Console.WindowWidth, ' ');
            StringBuilder lines = new StringBuilder();

            for (int i = 0; i < Console.WindowHeight; i++)
                lines.AppendLine(line);

            clearBuffer = lines.ToString();
        }

        /// <summary>
        /// Clears console by writing clearBuffer
        /// </summary>
        public void Clear()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(clearBuffer);
        }

        /// <summary>
        /// Clears a part of console
        /// </summary>
        /// <param name="x">position of top left corner from left </param>
        /// <param name="y">position of top left corner from top </param>
        /// <param name="w">width of clear block </param>
        /// <param name="h">heigh of clear block </param>
        public void Clear(int x, int y, int w, int h)
        {
            for (int i = 0; i < h; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write("".PadRight(w, ' '));
            }
        }
        /// <summary>
        /// Clears console's input buffer
        /// </summary>
        public void ClearInputBuffer()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }
    }
}
