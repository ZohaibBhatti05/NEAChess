using Prototype1.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype1.Boards
{
    public enum PlayerColour
    {
        White, Black
    }

    public struct Position
    {
        public Position(int column, int row)
        {
            this.column = column; this.row = row;
        }
        public int column;
        public int row;
    }

    class ChessBoard
    {
        protected UpdateBoardGraphicsCallBack graphicsCallBack;

        public PlayerColour currentTurn { get; private set; }

        public Position selectedCell { get; private set; }

        public Piece[][] board { get; private set; }

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

            currentTurn = PlayerColour.White;

            // change later to allow custom positions
            StandardPositions();
        }


        // function loads standard positions :: override if child classes are implemented
        private void StandardPositions()
        {
            // fen for standard position
            PositionFromFEN("rnbqkbnr / pppppppp / 8 / 8 / 8 / 8 / PPPPPPPP / RNBQKBNR");
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

        // return true if position is occupied
        public bool ContainsPiece(Position position)
        {
            return (board[position.column][position.row] != null);
        }

        public bool ContainsPiece(int column, int row)
        {
            return (board[column][row] != null);
        }


        // return piece stored in position, test first
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
            if 
        }
    }
}
