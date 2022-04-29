namespace ScoutEye
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MatchDataPlanel = new System.Windows.Forms.Panel();
            this.StopwatchLB = new System.Windows.Forms.Label();
            this.TeamNameLB = new System.Windows.Forms.Label();
            this.MatchNumberLB = new System.Windows.Forms.Label();
            this.TeamNumberLB = new System.Windows.Forms.Label();
            this.MatchDataLabel = new System.Windows.Forms.Label();
            this.EnterBTN = new System.Windows.Forms.Button();
            this.ResetBTN = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.NameLB = new System.Windows.Forms.Label();
            this.NotesTB = new System.Windows.Forms.RichTextBox();
            this.QRCodePB = new System.Windows.Forms.PictureBox();
            this.DebugBTN = new System.Windows.Forms.Button();
            this.StartTimerBTN = new System.Windows.Forms.Button();
            this.stopWatchUpdater = new System.Windows.Forms.Timer(this.components);
            this.Auto1TB = new System.Windows.Forms.TextBox();
            this.Auto2TB = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AutoLB = new System.Windows.Forms.Label();
            this.Auto1LB = new System.Windows.Forms.Label();
            this.Auto2LB = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Tele1LB = new System.Windows.Forms.Label();
            this.Tele2LB = new System.Windows.Forms.Label();
            this.Tele1TB = new System.Windows.Forms.TextBox();
            this.Tele2TB = new System.Windows.Forms.TextBox();
            this.Auto3LB = new System.Windows.Forms.Label();
            this.Auto3TB = new System.Windows.Forms.TextBox();
            this.Tele3LB = new System.Windows.Forms.Label();
            this.Tele3TB = new System.Windows.Forms.TextBox();
            this.PlusBTN = new System.Windows.Forms.Button();
            this.Minus = new System.Windows.Forms.Button();
            this.ClickCounterLB = new System.Windows.Forms.Label();
            this.MatchDataPlanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QRCodePB)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MatchDataPlanel
            // 
            this.MatchDataPlanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MatchDataPlanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MatchDataPlanel.Controls.Add(this.StopwatchLB);
            this.MatchDataPlanel.Controls.Add(this.TeamNameLB);
            this.MatchDataPlanel.Controls.Add(this.MatchNumberLB);
            this.MatchDataPlanel.Controls.Add(this.TeamNumberLB);
            this.MatchDataPlanel.Controls.Add(this.MatchDataLabel);
            this.MatchDataPlanel.Cursor = System.Windows.Forms.Cursors.No;
            this.MatchDataPlanel.Location = new System.Drawing.Point(12, 12);
            this.MatchDataPlanel.Name = "MatchDataPlanel";
            this.MatchDataPlanel.Size = new System.Drawing.Size(776, 43);
            this.MatchDataPlanel.TabIndex = 0;
            this.MatchDataPlanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MatchDataPlanel_Paint);
            // 
            // StopwatchLB
            // 
            this.StopwatchLB.AutoSize = true;
            this.StopwatchLB.Location = new System.Drawing.Point(551, 9);
            this.StopwatchLB.Name = "StopwatchLB";
            this.StopwatchLB.Size = new System.Drawing.Size(85, 20);
            this.StopwatchLB.TabIndex = 5;
            this.StopwatchLB.Text = "Stopwatch";
            this.StopwatchLB.Click += new System.EventHandler(this.StopwatchLB_Click);
            // 
            // TeamNameLB
            // 
            this.TeamNameLB.AutoSize = true;
            this.TeamNameLB.Location = new System.Drawing.Point(403, 9);
            this.TeamNameLB.Name = "TeamNameLB";
            this.TeamNameLB.Size = new System.Drawing.Size(95, 20);
            this.TeamNameLB.TabIndex = 4;
            this.TeamNameLB.Text = "Team Name";
            // 
            // MatchNumberLB
            // 
            this.MatchNumberLB.AutoSize = true;
            this.MatchNumberLB.Location = new System.Drawing.Point(110, 9);
            this.MatchNumberLB.Name = "MatchNumberLB";
            this.MatchNumberLB.Size = new System.Drawing.Size(113, 20);
            this.MatchNumberLB.TabIndex = 3;
            this.MatchNumberLB.Text = "Match Number";
            // 
            // TeamNumberLB
            // 
            this.TeamNumberLB.AutoSize = true;
            this.TeamNumberLB.Location = new System.Drawing.Point(246, 9);
            this.TeamNumberLB.Name = "TeamNumberLB";
            this.TeamNumberLB.Size = new System.Drawing.Size(109, 20);
            this.TeamNumberLB.TabIndex = 2;
            this.TeamNumberLB.Text = "Team Number";
            // 
            // MatchDataLabel
            // 
            this.MatchDataLabel.AutoSize = true;
            this.MatchDataLabel.Location = new System.Drawing.Point(3, 9);
            this.MatchDataLabel.Name = "MatchDataLabel";
            this.MatchDataLabel.Size = new System.Drawing.Size(92, 20);
            this.MatchDataLabel.TabIndex = 1;
            this.MatchDataLabel.Text = "Match Data";
            // 
            // EnterBTN
            // 
            this.EnterBTN.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.EnterBTN.Location = new System.Drawing.Point(596, 61);
            this.EnterBTN.Name = "EnterBTN";
            this.EnterBTN.Size = new System.Drawing.Size(192, 143);
            this.EnterBTN.TabIndex = 4;
            this.EnterBTN.Text = "Enter";
            this.EnterBTN.UseVisualStyleBackColor = false;
            this.EnterBTN.Click += new System.EventHandler(this.EnterBTN_Click);
            // 
            // ResetBTN
            // 
            this.ResetBTN.Location = new System.Drawing.Point(596, 210);
            this.ResetBTN.Name = "ResetBTN";
            this.ResetBTN.Size = new System.Drawing.Size(192, 146);
            this.ResetBTN.TabIndex = 5;
            this.ResetBTN.Text = "Match Reset";
            this.ResetBTN.UseVisualStyleBackColor = true;
            this.ResetBTN.Click += new System.EventHandler(this.ResetBTN_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ClickCounterLB);
            this.panel1.Controls.Add(this.Minus);
            this.panel1.Controls.Add(this.PlusBTN);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.NameTB);
            this.panel1.Controls.Add(this.NameLB);
            this.panel1.Location = new System.Drawing.Point(12, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 327);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(60, 12);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(100, 26);
            this.NameTB.TabIndex = 11;
            // 
            // NameLB
            // 
            this.NameLB.AutoSize = true;
            this.NameLB.Location = new System.Drawing.Point(3, 12);
            this.NameLB.Name = "NameLB";
            this.NameLB.Size = new System.Drawing.Size(51, 20);
            this.NameLB.TabIndex = 10;
            this.NameLB.Text = "Name";
            // 
            // NotesTB
            // 
            this.NotesTB.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.NotesTB.Location = new System.Drawing.Point(1317, 605);
            this.NotesTB.Name = "NotesTB";
            this.NotesTB.Size = new System.Drawing.Size(108, 83);
            this.NotesTB.TabIndex = 7;
            this.NotesTB.Text = "Match Notes";
            // 
            // QRCodePB
            // 
            this.QRCodePB.ErrorImage = null;
            this.QRCodePB.Location = new System.Drawing.Point(794, 12);
            this.QRCodePB.Name = "QRCodePB";
            this.QRCodePB.Size = new System.Drawing.Size(563, 390);
            this.QRCodePB.TabIndex = 8;
            this.QRCodePB.TabStop = false;
            // 
            // DebugBTN
            // 
            this.DebugBTN.Location = new System.Drawing.Point(596, 355);
            this.DebugBTN.Name = "DebugBTN";
            this.DebugBTN.Size = new System.Drawing.Size(75, 33);
            this.DebugBTN.TabIndex = 10;
            this.DebugBTN.Text = "Debug";
            this.DebugBTN.UseVisualStyleBackColor = true;
            this.DebugBTN.Click += new System.EventHandler(this.DebugBTN_Click);
            // 
            // StartTimerBTN
            // 
            this.StartTimerBTN.Location = new System.Drawing.Point(596, 394);
            this.StartTimerBTN.Name = "StartTimerBTN";
            this.StartTimerBTN.Size = new System.Drawing.Size(200, 33);
            this.StartTimerBTN.TabIndex = 11;
            this.StartTimerBTN.Text = "Toggle Stopwatch";
            this.StartTimerBTN.UseVisualStyleBackColor = true;
            this.StartTimerBTN.Click += new System.EventHandler(this.StartTimerBTN_Click);
            // 
            // stopWatchUpdater
            // 
            this.stopWatchUpdater.Enabled = true;
            this.stopWatchUpdater.Interval = 10;
            this.stopWatchUpdater.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Auto1TB
            // 
            this.Auto1TB.Location = new System.Drawing.Point(89, 39);
            this.Auto1TB.Name = "Auto1TB";
            this.Auto1TB.Size = new System.Drawing.Size(144, 26);
            this.Auto1TB.TabIndex = 12;
            // 
            // Auto2TB
            // 
            this.Auto2TB.Location = new System.Drawing.Point(89, 68);
            this.Auto2TB.Name = "Auto2TB";
            this.Auto2TB.Size = new System.Drawing.Size(144, 26);
            this.Auto2TB.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Auto3TB);
            this.panel2.Controls.Add(this.Auto3LB);
            this.panel2.Controls.Add(this.Auto2LB);
            this.panel2.Controls.Add(this.Auto1LB);
            this.panel2.Controls.Add(this.AutoLB);
            this.panel2.Controls.Add(this.Auto1TB);
            this.panel2.Controls.Add(this.Auto2TB);
            this.panel2.Location = new System.Drawing.Point(3, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(236, 144);
            this.panel2.TabIndex = 15;
            // 
            // AutoLB
            // 
            this.AutoLB.AutoSize = true;
            this.AutoLB.Location = new System.Drawing.Point(8, 12);
            this.AutoLB.Name = "AutoLB";
            this.AutoLB.Size = new System.Drawing.Size(43, 20);
            this.AutoLB.TabIndex = 14;
            this.AutoLB.Text = "Auto";
            // 
            // Auto1LB
            // 
            this.Auto1LB.AutoSize = true;
            this.Auto1LB.Location = new System.Drawing.Point(3, 42);
            this.Auto1LB.Name = "Auto1LB";
            this.Auto1LB.Size = new System.Drawing.Size(35, 20);
            this.Auto1LB.TabIndex = 16;
            this.Auto1LB.Text = "Null";
            // 
            // Auto2LB
            // 
            this.Auto2LB.AutoSize = true;
            this.Auto2LB.Location = new System.Drawing.Point(3, 74);
            this.Auto2LB.Name = "Auto2LB";
            this.Auto2LB.Size = new System.Drawing.Size(35, 20);
            this.Auto2LB.TabIndex = 17;
            this.Auto2LB.Text = "Null";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Tele3TB);
            this.panel3.Controls.Add(this.Tele3LB);
            this.panel3.Controls.Add(this.Tele2TB);
            this.panel3.Controls.Add(this.Tele1TB);
            this.panel3.Controls.Add(this.Tele2LB);
            this.panel3.Controls.Add(this.Tele1LB);
            this.panel3.Location = new System.Drawing.Point(245, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(237, 144);
            this.panel3.TabIndex = 16;
            // 
            // Tele1LB
            // 
            this.Tele1LB.AutoSize = true;
            this.Tele1LB.Location = new System.Drawing.Point(3, 42);
            this.Tele1LB.Name = "Tele1LB";
            this.Tele1LB.Size = new System.Drawing.Size(35, 20);
            this.Tele1LB.TabIndex = 18;
            this.Tele1LB.Text = "Null";
            // 
            // Tele2LB
            // 
            this.Tele2LB.AutoSize = true;
            this.Tele2LB.Location = new System.Drawing.Point(3, 77);
            this.Tele2LB.Name = "Tele2LB";
            this.Tele2LB.Size = new System.Drawing.Size(35, 20);
            this.Tele2LB.TabIndex = 19;
            this.Tele2LB.Text = "Null";
            // 
            // Tele1TB
            // 
            this.Tele1TB.Location = new System.Drawing.Point(86, 42);
            this.Tele1TB.Name = "Tele1TB";
            this.Tele1TB.Size = new System.Drawing.Size(144, 26);
            this.Tele1TB.TabIndex = 18;
            // 
            // Tele2TB
            // 
            this.Tele2TB.Location = new System.Drawing.Point(86, 74);
            this.Tele2TB.Name = "Tele2TB";
            this.Tele2TB.Size = new System.Drawing.Size(144, 26);
            this.Tele2TB.TabIndex = 20;
            // 
            // Auto3LB
            // 
            this.Auto3LB.AutoSize = true;
            this.Auto3LB.Location = new System.Drawing.Point(3, 103);
            this.Auto3LB.Name = "Auto3LB";
            this.Auto3LB.Size = new System.Drawing.Size(35, 20);
            this.Auto3LB.TabIndex = 18;
            this.Auto3LB.Text = "Null";
            // 
            // Auto3TB
            // 
            this.Auto3TB.Location = new System.Drawing.Point(89, 97);
            this.Auto3TB.Name = "Auto3TB";
            this.Auto3TB.Size = new System.Drawing.Size(144, 26);
            this.Auto3TB.TabIndex = 19;
            // 
            // Tele3LB
            // 
            this.Tele3LB.AutoSize = true;
            this.Tele3LB.Location = new System.Drawing.Point(3, 106);
            this.Tele3LB.Name = "Tele3LB";
            this.Tele3LB.Size = new System.Drawing.Size(35, 20);
            this.Tele3LB.TabIndex = 21;
            this.Tele3LB.Text = "Null";
            // 
            // Tele3TB
            // 
            this.Tele3TB.Location = new System.Drawing.Point(86, 106);
            this.Tele3TB.Name = "Tele3TB";
            this.Tele3TB.Size = new System.Drawing.Size(144, 26);
            this.Tele3TB.TabIndex = 22;
            // 
            // PlusBTN
            // 
            this.PlusBTN.Location = new System.Drawing.Point(7, 194);
            this.PlusBTN.Name = "PlusBTN";
            this.PlusBTN.Size = new System.Drawing.Size(107, 58);
            this.PlusBTN.TabIndex = 17;
            this.PlusBTN.Text = "UP";
            this.PlusBTN.UseVisualStyleBackColor = true;
            this.PlusBTN.Click += new System.EventHandler(this.PlusBTN_Click);
            // 
            // Minus
            // 
            this.Minus.Location = new System.Drawing.Point(114, 194);
            this.Minus.Name = "Minus";
            this.Minus.Size = new System.Drawing.Size(107, 58);
            this.Minus.TabIndex = 18;
            this.Minus.Text = "DOWN";
            this.Minus.UseVisualStyleBackColor = true;
            this.Minus.Click += new System.EventHandler(this.Minus_Click);
            // 
            // ClickCounterLB
            // 
            this.ClickCounterLB.AutoSize = true;
            this.ClickCounterLB.Location = new System.Drawing.Point(241, 210);
            this.ClickCounterLB.Name = "ClickCounterLB";
            this.ClickCounterLB.Size = new System.Drawing.Size(18, 20);
            this.ClickCounterLB.TabIndex = 19;
            this.ClickCounterLB.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1437, 700);
            this.Controls.Add(this.NotesTB);
            this.Controls.Add(this.StartTimerBTN);
            this.Controls.Add(this.DebugBTN);
            this.Controls.Add(this.QRCodePB);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ResetBTN);
            this.Controls.Add(this.EnterBTN);
            this.Controls.Add(this.MatchDataPlanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "ScoutEye";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MatchDataPlanel.ResumeLayout(false);
            this.MatchDataPlanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QRCodePB)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MatchDataPlanel;
        private System.Windows.Forms.Label MatchDataLabel;
        private System.Windows.Forms.Label MatchNumberLB;
        private System.Windows.Forms.Label TeamNumberLB;
        private System.Windows.Forms.Button EnterBTN;
        private System.Windows.Forms.Button ResetBTN;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox NotesTB;
        private System.Windows.Forms.PictureBox QRCodePB;
        private System.Windows.Forms.Button DebugBTN;
        private System.Windows.Forms.Label TeamNameLB;
        private System.Windows.Forms.Button StartTimerBTN;
        private System.Windows.Forms.Label StopwatchLB;
        private System.Windows.Forms.Timer stopWatchUpdater;
        private System.Windows.Forms.Label NameLB;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.TextBox Auto2TB;
        private System.Windows.Forms.TextBox Auto1TB;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Auto2LB;
        private System.Windows.Forms.Label Auto1LB;
        private System.Windows.Forms.Label AutoLB;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox Tele2TB;
        private System.Windows.Forms.TextBox Tele1TB;
        private System.Windows.Forms.Label Tele2LB;
        private System.Windows.Forms.Label Tele1LB;
        private System.Windows.Forms.TextBox Tele3TB;
        private System.Windows.Forms.Label Tele3LB;
        private System.Windows.Forms.TextBox Auto3TB;
        private System.Windows.Forms.Label Auto3LB;
        private System.Windows.Forms.Label ClickCounterLB;
        private System.Windows.Forms.Button Minus;
        private System.Windows.Forms.Button PlusBTN;
    }
}

