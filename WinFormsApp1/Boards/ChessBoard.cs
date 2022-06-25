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
        public int column;
        public int row;
    }

    class ChessBoard
    {
        protected UpdateBoardGraphicsCallBack graphicsCallBack;

        public Piece[][] board { get; private set; }

        public ChessBoard(UpdateBoardGraphicsCallBack updateGraphicsCallback)
        {
            // set callback //
            graphicsCallBack = updateGraphicsCallback;

            // create an emtpy array for the board //
            board = new Piece[8][];
            for(int i = 0; i < 8; i++)
            {
                board[i] = new Piece[8];
            }
            // ----------------------------------- //

            // change later to allow custom positions
            StandardPositions();
        }

        private void StandardPositions()
        {
            // setup pawns
            for (int i = 0; i < 8; i++)
            {

            }


            graphicsCallBack.Invoke();
        }

        private void PositionFromFEN(string FEN)
        {

        }

        public bool ContainsPiece(Position position)
        {
            return (board[position.column][position.row] != null);
        }

        public bool ContainsPiece(int row, int column)
        {
            return (board[column][row] != null);
        }

        public Piece GetPiece(Position position)
        {
            return (board[position.column][position.row]);
        }

        public Piece GetPiece(int column, int row)
        {
            return (board[column][row]);
        }
    }
}
