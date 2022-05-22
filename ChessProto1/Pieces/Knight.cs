using ChessProto1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1.Pieces
{
    public class Knight : Piece
    {
        private readonly (int, int)[] moveArray =
        {
            (-1, 2) , (1, 2) , (2, 1) , (2, -1) ,
            (1, -2) , (-1, -2) , (-2, -1) , (-2, 1)
        };

        public Knight(PlayerColor color) : base(color)
        {
            base.type = 2;
        }

        public override List<Position> GenerateValidMoves(ChessBoard board, Position pos)
        {
            return base.GetArrayMoves(board, pos, moveArray);
        }
    }
}
