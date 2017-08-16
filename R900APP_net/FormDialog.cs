using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace R900APP_net
{
    public partial class FormDialog : Form
    {
        public FormDialog()
        {
            InitializeComponent();
        }

        public string Message
        {
            set
            {
                label1.Text = value;
            }
            get
            {
                return label1.Text;
            }
        }

    }
}