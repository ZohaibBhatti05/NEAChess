using Prototype4.Boards;
using Prototype4.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype4.Boards
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
            bestMove = null;
            //optimise for when there's few pieces on the board

            //count pieces on the board

            //int count = 0;
            //int wCount = 0;
            //int bCount = 0;
            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        if (board.ContainsPiece(i, j))
            //        {
            //            //if (!(board.GetPiece(i, j) is Pawn))
            //            //{
            //            //    count++;
            //            //}
            //            count++;
            //            if (board.GetPiece(i, j).colour == PlayerColour.White)
            //            {
            //                wCount++;
            //            }
            //            else
            //            {
            //                bCount++;
            //            }
            //        }
            //    }
            //}
            //if (wCount < 3 && count < 6)
            //{
            //    plyDepth = 6;
            //}

            // intital Minimax call
            AlphaBeta(board, plyDepth, 0, (colour == PlayerColour.White), int.MinValue, int.MaxValue);
            
            //if (bestMove == null && board.winStatus != ((colour == PlayerColour.White) ? WinStatus.WhiteMate : WinStatus.BlackMate))
            //{
            //    bestMove = board.AllPossibleMoves(colour)[0];
            //}

            return bestMove;
        }

        // minimax algorithm
        private int AlphaBeta(ChessBoard board, int plyDepth, int currentDepth, bool max, int alpha, int beta)
        {
            List<Move> possibleMoves = ((max) ? board.AllPossibleMoves(PlayerColour.White) : board.AllPossibleMoves(PlayerColour.Black));

            // return board value at final depth
            if (currentDepth == plyDepth || possibleMoves.Count == 0)
            {
                return board.BoardValue(max, currentDepth);
            }

            currentDepth++;
            int value;

            // white
            if (max)
            {
                value = int.MinValue;
                // for every possible move
                foreach(Move move in possibleMoves)
                {
                    board.MakeMove(move); // make the move

                    if (move.movingPiece is Pawn && move.positionTo.row == 7)
                    {
                        //continue;
                        board.AddPiece(new Queen(PlayerColour.White), move.positionTo);
                    }

                    board.UpdateWinStatus(PlayerColour.Black);

                    int newValue = AlphaBeta(board, plyDepth, currentDepth, false, alpha, beta);

                    if (newValue > value) // if better move found
                    {
                        value = newValue;
                        if (currentDepth == 1)
                        {
                            bestMove = move; // update best move
                        }
                    }

                    // beta cutoff
                    if (value >= beta)
                    {
                        board.UndoMove(move);
                        break;
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
                foreach (Move move in possibleMoves)
                {                    
                    board.MakeMove(move); // make the move
                    if (move.movingPiece is Pawn && move.positionTo.row == 0)
                    {
                        board.AddPiece(new Queen(PlayerColour.Black), move.positionTo);
                        //continue;
                    }

                    board.UpdateWinStatus(PlayerColour.White);
                    int newValue = AlphaBeta(board, plyDepth, currentDepth, true, alpha, beta);
                    if (newValue < value) // if better move found
                    {
                        value = newValue;
                        if (currentDepth == 1)
                        {
                            bestMove = move; // update best move
                        }

                    }

                    // alpha cutoff
                    if (value <= alpha)
                    {
                        board.UndoMove(move);
                        break;
                    }

                    beta = Math.Min(value, beta);
                    board.UndoMove(move); // undo the move
                }
                return value;
            }
        }
    }
}
