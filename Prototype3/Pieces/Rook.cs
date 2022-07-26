using Prototype3.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype3.Pieces
{
    class Rook : Piece
    {

        public Rook(PlayerColour colour) : base(colour)
        {
            base.type = 1;
            base.value = 5;
            base.canCastle = true;
        }

        public override List<Move> GenerateLegalMoves(ChessBoard board, Position position)
        {
            return base.GenerateOrthogonalMoves(board, position);
        }
    }
}
