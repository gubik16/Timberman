using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timberman
{
    /// <summary>
    /// Character's interface
    /// </summary>
    abstract class Character
    {
        protected int animationTime = 70; //Determines how long does the animation lasts
        protected bool animating = false;
        public abstract void DisplayLeft(int Position, int y); //Displaying player on the left side of the tree
        public abstract void DisplayRight(int Position, int y); //Displaying player on the right side of the tree
        public abstract void AnimateLeft(int Position, int y); //Displaying player's animation on the left side of the tree
        public abstract void AnimateRight(int Position, int y); //Displaying player's animation on the right side of the tree

        /// <summary>
        /// Displays the character
        /// </summary>
        /// <param name="side"></param>
        /// <param name="Position"></param>
        /// <param name="y"></param>
        public void Display(int side, int Position, int y)
        {
            if(side == 0)
            {
                if (animating)
                    AnimateLeft(Position, y);
                else
                    DisplayLeft(Position, y);
            }
            else if(side == 1)
            {
                if (animating)
                    AnimateRight(Position, y);
                else
                    DisplayRight(Position, y);
            }
        }

        /// <summary>
        /// Clears the character from screen
        /// </summary>
        /// <param name="Position"></param>
        /// <param name="y"></param>
        public void Clear(int Position, int y)
        {
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(Position - 4, y + i);
                Console.Write("         ");
            }
        }

        /// <summary>
        /// Sets animating variable to true and false after animation time.
        /// </summary>
        public void AnimationOn()
        {
            Task.Run(() => { animating = true; System.Threading.Thread.Sleep(animationTime); animating = false; });
        }
    }
}
