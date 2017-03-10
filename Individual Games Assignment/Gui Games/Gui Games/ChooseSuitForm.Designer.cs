namespace Gui_Games
{
    partial class ChooseSuitForm
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
            this.rbClubs = new System.Windows.Forms.RadioButton();
            this.rbHearts = new System.Windows.Forms.RadioButton();
            this.rbDiamonds = new System.Windows.Forms.RadioButton();
            this.grpSuit = new System.Windows.Forms.GroupBox();
            this.rbSpades = new System.Windows.Forms.RadioButton();
            this.btnChoose = new System.Windows.Forms.Button();
            this.grpSuit.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbClubs
            // 
            this.rbClubs.AutoSize = true;
            this.rbClubs.Checked = true;
            this.rbClubs.Location = new System.Drawing.Point(35, 37);
            this.rbClubs.Name = "rbClubs";
            this.rbClubs.Size = new System.Drawing.Size(51, 17);
            this.rbClubs.TabIndex = 0;
            this.rbClubs.TabStop = true;
            this.rbClubs.Text = "Clubs";
            this.rbClubs.UseVisualStyleBackColor = true;
            // 
            // rbHearts
            // 
            this.rbHearts.AutoSize = true;
            this.rbHearts.Location = new System.Drawing.Point(35, 108);
            this.rbHearts.Name = "rbHearts";
            this.rbHearts.Size = new System.Drawing.Size(56, 17);
            this.rbHearts.TabIndex = 1;
            this.rbHearts.Text = "Hearts";
            this.rbHearts.UseVisualStyleBackColor = true;
            // 
            // rbDiamonds
            // 
            this.rbDiamonds.AutoSize = true;
            this.rbDiamonds.Location = new System.Drawing.Point(35, 73);
            this.rbDiamonds.Name = "rbDiamonds";
            this.rbDiamonds.Size = new System.Drawing.Size(72, 17);
            this.rbDiamonds.TabIndex = 2;
            this.rbDiamonds.Text = "Diamonds";
            this.rbDiamonds.UseVisualStyleBackColor = true;
            // 
            // grpSuit
            // 
            this.grpSuit.Controls.Add(this.rbSpades);
            this.grpSuit.Controls.Add(this.rbClubs);
            this.grpSuit.Controls.Add(this.rbDiamonds);
            this.grpSuit.Controls.Add(this.rbHearts);
            this.grpSuit.Location = new System.Drawing.Point(32, 12);
            this.grpSuit.Name = "grpSuit";
            this.grpSuit.Size = new System.Drawing.Size(155, 184);
            this.grpSuit.TabIndex = 3;
            this.grpSuit.TabStop = false;
            this.grpSuit.Text = "Choose a Suit";
            // 
            // rbSpades
            // 
            this.rbSpades.AutoSize = true;
            this.rbSpades.Location = new System.Drawing.Point(35, 144);
            this.rbSpades.Name = "rbSpades";
            this.rbSpades.Size = new System.Drawing.Size(61, 17);
            this.rbSpades.TabIndex = 3;
            this.rbSpades.TabStop = true;
            this.rbSpades.Text = "Spades";
            this.rbSpades.UseVisualStyleBackColor = true;
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(67, 206);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 23);
            this.btnChoose.TabIndex = 4;
            this.btnChoose.Text = "OK";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // ChooseSuitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 241);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.grpSuit);
            this.Name = "ChooseSuitForm";
            this.Text = "ChooseSuitForm";
            this.grpSuit.ResumeLayout(false);
            this.grpSuit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbClubs;
        private System.Windows.Forms.RadioButton rbHearts;
        private System.Windows.Forms.RadioButton rbDiamonds;
        private System.Windows.Forms.GroupBox grpSuit;
        private System.Windows.Forms.RadioButton rbSpades;
        private System.Windows.Forms.Button btnChoose;
    }
}