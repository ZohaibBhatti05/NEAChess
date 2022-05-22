using ChessProto1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1.Pieces
{
    public class King : Piece
    {
        private readonly (int, int)[] moveArray =
        {
            (-1, 1), (0, 1), (1, 1),
            (-1, 0),          (1, 0),
            (-1, -1), (0, -1), (1, -1),
        };

        public King(PlayerColor color) : base(color)
        {
            base.type = 5;
        }

        public override List<Position> GenerateValidMoves(ChessBoard board, Position pos)
        {
            return base.GetArrayMoves(board, pos, moveArray);
        }
    }
}
