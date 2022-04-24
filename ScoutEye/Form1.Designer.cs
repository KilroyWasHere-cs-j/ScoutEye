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
            this.label5 = new System.Windows.Forms.Label();
            this.PointScoredTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DefenceCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EndgameCB = new System.Windows.Forms.ComboBox();
            this.TeleopCB = new System.Windows.Forms.ComboBox();
            this.AutoCB = new System.Windows.Forms.ComboBox();
            this.NotesTB = new System.Windows.Forms.RichTextBox();
            this.QRCodePB = new System.Windows.Forms.PictureBox();
            this.DebugBTN = new System.Windows.Forms.Button();
            this.StartTimerBTN = new System.Windows.Forms.Button();
            this.stopWatchUpdater = new System.Windows.Forms.Timer(this.components);
            this.MatchDataPlanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QRCodePB)).BeginInit();
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
            this.panel1.Controls.Add(this.NameTB);
            this.panel1.Controls.Add(this.NameLB);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.PointScoredTB);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.DefenceCB);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.EndgameCB);
            this.panel1.Controls.Add(this.TeleopCB);
            this.panel1.Controls.Add(this.AutoCB);
            this.panel1.Location = new System.Drawing.Point(12, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 327);
            this.panel1.TabIndex = 6;
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(7, 36);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Points Scored";
            // 
            // PointScoredTB
            // 
            this.PointScoredTB.Location = new System.Drawing.Point(7, 256);
            this.PointScoredTB.Name = "PointScoredTB";
            this.PointScoredTB.Size = new System.Drawing.Size(119, 26);
            this.PointScoredTB.TabIndex = 8;
            this.PointScoredTB.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Defence";
            // 
            // DefenceCB
            // 
            this.DefenceCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DefenceCB.FormattingEnabled = true;
            this.DefenceCB.Location = new System.Drawing.Point(149, 198);
            this.DefenceCB.Name = "DefenceCB";
            this.DefenceCB.Size = new System.Drawing.Size(121, 28);
            this.DefenceCB.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Endgame";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Teleop";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Auto";
            // 
            // EndgameCB
            // 
            this.EndgameCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EndgameCB.FormattingEnabled = true;
            this.EndgameCB.Location = new System.Drawing.Point(149, 144);
            this.EndgameCB.Name = "EndgameCB";
            this.EndgameCB.Size = new System.Drawing.Size(121, 28);
            this.EndgameCB.TabIndex = 2;
            // 
            // TeleopCB
            // 
            this.TeleopCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TeleopCB.FormattingEnabled = true;
            this.TeleopCB.Location = new System.Drawing.Point(147, 89);
            this.TeleopCB.Name = "TeleopCB";
            this.TeleopCB.Size = new System.Drawing.Size(121, 28);
            this.TeleopCB.TabIndex = 1;
            // 
            // AutoCB
            // 
            this.AutoCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AutoCB.FormattingEnabled = true;
            this.AutoCB.Location = new System.Drawing.Point(147, 35);
            this.AutoCB.Name = "AutoCB";
            this.AutoCB.Size = new System.Drawing.Size(121, 28);
            this.AutoCB.TabIndex = 0;
            // 
            // NotesTB
            // 
            this.NotesTB.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.NotesTB.Location = new System.Drawing.Point(1207, 411);
            this.NotesTB.Name = "NotesTB";
            this.NotesTB.Size = new System.Drawing.Size(150, 195);
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
            this.StartTimerBTN.Location = new System.Drawing.Point(12, 408);
            this.StartTimerBTN.Name = "StartTimerBTN";
            this.StartTimerBTN.Size = new System.Drawing.Size(243, 33);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1369, 615);
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
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MatchDataPlanel.ResumeLayout(false);
            this.MatchDataPlanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QRCodePB)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox DefenceCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox EndgameCB;
        private System.Windows.Forms.ComboBox TeleopCB;
        private System.Windows.Forms.ComboBox AutoCB;
        private System.Windows.Forms.RichTextBox NotesTB;
        private System.Windows.Forms.PictureBox QRCodePB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PointScoredTB;
        private System.Windows.Forms.Button DebugBTN;
        private System.Windows.Forms.Label TeamNameLB;
        private System.Windows.Forms.Button StartTimerBTN;
        private System.Windows.Forms.Label StopwatchLB;
        private System.Windows.Forms.Timer stopWatchUpdater;
        private System.Windows.Forms.Label NameLB;
        private System.Windows.Forms.TextBox NameTB;
    }
}

