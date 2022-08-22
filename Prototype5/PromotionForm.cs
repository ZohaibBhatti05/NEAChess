using Prototype5.Boards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype5
{
    public delegate void GetPromotionCallback(char type, Move move);

    public partial class PromotionForm : Form
    {
        private GetPromotionCallback promotionCallback;
        private PlayerColour pieceColour;
        private Move move;

        public PromotionForm(GetPromotionCallback callback, PlayerColour colour, Move move)
        {
            InitializeComponent();

            // display piece images
            if (colour == PlayerColour.White)
            {
                picQueen.Image = Properties.Resources.wQ;
                picKnight.Image = Properties.Resources.wN;
                picBishop.Image = Properties.Resources.wB;
                picRook.Image = Properties.Resources.wR;
            }
            else
            {
                picQueen.Image = Properties.Resources.bQ;
                picKnight.Image = Properties.Resources.bN;
                picBishop.Image = Properties.Resources.bB;
                picRook.Image = Properties.Resources.bR;
            }

            pieceColour = colour;
            promotionCallback = callback;
            this.move = move;
        }

        private void btnQueen_Click(object sender, EventArgs e)
        {
            char type = 'q';
            promotionCallback.Invoke(type, move);
            this.Close();
        }

        private void btnKnight_Click(object sender, EventArgs e)
        {
            char type = 'n';
            promotionCallback.Invoke(type, move);
            this.Close();
        }

        private void btnBishop_Click(object sender, EventArgs e)
        {
            char type = 'b';
            promotionCallback.Invoke(type, move);
            this.Close();
        }

        private void btnRook_Click(object sender, EventArgs e)
        {
            char type = 'r';
            promotionCallback.Invoke(type, move);
            this.Close();
        }
    }
}
