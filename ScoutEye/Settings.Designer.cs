namespace ScoutEye
{
    partial class Settings
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
            this.ThemeCombo = new System.Windows.Forms.ComboBox();
            this.EnterBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ThemeCombo
            // 
            this.ThemeCombo.FormattingEnabled = true;
            this.ThemeCombo.Location = new System.Drawing.Point(34, 30);
            this.ThemeCombo.Name = "ThemeCombo";
            this.ThemeCombo.Size = new System.Drawing.Size(210, 28);
            this.ThemeCombo.TabIndex = 0;
            // 
            // EnterBTN
            // 
            this.EnterBTN.Location = new System.Drawing.Point(566, 261);
            this.EnterBTN.Name = "EnterBTN";
            this.EnterBTN.Size = new System.Drawing.Size(177, 108);
            this.EnterBTN.TabIndex = 1;
            this.EnterBTN.Text = "Enter Settings";
            this.EnterBTN.UseVisualStyleBackColor = true;
            this.EnterBTN.Click += new System.EventHandler(this.EnterBTN_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EnterBTN);
            this.Controls.Add(this.ThemeCombo);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ThemeCombo;
        private System.Windows.Forms.Button EnterBTN;
    }
}