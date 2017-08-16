namespace R900APP_net
{
    partial class FormMask
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
            this.Quit = new System.Windows.Forms.Button();
            this.textBox_maskdata = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_length = new System.Windows.Forms.TextBox();
            this.label_length = new System.Windows.Forms.Label();
            this.textBox_offset = new System.Windows.Forms.TextBox();
            this.label_offset = new System.Windows.Forms.Label();
            this.label_bank = new System.Windows.Forms.Label();
            this.comboBox_bank = new System.Windows.Forms.ComboBox();
            this.radioButton_multimode = new System.Windows.Forms.RadioButton();
            this.textBox_epcdata = new System.Windows.Forms.TextBox();
            this.radioButton_epcmask = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // Quit
            // 
            this.Quit.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Quit.Location = new System.Drawing.Point(230, 397);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(58, 21);
            this.Quit.TabIndex = 60;
            this.Quit.Text = "Quit";
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // textBox_maskdata
            // 
            this.textBox_maskdata.Location = new System.Drawing.Point(159, 351);
            this.textBox_maskdata.Name = "textBox_maskdata";
            this.textBox_maskdata.Size = new System.Drawing.Size(129, 21);
            this.textBox_maskdata.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(55, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 61;
            this.label1.Text = "MASK DATA :";
            // 
            // textBox_length
            // 
            this.textBox_length.Location = new System.Drawing.Point(159, 322);
            this.textBox_length.Name = "textBox_length";
            this.textBox_length.Size = new System.Drawing.Size(129, 21);
            this.textBox_length.TabIndex = 58;
            // 
            // label_length
            // 
            this.label_length.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label_length.Location = new System.Drawing.Point(55, 328);
            this.label_length.Name = "label_length";
            this.label_length.Size = new System.Drawing.Size(103, 12);
            this.label_length.TabIndex = 62;
            this.label_length.Text = "LENGTH (bit) :";
            // 
            // textBox_offset
            // 
            this.textBox_offset.Location = new System.Drawing.Point(159, 293);
            this.textBox_offset.Name = "textBox_offset";
            this.textBox_offset.Size = new System.Drawing.Size(129, 21);
            this.textBox_offset.TabIndex = 57;
            // 
            // label_offset
            // 
            this.label_offset.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label_offset.Location = new System.Drawing.Point(55, 300);
            this.label_offset.Name = "label_offset";
            this.label_offset.Size = new System.Drawing.Size(101, 12);
            this.label_offset.TabIndex = 63;
            this.label_offset.Text = "OFFSET (bit) :";
            // 
            // label_bank
            // 
            this.label_bank.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label_bank.Location = new System.Drawing.Point(63, 269);
            this.label_bank.Name = "label_bank";
            this.label_bank.Size = new System.Drawing.Size(48, 12);
            this.label_bank.TabIndex = 64;
            this.label_bank.Text = "BANK :";
            // 
            // comboBox_bank
            // 
            this.comboBox_bank.Items.AddRange(new object[] {
            "RESERVED",
            "EPC",
            "TID",
            "USER"});
            this.comboBox_bank.Location = new System.Drawing.Point(121, 265);
            this.comboBox_bank.Name = "comboBox_bank";
            this.comboBox_bank.Size = new System.Drawing.Size(168, 20);
            this.comboBox_bank.TabIndex = 56;
            // 
            // radioButton_multimode
            // 
            this.radioButton_multimode.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.radioButton_multimode.Location = new System.Drawing.Point(61, 243);
            this.radioButton_multimode.Name = "radioButton_multimode";
            this.radioButton_multimode.Size = new System.Drawing.Size(192, 16);
            this.radioButton_multimode.TabIndex = 55;
            this.radioButton_multimode.Text = "Select Mask MULTI Mode";
            this.radioButton_multimode.CheckedChanged += new System.EventHandler(this.radioButton_multimode_CheckedChanged);
            // 
            // textBox_epcdata
            // 
            this.textBox_epcdata.Location = new System.Drawing.Point(12, 160);
            this.textBox_epcdata.Name = "textBox_epcdata";
            this.textBox_epcdata.Size = new System.Drawing.Size(355, 21);
            this.textBox_epcdata.TabIndex = 54;
            // 
            // radioButton_epcmask
            // 
            this.radioButton_epcmask.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.radioButton_epcmask.Location = new System.Drawing.Point(61, 138);
            this.radioButton_epcmask.Name = "radioButton_epcmask";
            this.radioButton_epcmask.Size = new System.Drawing.Size(178, 16);
            this.radioButton_epcmask.TabIndex = 53;
            this.radioButton_epcmask.Text = "Select Mask EPC Mode";
            this.radioButton_epcmask.CheckedChanged += new System.EventHandler(this.radioButton_epcmask_CheckedChanged);
            // 
            // FormMask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 572);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.textBox_maskdata);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_length);
            this.Controls.Add(this.label_length);
            this.Controls.Add(this.textBox_offset);
            this.Controls.Add(this.label_offset);
            this.Controls.Add(this.label_bank);
            this.Controls.Add(this.comboBox_bank);
            this.Controls.Add(this.radioButton_multimode);
            this.Controls.Add(this.textBox_epcdata);
            this.Controls.Add(this.radioButton_epcmask);
            this.Name = "FormMask";
            this.Text = "FormMask";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMask_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.TextBox textBox_maskdata;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_length;
        private System.Windows.Forms.Label label_length;
        private System.Windows.Forms.TextBox textBox_offset;
        private System.Windows.Forms.Label label_offset;
        private System.Windows.Forms.Label label_bank;
        private System.Windows.Forms.ComboBox comboBox_bank;
        private System.Windows.Forms.RadioButton radioButton_multimode;
        private System.Windows.Forms.TextBox textBox_epcdata;
        private System.Windows.Forms.RadioButton radioButton_epcmask;
    }
}