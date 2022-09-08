namespace Prototype7
{
    partial class AnalysisForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnPrintToFile = new System.Windows.Forms.Button();
            this.dataGridGames = new System.Windows.Forms.DataGridView();
            this.databaseConnectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseConnectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrintToFile
            // 
            this.btnPrintToFile.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnPrintToFile.FlatAppearance.BorderSize = 0;
            this.btnPrintToFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintToFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPrintToFile.ForeColor = System.Drawing.Color.White;
            this.btnPrintToFile.Location = new System.Drawing.Point(12, 12);
            this.btnPrintToFile.Name = "btnPrintToFile";
            this.btnPrintToFile.Size = new System.Drawing.Size(105, 32);
            this.btnPrintToFile.TabIndex = 0;
            this.btnPrintToFile.Text = "Print to File";
            this.btnPrintToFile.UseVisualStyleBackColor = false;
            this.btnPrintToFile.Click += new System.EventHandler(this.btnPrintToFile_Click);
            // 
            // dataGridGames
            // 
            this.dataGridGames.AutoGenerateColumns = false;
            this.dataGridGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridGames.DataSource = this.databaseConnectionBindingSource;
            this.dataGridGames.Location = new System.Drawing.Point(12, 50);
            this.dataGridGames.Name = "dataGridGames";
            this.dataGridGames.RowTemplate.Height = 25;
            this.dataGridGames.Size = new System.Drawing.Size(578, 388);
            this.dataGridGames.TabIndex = 1;
            // 
            // databaseConnectionBindingSource
            // 
            this.databaseConnectionBindingSource.DataSource = typeof(Prototype7.Database.DatabaseConnection);
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(716, 450);
            this.Controls.Add(this.dataGridGames);
            this.Controls.Add(this.btnPrintToFile);
            this.Name = "AnalysisForm";
            this.Text = "AnalysisForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseConnectionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrintToFile;
        private System.Windows.Forms.DataGridView dataGridGames;
        private System.Windows.Forms.BindingSource databaseConnectionBindingSource;
    }
}