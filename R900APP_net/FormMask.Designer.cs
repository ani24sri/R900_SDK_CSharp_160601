namespace R900APP_net
{
    partial class FormMask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
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
            this.Quit.Location = new System.Drawing.Point(174, 240);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(58, 21);
            this.Quit.TabIndex = 48;
            this.Quit.Text = "Quit";
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // textBox_maskdata
            // 
            this.textBox_maskdata.Location = new System.Drawing.Point(103, 211);
            this.textBox_maskdata.Name = "textBox_maskdata";
            this.textBox_maskdata.Size = new System.Drawing.Size(129, 23);
            this.textBox_maskdata.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(7, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.Text = "MASK DATA :";
            // 
            // textBox_length
            // 
            this.textBox_length.Location = new System.Drawing.Point(103, 182);
            this.textBox_length.Name = "textBox_length";
            this.textBox_length.Size = new System.Drawing.Size(129, 23);
            this.textBox_length.TabIndex = 46;
            // 
            // label_length
            // 
            this.label_length.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label_length.Location = new System.Drawing.Point(7, 188);
            this.label_length.Name = "label_length";
            this.label_length.Size = new System.Drawing.Size(103, 12);
            this.label_length.Text = "LENGTH (bit) :";
            // 
            // textBox_offset
            // 
            this.textBox_offset.Location = new System.Drawing.Point(103, 153);
            this.textBox_offset.Name = "textBox_offset";
            this.textBox_offset.Size = new System.Drawing.Size(129, 23);
            this.textBox_offset.TabIndex = 45;
            // 
            // label_offset
            // 
            this.label_offset.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label_offset.Location = new System.Drawing.Point(7, 160);
            this.label_offset.Name = "label_offset";
            this.label_offset.Size = new System.Drawing.Size(101, 12);
            this.label_offset.Text = "OFFSET (bit) :";
            // 
            // label_bank
            // 
            this.label_bank.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label_bank.Location = new System.Drawing.Point(7, 129);
            this.label_bank.Name = "label_bank";
            this.label_bank.Size = new System.Drawing.Size(48, 12);
            this.label_bank.Text = "BANK :";
            // 
            // comboBox_bank
            // 
            this.comboBox_bank.Items.Add("RESERVED");
            this.comboBox_bank.Items.Add("EPC");
            this.comboBox_bank.Items.Add("TID");
            this.comboBox_bank.Items.Add("USER");
            this.comboBox_bank.Location = new System.Drawing.Point(65, 125);
            this.comboBox_bank.Name = "comboBox_bank";
            this.comboBox_bank.Size = new System.Drawing.Size(168, 23);
            this.comboBox_bank.TabIndex = 44;
            // 
            // radioButton_multimode
            // 
            this.radioButton_multimode.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.radioButton_multimode.Location = new System.Drawing.Point(5, 103);
            this.radioButton_multimode.Name = "radioButton_multimode";
            this.radioButton_multimode.Size = new System.Drawing.Size(192, 16);
            this.radioButton_multimode.TabIndex = 43;
            this.radioButton_multimode.Text = "Select Mask MULTI Mode";
            this.radioButton_multimode.CheckedChanged += new System.EventHandler(this.radioButton_multimode_CheckedChanged_1);
            // 
            // textBox_epcdata
            // 
            this.textBox_epcdata.Location = new System.Drawing.Point(5, 55);
            this.textBox_epcdata.Name = "textBox_epcdata";
            this.textBox_epcdata.Size = new System.Drawing.Size(228, 23);
            this.textBox_epcdata.TabIndex = 42;
            // 
            // radioButton_epcmask
            // 
            this.radioButton_epcmask.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.radioButton_epcmask.Location = new System.Drawing.Point(5, 33);
            this.radioButton_epcmask.Name = "radioButton_epcmask";
            this.radioButton_epcmask.Size = new System.Drawing.Size(178, 16);
            this.radioButton_epcmask.TabIndex = 41;
            this.radioButton_epcmask.Text = "Select Mask EPC Mode";
            this.radioButton_epcmask.CheckedChanged += new System.EventHandler(this.radioButton_epcmask_CheckedChanged_1);
            // 
            // FormMask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
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
            this.Menu = this.mainMenu1;
            this.Name = "FormMask";
            this.Text = "FormMask";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormMask_Closing);
            this.ResumeLayout(false);

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