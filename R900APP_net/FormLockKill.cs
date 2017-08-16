using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace R900APP_net
{

    public partial class FormLockKill : Form
    {
        internal static UHFAPI_NET.UHFAPI_NET.structTAG_OP_PARAM InventoryContolParam;
        internal bool trigger_on = false;
        internal bool force_stop = false;
        internal bool by_trigger = false;

        // Tx dB Text
        internal string[] dB = { "MAX", "-4dB", "-8dB", "-12dB", "-16dB", "-20dB", "-24dB", "-28dB" };

        public FormLockKill()
        {
            InitializeComponent();

            // set event dispacher
            Form1.R900APP.evtAccessEPC += new UHFAPI_NET.UHFAPI_NET.AccessEPCDispacher(ShowLockKillAccessEPC);
            Form1.R900APP.evtAccessResult += new UHFAPI_NET.UHFAPI_NET.AccessResultDispacher(ShowLockKillAccessResult);

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

            InitAccessParameters();
        }

        internal void InitAccessParameters()
        {
            radioButton_lock.Checked = true;
            radioButton_kill.Checked = false;

            textBox_killpassword.Text = "00000000";
            textBox_accesspassword.Text = "00000000";

            // init bank select
            comboBox_bank.SelectedIndex = 0;
            comboBox_lockop.SelectedIndex = 0;
            
            textBox6.Text = "";

            trackBar_txpwr.Value = Form1.rfidhost_param.txpower * 10;
            label_txpwr.Text = dB[Form1.rfidhost_param.txpower];
            
            Form1.rfidhost_param.continuous = checkBoxContinous.Checked;

            Timer tm = new Timer();
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
                        for (int i = 0; i < (InventoryContolParam.mask.mskBits + 7) /8 ; i++)
                            *(t + i) = *(s + i);
                    }
                }

                Form1.R900APP.UHFAPI_SET_SelectAction(true, 0x30, ref InventoryContolParam.mask);

            }

            Form1.R900APP.UHFAPI_SET_OpMode(InventoryContolParam.single_tag > 0 ? true : false, Form1.rfidhost_param.bldMask, Form1.rfidhost_param.bldMask/*InventoryContolParam.QuerySelected > 0 ? true : false*/, InventoryContolParam.timeout);
            
        }

        private void button_access_Click_1(object sender, EventArgs e)
        {
            // check if reader linked
            force_stop = false;
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

        public void LockAccessTrigger(bool trigger)
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
            else if (button_access.Text.Equals("ACCESS"))
            {
                // enable button
                button_access.Enabled = true;
            }
        }

        public ushort SWAPLSB2(int value)
        {
            int res = (((((value) & 1) << 1) | (((value) >> 1) & 1)) & 3);
            return (ushort)res;
        }

        internal bool HEX32(out UInt32 number, string hexastr)
        {
            number = 0;
            string str = hexastr.ToLower();
            for (int i = 0; i < hexastr.Length; i++)
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
            buff = new ushort[(hexastr.Length + 3) / 4];
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

        internal void StartAccess()
        {
            button_access.Text = "STOP";
            force_stop = false;
            textBox6.Text = "";

            SetupOperationParameter();

            if (radioButton_lock.Checked)
            {
                UInt32 pwdACCESS;
                ushort lock_enable = 0;
                ushort lock_mask = 0;

                textBox_epc.Text = "";

                int mark;
                int index = (int)comboBox_bank.SelectedIndex;

                if (false == HEX32(out pwdACCESS, textBox_accesspassword.Text))
                {
                    AccessEnd();
                    MessageBox.Show("Wrong Access Password!!");
                    return;
                }

                // set kill password field
                if (index == 0)
                {
                    mark = (int)comboBox_lockop.SelectedIndex;

                    lock_enable |= (ushort)(mark > 0 ? 3 : 0);
                    lock_mask |= (ushort)(mark > 0 ? mark - 1 : 0);

                    lock_enable <<= 8;
                    lock_mask <<= 8;
                }
                else
                {
                    mark = 0;
                }

                // set access password field
                if (index == 1)
                {
                    mark = (int)comboBox_lockop.SelectedIndex;

                    lock_enable |= (ushort)(mark > 0 ? 3 : 0);
                    lock_mask |= (ushort)(mark > 0 ? mark - 1 : 0);

                    lock_enable <<= 6;
                    lock_mask <<= 6;
                }
                else
                {
                    mark = 0;
                }

                // set EPC memory field
                if (index == 2)
                {
                    mark = (int)comboBox_lockop.SelectedIndex;

                    lock_enable |= (ushort)(mark > 0 ? 3 : 0);
                    lock_mask |= (ushort)(mark > 0 ? mark - 1 : 0);

                    lock_enable <<= 4;
                    lock_mask <<= 4;

                }
                else
                {
                    mark = 0;
                }

                // TID memory field
                if (index == 3)
                {
                    mark = (int)comboBox_lockop.SelectedIndex;

                    lock_enable |= (ushort)(mark > 0 ? 3 : 0);
                    lock_mask |= (ushort)(mark > 0 ? mark - 1 : 0);

                    lock_enable <<= 2;
                    lock_mask <<= 2;
                }
                else
                {
                    mark = 0;
                }

                // USER memory field
                if (index == 4)
                {
                    mark = (int)comboBox_lockop.SelectedIndex;

                    lock_enable |= (ushort)(mark > 0 ? 3 : 0);
                    lock_mask |= (ushort)(mark > 0 ? mark - 1 : 0);

                    lock_enable <<= 0;
                    lock_mask <<= 0;
                }
                else
                {
                    mark = 0;
                }

                Form1.R900APP.UHFAPI_LockSetTag((UHFAPI_NET.UHFAPI_NET.enumLockMasks)lock_mask, (UHFAPI_NET.UHFAPI_NET.enumLockMasks)lock_enable, pwdACCESS, FormLockKill.InventoryContolParam, false);

            }
            else if (radioButton_kill.Checked)
            {
                UInt32 pwdACCESS;
                UInt32 pwdKILL;

                textBox_epc.Text = "";

                if (false == HEX32(out pwdACCESS, textBox_accesspassword.Text))
                {
                    AccessEnd();
                    MessageBox.Show("Wrong Access Password!!");
                    return;
                }

                if (false == HEX32(out pwdKILL, textBox_killpassword.Text))
                {
                    AccessEnd();
                    MessageBox.Show("Wrong Access Password!!");
                    return;
                }

                System.Windows.Forms.DialogResult rts = System.Windows.Forms.MessageBox.Show("If you click on this YES, the kill tag will run..", "Warring", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                switch (rts)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        {
                            SetupOperationParameter();

                            Form1.R900APP.UHFAPI_KillTag(pwdKILL, pwdACCESS, FormLockKill.InventoryContolParam, false);
                        }
                        break;

                    case System.Windows.Forms.DialogResult.No:
                        {
                            AccessEnd();
                        }
                        break;
                }
            }
        }

        public void ShowLockKillAccessEPC(string epc)
        {
            textBox_epc.Text = epc;
        }

        public void ShowLockKillAccessResult(string res)
        {
            //textBox6.Text = res;

            if (res == "Success" || res == "OK") //add by cjlee
            {
                textBox6.Text = res;  //success led
            }
            else
                textBox6.Text = res;  //fail led
        }
        
        internal void StopAccess()
        {
            Form1.R900APP.UHFAPI_Stop();
            AccessEnd();
        }

        public void AccessEnd()
        {
            button_access.Text = "ACCESS";
            if ((force_stop && !by_trigger) || (label3.Text != "On Line"))
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
            MessageBox.Show("Power Resume");
        }
        
        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void trackBar_txpwr_ValueChanged(object sender, EventArgs e)
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

        private void checkBoxContinous_CheckStateChanged(object sender, EventArgs e)
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