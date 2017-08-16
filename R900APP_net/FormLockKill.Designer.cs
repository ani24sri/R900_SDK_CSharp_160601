namespace R900APP_net
{
    partial class FormLockKill
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
            this.comboBox_lockop = new System.Windows.Forms.ComboBox();
            this.textBox_killpassword = new System.Windows.Forms.TextBox();
            this.textBox_accesspassword = new System.Windows.Forms.TextBox();
            this.comboBox_bank = new System.Windows.Forms.ComboBox();
            this.textBox_epc = new System.Windows.Forms.TextBox();
            this.checkBoxContinous = new System.Windows.Forms.CheckBox();
            this.radioButton_kill = new System.Windows.Forms.RadioButton();
            this.radioButton_lock = new System.Windows.Forms.RadioButton();
            this.button_access = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_txpwr = new System.Windows.Forms.Label();
            this.label_txpower = new System.Windows.Forms.Label();
            this.trackBar_txpwr = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // Quit
            // 
            this.Quit.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Quit.Location = new System.Drawing.Point(192, 179);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(42, 32);
            this.Quit.TabIndex = 132;
            this.Quit.Text = "Quit";
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // comboBox_lockop
            // 
            this.comboBox_lockop.Items.Add("skip");
            this.comboBox_lockop.Items.Add("accessible");
            this.comboBox_lockop.Items.Add("perm. accessible");
            this.comboBox_lockop.Items.Add("secured accessible");
            this.comboBox_lockop.Items.Add("perm. inaccessibe");
            this.comboBox_lockop.Location = new System.Drawing.Point(112, 149);
            this.comboBox_lockop.Name = "comboBox_lockop";
            this.comboBox_lockop.Size = new System.Drawing.Size(123, 23);
            this.comboBox_lockop.TabIndex = 131;
            // 
            // textBox_killpassword
            // 
            this.textBox_killpassword.Location = new System.Drawing.Point(6, 103);
            this.textBox_killpassword.Name = "textBox_killpassword";
            this.textBox_killpassword.Size = new System.Drawing.Size(111, 23);
            this.textBox_killpassword.TabIndex = 129;
            // 
            // textBox_accesspassword
            // 
            this.textBox_accesspassword.Location = new System.Drawing.Point(122, 103);
            this.textBox_accesspassword.Name = "textBox_accesspassword";
            this.textBox_accesspassword.Size = new System.Drawing.Size(112, 23);
            this.textBox_accesspassword.TabIndex = 128;
            // 
            // comboBox_bank
            // 
            this.comboBox_bank.Items.Add("Kill PWD");
            this.comboBox_bank.Items.Add("Access PWD");
            this.comboBox_bank.Items.Add("EPC");
            this.comboBox_bank.Items.Add("TID");
            this.comboBox_bank.Items.Add("USER");
            this.comboBox_bank.Location = new System.Drawing.Point(7, 149);
            this.comboBox_bank.Name = "comboBox_bank";
            this.comboBox_bank.Size = new System.Drawing.Size(98, 23);
            this.comboBox_bank.TabIndex = 130;
            // 
            // textBox_epc
            // 
            this.textBox_epc.Location = new System.Drawing.Point(7, 61);
            this.textBox_epc.Name = "textBox_epc";
            this.textBox_epc.Size = new System.Drawing.Size(228, 23);
            this.textBox_epc.TabIndex = 127;
            // 
            // checkBoxContinous
            // 
            this.checkBoxContinous.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.checkBoxContinous.Location = new System.Drawing.Point(120, 30);
            this.checkBoxContinous.Name = "checkBoxContinous";
            this.checkBoxContinous.Size = new System.Drawing.Size(103, 16);
            this.checkBoxContinous.TabIndex = 126;
            this.checkBoxContinous.Text = "Continue";
            this.checkBoxContinous.CheckStateChanged += new System.EventHandler(this.checkBoxContinous_CheckStateChanged);
            // 
            // radioButton_kill
            // 
            this.radioButton_kill.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.radioButton_kill.Location = new System.Drawing.Point(62, 30);
            this.radioButton_kill.Name = "radioButton_kill";
            this.radioButton_kill.Size = new System.Drawing.Size(55, 16);
            this.radioButton_kill.TabIndex = 125;
            this.radioButton_kill.Text = "Kill";
            // 
            // radioButton_lock
            // 
            this.radioButton_lock.Checked = true;
            this.radioButton_lock.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.radioButton_lock.Location = new System.Drawing.Point(6, 30);
            this.radioButton_lock.Name = "radioButton_lock";
            this.radioButton_lock.Size = new System.Drawing.Size(56, 16);
            this.radioButton_lock.TabIndex = 124;
            this.radioButton_lock.Text = "Lock";
            // 
            // button_access
            // 
            this.button_access.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.button_access.Location = new System.Drawing.Point(78, 4);
            this.button_access.Name = "button_access";
            this.button_access.Size = new System.Drawing.Size(149, 22);
            this.button_access.TabIndex = 123;
            this.button_access.Text = "ACCESS";
            this.button_access.Click += new System.EventHandler(this.button_access_Click_1);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Kill password :";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(120, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.Text = "Access password :";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.Text = "Access Tag EPC :";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 19);
            this.label3.Text = "label3";
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(6, 178);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(163, 23);
            this.textBox6.TabIndex = 138;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 21);
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.Text = "Tag Bank :";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(115, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.Text = "Lock Op.";
            // 
            // label_txpwr
            // 
            this.label_txpwr.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label_txpwr.Location = new System.Drawing.Point(162, 214);
            this.label_txpwr.Name = "label_txpwr";
            this.label_txpwr.Size = new System.Drawing.Size(61, 12);
            this.label_txpwr.Text = "MAX";
            // 
            // label_txpower
            // 
            this.label_txpower.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label_txpower.Location = new System.Drawing.Point(3, 236);
            this.label_txpower.Name = "label_txpower";
            this.label_txpower.Size = new System.Drawing.Size(63, 10);
            this.label_txpower.Text = "Tx Pow.";
            // 
            // trackBar_txpwr
            // 
            this.trackBar_txpwr.LargeChange = 10;
            this.trackBar_txpwr.Location = new System.Drawing.Point(62, 227);
            this.trackBar_txpwr.Maximum = 70;
            this.trackBar_txpwr.Name = "trackBar_txpwr";
            this.trackBar_txpwr.Size = new System.Drawing.Size(147, 31);
            this.trackBar_txpwr.TabIndex = 145;
            this.trackBar_txpwr.TickFrequency = 10;
            this.trackBar_txpwr.ValueChanged += new System.EventHandler(this.trackBar_txpwr_ValueChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormLockKill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.label_txpwr);
            this.Controls.Add(this.label_txpower);
            this.Controls.Add(this.trackBar_txpwr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.comboBox_lockop);
            this.Controls.Add(this.textBox_killpassword);
            this.Controls.Add(this.textBox_accesspassword);
            this.Controls.Add(this.comboBox_bank);
            this.Controls.Add(this.textBox_epc);
            this.Controls.Add(this.checkBoxContinous);
            this.Controls.Add(this.radioButton_kill);
            this.Controls.Add(this.radioButton_lock);
            this.Controls.Add(this.button_access);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "FormLockKill";
            this.Text = "LockKillForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.ComboBox comboBox_lockop;
        private System.Windows.Forms.TextBox textBox_killpassword;
        private System.Windows.Forms.TextBox textBox_accesspassword;
        private System.Windows.Forms.ComboBox comboBox_bank;
        private System.Windows.Forms.TextBox textBox_epc;
        private System.Windows.Forms.CheckBox checkBoxContinous;
        private System.Windows.Forms.RadioButton radioButton_kill;
        private System.Windows.Forms.RadioButton radioButton_lock;
        private System.Windows.Forms.Button button_access;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_txpwr;
        private System.Windows.Forms.Label label_txpower;
        private System.Windows.Forms.TrackBar trackBar_txpwr;
        private System.Windows.Forms.Timer timer1;
    }
}