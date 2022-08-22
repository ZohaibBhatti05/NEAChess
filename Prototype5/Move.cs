using Prototype5.Boards;
using Prototype5.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype5
{
    public class Move
    {
        public Piece movingPiece { get; private set; }
        public Piece takenPiece { get; private set; }
        public Position positionFrom { get; private set; }
        public Position positionTo { get; private set; }


        // initialise a standard non-taking move
        public Move(Position from, Position to, Piece moving)
        {
            movingPiece = moving;
            takenPiece = null;
            positionFrom = from;
            positionTo = to;
        }

        // initialise a standard taking move
        public Move(Position from, Position to, Piece moving, Piece taken)
        {
            movingPiece = moving;
            takenPiece = taken;
            positionFrom = from;
            positionTo = to;
        }

        // function returns the PGN notation for a move. Should be overwritten on promotion
        public string GetMoveName(ChessBoard board)
        {
            // hardcode castling name
            if (this is Castle)
            {
                if (positionTo.column == 2)
                {
                    return "O-O-O";
                }
                else
                {
                    return "O-O";
                }
            }

            // non-hardcoded names:
            string name = string.Empty;
            if (movingPiece is Pawn) // pawn block
            {
                name += (char)(positionFrom.column + 97); // get letter of file

                if (takenPiece != null)
                {
                    name += "x";
                    name += (char)(positionTo.column + 97);
                }
            }
            else // non pawn pieces
            {
                name += char.ToUpper(board.CharFromPiece(movingPiece)); // get piece letter
                if (takenPiece != null) // get taking symbol
                {
                    name += "x";
                }
                // get position to
                name += (char)(positionTo.column + 97); // get letter of file
            }

            name += (positionTo.row + 1).ToString(); // positions here are zero-based, add 1 to correct
            return name;
        }
    }

    class EnPassant : Move
    {
        public Position takenPosition { get; private set; }
        public EnPassant(Position from, Position to, Piece moving, Piece taken, Position takenPos) : base(from, to, moving, taken)
        {
            takenPosition = takenPos;
        }
    }

    class Castle : Move
    {
        public Position rookFrom { get; private set; }
        public Position rookTo { get; private set; }
        public Piece rook { get; private set; }

        public Castle(Position from, Position to, Piece king,
            Position rookFrom, Position rookTo, Piece rook) : base(from, to, king)
        {
            this.rookFrom = rookFrom;
            this.rookTo = rookTo;
            this.rook = rook;
        }
    }
}
