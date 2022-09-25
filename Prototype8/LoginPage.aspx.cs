using Prototype8.Database;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype8
{
    public partial class LoginPage : System.Web.UI.Page
    {
        private DatabaseConnection dbConnection = new DatabaseConnection();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // logging in
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid(txtLoginUsername.Text) && IsValid(txtLoginPassword.Text))
            {
                if (AreDetailsValid(txtLoginUsername.Text, txtLoginPassword.Text))
                {
                    Response.Redirect($"GamePage.aspx?Username={txtLoginUsername.Text}");
                }
            }
            lblError.Text = "Invalid Details - Please check your entered details.";
        }

        private new bool IsValid(string text)
        {
            // only check for banned characters, others not as important
            foreach (char c in text)
            {
                if ("!£$%^&*()-_=+{}[]@'~# ".Contains(c))
                {
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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }

        // guest, set gameform attributes as needed
        protected void btnGuest_Click(object sender, EventArgs e)
        {
            Response.Redirect("GamePage.aspx?Username=Guest");
        }
    }
}