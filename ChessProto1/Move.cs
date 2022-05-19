using ChessProto1.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1
{
    internal class Move
    {
        private bool isCastle;
        private bool isEnPassant;
        private bool isPromotion;

        private Piece movingPiece;
        private Piece takenPiece;

        public Move()
        {

        }

        private string GenerateMoveName()
        {
            return string.Empty;
        }
    }
}
