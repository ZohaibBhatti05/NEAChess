using Prototype7.Boards;
using Prototype7.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype7
{
    public delegate void CreateAnalysisCallback(string FEN, string PGN);

    public partial class GameForm : Form
    {
        ChessBoard chessBoard;
        private string username; // username of person logged in

        // user logged in
        public GameForm(string username)
        {
            this.username = username;
            InitializeComponent();
            cmbTimeSettings.SelectedIndex = 1;
            cmbVariant.SelectedIndex = 0;
            pnlCustomTime.Hide();
            cmbTimeSettings.Hide();

            pnlPreGame.Visible = true;
            pnlDuringGame.Visible = false;
        }

        // guest: not logged in
        public GameForm()
        {
            username = "Guest";
            InitializeComponent();
            cmbTimeSettings.SelectedIndex = 1;
            cmbVariant.SelectedIndex = 0;
            pnlCustomTime.Hide();
            cmbTimeSettings.Hide();

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
                chessBoard.InitialisePlayers(username, true, trackPlyDepth.Value, checkUseTT.Checked, !radFEN.Checked);
                timerUpdateTime.Start();
            }
            else // human game
            {
                chessBoard.InitialisePlayers(username, false, 0, false, false);

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
                timerUpdateTime.Start();
            }

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

        TimeSpan totalTime = new TimeSpan(0, 10, 0); // 5 minutes hardcoded
        TimeSpan increment = new TimeSpan(0, 10, 0);

        // take timers from board, display times
        private void timerUpdateTime_Tick(object sender, EventArgs e)
        {
            if (radNoTimers.Checked) // permanent display if disabled
            {
                lblWhiteTime.Text = "-- : -- : --";
                lblBlackTime.Text = "-- : -- : --";
                timerUpdateTime.Stop(); // disable tick timer, no need to keep updating
            }
            else
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
        }


        #endregion

        #region AI Settings

        private void radAgainstAI_CheckedChanged(object sender, EventArgs e)
        {
            if (radAgainstAI.Checked) // if checking the ai button, show :: else hide
            {
                pnlAISettings.Show();

                // hide time settings
                radNoTimers.Checked = true;
                timeRadioButton_CheckChanged(sender, e);

                radCustomTime.Hide();
                radPresetTime.Hide();
            }
            else
            {
                pnlAISettings.Hide();
                radCustomTime.Show();
                radPresetTime.Show();
            }
        }

        // show value of ai ply depth in label
        private void trackPlyDepth_ValueChanged(object sender, EventArgs e)
        {
            lblPlyDepth.Text = trackPlyDepth.Value.ToString();
        }

        #endregion

        #region Time Settings

        // hide relevant controls for time settings
        private void timeRadioButton_CheckChanged(object sender, EventArgs e)
        {
            if (radPresetTime.Checked)
            {
                pnlCustomTime.Hide();
                cmbTimeSettings.Show();
            }
            else if (radCustomTime.Checked)
            {
                pnlCustomTime.Show();
                cmbTimeSettings.Hide();
            }
            else
            {
                pnlCustomTime.Hide();
                cmbTimeSettings.Hide();
            }
        }

        // if input not a number, dont accept
        private void customTimeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(int.TryParse(e.KeyChar.ToString(), out int i));
        }

        #endregion

        #region Position
        private void radDefaultPosition_CheckedChanged(object sender, EventArgs e)
        {
            if (radDefaultPosition.Checked)
            {
                textFEN.Hide();
            }
            else
            {
                textFEN.Show();
            }
        }



        #endregion

        #region Settings
        private void menuColourC1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                CELL_COLOUR_1 = colorDialog.Color;
                DrawBoard(false);
            }
        }

        private void menuColourC2_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                CELL_COLOUR_2 = colorDialog.Color;
                DrawBoard(false);
            }
        }

        private void menuColourMove_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                MOVE_COLOUR = colorDialog.Color;
                DrawBoard(false);
            }
        }

        private void menuColourSelect_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SELECT_COLOUR = colorDialog.Color;
                DrawBoard(false);
            }
        }

        private void menuResetColour_Click(object sender, EventArgs e)
        {
            CELL_COLOUR_1 = DEFAULT_CELL_COLOUR_1;
            CELL_COLOUR_2 = DEFAULT_CELL_COLOUR_2;
            MOVE_COLOUR = DEFAULT_MOVE_COLOUR;
            SELECT_COLOUR = DEFAULT_SELECT_COLOUR;
            DrawBoard(false);
        }


        #endregion

        // display previous games
        private void menuPreviousGames_Click(object sender, EventArgs e)
        {
            AnalysisForm analysisForm = new AnalysisForm(username, new CreateAnalysisCallback(CreateAnalysisBoard));
            analysisForm.ShowDialog();          
        }

        // callback function to create an analysis board
        private void CreateAnalysisBoard(string FEN, string PGN)
        {
            chessBoard = new Analysis(new UpdateBoardGraphicsCallBack(DrawBoard));
            (chessBoard as Analysis).SetupAnalysis(FEN, PGN);

            // logistics
            pnlPreGame.Visible = false;
            pnlDuringGame.Visible = true;

            // emulate infinite time settings
            radNoTimers.Checked = true;
            timerUpdateTime.Start();

            // button logistics
            btnResign.BackgroundImage = Properties.Resources.Redo;
            btnDraw.Hide();

            InitialiseGraphics();
        }
    }
}
