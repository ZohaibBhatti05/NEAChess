using Prototype6.Boards;
using Prototype6.Pieces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype6
{
    // callback function for board to tell form to redraw
    public delegate void UpdateBoardGraphicsCallBack(bool updatePost);

    public partial class GameForm : Form
    {
        private readonly string RESOURCE_PATH = System.AppDomain.CurrentDomain.BaseDirectory; // get where app is RUNNING
        private Dictionary<int, Image> pieceImages = new Dictionary<int, Image>(); // dictionary of images
        private readonly Dictionary<char, char> unicodePieces = new Dictionary<char, char>()
        {
            {'P', '♙' }, {'R', '♖' }, {'N', '♘' }, {'B', '♗' }, {'Q', '♕' }, {'K', '♔' },
            {'p', /*'♟'*/ '♙' }, {'r', '♜' }, {'n', '♞' }, {'b', '♝' }, {'q', '♛' }, {'k', '♚' },
        };

        #region DefaultColours
        readonly Color DEFAULT_CELL_COLOUR_1 = Color.FromArgb(236, 217, 183);
        readonly Color DEFAULT_CELL_COLOUR_2 = Color.FromArgb(174, 137, 100);
        readonly Color DEFAULT_SELECT_COLOUR = Color.FromArgb(214, 195, 79);
        readonly Color DEFAULT_MOVE_COLOUR = Color.FromArgb(245, 235, 121);
        #endregion

        #region UserDefinedSettings
        Color CELL_COLOUR_1 = Color.FromArgb(236, 217, 183);
        Color CELL_COLOUR_2 = Color.FromArgb(174, 137, 100);
        Color SELECT_COLOUR = Color.FromArgb(214, 195, 79);
        Color MOVE_COLOUR = Color.FromArgb(245, 235, 121);
        Color CHECK_COLOUR = Color.FromArgb(255, 0, 0);
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
                    cell.BackgroundImageLayout = ImageLayout.Stretch;
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

            DrawBoard(false);
        }

        // method to draw the cells and pieces that comprise the board
        private void DrawBoard(bool updatePost)
        {
            // draw cells (update button colours and pictures)
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // clear image
                    boardCells[i][j].BackgroundImage = null;
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
                        boardCells[i][j].BackgroundImage = pieceImages[type];
                    }
                    boardCells[i][j].Update(); // redraw cell
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
                            boardCells[i][j].Image = Properties.Resources.Circle;
                        }
                        else
                        {
                            boardCells[i][j].Image = Properties.Resources.Dot;
                        }
                        //boardCells[move.positionTo.column][move.positionTo.row].BackColor = MOVE_COLOUR;
                    }
                }
            }

            UpdateMoveHistory();
            UpdatePieceDisplay();

            if (updatePost)
            {
                chessBoard.PostBoardRedraw();
            }
        }

        // prints the taken pieces to labels on the form
        private void UpdatePieceDisplay()
        {
            List<char> taken = chessBoard.takenPieces;

            lblWhiteTaken.Text = string.Empty;
            lblBlackTaken.Text = string.Empty;

            foreach(char p in taken)
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

            lblBlackTaken.Update();
            lblWhiteTaken.Update();
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
            txtWhiteMoves.Update();
            txtBlackMoves.Update(); // redraw
        }
    }
}
