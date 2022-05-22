using ChessProto1.Boards;
using ChessProto1.Pieces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessProto1
{
    public enum PieceVisuals
    {
        Standard
    }

    public partial class GameForm : Form
    {
        PictureBox[][] boardCells = new PictureBox[8][];
        private readonly string resourcePath = System.AppDomain.CurrentDomain.BaseDirectory; // get where app is RUNNING
        private Dictionary<int, Image> pieceImages = new Dictionary<int, Image>();
        private const int CELL_SIZE = 80;
        Color wColor = Color.White;
        Color bColor = Color.SaddleBrown;
        Color selectColor = Color.Green;
        Color checkColor = Color.Red;
        PieceVisuals pVisuals = PieceVisuals.Standard;

        private void InitialiseGUI()
        {
            CreateBoardGUI();
        }

        private void CreateBoardGUI()
        {
            for (int i = 0; i < 8; i++)
            {
                boardCells[i] = new PictureBox[8];
                for (int j = 0; j < 8; j++)
                {
                    PictureBox cell = new PictureBox();
                    cell.Parent = panelBoardGUI;
                    cell.Location = new Point(i * CELL_SIZE, (7 - j) * CELL_SIZE);
                    cell.Size = new Size(CELL_SIZE, CELL_SIZE);
                    cell.Click += ClickCell;
                    cell.SizeMode = PictureBoxSizeMode.StretchImage;
                    panelBoardGUI.Controls.Add(cell);
                    boardCells[i][j] = cell;
                }
            }

            string pieceImagePath = resourcePath + "Assets\\PieceImages\\" + pVisuals.ToString() + "\\";

            for (int i = 0; i < 12; i++)
            {
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

            UpdateBoardGUI();
        }

        public void UpdateBoardGUI()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    boardCells[i][j].BackColor = ((i + j) % 2 == 0) ? wColor : bColor;
                }
            }

            if (chessBoard.selectedCell.column > -1)
            {
                boardCells[(int)chessBoard.selectedCell.column][(int)chessBoard.selectedCell.row].BackColor = selectColor;
            }

            foreach(Position position in chessBoard.selectedPieceMoves)
            {
                boardCells[position.column][position.row].BackColor = Color.Yellow;
            }

            DrawPieces();
        }

        private void DrawPieces()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (chessBoard.HasPiece(new Position(i, j)))
                    {
                        Piece p = chessBoard.GetPiece(new Position(i, j));
                        boardCells[i][j].Image = pieceImages[(6 * ((p.color == PlayerColor.White) ? 0 : 1)) + p.type];
                    }
                    else
                    {
                        boardCells[i][j].Image = null;
                    }
                }
            }
        }

        public void ClickCell(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                if (boardCells[i].Contains(sender))
                {
                    int j = Array.IndexOf(boardCells[i], sender);
                    chessBoard.SelectCell(new Position(i, j));
                    Debug.WriteLine(i + " : " + j);
                    UpdateBoardGUI();
                    return;
                }
            }
        }
    }
}
