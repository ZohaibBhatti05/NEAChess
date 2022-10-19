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


        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(dataGridGames, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }


        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in dataGridGames.Rows)
            {
                if (row.RowIndex == dataGridGames.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

    }
}