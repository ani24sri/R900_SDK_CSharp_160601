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
        //┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    //  rfid configuration parameters struct..
    //┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    unsafe public struct RFID_PARMS
    {
        public Int32 single_tag;                        // single tag
        public bool auto_link;                          // auto link
        public bool continuous;                         // tag operation continuous
        public bool skip_same;                          // discard skip
        public Int32 session;                           // session (S00, S01, S10, S11)
        public Int32 target;                            // target AB
        public Int32 q;                                 // q value
        public UInt32 timeout;                          // set operation time when detected tag
        public Int32 txpower;                           // tx power level control
        public Int32 mask_mode;                         // mask mode
        public byte mask_bank;                          // bank mask
        public UInt32 mask_offset;                      // mask offset
        public UInt32 mask_bits;                        // mask bit
        public fixed byte mskpattern[256];              // set mask pattern
        public fixed byte mskID[256];                   // store mask id.
        public UInt32 mskID_len;                        // store mask id length;
        public bool bldMask;                            // select mask state
        public Int32 mem_bank;                         // tag memory bank
        public Int32 host_state;                        // host state
        public bool link_state;                         // link state
        public Int32 tx_on;                             // tx on time
        public Int32 tx_off;                            // tx off time     
        public Int32 tx_duty;                           // tx duty level
        public Int32 form_state;                        // form state

    }

    public enum typeLockMasks
    {
        LM_USER_MEM_PERM_LOCK = 1,
        LM_USER_MEM_RW_LOCK = 2,
        LM_TID_MEM_PERM_LOCK = 4,
        LM_TID_MEM_RW_LOCK = 8,
        LM_EPC_MEM_PERM_LOCK = 16,
        LM_EPC_MEM_RW_LOCK = 32,
        LM_ACCESS_PWD_PERM_LOCK = 64,
        LM_ACCESS_PWD_RW_LOCK = 128,
        LM_KILL_PWD_PERM_LOCK = 256,
        LM_KILL_PWD_RW_LOCK = 512,
    }

    public partial class Form1 : Form
    {
        // Tag Memory Bank
        public enum TAG_MEMORY_BANK
        {
            RESERVED = 0x00000000,
            EPC = 0x00000001,
            TID = 0x00000002,
            USER = 0x00000003,
        }

        // mask mode status
        public enum MASK_MODE
        {
            EPC_MASK_MODE = 0x00000000,
            MULTI_MASK_MODE = 0x00000001,
        }

        // lock mask field
        public enum LOCK_MASK_FIELD
        {
            KILL_PASSWORD = 0x00000000,
            ACCESS_PASSWORD = 0x00000001,
            EPC = 0x00000002,
            TID = 0x00000003,
            USER = 0x00000004,
        }


        /// <summary>
        /// main class
        /// </summary>
        public static UHFAPI_NET.UHFAPI_NET R900APP;
        public static bool R900_alive = false;
        public static FormInventory formInventory;
        public static FormAccess formAccess;
        public static FormLockKill formLockkill; 
        public static FormLink formLink;
        public static RFID_PARMS rfidhost_param;

        public Form1()
        {
            InitializeComponent();

            label3.Text = "Off Line";
            label3.ForeColor = Color.Red;

            // show this form
            Show();
            Application.DoEvents();

            FormDialog formDlg = new FormDialog();
            formDlg.Message = "Please Wait ...";
            formDlg.Show();
            Application.DoEvents();

            R900APP = new UHFAPI_NET.UHFAPI_NET();

            // link R900 for control
            LinkReader();

            if (R900_alive)
            {
                label3.Text = "On Line";
                label3.ForeColor = Color.Green;
            }

            Timer tm = new Timer();
            tm.Interval = 1000;
            tm.Enabled = true;
            tm.Tick += new EventHandler(timer1_Tick);

            formDlg.Close();
            Application.DoEvents();
        }

        public void LinkReader()
        {
            R900APP.UHFAPI_HWND_EX(0, 0);
            //R900APP.UHFAPI_HWND_EX(0, 0); If you chaged the parameter, you can see the RSSI value.

            if (R900APP.UHFAPI_Open())
                R900_alive = true;

            R900APP.evtR900TriggerEvent += new UHFAPI_NET.UHFAPI_NET.R900TriggerHandler(R900TriggerHandler);
            R900APP.evtCmdBegin += new UHFAPI_NET.UHFAPI_NET.BeginEventDispacher(R900CommandBegin);
            R900APP.evtCmdEnd += new UHFAPI_NET.UHFAPI_NET.EndEventDispacher(R900CommandEnd);
            R900APP.evtLinkLost += new UHFAPI_NET.UHFAPI_NET.LinkLostEventHandler(R900APP_evtLinkLost);
            R900APP.evtPlatformPowerResume += new UHFAPI_NET.UHFAPI_NET.PlatformPowerResumeEventHandler(R900APP_evtPlatformPowerResume);
            R900APP.evtNotifyMsg += new UHFAPI_NET.UHFAPI_NET.MsgEventDispacher(R900APP_evtMSG);
        }

        void R900APP_evtPlatformPowerResume()
        {
            MessageBox.Show("power");
            R900_alive = false;

            label3.Text = "Off Line";
            label3.ForeColor = Color.Red;

            R900APP.UHFAPI_Close();

            if (formInventory != null)
                formInventory.PowerResume();
            if (formAccess != null)
                formAccess.PowerResume();
        }

        void R900APP_evtLinkLost()
        {
            R900_alive = false;

            label3.Text = "Off Line";
            label3.ForeColor = Color.Red;

            R900APP.UHFAPI_Close();

            if (formInventory != null)
                formInventory.LinkLost();
            if (formAccess != null)
                formAccess.LinkLost();
        }

        public void DislinkReader()
        {
            if (R900_alive || R900APP.UHFAPI_IsOpen())
            {
                R900_alive = false;
                R900APP.UHFAPI_Close();
            }

            R900APP.Cleanup();
        }

        internal void R900TriggerHandler(bool trigger_on)
        {
            if (formInventory != null)
                formInventory.InventoryTrigger(trigger_on);
            else if (formAccess != null)
                formAccess.AccessTrigger(trigger_on);
            else if (formLockkill != null)
                formLockkill.LockAccessTrigger(trigger_on);
        }

        internal void R900CommandBegin(string cmd)
        {
        }

        internal void R900CommandEnd(string cmd)
        {
            if (cmd == "Inventory")
                formInventory.InventoryEnd();
            else if (cmd == "Read" || cmd == "Write")
            {
                formAccess.AccessEnd();
            }
            else if (cmd == "Lock" || cmd == "Kill")
            {
                formLockkill.AccessEnd();
            }
        }

        internal void R900APP_evtMSG(string str)
        {

        }

        private void button1_Click(object sender, EventArgs e) 
        {
            formInventory = new FormInventory();

            formInventory.ShowDialog();

            if (R900APP.UHFAPI_IsOpen())
            {
                R900_alive = true;

                label3.Text = "On Line";
                label3.ForeColor = Color.Green;
            }
            else
            {
                R900_alive = false;

                label3.Text = "Off Line";
                label3.ForeColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            formAccess = new FormAccess();

            formAccess.ShowDialog();

            if (R900APP.UHFAPI_IsOpen())
            {
                R900_alive = true;

                label3.Text = "On Line";
                label3.ForeColor = Color.Green;
            }
            else
            {
                R900_alive = false;

                label3.Text = "Off Line";
                label3.ForeColor = Color.Red;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
   
//            DislinkReader();
            Cursor.Current = Cursors.WaitCursor;
            R900APP.Cleanup();
            R900APP.UHFAPI_Close();
            Cursor.Current = Cursors.Default;
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // dislink first
            if (R900APP.UHFAPI_IsOpen())
                DislinkReader();

            // invoke bind window
            formLink = new FormLink();

            formLink.ShowDialog();

            if (!R900APP.UHFAPI_IsOpen())
            {
                FormDialog formDlg = new FormDialog();
                formDlg.Message = "Please Wait ...";
                formDlg.Show();
                Application.DoEvents();

                // link R900 for control
                LinkReader();

                formDlg.Close();
                Application.DoEvents();
            }

            if (R900APP.UHFAPI_IsOpen())
            {
                R900_alive = true;

                label3.Text = "On Line";
                label3.ForeColor = Color.Green;
            }
            else
            {
                R900_alive = false;

                label3.Text = "Off Line";
                label3.ForeColor = Color.Red;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formLockkill = new FormLockKill();

            formLockkill.ShowDialog();

            if (R900APP.UHFAPI_IsOpen())
            {
                R900_alive = true;

                label3.Text = "On Line";
                label3.ForeColor = Color.Green;
            }
            else
            {
                R900_alive = false;

                label3.Text = "Off Line";
                label3.ForeColor = Color.Red;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!R900APP.UHFAPI_IsOpen())
            {
                FormDialog formDlg = new FormDialog();
                formDlg.Message = "Please Wait ...";
                formDlg.Show();
                Application.DoEvents();

                // link R900 for control
                LinkReader();

                formDlg.Close();
                Application.DoEvents();
            }

            if (R900APP.UHFAPI_IsOpen())
            {
                R900_alive = true;

                label3.Text = "On Line";
                label3.ForeColor = Color.Green;

            }
            else
            {
                R900_alive = false;

                label3.Text = "Off Line";
                label3.ForeColor = Color.Red;
            }
        }

    }

}
