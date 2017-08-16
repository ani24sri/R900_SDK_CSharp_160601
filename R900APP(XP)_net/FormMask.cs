using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// For example mask ( How to do mask in demo program? )
//
// 1.Select Mask EPC Mode.
// You must use the EPC value. 
// If you read the tag, you can see the tag value. please refer to the below the example.
// 
// ex)
//      3000300833B2DDD9014000005858  (normally include the PC value)
//      3000 (PC) + 300833B2DDD9014000005858 (EPC)
// You need a EPC data. "300833B2DDD9014000005858"
//
//
// 2.Select Mask MULTI Mode.
// BANK : EPC
// 
// For Tag Configuration.
//    CRC           + PC              + EPC               : we can not see the CRC data.
// (4 digits)     (4 digits)    (digits is Different.)
//
// 3000300833B2DDD9014000005858 : If you want mask digits for "5858", please refer to the bleow.
//
// - FOR OFFSET(bit)
//  CRC 4 digits + PC 4 digits + EPC 20 digits(remove 5858 digits) = 28 digits * 4 = 112 (offser value)
//
// - FOR Length(bit)
// 5858 digits = 4 digits * 4 = 16(length value)
// 
// - FOR Mask data
// 5858(maks data)
//┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━


namespace R900APP_net
{
    public partial class FormMask : Form
    {
        public FormMask()
        {
            InitializeComponent();
            InitForm();
        }

        public void InitForm()
        {
            //set mask bank
            comboBox_bank.SelectedIndex = (int)Form1.rfidhost_param.mask_bank;

            //set mask offset
            textBox_offset.Text = Form1.rfidhost_param.mask_offset.ToString();

            //set mask length
            textBox_length.Text = Form1.rfidhost_param.mask_bits.ToString();

            if (Form1.rfidhost_param.mask_bits > 0)
            {
                unsafe
                {
                    byte[] buf = new byte[256];
                    fixed (byte* p = Form1.rfidhost_param.mskID, b = buf)
                    {
                        for (int i = 0; i < Form1.rfidhost_param.mskID_len; i++)
                            *(b + i) = *(p + i);
                    }

                    textBox_epcdata.Text = System.Text.Encoding.ASCII.GetString(buf, 0, buf.Length);
                    textBox_maskdata.Text = System.Text.Encoding.ASCII.GetString(buf, 0, buf.Length);
                }
            }

            switch (Form1.rfidhost_param.mask_mode)
            {
                case (int)Form1.MASK_MODE.EPC_MASK_MODE:
                    {
                        radioButton_epcmask.Checked = true;
                        radioButton_multimode.Checked = false;
                        textBox_epcdata.Enabled = true;
                        comboBox_bank.Enabled = false;
                        textBox_offset.Enabled = false;
                        textBox_length.Enabled = false;
                        textBox_maskdata.Enabled = false;
                        Refresh();
                    }
                    break;

                case (int)Form1.MASK_MODE.MULTI_MASK_MODE:
                    {
                        Refresh();
                        radioButton_epcmask.Checked = false;
                        radioButton_multimode.Checked = true;
                        textBox_epcdata.Enabled = true;
                        comboBox_bank.Enabled = true;
                        textBox_offset.Enabled = true;
                        textBox_length.Enabled = true;
                        textBox_maskdata.Enabled = true;
                    }
                    break;
            }
        }


        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton_epcmask_CheckedChanged(object sender, EventArgs e)
        {
            textBox_offset.Text = "";
            textBox_length.Text = "";
            textBox_maskdata.Text = "";

            textBox_epcdata.Enabled = true;
            comboBox_bank.Enabled = false;
            textBox_offset.Enabled = false;
            textBox_length.Enabled = false;
            textBox_maskdata.Enabled = false;
        }

        private void radioButton_multimode_CheckedChanged(object sender, EventArgs e)
        {
            textBox_epcdata.Text = "";

            textBox_epcdata.Enabled = false;
            comboBox_bank.Enabled = true;
            textBox_offset.Enabled = true;
            textBox_length.Enabled = true;
            textBox_maskdata.Enabled = true;
        }

