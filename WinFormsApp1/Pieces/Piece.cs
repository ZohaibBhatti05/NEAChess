using Prototype1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype1.Pieces
{
    class Piece
    {
        public PlayerColour colour { get; protected set; }

        public int type { get; protected set; }

        public Piece(PlayerColour colour)
        {
            this.colour = colour;
        }

        // takes board and position of moving piece
        public virtual List<Move> GenerateLegalMoves(ChessBoard board, Position position)
        {
            return null; // line should never be run, should always be overwritten
        }
    }
}
