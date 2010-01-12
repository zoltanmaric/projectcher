namespace Cher.Main
{
    partial class MainForm
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
            this.usersLstBox = new System.Windows.Forms.ListBox();
            this.usersLbl = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnRecommend = new System.Windows.Forms.Button();
            this.lsbNeigh = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbRecArtists = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNeighSize = new System.Windows.Forms.TextBox();
            this.txtArtistSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usersLstBox
            // 
            this.usersLstBox.FormattingEnabled = true;
            this.usersLstBox.Location = new System.Drawing.Point(12, 58);
            this.usersLstBox.Name = "usersLstBox";
            this.usersLstBox.Size = new System.Drawing.Size(210, 368);
            this.usersLstBox.TabIndex = 6;
            // 
            // usersLbl
            // 
            this.usersLbl.AutoSize = true;
            this.usersLbl.Location = new System.Drawing.Point(74, 440);
            this.usersLbl.Name = "usersLbl";
            this.usersLbl.Size = new System.Drawing.Size(98, 13);
            this.usersLbl.TabIndex = 7;
            this.usersLbl.Text = "Neighborhood size:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnRecommend
            // 
            this.btnRecommend.Location = new System.Drawing.Point(147, 484);
            this.btnRecommend.Name = "btnRecommend";
            this.btnRecommend.Size = new System.Drawing.Size(75, 23);
            this.btnRecommend.TabIndex = 9;
            this.btnRecommend.Text = "Recommend!";
            this.btnRecommend.UseVisualStyleBackColor = true;
            this.btnRecommend.Click += new System.EventHandler(this.btnRecommend_Click);
            // 
            // lsbNeigh
            // 
            this.lsbNeigh.FormattingEnabled = true;
            this.lsbNeigh.Location = new System.Drawing.Point(228, 58);
            this.lsbNeigh.Name = "lsbNeigh";
            this.lsbNeigh.Size = new System.Drawing.Size(210, 368);
            this.lsbNeigh.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Neighborhood:";
            // 
            // lsbRecArtists
            // 
            this.lsbRecArtists.FormattingEnabled = true;
            this.lsbRecArtists.Location = new System.Drawing.Point(444, 58);
            this.lsbRecArtists.Name = "lsbRecArtists";
            this.lsbRecArtists.Size = new System.Drawing.Size(210, 368);
            this.lsbRecArtists.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Recommended artists:";
            // 
            // txtNeighSize
            // 
            this.txtNeighSize.Location = new System.Drawing.Point(187, 432);
            this.txtNeighSize.Name = "txtNeighSize";
            this.txtNeighSize.Size = new System.Drawing.Size(35, 20);
            this.txtNeighSize.TabIndex = 10;
            // 
            // txtArtistSize
            // 
            this.txtArtistSize.Location = new System.Drawing.Point(187, 458);
            this.txtArtistSize.Name = "txtArtistSize";
            this.txtArtistSize.Size = new System.Drawing.Size(35, 20);
            this.txtArtistSize.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 465);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Number of artists:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Users:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 515);
            this.Controls.Add(this.txtArtistSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNeighSize);
            this.Controls.Add(this.btnRecommend);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usersLbl);
            this.Controls.Add(this.lsbRecArtists);
            this.Controls.Add(this.lsbNeigh);
            this.Controls.Add(this.usersLstBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox usersLstBox;
        private System.Windows.Forms.Label usersLbl;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnRecommend;
        private System.Windows.Forms.ListBox lsbNeigh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbRecArtists;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNeighSize;
        private System.Windows.Forms.TextBox txtArtistSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}