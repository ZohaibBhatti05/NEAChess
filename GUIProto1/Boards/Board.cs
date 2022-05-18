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
        protected Piece[][] board = new Piece[8][];

        public Board()
        {
            for (int i = 0; i < 8; i++)
            {
                board[i] = new Piece[8];
            }
        }


        public void AddPiece(int x, int y, Piece piece)
        {
            board[x][y] = piece;
        }

        public void RemovePiece(int x, int y)
        {
            board[x][y] = null;
        }
    }
}
