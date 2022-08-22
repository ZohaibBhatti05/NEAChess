using Prototype5.Boards;
using Prototype5.Pieces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype5.Boards
{
    class AI : Player
    {
        Move[][] killerMoves;
        const int KILLER_MOVE_COUNT = 2;

        private int nodes;

        private int plyDepth;
        private PlayerColour colour;
        private Move bestMove;

        public AI(int plyDepth, PlayerColour colour) : base()
        {
            this.plyDepth = plyDepth;
            this.colour = colour;

            killerMoves = new Move[plyDepth][];
            for (int i = 0; i < plyDepth; i++)
            {
                killerMoves[i] = new Move[KILLER_MOVE_COUNT];
            }
        }

        // method run by board when computer needs to make a move
        public Move MakeMove(ChessBoard board)
        {
            nodes = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            bestMove = null;

            // intital Minimax call
            AlphaBeta(board, plyDepth, (colour == PlayerColour.White), int.MinValue, int.MaxValue);

            Console.WriteLine();
            Console.WriteLine($"Ply {plyDepth} :: {nodes} nodes in {stopwatch.Elapsed.ToString()} seconds");
            return bestMove;
        }

        // minimax algorithm
        private int AlphaBeta(ChessBoard board, int currentDepth, bool max, int alpha, int beta)
        {
            nodes++;
            // return board value at final depth
            if (currentDepth == 0)
            {
                return board.BoardValue(max, plyDepth - currentDepth);
            }

            List<Move> possibleMoves = ((max) ? board.AllPossibleMoves(PlayerColour.White) : board.AllPossibleMoves(PlayerColour.Black));

            if (possibleMoves.Count == 0)
            {
                return board.BoardValue(max, plyDepth - currentDepth);
            }

            OrderMoves(possibleMoves, currentDepth);

            currentDepth--;
            int value;

            // white
            if (max)
            {
                value = int.MinValue;
                Move bestMoveNode = null;

                // for every possible move
                foreach (Move move in possibleMoves)
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

                        AddKillerMove(currentDepth, move);

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

        // inserts a new killer move at the specified depth
        private void AddKillerMove(int depth, Move move)
        {
            for (int i = killerMoves[depth].Length - 2; i >=0; i--)
            {
                killerMoves[depth][i + 1] = killerMoves[depth][i]; // move all moves over to the right, insert new move at the start
            }
            killerMoves[depth][0] = move;
        }

        // orders the move list before recursion starts
        private void OrderMoves(List<Move> moves, int depth)
        {
            // killer heuristic

            int foundKiller = 0;
            // sort killer moves to be evaluated first
            for (int i = 0; i < moves.Count - 1; i++)
            {
                if (killerMoves[depth - 1].Contains(moves[i])) // if move is killer move, insert at front
                {
                    moves.Insert(0, moves[i]); // put move at front, remove duplicate
                    moves.RemoveAt(i + 1);
                    foundKiller++;
                    if (foundKiller == KILLER_MOVE_COUNT) // if all killer moves found, ignore the rest of the list
                    {
                        break;
                    }
                }
            }
        }
    }
}
