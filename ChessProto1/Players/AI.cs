using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1.Players
{
    internal class AI : Player
    {
        private int plyDepth;

        public AI(int plyDepth)
        {
            this.plyDepth = plyDepth;
        }
    }
}
