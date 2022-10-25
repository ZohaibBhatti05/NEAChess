using Microsoft.Win32;
using Prototype8.Boards;
using Prototype8.Pieces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Image = System.Web.UI.WebControls.Image;

namespace Prototype8
{
    // callback function for board to tell form to redraw
    public delegate void UpdateBoardGraphicsCallBack(bool updatePost);

    public partial class GamePage : System.Web.UI.Page
    {
        private static Dictionary<int, string> pieceImages = new Dictionary<int, string>(); // dictionary of images
        private readonly static Dictionary<char, char> unicodePieces = new Dictionary<char, char>()
        {
            {'P', '♙' }, {'R', '♖' }, {'N', '♘' }, {'B', '♗' }, {'Q', '♕' }, {'K', '♔' },
            {'p', /*'♟'*/ '♙' }, {'r', '♜' }, {'n', '♞' }, {'b', '♝' }, {'q', '♛' }, {'k', '♚' },
        };

        #region DefaultColours
        static readonly Color DEFAULT_CELL_COLOUR_1 = Color.FromArgb(236, 217, 183);
        static readonly Color DEFAULT_CELL_COLOUR_2 = Color.FromArgb(174, 137, 100);
        static readonly Color DEFAULT_SELECT_COLOUR = Color.FromArgb(214, 195, 79);
        static readonly Color DEFAULT_MOVE_COLOUR = Color.FromArgb(245, 235, 121);
        static readonly Color DEFAULT_CHECK_COLOUR = Color.FromArgb(255, 0, 0);
        #endregion

        #region UserDefinedSettings
        static Color CELL_COLOUR_1 = Color.FromArgb(236, 217, 183);
        static Color CELL_COLOUR_2 = Color.FromArgb(174, 137, 100);
        static Color SELECT_COLOUR = Color.FromArgb(214, 195, 79);
        static Color MOVE_COLOUR = Color.FromArgb(245, 235, 121);
        static Color CHECK_COLOUR = Color.FromArgb(255, 0, 0);
        #endregion

        static Image[][] boardCells = new Image[8][];
        static ImageButton[][] frontBoardCells = new ImageButton[8][];
        // array of buttons for click location purposes

        private static string pieceSet = "Standard";

        // updates customisable colours depending on user selections
        protected void ManageColours(object sender, EventArgs e)
        {
            CELL_COLOUR_1 = (txtLightCellColour.Text == String.Empty) ? DEFAULT_CELL_COLOUR_1 : ColorTranslator.FromHtml("#" + txtLightCellColour.Text);
            CELL_COLOUR_2 = (txtDarkCellColour.Text == String.Empty) ? DEFAULT_CELL_COLOUR_2 : ColorTranslator.FromHtml("#" + txtDarkCellColour.Text);
            SELECT_COLOUR = (txtSelectCellColour.Text == String.Empty) ? DEFAULT_SELECT_COLOUR : ColorTranslator.FromHtml("#" + txtSelectCellColour.Text);
            MOVE_COLOUR = (txtMoveCellColour.Text == String.Empty) ? DEFAULT_MOVE_COLOUR : ColorTranslator.FromHtml("#" + txtMoveCellColour.Text);
            CHECK_COLOUR = (txtCheckCellColour.Text == String.Empty) ? DEFAULT_CHECK_COLOUR : ColorTranslator.FromHtml("#" + txtCheckCellColour.Text);

            updatePanel.Update();
        }

        // updates piece set images depending on user selections
        protected void cmbPieceSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            pieceSet = cmbPieceSet.Text;
            InitialiseGraphics();
        }

        // sets up graphics dictionary and pictureboxes
        private void InitialiseGraphics()
        {
            pnlBoard.Controls.Clear();
            // create buttons, arrange and resize, add click event
            for (int i = 0; i < 8; i++)
            {
                boardCells[i] = new Image[8];
                frontBoardCells[i] = new ImageButton[8];
                for (int j = 0; j < 8; j++)
                {
                    // set up the piece images
                    Image cell = new Image();
                    cell.Style.Add("position", "absolute");
                    cell.Style.Add("width", "75px");
                    cell.Style.Add("height", "75px");
                    cell.Style.Add("left", $"{i * 75}px");
                    cell.Style.Add("top", $"{(7 - j) * 75}px");
                    cell.BorderWidth = Unit.Empty;
                    cell.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
                    cell.ID = String.Format($"bg{i}{j}");

                    pnlBoard.Controls.Add(cell);
                    boardCells[i][j] = cell;

                    // set up the front images
                    ImageButton fcell = new ImageButton();
                    fcell.Style.Add("position", "absolute");
                    fcell.Style.Add("width", "75px");
                    fcell.Style.Add("height", "75px");
                    fcell.Style.Add("left", $"{i * 75}px");
                    fcell.Style.Add("top", $"{(7 - j) * 75}px");
                    fcell.BorderWidth = Unit.Empty;
                    fcell.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
                    fcell.BackColor = Color.Transparent;
                    fcell.ID = String.Format($"fg{i}{j}");

                    fcell.Click += ClickCell;

                    pnlBoard.Controls.Add(fcell);
                    frontBoardCells[i][j] = fcell;

                }
            }
            //

            // initialise piece graphics
            pieceImages.Clear();
            // change visual style

            string pieceImagePath = "~/Assets/PieceImages/" + pieceSet + "/";
            // add relative path

            for (int i = 0; i < 12; i++)
            {
                // add paths to dictionary
                string path = pieceImagePath;
                switch (i)
                {
                    case 0:
                        path += "wP.png"; break;
                    case 1:
                        path += "wR.png"; break;
                    case 2:
                        path += "wN.png"; break;
                    case 3:
                        path += "wB.png"; break;
                    case 4:
                        path += "wQ.png"; break;
                    case 5:
                        path += "wK.png"; break;
                    case 6:
                        path += "bP.png"; break;
                    case 7:
                        path += "bR.png"; break;
                    case 8:
                        path += "bN.png"; break;
                    case 9:
                        path += "bB.png"; break;
                    case 10:
                        path += "bQ.png"; break;
                    case 11:
                        path += "bK.png"; break;
                }

                pieceImages[i] = path;
            }
            //

            DrawBoard(false);
        }

