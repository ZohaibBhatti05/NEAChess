using Prototype2.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype2.Pieces
{
    class Pawn : Piece
    {
        public bool canBeEnPassanted { get; private set; }
        // encapsulation method
        public void SetEnPassant(bool value)
        {
            canBeEnPassanted = value;
        }

        public Pawn(PlayerColour colour) : base(colour)
        {
            base.type = 0;
            base.value = 1;
            canBeEnPassanted = false;
        }

        public override List<Move> GenerateLegalMoves(ChessBoard board, Position position)
        {
            List<Move> validMoves = new List<Move>();

            int x = position.column; int y = position.row; // easier reference to x / y than column / row

            // white
            if (this.colour == PlayerColour.White)
            {
                if (!board.ContainsPiece(x, y + 1)) // if square in front is empty
                {
                    // is valid
                    validMoves.Add(new Move(position, new Position(x, y + 1), this));
                    // if hasnt moved and space 2 in front is empty, move valid
                    if (y == 1 && !board.ContainsPiece(x, y + 2))
                    {
                        validMoves.Add(new Move(position, new Position(x, y + 2), this));
                    }
                }

                // taking block :: white
                if (x > 0)
                {
                    if (board.ContainsPiece(x - 1, y + 1)) // left
                    {
                        if (board.GetPiece(x - 1, y + 1).colour != this.colour) // if piece diagonal occupied by opposing colour, add the move
                        {
                            validMoves.Add(new Move(position, new Position(x - 1, y + 1), this, board.GetPiece(x - 1, y + 1)));
                        }
                    }

                    // enpassant left
                    if (y == 4)
                    {
                        if (board.ContainsPiece(x - 1, y))
                        {
                            Piece piece = board.GetPiece(x - 1, y);
                            if (piece is Pawn)
                            {
                                if ((piece as Pawn).canBeEnPassanted) // no need to check if cell above pawn is empty: its impossible here
                                {
                                    validMoves.Add(new EnPassant(position, new Position(x - 1, y + 1), this, piece, new Position(x - 1, y)));
                                }
                            }
                        }
                    }
                }
                if (x < 7)
                {
                    if (board.ContainsPiece(x + 1, y + 1)) // right
                    {
                        if (board.GetPiece(x + 1, y + 1).colour != this.colour)
                        {
                            validMoves.Add(new Move(position, new Position(x + 1, y + 1), this, board.GetPiece(x + 1, y + 1)));
                        }
                    }

                    // enpassant right
                    if (y == 4)
                    {
                        if (board.ContainsPiece(x + 1, y))
                        {
                            Piece piece = board.GetPiece(x + 1, y);
                            if (piece is Pawn)
                            {
                                if ((piece as Pawn).canBeEnPassanted) // no need to check if cell above pawn is empty: its impossible here
                                {
                                    validMoves.Add(new EnPassant(position, new Position(x + 1, y + 1), this, piece, new Position(x + 1, y)));
                                }
                            }
                        }
                    }
                }
            }
            //black
            else
            {
                if (!board.ContainsPiece(x, y - 1)) // if square in front is empty
                {
                    // is valid
                    validMoves.Add(new Move(position, new Position(x, y - 1), this));
                    // if hasnt moved and space 2 in front is empty, move valid
                    if (y == 6 && !board.ContainsPiece(x, y - 2))
                    {
                        validMoves.Add(new Move(position, new Position(x, y - 2), this));
                    }
                }

                // taking block :: black
                if (x > 0)
                {
                    if (board.ContainsPiece(x - 1, y - 1)) // left
                    {
                        if (board.GetPiece(x - 1, y - 1).colour != this.colour) // if piece diagonal occupied by opposing colour, add the move
                        {
                            validMoves.Add(new Move(position, new Position(x - 1, y - 1), this, board.GetPiece(x - 1, y - 1)));
                        }
                    }

                    // enpassant left
                    if (y == 3)
                    {
                        if (board.ContainsPiece(x - 1, y))
                        {
                            Piece piece = board.GetPiece(x - 1, y);
                            if (piece is Pawn)
                            {
                                if ((piece as Pawn).canBeEnPassanted) // no need to check if cell above pawn is empty: its impossible here
                                {
                                    validMoves.Add(new EnPassant(position, new Position(x - 1, y - 1), this, piece, new Position(x - 1, y)));
                                }
                            }
                        }
                    }

                }
                if (x < 7)
                {
                    if (board.ContainsPiece(x + 1, y - 1)) // right
                    {
                        if (board.GetPiece(x + 1, y - 1).colour != this.colour)
                        {
                            validMoves.Add(new Move(position, new Position(x + 1, y - 1), this, board.GetPiece(x + 1, y - 1)));
                        }
                    }

                    // enpassant right
                    if (y == 3)
                    {
                        if (board.ContainsPiece(x + 1, y))
                        {
                            Piece piece = board.GetPiece(x + 1, y);
                            if (piece is Pawn)
                            {
                                if ((piece as Pawn).canBeEnPassanted) // no need to check if cell above pawn is empty: its impossible here
                                {
                                    validMoves.Add(new EnPassant(position, new Position(x + 1, y - 1), this, piece, new Position(x + 1, y)));
                                }
                            }
                        }
                    }
                }
            }

            return board.CullCheckMoves(validMoves, this.colour);
        }
    }
}
