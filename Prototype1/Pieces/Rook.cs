﻿using Prototype1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype1.Pieces
{
    class Rook : Piece
    {
        public Rook(PlayerColour colour) : base(colour)
        {
            base.type = 1;
        }

        public override List<Move> GenerateLegalMoves(ChessBoard board, Position position)
        {
            return base.GenerateOrthogonalMoves(board, position);
        }
    }
}
