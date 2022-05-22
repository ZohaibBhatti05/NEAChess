using ChessProto1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1.Pieces
{
    public class Piece
    {
        public readonly PlayerColor color;
        public int type;

        public Piece(PlayerColor color)
        {
            this.color = color;
        }

        public virtual List<Position> GenerateValidMoves(ChessBoard board, Position pos)
        {
            return new List<Position>();
        }

        protected List<Position> GetHorizontalMoves(ChessBoard board, Position pos) // this is just the rook movement logic
        {
            List<Position> moves = new List<Position>();

            // left
            if (pos.column > 0)
            {
                for (int k = pos.column - 1; k >= 0; k--)
                {
                    Position posT = new Position(k, pos.row);
                    // has piece
                    if (board.HasPiece(posT))
                    {
                        // same color
                        if (board.GetPiece(posT).color == color)
                        {
                            break;
                        }
                        // other color
                        else
                        {
                            moves.Add(posT); break;
                        }
                    }
                    //empty
                    moves.Add(posT);
                }
            }

            // right
            if (pos.column < 7)
            {
                for (int k = pos.column + 1; k <= 7; k++)
                {
                    Position posT = new Position(k, pos.row);
                    // has piece
                    if (board.HasPiece(posT))
                    {
                        // same color
                        if (board.GetPiece(posT).color == color)
                        {
                            break;
                        }
                        // other color
                        else
                        {
                            moves.Add(posT); break;
                        }
                    }
                    //empty
                    moves.Add(posT);
                }
            }

            // down
            if (pos.row > 0)
            {
                for (int k = pos.row - 1; k >= 0; k--)
                {
                    Position posT = new Position(pos.column, k);
                    // has piece
                    if (board.HasPiece(posT))
                    {
                        // same color
                        if (board.GetPiece(posT).color == color)
                        {
                            break;
                        }
                        // other color
                        else
                        {
                            moves.Add(posT); break;
                        }
                    }
                    //empty
                    moves.Add(posT);
                }
            }

            // up
            if (pos.row < 7)
            {
                for (int k = pos.row + 1; k <= 7; k++)
                {
                    Position posT = new Position(pos.column, k);
                    // has piece
                    if (board.HasPiece(posT))
                    {
                        // same color
                        if (board.GetPiece(posT).color == color)
                        {
                            break;
                        }
                        // other color
                        else
                        {
                            moves.Add(posT); break;
                        }
                    }
                    //empty
                    moves.Add(posT);
                }
            }

            return moves;
        }

        protected List<Position> GetDiagonalMoves(ChessBoard board, Position pos) // this is just the bishop movement logic
        {
            List<Position> moves = new List<Position>();

            // down left
            if (pos.column >  0 && pos.row > 0)
            {
                for (int k = 1; k <= Math.Min(pos.column, pos.row); k++)
                {
                    Position posT = new Position(pos.column - k, pos.row - k);
                    // has piece
                    if (board.HasPiece(posT))
                    {
                        // same color
                        if (board.GetPiece(posT).color == color)
                        {
                            break;
                        }
                        // other color
                        else
                        {
                            moves.Add(posT); break;
                        }
                    }
                    //empty
                    moves.Add(posT);
                }
            }

            // down right
            if (pos.column < 7 && pos.row > 0)
            {
                for (int k = 1; k <= Math.Min(7 - pos.column, pos.row); k++)
                {
                    Position posT = new Position(pos.column + k, pos.row - k);
                    // has piece
                    if (board.HasPiece(posT))
                    {
                        // same color
                        if (board.GetPiece(posT).color == color)
                        {
                            break;
                        }
                        // other color
                        else
                        {
                            moves.Add(posT); break;
                        }
                    }
                    //empty
                    moves.Add(posT);
                }
            }

            // up left
            if (pos.column > 0 && pos.row < 7)
            {
                for (int k = 1; k <= Math.Min(pos.column, 7 - pos.row); k++)
                {
                    Position posT = new Position(pos.column - k, pos.row + k);
                    // has piece
                    if (board.HasPiece(posT))
                    {
                        // same color
                        if (board.GetPiece(posT).color == color)
                        {
                            break;
                        }
                        // other color
                        else
                        {
                            moves.Add(posT); break;
                        }
                    }
                    //empty
                    moves.Add(posT);
                }
            }

            // up right
            if (pos.column < 7 && pos.row < 7)
            {
                for (int k = 1; k <= Math.Min(7 - pos.column, 7 - pos.row); k++)
                {
                    Position posT = new Position(pos.column + k, pos.row + k);
                    // has piece
                    if (board.HasPiece(posT))
                    {
                        // same color
                        if (board.GetPiece(posT).color == color)
                        {
                            break;
                        }
                        // other color
                        else
                        {
                            moves.Add(posT); break;
                        }
                    }
                    //empty
                    moves.Add(posT);
                }
            }

            return moves;
        }

        protected List<Position> GetArrayMoves(ChessBoard board, Position pos, (int, int)[] moveArray)
        {
            List<Position> moves = new List<Position>();

            foreach ((int, int) move in moveArray)
            {
                int colT = pos.column + move.Item1;
                int rowT = pos.row + move.Item2;

                if (colT < 0 || colT > 7 || rowT < 0 || rowT > 7) { continue; }
                else
                {
                    Position posT = new Position(colT, rowT);
                    // has piece
                    if (board.HasPiece(posT))
                    {
                        // same color
                        if (board.GetPiece(posT).color == color)
                        {
                            continue;
                        }
                        else
                        {
                            moves.Add(posT);
                        }
                    }
                    else
                    {
                        moves.Add(posT);
                    }
                }
            }

            return moves;
        }

        // perform move
        // // does it result in check?
        // if so, kill it
        protected List<Position> CullCheckMoves(List<Position> positions)
        {
            List<Position> newPositions = new List<Position>();
            return newPositions;
        }
    }
}
