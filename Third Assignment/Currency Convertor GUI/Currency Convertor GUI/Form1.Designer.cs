namespace Currency_Convertor_GUI {
    partial class frmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.cboCurrency2 = new System.Windows.Forms.ComboBox();
            this.cboCurrency1 = new System.Windows.Forms.ComboBox();
            this.lblCurrency1 = new System.Windows.Forms.Label();
            this.lblCurrency2 = new System.Windows.Forms.Label();
            this.lblValue2 = new System.Windows.Forms.Label();
            this.lblValue1 = new System.Windows.Forms.Label();
            this.rbYes = new System.Windows.Forms.RadioButton();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.lblCurrencyCode1 = new System.Windows.Forms.Label();
            this.lblCurrencyCode2 = new System.Windows.Forms.Label();
            this.grpPromptRepeat = new System.Windows.Forms.GroupBox();
            this.grpPromptRepeat.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.Location = new System.Drawing.Point(145, 90);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(72, 60);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.Text = "equals";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Enabled = false;
            this.txtOutput.Location = new System.Drawing.Point(251, 111);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(94, 20);
            this.txtOutput.TabIndex = 1;
            // 
            // txtInput
            // 
            this.txtInput.Enabled = false;
            this.txtInput.Location = new System.Drawing.Point(36, 111);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(94, 20);
            this.txtInput.TabIndex = 2;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // cboCurrency2
            // 
            this.cboCurrency2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency2.Enabled = false;
            this.cboCurrency2.FormattingEnabled = true;
            this.cboCurrency2.Items.AddRange(new object[] {
            "Australia (AUD)",
            "China (CYN)",
            "Denmark (DKK)",
            "Europe (EUR)",
            "India (INR)",
            "New Zealand (NZD)",
            "United Arab Emirates (AED)",
            "United Kingdom (GBP)",
            "United States (USD)",
            "Vietnam (VND)"});
            this.cboCurrency2.Location = new System.Drawing.Point(197, 29);
            this.cboCurrency2.Name = "cboCurrency2";
            this.cboCurrency2.Size = new System.Drawing.Size(134, 21);
            this.cboCurrency2.TabIndex = 3;
            this.cboCurrency2.SelectedIndexChanged += new System.EventHandler(this.cboCurrency2_SelectedIndexChanged);
            // 
            // cboCurrency1
            // 
            this.cboCurrency1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency1.FormattingEnabled = true;
            this.cboCurrency1.Items.AddRange(new object[] {
            "Australia (AUD)",
            "China (CYN)",
            "Denmark (DKK)",
            "Europe (EUR)",
            "India (INR)",
            "New Zealand (NZD)",
            "United Arab Emirates (AED)",
            "United Kingdom (GBP)",
            "United States (USD)",
            "Vietnam (VND)"});
            this.cboCurrency1.Location = new System.Drawing.Point(36, 29);
            this.cboCurrency1.Name = "cboCurrency1";
            this.cboCurrency1.Size = new System.Drawing.Size(134, 21);
            this.cboCurrency1.TabIndex = 4;
            this.cboCurrency1.SelectedIndexChanged += new System.EventHandler(this.cboCurrency1_SelectedIndexChanged);
            // 
            // lblCurrency1
            // 
            this.lblCurrency1.AutoSize = true;
            this.lblCurrency1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrency1.Location = new System.Drawing.Point(33, 13);
            this.lblCurrency1.Name = "lblCurrency1";
            this.lblCurrency1.Size = new System.Drawing.Size(105, 15);
            this.lblCurrency1.TabIndex = 5;
            this.lblCurrency1.Text = "Currency I have";
            // 
            // lblCurrency2
            // 
            this.lblCurrency2.AutoSize = true;
            this.lblCurrency2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrency2.Location = new System.Drawing.Point(194, 13);
            this.lblCurrency2.Name = "lblCurrency2";
            this.lblCurrency2.Size = new System.Drawing.Size(105, 15);
            this.lblCurrency2.TabIndex = 6;
            this.lblCurrency2.Text = "Currency I want";
            // 
            // lblValue2
            // 
            this.lblValue2.AutoSize = true;
            this.lblValue2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue2.Location = new System.Drawing.Point(248, 95);
            this.lblValue2.Name = "lblValue2";
            this.lblValue2.Size = new System.Drawing.Size(97, 15);
            this.lblValue2.TabIndex = 7;
            this.lblValue2.Text = "Amount I want";
            // 
            // lblValue1
            // 
            this.lblValue1.AutoSize = true;
            this.lblValue1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue1.Location = new System.Drawing.Point(33, 95);
            this.lblValue1.Name = "lblValue1";
            this.lblValue1.Size = new System.Drawing.Size(97, 15);
            this.lblValue1.TabIndex = 8;
            this.lblValue1.Text = "Amount I have";
            // 
            // rbYes
            // 
            this.rbYes.AutoSize = true;
            this.rbYes.BackColor = System.Drawing.SystemColors.Control;
            this.rbYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbYes.Location = new System.Drawing.Point(31, 29);
            this.rbYes.Name = "rbYes";
            this.rbYes.Size = new System.Drawing.Size(46, 17);
            this.rbYes.TabIndex = 9;
            this.rbYes.Text = "Yes";
            this.rbYes.UseVisualStyleBackColor = false;
            this.rbYes.CheckedChanged += new System.EventHandler(this.rbYes_CheckedChanged);
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNo.Location = new System.Drawing.Point(31, 52);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(41, 17);
            this.rbNo.TabIndex = 10;
            this.rbNo.Text = "No";
            this.rbNo.UseVisualStyleBackColor = true;
            this.rbNo.CheckedChanged += new System.EventHandler(this.rbNo_CheckedChanged);
            // 
            // lblCurrencyCode1
            // 
            this.lblCurrencyCode1.AutoSize = true;
            this.lblCurrencyCode1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrencyCode1.Location = new System.Drawing.Point(3, 114);
            this.lblCurrencyCode1.Name = "lblCurrencyCode1";
            this.lblCurrencyCode1.Size = new System.Drawing.Size(42, 13);
            this.lblCurrencyCode1.TabIndex = 12;
            this.lblCurrencyCode1.Text = "code1";
            this.lblCurrencyCode1.Visible = false;
            // 
            // lblCurrencyCode2
            // 
            this.lblCurrencyCode2.AutoSize = true;
            this.lblCurrencyCode2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrencyCode2.Location = new System.Drawing.Point(221, 114);
            this.lblCurrencyCode2.Name = "lblCurrencyCode2";
            this.lblCurrencyCode2.Size = new System.Drawing.Size(42, 13);
            this.lblCurrencyCode2.TabIndex = 13;
            this.lblCurrencyCode2.Text = "code2";
            this.lblCurrencyCode2.Visible = false;
            // 
            // grpPromptRepeat
            // 
            this.grpPromptRepeat.Controls.Add(this.rbYes);
            this.grpPromptRepeat.Controls.Add(this.rbNo);
            this.grpPromptRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPromptRepeat.Location = new System.Drawing.Point(93, 156);
            this.grpPromptRepeat.Name = "grpPromptRepeat";
            this.grpPromptRepeat.Size = new System.Drawing.Size(170, 88);
            this.grpPromptRepeat.TabIndex = 14;
            this.grpPromptRepeat.TabStop = false;
            this.grpPromptRepeat.Text = "Another Conversion?";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 271);
            this.Controls.Add(this.grpPromptRepeat);
            this.Controls.Add(this.lblCurrencyCode2);
            this.Controls.Add(this.lblCurrencyCode1);
            this.Controls.Add(this.lblValue1);
            this.Controls.Add(this.lblValue2);
            this.Controls.Add(this.lblCurrency2);
            this.Controls.Add(this.lblCurrency1);
            this.Controls.Add(this.cboCurrency1);
            this.Controls.Add(this.cboCurrency2);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnConvert);
            this.Name = "frmMain";
            this.Text = "Currency Converter";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpPromptRepeat.ResumeLayout(false);
            this.grpPromptRepeat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.ComboBox cboCurrency2;
        private System.Windows.Forms.ComboBox cboCurrency1;
        private System.Windows.Forms.Label lblCurrency1;
        private System.Windows.Forms.Label lblCurrency2;
        private System.Windows.Forms.Label lblValue2;
        private System.Windows.Forms.Label lblValue1;
        private System.Windows.Forms.RadioButton rbYes;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.Label lblCurrencyCode1;
        private System.Windows.Forms.Label lblCurrencyCode2;
        private System.Windows.Forms.GroupBox grpPromptRepeat;

     
    }
}

