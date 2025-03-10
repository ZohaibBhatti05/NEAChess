﻿using Prototype1.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype1.Boards
{
    public enum WinStatus
    {
        None, 
        WhiteCheck,
        BlackCheck,
        WhiteMate,
        BlackMate,
        Stalemate,
        DrawInsufficient,
        DrawRepetition,
        DrawFifty,
    }

    public enum PlayerColour
    {
        White, Black
    }

    // class has two attributes : column and row. Thats it
    public class Position
    {
        public Position(int column, int row)
        {
            this.column = column; this.row = row;
        }

        public int column { get; private set; }
        public int row { get; private set; }
    }

    class ChessBoard
    {
        protected UpdateBoardGraphicsCallBack graphicsCallBack;

        public PlayerColour currentTurn { get; private set; }

        public Position selectedCell { get; private set; }
        public Position checkCell { get; private set; }

        public List<Move> selectedMoves { get; private set; }

        private List<Move> moveHistory;

        public Piece[][] board { get; private set; }

        public WinStatus winStatus { get; private set; }

        public ChessBoard(UpdateBoardGraphicsCallBack updateGraphicsCallback)
        {
            // create an emtpy array for the board //
            board = new Piece[8][];
            for(int i = 0; i < 8; i++)
            {
                board[i] = new Piece[8];
            }
            // ----------------------------------- //

            // set callback //
            graphicsCallBack = updateGraphicsCallback;

            // initalise empty variables
            moveHistory = new List<Move>();
            currentTurn = PlayerColour.White;
            selectedMoves = new List<Move>();
            winStatus = WinStatus.None;

            // change later to allow custom positions
            StandardPositions();
        }


        // function loads standard positions :: override if child classes are implemented
        private void StandardPositions()
        {
            // fen for standard position
            //PositionFromFEN("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR");

            // custom fen for testing
            PositionFromFEN("6bk/7b/5P2/4B3/8/8/8/K7");
        }

        // places pieces from a FEN string
        // error checking should be added if user inputted FEN is implemented
        private void PositionFromFEN(string FEN)
        {
            int file = 0; int rank = 7; // program displays from bottom up, FEN goes from top to bottom, so rank goes from 7 to 0
            foreach (char c in FEN)
            {
                if (c == '/') // / denotes new line, go down
                {
                    file = 0; rank--;
                }
                else if (int.TryParse(c.ToString(), out int stride))
                {
                    file += stride;
                }
                else if (c != ' ')
                {
                    // uppercase for white pieces
                    if (char.IsUpper(c))
                    {
                        board[file][rank] = NewPieceFromCharType(char.ToLower(c), PlayerColour.White);
                    }
                    else
                    {
                        board[file][rank] = NewPieceFromCharType(char.ToLower(c), PlayerColour.Black);
                    }
                    file++; // next position
                }
            }
        }

        // takes a character, returns a piece
        private Piece NewPieceFromCharType(char type, PlayerColour colour)
        {
            switch (type)
            {
                case 'p':
                    return new Pawn(colour);
                case 'r':
                    return new Rook(colour);
                case 'n':
                    return new Knight(colour);
                case 'b':
                    return new Bishop(colour);
                case 'q':
                    return new Queen(colour);
                case 'k':
                    return new King(colour);
            }
            return null;
        }

        // returns if a position has a piece in it
        public bool ContainsPiece(Position position)
        {
            return (board[position.column][position.row] != null);
        }
        public bool ContainsPiece(int column, int row)
        {
            return (board[column][row] != null);
        }

        // returns the piece at the specified position
        public Piece GetPiece(Position position)
        {
            return (board[position.column][position.row]);
        }
        public Piece GetPiece(int column, int row)
        {
            return (board[column][row]);
        }

        // method run from form when a cell is clicked
        public void SelectCell(Position position)
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
                    graphicsCallBack.Invoke();
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
                        graphicsCallBack.Invoke();
                        return;
                    }

                    // of a different colour: try to make a move
                    else
                    {
                        foreach(Move move in selectedMoves) // if position is in a valid move, make the move
                        {
                            if ((position.column == move.positionTo.column) && (position.row == move.positionTo.row))
                            {
                                MakeMove(move);
                                AfterMove(move);
                                graphicsCallBack.Invoke();
                                return;
                            }
                        }
                    }
                }

                // if selecting an empty square
                else
                {
                    foreach(Move move in selectedMoves) // if position is in a valid move, make the move
                    {
                        if ((position.column == move.positionTo.column) && (position.row == move.positionTo.row))
                        {
                            MakeMove(move);
                            AfterMove(move);
                            graphicsCallBack.Invoke();
                            return;
                        }
                    }
                }
            }
        }

        // method takes a move and performs it
        private void MakeMove(Move move)
        {
            AddPiece(move.movingPiece, move.positionTo);

            RemovePiece(move.positionFrom);
        }

        // undoes a specified instance of a move
        private void UndoMove(Move move)
        {
            AddPiece(move.takenPiece, move.positionTo); // put taken piece back

            AddPiece(move.movingPiece, move.positionFrom); // put the moving piece back
        }

        private void AfterMove(Move move)
        {
            // switch turns
            currentTurn = (currentTurn == PlayerColour.White) ? PlayerColour.Black : PlayerColour.White;

            // clear selections
            selectedCell = null;
            selectedMoves = null;

            // update win status for check/mate/draw
            UpdateWinStatus();

            // add move to history
            moveHistory.Add(move);
        }

        // adds a specified piece to the specified position
        private void AddPiece(Piece piece, Position position)
        {
            board[position.column][position.row] = piece;
        }

        // removes the piece at the specified position
        private void RemovePiece(Position position)
        {
            board[position.column][position.row] = null;
        }

        // returns the position of the king of the specified colour
        private Position GetKingPosition(PlayerColour colour)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++) // foreach piece on the board
                {
                    if (ContainsPiece(i , j))
                    {
                        Piece piece = GetPiece(i, j);
                        if (piece is King && piece.colour == colour) { return new Position(i, j); }
                        // if it is a king of the specified colour, return the position
                    }
                }
            }
            return null; // prevent error throwing
        }

        // function takes a list of moves and removes all that result in check
        public List<Move> CullCheckMoves(List<Move> moves, PlayerColour colour)
        {
            List<Move> validMoves = new List<Move>();
            foreach(Move move in moves)
            {
                MakeMove(move); // make the move
                Position position = GetKingPosition(colour); // get the king
                King king = (GetPiece(position) as King);

                if (!king.IsInCheck(this, position)) // if move doesnt result in check, add the move
                {
                    validMoves.Add(move);
                }

                UndoMove(move); // undo the move
            }
            return validMoves;
        }

        // function takes a colour and returns all possible moves for every piece of that colour
        public List<Move> AllPossibleMoves(PlayerColour colour)
        {
            List<Move> possibleMoves = new List<Move>();
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++) // for every piece on the board
                {
                    if (ContainsPiece(x, y))
                    {
                        if (GetPiece(x, y).colour == colour) // if it is of the specified colour
                        {
                            possibleMoves.AddRange(GetPiece(x, y).GenerateLegalMoves(this, new Position(x, y)));
                            // add all moves to big list
                        }
                    }
                }
            }
            return possibleMoves;
        }

        // updates whether a side is in check/mate or a draw
        private void UpdateWinStatus()
        {
            Position position = GetKingPosition(currentTurn); // get the king
            King king = (GetPiece(position) as King);

            if (king.IsInCheck(this, position)) // if in check:
            {
                if (AllPossibleMoves(currentTurn).Count == 0) // no possible moves
                {
                    winStatus = (currentTurn == PlayerColour.White) ? WinStatus.WhiteMate : WinStatus.BlackMate; // checkmate
                    checkCell = GetKingPosition(currentTurn);
                }
                else // possible moves
                {
                    winStatus = (currentTurn == PlayerColour.White) ? WinStatus.WhiteCheck : WinStatus.BlackCheck; // check (regular)
                    checkCell = GetKingPosition(currentTurn);
                }
            }
            else // not in check
            {
                if (AllPossibleMoves(currentTurn).Count == 0) // no possible moves
                {
                    winStatus = WinStatus.Stalemate; // stalemate
                }
                else // possible moves
                {
                    winStatus = WinStatus.None; // noones winning
                    checkCell = null;
                }
            }

            // test for other draw types here
        }
    }
}
