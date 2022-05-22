using ChessProto1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PlayerColor color) : base(color)
        {
            base.type = 3;
        }

        public override List<Position> GenerateValidMoves(ChessBoard board, Position pos)
        {
            return base.GetDiagonalMoves(board, pos);
        }
    }
}