        // method to draw the cells and pieces that comprise the board
        private void DrawBoard(bool updatePost)
        {
            if (frontBoardCells == null) { return; }
            else if (frontBoardCells[0] == null) { return; }
            else if (boardCells == null) { return; }
            else if (boardCells[0] == null) { return; }
            // draw cells (update button colours and pictures)
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // clear image
                    boardCells[i][j].ImageUrl = ResolveUrl("~/Resources/Empty.png");
                    frontBoardCells[i][j].ImageUrl = ResolveUrl("~/Resources/Empty.png");

                    // set colour
                    if ((i + j) % 2 != 0)
                    {
                        boardCells[i][j].BackColor = CELL_COLOUR_1;
                    }
                    else
                    {
                        boardCells[i][j].BackColor = CELL_COLOUR_2;
                    }

                    // highlight king in check
                    if (chessBoard.checkCell != null)
                    {
                        Position check = chessBoard.checkCell;
                        boardCells[check.column][check.row].BackColor = CHECK_COLOUR;
                    }

                    //highlight last move
                    if (chessBoard.moveHistory.Count > 0)
                    {
                        Move lastMove = chessBoard.moveHistory.First();
                        boardCells[lastMove.positionFrom.column][lastMove.positionFrom.row].BackColor = MOVE_COLOUR;
                        boardCells[lastMove.positionTo.column][lastMove.positionTo.row].BackColor = MOVE_COLOUR;
                    }

                    //
                    // draw pieces
                    if (chessBoard.ContainsPiece(i, j))
                    {
                        // get piece type
                        Piece piece = chessBoard.GetPiece(i, j);
                        int type = piece.type;
                        if (piece.colour == PlayerColour.Black) { type += (pieceImages.Count / 2); }
                        boardCells[i][j].ImageUrl = ResolveUrl(pieceImages[type]);
                    }
                    //boardCells[i][j].Update(); // redraw cell
                }
            }

            // highlight cells
            if (chessBoard.selectedCell != null) // selected piece / moves
            {
                Position selected = chessBoard.selectedCell;
                boardCells[selected.column][selected.row].BackColor = SELECT_COLOUR;

                // valid moves
                if (chessBoard.selectedMoves.Count != 0)
                {
                    foreach (Move move in chessBoard.selectedMoves) // for each move
                    {
                        int i = move.positionTo.column;
                        int j = move.positionTo.row;
                        if (chessBoard.ContainsPiece(move.positionTo))  // if contains piece, display circle, else display dot
                        {
                            frontBoardCells[i][j].ImageUrl = ResolveUrl("~/Resources/Circle.png");
                        }
                        else
                        {
                            frontBoardCells[i][j].ImageUrl = ResolveUrl("~/Resources/Dot.png");
                        }
                        boardCells[move.positionTo.column][move.positionTo.row].BackColor = MOVE_COLOUR;
                    }
                }
            }

            UpdateMoveHistory();
            UpdatePieceDisplay();

            if (updatePost)
            {
                //makeAIMove.Invoke();
                //updatePanel.Update();
                //makeAIMove = true;
                //DrawBoard(false);
                chessBoard.PostBoardRedraw();
            }

            // analysis block
            if (chessBoard is Analysis)
            {
                lblAnalysisMove.Text = "Expected move: " + (chessBoard as Analysis).analysisMove;
            }
        }

        // prints the taken pieces to labels on the form
        private void UpdatePieceDisplay()
        {
            List<char> taken = chessBoard.takenPieces;

            lblWhiteTaken.Text = string.Empty;
            lblBlackTaken.Text = string.Empty;

            foreach (char p in taken)
            {
                if (char.IsUpper(p)) // white piece
                {
                    lblWhiteTaken.Text += unicodePieces[p];
                }
                else // black piece
                {
                    lblBlackTaken.Text += unicodePieces[p];
                }
            }
        }

        // prints the move history to a rich text box on the game form :: format better later
        private void UpdateMoveHistory()
        {
            txtWhiteMoves.Text = null;
            txtBlackMoves.Text = null;
            for (int i = 0; i < chessBoard.moveNameHistory.Count; i++) // foreach move made
            {
                if (i % 2 == 0)
                {
                    txtWhiteMoves.Text += ((i / 2) + 1) + ". " + chessBoard.moveNameHistory[i] + Environment.NewLine;
                }
                else
                {
                    txtBlackMoves.Text += chessBoard.moveNameHistory[i] + Environment.NewLine;
                }
            }
            //txtWhiteMoves.Update();
            //txtBlackMoves.Update(); // redraw
        }

        protected void UpdatePanel(object sender, EventArgs e)
        {
            DrawBoard(false);
        }
    }
}