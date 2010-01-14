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
            this.lsbLastFMArtists = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblEvaluation = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMicroF1 = new System.Windows.Forms.TextBox();
            this.txtMicroRecall = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMicroPrecision = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMacroRecall = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMacroPrecision = new System.Windows.Forms.TextBox();
            this.txtMacroF1 = new System.Windows.Forms.TextBox();
            this.txtWe = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtWk = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblDBLoadStatus = new System.Windows.Forms.Label();
            this.btnEval = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
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
            this.usersLbl.Location = new System.Drawing.Point(74, 435);
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
            this.btnRecommend.Location = new System.Drawing.Point(147, 536);
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
            this.label3.Location = new System.Drawing.Point(83, 461);
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
            // lsbLastFMArtists
            // 
            this.lsbLastFMArtists.FormattingEnabled = true;
            this.lsbLastFMArtists.Location = new System.Drawing.Point(689, 58);
            this.lsbLastFMArtists.Name = "lsbLastFMArtists";
            this.lsbLastFMArtists.Size = new System.Drawing.Size(210, 368);
            this.lsbLastFMArtists.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(686, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Last.FM recommended ar tists:";
            // 
            // lblEvaluation
            // 
            this.lblEvaluation.AutoSize = true;
            this.lblEvaluation.Location = new System.Drawing.Point(91, 10);
            this.lblEvaluation.Name = "lblEvaluation";
            this.lblEvaluation.Size = new System.Drawing.Size(35, 13);
            this.lblEvaluation.TabIndex = 13;
            this.lblEvaluation.Text = "status";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtMicroF1);
            this.panel1.Controls.Add(this.txtMicroRecall);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtMicroPrecision);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtMacroRecall);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtMacroPrecision);
            this.panel1.Controls.Add(this.lblEvaluation);
            this.panel1.Controls.Add(this.txtMacroF1);
            this.panel1.Location = new System.Drawing.Point(561, 432);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 120);
            this.panel1.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(193, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Micro F1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(193, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Micro Recall";
            // 
            // txtMicroF1
            // 
            this.txtMicroF1.Location = new System.Drawing.Point(289, 88);
            this.txtMicroF1.Name = "txtMicroF1";
            this.txtMicroF1.Size = new System.Drawing.Size(35, 20);
            this.txtMicroF1.TabIndex = 27;
            // 
            // txtMicroRecall
            // 
            this.txtMicroRecall.Location = new System.Drawing.Point(289, 58);
            this.txtMicroRecall.Name = "txtMicroRecall";
            this.txtMicroRecall.Size = new System.Drawing.Size(35, 20);
            this.txtMicroRecall.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(193, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Micro Precision";
            // 
            // txtMicroPrecision
            // 
            this.txtMicroPrecision.Location = new System.Drawing.Point(289, 32);
            this.txtMicroPrecision.Name = "txtMicroPrecision";
            this.txtMicroPrecision.Size = new System.Drawing.Size(35, 20);
            this.txtMicroPrecision.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Macro Recall";
            // 
            // txtMacroRecall
            // 
            this.txtMacroRecall.Location = new System.Drawing.Point(109, 61);
            this.txtMacroRecall.Name = "txtMacroRecall";
            this.txtMacroRecall.Size = new System.Drawing.Size(35, 20);
            this.txtMacroRecall.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Macro Precision";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Macro F1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Evaluation";
            // 
            // txtMacroPrecision
            // 
            this.txtMacroPrecision.Location = new System.Drawing.Point(109, 35);
            this.txtMacroPrecision.Name = "txtMacroPrecision";
            this.txtMacroPrecision.Size = new System.Drawing.Size(35, 20);
            this.txtMacroPrecision.TabIndex = 12;
            // 
            // txtMacroF1
            // 
            this.txtMacroF1.Location = new System.Drawing.Point(109, 87);
            this.txtMacroF1.Name = "txtMacroF1";
            this.txtMacroF1.Size = new System.Drawing.Size(35, 20);
            this.txtMacroF1.TabIndex = 10;
            // 
            // txtWe
            // 
            this.txtWe.Location = new System.Drawing.Point(187, 510);
            this.txtWe.Name = "txtWe";
            this.txtWe.Size = new System.Drawing.Size(35, 20);
            this.txtWe.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(148, 513);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "we:";
            // 
            // txtWk
            // 
            this.txtWk.Location = new System.Drawing.Point(187, 484);
            this.txtWk.Name = "txtWk";
            this.txtWk.Size = new System.Drawing.Size(35, 20);
            this.txtWk.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(148, 487);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "wk:";
            // 
            // lblDBLoadStatus
            // 
            this.lblDBLoadStatus.AutoSize = true;
            this.lblDBLoadStatus.Location = new System.Drawing.Point(107, 20);
            this.lblDBLoadStatus.Name = "lblDBLoadStatus";
            this.lblDBLoadStatus.Size = new System.Drawing.Size(0, 13);
            this.lblDBLoadStatus.TabIndex = 19;
            // 
            // btnEval
            // 
            this.btnEval.Location = new System.Drawing.Point(425, 458);
            this.btnEval.Name = "btnEval";
            this.btnEval.Size = new System.Drawing.Size(75, 23);
            this.btnEval.TabIndex = 20;
            this.btnEval.Text = "Eval";
            this.btnEval.UseVisualStyleBackColor = true;
            this.btnEval.Click += new System.EventHandler(this.btnEval_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 568);
            this.Controls.Add(this.btnEval);
            this.Controls.Add(this.lblDBLoadStatus);
            this.Controls.Add(this.txtWe);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtWk);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtArtistSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNeighSize);
            this.Controls.Add(this.btnRecommend);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usersLbl);
            this.Controls.Add(this.lsbLastFMArtists);
            this.Controls.Add(this.lsbRecArtists);
            this.Controls.Add(this.lsbNeigh);
            this.Controls.Add(this.usersLstBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.ListBox lsbLastFMArtists;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblEvaluation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMacroF1;
        private System.Windows.Forms.TextBox txtMacroPrecision;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMacroRecall;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMicroF1;
        private System.Windows.Forms.TextBox txtMicroRecall;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMicroPrecision;
        private System.Windows.Forms.TextBox txtWe;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtWk;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblDBLoadStatus;
        private System.Windows.Forms.Button btnEval;
    }
}