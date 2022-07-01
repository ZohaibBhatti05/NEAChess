using Prototype2.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype2.Pieces
{
    class Knight : Piece
    {
        private readonly (int, int)[] moveArray =
        {
            (-1, 2), (1, 2), (2, 1), (2, -1),
            (1, -2), (-1, -2), (-2, -1), (-2, 1),
        };  // readonly because const throws an error

        public Knight(PlayerColour colour) : base(colour)
        {
            base.type = 2;
        }

        public override List<Move> GenerateLegalMoves(ChessBoard board, Position position)
        {
            return base.GenerateArrayMoves(board, position, moveArray);
        }
    }
}
