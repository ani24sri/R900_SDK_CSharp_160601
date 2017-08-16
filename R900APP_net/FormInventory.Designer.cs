namespace R900APP_net
{
    partial class FormInventory
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.checkBoxContinous = new System.Windows.Forms.CheckBox();
            this.buttonInventory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar_txpwr = new System.Windows.Forms.TrackBar();
            this.Quit = new System.Windows.Forms.Button();
            this.label_txpower = new System.Windows.Forms.Label();
            this.label_txpwr = new System.Windows.Forms.Label();
            this.button_mask = new System.Windows.Forms.Button();
            this.checkBox_mask = new System.Windows.Forms.CheckBox();
            this.button_clear = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.Add(this.columnHeader1);
            this.listView1.Columns.Add(this.columnHeader2);
            this.listView1.Location = new System.Drawing.Point(3, 69);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(232, 127);
            this.listView1.TabIndex = 0;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "PC/EPC";
            this.columnHeader1.Width = 190;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Count";
            this.columnHeader2.Width = 47;
            // 
            // checkBoxContinous
            // 
            this.checkBoxContinous.Location = new System.Drawing.Point(139, 3);
            this.checkBoxContinous.Name = "checkBoxContinous";
            this.checkBoxContinous.Size = new System.Drawing.Size(96, 16);
            this.checkBoxContinous.TabIndex = 1;
            this.checkBoxContinous.Text = "Continuous";
            this.checkBoxContinous.CheckStateChanged += new System.EventHandler(this.checkBoxContinous_CheckStateChanged);
            // 
            // buttonInventory
            // 
            this.buttonInventory.Location = new System.Drawing.Point(66, 25);
            this.buttonInventory.Name = "buttonInventory";
            this.buttonInventory.Size = new System.Drawing.Size(87, 36);
            this.buttonInventory.TabIndex = 2;
            this.buttonInventory.Text = "INVENTORY";
            this.buttonInventory.Click += new System.EventHandler(this.buttonInventory_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(179, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 33);
            this.label1.Text = "0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 21);
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 19);
            this.label3.Text = "label3";
            // 
            // trackBar_txpwr
            // 
            this.trackBar_txpwr.LargeChange = 10;
            this.trackBar_txpwr.Location = new System.Drawing.Point(6, 217);
            this.trackBar_txpwr.Maximum = 70;
            this.trackBar_txpwr.Name = "trackBar_txpwr";
            this.trackBar_txpwr.Size = new System.Drawing.Size(208, 31);
            this.trackBar_txpwr.TabIndex = 42;
            this.trackBar_txpwr.TickFrequency = 10;
            this.trackBar_txpwr.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // Quit
            // 
            this.Quit.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Quit.Location = new System.Drawing.Point(176, 250);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(58, 32);
            this.Quit.TabIndex = 133;
            this.Quit.Text = "Quit";
            this.Quit.Click += new System.EventHandler(this.Quit_Click_1);
            // 
            // label_txpower
            // 
            this.label_txpower.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label_txpower.Location = new System.Drawing.Point(6, 202);
            this.label_txpower.Name = "label_txpower";
            this.label_txpower.Size = new System.Drawing.Size(68, 12);
            this.label_txpower.Text = "Tx Power";
            // 
            // label_txpwr
            // 
            this.label_txpwr.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label_txpwr.Location = new System.Drawing.Point(92, 202);
            this.label_txpwr.Name = "label_txpwr";
            this.label_txpwr.Size = new System.Drawing.Size(61, 12);
            this.label_txpwr.Text = "MAX";
            // 
            // button_mask
            // 
            this.button_mask.Location = new System.Drawing.Point(194, 198);
            this.button_mask.Name = "button_mask";
            this.button_mask.Size = new System.Drawing.Size(38, 20);
            this.button_mask.TabIndex = 137;
            this.button_mask.Text = "Mask";
            this.button_mask.Click += new System.EventHandler(this.button_mask_Click);
            // 
            // checkBox_mask
            // 
            this.checkBox_mask.Location = new System.Drawing.Point(168, 199);
            this.checkBox_mask.Name = "checkBox_mask";
            this.checkBox_mask.Size = new System.Drawing.Size(27, 17);
            this.checkBox_mask.TabIndex = 143;
            this.checkBox_mask.CheckStateChanged += new System.EventHandler(this.checkBox_mask_CheckStateChanged_1);
            // 
            // button_clear
            // 
            this.button_clear.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_clear.Location = new System.Drawing.Point(132, 250);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(41, 32);
            this.button_clear.TabIndex = 149;
            this.button_clear.Text = "Clear";
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.checkBox_mask);
            this.Controls.Add(this.button_mask);
            this.Controls.Add(this.label_txpwr);
            this.Controls.Add(this.label_txpower);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.trackBar_txpwr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonInventory);
            this.Controls.Add(this.checkBoxContinous);
            this.Controls.Add(this.listView1);
            this.Name = "FormInventory";
            this.Text = "FormInventory";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormInventory_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.CheckBox checkBoxContinous;
        private System.Windows.Forms.Button buttonInventory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar_txpwr;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Label label_txpower;
        private System.Windows.Forms.Label label_txpwr;
        private System.Windows.Forms.Button button_mask;
        private System.Windows.Forms.CheckBox checkBox_mask;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Timer timer1;
    }
}