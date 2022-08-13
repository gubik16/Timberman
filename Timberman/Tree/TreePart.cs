using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timberman
{
    /// <summary>
    /// Branch and trunk interface
    /// </summary>
    abstract class TreePart
    {
        protected int posX = 90;

        protected int posY;

        public int Y
        {
            get { return posY; }
            set { posY = value; }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public TreePart(int posY)
        {
            this.posY = posY;
        }
        public TreePart(int posY, int posX)
        {
            this.posY = posY;
            this.posX = posX;
        }

        /// <summary>
        /// Displays tree part
        /// </summary>
        public virtual void Display()
        {
            Console.SetCursorPosition(posX, posY-8);
            for (int i = 0; i < 9; i++)
            {
                Console.Write(Model);
                Cursor.Down(4);
            }
        }
    }
}