        private void FormMask_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (radioButton_epcmask.Checked) //EPC Mask Mode
            {
                Form1.rfidhost_param.mask_mode = (int)Form1.MASK_MODE.EPC_MASK_MODE;

                if (textBox_epcdata.Text.Length != 0)
                {
                    Form1.rfidhost_param.mskID_len = (uint)textBox_epcdata.Text.Length;

                    if (true == UtilClass.BitCount(out Form1.rfidhost_param.mask_bits, textBox_epcdata.Text))
                    {
                        Form1.rfidhost_param.mask_offset = 2 * 16;
                        Form1.rfidhost_param.mask_bank = (byte)Form1.TAG_MEMORY_BANK.EPC;

                        unsafe
                        {
                            byte[] tagid = new byte[256];

                            UtilClass.HexStrToByteArray(out tagid, textBox_epcdata.Text);

                            fixed (byte* s = tagid, t = Form1.rfidhost_param.mskpattern)
                            {
                                for (int i = 0; i < tagid.Length; i++)
                                    *(t + i) = *(s + i);
                            }
                        }
                        //restore tag id
                        unsafe
                        {
                            byte[] ID = new byte[256];

                            ID = UtilClass.StrToByteArray(textBox_epcdata.Text);

                            fixed (byte* s = ID, t = Form1.rfidhost_param.mskID)
                            {
                                for (int i = 0; i < Form1.rfidhost_param.mskID_len; i++)
                                    *(t + i) = *(s + i);
                            }
                        }
                    }
                    else
                    {
                        Form1.rfidhost_param.mask_bits = 0;
                        Form1.rfidhost_param.mask_offset = 0;
                        MessageBox.Show("Wrong Tag EPC data");
                    }
                }
                else
                {
                    ;

                }
            }
            else if (radioButton_multimode.Checked) //Select Mask Mode
            {
                Form1.rfidhost_param.mask_mode = (int)Form1.MASK_MODE.MULTI_MASK_MODE;
                // bank
                switch (comboBox_bank.SelectedIndex)
                {
                    case (int)Form1.TAG_MEMORY_BANK.EPC:
                        Form1.rfidhost_param.mask_bank = (byte)Form1.TAG_MEMORY_BANK.EPC;
                        break;

                    case (int)Form1.TAG_MEMORY_BANK.RESERVED:
                        Form1.rfidhost_param.mask_bank = (byte)Form1.TAG_MEMORY_BANK.RESERVED;
                        break;

                    case (int)Form1.TAG_MEMORY_BANK.TID:
                        Form1.rfidhost_param.mask_bank = (byte)Form1.TAG_MEMORY_BANK.TID;
                        break;

                    case (int)Form1.TAG_MEMORY_BANK.USER:
                        Form1.rfidhost_param.mask_bank = (byte)Form1.TAG_MEMORY_BANK.USER;
                        break;
                }
                // offset
                if (textBox_offset.Text.Length != 0)
                {
                    Form1.rfidhost_param.mask_offset = Convert.ToUInt32(textBox_offset.Text);
                }
                // bit count
                if (textBox_length.Text.Length != 0)
                {
                    Form1.rfidhost_param.mask_bits = Convert.ToUInt32(textBox_length.Text);
                }
                // tag mask data
                if (textBox_maskdata.Text.Length != 0)
                {
                    uint len;

                    if (true == UtilClass.BitCount(out len, textBox_maskdata.Text))
                    {

                        unsafe
                        {
                            byte[] tagid = new byte[256];

                            UtilClass.HexStrToByteArray(out tagid, textBox_maskdata.Text);

                            fixed (byte* s = tagid, t = Form1.rfidhost_param.mskpattern)
                            {
                                for (int i = 0; i < tagid.Length; i++)
                                    *(t + i) = *(s + i);
                            }
                        }
                        //restore tag id
                        unsafe
                        {
                            byte[] ID = new byte[256];

                            ID = UtilClass.StrToByteArray(textBox_maskdata.Text);

                            fixed (byte* s = ID, t = Form1.rfidhost_param.mskID)
                            {
                                for (int i = 0; i < Form1.rfidhost_param.mskID_len; i++)
                                    *(t + i) = *(s + i);
                            }
                        }
                    }
                    else
                    {
                        Form1.rfidhost_param.mask_bits = 0;
                        Form1.rfidhost_param.mask_offset = 0;
                        MessageBox.Show("Wrong Tag EPC data");
                    }
                }
                else
                {
                    ;

                }
            }
        }
    }
}
