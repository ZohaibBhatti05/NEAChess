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
        private int qNodes;

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
            nodes = 0; qNodes = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            bestMove = null;

            // intital Minimax call
            AlphaBeta(board, plyDepth, (colour == PlayerColour.White), int.MinValue, int.MaxValue);

            Console.WriteLine();
            Console.WriteLine($"Ply {plyDepth} :: {nodes} nodes :: {qNodes} Q-Nodes in {stopwatch.Elapsed.ToString()} seconds");

            if (bestMove == null)
            {
                bestMove = board.AllPossibleMoves(colour)[0];
            }

            return bestMove;
        }

        // minimax algorithm
        private int AlphaBeta(ChessBoard board, int currentDepth, bool max, int alpha, int beta)
        {
            int value;
            nodes++;
            // return board value at final depth
            if (currentDepth == 0)
            {
                return Quiescence(board, !max, 0, -beta, -alpha);
                //return board.BoardValue(max, plyDepth - currentDepth);
            }

            // null move
            if (currentDepth == plyDepth - 1)
            {
                if (!(board.winStatus == WinStatus.WhiteCheck || board.winStatus == WinStatus.BlackCheck) && plyDepth > 3) // if not in check and on base nodes
                {
                    value = AlphaBeta(board, plyDepth - 3, !max, alpha, 1 - beta);

                    if (value >= beta) // beta cutoff => return early
                    {
                        return value;
                    }
                }
            }

            // generate moves
            List<Move> possibleMoves = ((max) ? board.AllPossibleMoves(PlayerColour.White) : board.AllPossibleMoves(PlayerColour.Black));
            if (possibleMoves.Count == 0)
            {
                return board.BoardValue(max, plyDepth - currentDepth);
            }

            OrderMoves(possibleMoves, currentDepth);

            currentDepth--;

            // white
            if (max)
            {
                value = int.MinValue;
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

        private const int QUIESCENCE_MAX_DEPTH = 4;

        // quiescence search
        private int Quiescence(ChessBoard board, bool max, int qDepth, int alpha, int beta)
        {
            // "stand pat" state
            int value = board.BoardValue(max, qDepth);
            if (value >= beta || qDepth == QUIESCENCE_MAX_DEPTH) // beta cutoff or depth cutoff
            {
                return value;
            }

            //delta pruning
            if (value < alpha - board.PIECE_MATERIAL_VALUES_END[4])
            {
                return alpha;
            }

            if (value > alpha) // increase alpha => ignore lower values
            {
                alpha = value;
            }

            //
            // recursion

            qNodes++; // debug

            List<Move> possibleMoves = ((max) ? board.AllPossibleMoves(PlayerColour.White) : board.AllPossibleMoves(PlayerColour.Black));

            if (possibleMoves.Count == 0) // terminate at mate
            {
                return board.BoardValue(max, qDepth);
            }

            // sort list
            possibleMoves = possibleMoves.OrderByDescending(move => ((move.takenPiece is null ? -100 : move.takenPiece.value) - move.movingPiece.value)).ToList();

            foreach (Move move in possibleMoves)
            {
                if ((move.takenPiece is null && !(board.winStatus == WinStatus.WhiteCheck || board.winStatus == WinStatus.BlackCheck)) || move.takenPiece is King)
                {
                    continue; // ignore quiescent moves
                }
                board.MakeMove(move);

                if (move.movingPiece is Pawn && move.positionTo.row == 7) // promote white
                {
                    board.AddPiece(new Queen(PlayerColour.White), move.positionTo);
                }
                else if (move.movingPiece is Pawn && move.positionTo.row == 0) // promote black
                {
                    board.AddPiece(new Queen(PlayerColour.Black), move.positionTo);
                }

                board.UpdateWinStatus((max ? PlayerColour.Black : PlayerColour.White)); // update check/mate

                value = -Quiescence(board, !max, qDepth + 1, -beta, -alpha); // recursion call
                board.UndoMove(move);

                if (value >= beta) // beta cutoff
                {
                    return beta;
                }
                else if (value > alpha) // update alpha
                {
                    alpha = value;
                }
            }

            return alpha;
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
