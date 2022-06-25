using Prototype1.Boards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype1
{
    public partial class GameForm : Form
    {
        ChessBoard chessBoard;

        public GameForm()
        {
            InitializeComponent();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            InitialiseGame();
        }

        private void InitialiseGame()
        {
            chessBoard = new ChessBoard(new UpdateBoardGraphicsCallBack(DrawBoard));
            InitialiseGraphics();
        }

        private void ClickCell(object sender, EventArgs e)
        {
            
        }
    }
}
