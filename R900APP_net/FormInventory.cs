using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UHFAPI_NET;

namespace R900APP_net
{

    public partial class FormInventory : Form
    {
        internal static UHFAPI_NET.UHFAPI_NET.structTAG_OP_PARAM InventoryContolParam;
        internal int count = 0; // tag count
        internal bool trigger_on = false;
        internal bool force_stop = false;
        internal bool by_trigger = false;

        public static FormInventory formInventory;
        public static FormAccess formAccess;
        public static FormLockKill formLockkill;
        public static FormLink formLink;
        public static FormMask formMask;

        // Tx dB Text
        internal string[] dB = { "MAX", "-4dB", "-8dB", "-12dB", "-16dB", "-20dB", "-24dB", "-28dB" };


        public FormInventory()
        {
            InitializeComponent();

            // set event dispacher
            Form1.R900APP.evtInventoryEPC += new UHFAPI_NET.UHFAPI_NET.InventoryEPCDispacher(ShowInventoryEPC);

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

            // upload local inventory data
            if (Form1.R900_alive)
            {
                string str = Form1.R900APP.UHFAPI_GetFirmwareVersion();

                label2.Text = "Uploading local tag information";
                // set event dispacher
                Form1.R900APP.evtUploadEPC += new UHFAPI_NET.UHFAPI_NET.InventoryEPCDispacher(ShowUploadEPC);
                Form1.R900APP.R900LIB_UploadInventory();
                Form1.R900APP.R900LIB_ClearInventory();
                label2.Text = "Upload finished";
            }

            trackBar_txpwr.Value = Form1.rfidhost_param.txpower * 10;
            label_txpwr.Text = dB[Form1.rfidhost_param.txpower];

            checkBoxContinous.Checked = Form1.rfidhost_param.continuous;
            checkBox_mask.Checked = Form1.rfidhost_param.bldMask;

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
                        for (int i = 0; i < (InventoryContolParam.mask.mskBits + 7)/8; i++)
                            *(t + i) = *(s + i);
                    }
                }

