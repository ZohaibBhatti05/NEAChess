using GUIProto1.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIProto1.Boards
{
    internal class Board
    {
        public bool checkState { get; private set; }

        protected Piece[][] board = new Piece[8][];

        public Board()
        {
            for (int i = 0; i < 8; i++)
            {
                board[i] = new Piece[8];
            }
            StandardPositions();
        }


        public void AddPiece(int x, int y, Piece piece)
        {
            board[x][y] = piece;
        }

        public void RemovePiece(int x, int y)
        {
            board[x][y] = null;
        }

        public void StandardPositions()
        {
            for (int i = 0; i < 8; i++)
            {
                board[i][1] = new Pawn(false);
                board[i][6] = new Pawn(true);
            }
            board[0][0] = new Rook(false); board[7][0] = new Rook(false);
            board[0][7] = new Rook(true); board[7][7] = new Rook(true);

            board[1][0] = new Knight(false); board[6][0] = new Knight(false);
            board[1][7] = new Knight(true); board[6][7] = new Knight(true);

            board[2][0] = new Bishop(false); board[5][0] = new Bishop(false);
            board[2][7] = new Bishop(true); board[5][7] = new Bishop(true);

            board[3][0] = new Queen(false); board[4][0] = new King(false);
            board[3][7] = new Queen(true); board[4][7] = new King(true);


        }

        public bool IsInCheck(bool white)
        {
            return false;
        }

        public Piece GetPiece(int x, int y)
        {
            return board[x][y];
        }

        public bool ContainsPiece(int x, int y)
        {
            return (board[x][y] != null);
        }
    }
}
