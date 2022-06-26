using Prototype1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype1.Pieces
{
    class Knight : Piece
    {
        public Knight(PlayerColour colour) : base(colour)
        {
            base.type = 2;
        }
    }
}
