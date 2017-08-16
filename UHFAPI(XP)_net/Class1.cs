using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace UHFAPI_NET
{
	/// <summary>
	/// Class1에 대한 요약 설명입니다.
	/// </summary>
	public class UHFAPI_NET
    {
		#region Dll Import

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_Open", SetLastError = true)]
		internal static extern bool _UHFAPI_Open();

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_HWND_EX", SetLastError = true)]
        internal static extern bool _UHFAPI_HWND_EX(IntPtr handle, UInt32 report_mode_set, UInt32 report_mode_reset);
 
		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_IsOpen", SetLastError = true)]
		internal static extern bool _UHFAPI_IsOpen();
 
		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_Close", SetLastError = true)]
		internal static extern bool _UHFAPI_Close();

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GetLibVersion", SetLastError = true)]
		internal unsafe static extern bool _UHFAPI_GetLibVersion(char* szValue);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_Stop", SetLastError = true)]
		internal static extern bool _UHFAPI_Stop(bool wait_done);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GET_RESULT_MESSAGE", SetLastError = true)]
		unsafe internal static extern bool _UHFAPI_GET_RESULT_MESSAGE(char* szResult, uint msg, UInt16 wParam, UInt32 lParam);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GET_EPC", SetLastError = true)]
		internal unsafe static extern bool _UHFAPI_GET_EPC(char* szResult);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GET_DATA", SetLastError = true)]
		internal unsafe static extern bool _UHFAPI_GET_DATA(char* szResult);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GET_LAST_ERROR", SetLastError = true)]
		internal static extern IntPtr _UHFAPI_GET_LAST_ERROR();

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GET_LAST_ERROR_CODE", SetLastError = true)]
		internal static extern enumAccessResult _UHFAPI_GET_LAST_CODE_CODE();

        [DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GET_LAST_ERROR_CODE", SetLastError = true)]
        internal static extern enumAccessResult _UHFAPI_GET_LAST_ERROR_CODE();

        [DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GetFirmwareVersion", SetLastError = true)]
		internal unsafe static extern bool _UHFAPI_GetFirmwareVersion(char* szValue);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GetReaderClock", SetLastError = true)]
		internal static extern Int64 _UHFAPI_GetReaderClock(UInt32 ReaderTick);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_SpecialAccessCtrl", SetLastError = true)]
		internal static extern bool _UHFAPI_SpecialAccessCtrl(UInt32 type, UInt32 code, out UInt32 value);

        //internal delegate UInt32 pc_cbproc(IntPtr context, IntPtr message);
		//[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_ProprietaryCommand", SetLastError = true)]
		//internal static extern bool _UHFAPI_ProprietaryCommand(UInt32 action, pc_cbproc cbproc, IntPtr context);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_Inventory", SetLastError = true)]
		unsafe internal static extern enumAccessResult _UHFAPI_Inventory(structTAG_OP_PARAM *param, bool wait_done);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_ReadTag", SetLastError = true)]
        unsafe internal static extern enumAccessResult _UHFAPI_ReadTag(byte MemBank, UInt32 offset, UInt32 length, UInt32 pwdACCESS, structTAG_OP_PARAM *param, bool wait_done);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_WriteTag", SetLastError = true)]
//han 2011.2.8        unsafe internal static extern enumAccessResult _UHFAPI_WriteTag(byte MemBank, UInt32 offset, UInt32 length, ref UInt16 szWriteData, UInt32 pwdACCESS, structTAG_OP_PARAM *param, bool wait_done);
        unsafe internal static extern enumAccessResult _UHFAPI_WriteTag(byte MemBank, UInt32 offset, UInt32 length,  UInt16* szWriteData, UInt32 pwdACCESS, structTAG_OP_PARAM* param, bool wait_done);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_LockSetTag", SetLastError = true)]
        unsafe internal static extern enumAccessResult _UHFAPI_LockSetTag(enumLockMasks masks, enumLockMasks enables, UInt32 pwdACCESS, structTAG_OP_PARAM* param, bool wait_done);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_LockTag", SetLastError = true)]
        unsafe internal static extern enumAccessResult _UHFAPI_LockTag(bool kill_pwd, bool access_pwd, bool epc, bool tid, bool user, UInt32 pwdACCESS, structTAG_OP_PARAM* param, bool wait_done);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_UnlockTag", SetLastError = true)]
        unsafe internal static extern enumAccessResult _UHFAPI_UnlockTag(bool kill_pwd, bool access_pwd, bool epc, bool tid, bool user, UInt32 pwdACCESS, structTAG_OP_PARAM* param, bool wait_done);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_PermalockTag", SetLastError = true)]
        unsafe internal static extern enumAccessResult _UHFAPI_PermalockTag(byte ActionField, bool Lock, UInt32 pwdACCESS, structTAG_OP_PARAM* param, bool wait_done);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_KillTag", SetLastError = true)]
        unsafe internal static extern enumAccessResult _UHFAPI_KillTag(UInt32 Kill_PWD, UInt32 pwdACCESS, structTAG_OP_PARAM* param, bool wait_done);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_SET_PowerControl", SetLastError = true)]
        unsafe internal static extern bool _UHFAPI_SET_PowerControl(UInt32 attDb10);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GET_PowerControl", SetLastError = true)]
		unsafe internal static extern bool _UHFAPI_GET_PowerControl(out UInt32 attDb10);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_SET_Session", SetLastError = true)]
		internal static extern bool _UHFAPI_SET_Session(byte SessionCode);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GET_Session", SetLastError = true)]
		unsafe internal static extern bool _UHFAPI_GET_Session(out byte SessionCode);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_SET_QValue", SetLastError = true)]
		internal static extern bool _UHFAPI_SET_QValue(UInt32 QValue);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GET_QValue", SetLastError = true)]
		unsafe internal static extern bool _UHFAPI_GET_QValue( out UInt32 QValue);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_SET_InventoryTarget", SetLastError = true)]
		internal static extern bool _UHFAPI_SET_InventoryTarget(byte TargetCode);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GET_InventoryTarget", SetLastError = true)]
		unsafe internal static extern bool _UHFAPI_GET_InventoryTarget( out byte TargetCode);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_SET_SelectAction", SetLastError = true)]
		internal static extern bool _UHFAPI_SET_SelectAction(bool SelectFlag, byte ActionCode, ref structSelectMask mask);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GET_SelectAction", SetLastError = true)]
		unsafe internal static extern bool _UHFAPI_GET_SelectAction(out bool SelectFlag, out Byte ActionCode);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_SET_OpMode", SetLastError = true)]
		internal static extern bool _UHFAPI_SET_OpMode(bool single_tag, bool UseMask, bool QuerySelected, UInt32 timeout);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GET_OpMode", SetLastError = true)]
		unsafe internal static extern bool _UHFAPI_GET_OpMode(out bool single_tag, out bool UseMask, out bool QuerySelected, out UInt32 timeout);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_SET_LBT_CHState", SetLastError = true)]
		internal static extern bool _UHFAPI_SET_LBT_CHState(UInt32 State);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GET_LBT_CHState", SetLastError = true)]
		internal static extern bool _UHFAPI_GET_LBT_CHState(out UInt32 State);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_SET_LBT_Time", SetLastError = true)]
		internal static extern bool _UHFAPI_SET_LBT_Time(UInt16 LBT_Time);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_SET_Default", SetLastError = true)]
		internal static extern bool _UHFAPI_SET_Default();

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_CheckBattery", SetLastError = true)]
		internal static extern UInt32 _UHFAPI_CheckBattery();

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_PowerOnInit", SetLastError = true)]
		internal static extern bool _UHFAPI_PowerOnInit();

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_SetBand", SetLastError = true)]
		internal static extern bool _UHFAPI_SetBand(UInt16 band_code);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GetBand", SetLastError = true)]
		internal static extern bool _UHFAPI_GetBand(out UInt16 band_code);

		//[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GetBandCapabilities", SetLastError = true)]
		//internal static extern bool _UHFAPI_GetBandCapabilities(IntPtr/*typeBandCap ***/ppCap);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_SetAirDura", SetLastError = true)]
		internal static extern bool _UHFAPI_SetAirDura(UInt32 onms, UInt32 offms);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_SetAirDuty", SetLastError = true)]
		internal static extern bool _UHFAPI_SetAirDuty(UInt32 speed);

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_GetTestHandle", SetLastError = true)]
		internal static extern IntPtr _UHFAPI_GetTestHandle();

		[DllImport("UHFAPI.dll", EntryPoint = "UHFAPI_LibraryMode", SetLastError = true)]
		internal static extern bool _UHFAPI_LibraryMode(UInt32 mode);


        [DllImport("R900Lib.dll", EntryPoint = "R900LIB_HWND_EX", SetLastError = true)]
        unsafe internal static extern bool _R900LIB_HWND_EX(IntPtr handle, UInt32 report_mode_set, UInt32 report_mode_reset);

        [DllImport("R900Lib.dll", EntryPoint = "R900LIB_IsTriggerEvent", SetLastError = true)]
		unsafe internal static extern bool _R900LIB_IsTriggerEvent(Int32 *trigger);

        [DllImport("R900Lib.dll", EntryPoint = "R900LIB_RefreshStatus", SetLastError = true)]
        unsafe internal static extern bool _R900LIB_RefreshStatus();

		[DllImport("uhfapi_sup_4_net.dll", EntryPoint = "UHFSUPAPI_GetMessageId", SetLastError = true)]
		unsafe internal static extern UInt32 _UHFSUPAPI_GetMessageId();

        [DllImport("uhfapi_sup_4_net.dll", EntryPoint = "UHFSUPAPI_GetDeviceLostEventId", SetLastError = true)]
		unsafe internal static extern IntPtr _UHFSUPAPI_GetDeviceLostEventId();

        [DllImport("uhfapi_sup_4_net.dll", EntryPoint = "UHFSUPAPI_GetR900MessageId", SetLastError = true)]
		unsafe internal static extern UInt32 _UHFSUPAPI_GetR900MessageId();

        [DllImport("uhfapi_sup_4_net.dll", EntryPoint = "UHFSUPAPI_GetDeviceLostMessageId", SetLastError = true)]
        unsafe internal static extern UInt32 _UHFSUPAPI_GetDeviceLostMessageId();

        [DllImport("uhfapi_sup_4_net.dll", EntryPoint = "UHFSUPAPI_GetPlatformPowerMessageId", SetLastError = true)]
        unsafe internal static extern UInt32 _UHFSUPAPI_GetPlatformPowerMessageId();

        //[DllImport("uhfapi_sup_4_net.dll", EntryPoint = "UHFSUPAPI_UploadInventory", SetLastError = true)]
        //unsafe internal static extern UInt32 _UHFSUPAPI_UploadInventory(UploadCallbackHandler1 UploadCallbackHandler1); 
        [DllImport("uhfapi_sup_4_net.dll", EntryPoint = "UHFSUPAPI_OpenUploadInventoryList", SetLastError = true)]
        unsafe internal static extern UInt32 _UHFSUPAPI_OpenUploadInventoryList();
        [DllImport("uhfapi_sup_4_net.dll", EntryPoint = "UHFSUPAPI_GetUploadInventoryData", SetLastError = true)]
        unsafe internal static extern char* _UHFSUPAPI_GetUploadInventoryData(UInt32 index);
        [DllImport("uhfapi_sup_4_net.dll", EntryPoint = "UHFSUPAPI_CloseUploadInventoryList", SetLastError = true)]
        unsafe internal static extern void _UHFSUPAPI_CloseUploadInventoryList();

        [DllImport("uhfapi_sup_4_net.dll", EntryPoint = "UHFSUPAPI_ClearInventory", SetLastError = true)]
        unsafe internal static extern UInt32 _UHFSUPAPI_ClearInventory(); 


       	#endregion

        #region unsafe handle

        unsafe static int GetMessageId()
        {
            return (int)_UHFSUPAPI_GetMessageId();
        }
        unsafe static int GetR900MessageId()
        {
            return (int)_UHFSUPAPI_GetR900MessageId();
        }
        unsafe static int GetDeviceLostMessageId()
        {
            return (int)_UHFSUPAPI_GetDeviceLostMessageId();
        }
        unsafe static IntPtr GetDeviceLostEventId()
        {
            return _UHFSUPAPI_GetDeviceLostEventId();
        }
        unsafe static int GetPlatformPowerMessageId()
        {
            return (int)_UHFSUPAPI_GetPlatformPowerMessageId();
        }

        #endregion


		public delegate void UHFAPIEventHandler(int Msg, IntPtr WParam, IntPtr LParam);
        public delegate void R900EventHandler(int Msg, IntPtr WParam, IntPtr LParam);
        public delegate void R900TriggerHandler(bool trigger);
        public delegate void InventoryEPCDispacher(string epc);
        public delegate void AccessEPCDispacher(string epc);
        public delegate void AccessDataDispacher(string data);
        public delegate void AccessResultDispacher(string msg);
        public delegate void MsgEventDispacher(string msg);
        public delegate void BeginEventDispacher(string msg);
        public delegate void EndEventDispacher(string msg);
        public delegate void LinkLostEventHandler();
        public delegate void PlatformPowerResumeEventHandler();
        public delegate void UploadCallbackHandler(string msg);
        public unsafe delegate UInt32 UploadCallbackHandler1(char* msg);

		public event UHFAPIEventHandler UHFAPIMessage = null;
		public event R900EventHandler R900APIMessage = null;
        public event R900TriggerHandler evtR900TriggerEvent = null;
        public event InventoryEPCDispacher evtInventoryEPC = null;
        public event InventoryEPCDispacher evtUploadEPC = null;
        public event AccessEPCDispacher evtAccessEPC = null;
        public event AccessDataDispacher evtAccessData = null;
        public event AccessResultDispacher evtAccessResult = null;
        public event MsgEventDispacher evtNotifyMsg = null;
        public event BeginEventDispacher evtCmdBegin = null;
        public event EndEventDispacher evtCmdEnd = null;
        public event LinkLostEventHandler evtLinkLost = null;
        public event PlatformPowerResumeEventHandler evtPlatformPowerResume = null;
        public event UploadCallbackHandler evtUploadCallback = null;

        internal static int UHFAPI_MESSAGE = GetMessageId();
        internal static int R900_MESSAGE = GetR900MessageId();
        internal static int DEVICE_LOST_MESSAGE = GetDeviceLostMessageId();
        internal static int PLATFORM_POWER_MESSAGE = GetPlatformPowerMessageId();


        internal int readercommand;
        internal int access_state;

        internal string LastCommandName;
        internal string LastTagEPC;
        internal string msgLastError;

        internal UHFMsgWnd uhfmsgwnd = null;
        internal class UHFMsgWnd : System.Windows.Forms.Form
		{
			private UHFAPI_NET _uhf = null;
			public UHFMsgWnd(UHFAPI_NET uhf)
			{
				this._uhf = uhf;
			}
			protected override void WndProc(ref Message m)
			{
				if ( m.Msg == UHFAPI_MESSAGE )
                {
                    _uhf.MessageHandler(m.Msg, m.WParam, m.LParam);
                }
                else if (m.Msg == R900_MESSAGE)
                {
                    _uhf.R900MessageHandler(m.Msg, m.WParam, m.LParam);
                }
                else if (m.Msg == DEVICE_LOST_MESSAGE)
                {
                    _uhf.DeviceLostMessageHandler(m.Msg, m.WParam, m.LParam);
                }
                else if (m.Msg == PLATFORM_POWER_MESSAGE)
                {
                    _uhf.PlatformPowerMessageHandler(m.Msg, m.WParam, m.LParam);
                }

				base.WndProc(ref m);
			}
		}

        private void MessageHandler(int msg, IntPtr wParam, IntPtr lParam)
        {
            string szRawBuff = new string(new char[1024]);
            string szBuff;

            // get result message
            if (!UHFAPI_GET_RESULT_MESSAGE(szRawBuff, msg, wParam, lParam))
            {
                //SetLastError = false;
                return;
            }
            szBuff = szRawBuff.Substring(0, szRawBuff.IndexOf('\0'));

            switch (wParam.ToInt32())
            {
            case (int)MSG_TYPE.MSG_TYPE_INV_EPC:
                {
                    // dispach epc
                    if (evtInventoryEPC != null)
                        evtInventoryEPC(szBuff);
                }
                break;

            case (int)MSG_TYPE.MSG_TYPE_ACCESS_EPC:
                {
                    // dispach epc
                    if (evtAccessEPC != null)
                        evtAccessEPC(szBuff);

                    LastTagEPC = szBuff;
                }
                break;

            case (int)MSG_TYPE.MSG_TYPE_READ_DATA:
                {
                    // dispatch read data
                    if (evtAccessData != null)
                        evtAccessData(szBuff);
                }
                break;

            case (int)MSG_TYPE.MSG_TYPE_ACCESS_RESULT:
                {
                    // dispatch result
                    if (evtAccessResult != null)
                        evtAccessResult(szBuff);
                }
                break;

            case (int)MSG_TYPE.MSG_TYPE_CMD_BEGIN:
                {
                    readercommand = lParam.ToInt32();

                    // dispatch command name
                    if (evtCmdBegin != null)
                        evtCmdBegin(szBuff);

                    LastCommandName = szBuff;
                    LastTagEPC = "";
                    msgLastError = "";
                }
                break;

            case (int)MSG_TYPE.MSG_TYPE_CMD_END:
                {
                    // dispatch command name
                    if (evtCmdEnd != null)
                        evtCmdEnd(LastCommandName);

                    //if (readercommand == UHFAPI_NET.UHFAPI_NET.READER_COMMAND.READER_COMMAND_INVENTORY)
                    //{
                    //    formInventory.InventoryEnd();
                    //}
// han 2010.12.28
//                    unsafe
//                    {
//                        if (_R900LIB_RefreshStatus())
//                        {
//                            Int32 trigger_on;
//
//                            _R900LIB_IsTriggerEvent(&trigger_on);
//
//                            evtR900TriggerEvent((bool)(trigger_on != 0));
//                        }
//                    }
//
                }
                break;

            case (int)MSG_TYPE.MSG_TYPE_REPORT_ERROR:
                {
                    // dispatch error message
                    if (evtNotifyMsg != null)
                        evtNotifyMsg(szBuff);
                }
                break;

            default:
                break;
            }
        }

        unsafe private void R900MessageHandler(int Msg, IntPtr WParam, IntPtr LParam)
        {
            Int32/*BOOL*/ trigger;

            if ( R900APIMessage != null )
                R900APIMessage(Msg, WParam, LParam);

            if (evtR900TriggerEvent != null)
            {
                if (_R900LIB_IsTriggerEvent(&trigger))
                    evtR900TriggerEvent((bool)(trigger!=0));
            }
        }

        unsafe private void DeviceLostMessageHandler(int Msg, IntPtr WParam, IntPtr LParam)
        {
            if (evtLinkLost != null)
                evtLinkLost();
        }

        unsafe private void PlatformPowerMessageHandler(int Msg, IntPtr WParam, IntPtr LParam)
        {
            if (evtPlatformPowerResume != null)
                evtPlatformPowerResume();
        }

        internal Thread EventMonitorThread = null;

        internal void threadProc()
        {
            AutoResetEvent LostEvent = new AutoResetEvent(false); 

            LostEvent.Handle = GetDeviceLostEventId();
            
            while ( LostEvent.WaitOne() )
            {
                if ( evtLinkLost != null )
                    evtLinkLost();
            }
        }
        

        public UHFAPI_NET()
		{
			uhfmsgwnd = new UHFMsgWnd(this);

            EventMonitorThread = new Thread(threadProc);
            EventMonitorThread.Start();
		}

        public void Cleanup()
        {
            EventMonitorThread.Abort();
        }

		#region 기본함수

		public bool UHFAPI_Open()
		{
			return _UHFAPI_Open();
		}

		public bool UHFAPI_HWND_EX(UInt32 report_mode_set, UInt32 report_mode_reset)
		{
#if DEBUG
        	// !!! disable heart beat operation for debuging purpose !!!
        	//_UHFAPI_LibraryMode(1);
#endif
            bool res = _R900LIB_HWND_EX(uhfmsgwnd.Handle, 0, 0);
            return res && _UHFAPI_HWND_EX(uhfmsgwnd.Handle, report_mode_set, report_mode_reset);
		}

		public bool UHFAPI_IsOpen()
		{
			return _UHFAPI_IsOpen();
		}

		public unsafe string UHFAPI_GetLibVersion()
		{
			String lszValue = new string(new char[50]);
			fixed ( char* p = lszValue )
                if ( _UHFAPI_GetLibVersion(p) )
                    return lszValue;
            return null;
		}

        public unsafe string UHFAPI_GetFirmwareVersion()
        {
            string strValue = new string(new char[50]);

            fixed ( char *p = strValue )
                if (_UHFAPI_GetFirmwareVersion(p))
                    return strValue;

            return null;
        }

		public void UHFAPI_Stop()
		{
			_UHFAPI_Stop(true);
		}

		public void UHFAPI_Close()
		{
			_UHFAPI_Close();
		}

        public unsafe bool UHFAPI_GET_RESULT_MESSAGE(string szResult, int msg, IntPtr wParam, IntPtr lParam)
        {
            fixed ( char *p = szResult )
                if ( _UHFAPI_GET_RESULT_MESSAGE(p, (uint)msg, (UInt16)wParam.ToInt32(), (UInt32)lParam.ToInt32()) )
                    return true;
            return false;
        }

        public unsafe bool UHFAPI_GET_EPC(string szResult)
        {
            fixed ( char* p = szResult )
                if ( _UHFAPI_GET_EPC(p) )
                    return true;
            return false;
        }

        public unsafe bool UHFAPI_GET_DATA(string szResult)
        {
            fixed (char* p = szResult)
                if ( _UHFAPI_GET_DATA(p) )
                    return true;
            return false;
        }

        public bool UHFAPI_GET_LAST_ERROR(string err)
        {
            IntPtr ip = _UHFAPI_GET_LAST_ERROR();
            err = ip.ToString();
            return true;
        }

        public enumAccessResult UHFAPI_GET_LAST_ERROR_CODE()
        {
            return _UHFAPI_GET_LAST_ERROR_CODE();
        }

        public enumAccessResult UHFAPI_GET_LAST_CODE_CODE()
        {
            return _UHFAPI_GET_LAST_ERROR_CODE();
        }

        public unsafe bool UHFAPI_GetFirmwareVersion(string strValue)
        {
            fixed (char* p = strValue)
                if (_UHFAPI_GetFirmwareVersion(p))
                    return true;
            return false;
        }

        public Int64 UHFAPI_GetReaderClock(UInt32 ReaderTick)
        {
            return _UHFAPI_GetReaderClock(ReaderTick);
        }

        public bool UHFAPI_SpecialAccessCtrl(UInt32 type, UInt32 code, out UInt32 value)
        {
            return _UHFAPI_SpecialAccessCtrl(type, code, out value);
        }

        unsafe public enumAccessResult UHFAPI_Inventory(structTAG_OP_PARAM param, bool wait_done)
        {
            return _UHFAPI_Inventory(&param, wait_done);
        }

        unsafe public enumAccessResult UHFAPI_ReadTag(byte MemBank, UInt32 offset, UInt32 length, UInt32 pwdACCESS, structTAG_OP_PARAM param, bool wait_done)
        {
            return _UHFAPI_ReadTag(MemBank, offset, length, pwdACCESS, &param, wait_done);
        }

//han 2011.2.8        unsafe public enumAccessResult UHFAPI_WriteTag(byte MemBank, UInt32 offset, UInt32 length, ref UInt16 szWriteData, UInt32 pwdACCESS, structTAG_OP_PARAM param, bool wait_done)
        unsafe public enumAccessResult UHFAPI_WriteTag(byte MemBank, UInt32 offset, UInt32 length, ref UInt16 [] szWriteData, UInt32 pwdACCESS, structTAG_OP_PARAM param, bool wait_done)
        {
            fixed (UInt16* pszWriteData = &szWriteData[0]) return _UHFAPI_WriteTag(MemBank, offset, length, pszWriteData, pwdACCESS, &param, wait_done);
        }

        unsafe public enumAccessResult UHFAPI_LockSetTag(enumLockMasks masks, enumLockMasks enables, UInt32 pwdACCESS, structTAG_OP_PARAM param, bool wait_done)
        {
            return _UHFAPI_LockSetTag(masks, enables, pwdACCESS, &param, wait_done);
        }

        unsafe public enumAccessResult UHFAPI_LockTag(bool kill_pwd, bool access_pwd, bool epc, bool tid, bool user, UInt32 pwdACCESS, structTAG_OP_PARAM param, bool wait_done)
        {
            return _UHFAPI_LockTag(kill_pwd, access_pwd, epc, tid, user, pwdACCESS, &param, wait_done);
        }

        unsafe public enumAccessResult UHFAPI_UnlockTag(bool kill_pwd, bool access_pwd, bool epc, bool tid, bool user, UInt32 pwdACCESS, structTAG_OP_PARAM param, bool wait_done)
        {
            return _UHFAPI_UnlockTag(kill_pwd, access_pwd, epc, tid, user, pwdACCESS, &param, wait_done);
        }

        unsafe public enumAccessResult UHFAPI_PermalockTag(byte ActionField, bool Lock, UInt32 pwdACCESS, structTAG_OP_PARAM param, bool wait_done)
        {
            return _UHFAPI_PermalockTag(ActionField, Lock, pwdACCESS, &param, wait_done);
        }

        unsafe public enumAccessResult UHFAPI_KillTag(UInt32 Kill_PWD, UInt32 pwdACCESS, structTAG_OP_PARAM param, bool wait_done)
        {
            return _UHFAPI_KillTag(Kill_PWD, pwdACCESS, &param, wait_done);
        }

        public bool UHFAPI_SET_PowerControl(UInt32 attDb10)
        {
            return _UHFAPI_SET_PowerControl(attDb10);
        }

        public bool UHFAPI_GET_PowerControl(out UInt32 attDb10)
        {
            return _UHFAPI_GET_PowerControl(out attDb10);
        }

        public bool UHFAPI_SET_Session(byte SessionCode)
        {
            return _UHFAPI_SET_Session(SessionCode);
        }

        public bool UHFAPI_GET_Session(out byte SessionCode)
        {
            return _UHFAPI_GET_Session(out SessionCode);
        }

        public bool UHFAPI_SET_QValue(UInt32 QValue)
        {
            return _UHFAPI_SET_QValue(QValue);
        }

        public bool UHFAPI_GET_QValue(out UInt32 QValue)
        {
            return _UHFAPI_GET_QValue(out QValue);
        }

        public bool UHFAPI_SET_InventoryTarget(byte TargetCode)
        {
            return _UHFAPI_SET_InventoryTarget(TargetCode);
        }

        public bool UHFAPI_GET_InventoryTarget(out byte TargetCode)
        {
            return _UHFAPI_GET_InventoryTarget(out TargetCode);
        }

        public bool UHFAPI_SET_SelectAction(bool SelectFlag, byte ActionCode, ref structSelectMask mask)
        {
            return _UHFAPI_SET_SelectAction(SelectFlag, ActionCode, ref mask);
        }

        public bool UHFAPI_GET_SelectAction(out bool SelectFlag, out Byte ActionCode)
        {
            return _UHFAPI_GET_SelectAction(out SelectFlag, out ActionCode);
        }

        public bool UHFAPI_SET_OpMode(bool single_tag, bool UseMask, bool QuerySelected, UInt32 timeout)
        {
            return _UHFAPI_SET_OpMode(single_tag, UseMask, QuerySelected, timeout);
        }

        public bool UHFAPI_GET_OpMode(out bool single_tag, out bool UseMask, out bool QuerySelected, out UInt32 timeout)
        {
            return _UHFAPI_GET_OpMode(out single_tag, out UseMask, out QuerySelected, out timeout);
        }

        public bool UHFAPI_SET_LBT_CHState(UInt32 State)
        {
            return _UHFAPI_SET_LBT_CHState(State);
        }

        public bool UHFAPI_GET_LBT_CHState(out UInt32 State)
        {
            return _UHFAPI_GET_LBT_CHState(out State);
        }

        //public bool UHFAPI_SET_LBT_Time(UInt16 LBT_Time)
        //{
        //    return _UHFAPI_SET_LBT_Time(LBT_Time);
        //}

        public bool UHFAPI_SET_Default()
        {
            return _UHFAPI_SET_Default();
        }

        //public UInt32 UHFAPI_CheckBattery()
        //{
        //    return _UHFAPI_CheckBattery();
        //}

        //public bool UHFAPI_PowerOnInit()
        //{
        //    return _UHFAPI_PowerOnInit();
        //}

        public bool UHFAPI_SetBand(UInt16 band_code)
        {
            return _UHFAPI_SetBand(band_code);
        }

        //public bool UHFAPI_GetBand(out UInt16 band_code)
        //{
        //    return _UHFAPI_GetBand(out UInt16 band_code);
        //}

        //internal static extern bool _UHFAPI_GetBandCapabilities(IntPtr/*typeBandCap ***/ppCap);

        public bool UHFAPI_SetAirDura(UInt32 onms, UInt32 offms)
        {
            return _UHFAPI_SetAirDura(onms, offms);
        }

        public bool UHFAPI_SetAirDuty(UInt32 speed)
        {
            return _UHFAPI_SetAirDuty(speed);
        }

        public bool UHFAPI_LibraryMode(UInt32 mode)
        {
            return _UHFAPI_LibraryMode(mode);
        }

        internal unsafe UInt32 UploadCallback(string inv)
        {
            if (evtUploadEPC != null)
                evtUploadEPC(inv);
            return 0;
        }

        public unsafe bool R900LIB_UploadInventory()
        {
            // upload all tag infomation
            if (evtUploadEPC == null)
                return false;

            UInt32 count = _UHFSUPAPI_OpenUploadInventoryList();
            if (count == 0)
                return false;

            for ( UInt32 i = 0 ; i < count ; i++ )
            {
                char *p = _UHFSUPAPI_GetUploadInventoryData(i);
                if (p == null)
                {
                    _UHFSUPAPI_CloseUploadInventoryList();
                    return false;
                }
                UploadCallback(new string(p));
            }

            _UHFSUPAPI_CloseUploadInventoryList();

            return true;
        }


        public bool R900LIB_ClearInventory()
        {
            return 0 == _UHFSUPAPI_ClearInventory();
        }

        unsafe public static void UHFAPI_PutSelectMask(structTAG_OP_PARAM *param, byte bank, uint offset, uint bits, byte[] pattern)
        {
            byte* ptr = param->mask.mskPattern;
            param->mask.mskMemBank = bank;
            param->mask.mskBits = bits;
            param->mask.mskOffset = offset;

            for (int i = 0; i < pattern.Length; i++)
            {
                ptr[i] = (byte)pattern.GetValue(i);
            }
        }

        unsafe public static structTAG_OP_PARAM UHFAPI_GetTagOpParam(byte bank, uint offset, uint bits, byte[] pattern)
        {
            structTAG_OP_PARAM param = new structTAG_OP_PARAM();

            param.mask.mskMemBank = bank;
            param.mask.mskBits = bits;
            param.mask.mskOffset = offset;

            for (int i = 0; i < pattern.Length; i++)
            {
                param.mask.mskPattern[i] = (byte)pattern.GetValue(i);
            }

            return param;
        }

        #endregion


        #region 세팅함수
        public struct CONTROL_VALUE
        {
            public string Version;
            public int Power;
            public int Qvalue;
            public int ScanTime;
            public int SessionValue;
            public bool ContinueMode;
            public HOPPING_CODE Hopping;
            public bool Buzzer;
            public CH_STATE ChState;
            public bool HoppingOn;
            public int CHNumber;
            public int LBT_Time;
        }

        public struct CH_STATE
        {
            public bool CH1;
            public bool CH2;
            public bool CH3;
            public bool CH4;
            public bool CH5;
            public bool CH6;
            public bool CH7;
            public bool CH8;
            public bool CH9;
            public bool CH10;
        }

        #endregion


        #region CODE

        public Int64 tag_t;


        public enum MSG_TYPE {
	        //MSG_TYPE_NOTIFY = 0,	// command not started by the reason
	        //MSG_TYPE_REPLY,			// command end with or without error
	        MSG_TYPE_REPORT_ERROR,	// error report
	        MSG_TYPE_ACCESS_EPC,	// EPC report from access operation
	        MSG_TYPE_INV_EPC,		// EPC report from inventory operation
	        MSG_TYPE_READ_DATA,		// read data from read access operation
	        MSG_TYPE_ACCESS_RESULT, // han 2009.10.23
	        MSG_TYPE_CMD_BEGIN,		// command begin report from module
	        MSG_TYPE_CMD_END,		// command end report from module
	        MSG_TYPE_CMD_INFO,		// informative data during command execution in the module
        }

        public enum READER_COMMAND
        {
            READER_COMMAND_INVENTORY = 0x0000000F,
            READER_COMMAND_READ = 0x00000010,
            READER_COMMAND_WRITE = 0x00000011,
            READER_COMMAND_LOCK = 0x00000012,
            READER_COMMAND_KILL = 0x00000013,
        }

        unsafe public struct structSelectMask
        {
            public byte mskMemBank;	// mem bank id for selection mask
            public UInt32 mskOffset;		// mem bank bit offset for selection mask
            public UInt32 mskBits;		// mem bank pattern bits for selection mask
            public fixed byte mskPattern[256 / 8];// bit pattern for selection mask
        }
        public struct structTAG_OP_PARAM
        {
        	public Int32/*BOOL*/ single_tag;		// access only 1 tag
            public Int32/*BOOL*/ QuerySelected;		// inventory only for selected tag
            public structSelectMask mask; // select mask
            public UInt32 timeout;		// access timeout in [ms]
        }
        /*
        public struct structChanInfo
        { // han 2010.1.25
	        UInt16	ChannelNo;
	        UInt16	ChannelFrequency; // frequency in khz
	        UInt16	ChannelPower; // attenuation from max power in 0.1dB, so negative value
        }
        unsafe public struct structBandCap { // han 2010.1.25
	        bool	Hopping;
	        UInt16	Channels;
	        UInt32	TxMaxPower;
	        UInt16	TxOn;	// in msec
	        UInt16	TxOff; // in msec
	        UInt16	TxWait;	// in msec
	        fixed structChanInfo	ChannelList[50];
        } */
        public enum enumLockMasks
        {
	        LM_KILL_PWD_RW_LOCK		= 1 << 9,
	        LM_KILL_PWD_PERM_LOCK		= 1 << 8,
	        LM_ACCESS_PWD_RW_LOCK		= 1 << 7,
	        LM_ACCESS_PWD_PERM_LOCK	= 1 << 6,
	        LM_EPC_MEM_RW_LOCK			= 1 << 5,
	        LM_EPC_MEM_PERM_LOCK		= 1 << 4,
	        LM_TID_MEM_RW_LOCK			= 1 << 3,
	        LM_TID_MEM_PERM_LOCK		= 1 << 2,
	        LM_USER_MEM_RW_LOCK		= 1 << 1,
	        LM_USER_MEM_PERM_LOCK		= 1 << 0,
        }
        public enum enumAccessResult
        {
	        ACCESS_RESULT_OK			 = 0,
	        ACCESS_RESULT_NOT_CONNECTED	 = -1,
	        ACCESS_RESULT_NOT_DETECT	 = -2,
	        ACCESS_RESULT_ACCESS_ERROR	 = -3,
        }
		public enum UIDREAD_CODE
		{
			ISO_180006B_ONE_TAG       =   0x61,
			ISO_180006B_MULTI_TAG     =   0x62,
			EPC_GEN2_ONE_TAG          =   0x65,
			EPC_GEN2_MULTI_TAG        =   0x66,
			EPC_GEN2_ONE_TAG_SELECT   =   0x6A,
			EPC_GEN2_MULTI_TAG_SELECT =   0x79,
			C_W                       =   0x73
		}
		public enum CONTROL_CODE
		{
			CTL_ALL       =    0x61,
			CTL_POWER     =    0x70,
			CTL_QVALUE    =    0x71,
			CTL_SCANTIME  =    0x74,
			CTL_VERSION   =    0x76,
			CTL_CONTINUE  =    0x63,
			CTL_HOPPING   =    0x66,
			CTL_BUZZER    =    0x62,
            CTL_LBT_TIME  =    0x67, // han 2008.7.28
            CTL_HOPPING_ONOFF = 0x6f,// han 2008.7.28
            CTL_CH_NUMBER =    0x6e, // han 2008.7.28
            CTL_DEFAULT =      0x64  // han 2008.7.28

		}
		public enum MEMBANK_CODE
		{
			BANK_RESERVED  =       0x0,
			BANK_EPC       =       0x1,
			BANK_TID       =       0x2,
			BANK_USER      =       0x3
		}
		public enum HOPPING_CODE
		{
			KOREA_FHSS     =       0x30,
			KOREA_LBT      =       0x31,
			JAPAN_LBT      =       0x32,
			EURO_LBT       =       0x33,
			USA_FHSS       =       0x34,
			CHINA_FHSS     =       0x36
		}
		public enum ActField
		{
			KillPWD = 0x01,
			AccessPWD = 0x02,
			EPC = 0x03,
			TID = 0x04,
			USER = 0x05
		}

		#endregion

		#region  PlaySound 
		[DllImport("coredll.dll")]
		private static extern int PlaySound(string szSound, IntPtr hModule, int flags);
		private enum PlaySoundFlags : int
		{
			SND_SYNC = 0x0,     // play synchronously (default)
			SND_ASYNC = 0x1,    // play asynchronously
			SND_NODEFAULT = 0x2,    // silence (!default) if sound not found
			SND_MEMORY = 0x4,       // pszSound points to a memory file
			SND_LOOP = 0x8,     // loop the sound until next sndPlaySound
			SND_NOSTOP = 0x10,      // don't stop any currently playing sound
			SND_NOWAIT = 0x2000,    // don't wait if the driver is busy
			SND_ALIAS = 0x10000,    // name is a registry alias
			SND_ALIAS_ID = 0x110000,// alias is a predefined ID
			SND_FILENAME = 0x20000, // name is file name
			SND_RESOURCE = 0x40004, // name is resource name or atom
		};
		public static void PlaySound(string fileName)
		{
			PlaySound(fileName, IntPtr.Zero, (int)(PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_ASYNC | PlaySoundFlags.SND_NOSTOP));
		}
		public static void PlaySuccess()
		{
			PlaySound(@"\Windows\Success.wav", IntPtr.Zero, (int)(PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_ASYNC | PlaySoundFlags.SND_NOSTOP));
		}
		public static void PlayFail()
		{
			PlaySound(@"\Windows\fail.wav", IntPtr.Zero, (int)(PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_ASYNC | PlaySoundFlags.SND_NOSTOP));
		}
		#endregion
		
    }
}
