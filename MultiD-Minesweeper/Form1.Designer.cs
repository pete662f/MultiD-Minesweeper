namespace MultiD_Minesweeper
{
    partial class Form1
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.comboBoxGameMode = new System.Windows.Forms.ComboBox();
            this.labelGameMode = new System.Windows.Forms.Label();
            this.labelDimensions = new System.Windows.Forms.Label();
            this.labelLength = new System.Windows.Forms.Label();
            this.labelMines = new System.Windows.Forms.Label();
            this.textBoxDimensions = new System.Windows.Forms.TextBox();
            this.textBoxLength = new System.Windows.Forms.TextBox();
            this.textBoxMines = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMenu = new System.Windows.Forms.TabPage();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.tabPagePlay = new System.Windows.Forms.TabPage();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.labelSettings = new System.Windows.Forms.Label();
            this.tabPageGame = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelLoss = new System.Windows.Forms.Label();
            this.buttonBackSettings = new System.Windows.Forms.Button();
            this.labelWin = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageMenu.SuspendLayout();
            this.tabPagePlay.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.tabPageGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Stencil", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(217, 267);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(311, 115);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "START";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // comboBoxGameMode
            // 
            this.comboBoxGameMode.FormattingEnabled = true;
            this.comboBoxGameMode.Location = new System.Drawing.Point(217, 233);
            this.comboBoxGameMode.Name = "comboBoxGameMode";
            this.comboBoxGameMode.Size = new System.Drawing.Size(311, 28);
            this.comboBoxGameMode.TabIndex = 1;
            // 
            // labelGameMode
            // 
            this.labelGameMode.AutoSize = true;
            this.labelGameMode.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameMode.Location = new System.Drawing.Point(302, 201);
            this.labelGameMode.Name = "labelGameMode";
            this.labelGameMode.Size = new System.Drawing.Size(140, 29);
            this.labelGameMode.TabIndex = 2;
            this.labelGameMode.Text = "Gamemode";
            // 
            // labelDimensions
            // 
            this.labelDimensions.AutoSize = true;
            this.labelDimensions.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDimensions.Location = new System.Drawing.Point(64, 73);
            this.labelDimensions.Name = "labelDimensions";
            this.labelDimensions.Size = new System.Drawing.Size(155, 29);
            this.labelDimensions.TabIndex = 3;
            this.labelDimensions.Text = "Dimensions";
            // 
            // labelLength
            // 
            this.labelLength.AutoSize = true;
            this.labelLength.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLength.Location = new System.Drawing.Point(321, 73);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(103, 29);
            this.labelLength.TabIndex = 4;
            this.labelLength.Text = "Length";
            // 
            // labelMines
            // 
            this.labelMines.AutoSize = true;
            this.labelMines.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMines.Location = new System.Drawing.Point(567, 73);
            this.labelMines.Name = "labelMines";
            this.labelMines.Size = new System.Drawing.Size(85, 29);
            this.labelMines.TabIndex = 5;
            this.labelMines.Text = "Mines";
            // 
            // textBoxDimensions
            // 
            this.textBoxDimensions.Location = new System.Drawing.Point(91, 102);
            this.textBoxDimensions.Name = "textBoxDimensions";
            this.textBoxDimensions.Size = new System.Drawing.Size(100, 26);
            this.textBoxDimensions.TabIndex = 6;
            // 
            // textBoxLength
            // 
            this.textBoxLength.Location = new System.Drawing.Point(322, 102);
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.Size = new System.Drawing.Size(100, 26);
            this.textBoxLength.TabIndex = 7;
            // 
            // textBoxMines
            // 
            this.textBoxMines.Location = new System.Drawing.Point(559, 102);
            this.textBoxMines.Name = "textBoxMines";
            this.textBoxMines.Size = new System.Drawing.Size(100, 26);
            this.textBoxMines.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageMenu);
            this.tabControl1.Controls.Add(this.tabPagePlay);
            this.tabControl1.Controls.Add(this.tabPageSettings);
            this.tabControl1.Controls.Add(this.tabPageGame);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(785, 450);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPageMenu
            // 
            this.tabPageMenu.Controls.Add(this.buttonSettings);
            this.tabPageMenu.Controls.Add(this.buttonPlay);
            this.tabPageMenu.Location = new System.Drawing.Point(4, 29);
            this.tabPageMenu.Name = "tabPageMenu";
            this.tabPageMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMenu.Size = new System.Drawing.Size(777, 417);
            this.tabPageMenu.TabIndex = 1;
            this.tabPageMenu.Text = "Menu";
            this.tabPageMenu.UseVisualStyleBackColor = true;
            // 
            // buttonSettings
            // 
            this.buttonSettings.Font = new System.Drawing.Font("Stencil", 30F);
            this.buttonSettings.Location = new System.Drawing.Point(196, 229);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(346, 80);
            this.buttonSettings.TabIndex = 1;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Font = new System.Drawing.Font("Stencil", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlay.Location = new System.Drawing.Point(196, 73);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(346, 131);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // tabPagePlay
            // 
            this.tabPagePlay.Controls.Add(this.buttonStart);
            this.tabPagePlay.Controls.Add(this.comboBoxGameMode);
            this.tabPagePlay.Controls.Add(this.labelGameMode);
            this.tabPagePlay.Controls.Add(this.labelMines);
            this.tabPagePlay.Controls.Add(this.textBoxMines);
            this.tabPagePlay.Controls.Add(this.labelDimensions);
            this.tabPagePlay.Controls.Add(this.textBoxLength);
            this.tabPagePlay.Controls.Add(this.labelLength);
            this.tabPagePlay.Controls.Add(this.textBoxDimensions);
            this.tabPagePlay.Location = new System.Drawing.Point(4, 29);
            this.tabPagePlay.Name = "tabPagePlay";
            this.tabPagePlay.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePlay.Size = new System.Drawing.Size(777, 417);
            this.tabPagePlay.TabIndex = 0;
            this.tabPagePlay.Text = "Play";
            this.tabPagePlay.UseVisualStyleBackColor = true;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.buttonBackSettings);
            this.tabPageSettings.Controls.Add(this.labelSettings);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 29);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Size = new System.Drawing.Size(777, 417);
            this.tabPageSettings.TabIndex = 2;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.Font = new System.Drawing.Font("Stencil", 40F);
            this.labelSettings.Location = new System.Drawing.Point(185, 14);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(409, 95);
            this.labelSettings.TabIndex = 3;
            this.labelSettings.Text = "Settings";
            // 
            // tabPageGame
            // 
            this.tabPageGame.AutoScroll = true;
            this.tabPageGame.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.tabPageGame.Controls.Add(this.labelWin);
            this.tabPageGame.Controls.Add(this.labelLoss);
            this.tabPageGame.Controls.Add(this.progressBar1);
            this.tabPageGame.Location = new System.Drawing.Point(4, 29);
            this.tabPageGame.Name = "tabPageGame";
            this.tabPageGame.Size = new System.Drawing.Size(777, 417);
            this.tabPageGame.TabIndex = 3;
            this.tabPageGame.Text = "Game";
            this.tabPageGame.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(164, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(450, 30);
            this.progressBar1.TabIndex = 0;
            // 
            // labelLoss
            // 
            this.labelLoss.AutoSize = true;
            this.labelLoss.BackColor = System.Drawing.Color.Black;
            this.labelLoss.Font = new System.Drawing.Font("Stencil", 100F);
            this.labelLoss.ForeColor = System.Drawing.Color.White;
            this.labelLoss.Location = new System.Drawing.Point(64, 102);
            this.labelLoss.Name = "labelLoss";
            this.labelLoss.Size = new System.Drawing.Size(994, 237);
            this.labelLoss.TabIndex = 1;
            this.labelLoss.Text = "YOU LOSE";
            // 
            // buttonBackSettings
            // 
            this.buttonBackSettings.Font = new System.Drawing.Font("Stencil", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackSettings.Location = new System.Drawing.Point(18, 14);
            this.buttonBackSettings.Name = "buttonBackSettings";
            this.buttonBackSettings.Size = new System.Drawing.Size(161, 95);
            this.buttonBackSettings.TabIndex = 4;
            this.buttonBackSettings.Text = "BACK";
            this.buttonBackSettings.UseVisualStyleBackColor = true;
            this.buttonBackSettings.Click += new System.EventHandler(this.buttonBackSettings_Click);
            // 
            // labelWin
            // 
            this.labelWin.AutoSize = true;
            this.labelWin.BackColor = System.Drawing.Color.Black;
            this.labelWin.Font = new System.Drawing.Font("Stencil", 100F);
            this.labelWin.ForeColor = System.Drawing.Color.White;
            this.labelWin.Location = new System.Drawing.Point(45, 154);
            this.labelWin.Name = "labelWin";
            this.labelWin.Size = new System.Drawing.Size(908, 237);
            this.labelWin.TabIndex = 2;
            this.labelWin.Text = "YOU WIN";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 444);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPageMenu.ResumeLayout(false);
            this.tabPagePlay.ResumeLayout(false);
            this.tabPagePlay.PerformLayout();
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.tabPageGame.ResumeLayout(false);
            this.tabPageGame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ComboBox comboBoxGameMode;
        private System.Windows.Forms.Label labelGameMode;
        private System.Windows.Forms.Label labelDimensions;
        private System.Windows.Forms.Label labelLength;
        private System.Windows.Forms.Label labelMines;
        private System.Windows.Forms.TextBox textBoxDimensions;
        private System.Windows.Forms.TextBox textBoxLength;
        private System.Windows.Forms.TextBox textBoxMines;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMenu;
        private System.Windows.Forms.TabPage tabPagePlay;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TabPage tabPageGame;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelLoss;
        private System.Windows.Forms.Button buttonBackSettings;
        private System.Windows.Forms.Label labelWin;
    }
}

