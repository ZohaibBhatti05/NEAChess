using Prototype8.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Prototype8
{
    public partial class AnalysisPage : System.Web.UI.Page
    {
        private string username;
        private DatabaseConnection dbConnection = new DatabaseConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            username = Session["username"].ToString();
            if (!this.IsPostBack)
            {
                InitialiseDataGrid();
            }
        }

        // method binds data to griview
        private void InitialiseDataGrid()
        {
            OleDbCommand command = dbConnection.GetGameHistory(username); // get all game data for user
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);

            using (DataTable dt = new DataTable())
            {
                dataAdapter.Fill(dt);
                dataGridGames.DataSource = dt;
                dataGridGames.DataBind();
            }
        }


        protected void dataGridGame_OnRowBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(dataGridGames, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(dataGridGames, "Edit$" + e.Row.RowIndex);
            }
        }

        // method run whenever a row is double clicked
        protected void dataGridGames_OnRowEdit(object sender, GridViewEditEventArgs e)
        {
            (string FEN, string PGN) data = dbConnection.GetAnalysisData(username, dataGridGames.SelectedIndex);

            Session["FEN"] = data.FEN;
            Session["PGN"] = data.PGN;

            Session["IsAnalysisPostback"] = true;
            Server.Transfer("GamePage.aspx");
        }


        protected void dataGridGames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}