namespace R900APP_net
{
    partial class Form1
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
            this.label3_led = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.label_version = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // label3_led
            // 
            this.label3_led.Location = new System.Drawing.Point(59, 10);
            this.label3_led.Name = "label3_led";
            this.label3_led.Size = new System.Drawing.Size(71, 19);
            this.label3_led.Text = "label3";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(58, 117);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 31);
            this.button2.TabIndex = 4;
            this.button2.Text = "Read/Write";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "InventoryTest";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(58, 233);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 27);
            this.button3.TabIndex = 5;
            this.button3.Text = "Bind COMPORT";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(59, 165);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 31);
            this.button4.TabIndex = 7;
            this.button4.Text = "Lock/Kill";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Close";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // label_version
            // 
            this.label_version.Location = new System.Drawing.Point(58, 39);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(140, 19);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3_led);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3_led;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.Label label_version;
        private System.Windows.Forms.Timer timer1;


    }
}

