using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIProto1.Pieces
{
    public class Rook : Piece
    {

        public Rook(bool white) : base(white)
        {
            base.type = 1;
        }
    }
}
