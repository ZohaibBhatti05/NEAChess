using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIProto1.Pieces
{
    public class Knight : Piece
    {
        public Knight(bool white) : base(white)
        {
            base.type = 2;
        }
    }
}
