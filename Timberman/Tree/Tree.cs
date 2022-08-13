using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timberman
{
    /// <summary>
    /// Storing tree parts
    /// </summary>
    class Tree
    {
        protected List<TreePart> tree; //Using list instead of queue to store the parts, because list works just fine and gives more freedom
        protected int posX = 90;
        public Tree() //Upon creating the tree every part is a trunk
        {
            tree = new List<TreePart>();

            for (int i = 0; i <= 5; i++)
            {
                tree.Add(new Trunk(60 - (i * 9)));
            }
        }
        public Tree(int posX)
        {
            this.posX = posX;
            tree = new List<TreePart>();

            for (int i = 0; i <= 5; i++)
            {
                tree.Add(new Trunk(60 - (i * 9), posX));
            }
        }

        /// <summary>
        /// Displays the whole tree
        /// </summary>
        public void Display()
        {
            for (int i = 0; i < tree.Count; i++)
            {
                tree[i].Display();
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Checks if player hit a branch
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool BranchHit(Player player)
        {
            if (tree[0] is Branch && (tree[0] as Branch).Side == player.Side)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Removes tree part at the bottom of the tree
        /// </summary>
        public void Cut()
        {
            tree.RemoveAt(0);

            for (int i = 0; i < tree.Count; i++)
            {
                tree[i].Y += 9;
            }
        }

        /// <summary>
        /// Adds tree part at the top of the tree. Branches and trunks are added alternatly
        /// </summary>
        public void Add()
        {
            if (tree[4] is Branch)
                tree.Add(new Trunk(tree[4].Y - 9, posX));
            else
                tree.Add(new Branch(tree[4].Y - 9, posX));
        }

        /// <summary>
        /// Clears the tree
        /// </summary>
        public void Clear()
        {
            tree.Clear();
        }
        ~Tree()
        {
            Clear();
        }
    }
}
