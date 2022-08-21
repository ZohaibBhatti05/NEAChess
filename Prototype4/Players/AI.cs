using Prototype4.Boards;
using Prototype4.Pieces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype4.Boards
{
    class AI : Player
    {
        private int nodes;

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
            nodes = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            bestMove = null;
            //optimise for when there's few pieces on the board

            //count pieces on the board

            // intital Minimax call
            AlphaBeta(board, plyDepth, (colour == PlayerColour.White), int.MinValue, int.MaxValue);

            Console.WriteLine();
            Console.WriteLine($"Ply {plyDepth} :: {nodes} nodes in {stopwatch.Elapsed.ToString()} seconds");
            return bestMove;
        }

        // minimax algorithm
        private int AlphaBeta(ChessBoard board, int currentDepth, bool max, int alpha, int beta)
        {
            List<Move> possibleMoves = ((max) ? board.AllPossibleMoves(PlayerColour.White) : board.AllPossibleMoves(PlayerColour.Black));

            // return board value at final depth
            if (currentDepth == 0 || possibleMoves.Count == 0)
            {
                nodes++;
                return board.BoardValue(max, plyDepth - currentDepth);
            }

            currentDepth--;
            int value;

            // white
            if (max)
            {
                value = int.MinValue;
                Move bestMoveNode = null;

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

                    int newValue = AlphaBeta(board, currentDepth, false, alpha, beta);

                    if (newValue > value) // if better move found
                    {
                        value = newValue;
                        if (currentDepth == plyDepth - 1)
                        {
                            bestMove = move; // update best move
                        }
                        bestMoveNode = move;
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
                Move bestMoveNode = null;
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
                    int newValue = AlphaBeta(board, currentDepth, true, alpha, beta);
                    if (newValue < value) // if better move found
                    {
                        value = newValue;
                        if (currentDepth == plyDepth - 1)
                        {
                            bestMove = move; // update best move
                        }
                        bestMoveNode = move;
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
