using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace R900APP_net
{
    public partial class FormAccess : Form
    {
        internal static UHFAPI_NET.UHFAPI_NET.structTAG_OP_PARAM InventoryContolParam;
        internal bool trigger_on = false;
        internal bool force_stop = false;
        internal bool by_trigger = false;
                                        // pc_epc,acs_pwd,kill_pwd,tid,reserved,uii,tid,user
        internal byte[] bankIDlist = { 0, 1, 2, 3 };
        internal string[] defaultoffset = { "0", "02", "00", "00" };
        internal string[] defaultlength = { "1", "6", "2", "2" };

        // Tx dB Text
        internal string[] dB = { "MAX", "-4dB", "-8dB", "-12dB", "-16dB", "-20dB", "-24dB", "-28dB" };

        public enum enumAccessResult
        {
            ACCESS_RESULT_OK = 0,
            ACCESS_RESULT_NOT_CONNECTED = -1,
            ACCESS_RESULT_NOT_DETECT = -2,
            ACCESS_RESULT_ACCESS_ERROR = -3,
        }

        public FormAccess()
        {
            InitializeComponent();
           
            // set event dispacher
            Form1.R900APP.evtAccessEPC += new UHFAPI_NET.UHFAPI_NET.AccessEPCDispacher(ShowAccessEPC);
            Form1.R900APP.evtAccessData += new UHFAPI_NET.UHFAPI_NET.AccessDataDispacher(ShowAccessData);
            Form1.R900APP.evtAccessResult += new UHFAPI_NET.UHFAPI_NET.AccessResultDispacher(ShowAccessResult);

            // setup list view
            if (Form1.R900_alive)
            {
                label3.Text = "On Line";
                label3.ForeColor = Color.Green;
            }
            else
            {
                label3.Text = "Off Line";
                label3.ForeColor = Color.Red;
            }

            // clear status line
            label2.Text = "";

            InitAccessParameters();

        }

        internal void InitAccessParameters()
        {
            radioButton1.Checked = true;
            radioButton2.Checked = false;

            checkBoxContinous.Checked = Form1.rfidhost_param.continuous;
            comboBox_bank.SelectedIndex = Form1.rfidhost_param.mem_bank;

            textBox_access.Text = "00000000";

            textBox_offset.Text = defaultoffset[comboBox_bank.SelectedIndex];
            textBox_length.Text = defaultlength[comboBox_bank.SelectedIndex];

            // init bank select
            //comboBox_bank.SelectedIndex = 0;
            //SetSelectBank();

            // init operation
            SetSelectOperation();

            trackBar_txpwr.Value = Form1.rfidhost_param.txpower * 10;
            label_txpwr.Text = dB[Form1.rfidhost_param.txpower];

            System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer();
            tm.Interval = 1000;
            tm.Enabled = true;
            tm.Tick += new EventHandler(timer1_Tick);

        }


        //┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
        //  Setup RFID Operation parameter        
        //┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
        public static void SetupOperationParameter()
        {
            if (Form1.rfidhost_param.mask_bits > 255)
                Form1.rfidhost_param.mask_bits = 255;

            InventoryContolParam.single_tag = Form1.rfidhost_param.continuous == true ? 0 : 1;
            InventoryContolParam.timeout = Form1.rfidhost_param.timeout * 1000;
            InventoryContolParam.QuerySelected = Form1.rfidhost_param.mask_bits > 0 ? 1 : 0;
            InventoryContolParam.mask.mskBits = 0;

            if (Form1.rfidhost_param.bldMask)
            {
                InventoryContolParam.mask.mskBits = Form1.rfidhost_param.mask_bits;
                InventoryContolParam.mask.mskOffset = Form1.rfidhost_param.mask_offset;
                InventoryContolParam.mask.mskMemBank = Form1.rfidhost_param.mask_bank;

                unsafe
                {
                    fixed (byte* t = InventoryContolParam.mask.mskPattern, s = Form1.rfidhost_param.mskpattern)
                    {
                        for (int i = 0; i < (InventoryContolParam.mask.mskBits + 7) / 8; i++)
                            *(t + i) = *(s + i);
                    }
                }

                Form1.R900APP.UHFAPI_SET_SelectAction(true, 0x30, ref InventoryContolParam.mask);

            }

            Form1.R900APP.UHFAPI_SET_OpMode(InventoryContolParam.single_tag > 0 ? true : false, Form1.rfidhost_param.bldMask, Form1.rfidhost_param.bldMask/*InventoryContolParam.QuerySelected > 0 ? true : false*/, InventoryContolParam.timeout);
        }

        private void button_access_Click(object sender, EventArgs e)
        {
            // check if reader linked
            force_stop = false;

            textBox_result.Text = "";
            while (!force_stop && (Form1.R900APP.UHFAPI_IsOpen() == false))
            {
                label2.Text = "linking device";
                Application.DoEvents();

                if (Form1.R900APP.UHFAPI_Open())
                {
                    Form1.R900_alive = true;
                    label3.Text = "On Line";
                    label3.ForeColor = Color.Green;
                }
            }

            if (button_access.Text.Equals("ACCESS"))
            {
                label2.Text = "starting access";
                Application.DoEvents();
                force_stop = false;
                by_trigger = false;
                StartAccess();
            }
            else
            {
                label2.Text = "stopping access";
                Application.DoEvents();
                force_stop = true;
                StopAccess();
            }
        }
      
        public void AccessTrigger(bool trigger)
        {
            // save status
            trigger_on = trigger;
            force_stop = true;

            if (button_access.Text.Equals("ACCESS") && trigger)
            {
                by_trigger = true;

                // start access
                StartAccess();

                // disable button
                button_access.Enabled = false;
            }
            else if (button_access.Text.Equals("STOP") && !trigger)
            {
                // stop access
                StopAccess();

                // enable button
                button_access.Enabled = true;
            }
            else if (button_access.Text.Equals("ACCESS") )
            {
                // enable button
                button_access.Enabled = true;
            }
        }

        internal bool HEX32(out UInt32 number, string hexastr)
        {
            number = 0;
            string str = hexastr.ToLower();
            for (int i = 0 ; i < hexastr.Length ; i++ )
            {
                number <<= 4;
                if ((str[i] >= '0') && (str[i] <= '9'))
                {
                    number += (UInt32)(str[i] - '0');
                }
                else if ((str[i] >= 'a') && (str[i] <= 'f'))
                {
                    number += (UInt32)(str[i] - 'a' + 10);
                }
                else
                    return false;
            }
            return true;
        }

        internal bool HEXSTR(out ushort[] buff, string hexastr)
        {
            string str = hexastr.ToLower();
            string str4;
            buff = new ushort [(hexastr.Length+3)/4];
            for (int i = 0; i < hexastr.Length; )
            {
                UInt32 val;
                buff[i / 4] = 0;
                str4 = str.Substring(i, 4);
                if (!HEX32(out val, str4))
                {
                    return false;
                }
                buff[i / 4] = (ushort)val;
                i += 4;
            }
            return true;
        }

        //UHFAPI_NET.UHFAPI_NET.enumAccessResult enumResult;
        
        internal void StartAccess()
        {
            byte MemBank = bankIDlist[comboBox_bank.SelectedIndex];
            UInt32 offset = Convert.ToUInt32(textBox_offset.Text);
            UInt32 length = Convert.ToUInt32(textBox_length.Text);
            UInt32 pwdACCESS;

            button_access.Text = "STOP";
            force_stop = false;
            label2.Text = "";
            textBox_result.Text = "";

            if (false == HEX32(out pwdACCESS, textBox_access.Text))
            {
                AccessEnd();
                label2.Text = "access terminated by bad parameter";
                return;
            }

            SetupOperationParameter();

            // start access
            if (radioButton1.Checked)
            {
                // enumResult = Form1.R900APP.UHFAPI_ReadTag(MemBank, offset, length, pwdACCESS, InventoryContolParam, true); //If you are setting "true", you can see the retrun value. like below.

                //read access
                Form1.R900APP.UHFAPI_ReadTag(MemBank, offset, length, pwdACCESS, InventoryContolParam, false); 
                textBox_epc.Text = "";
                textBox_write.Text = "";
            }
            else if (radioButton2.Checked)
            {
                // write access
                ushort[] szWriteData;

                if (true == HEXSTR(out szWriteData, textBox_write.Text))
                {
                    Form1.R900APP.UHFAPI_WriteTag(MemBank, offset, length, ref szWriteData, pwdACCESS, InventoryContolParam, false);
                    textBox_epc.Text = "";
                    //textBox4.Text = "";
                }
                else
                {
                    AccessEnd();
                    label2.Text = "access terminated by bad parameter";
                }
            }
        }

        internal void StopAccess()
        {
            Form1.R900APP.UHFAPI_Stop();
            AccessEnd();
        }

        public void ShowAccessEPC(string epc)
        {
            textBox_epc.Text = epc;
        }

        public void ShowAccessData(string data)
        {
            textBox_write.Text = data;
        }

        public void ShowAccessResult(string res)
        {
            if (res == "Success" || res == "OK") //add by cjlee
            {
                textBox_result.Text = res;  //success 
            }
            else
                textBox_result.Text = res;  //fail 
        }

        public void AccessEnd()
        {
            button_access.Text = "ACCESS";
            if ( (force_stop && !by_trigger) || (label3.Text != "On Line") )
            {
                label2.Text = "access terminated";
            }
            else
                label2.Text = "access finished";
            by_trigger = false;
        }

        public void LinkLost()
        {
            label3.Text = "Off Line";
            label3.ForeColor = Color.Red;

            if (button_access.Text != "ACCESS")
            {
                button_access.Text = "ACCESS";
                // enable button
                button_access.Enabled = true;
                // clear trigger state
                trigger_on = false;
                by_trigger = false;
                force_stop = false;

                label2.Text = "link lost";
            }

        }

        public void PowerResume()
        {
            label2.Text = "power cycled";
        }

        internal void SetSelectBank()
        {
            // one of fixed locations
            if (comboBox_bank.SelectedIndex < 4)
            {
                textBox_offset.Text = defaultoffset[comboBox_bank.SelectedIndex];
                textBox_length.Text = defaultlength[comboBox_bank.SelectedIndex];
            }
            else
            {
                textBox_offset.Text = defaultoffset[comboBox_bank.SelectedIndex];
                textBox_length.Text = defaultlength[comboBox_bank.SelectedIndex];
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1.rfidhost_param.mem_bank = comboBox_bank.SelectedIndex;
            textBox_offset.Text = defaultoffset[comboBox_bank.SelectedIndex];
            textBox_length.Text = defaultlength[comboBox_bank.SelectedIndex];
            Refresh();
        }


        internal void SetSelectOperation()
        {
            if (radioButton1.Checked) // read
            {
                textBox_epc.Enabled = false;
                textBox_write.Enabled = false;
            }
            else if (radioButton2.Checked) // write
            {
                textBox_epc.Enabled = false;
                textBox_write.Enabled = true;
            }
           
        }

        private void radioButton_Click(object sender, EventArgs e)
        {
            SetSelectOperation();
        }

        private void FormAccess_FormClosing(object sender, FormClosingEventArgs e)
        {
            force_stop = true;
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void trackBar_txpwr_Scroll(object sender, EventArgs e)
        {
            int level = trackBar_txpwr.Value;
            Form1.rfidhost_param.txpower = level / 10;

            if (Form1.R900APP.UHFAPI_SET_PowerControl((uint)(level * 4)))
            {
                label_txpwr.Text = dB[Form1.rfidhost_param.txpower];
            }
            else
            {
                label_txpwr.Text = "ERROR";
            }
        }

        private void textBox_write_TextChanged(object sender, EventArgs e)
        {
            textBox_count.Text = textBox_write.Text.Length.ToString();
        }

        private void comboBox_bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1.rfidhost_param.mem_bank = comboBox_bank.SelectedIndex;
            textBox_offset.Text = defaultoffset[comboBox_bank.SelectedIndex];
            textBox_length.Text = defaultlength[comboBox_bank.SelectedIndex];
            Refresh();
        }

        private void checkBoxContinous_CheckedChanged(object sender, EventArgs e)
        {
            Form1.rfidhost_param.continuous = checkBoxContinous.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Form1.R900APP.UHFAPI_IsOpen())
            {
                label3.Text = "On Line";
                label3.ForeColor = Color.Green;

            }
            else
            {
                label3.Text = "Off Line";
                label3.ForeColor = Color.Red;
            }
        }

    }


}