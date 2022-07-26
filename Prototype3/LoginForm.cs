using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype3
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        // method run when the form closes
        private void OnFormClose(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != DialogResult.Cancel) // if the user DIDNT hit the X button or kill the form
            {
                GameForm gameForm = new GameForm(); // show the game form
                gameForm.ShowDialog();
            }
        }
    }
}
