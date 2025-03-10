﻿using Prototype1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype1.Pieces
{
    class Pawn : Piece
    {
        public Pawn(PlayerColour colour) : base(colour)
        {
            base.type = 0;
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
                }

                // if hasnt moved and space 2 in front is empty, move valid
                if (y == 1 && !board.ContainsPiece(x, y + 2))
                {
                    validMoves.Add(new Move(position, new Position(x, y + 2), this));
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
                }
            }
            //black
            else
            {
                if (!board.ContainsPiece(x, y - 1)) // if square in front is empty
                {
                    // is valid
                    validMoves.Add(new Move(position, new Position(x, y - 1), this));
                }

                // if hasnt moved and space 2 in front is empty, move valid
                if (y == 6 && !board.ContainsPiece(x, y - 2))
                {
                    validMoves.Add(new Move(position, new Position(x, y - 2), this));
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
                }
            }

            return board.CullCheckMoves(validMoves, this.colour);
        }
    }
}
