using Prototype3.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype3.Pieces
{
    class Bishop : Piece
    {
        public Bishop(PlayerColour colour) : base(colour)
        {
            base.type = 3;
            base.value = 3;
        }

        public override List<Move> GenerateLegalMoves(ChessBoard board, Position position) // bishop
        {
            return base.GenerateDiagonalMoves(board, position);
        }
    }
}
