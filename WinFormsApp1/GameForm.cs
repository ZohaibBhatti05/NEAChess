using Prototype1.Boards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype1
{
    public partial class GameForm : Form
    {
        ChessBoard chessBoard;

        public GameForm()
        {
            InitializeComponent();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            InitialiseGame();
        }

        private void InitialiseGame()
        {
            chessBoard = new ChessBoard(new UpdateBoardGraphicsCallBack(DrawBoard));
            InitialiseGraphics();
        }

        // function is run whenever a cell is clicked
        private void ClickCell(object sender, EventArgs e)
        {
            Position position;
            // get position of clicked cell
            for (int i = 0; i < 8; i++)
            {
                if (boardCells[i].Contains(sender))
                {
                    position = new Position(i, Array.IndexOf(boardCells[i], sender));
                    chessBoard.SelectCell(position);
                    break;
                }
            }
            //

            //
        }

        private void btnUndoMove_Click(object sender, EventArgs e)
        {
            chessBoard.UndoLastMove();
        }
    }
}
