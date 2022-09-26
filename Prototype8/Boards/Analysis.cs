using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Prototype8.Boards
{
    internal class Analysis : ChessBoard
    {
        public Analysis(UpdateBoardGraphicsCallBack updateGraphicsCallback) : base(updateGraphicsCallback)
        {

        }

        private int deviatingMoveCount = 0;

        private AI analysisAI = new AI(3, 4, PlayerColour.Black, true, false);

        private List<string> gameMoveNameHistory = new List<string>();

        public string analysisMove { get; private set; }

        public void SetupAnalysis(string FEN, string PGN)
        {
            base.PositionFromFEN(FEN);

            gameMoveNameHistory = PGN.Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries).ToList();
            //base.moveNameHistory = gameMoveNameHistory;
        }



        // function replays the move made in the given game
        public void RedoNextMove()
        {
            if (deviatingMoveCount > 0)
            {
                return; // dont run code if deviating from recorded moves
            }

            List<Move> moves = AllPossibleMoves(currentTurn); // get all moves

            foreach (Move move in moves)
            {
                string name = move.GetMoveName(this);
                if (name == Regex.Replace(gameMoveNameHistory[moveNameHistory.Count], "[#+]", "")) // if move matches, make it
                {
                    MakeMove(move);
                    AfterMove(move);
                }
            }
        }

        // get pvs from ai after a move is made
        protected override void AfterMove(Move move)
        {
            base.AfterMove(move);
            analysisMove = analysisAI.MakeMove(this, currentTurn).GetMoveName(this); // get best move found
            graphicsCallBack.Invoke(false);
        }

        // undoes the last move
        public override void UndoLastMove()
        {
            if (deviatingMoveCount > 0)
            {
                deviatingMoveCount--;
            }
            base.UndoLastMove();
        }

        public override void SelectCell(Position position, int promoteChoice)
        {
            SetPromotionChoice(promoteChoice);
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
                                    deviatingMoveCount++;
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
                                deviatingMoveCount++;
                                MakeMove(move);
                                AfterMove(move);
                                return;
                            }
                        }
                    }
                }
            }
            return;
        }
    }
}