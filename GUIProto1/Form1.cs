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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateBoard(sender, e);
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
                    this.panelBoard.Controls.Add(box);
                }
            }
            ClearBoardColours();
            panelBoard.Size = new Size(8 * CELL_SIZE, 8 * CELL_SIZE);
        }

        private void ClearBoardColours()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    boardButtons[i][j].BackColor = (((i % 2) + j) % 2 == 0) ? Color.Black : Color.White;
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
                    break;
                }
            }
        }

        private void DisplayPieces(object sender, EventArgs e)
        {

        }
    }
}