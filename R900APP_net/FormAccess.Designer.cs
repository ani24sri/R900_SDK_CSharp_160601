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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Quit = new System.Windows.Forms.Button();
            this.trackBar_txpwr = new System.Windows.Forms.TrackBar();
            this.label_txpower = new System.Windows.Forms.Label();
            this.label_txpwr = new System.Windows.Forms.Label();
            this.textBox_count = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // textBox_access
            // 
            this.textBox_access.Location = new System.Drawing.Point(112, 159);
            this.textBox_access.Name = "textBox_access";
            this.textBox_access.Size = new System.Drawing.Size(116, 23);
            this.textBox_access.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-1, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 19);
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(82, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 21);
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // checkBoxContinous
            // 
            this.checkBoxContinous.Location = new System.Drawing.Point(133, 33);
            this.checkBoxContinous.Name = "checkBoxContinous";
            this.checkBoxContinous.Size = new System.Drawing.Size(100, 16);
            this.checkBoxContinous.TabIndex = 25;
            this.checkBoxContinous.Text = "Continuous";
            this.checkBoxContinous.CheckStateChanged += new System.EventHandler(this.checkBoxContinous_CheckStateChanged);
            // 
            // textBox_result
            // 
            this.textBox_result.Enabled = false;
            this.textBox_result.Location = new System.Drawing.Point(6, 229);
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.Size = new System.Drawing.Size(73, 23);
            this.textBox_result.TabIndex = 23;
            // 
            // textBox_write
            // 
            this.textBox_write.Location = new System.Drawing.Point(6, 204);
            this.textBox_write.Name = "textBox_write";
            this.textBox_write.Size = new System.Drawing.Size(179, 23);
            this.textBox_write.TabIndex = 21;
            this.textBox_write.TextChanged += new System.EventHandler(this.textBox_write_TextChanged);
            // 
            // textBox_length
            // 
            this.textBox_length.Location = new System.Drawing.Point(183, 115);
            this.textBox_length.Name = "textBox_length";
            this.textBox_length.Size = new System.Drawing.Size(37, 23);
            this.textBox_length.TabIndex = 19;
            // 
            // textBox_offset
            // 
            this.textBox_offset.Location = new System.Drawing.Point(117, 115);
            this.textBox_offset.Name = "textBox_offset";
            this.textBox_offset.Size = new System.Drawing.Size(41, 23);
            this.textBox_offset.TabIndex = 16;
            // 
            // comboBox_bank
            // 
            this.comboBox_bank.Items.Add("RESERVED");
            this.comboBox_bank.Items.Add("EPC");
            this.comboBox_bank.Items.Add("TID");
            this.comboBox_bank.Items.Add("USER");
            this.comboBox_bank.Location = new System.Drawing.Point(7, 115);
            this.comboBox_bank.Name = "comboBox_bank";
            this.comboBox_bank.Size = new System.Drawing.Size(93, 23);
            this.comboBox_bank.TabIndex = 14;
            this.comboBox_bank.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox_epc
            // 
            this.textBox_epc.Location = new System.Drawing.Point(3, 70);
            this.textBox_epc.Name = "textBox_epc";
            this.textBox_epc.Size = new System.Drawing.Size(226, 23);
            this.textBox_epc.TabIndex = 24;
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(69, 32);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 16);
            this.radioButton2.TabIndex = 18;
            this.radioButton2.Text = "Write";
            this.radioButton2.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(11, 32);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(52, 16);
            this.radioButton1.TabIndex = 17;
            this.radioButton1.Text = "Read";
            this.radioButton1.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "ACCESS";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.Text = "Access Tag EPC :";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Tag Bank :";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(114, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.Text = "Offset :";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(181, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.Text = "Length :";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(112, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 20);
            this.label7.Text = "Access Password :";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 20);
            this.label8.Text = "Write";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(193, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 20);
            this.label9.Text = "Len.";
            // 
            // Quit
            // 
            this.Quit.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Quit.Location = new System.Drawing.Point(193, 260);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(41, 32);
            this.Quit.TabIndex = 92;
            this.Quit.Text = "Quit";
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // trackBar_txpwr
            // 
            this.trackBar_txpwr.LargeChange = 10;
            this.trackBar_txpwr.Location = new System.Drawing.Point(46, 259);
            this.trackBar_txpwr.Maximum = 70;
            this.trackBar_txpwr.Name = "trackBar_txpwr";
            this.trackBar_txpwr.Size = new System.Drawing.Size(128, 31);
            this.trackBar_txpwr.TabIndex = 42;
            this.trackBar_txpwr.TickFrequency = 10;
            this.trackBar_txpwr.ValueChanged += new System.EventHandler(this.trackBar_txpwr_ValueChanged);
            // 
            // label_txpower
            // 
            this.label_txpower.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label_txpower.Location = new System.Drawing.Point(0, 260);
            this.label_txpower.Name = "label_txpower";
            this.label_txpower.Size = new System.Drawing.Size(56, 12);
            this.label_txpower.Text = "Tx Pow.";
            // 
            // label_txpwr
            // 
            this.label_txpwr.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label_txpwr.Location = new System.Drawing.Point(97, 252);
            this.label_txpwr.Name = "label_txpwr";
            this.label_txpwr.Size = new System.Drawing.Size(61, 12);
            this.label_txpwr.Text = "MAX";
            // 
            // textBox_count
            // 
            this.textBox_count.Location = new System.Drawing.Point(191, 204);
            this.textBox_count.Name = "textBox_count";
            this.textBox_count.ReadOnly = true;
            this.textBox_count.Size = new System.Drawing.Size(42, 23);
            this.textBox_count.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
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
            this.Controls.Add(this.button1);
            this.Name = "FormAccess";
            this.Text = "ReadWriteForm";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormAccess_Closing);
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.TrackBar trackBar_txpwr;
        private System.Windows.Forms.Label label_txpower;
        private System.Windows.Forms.Label label_txpwr;
        private System.Windows.Forms.TextBox textBox_count;
        private System.Windows.Forms.Timer timer1;
    }
}