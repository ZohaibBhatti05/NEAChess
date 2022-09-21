using Prototype8.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prototype8.Boards
{
    internal class ThreeCheck : ChessBoard
    {
        private int wCheckCount = 0;
        private int bCheckCount = 0;

        public ThreeCheck(UpdateBoardGraphicsCallBack updateGraphicsCallback) : base(updateGraphicsCallback)
        {

        }

        internal override void UpdateWinStatus(PlayerColour turn)
        {
            Position position = GetKingPosition(turn); // get the king
            King king = (GetPiece(position) as King);

            if (king.IsInCheck(this, position)) // if in check:
            {
                if (AllPossibleMoves(turn).Count == 0) // no possible moves
                {
                    winStatus = (turn == PlayerColour.White) ? WinStatus.WhiteMate : WinStatus.BlackMate; // checkmate
                    checkCell = GetKingPosition(currentTurn);
                }
                else // possible moves
                {
                    winStatus = (turn == PlayerColour.White) ? WinStatus.WhiteCheck : WinStatus.BlackCheck; // check (regular)
                    if (turn == PlayerColour.White)
                    {
                        wCheckCount++;
                    }
                    else
                    {
                        bCheckCount++;
                    }

                    if (bCheckCount == 3) // white wins
                    {
                        winStatus = WinStatus.WhiteWin;
                    }
                    else if (wCheckCount == 3) // black wins
                    {
                        winStatus = WinStatus.BlackWin;
                    }

                    checkCell = GetKingPosition(turn);
                }
            }
            else // not in check
            {
                if (AllPossibleMoves(turn).Count == 0) // no possible moves
                {
                    winStatus = WinStatus.Stalemate; // stalemate
                }
                else // possible moves
                {
                    winStatus = WinStatus.None; // noones winning
                    checkCell = null;
                }
            }
        }
    }
}