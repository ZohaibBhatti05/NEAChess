using ChessProto1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1.Pieces
{
    internal class Piece
    {
        public readonly PlayerColor color;
        public int type;

        public Piece(PlayerColor color)
        {
            this.color = color;
        }
    }
}
