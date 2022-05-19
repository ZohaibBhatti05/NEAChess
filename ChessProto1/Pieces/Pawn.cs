using ChessProto1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1.Pieces
{
    internal class Pawn : Piece
    {
        public const int type = 0;
        public Pawn(PlayerColor color) : base(color)
        {
        }
    }
}
