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

        // function returns list of moves that
        protected List<Move> GenerateOrthogonalMoves(ChessBoard board, Position position)
        {
            List<Move> validMoves = new List<Move>();
            // left
            for (int x = position.column - 1; x >= 0; x--)
            {
                // get new position
                Position positionTo = new Position(x, position.row);
                (bool isValid, bool proceed) = IsSlidingMoveValid(board, positionTo);   // get state of move
                if (isValid) {
                    validMoves.Add(new Move(position, positionTo, this, board.GetPiece(positionTo)));   // if valid, add
                }
                if (!proceed) { // if takes or land on piece, discontinue current loop
                    break;
                }
            }
            // right
            for (int x = position.column + 1; x <= 7; x++)
            {
                Position positionTo = new Position(x, position.row);
                (bool isValid, bool proceed) = IsSlidingMoveValid(board, positionTo);
                if (isValid)
                {
                    validMoves.Add(new Move(position, positionTo, this, board.GetPiece(positionTo)));
                }
                if (!proceed) { break; }
            }
            // down
            for (int y = position.row - 1; y >= 0; y--)
            {
                Position positionTo = new Position(position.column, y);
                (bool isValid, bool proceed) = IsSlidingMoveValid(board, positionTo);
                if (isValid)
                {
                    validMoves.Add(new Move(position, positionTo, this, board.GetPiece(positionTo)));
                }
                if (!proceed) { break; }
            }
            // up
            for (int y = position.row + 1; y <= 7; y++)
            {
                Position positionTo = new Position(position.column, y);
                (bool isValid, bool proceed) = IsSlidingMoveValid(board, positionTo);
                if (isValid)
                {
                    validMoves.Add(new Move(position, positionTo, this, board.GetPiece(positionTo)));
                }
                if (!proceed) { break; }
            }
            return validMoves;
        }

        protected List<Move> GenerateDiagonalMoves(ChessBoard board, Position position)
        {
            List<Move> validMoves = new List<Move>();

            int x = position.column;
            int y = position.row;

            for (int offset = 1; offset <= Math.Min(x, y); offset++)
            { // down left
                Position positionTo = new Position(x - offset, y - offset);
                (bool isValid, bool proceed) = IsSlidingMoveValid(board, positionTo);
                if (isValid)
                {
                    validMoves.Add(new Move(position, positionTo, this, board.GetPiece(position)));
                }
                if (!proceed) { break; }
            }

            for (int offset = 1; offset <= Math.Min(7 - x, y); offset++)
            { // down right
                Position positionTo = new Position(x + offset, y - offset);
                (bool isValid, bool proceed) = IsSlidingMoveValid(board, positionTo);
                if (isValid)
                {
                    validMoves.Add(new Move(position, positionTo, this, board.GetPiece(position)));
                }
                if (!proceed) { break; }
            }

            for (int offset = 1; offset <= Math.Min(x, 7 - y); offset++)
            { // up left
                Position positionTo = new Position(x - offset, y + offset);
                (bool isValid, bool proceed) = IsSlidingMoveValid(board, positionTo);
                if (isValid)
                {
                    validMoves.Add(new Move(position, positionTo, this, board.GetPiece(position)));
                }
                if (!proceed) { break; }
            }

            for (int offset = 1; offset <= Math.Min(7 - x, 7 - y); offset++)
            { // up right
                Position positionTo = new Position(x + offset, y + offset);
                (bool isValid, bool proceed) = IsSlidingMoveValid(board, positionTo);
                if (isValid)
                {
                    validMoves.Add(new Move(position, positionTo, this, board.GetPiece(position)));
                }
                if (!proceed) { break; }
            }
            return validMoves;
        }

        // returns whether a sliding move is valid and whether moves after should be considered
        protected (bool, bool) IsSlidingMoveValid(ChessBoard board, Position position)
        {
            // empty square: valid : continue
            if (!board.ContainsPiece(position))
            {
                return (true, true);
            }
            // opposing piece : valid : discontinue
            else if (board.GetPiece(position).colour != this.colour)
            {
                return (true, false);
            }
            else
            // same colour piece : invalid : discontinue
            {
                return (false, false);
            }
        }

        protected List<Move> GenerateArrayMoves(ChessBoard board, Position position, (int, int)[] moves)
        {
            List<Move> validMoves = new List<Move>();

            return validMoves;
        }
    }
}
