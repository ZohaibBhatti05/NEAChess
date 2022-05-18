using GUIProto1.Boards;
using GUIProto1.Pieces;
using GUIProto1.Players;
using System.Diagnostics;

namespace GUIProto1
{
    public partial class Form1 : Form
    {
        private PictureBox[][] boardButtons = new PictureBox[8][];
        private const int CELL_SIZE = 80;
        private readonly Dictionary<int, Color> highlightColours = new Dictionary<int, Color>
        {
            { 0, Color.Green },
            { 1, Color.Red }
        };

        private Board board;

        private Player whitePlayer;
        private Player blackPlayer;

        private readonly string imagePath = System.IO.Directory.GetCurrentDirectory() + "\\Assets\\Pieces\\";
        private readonly string imageType = "Standard";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateBoard(sender, e);
            InitialisePlayers(false, false);
            LoadImages();
            board = new Board();
            DisplayPieces();
        }

        private void InitialisePlayers(bool whiteAI, bool blackAI)
        {
            whitePlayer = (whiteAI) ? new Computer() : new Human();
        }
        
        private void CreateBoard(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                boardButtons[i] = new PictureBox[8];
                for (int j = 0; j < 8; j++)
                {
                    PictureBox box = new PictureBox();
                    box.Size = new Size(CELL_SIZE, CELL_SIZE);
                    box.Location = new Point(CELL_SIZE * i, CELL_SIZE * j);
                    boardButtons[i][j] = box;
                    boardButtons[i][j].Click += SelectCell;
                    boardButtons[i][j].Parent = this.panelBoard;
                    boardButtons[i][j].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.panelBoard.Controls.Add(box);
                }
            }
            ClearBoardColours();
            panelBoard.Size = new Size(8 * CELL_SIZE, 8 * CELL_SIZE);
        }

        private Dictionary<int, Image> images = new Dictionary<int, Image>();
        private void LoadImages()
        {
            for (int i = 0; i < 12; i++)
            {
                string file = imagePath + imageType + "/";
                switch (i)
                {
                    case 0:
                        file += "wP"; break;
                    case 1:
                        file += "wR"; break;
                    case 2:
                        file += "wN"; break;
                    case 3:
                        file += "wB"; break;
                    case 4:
                        file += "wK"; break;
                    case 5:
                        file += "wQ"; break;
                    case 6:
                        file += "bP"; break;
                    case 7:
                        file += "bR"; break;
                    case 8:
                        file += "bN"; break;
                    case 9:
                        file += "bB"; break;
                    case 10:
                        file += "bK"; break;
                    case 11:
                        file += "bQ"; break;

                }
                Console.WriteLine(file + ".png");
                images[i] = Image.FromFile(file + ".png");
            }
        }

        private void ClearBoardColours()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    boardButtons[i][j].BackColor = (((i % 2) + j) % 2 == 0) ? Color.SaddleBrown : Color.White;
                }
            }
        }

        private void HighlightCell(int cellX, int cellY, int highlightFlag)
        {
            boardButtons[cellX][cellY].BackColor = highlightColours[highlightFlag];
        }

        private void SelectCell(object? sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                if (boardButtons[i].Contains(sender))
                {
                    int j = Array.IndexOf(boardButtons[i], sender);
                    Console.WriteLine(i + " : " + j);
                    if (board.ContainsPiece(i, j))
                    {
                        ClearBoardColours();
                        HighlightCell(i, j, 0);
                    }
                    break;
                }
            }
        }

        private void DisplayPieces()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Piece piece = board.GetPiece(i, j);
                    if (piece == null) { continue; }
                    int display = (piece.type + ((!piece.isWhite) ? 6 : 0));
                    Console.WriteLine(display);
                    boardButtons[i][j].Image = images[display];
                }
            }
        }
    }
}