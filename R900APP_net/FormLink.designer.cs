namespace R900APP_net
{
    partial class FormLink
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
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonBind = new System.Windows.Forms.Button();
            this.comboBoxDevices = new System.Windows.Forms.ComboBox();
            this.comboBoxFreeComs = new System.Windows.Forms.ComboBox();
            this.buttonLink = new System.Windows.Forms.Button();
            this.comboBoxComports = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
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
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(42, 133);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(163, 31);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "DEVICE SEARCH";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonBind
            // 
            this.buttonBind.Location = new System.Drawing.Point(63, 237);
            this.buttonBind.Name = "buttonBind";
            this.buttonBind.Size = new System.Drawing.Size(114, 26);
            this.buttonBind.TabIndex = 1;
            this.buttonBind.Text = "BIND";
            this.buttonBind.Click += new System.EventHandler(this.buttonBind_Click);
            // 
            // comboBoxDevices
            // 
            this.comboBoxDevices.Location = new System.Drawing.Point(3, 167);
            this.comboBoxDevices.Name = "comboBoxDevices";
            this.comboBoxDevices.Size = new System.Drawing.Size(232, 23);
            this.comboBoxDevices.TabIndex = 2;
            this.comboBoxDevices.SelectedIndexChanged += new System.EventHandler(this.comboBoxDevices_SelectedIndexChanged);
            // 
            // comboBoxFreeComs
            // 
            this.comboBoxFreeComs.Location = new System.Drawing.Point(49, 209);
            this.comboBoxFreeComs.Name = "comboBoxFreeComs";
            this.comboBoxFreeComs.Size = new System.Drawing.Size(145, 23);
            this.comboBoxFreeComs.TabIndex = 3;
            // 
            // buttonLink
            // 
            this.buttonLink.Location = new System.Drawing.Point(42, 16);
            this.buttonLink.Name = "buttonLink";
            this.buttonLink.Size = new System.Drawing.Size(163, 35);
            this.buttonLink.TabIndex = 4;
            this.buttonLink.Text = "Select COMPORT";
            this.buttonLink.Click += new System.EventHandler(this.buttonLink_Click);
            // 
            // comboBoxComports
            // 
            this.comboBoxComports.Location = new System.Drawing.Point(3, 57);
            this.comboBoxComports.Name = "comboBoxComports";
            this.comboBoxComports.Size = new System.Drawing.Size(232, 23);
            this.comboBoxComports.TabIndex = 5;
            // 
            // FormLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.comboBoxComports);
            this.Controls.Add(this.buttonLink);
            this.Controls.Add(this.comboBoxFreeComs);
            this.Controls.Add(this.comboBoxDevices);
            this.Controls.Add(this.buttonBind);
            this.Controls.Add(this.buttonSearch);
            this.Name = "FormLink";
            this.Text = "FormLink";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonBind;
        private System.Windows.Forms.ComboBox comboBoxDevices;
        private System.Windows.Forms.ComboBox comboBoxFreeComs;
        private System.Windows.Forms.Button buttonLink;
        private System.Windows.Forms.ComboBox comboBoxComports;
        private System.Windows.Forms.MenuItem menuItem1;
    }
}

