using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIProto1.Pieces
{
    public class Piece
    {
        public bool isWhite { get; private set; }
        public int type { get; protected set; }
        public Piece(bool white)
        {
            isWhite = white;
        }

        public virtual void GenerateLegalMoves()
        {
                                         
        }
    }
}
