using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype6.Boards
{
    internal class Antichess : ChessBoard
    {
        public Antichess(UpdateBoardGraphicsCallBack updateGraphicsCallback) : base(updateGraphicsCallback)
        {
        }



        public override void SelectCell(Position position)
        {
            if (winStatus == WinStatus.None || winStatus == WinStatus.WhiteCheck || winStatus == WinStatus.BlackCheck) // if noone won
            {

                // if there is no selected position
                if (selectedCell == null)
                {
                    // cant select what isnt there
                    if (!ContainsPiece(position))
                    {
                        return;
                    }
                    // cant select opponents pieces
                    else if (GetPiece(position).colour != currentTurn)
                    {
                        return;
                    }
                    else
                    {
                        // select piece
                        selectedCell = position;
                        selectedMoves = GetPiece(position).GenerateLegalMoves(this, position); // get valid moves
                        AllPossibleMoves(currentTurn); // generate all moves
                        CullNonCaptureMoves(base.allPossibleMoves); // antichess culling
                        graphicsCallBack.Invoke(false);
                        return;
                    }
                }

                // if there IS a selected piece
                else
                {
                    // clicking a piece:
                    if (ContainsPiece(position))
                    {
                        // of the same colour: select it
                        if (GetPiece(position).colour == currentTurn)
                        {
                            selectedCell = position; // select cell
                            selectedMoves = GetPiece(position).GenerateLegalMoves(this, position); // get valid moves
                            CullNonCaptureMoves(base.allPossibleMoves);
                            graphicsCallBack.Invoke(false);
                            return;
                        }

                        // of a different colour: try to make a move
                        else
                        {
                            foreach (Move move in selectedMoves) // if position is in a valid move, make the move
                            {
                                if ((position.column == move.positionTo.column) && (position.row == move.positionTo.row))
                                {
                                    MakeMove(move);
                                    AfterMove(move);
                                    return;
                                }
                            }
                        }
                    }

                    // if selecting an empty square
                    else
                    {
                        foreach (Move move in selectedMoves) // if position is in a valid move, make the move
                        {
                            if ((position.column == move.positionTo.column) && (position.row == move.positionTo.row))
                            {
                                MakeMove(move);
                                AfterMove(move);
                                return;
                            }
                        }
                    }
                }
            }
        }


        // method removes all non-capture moves if a caputure move exists
        private void CullNonCaptureMoves(List<Move> allPossibleMoves)
        {
            // for every move from the player colour
            foreach(Move move in allPossibleMoves)
            {
                if (move.takenPiece != null) // if any move is a capture, remove all non-captures from the list of moves
                {
                    selectedMoves.RemoveAll(move => move.takenPiece == null);
                    return;
                }
            }
        }

        // dont remove moves that result in check
        public override List<Move> CullCheckMoves(List<Move> moves, PlayerColour colour)
        {
            return moves;
        }

        protected override bool UpdateDrawConditions(Move move)
        {
            return false;
        }

        internal override void UpdateWinStatus(PlayerColour turn)
        {
            bool win = true;
            // count pieces on the board
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if (ContainsPiece(i, j))
                    {
                        if (GetPiece(i, j).colour == turn) // if the current player still has a piece
                        {
                            win = false; // player has not won
                        }
                    }
                }
            }
            if (win || AllPossibleMoves(turn).Count == 0) // all pieces taken or stalemated
            {
                winStatus = (currentTurn == PlayerColour.White ? WinStatus.WhiteWin : WinStatus.BlackWin);
                return;
            }

            winStatus = WinStatus.None;
        }

        // return the OPPOSITE of what it should
        public override int BoardValue(bool max, int depth)
        {
            return -base.BoardValue(max, depth);
        }
    }
}
