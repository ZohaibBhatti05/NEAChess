using Prototype4.Boards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype4
{
    public partial class GameForm : Form
    {
        ChessBoard chessBoard;
        private string username; // username of person logged in

        // user logged in
        public GameForm(string username)
        {
            this.username = username;
            InitializeComponent();

            pnlPreGame.Visible = true;
            pnlDuringGame.Visible = false;
        }

        // guest: not logged in
        public GameForm()
        {
            username = "Guest";
            InitializeComponent();

            pnlPreGame.Visible = true;
            pnlDuringGame.Visible = false;
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            pnlPreGame.Visible = false;
            pnlDuringGame.Visible = true;
            InitialiseGame();
        }

        private void InitialiseGame()
        {
            chessBoard = new ChessBoard(new UpdateBoardGraphicsCallBack(DrawBoard), username);
            timerUpdateTime.Start();
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
        }

        private void btnUndoMove_Click(object sender, EventArgs e)
        {
            chessBoard.UndoLastMove();
        }

        private void btnResign_Click(object sender, EventArgs e)
        {
            chessBoard.Resign();
        }


        #region timers

        TimeSpan totalTime = new TimeSpan(0, 0, 10); // 5 minutes hardcoded

        // take timers from board, display times
        private void timerUpdateTime_Tick(object sender, EventArgs e)
        {
            TimeSpan whiteTimeLeft = totalTime - chessBoard.whiteTimer.Elapsed;
            TimeSpan blackTimeLeft = totalTime - chessBoard.blackTimer.Elapsed;

            if (whiteTimeLeft < TimeSpan.Zero)
            {
                whiteTimeLeft = TimeSpan.Zero;
                chessBoard.Timeout();
                timerUpdateTime.Stop();
            }
            else if (blackTimeLeft < TimeSpan.Zero)
            {
                blackTimeLeft = TimeSpan.Zero;
                chessBoard.Timeout();
                timerUpdateTime.Stop();
            }

            lblWhiteTime.Text = whiteTimeLeft.ToString("mm\\:ss\\.ff");
            lblBlackTime.Text = blackTimeLeft.ToString("mm\\:ss\\.ff");
        }

        private void UpdateTimers()
        {

        }


        #endregion
    }
}
