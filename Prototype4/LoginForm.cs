﻿using Prototype4.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Prototype4
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
                    GameForm gameForm = new GameForm(txtLoginUsername.Text); // show the game form
                    gameForm.ShowDialog();
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
            this.Hide();
            registerForm.ShowDialog();
            this.Show();
        }

        // guest, set gameform attributes as needed
        private void btnGuest_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm(); // show the game form
            gameForm.ShowDialog();
        }

        private void LoginForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(10, 10, 10), Color.FromArgb(60, 60, 60), 65f);

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }
    }
}
