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
            // intital Minimax call
            MinMax(board, plyDepth, 0, (colour == PlayerColour.White));
            return bestMove;
        }

        // minimax algorithm
        private int MinMax(ChessBoard board, int plyDepth, int currentDepth, bool max)
        {
            // return board value at final depth
            if (currentDepth == plyDepth)
            {
                return board.BoardValue();
            }

            //List<Move> possibleMoves = board.AllPossibleMoves((max) ? PlayerColour.White : PlayerColour.Black);
            //if (possibleMoves.Count == 0)
            //{
            //    return board.BoardValue();
            //}

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
                    int newValue = MinMax(board, plyDepth, currentDepth, false);
                    if (newValue > value) // if better move found
                    {
                        value = newValue;
                        if (currentDepth == 1)
                        {
                            bestMove = move; // update best move
                        }
                    }
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
                    int newValue = MinMax(board, plyDepth, currentDepth, true);
                    if (newValue < value) // if better move found
                    {
                        value = newValue;
                        if (currentDepth == 1)
                        {
                            bestMove = move; // update best move
                        }
                    }
                    board.UndoMove(move); // undo the move
                }
                return value;
            }
        }
    }
}
