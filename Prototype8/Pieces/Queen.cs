using Prototype8.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prototype8.Pieces
{
    class Queen : Piece
    {
        public Queen(PlayerColour colour) : base(colour)
        {
            base.type = 4;
            base.value = 9;
            base.weight = 4;
        }

        public override List<Move> GenerateLegalMoves(ChessBoard board, Position position) // queen
        {
            // add both lists
            List<Move> orthogonal = base.GenerateOrthogonalMoves(board, position);
            List<Move> diagonal = base.GenerateDiagonalMoves(board, position);

            orthogonal.AddRange(diagonal); // append all elements of diagonal to orthogonal, return combined list
            return orthogonal;
        }
    }
}