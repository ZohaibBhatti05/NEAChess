using ChessProto1.Pieces;
using ChessProto1.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1.Boards
{
    public enum WinState
    {
        None,
        Draw,
        CheckWhite,
        CheckBlack,
        CheckmateWhite,
        CheckmateBlack
    }

    public enum PlayerColor
    {
        White,
        Black
    }

    internal class ChessBoard
    {
        private Piece[][] board = new Piece[8][];

        public Stack<Move> moveHistory = new Stack<Move>();
        private List<Move> curPieceMoves = new List<Move>();

        public (int?, int?) selectedCell { get; protected set; }
        public (int?, int?) checkCell { get; protected set; }
        public (int?, int?) previousCellFrom { get; protected set; }
        public (int?, int?) previousCellTo { get; protected set; }

        public WinState winState { get; protected set; }
        public PlayerColor currentTurn { get; protected set; }

        public ChessBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                board[i] = new Piece[8];
            }

            InitialiseGame();
        }

        private void InitialiseGame()
        {
            currentTurn = PlayerColor.White;
            StandardPositions();
        }

        protected virtual void StandardPositions()
        {
            for (int i = 0; i < 8; i++)
            {
                board[i][1] = new Pawn(PlayerColor.White);
                board[i][6] = new Pawn(PlayerColor.Black);
            }
        }

        protected virtual void CustomPositions()
        {
            throw new NotImplementedException();
        }

        public bool HasPiece(int column, int row)
        {
            return (board[column][row] != null);
        }

        public Piece GetPiece(int column, int row)
        {
            return board[column][row];
        }

        public bool SelectCell(int column, int row) // returns true if a piece was selected or moved
        {
            if (HasPiece(column, row))
            {
                if (board[column][row].color == currentTurn)
                {
                    selectedCell = (column, row);
                    return true;
                }
            }

            return false;
        }

        protected virtual string GetFENString()
        {
            return string.Empty;
        }
    }
}
