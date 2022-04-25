namespace ScoutInstallerInstaller
{
    partial class Installer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Installer));
            this.InstallBTN = new System.Windows.Forms.Button();
            this.InstallProgressPB = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.InstallLB = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // InstallBTN
            // 
            this.InstallBTN.Location = new System.Drawing.Point(35, 355);
            this.InstallBTN.Name = "InstallBTN";
            this.InstallBTN.Size = new System.Drawing.Size(99, 42);
            this.InstallBTN.TabIndex = 0;
            this.InstallBTN.Text = "Install";
            this.InstallBTN.UseVisualStyleBackColor = true;
            this.InstallBTN.Click += new System.EventHandler(this.InstallBTN_Click);
            // 
            // InstallProgressPB
            // 
            this.InstallProgressPB.Location = new System.Drawing.Point(35, 314);
            this.InstallProgressPB.Name = "InstallProgressPB";
            this.InstallProgressPB.Size = new System.Drawing.Size(663, 26);
            this.InstallProgressPB.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(35, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(330, 296);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // InstallLB
            // 
            this.InstallLB.FormattingEnabled = true;
            this.InstallLB.ItemHeight = 20;
            this.InstallLB.Location = new System.Drawing.Point(371, 12);
            this.InstallLB.Name = "InstallLB";
            this.InstallLB.Size = new System.Drawing.Size(327, 284);
            this.InstallLB.TabIndex = 3;
            // 
            // Installer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InstallLB);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.InstallProgressPB);
            this.Controls.Add(this.InstallBTN);
            this.Name = "Installer";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button InstallBTN;
        private System.Windows.Forms.ProgressBar InstallProgressPB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox InstallLB;
    }
}

