using Prototype7.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
        private DatabaseConnection dbConnection = new DatabaseConnection();
        private CreateAnalysisCallback callback;

        public AnalysisForm(string username, CreateAnalysisCallback analysisCallback)
        {
            this.username = username;
            callback = analysisCallback;

            InitializeComponent();

            InitialiseDataGrid();
        }

        // loads game data into the data grid view control
        private void InitialiseDataGrid()
        {
            List<string[]> gameData = dbConnection.GetGameHistory(username); // get all game data for user

            foreach (string[] record in gameData)
            {
                dataGridGames.Rows.Add(record[0], record[1], record[2], record[3], record[4]); // display record in datagrid
            }
        }

        // logs all game data in formatted pgn to a file of users choice
        private void btnPrintToFile_Click(object sender, EventArgs e)
        {
            dbConnection.SaveGameHistory(username);
        }

        // callback to game form to run analysis
        private void dataGridGames_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = (sender as DataGridView).CurrentRow;

            string FEN = row.Cells[3].Value.ToString();
            string PGN = row.Cells[4].Value.ToString();

            callback.Invoke(FEN, PGN);
            this.Close();
        }
    }
}
