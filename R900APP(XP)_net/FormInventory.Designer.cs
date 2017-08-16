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
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.checkBoxContinous = new System.Windows.Forms.CheckBox();
            this.buttonInventory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar_txpwr = new System.Windows.Forms.TrackBar();
            this.label_txpower = new System.Windows.Forms.Label();
            this.label_txpwr = new System.Windows.Forms.Label();
            this.checkBox_mask = new System.Windows.Forms.CheckBox();
            this.button_mask = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_txpwr)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Location = new System.Drawing.Point(12, 78);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(350, 312);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "PC/EPC";
            this.columnHeader1.Width = 324;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Count";
            this.columnHeader2.Width = 47;
            // 
            // checkBoxContinous
            // 
            this.checkBoxContinous.Location = new System.Drawing.Point(283, 10);
            this.checkBoxContinous.Name = "checkBoxContinous";
            this.checkBoxContinous.Size = new System.Drawing.Size(100, 16);
            this.checkBoxContinous.TabIndex = 1;
            this.checkBoxContinous.Text = "Continuous";
            this.checkBoxContinous.CheckedChanged += new System.EventHandler(this.checkBoxContinous_CheckedChanged);
            // 
            // buttonInventory
            // 
            this.buttonInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonInventory.Location = new System.Drawing.Point(93, 7);
            this.buttonInventory.Name = "buttonInventory";
            this.buttonInventory.Size = new System.Drawing.Size(173, 58);
            this.buttonInventory.TabIndex = 2;
            this.buttonInventory.Text = "INVENTORY";
            this.buttonInventory.UseVisualStyleBackColor = false;
            this.buttonInventory.Click += new System.EventHandler(this.buttonInventory_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F);
            this.label1.Location = new System.Drawing.Point(292, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(37, 485);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(19, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // trackBar_txpwr
            // 
            this.trackBar_txpwr.LargeChange = 10;
            this.trackBar_txpwr.Location = new System.Drawing.Point(12, 429);
            this.trackBar_txpwr.Maximum = 70;
            this.trackBar_txpwr.Name = "trackBar_txpwr";
            this.trackBar_txpwr.Size = new System.Drawing.Size(350, 45);
            this.trackBar_txpwr.TabIndex = 42;
            this.trackBar_txpwr.TickFrequency = 10;
            this.trackBar_txpwr.Scroll += new System.EventHandler(this.trackBar_txpwr_Scroll);
            // 
            // label_txpower
            // 
            this.label_txpower.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label_txpower.Location = new System.Drawing.Point(19, 405);
            this.label_txpower.Name = "label_txpower";
            this.label_txpower.Size = new System.Drawing.Size(68, 21);
            this.label_txpower.TabIndex = 7;
            this.label_txpower.Text = "Tx Power";
            // 
            // label_txpwr
            // 
            this.label_txpwr.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label_txpwr.Location = new System.Drawing.Point(287, 405);
            this.label_txpwr.Name = "label_txpwr";
            this.label_txpwr.Size = new System.Drawing.Size(61, 12);
            this.label_txpwr.TabIndex = 9;
            this.label_txpwr.Text = "MAX";
            // 
            // checkBox_mask
            // 
            this.checkBox_mask.Location = new System.Drawing.Point(263, 486);
            this.checkBox_mask.Name = "checkBox_mask";
            this.checkBox_mask.Size = new System.Drawing.Size(27, 17);
            this.checkBox_mask.TabIndex = 145;
            this.checkBox_mask.CheckedChanged += new System.EventHandler(this.checkBox_mask_CheckedChanged);
            // 
            // button_mask
            // 
            this.button_mask.Location = new System.Drawing.Point(289, 485);
            this.button_mask.Name = "button_mask";
            this.button_mask.Size = new System.Drawing.Size(73, 20);
            this.button_mask.TabIndex = 144;
            this.button_mask.Text = "Mask";
            this.button_mask.Click += new System.EventHandler(this.button_mask_Click);
            // 
            // button_clear
            // 
            this.button_clear.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_clear.Location = new System.Drawing.Point(236, 524);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(61, 32);
            this.button_clear.TabIndex = 151;
            this.button_clear.Text = "Clear";
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // Quit
            // 
            this.Quit.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Quit.Location = new System.Drawing.Point(300, 524);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(58, 32);
            this.Quit.TabIndex = 150;
            this.Quit.Text = "Quit";
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormInventory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(379, 572);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.checkBox_mask);
            this.Controls.Add(this.button_mask);
            this.Controls.Add(this.label_txpwr);
            this.Controls.Add(this.label_txpower);
            this.Controls.Add(this.trackBar_txpwr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonInventory);
            this.Controls.Add(this.checkBoxContinous);
            this.Controls.Add(this.listView1);
            this.Name = "FormInventory";
            this.Text = "FormInventory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInventory_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_txpwr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label_txpower;
        private System.Windows.Forms.Label label_txpwr;
        private System.Windows.Forms.CheckBox checkBox_mask;
        private System.Windows.Forms.Button button_mask;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Timer timer1;
    }
}