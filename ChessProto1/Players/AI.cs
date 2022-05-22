using ChessProto1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1.Players
{
    public class AI : Player
    {
        private int plyDepth;

        private Position bestPositionF;
        private Position bestPositionT;

        public AI(int plyDepth)
        {
            this.plyDepth = plyDepth;
        }

        public void MakeMove(ChessBoard board)
        {
            MinMax(board, 0, false, int.MinValue, int.MaxValue);
            board.MakeMove(bestPositionF, bestPositionT);
        }

        private int MinMax(ChessBoard board, int currentDepth, bool max, int alpha, int beta)
        {
            int value = 0;
            if (currentDepth == plyDepth)
            {
                return board.GetBoardValue();
            }
            else
            {
                currentDepth++; // moved 1 ply down

                if (max)    // WHITE
                {
                    value = int.MinValue;
                    foreach((Position posF, Position posT) in board.AllPossibleMoves(PlayerColor.White)) // for every move for white
                    {
                        board.MakeMove(posF, posT); // perform move

                        int valueBefore = value;    // store copy of value
                        value = Math.Max(value, MinMax(board, currentDepth, false, alpha, beta)); // recursion call

                        if (value != valueBefore) // if value has improved
                        {
                            bestPositionF = posF; bestPositionT = posT; // update best move
                        }

                        if (value >= beta)
                        {
                            break;  // beta cutoff
                        }
                        alpha = Math.Max(value, alpha);
                        board.UndoLastMove();   // undo move
                    }
                    return value;
                }
                else
                {
                    value = int.MaxValue;
                    foreach ((Position posF, Position posT) in board.AllPossibleMoves(PlayerColor.Black)) // for every move for white
                    {
                        board.MakeMove(posF, posT); // perform move

                        int valueBefore = value;    // store copy of value
                        value = Math.Min(value, MinMax(board, currentDepth, false, alpha, beta)); // recursion call

                        if (value != valueBefore) // if value has improved
                        {
                            bestPositionF = posF; bestPositionT = posT; // update best move
                        }

                        if (value <= alpha)
                        {
                            break;  // alpha cutoff
                        }
                        beta = Math.Min(value, alpha);
                        board.UndoLastMove();   // undo move
                    }
                    return value;
                }
            }
        }
    }
}
