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
            chessBoard = new ChessBoard(new UpdateBoardGraphicsCallBack(DrawBoard));

            // intialise board players
            if (radAgainstAI.Checked) // ai game
            {
                chessBoard.InitialisePlayers(username, true, trackPlyDepth.Value);
                pnlWhiteTime.Hide();
                pnlBlackTime.Hide(); // hide and disable timers
            }
            else // human game
            {
                chessBoard.InitialisePlayers(username, false, 0);
                timerUpdateTime.Start();
            }


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

        TimeSpan totalTime = new TimeSpan(0, 10, 0); // 5 minutes hardcoded
        TimeSpan increment = new TimeSpan(0, 10, 0);

        // take timers from board, display times
        private void timerUpdateTime_Tick(object sender, EventArgs e)
        {
            TimeSpan whiteTimeLeft = totalTime - chessBoard.whiteTimer.Elapsed + (((chessBoard.moveNameHistory.Count + 1) / 2) * increment);
            TimeSpan blackTimeLeft = totalTime - chessBoard.blackTimer.Elapsed + ((chessBoard.moveNameHistory.Count / 2) * increment);

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


        #endregion

        #region AI Settings

        private void radAgainstAI_CheckedChanged(object sender, EventArgs e)
        {
            if (radAgainstAI.Checked) // if checking the ai button, show :: else hide
            {
                pnlAISettings.Show();
            }
            else
            {
                pnlAISettings.Hide();
            }
        }

        // show value of ai ply depth in label
        private void trackPlyDepth_ValueChanged(object sender, EventArgs e)
        {
            lblPlyDepth.Text = trackPlyDepth.Value.ToString();
        }

        #endregion
    }
}
