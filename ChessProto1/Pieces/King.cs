using ChessProto1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1.Pieces
{
    internal class King : Piece
    {
        public const int type = 5;
        public King(PlayerColor color) : base(color)
        {
        }
    }
}
