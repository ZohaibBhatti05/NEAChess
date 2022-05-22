using ChessProto1.Boards;
using ChessProto1.Players;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessProto1
{
    public partial class GameForm : Form
    {
        Player whitePlayer;
        Player blackPlayer;
        ChessBoard chessBoard;

        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            chessBoard = new Standard();
            whitePlayer = new Human();
            blackPlayer = new Human();
            InitialiseGUI();
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            chessBoard.UndoLastMove();
            UpdateBoardGUI();
        }
    }
}
