using ChessProto1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(PlayerColor color) : base(color)
        {
            base.type = 0;
        }

        public override List<Position> GenerateValidMoves(ChessBoard board, Position pos)
        {
            List<Position> moves = new List<Position>();

            if (color == PlayerColor.White && pos.row < 7) // WHITE
            {
                if (!board.HasPiece(new Position(pos.column, pos.row + 1))) // space above empty
                {
                    moves.Add(new Position(pos.column, pos.row + 1));

                    if (pos.row == 1)
                    {
                        if (!board.HasPiece(new Position(pos.column, pos.row + 2)))  // double forward :: empty and on rank 1
                        {
                            moves.Add(new Position(pos.column, pos.row + 2));
                        }
                    }
                }

                // take left
                if (pos.column > 0)
                {
                    Position posT = new Position(pos.column - 1, pos.row + 1);
                    if (board.HasPiece(posT)) // has piece
                    {
                        if (board.GetPiece(posT).color != this.color)
                        {
                            moves.Add(posT);
                        }
                    }
                }

                // take right
                if (pos.column < 7)
                {
                    Position posT = new Position(pos.column + 1, pos.row + 1);
                    if (board.HasPiece(posT)) // has piece
                    {
                        if (board.GetPiece(posT).color != this.color)
                        {
                            moves.Add(posT);
                        }
                    }
                }
            }
            else if (pos.row > 0)// BLACK
            {
                if (!board.HasPiece(new Position(pos.column, pos.row - 1))) // space above empty
                {
                    moves.Add(new Position(pos.column, pos.row - 1));

                    if (pos.row == 6)
                    {
                        if (!board.HasPiece(new Position(pos.column, pos.row - 2)))  // double forward :: empty and on rank 1
                        {
                            moves.Add(new Position(pos.column, pos.row - 2));
                        }
                    }
                }

                // take left
                if (pos.column > 0)
                {
                    Position posT = new Position(pos.column - 1, pos.row - 1);
                    if (board.HasPiece(posT)) // has piece
                    {
                        if (board.GetPiece(posT).color != this.color)
                        {
                            moves.Add(posT);
                        }
                    }
                }

                // take right
                if (pos.column < 7)
                {
                    Position posT = new Position(pos.column + 1, pos.row - 1);
                    if (board.HasPiece(posT)) // has piece
                    {
                        if (board.GetPiece(posT).color != this.color)
                        {
                            moves.Add(posT);
                        }
                    }
                }
            }


            return moves;
        }
    }
}
