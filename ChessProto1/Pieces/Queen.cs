using ChessProto1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1.Pieces
{
    internal class Queen : Piece
    {
        public const int type = 4;
        public Queen(PlayerColor color) : base(color)
        {
        }
    }
}
