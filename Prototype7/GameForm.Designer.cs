
namespace Prototype7
{
    partial class GameForm
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
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.pnlPreGame = new System.Windows.Forms.Panel();
            this.pnlPosition = new System.Windows.Forms.Panel();
            this.textFEN = new System.Windows.Forms.TextBox();
            this.radFEN = new System.Windows.Forms.RadioButton();
            this.radDefaultPosition = new System.Windows.Forms.RadioButton();
            this.lblPosition = new System.Windows.Forms.Label();
            this.pnlTimeControl = new System.Windows.Forms.Panel();
            this.radNoTimers = new System.Windows.Forms.RadioButton();
            this.pnlCustomTime = new System.Windows.Forms.Panel();
            this.textMinutes = new System.Windows.Forms.TextBox();
            this.textSeconds = new System.Windows.Forms.TextBox();
            this.textIncrement = new System.Windows.Forms.TextBox();
            this.radCustomTime = new System.Windows.Forms.RadioButton();
            this.radPresetTime = new System.Windows.Forms.RadioButton();
            this.cmbTimeSettings = new System.Windows.Forms.ComboBox();
            this.lblTimeControl = new System.Windows.Forms.Label();
            this.pnlVariants = new System.Windows.Forms.Panel();
            this.cmbVariant = new System.Windows.Forms.ComboBox();
            this.lblVariant = new System.Windows.Forms.Label();
            this.pnlPlayerOptions = new System.Windows.Forms.Panel();
            this.pnlAISettings = new System.Windows.Forms.Panel();
            this.checkUseTT = new System.Windows.Forms.CheckBox();
            this.lblPlyDepth = new System.Windows.Forms.Label();
            this.lblDepth = new System.Windows.Forms.Label();
            this.trackPlyDepth = new System.Windows.Forms.TrackBar();
            this.radAgainstAI = new System.Windows.Forms.RadioButton();
            this.radAgainstHuman = new System.Windows.Forms.RadioButton();
            this.lblPlayAgainst = new System.Windows.Forms.Label();
            this.pnlDuringGame = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBlackMoves = new System.Windows.Forms.TextBox();
            this.txtWhiteMoves = new System.Windows.Forms.TextBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnResign = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.pnlBlackUI = new System.Windows.Forms.Panel();
            this.lblWhiteTaken = new System.Windows.Forms.Label();
            this.pnlBlackTime = new System.Windows.Forms.Panel();
            this.picBlackTime = new System.Windows.Forms.PictureBox();
            this.lblBlackTime = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblBlackTaken = new System.Windows.Forms.Label();
            this.pnlWhiteTime = new System.Windows.Forms.Panel();
            this.picWhiteTime = new System.Windows.Forms.PictureBox();
            this.lblWhiteTime = new System.Windows.Forms.Label();
            this.timerUpdateTime = new System.Windows.Forms.Timer(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbPieceSet = new System.Windows.Forms.ToolStripComboBox();
            this.coloursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colourMenuC1 = new System.Windows.Forms.ToolStripMenuItem();
            this.colourMenuC2 = new System.Windows.Forms.ToolStripMenuItem();
            this.colourMenuMove = new System.Windows.Forms.ToolStripMenuItem();
            this.colourMenuSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuResetColour = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPreviousGames = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.lblRank1 = new System.Windows.Forms.Label();
            this.lblRank2 = new System.Windows.Forms.Label();
            this.lblRank4 = new System.Windows.Forms.Label();
            this.lblRank3 = new System.Windows.Forms.Label();
            this.lblRank8 = new System.Windows.Forms.Label();
            this.lblRank7 = new System.Windows.Forms.Label();
            this.lblRank6 = new System.Windows.Forms.Label();
            this.lblRank5 = new System.Windows.Forms.Label();
            this.lblFile1 = new System.Windows.Forms.Label();
            this.lblFile2 = new System.Windows.Forms.Label();
            this.lblFile4 = new System.Windows.Forms.Label();
            this.lblFile3 = new System.Windows.Forms.Label();
            this.lblFile8 = new System.Windows.Forms.Label();
            this.lblFile7 = new System.Windows.Forms.Label();
            this.lblFile6 = new System.Windows.Forms.Label();
            this.lblFile5 = new System.Windows.Forms.Label();
            this.lblAnalysisMove = new System.Windows.Forms.Label();
            this.pnlPreGame.SuspendLayout();
            this.pnlPosition.SuspendLayout();
            this.pnlTimeControl.SuspendLayout();
            this.pnlCustomTime.SuspendLayout();
            this.pnlVariants.SuspendLayout();
            this.pnlPlayerOptions.SuspendLayout();
            this.pnlAISettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackPlyDepth)).BeginInit();
            this.pnlDuringGame.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlBlackUI.SuspendLayout();
            this.pnlBlackTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBlackTime)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlWhiteTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWhiteTime)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.AutoSize = true;
            this.pnlBoard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlBoard.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlBoard.Location = new System.Drawing.Point(38, 118);
            this.pnlBoard.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBoard.MinimumSize = new System.Drawing.Size(600, 600);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(600, 600);
            this.pnlBoard.TabIndex = 0;
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.ForestGreen;
            this.btnStartGame.FlatAppearance.BorderSize = 0;
            this.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartGame.Font = new System.Drawing.Font("Bahnschrift", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStartGame.ForeColor = System.Drawing.Color.White;
            this.btnStartGame.Location = new System.Drawing.Point(3, 662);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(294, 82);
            this.btnStartGame.TabIndex = 1;
            this.btnStartGame.Text = "START GAME";
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // pnlPreGame
            // 
            this.pnlPreGame.Controls.Add(this.pnlPosition);
            this.pnlPreGame.Controls.Add(this.pnlTimeControl);
            this.pnlPreGame.Controls.Add(this.pnlVariants);
            this.pnlPreGame.Controls.Add(this.pnlPlayerOptions);
            this.pnlPreGame.Controls.Add(this.btnStartGame);
            this.pnlPreGame.Location = new System.Drawing.Point(641, 56);
            this.pnlPreGame.Name = "pnlPreGame";
            this.pnlPreGame.Size = new System.Drawing.Size(300, 747);
            this.pnlPreGame.TabIndex = 5;
            // 
            // pnlPosition
            // 
            this.pnlPosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlPosition.Controls.Add(this.textFEN);
            this.pnlPosition.Controls.Add(this.radFEN);
            this.pnlPosition.Controls.Add(this.radDefaultPosition);
            this.pnlPosition.Controls.Add(this.lblPosition);
            this.pnlPosition.Location = new System.Drawing.Point(3, 531);
            this.pnlPosition.Name = "pnlPosition";
            this.pnlPosition.Size = new System.Drawing.Size(294, 125);
            this.pnlPosition.TabIndex = 5;
            // 
            // textFEN
            // 
            this.textFEN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.textFEN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textFEN.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textFEN.ForeColor = System.Drawing.Color.White;
            this.textFEN.Location = new System.Drawing.Point(6, 88);
            this.textFEN.Name = "textFEN";
            this.textFEN.Size = new System.Drawing.Size(282, 16);
            this.textFEN.TabIndex = 10;
            this.textFEN.Visible = false;
            // 
            // radFEN
            // 
            this.radFEN.AutoSize = true;
            this.radFEN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radFEN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.radFEN.Location = new System.Drawing.Point(6, 54);
            this.radFEN.Name = "radFEN";
            this.radFEN.Size = new System.Drawing.Size(77, 21);
            this.radFEN.TabIndex = 9;
            this.radFEN.Text = "Custom:";
            this.radFEN.UseVisualStyleBackColor = true;
            // 
            // radDefaultPosition
            // 
            this.radDefaultPosition.AutoSize = true;
            this.radDefaultPosition.Checked = true;
            this.radDefaultPosition.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radDefaultPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.radDefaultPosition.Location = new System.Drawing.Point(6, 29);
            this.radDefaultPosition.Name = "radDefaultPosition";
            this.radDefaultPosition.Size = new System.Drawing.Size(72, 21);
            this.radDefaultPosition.TabIndex = 8;
            this.radDefaultPosition.TabStop = true;
            this.radDefaultPosition.Text = "Default";
            this.radDefaultPosition.UseVisualStyleBackColor = true;
            this.radDefaultPosition.CheckedChanged += new System.EventHandler(this.radDefaultPosition_CheckedChanged);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPosition.ForeColor = System.Drawing.Color.White;
            this.lblPosition.Location = new System.Drawing.Point(3, 3);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(3);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(70, 20);
            this.lblPosition.TabIndex = 1;
            this.lblPosition.Text = "Position:";
            // 
            // pnlTimeControl
            // 
            this.pnlTimeControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlTimeControl.Controls.Add(this.radNoTimers);
            this.pnlTimeControl.Controls.Add(this.pnlCustomTime);
            this.pnlTimeControl.Controls.Add(this.radCustomTime);
            this.pnlTimeControl.Controls.Add(this.radPresetTime);
            this.pnlTimeControl.Controls.Add(this.cmbTimeSettings);
            this.pnlTimeControl.Controls.Add(this.lblTimeControl);
            this.pnlTimeControl.Location = new System.Drawing.Point(3, 214);
            this.pnlTimeControl.Name = "pnlTimeControl";
            this.pnlTimeControl.Size = new System.Drawing.Size(294, 223);
            this.pnlTimeControl.TabIndex = 4;
            // 
            // radNoTimers
            // 
            this.radNoTimers.AutoSize = true;
            this.radNoTimers.Checked = true;
            this.radNoTimers.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radNoTimers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.radNoTimers.Location = new System.Drawing.Point(7, 33);
            this.radNoTimers.Name = "radNoTimers";
            this.radNoTimers.Size = new System.Drawing.Size(87, 21);
            this.radNoTimers.TabIndex = 7;
            this.radNoTimers.TabStop = true;
            this.radNoTimers.Text = "Unlimited";
            this.radNoTimers.UseVisualStyleBackColor = true;
            this.radNoTimers.CheckedChanged += new System.EventHandler(this.timeRadioButton_CheckChanged);
            // 
            // pnlCustomTime
            // 
            this.pnlCustomTime.Controls.Add(this.textMinutes);
            this.pnlCustomTime.Controls.Add(this.textSeconds);
            this.pnlCustomTime.Controls.Add(this.textIncrement);
            this.pnlCustomTime.Location = new System.Drawing.Point(3, 167);
            this.pnlCustomTime.Name = "pnlCustomTime";
            this.pnlCustomTime.Size = new System.Drawing.Size(286, 33);
            this.pnlCustomTime.TabIndex = 6;
            // 
            // textMinutes
            // 
            this.textMinutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.textMinutes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textMinutes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textMinutes.ForeColor = System.Drawing.Color.White;
            this.textMinutes.Location = new System.Drawing.Point(16, 4);
            this.textMinutes.Name = "textMinutes";
            this.textMinutes.PlaceholderText = "minutes";
            this.textMinutes.Size = new System.Drawing.Size(80, 25);
            this.textMinutes.TabIndex = 3;
            this.textMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.customTimeTextBox_KeyPress);
            // 
            // textSeconds
            // 
            this.textSeconds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.textSeconds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textSeconds.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textSeconds.ForeColor = System.Drawing.Color.White;
            this.textSeconds.Location = new System.Drawing.Point(102, 4);
            this.textSeconds.Name = "textSeconds";
            this.textSeconds.PlaceholderText = "seconds";
            this.textSeconds.Size = new System.Drawing.Size(80, 25);
            this.textSeconds.TabIndex = 4;
            this.textSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textSeconds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.customTimeTextBox_KeyPress);
            // 
            // textIncrement
            // 
            this.textIncrement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.textIncrement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textIncrement.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textIncrement.ForeColor = System.Drawing.Color.White;
            this.textIncrement.Location = new System.Drawing.Point(188, 4);
            this.textIncrement.Name = "textIncrement";
            this.textIncrement.PlaceholderText = "increment";
            this.textIncrement.Size = new System.Drawing.Size(80, 25);
            this.textIncrement.TabIndex = 5;
            this.textIncrement.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textIncrement.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.customTimeTextBox_KeyPress);
            // 
            // radCustomTime
            // 
            this.radCustomTime.AutoSize = true;
            this.radCustomTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radCustomTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.radCustomTime.Location = new System.Drawing.Point(7, 140);
            this.radCustomTime.Name = "radCustomTime";
            this.radCustomTime.Size = new System.Drawing.Size(77, 21);
            this.radCustomTime.TabIndex = 5;
            this.radCustomTime.Text = "Custom:";
            this.radCustomTime.UseVisualStyleBackColor = true;
            this.radCustomTime.CheckedChanged += new System.EventHandler(this.timeRadioButton_CheckChanged);
            // 
            // radPresetTime
            // 
            this.radPresetTime.AutoSize = true;
            this.radPresetTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radPresetTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.radPresetTime.Location = new System.Drawing.Point(7, 70);
            this.radPresetTime.Name = "radPresetTime";
            this.radPresetTime.Size = new System.Drawing.Size(68, 21);
            this.radPresetTime.TabIndex = 4;
            this.radPresetTime.Text = "Preset:";
            this.radPresetTime.UseVisualStyleBackColor = true;
            this.radPresetTime.CheckedChanged += new System.EventHandler(this.timeRadioButton_CheckChanged);
            // 
            // cmbTimeSettings
            // 
            this.cmbTimeSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmbTimeSettings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbTimeSettings.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbTimeSettings.ForeColor = System.Drawing.Color.White;
            this.cmbTimeSettings.FormattingEnabled = true;
            this.cmbTimeSettings.Items.AddRange(new object[] {
            "1 min",
            "10 min",
            "20 min",
            "60 min",
            "15 | 10",
            "10 | 5",
            "3 | 2",
            "1 | 1"});
            this.cmbTimeSettings.Location = new System.Drawing.Point(7, 97);
            this.cmbTimeSettings.Name = "cmbTimeSettings";
            this.cmbTimeSettings.Size = new System.Drawing.Size(136, 25);
            this.cmbTimeSettings.TabIndex = 1;
            // 
            // lblTimeControl
            // 
            this.lblTimeControl.AutoSize = true;
            this.lblTimeControl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTimeControl.ForeColor = System.Drawing.Color.White;
            this.lblTimeControl.Location = new System.Drawing.Point(3, 4);
            this.lblTimeControl.Margin = new System.Windows.Forms.Padding(3);
            this.lblTimeControl.Name = "lblTimeControl";
            this.lblTimeControl.Size = new System.Drawing.Size(48, 20);
            this.lblTimeControl.TabIndex = 0;
            this.lblTimeControl.Text = "Time:";
            // 
            // pnlVariants
            // 
            this.pnlVariants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlVariants.Controls.Add(this.cmbVariant);
            this.pnlVariants.Controls.Add(this.lblVariant);
            this.pnlVariants.Location = new System.Drawing.Point(3, 443);
            this.pnlVariants.Name = "pnlVariants";
            this.pnlVariants.Size = new System.Drawing.Size(294, 82);
            this.pnlVariants.TabIndex = 3;
            // 
            // cmbVariant
            // 
            this.cmbVariant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmbVariant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVariant.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbVariant.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbVariant.ForeColor = System.Drawing.Color.White;
            this.cmbVariant.FormattingEnabled = true;
            this.cmbVariant.Items.AddRange(new object[] {
            "Standard",
            "Chess960",
            "Antichess",
            "Three-Check"});
            this.cmbVariant.Location = new System.Drawing.Point(7, 34);
            this.cmbVariant.Name = "cmbVariant";
            this.cmbVariant.Size = new System.Drawing.Size(136, 25);
            this.cmbVariant.TabIndex = 8;
            // 
            // lblVariant
            // 
            this.lblVariant.AutoSize = true;
            this.lblVariant.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblVariant.ForeColor = System.Drawing.Color.White;
            this.lblVariant.Location = new System.Drawing.Point(3, 3);
            this.lblVariant.Margin = new System.Windows.Forms.Padding(3);
            this.lblVariant.Name = "lblVariant";
            this.lblVariant.Size = new System.Drawing.Size(63, 20);
            this.lblVariant.TabIndex = 0;
            this.lblVariant.Text = "Variant:";
            // 
            // pnlPlayerOptions
            // 
            this.pnlPlayerOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlPlayerOptions.Controls.Add(this.pnlAISettings);
            this.pnlPlayerOptions.Controls.Add(this.radAgainstAI);
            this.pnlPlayerOptions.Controls.Add(this.radAgainstHuman);
            this.pnlPlayerOptions.Controls.Add(this.lblPlayAgainst);
            this.pnlPlayerOptions.Location = new System.Drawing.Point(3, 3);
            this.pnlPlayerOptions.Name = "pnlPlayerOptions";
            this.pnlPlayerOptions.Size = new System.Drawing.Size(294, 205);
            this.pnlPlayerOptions.TabIndex = 2;
            // 
            // pnlAISettings
            // 
            this.pnlAISettings.Controls.Add(this.checkUseTT);
            this.pnlAISettings.Controls.Add(this.lblPlyDepth);
            this.pnlAISettings.Controls.Add(this.lblDepth);
            this.pnlAISettings.Controls.Add(this.trackPlyDepth);
            this.pnlAISettings.ForeColor = System.Drawing.Color.White;
            this.pnlAISettings.Location = new System.Drawing.Point(3, 82);
            this.pnlAISettings.Name = "pnlAISettings";
            this.pnlAISettings.Size = new System.Drawing.Size(288, 120);
            this.pnlAISettings.TabIndex = 3;
            this.pnlAISettings.Visible = false;
            // 
            // checkUseTT
            // 
            this.checkUseTT.AutoSize = true;
            this.checkUseTT.Checked = true;
            this.checkUseTT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkUseTT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.checkUseTT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.checkUseTT.Location = new System.Drawing.Point(9, 89);
            this.checkUseTT.Name = "checkUseTT";
            this.checkUseTT.Size = new System.Drawing.Size(174, 21);
            this.checkUseTT.TabIndex = 4;
            this.checkUseTT.Text = "Use Transposition Table";
            this.checkUseTT.UseVisualStyleBackColor = true;
            // 
            // lblPlyDepth
            // 
            this.lblPlyDepth.AutoSize = true;
            this.lblPlyDepth.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPlyDepth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.lblPlyDepth.Location = new System.Drawing.Point(78, 14);
            this.lblPlyDepth.Name = "lblPlyDepth";
            this.lblPlyDepth.Size = new System.Drawing.Size(15, 17);
            this.lblPlyDepth.TabIndex = 2;
            this.lblPlyDepth.Text = "4";
            // 
            // lblDepth
            // 
            this.lblDepth.AutoSize = true;
            this.lblDepth.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDepth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.lblDepth.Location = new System.Drawing.Point(6, 14);
            this.lblDepth.Margin = new System.Windows.Forms.Padding(3);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(73, 17);
            this.lblDepth.TabIndex = 1;
            this.lblDepth.Text = "Ply Depth:";
            // 
            // trackPlyDepth
            // 
            this.trackPlyDepth.LargeChange = 1;
            this.trackPlyDepth.Location = new System.Drawing.Point(3, 37);
            this.trackPlyDepth.Maximum = 8;
            this.trackPlyDepth.Minimum = 1;
            this.trackPlyDepth.Name = "trackPlyDepth";
            this.trackPlyDepth.Size = new System.Drawing.Size(282, 45);
            this.trackPlyDepth.TabIndex = 0;
            this.trackPlyDepth.Value = 4;
            this.trackPlyDepth.ValueChanged += new System.EventHandler(this.trackPlyDepth_ValueChanged);
            // 
            // radAgainstAI
            // 
            this.radAgainstAI.AutoSize = true;
            this.radAgainstAI.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radAgainstAI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.radAgainstAI.Location = new System.Drawing.Point(9, 55);
            this.radAgainstAI.Name = "radAgainstAI";
            this.radAgainstAI.Size = new System.Drawing.Size(87, 21);
            this.radAgainstAI.TabIndex = 2;
            this.radAgainstAI.Text = "Computer";
            this.radAgainstAI.UseVisualStyleBackColor = true;
            this.radAgainstAI.CheckedChanged += new System.EventHandler(this.radAgainstAI_CheckedChanged);
            // 
            // radAgainstHuman
            // 
            this.radAgainstHuman.AutoSize = true;
            this.radAgainstHuman.Checked = true;
            this.radAgainstHuman.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radAgainstHuman.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.radAgainstHuman.Location = new System.Drawing.Point(9, 28);
            this.radAgainstHuman.Name = "radAgainstHuman";
            this.radAgainstHuman.Size = new System.Drawing.Size(71, 21);
            this.radAgainstHuman.TabIndex = 1;
            this.radAgainstHuman.TabStop = true;
            this.radAgainstHuman.Text = "Human";
            this.radAgainstHuman.UseVisualStyleBackColor = true;
            // 
            // lblPlayAgainst
            // 
            this.lblPlayAgainst.AutoSize = true;
            this.lblPlayAgainst.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPlayAgainst.ForeColor = System.Drawing.Color.White;
            this.lblPlayAgainst.Location = new System.Drawing.Point(3, 3);
            this.lblPlayAgainst.Margin = new System.Windows.Forms.Padding(3);
            this.lblPlayAgainst.Name = "lblPlayAgainst";
            this.lblPlayAgainst.Size = new System.Drawing.Size(100, 20);
            this.lblPlayAgainst.TabIndex = 0;
            this.lblPlayAgainst.Text = "Play Against:";
            // 
            // pnlDuringGame
            // 
            this.pnlDuringGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlDuringGame.Controls.Add(this.panel1);
            this.pnlDuringGame.Controls.Add(this.btnDraw);
            this.pnlDuringGame.Controls.Add(this.btnResign);
            this.pnlDuringGame.Controls.Add(this.btnUndo);
            this.pnlDuringGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlDuringGame.Location = new System.Drawing.Point(641, 56);
            this.pnlDuringGame.Name = "pnlDuringGame";
            this.pnlDuringGame.Size = new System.Drawing.Size(300, 747);
            this.pnlDuringGame.TabIndex = 6;
            this.pnlDuringGame.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.lblAnalysisMove);
            this.panel1.Controls.Add(this.txtBlackMoves);
            this.panel1.Controls.Add(this.txtWhiteMoves);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 680);
            this.panel1.TabIndex = 4;
            // 
            // txtBlackMoves
            // 
            this.txtBlackMoves.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtBlackMoves.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBlackMoves.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtBlackMoves.ForeColor = System.Drawing.Color.White;
            this.txtBlackMoves.Location = new System.Drawing.Point(109, 3);
            this.txtBlackMoves.Multiline = true;
            this.txtBlackMoves.Name = "txtBlackMoves";
            this.txtBlackMoves.ReadOnly = true;
            this.txtBlackMoves.Size = new System.Drawing.Size(100, 674);
            this.txtBlackMoves.TabIndex = 1;
            // 
            // txtWhiteMoves
            // 
            this.txtWhiteMoves.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtWhiteMoves.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWhiteMoves.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtWhiteMoves.ForeColor = System.Drawing.Color.White;
            this.txtWhiteMoves.Location = new System.Drawing.Point(3, 3);
            this.txtWhiteMoves.Multiline = true;
            this.txtWhiteMoves.Name = "txtWhiteMoves";
            this.txtWhiteMoves.ReadOnly = true;
            this.txtWhiteMoves.Size = new System.Drawing.Size(100, 674);
            this.txtWhiteMoves.TabIndex = 0;
            // 
            // btnDraw
            // 
            this.btnDraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnDraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDraw.FlatAppearance.BorderSize = 0;
            this.btnDraw.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDraw.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDraw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.btnDraw.Location = new System.Drawing.Point(200, 688);
            this.btnDraw.Margin = new System.Windows.Forms.Padding(2);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(98, 56);
            this.btnDraw.TabIndex = 3;
            this.btnDraw.Text = "½ ½";
            this.btnDraw.UseVisualStyleBackColor = false;
            // 
            // btnResign
            // 
            this.btnResign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnResign.BackgroundImage = global::Prototype7.Properties.Resources.Flag;
            this.btnResign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnResign.FlatAppearance.BorderSize = 0;
            this.btnResign.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnResign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResign.Location = new System.Drawing.Point(100, 688);
            this.btnResign.Margin = new System.Windows.Forms.Padding(2);
            this.btnResign.Name = "btnResign";
            this.btnResign.Size = new System.Drawing.Size(96, 56);
            this.btnResign.TabIndex = 2;
            this.btnResign.UseVisualStyleBackColor = false;
            this.btnResign.Click += new System.EventHandler(this.btnResign_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnUndo.BackgroundImage = global::Prototype7.Properties.Resources.Undo;
            this.btnUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUndo.FlatAppearance.BorderSize = 0;
            this.btnUndo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Location = new System.Drawing.Point(2, 688);
            this.btnUndo.Margin = new System.Windows.Forms.Padding(2);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(94, 56);
            this.btnUndo.TabIndex = 1;
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndoMove_Click);
            // 
            // pnlBlackUI
            // 
            this.pnlBlackUI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlBlackUI.Controls.Add(this.lblWhiteTaken);
            this.pnlBlackUI.Controls.Add(this.pnlBlackTime);
            this.pnlBlackUI.Location = new System.Drawing.Point(38, 56);
            this.pnlBlackUI.Name = "pnlBlackUI";
            this.pnlBlackUI.Size = new System.Drawing.Size(600, 60);
            this.pnlBlackUI.TabIndex = 7;
            // 
            // lblWhiteTaken
            // 
            this.lblWhiteTaken.AutoSize = true;
            this.lblWhiteTaken.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWhiteTaken.ForeColor = System.Drawing.Color.White;
            this.lblWhiteTaken.Location = new System.Drawing.Point(172, 12);
            this.lblWhiteTaken.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblWhiteTaken.Name = "lblWhiteTaken";
            this.lblWhiteTaken.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblWhiteTaken.Size = new System.Drawing.Size(0, 37);
            this.lblWhiteTaken.TabIndex = 3;
            this.lblWhiteTaken.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlBlackTime
            // 
            this.pnlBlackTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlBlackTime.Controls.Add(this.picBlackTime);
            this.pnlBlackTime.Controls.Add(this.lblBlackTime);
            this.pnlBlackTime.Location = new System.Drawing.Point(3, 4);
            this.pnlBlackTime.Name = "pnlBlackTime";
            this.pnlBlackTime.Size = new System.Drawing.Size(165, 53);
            this.pnlBlackTime.TabIndex = 2;
            // 
            // picBlackTime
            // 
            this.picBlackTime.Image = global::Prototype7.Properties.Resources.Timer;
            this.picBlackTime.Location = new System.Drawing.Point(3, 3);
            this.picBlackTime.Name = "picBlackTime";
            this.picBlackTime.Size = new System.Drawing.Size(47, 47);
            this.picBlackTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBlackTime.TabIndex = 1;
            this.picBlackTime.TabStop = false;
            // 
            // lblBlackTime
            // 
            this.lblBlackTime.AutoSize = true;
            this.lblBlackTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBlackTime.ForeColor = System.Drawing.Color.White;
            this.lblBlackTime.Location = new System.Drawing.Point(59, 17);
            this.lblBlackTime.Margin = new System.Windows.Forms.Padding(3);
            this.lblBlackTime.Name = "lblBlackTime";
            this.lblBlackTime.Size = new System.Drawing.Size(0, 21);
            this.lblBlackTime.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.panel2.Controls.Add(this.lblBlackTaken);
            this.panel2.Controls.Add(this.pnlWhiteTime);
            this.panel2.Location = new System.Drawing.Point(38, 743);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 60);
            this.panel2.TabIndex = 8;
            // 
            // lblBlackTaken
            // 
            this.lblBlackTaken.AutoSize = true;
            this.lblBlackTaken.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBlackTaken.ForeColor = System.Drawing.Color.White;
            this.lblBlackTaken.Location = new System.Drawing.Point(172, 12);
            this.lblBlackTaken.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblBlackTaken.Name = "lblBlackTaken";
            this.lblBlackTaken.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBlackTaken.Size = new System.Drawing.Size(0, 37);
            this.lblBlackTaken.TabIndex = 2;
            this.lblBlackTaken.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlWhiteTime
            // 
            this.pnlWhiteTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlWhiteTime.Controls.Add(this.picWhiteTime);
            this.pnlWhiteTime.Controls.Add(this.lblWhiteTime);
            this.pnlWhiteTime.Location = new System.Drawing.Point(3, 4);
            this.pnlWhiteTime.Name = "pnlWhiteTime";
            this.pnlWhiteTime.Size = new System.Drawing.Size(165, 53);
            this.pnlWhiteTime.TabIndex = 1;
            // 
            // picWhiteTime
            // 
            this.picWhiteTime.Image = global::Prototype7.Properties.Resources.Timer;
            this.picWhiteTime.Location = new System.Drawing.Point(3, 3);
            this.picWhiteTime.Name = "picWhiteTime";
            this.picWhiteTime.Size = new System.Drawing.Size(47, 47);
            this.picWhiteTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWhiteTime.TabIndex = 1;
            this.picWhiteTime.TabStop = false;
            // 
            // lblWhiteTime
            // 
            this.lblWhiteTime.AutoSize = true;
            this.lblWhiteTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWhiteTime.ForeColor = System.Drawing.Color.White;
            this.lblWhiteTime.Location = new System.Drawing.Point(59, 17);
            this.lblWhiteTime.Margin = new System.Windows.Forms.Padding(3);
            this.lblWhiteTime.Name = "lblWhiteTime";
            this.lblWhiteTime.Size = new System.Drawing.Size(0, 21);
            this.lblWhiteTime.TabIndex = 0;
            // 
            // timerUpdateTime
            // 
            this.timerUpdateTime.Interval = 10;
            this.timerUpdateTime.Tick += new System.EventHandler(this.timerUpdateTime_Tick);
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSettings,
            this.menuPreviousGames});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1677, 24);
            this.menuStrip.TabIndex = 9;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripSettings
            // 
            this.toolStripSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imagesToolStripMenuItem,
            this.coloursToolStripMenuItem});
            this.toolStripSettings.Name = "toolStripSettings";
            this.toolStripSettings.Size = new System.Drawing.Size(61, 20);
            this.toolStripSettings.Text = "Options";
            // 
            // imagesToolStripMenuItem
            // 
            this.imagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbPieceSet});
            this.imagesToolStripMenuItem.Name = "imagesToolStripMenuItem";
            this.imagesToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.imagesToolStripMenuItem.Text = "Images";
            // 
            // cmbPieceSet
            // 
            this.cmbPieceSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPieceSet.Items.AddRange(new object[] {
            "Alpha",
            "Anarcandy",
            "California",
            "Cardinal",
            "Cburnett",
            "Chess7",
            "Chessnut",
            "Companion",
            "Dubrovny",
            "Fantasy",
            "Fresca",
            "Gioco",
            "Governor",
            "Horsey",
            "Icpieces",
            "Kosal",
            "Leipzig",
            "Letter",
            "Libra",
            "Maestro",
            "Merida",
            "Mono",
            "Pirouetti",
            "Pixel",
            "Reillycraig",
            "Riohacha",
            "Shapes",
            "Standard",
            "Spatial",
            "Staunty",
            "Tatiana"});
            this.cmbPieceSet.Name = "cmbPieceSet";
            this.cmbPieceSet.Size = new System.Drawing.Size(121, 23);
            this.cmbPieceSet.SelectedIndexChanged += new System.EventHandler(this.cmbPieceSet_SelectedIndexChanged);
            // 
            // coloursToolStripMenuItem
            // 
            this.coloursToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colourMenuC1,
            this.colourMenuC2,
            this.colourMenuMove,
            this.colourMenuSelect,
            this.menuResetColour});
            this.coloursToolStripMenuItem.Name = "coloursToolStripMenuItem";
            this.coloursToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.coloursToolStripMenuItem.Text = "Colours";
            // 
            // colourMenuC1
            // 
            this.colourMenuC1.BackColor = System.Drawing.SystemColors.Control;
            this.colourMenuC1.Name = "colourMenuC1";
            this.colourMenuC1.Size = new System.Drawing.Size(161, 22);
            this.colourMenuC1.Text = "Cell Colour 1";
            this.colourMenuC1.Click += new System.EventHandler(this.menuColourC1_Click);
            // 
            // colourMenuC2
            // 
            this.colourMenuC2.Name = "colourMenuC2";
            this.colourMenuC2.Size = new System.Drawing.Size(161, 22);
            this.colourMenuC2.Text = "Cell Colour 2";
            this.colourMenuC2.Click += new System.EventHandler(this.menuColourC2_Click);
            // 
            // colourMenuMove
            // 
            this.colourMenuMove.Name = "colourMenuMove";
            this.colourMenuMove.Size = new System.Drawing.Size(161, 22);
            this.colourMenuMove.Text = "Move Colour";
            this.colourMenuMove.Click += new System.EventHandler(this.menuColourMove_Click);
            // 
            // colourMenuSelect
            // 
            this.colourMenuSelect.Name = "colourMenuSelect";
            this.colourMenuSelect.Size = new System.Drawing.Size(161, 22);
            this.colourMenuSelect.Text = "Selection Colour";
            this.colourMenuSelect.Click += new System.EventHandler(this.menuColourSelect_Click);
            // 
            // menuResetColour
            // 
            this.menuResetColour.Name = "menuResetColour";
            this.menuResetColour.Size = new System.Drawing.Size(161, 22);
            this.menuResetColour.Text = "Reset To Default";
            this.menuResetColour.Click += new System.EventHandler(this.menuResetColour_Click);
            // 
            // menuPreviousGames
            // 
            this.menuPreviousGames.Name = "menuPreviousGames";
            this.menuPreviousGames.Size = new System.Drawing.Size(100, 20);
            this.menuPreviousGames.Text = "PreviousGames";
            this.menuPreviousGames.Click += new System.EventHandler(this.menuPreviousGames_Click);
            // 
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            // 
            // lblRank1
            // 
            this.lblRank1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRank1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRank1.ForeColor = System.Drawing.Color.White;
            this.lblRank1.Location = new System.Drawing.Point(13, 643);
            this.lblRank1.Name = "lblRank1";
            this.lblRank1.Size = new System.Drawing.Size(22, 75);
            this.lblRank1.TabIndex = 10;
            this.lblRank1.Text = "1";
            this.lblRank1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRank2
            // 
            this.lblRank2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRank2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRank2.ForeColor = System.Drawing.Color.White;
            this.lblRank2.Location = new System.Drawing.Point(13, 568);
            this.lblRank2.Name = "lblRank2";
            this.lblRank2.Size = new System.Drawing.Size(22, 75);
            this.lblRank2.TabIndex = 11;
            this.lblRank2.Text = "2";
            this.lblRank2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRank4
            // 
            this.lblRank4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRank4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRank4.ForeColor = System.Drawing.Color.White;
            this.lblRank4.Location = new System.Drawing.Point(13, 418);
            this.lblRank4.Name = "lblRank4";
            this.lblRank4.Size = new System.Drawing.Size(22, 75);
            this.lblRank4.TabIndex = 13;
            this.lblRank4.Text = "4";
            this.lblRank4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRank3
            // 
            this.lblRank3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRank3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRank3.ForeColor = System.Drawing.Color.White;
            this.lblRank3.Location = new System.Drawing.Point(13, 493);
            this.lblRank3.Name = "lblRank3";
            this.lblRank3.Size = new System.Drawing.Size(22, 75);
            this.lblRank3.TabIndex = 12;
            this.lblRank3.Text = "3";
            this.lblRank3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRank8
            // 
            this.lblRank8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRank8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRank8.ForeColor = System.Drawing.Color.White;
            this.lblRank8.Location = new System.Drawing.Point(13, 118);
            this.lblRank8.Name = "lblRank8";
            this.lblRank8.Size = new System.Drawing.Size(22, 75);
            this.lblRank8.TabIndex = 17;
            this.lblRank8.Text = "8";
            this.lblRank8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRank7
            // 
            this.lblRank7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRank7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRank7.ForeColor = System.Drawing.Color.White;
            this.lblRank7.Location = new System.Drawing.Point(13, 193);
            this.lblRank7.Name = "lblRank7";
            this.lblRank7.Size = new System.Drawing.Size(22, 75);
            this.lblRank7.TabIndex = 16;
            this.lblRank7.Text = "7";
            this.lblRank7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRank6
            // 
            this.lblRank6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRank6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRank6.ForeColor = System.Drawing.Color.White;
            this.lblRank6.Location = new System.Drawing.Point(13, 268);
            this.lblRank6.Name = "lblRank6";
            this.lblRank6.Size = new System.Drawing.Size(22, 75);
            this.lblRank6.TabIndex = 15;
            this.lblRank6.Text = "6";
            this.lblRank6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRank5
            // 
            this.lblRank5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRank5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRank5.ForeColor = System.Drawing.Color.White;
            this.lblRank5.Location = new System.Drawing.Point(13, 343);
            this.lblRank5.Name = "lblRank5";
            this.lblRank5.Size = new System.Drawing.Size(22, 75);
            this.lblRank5.TabIndex = 14;
            this.lblRank5.Text = "5";
            this.lblRank5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFile1
            // 
            this.lblFile1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFile1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFile1.ForeColor = System.Drawing.Color.White;
            this.lblFile1.Location = new System.Drawing.Point(38, 718);
            this.lblFile1.Margin = new System.Windows.Forms.Padding(0);
            this.lblFile1.Name = "lblFile1";
            this.lblFile1.Size = new System.Drawing.Size(75, 22);
            this.lblFile1.TabIndex = 18;
            this.lblFile1.Text = "a";
            this.lblFile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFile2
            // 
            this.lblFile2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFile2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFile2.ForeColor = System.Drawing.Color.White;
            this.lblFile2.Location = new System.Drawing.Point(113, 718);
            this.lblFile2.Margin = new System.Windows.Forms.Padding(0);
            this.lblFile2.Name = "lblFile2";
            this.lblFile2.Size = new System.Drawing.Size(75, 22);
            this.lblFile2.TabIndex = 19;
            this.lblFile2.Text = "b";
            this.lblFile2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFile4
            // 
            this.lblFile4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFile4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFile4.ForeColor = System.Drawing.Color.White;
            this.lblFile4.Location = new System.Drawing.Point(263, 718);
            this.lblFile4.Margin = new System.Windows.Forms.Padding(0);
            this.lblFile4.Name = "lblFile4";
            this.lblFile4.Size = new System.Drawing.Size(75, 22);
            this.lblFile4.TabIndex = 21;
            this.lblFile4.Text = "d";
            this.lblFile4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFile3
            // 
            this.lblFile3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFile3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFile3.ForeColor = System.Drawing.Color.White;
            this.lblFile3.Location = new System.Drawing.Point(188, 718);
            this.lblFile3.Margin = new System.Windows.Forms.Padding(0);
            this.lblFile3.Name = "lblFile3";
            this.lblFile3.Size = new System.Drawing.Size(75, 22);
            this.lblFile3.TabIndex = 20;
            this.lblFile3.Text = "c";
            this.lblFile3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFile8
            // 
            this.lblFile8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFile8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFile8.ForeColor = System.Drawing.Color.White;
            this.lblFile8.Location = new System.Drawing.Point(563, 718);
            this.lblFile8.Margin = new System.Windows.Forms.Padding(0);
            this.lblFile8.Name = "lblFile8";
            this.lblFile8.Size = new System.Drawing.Size(75, 22);
            this.lblFile8.TabIndex = 25;
            this.lblFile8.Text = "h";
            this.lblFile8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFile7
            // 
            this.lblFile7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFile7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFile7.ForeColor = System.Drawing.Color.White;
            this.lblFile7.Location = new System.Drawing.Point(488, 718);
            this.lblFile7.Margin = new System.Windows.Forms.Padding(0);
            this.lblFile7.Name = "lblFile7";
            this.lblFile7.Size = new System.Drawing.Size(75, 22);
            this.lblFile7.TabIndex = 24;
            this.lblFile7.Text = "g";
            this.lblFile7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFile6
            // 
            this.lblFile6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFile6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFile6.ForeColor = System.Drawing.Color.White;
            this.lblFile6.Location = new System.Drawing.Point(413, 718);
            this.lblFile6.Margin = new System.Windows.Forms.Padding(0);
            this.lblFile6.Name = "lblFile6";
            this.lblFile6.Size = new System.Drawing.Size(75, 22);
            this.lblFile6.TabIndex = 23;
            this.lblFile6.Text = "f";
            this.lblFile6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFile5
            // 
            this.lblFile5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFile5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFile5.ForeColor = System.Drawing.Color.White;
            this.lblFile5.Location = new System.Drawing.Point(338, 718);
            this.lblFile5.Margin = new System.Windows.Forms.Padding(0);
            this.lblFile5.Name = "lblFile5";
            this.lblFile5.Size = new System.Drawing.Size(75, 22);
            this.lblFile5.TabIndex = 22;
            this.lblFile5.Text = "e";
            this.lblFile5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAnalysisMove
            // 
            this.lblAnalysisMove.AutoSize = true;
            this.lblAnalysisMove.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAnalysisMove.ForeColor = System.Drawing.Color.White;
            this.lblAnalysisMove.Location = new System.Drawing.Point(9, 656);
            this.lblAnalysisMove.Name = "lblAnalysisMove";
            this.lblAnalysisMove.Size = new System.Drawing.Size(45, 17);
            this.lblAnalysisMove.TabIndex = 0;
            this.lblAnalysisMove.Text = "label1";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1677, 934);
            this.Controls.Add(this.lblFile8);
            this.Controls.Add(this.lblFile7);
            this.Controls.Add(this.lblFile6);
            this.Controls.Add(this.lblFile5);
            this.Controls.Add(this.lblFile4);
            this.Controls.Add(this.lblFile3);
            this.Controls.Add(this.lblFile2);
            this.Controls.Add(this.lblFile1);
            this.Controls.Add(this.lblRank8);
            this.Controls.Add(this.lblRank7);
            this.Controls.Add(this.lblRank6);
            this.Controls.Add(this.lblRank5);
            this.Controls.Add(this.lblRank4);
            this.Controls.Add(this.lblRank3);
            this.Controls.Add(this.lblRank2);
            this.Controls.Add(this.lblRank1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlBlackUI);
            this.Controls.Add(this.pnlDuringGame);
            this.Controls.Add(this.pnlPreGame);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.pnlPreGame.ResumeLayout(false);
            this.pnlPosition.ResumeLayout(false);
            this.pnlPosition.PerformLayout();
            this.pnlTimeControl.ResumeLayout(false);
            this.pnlTimeControl.PerformLayout();
            this.pnlCustomTime.ResumeLayout(false);
            this.pnlCustomTime.PerformLayout();
            this.pnlVariants.ResumeLayout(false);
            this.pnlVariants.PerformLayout();
            this.pnlPlayerOptions.ResumeLayout(false);
            this.pnlPlayerOptions.PerformLayout();
            this.pnlAISettings.ResumeLayout(false);
            this.pnlAISettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackPlyDepth)).EndInit();
            this.pnlDuringGame.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlBlackUI.ResumeLayout(false);
            this.pnlBlackUI.PerformLayout();
            this.pnlBlackTime.ResumeLayout(false);
            this.pnlBlackTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBlackTime)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlWhiteTime.ResumeLayout(false);
            this.pnlWhiteTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWhiteTime)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Panel pnlPreGame;
        private System.Windows.Forms.Panel pnlDuringGame;
        private System.Windows.Forms.Panel pnlPlayerOptions;
        private System.Windows.Forms.Label lblPlayAgainst;
        private System.Windows.Forms.Panel pnlVariants;
        private System.Windows.Forms.Label lblVariant;
        private System.Windows.Forms.Panel pnlTimeControl;
        private System.Windows.Forms.Label lblTimeControl;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnResign;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBlackMoves;
        private System.Windows.Forms.TextBox txtWhiteMoves;
        private System.Windows.Forms.Panel pnlBlackUI;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlWhiteTime;
        private System.Windows.Forms.Label lblWhiteTime;
        private System.Windows.Forms.Panel pnlBlackTime;
        private System.Windows.Forms.PictureBox picBlackTime;
        private System.Windows.Forms.Label lblBlackTime;
        private System.Windows.Forms.PictureBox picWhiteTime;
        private System.Windows.Forms.Timer timerUpdateTime;
        private System.Windows.Forms.Panel pnlPosition;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.RadioButton radAgainstAI;
        private System.Windows.Forms.RadioButton radAgainstHuman;
        private System.Windows.Forms.Panel pnlAISettings;
        private System.Windows.Forms.TrackBar trackPlyDepth;
        private System.Windows.Forms.Label lblDepth;
        private System.Windows.Forms.Label lblPlyDepth;
        private System.Windows.Forms.ComboBox cmbTimeSettings;
        private System.Windows.Forms.TextBox textIncrement;
        private System.Windows.Forms.TextBox textSeconds;
        private System.Windows.Forms.TextBox textMinutes;
        private System.Windows.Forms.RadioButton radCustomTime;
        private System.Windows.Forms.RadioButton radPresetTime;
        private System.Windows.Forms.Panel pnlCustomTime;
        private System.Windows.Forms.RadioButton radNoTimers;
        private System.Windows.Forms.RadioButton radDefaultPosition;
        private System.Windows.Forms.TextBox textFEN;
        private System.Windows.Forms.RadioButton radFEN;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripSettings;
        private System.Windows.Forms.ToolStripMenuItem imagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cmbPieceSet;
        private System.Windows.Forms.ToolStripMenuItem coloursToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripMenuItem colourMenuC1;
        private System.Windows.Forms.ToolStripMenuItem colourMenuC2;
        private System.Windows.Forms.ToolStripMenuItem colourMenuMove;
        private System.Windows.Forms.ToolStripMenuItem colourMenuSelect;
        private System.Windows.Forms.ToolStripMenuItem menuResetColour;
        private System.Windows.Forms.Label lblBlackTaken;
        private System.Windows.Forms.Label lblWhiteTaken;
        private System.Windows.Forms.CheckBox checkUseTT;
        private System.Windows.Forms.ComboBox cmbVariant;
        private System.Windows.Forms.Label lblRank1;
        private System.Windows.Forms.Label lblRank2;
        private System.Windows.Forms.Label lblRank4;
        private System.Windows.Forms.Label lblRank3;
        private System.Windows.Forms.Label lblRank8;
        private System.Windows.Forms.Label lblRank7;
        private System.Windows.Forms.Label lblRank6;
        private System.Windows.Forms.Label lblRank5;
        private System.Windows.Forms.Label lblFile1;
        private System.Windows.Forms.Label lblFile2;
        private System.Windows.Forms.Label lblFile4;
        private System.Windows.Forms.Label lblFile3;
        private System.Windows.Forms.Label lblFile8;
        private System.Windows.Forms.Label lblFile7;
        private System.Windows.Forms.Label lblFile6;
        private System.Windows.Forms.Label lblFile5;
        private System.Windows.Forms.ToolStripMenuItem menuPreviousGames;
        private System.Windows.Forms.Label lblAnalysisMove;
    }
}