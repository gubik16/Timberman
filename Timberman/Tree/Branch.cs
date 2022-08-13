using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timberman
{
    /// <summary>
    /// Branch tree part
    /// </summary>
    class Branch: Trunk
    {
        private int side;

        public int Side
        {
            get { return side; }
            set {
                side = value;
                if (side != 0 && side != 1)
                    throw new BadValueException();
            }
        }

        /// <summary>
        /// Constructors create new branch with random side
        /// </summary>
        /// <param name="posY"></param>
        public Branch(int posY) : base(posY)
        {
            Random rand = new Random();
            Side = rand.Next(0, 2);
        }
        public Branch(int posY, int posX) : base(posY, posX)
        {
            Random rand = new Random();
            Side = rand.Next(0, 2);
        }

        /// <summary>
        /// Displays branch
        /// </summary>
        public override void Display()
        {
            if (Side == 1)
            {
                Console.SetCursorPosition(posX, posY - 8);
                Console.Write("####");
                Cursor.Down(4);
                Console.Write("####");
                Cursor.Down(4);
                Console.Write("####");
                Cursor.Down(4);
                Console.Write("####");
                Cursor.Down(4);
                Console.Write("####  /   /"); 
                Cursor.Down(11);
                Console.Write("####========<"); 
                Cursor.Down(13);
                Console.Write(@"####  \   \");
                Cursor.Down(11);
                Console.Write("####");
                Cursor.Down(4);
                Console.Write("####");
            }
            else if (Side == 0)
            {
                Console.SetCursorPosition(posX, posY - 8);
                Console.Write("####");
                Cursor.Down(4);
                Console.Write("####");
                Cursor.Down(4);
                Console.Write("####");
                Cursor.Down(4);
                Console.Write("####");
                Cursor.Down(11);
                 Console.Write(@"\   \  ####");
                Cursor.Down(13);
                Console.Write(">========####");
                Cursor.Down(11);
                Console.Write("/   /  ####");
                Cursor.Down(4);
                Console.Write("####");
                Cursor.Down(4);
                Console.Write("####");
            }
        }
    }
}
