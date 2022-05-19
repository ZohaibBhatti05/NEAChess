using ChessProto1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1.Pieces
{
    internal class Knight : Piece
    {
        public const int type = 2;
        public Knight(PlayerColor color) : base(color)
        {
        }
    }
}
