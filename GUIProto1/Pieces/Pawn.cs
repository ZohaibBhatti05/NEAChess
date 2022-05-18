using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIProto1.Pieces
{
    internal class Pawn : Piece
    {
        
        public Pawn(bool white) : base(white)
        {
            base.type = 0;
        }
    }
}
