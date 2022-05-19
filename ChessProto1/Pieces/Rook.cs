using ChessProto1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1.Pieces
{
    internal class Rook : Piece
    {
        public const int type = 1;
        public Rook(PlayerColor color) : base(color)
        {
        }
    }
}
