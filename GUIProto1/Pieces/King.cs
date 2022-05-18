using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIProto1.Pieces
{
    internal class King : Piece
    {
        public King(bool white) : base(white)
        {
            base.type = 4;
        }
    }
}
