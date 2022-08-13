using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timberman
{
    /// <summary>
    /// Trunk tree part
    /// </summary>
    class Trunk: TreePart
    {
        public Trunk(int posY) : base(posY)
        {
            Model = "####";
        }
        public Trunk(int posY, int posX) : base(posY, posX)
        {
            Model = "####";
        }
    }
}