                Form1.R900APP.UHFAPI_SET_SelectAction(true, 0x30, ref InventoryContolParam.mask);

            }

            Form1.R900APP.UHFAPI_SET_OpMode(InventoryContolParam.single_tag > 0 ? true : false, Form1.rfidhost_param.bldMask, Form1.rfidhost_param.bldMask/*InventoryContolParam.QuerySelected > 0 ? true : false*/, InventoryContolParam.timeout);
        }


        private void buttonInventory_Click(object sender, EventArgs e)
        {
            // check if reader linked
            force_stop = false;
            while (!force_stop && (Form1.R900APP.UHFAPI_IsOpen() == false) )
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

            if (buttonInventory.Text.Equals("INVENTORY"))
            {
                label2.Text = "starting inventory";
                Application.DoEvents();
                force_stop = false;
                by_trigger = false;
                StartInventory();
            }
            else
            {
                label2.Text = "stopping inventory";
                Application.DoEvents();
                force_stop = true;
                StopInventory();
            }
        }

        public void InventoryTrigger(bool trigger)
        {
            // save status
            trigger_on = trigger;
            force_stop = true;

            if (buttonInventory.Text.Equals("INVENTORY") && trigger)
            {
                by_trigger = true;

                //Start inventory
                StartInventory();

                //Disable button
                buttonInventory.Enabled = false;
            }
            else if (buttonInventory.Text.Equals("STOP") && !trigger)
            {
                //Stop inventory
                StopInventory();

                //Enable button
                buttonInventory.Enabled = true;
            }
            else if (buttonInventory.Text.Equals("INVENTORY") )
            {
                //Enable button
                buttonInventory.Enabled = true;
            }
        }

        public void PrepareContinuousInventoryParameter()
        {
            // sample parameters for single no slect mask
            InventoryContolParam.single_tag = (int)0;
            InventoryContolParam.QuerySelected = (int)0;
            InventoryContolParam.timeout = 0; // 0 means endless
            InventoryContolParam.mask.mskBits = 0; // do not use mask
        }

        public void PrepareSingleInventoryParameter()
        {
            // sample parameters for single no slect mask
            InventoryContolParam.single_tag = (int)1;
            InventoryContolParam.QuerySelected = (int)0;
            InventoryContolParam.timeout = 0; // 0 means endless
            InventoryContolParam.mask.mskBits = 0; // do not use mask
        }


        internal void StartInventory()
        {
            buttonInventory.Text = "STOP";
            force_stop = false;
            label2.Text = "";

            //Basic setting is multi mode.
            
            //Form1.R900APP.UHFAPI_SetAirDura(190, 10);

            //set session
            //Form1.R900APP.UHFAPI_SET_Session(0x31);

            //set q value
            //Form1.R900APP.UHFAPI_SET_QValue(5);

            //set inventory target
            //Form1.R900APP.UHFAPI_SET_InventoryTarget(0x30);

            // prepare inventory parameter
            if (checkBoxContinous.Checked)
                PrepareContinuousInventoryParameter();
            else
                PrepareSingleInventoryParameter();

            //set operation parameter.
            SetupOperationParameter();

            //start inventory
            Form1.R900APP.UHFAPI_Inventory(InventoryContolParam, false);
        }

        internal void StopInventory()
        {
            Form1.R900APP.UHFAPI_Stop();
            buttonInventory.Text = "INVENTORY";
            buttonInventory.Enabled = true;
            label2.Text = "inventory terminated";
        }

        public void ShowInventoryEPC(string epc)
        {
            int i;
            int count = listView1.Items.Count;

            for (i = 0; i < count; i++)
                if (epc == listView1.Items[i].SubItems[0].Text)
                    break;

            // increase count for repeated detection
            if (i < count)
                listView1.Items[i].SubItems[1].Text = Convert.ToString(Convert.ToInt32(listView1.Items[i].SubItems[1].Text) + 1);
            // increase tag count
            else
            {
                ListViewItem item = new ListViewItem(epc);
                item.SubItems.Add("1");
                listView1.Items.Add(item);
                label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) + 1);
            }
        }

        public void InventoryEnd()
        {
            buttonInventory.Text = "INVENTORY";
            if ( (force_stop && !by_trigger) || (label3.Text != "On Line") )
            {
                label2.Text = "inventory terminated";
            }
            else
                label2.Text = "inventory finished";
            by_trigger = false;
        }

        public void LinkLost()
        {
            label3.Text = "Off Line";
            label3.ForeColor = Color.Red;

            if (buttonInventory.Text != "INVENTORY")
            {
                buttonInventory.Text = "INVENTORY";
                // enable button
                buttonInventory.Enabled = true;
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

        public void ShowUploadEPC(string epc)
        {
            int i;
            int count = listView1.Items.Count;

            // increase count for repeated detection
            ListViewItem item = new ListViewItem(epc.Substring(0, epc.IndexOf(',')));
            item.SubItems.Add(epc.Substring(epc.IndexOf(",COUNT=")+7));
            listView1.Items.Add(item);
            label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) + 1);
        }

        private void FormInventory_Closing(object sender, CancelEventArgs e)
        {
            force_stop = true;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {

            int level = trackBar_txpwr.Value;
            Form1.rfidhost_param.txpower = level / 10;

            if(Form1.R900APP.UHFAPI_SET_PowerControl((uint)(level * 4)))
            {
                label_txpwr.Text = dB[Form1.rfidhost_param.txpower];
            }
            else
            {
                label_txpwr.Text = "ERROR";
            }

        }


        private void Quit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_mask_Click(object sender, EventArgs e)
        {
            formMask = new FormMask();
            formMask.ShowDialog();
        }

        private void checkBox_mask_CheckStateChanged_1(object sender, EventArgs e)
        {
            Form1.rfidhost_param.bldMask = checkBox_mask.Checked;
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            label1.Text = "0";
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
