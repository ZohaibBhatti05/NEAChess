using Prototype7.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype7
{
    public partial class AnalysisForm : Form
    {
        private string username;

        public AnalysisForm(string username)
        {
            this.username = username;
            InitializeComponent();

            InitialiseDataGrid();
        }

        private void InitialiseDataGrid()
        {
            
        }

        private void btnPrintToFile_Click(object sender, EventArgs e)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            dbConnection.SaveGameHistory(username);
        }
    }
}
