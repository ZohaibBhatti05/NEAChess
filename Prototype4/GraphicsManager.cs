using Prototype4.Boards;
using Prototype4.Pieces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype4
{
    // callback function for board to tell form to redraw
    public delegate void UpdateBoardGraphicsCallBack();

    public partial class GameForm : Form
    {
        private readonly string RESOURCE_PATH = System.AppDomain.CurrentDomain.BaseDirectory; // get where app is RUNNING
        private Dictionary<int, Image> pieceImages = new Dictionary<int, Image>(); // dictionary of images

        #region UserDefinedSettings
        Color CELL_COLOUR_1 = Color.LightGray;
        Color CELL_COLOUR_2 = Color.SaddleBrown;
        Color SELECT_COLOUR = Color.Yellow;
        Color MOVE_COLOUR = Color.Green;
        Color CHECK_COLOUR = Color.Red;
        #endregion

        PictureBox[][] boardCells = new PictureBox[8][];
        // array of buttons for click location purposes

        // sets up graphics dictionary and pictureboxes
        private void InitialiseGraphics()
        {
            // create buttons, arrange and resize, add click event
            for (int i = 0; i < 8; i++)
            {
                boardCells[i] = new PictureBox[8];
                for (int j = 0; j < 8; j++)
                {
                    PictureBox cell = new PictureBox();
                    cell.Size = new Size(75, 75);
                    cell.Location = new Point(i * 75, (7 - j) * 75);
                    cell.SizeMode = PictureBoxSizeMode.StretchImage;
                    cell.Margin = new Padding(0, 0, 0, 0);
                    pnlBoard.Controls.Add(cell);
                    boardCells[i][j] = cell;
                    cell.Click += ClickCell;
                }
            }
            //

            // initialise piece graphics
            string pieceImagePath = RESOURCE_PATH + "Assets\\PieceImages\\Standard\\";
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
                pieceImages[i] = Image.FromFile(path);
            }
            //

            DrawBoard();
        }

        // method to draw the cells and pieces that comprise the board
        private void DrawBoard()
        {
            // draw cells (update button colours and pictures)
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // clear image
                    boardCells[i][j].Image = null;

                    // set colour
                    if ((i + j) % 2 != 0)
                    {
                        boardCells[i][j].BackColor = CELL_COLOUR_1;
                    }
                    else
                    {
                        boardCells[i][j].BackColor = CELL_COLOUR_2;
                    }

                    // highlight cells
                    if(chessBoard.selectedCell != null) // selected piece / moves
                    {
                        Position selected = chessBoard.selectedCell;
                        boardCells[selected.column][selected.row].BackColor = SELECT_COLOUR;

                        if (chessBoard.selectedMoves.Count != 0)
                        {
                            foreach (Move move in chessBoard.selectedMoves)
                            {
                                boardCells[move.positionTo.column][move.positionTo.row].BackColor = MOVE_COLOUR;
                            }
                        }
                    }

                    // highlight king in check
                    if (chessBoard.checkCell != null)
                    {
                        Position check = chessBoard.checkCell;
                        boardCells[check.column][check.row].BackColor = CHECK_COLOUR;
                    }

                    //
                    // update win label
                    lblWinStatus.Text = String.Format($"Win Status: {chessBoard.winStatus.ToString()}");

                    // draw pieces
                    if (chessBoard.ContainsPiece(i, j))
                    {
                        // get piece type
                        Piece piece = chessBoard.GetPiece(i, j);
                        int type = piece.type;
                        if (piece.colour == PlayerColour.Black) { type += (pieceImages.Count / 2); }
                        boardCells[i][j].Image = pieceImages[type];
                    }
                }
            }

            UpdateMoveHistory();
        }

        // prints the move history to a rich text box on the game form
        private void UpdateMoveHistory()
        {
            txtMoveHistory.Text = null;
            for (int i = 0; i < chessBoard.moveNameHistory.Count; i++)
            {
                if (i > 0 && i % 2 == 0) // after every 2 moves, go to newline
                {
                    txtMoveHistory.Text += "\n"; // newline
                }

                txtMoveHistory.Text += chessBoard.moveNameHistory[i] + " :: ";
            }
        }
    }
}
