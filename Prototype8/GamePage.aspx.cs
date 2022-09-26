﻿using Prototype8.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Prototype8
{

    public partial class GamePage : System.Web.UI.Page
    {
        static ChessBoard chessBoard;
        private string username = "Guest"; // username of person logged in
        //static bool makeAIMove;

        protected void Page_Load(object sender, EventArgs e)
        {
            //timerAI.Enabled = false;
            //username = Request.QueryString["Username"];
            lblUsername.Text = "You are logged in as: " + username;
            pnlDuringGame.Visible = false;
            pnlAISettings.Visible = false;
            pnlCustomTime.Visible = false;
            cmbTimeSettings.Visible = false;
            textFEN.Visible = false;
            radAgainstAI_CheckedChanged(sender, e);

            if (Page.IsPostBack)
            {
                if (chessBoard != null)
                {
                    InitialiseGame();
                    InitialiseGraphics();
                    pnlDuringGame.Visible = true;
                    DrawBoard(false);
                }
            }

        }

        // starts the game
        protected void btnStartGame_Click(object sender, EventArgs e)
        {
            pnlPreGame.Visible = false;
            pnlDuringGame.Visible = true;
            InitialiseGame();
            updatePanel.Update();
        }

        private void InitialiseGame()
        {
            //timerUpdateTime.Enabled = true;
            if (chessBoard != null)
            {
                return;
            }

            // set board variant
            switch (cmbVariant.SelectedIndex)
            {
                case 0:
                    chessBoard = new ChessBoard(new UpdateBoardGraphicsCallBack(DrawBoard));
                    break;
                case 1:
                    chessBoard = new Chess960(new UpdateBoardGraphicsCallBack(DrawBoard));
                    break;
                case 2:
                    chessBoard = new Antichess(new UpdateBoardGraphicsCallBack(DrawBoard));
                    break;
                case 3:
                    chessBoard = new ThreeCheck(new UpdateBoardGraphicsCallBack(DrawBoard));
                    break;
            }


            // intialise board players
            if (radAgainstAI.Checked) // ai game
            {
                chessBoard.InitialisePlayers(username, true, cmbPlyDepth.SelectedIndex, cmbQDepth.SelectedIndex, checkUseTT.Checked, !radCustomPosition.Checked);
            }
            else // human game
            {
                chessBoard.InitialisePlayers(username, false, 0, 0, false, false);

                // time settings
                if (radCustomTime.Checked) // custom
                {
                    totalTime = new TimeSpan(0, int.Parse(textMinutes.Text), int.Parse(textSeconds.Text));
                    increment = new TimeSpan(0, 0, int.Parse(textIncrement.Text));
                }
                else if (radPresetTime.Checked) // preset
                {
                    switch (cmbTimeSettings.SelectedIndex)
                    {
                        case 0: // 1 min
                            totalTime = new TimeSpan(0, 1, 0);
                            increment = new TimeSpan(0, 0, 0);
                            break;
                        case 1: // 10 min
                            totalTime = new TimeSpan(0, 10, 0);
                            increment = new TimeSpan(0, 0, 0);
                            break;
                        case 2: // 20 min
                            totalTime = new TimeSpan(0, 20, 0);
                            increment = new TimeSpan(0, 0, 0);
                            break;
                        case 3: // 60 min
                            totalTime = new TimeSpan(1, 0, 0);
                            increment = new TimeSpan(0, 0, 0);
                            break;
                        case 4: // 15 | 10
                            totalTime = new TimeSpan(0, 15, 0);
                            increment = new TimeSpan(0, 0, 10);
                            break;
                        case 5: // 10 | 5
                            totalTime = new TimeSpan(0, 10, 0);
                            increment = new TimeSpan(0, 0, 5);
                            break;
                        case 6: // 3 | 2
                            totalTime = new TimeSpan(0, 3, 0);
                            increment = new TimeSpan(0, 0, 2);
                            break;
                        case 7: // 1 | 1
                            totalTime = new TimeSpan(0, 1, 0);
                            increment = new TimeSpan(0, 0, 1);
                            break;
                    }
                }
            }
            timerUpdateTime.Enabled = true;

            // position
            if (radDefaultPosition.Checked)
            {
                chessBoard.StandardPositions();
            }
            else
            {
                chessBoard.CustomPosition(textFEN.Text);
            }

            InitialiseGraphics();
        }

        // function is run whenever a cell is clicked
        protected void ClickCell(object sender, EventArgs e)
        {
            Position position;
            // get position of clicked cell
            for (int i = 0; i < 8; i++)
            {
                if (frontBoardCells[i].Contains(sender))
                {
                    position = new Position(i, Array.IndexOf(frontBoardCells[i], sender));
                    chessBoard.SelectCell(position, cmbPromote.SelectedIndex);
                    break;
                }
            }
            updatePanel.Update();
        }

        private void btnUndoMove_Click(object sender, EventArgs e)
        {
            if (radAgainstAI.Checked)
            {
                chessBoard.UndoLastMove();
            }
            chessBoard.UndoLastMove();
        }

        private void btnResign_Click(object sender, EventArgs e)
        {
            if (chessBoard is Analysis)
            {
                (chessBoard as Analysis).RedoNextMove();
            }
            else
            {
                chessBoard.Resign();
            }
        }


        #region timers

        static TimeSpan totalTime = new TimeSpan(0, 10, 0); // 5 minutes hardcoded
        static TimeSpan increment = new TimeSpan(0, 10, 0);
        static TimeSpan whiteTimeLeft;
        static TimeSpan blackTimeLeft;

        // take timers from board, display times
        protected void timerUpdateTime_Tick(object sender, EventArgs e)
        {
            if (radNoTimers.Checked) // permanent display if disabled
            {
                lblWhiteTime.Text = "-- : -- : --";
                lblBlackTime.Text = "-- : -- : --";
                timerUpdateTime.Enabled = false; // disable tick timer, no need to keep updating
            }
            else
            {
                whiteTimeLeft = totalTime - chessBoard.whiteTimer.Elapsed + new TimeSpan(0, 0, (((chessBoard.moveNameHistory.Count + 1) / 2) * increment.Seconds));
                blackTimeLeft = totalTime - chessBoard.blackTimer.Elapsed + new TimeSpan(0, 0, ((chessBoard.moveNameHistory.Count / 2) * increment.Seconds));

                if (whiteTimeLeft < TimeSpan.Zero)
                {
                    whiteTimeLeft = TimeSpan.Zero;
                    chessBoard.Timeout();
                    timerUpdateTime.Enabled = false;
                }
                else if (blackTimeLeft < TimeSpan.Zero)
                {
                    blackTimeLeft = TimeSpan.Zero;
                    chessBoard.Timeout();
                    timerUpdateTime.Enabled = false;
                }

                lblWhiteTime.Text = whiteTimeLeft.ToString("mm\\:ss\\.ff");
                lblBlackTime.Text = blackTimeLeft.ToString("mm\\:ss\\.ff");
            }
        }


        #endregion

        #region AI Settings

        protected void radAgainstAI_CheckedChanged(object sender, EventArgs e)
        {
            if (radAgainstAI.Checked) // if checking the ai button,.Visible = true :: else.Visible = false
            {
                pnlAISettings.Visible = true;

                //hide time settings

                radNoTimers.Checked = true;
                radPresetTime.Checked = false;
                radCustomTime.Checked = false;

                radCustomTime.Visible = false;
                radPresetTime.Visible = false;
            }
            else
            {
                pnlAISettings.Visible = false;
                radCustomTime.Visible = true;
                radPresetTime.Visible = true;
            }
            timeRadioButton_CheckChanged(sender, e);
            radDefaultPosition_CheckedChanged(sender, e);
        }

        #endregion

        #region Time Settings

        //hide relevant controls for time settings
        protected void timeRadioButton_CheckChanged(object sender, EventArgs e)
        {
            if (radPresetTime.Checked)
            {
                pnlCustomTime.Visible = false;
                cmbTimeSettings.Visible = true;
            }
            else if (radCustomTime.Checked)
            {
                pnlCustomTime.Visible = true;
                cmbTimeSettings.Visible = false;
            }
            else
            {
                pnlCustomTime.Visible = false;
                cmbTimeSettings.Visible = false;
            }
        }

        // if input not a number, dont accept
        protected void customTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            foreach(char c in ((System.Web.UI.WebControls.TextBox)sender).Text)
            {
                if (!int.TryParse(c.ToString(), out int i))
                {
                    ((System.Web.UI.WebControls.TextBox)sender).Text = string.Empty;
                    pnlCustomTime.Visible = true;
                    return;
                }
            }
            pnlCustomTime.Visible = true;
        }
        #endregion

        #region Position

        protected void radDefaultPosition_CheckedChanged(object sender, EventArgs e)
        {
            if (radDefaultPosition.Checked)
            {
                textFEN.Visible = false;
            }
            else
            {
                textFEN.Visible = true;
            }
        }

        #endregion

        #region Variants

        protected void cmbVariant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVariant.SelectedIndex == 1) // disallow custom positions in ficherrandom
            {
                radDefaultPosition.Checked = true;
                radCustomPosition.Checked = false;
                radAgainstAI_CheckedChanged(sender, e);
            }
        }

        #endregion

        protected void MakeAIMove(object sender, EventArgs e)
        {
            //timerAI.Enabled = false;
            //chessBoard.PostBoardRedraw();
            //updatePanel.Update();
        }
    }
}