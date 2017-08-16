namespace R900APP_net
{
    partial class FormAccess
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
            this.components = new System.ComponentModel.Container();
            this.textBox_count = new System.Windows.Forms.TextBox();
            this.label_txpwr = new System.Windows.Forms.Label();
            this.label_txpower = new System.Windows.Forms.Label();
            this.trackBar_txpwr = new System.Windows.Forms.TrackBar();
            this.Quit = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_access = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxContinous = new System.Windows.Forms.CheckBox();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.textBox_write = new System.Windows.Forms.TextBox();
            this.textBox_length = new System.Windows.Forms.TextBox();
            this.textBox_offset = new System.Windows.Forms.TextBox();
            this.comboBox_bank = new System.Windows.Forms.ComboBox();
            this.textBox_epc = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button_access = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_txpwr)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_count
            // 
            this.textBox_count.Location = new System.Drawing.Point(307, 337);
            this.textBox_count.Name = "textBox_count";
            this.textBox_count.ReadOnly = true;
            this.textBox_count.Size = new System.Drawing.Size(42, 21);
            this.textBox_count.TabIndex = 102;
            // 
            // label_txpwr
            // 
            this.label_txpwr.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label_txpwr.Location = new System.Drawing.Point(288, 433);
            this.label_txpwr.Name = "label_txpwr";
            this.label_txpwr.Size = new System.Drawing.Size(61, 12);
            this.label_txpwr.TabIndex = 103;
            this.label_txpwr.Text = "MAX";
            // 
            // label_txpower
            // 
            this.label_txpower.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label_txpower.Location = new System.Drawing.Point(58, 420);
            this.label_txpower.Name = "label_txpower";
            this.label_txpower.Size = new System.Drawing.Size(56, 12);
            this.label_txpower.TabIndex = 104;
            this.label_txpower.Text = "Tx Pow.";
            // 
            // trackBar_txpwr
            // 
            this.trackBar_txpwr.LargeChange = 10;
            this.trackBar_txpwr.Location = new System.Drawing.Point(58, 448);
            this.trackBar_txpwr.Maximum = 70;
            this.trackBar_txpwr.Name = "trackBar_txpwr";
            this.trackBar_txpwr.Size = new System.Drawing.Size(260, 45);
            this.trackBar_txpwr.TabIndex = 116;
            this.trackBar_txpwr.TickFrequency = 10;
            this.trackBar_txpwr.Scroll += new System.EventHandler(this.trackBar_txpwr_Scroll);
            // 
            // Quit
            // 
            this.Quit.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Quit.Location = new System.Drawing.Point(274, 511);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(75, 41);
            this.Quit.TabIndex = 117;
            this.Quit.Text = "Quit";
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(309, 318);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 20);
            this.label9.TabIndex = 118;
            this.label9.Text = "Len.";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(29, 314);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 20);
            this.label8.TabIndex = 119;
            this.label8.Text = "Write";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(171, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 20);
            this.label7.TabIndex = 120;
            this.label7.Text = "Access Password :";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(62, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 121;
            this.label4.Text = "Tag Bank :";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(173, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 122;
            this.label5.Text = "Offset :";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(240, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 123;
            this.label6.Text = "Length :";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(62, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 124;
            this.label1.Text = "Access Tag EPC :";
            // 
            // textBox_access
            // 
            this.textBox_access.Location = new System.Drawing.Point(171, 287);
            this.textBox_access.Name = "textBox_access";
            this.textBox_access.Size = new System.Drawing.Size(116, 21);
            this.textBox_access.TabIndex = 115;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(57, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 19);
            this.label3.TabIndex = 125;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(201, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 21);
            this.label2.TabIndex = 126;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // checkBoxContinous
            // 
            this.checkBoxContinous.Location = new System.Drawing.Point(192, 97);
            this.checkBoxContinous.Name = "checkBoxContinous";
            this.checkBoxContinous.Size = new System.Drawing.Size(100, 16);
            this.checkBoxContinous.TabIndex = 114;
            this.checkBoxContinous.Text = "Continuous";
            this.checkBoxContinous.CheckedChanged += new System.EventHandler(this.checkBoxContinous_CheckedChanged);
            // 
            // textBox_result
            // 
            this.textBox_result.Enabled = false;
            this.textBox_result.Location = new System.Drawing.Point(31, 373);
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.Size = new System.Drawing.Size(164, 21);
            this.textBox_result.TabIndex = 112;
            // 
            // textBox_write
            // 
            this.textBox_write.Location = new System.Drawing.Point(31, 337);
            this.textBox_write.Name = "textBox_write";
            this.textBox_write.Size = new System.Drawing.Size(270, 21);
            this.textBox_write.TabIndex = 111;
            this.textBox_write.TextChanged += new System.EventHandler(this.textBox_write_TextChanged);
            // 
            // textBox_length
            // 
            this.textBox_length.Location = new System.Drawing.Point(242, 228);
            this.textBox_length.Name = "textBox_length";
            this.textBox_length.Size = new System.Drawing.Size(37, 21);
            this.textBox_length.TabIndex = 110;
            // 
            // textBox_offset
            // 
            this.textBox_offset.Location = new System.Drawing.Point(176, 228);
            this.textBox_offset.Name = "textBox_offset";
            this.textBox_offset.Size = new System.Drawing.Size(41, 21);
            this.textBox_offset.TabIndex = 107;
            // 
            // comboBox_bank
            // 
            this.comboBox_bank.Items.AddRange(new object[] {
            "RESERVED",
            "EPC",
            "TID",
            "USER"});
            this.comboBox_bank.Location = new System.Drawing.Point(66, 228);
            this.comboBox_bank.Name = "comboBox_bank";
            this.comboBox_bank.Size = new System.Drawing.Size(93, 20);
            this.comboBox_bank.TabIndex = 105;
            this.comboBox_bank.SelectedIndexChanged += new System.EventHandler(this.comboBox_bank_SelectedIndexChanged);
            // 
            // textBox_epc
            // 
            this.textBox_epc.Location = new System.Drawing.Point(31, 157);
            this.textBox_epc.Name = "textBox_epc";
            this.textBox_epc.Size = new System.Drawing.Size(318, 21);
            this.textBox_epc.TabIndex = 113;
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(128, 96);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 16);
            this.radioButton2.TabIndex = 109;
            this.radioButton2.Text = "Write";
            this.radioButton2.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(70, 96);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(52, 16);
            this.radioButton1.TabIndex = 108;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Read";
            this.radioButton1.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // button_access
            // 
            this.button_access.Location = new System.Drawing.Point(120, 26);
            this.button_access.Name = "button_access";
            this.button_access.Size = new System.Drawing.Size(146, 44);
            this.button_access.TabIndex = 106;
            this.button_access.Text = "ACCESS";
            this.button_access.Click += new System.EventHandler(this.button_access_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 572);
            this.Controls.Add(this.textBox_count);
            this.Controls.Add(this.label_txpwr);
            this.Controls.Add(this.label_txpower);
            this.Controls.Add(this.trackBar_txpwr);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_access);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxContinous);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.textBox_write);
            this.Controls.Add(this.textBox_length);
            this.Controls.Add(this.textBox_offset);
            this.Controls.Add(this.comboBox_bank);
            this.Controls.Add(this.textBox_epc);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button_access);
            this.Name = "FormAccess";
            this.Text = "FormAccess";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAccess_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_txpwr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_count;
        private System.Windows.Forms.Label label_txpwr;
        private System.Windows.Forms.Label label_txpower;
        private System.Windows.Forms.TrackBar trackBar_txpwr;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_access;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxContinous;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.TextBox textBox_write;
        private System.Windows.Forms.TextBox textBox_length;
        private System.Windows.Forms.TextBox textBox_offset;
        private System.Windows.Forms.ComboBox comboBox_bank;
        private System.Windows.Forms.TextBox textBox_epc;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button_access;
        private System.Windows.Forms.Timer timer1;

    }
}