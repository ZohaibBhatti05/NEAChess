using Prototype2.Boards;
using Prototype2.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype2.Boards
{
    class AI : Player
    {
        private int plyDepth;
        private PlayerColour colour;
        private Move bestMove;

        public AI(int plyDepth, PlayerColour colour) : base()
        {
            this.plyDepth = plyDepth;
            this.colour = colour;
        }

        // method run by board when computer needs to make a move
        public Move MakeMove(ChessBoard board)
        {
            // optimise for when there's few pieces on the board
            // count pieces on the board
            int count = 0;
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if (board.ContainsPiece(i, j))
                    {
                        if (!(board.GetPiece(i, j) is Pawn))
                        {
                            count++;
                        }
                    }
                }
            }

            if (count < 10) { plyDepth = 7; }
            if (count < 5) { plyDepth = 10; } // think ahead more as game progresses

            // intital Minimax call
            AlphaBeta(board, plyDepth, 0, (colour == PlayerColour.White), int.MinValue, int.MaxValue);
            return bestMove;
        }

        // minimax algorithm
        private int AlphaBeta(ChessBoard board, int plyDepth, int currentDepth, bool max, int alpha, int beta)
        {
            List<Move> possibleMoves = ((max) ? board.AllPossibleMoves(PlayerColour.White) : board.AllPossibleMoves(PlayerColour.Black));

            // return board value at final depth
            if (currentDepth == plyDepth || possibleMoves.Count == 0)
            {
                return board.BoardValue();
            }

            currentDepth++;
            int value;

            // white
            if (max)
            {
                value = int.MinValue;
                // for every possible move
                foreach(Move move in board.AllPossibleMoves(PlayerColour.White))
                {
                    if (move.movingPiece is Pawn && move.positionTo.row == 7)
                    {
                        continue; // ignore promotion
                    }
                    board.MakeMove(move); // make the move
                    board.UpdateWinStatus();
                    int newValue = AlphaBeta(board, plyDepth, currentDepth, false, alpha, beta);

                    if (newValue > value) // if better move found
                    {
                        value = newValue;
                        if (currentDepth == 1)
                        {
                            bestMove = move; // update best move
                        }

                        // beta cutoff
                        if (newValue >= beta)
                        {
                            board.UndoMove(move);
                            break;
                        }
                    }
                    alpha = Math.Max(value, alpha);
                    board.UndoMove(move); // undo the move
                }
                return value;
            }
            // black
            else
            {
                value = int.MaxValue;
                // for every possible move
                foreach (Move move in board.AllPossibleMoves(PlayerColour.Black))
                {
                    if (move.movingPiece is Pawn && move.positionTo.row == 0)
                    {
                        continue; // ignore promotion
                    }
                    board.MakeMove(move); // make the move
                    board.UpdateWinStatus();
                    int newValue = AlphaBeta(board, plyDepth, currentDepth, true, alpha, beta);
                    if (newValue < value) // if better move found
                    {
                        value = newValue;
                        if (currentDepth == 1)
                        {
                            bestMove = move; // update best move
                        }

                        // alpha cutoff
                        if (newValue <= alpha)
                        {
                            board.UndoMove(move);
                            break;
                        }
                    }
                    beta = Math.Min(value, beta);
                    board.UndoMove(move); // undo the move
                }
                return value;
            }
        }
    }
}
