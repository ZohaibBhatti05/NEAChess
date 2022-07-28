using Prototype3.Database;
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
        private DatabaseConnection dbConnection = new DatabaseConnection();

        public LoginForm()
        {
            InitializeComponent();
        }

        // logging in
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid(txtLoginUsername.Text) && IsValid(txtLoginPassword.Text))
            {
                if (AreDetailsValid(txtLoginUsername.Text, txtLoginPassword.Text))
                {
                    this.Hide();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }


        private bool IsValid(string text)
        {
            // only check for banned characters, others not as important
            foreach(char c in text)
            {
                if ("!£$%^&*()-_=+{}[]@'~# ".Contains(c))
                {
                    MessageBox.Show("Invalid details");
                    return false;
                }
            }

            return true;
        }

        // method returns true if the user exists and the password is correct
        private bool AreDetailsValid(string username, string password)
        {
            if (dbConnection.AreDetailsValid(username, password))
            {
                return true;
            }
            return false;
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

        // guest, set gameform attributes as needed
        private void btnGuest_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
