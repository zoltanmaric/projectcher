namespace Cher.Main
{
    partial class CherForm
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.usersLbl = new System.Windows.Forms.Label();
            this.artistLbl = new System.Windows.Forms.Label();
            this.usersLstBox = new System.Windows.Forms.ListBox();
            this.artistsLstBox = new System.Windows.Forms.ListBox();
            this.scoresLstBox = new System.Windows.Forms.ListBox();
            this.scoresLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 516);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(136, 32);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load Model";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // usersLbl
            // 
            this.usersLbl.AutoSize = true;
            this.usersLbl.Location = new System.Drawing.Point(9, 9);
            this.usersLbl.Name = "usersLbl";
            this.usersLbl.Size = new System.Drawing.Size(37, 13);
            this.usersLbl.TabIndex = 2;
            this.usersLbl.Text = "Users:";
            // 
            // artistLbl
            // 
            this.artistLbl.AutoSize = true;
            this.artistLbl.Location = new System.Drawing.Point(225, 9);
            this.artistLbl.Name = "artistLbl";
            this.artistLbl.Size = new System.Drawing.Size(38, 13);
            this.artistLbl.TabIndex = 4;
            this.artistLbl.Text = "Artists:";
            // 
            // usersLstBox
            // 
            this.usersLstBox.FormattingEnabled = true;
            this.usersLstBox.Location = new System.Drawing.Point(12, 25);
            this.usersLstBox.Name = "usersLstBox";
            this.usersLstBox.Size = new System.Drawing.Size(210, 485);
            this.usersLstBox.TabIndex = 5;
            this.usersLstBox.SelectedIndexChanged += new System.EventHandler(this.usersLstBox_SelectedIndexChanged);
            // 
            // artistsLstBox
            // 
            this.artistsLstBox.FormattingEnabled = true;
            this.artistsLstBox.Location = new System.Drawing.Point(228, 25);
            this.artistsLstBox.Name = "artistsLstBox";
            this.artistsLstBox.Size = new System.Drawing.Size(210, 485);
            this.artistsLstBox.TabIndex = 6;
            this.artistsLstBox.SelectedIndexChanged += new System.EventHandler(this.artistsLstBox_SelectedIndexChanged);
            // 
            // scoresLstBox
            // 
            this.scoresLstBox.FormattingEnabled = true;
            this.scoresLstBox.Location = new System.Drawing.Point(444, 25);
            this.scoresLstBox.Name = "scoresLstBox";
            this.scoresLstBox.Size = new System.Drawing.Size(210, 485);
            this.scoresLstBox.TabIndex = 7;
            // 
            // scoresLbl
            // 
            this.scoresLbl.AutoSize = true;
            this.scoresLbl.Location = new System.Drawing.Point(441, 9);
            this.scoresLbl.Name = "scoresLbl";
            this.scoresLbl.Size = new System.Drawing.Size(43, 13);
            this.scoresLbl.TabIndex = 8;
            this.scoresLbl.Text = "Scores:";
            // 
            // CherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 556);
            this.Controls.Add(this.scoresLbl);
            this.Controls.Add(this.scoresLstBox);
            this.Controls.Add(this.artistsLstBox);
            this.Controls.Add(this.usersLstBox);
            this.Controls.Add(this.artistLbl);
            this.Controls.Add(this.usersLbl);
            this.Controls.Add(this.btnLoad);
            this.Name = "CherForm";
            this.Text = "Cher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label usersLbl;
        private System.Windows.Forms.Label artistLbl;
        private System.Windows.Forms.ListBox usersLstBox;
        private System.Windows.Forms.ListBox artistsLstBox;
        private System.Windows.Forms.ListBox scoresLstBox;
        private System.Windows.Forms.Label scoresLbl;
    }
}

