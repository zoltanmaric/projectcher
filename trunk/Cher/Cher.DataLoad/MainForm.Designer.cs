namespace Cher.DataLoad
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
            this.btnQuick = new System.Windows.Forms.Button();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnQuick
            // 
            this.btnQuick.Location = new System.Drawing.Point(12, 12);
            this.btnQuick.Name = "btnQuick";
            this.btnQuick.Size = new System.Drawing.Size(75, 23);
            this.btnQuick.TabIndex = 0;
            this.btnQuick.Text = "Quick";
            this.btnQuick.UseVisualStyleBackColor = true;
            // 
            // rtbResult
            // 
            this.rtbResult.Location = new System.Drawing.Point(93, 12);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.Size = new System.Drawing.Size(507, 435);
            this.rtbResult.TabIndex = 1;
            this.rtbResult.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 459);
            this.Controls.Add(this.rtbResult);
            this.Controls.Add(this.btnQuick);
            this.Name = "MainForm";
            this.Text = "MainForma";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQuick;
        private System.Windows.Forms.RichTextBox rtbResult;
    }
}

