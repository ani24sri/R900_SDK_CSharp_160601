#ifndef UHFAPI_H
#define UHFAPI_H

#include "rfid_def.h"

#ifdef UHFAPI_EXPORTS
#define UHFAPI_API extern "C" __declspec(dllexport)
#else
#define UHFAPI_API extern "C" __declspec(dllimport)
#endif


/*****************************************************************************************************
////////////////////////////////////////// MESSAGE DEFINITION  ///////////////////////////////////////
******************************************************************************************************/

// register a windows message
#define WM_UHFAPI_MESSAGE  RegisterWindowMessage(L"UHFAPI_MESSAGE")//WM_USER + 1612

#if 1 // han 2009.9.30

typedef enum MSG_TYPE {
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
} enumMsgType;

#else

enum DATA_FLAG {
	DATA_FLAG_GENERAL = 0,		// 일반적인 메모리 내용
	DATA_FLAG_LOCK_BIT = 1,		// LockBit
	DATA_FLAG_KILL_PWD = 2,		// Kill Password
	DATA_FLAG_ACCESS_PWD = 3,	// Access Password
	DATA_FLAG_EPC = 4,			// EPC
};

enum REPLY_FLAG {
	REPLY_FLAG_CMD_BEGIN = 0,
	REPLY_FLAG_CMD_END = 1,
	REPLY_FLAG_CMD_INFO = 2,
};

#endif


// access result code
typedef enum {
	ACCESS_RESULT_OK			 = 0,
	ACCESS_RESULT_NOT_CONNECTED	 = -1,
	ACCESS_RESULT_NOT_DETECT	 = -2,
	ACCESS_RESULT_ACCESS_ERROR	 = -3,
	// command finished with error, see error message string for details
	ACCESS_RESULT_NOT_OPENED	 = -4, // han 2008.12.2
	ACCESS_RESULT_INVALID_PARAMETER	 = -5, // han 2008.12.2
	// command terminated by invalid parameter
	ACCESS_RESULT_COMMAND_ERROR	 = -6, // han 2008.12.2
	// command terminated by device error
	ACCESS_RESULT_LOW_BATTERY	 = -7, // han 2008.12.2
	ACCESS_RESULT_Unknown	 = -8, // han 2008.12.2
	ACCESS_RESULT_NOT_SUPPORTED	 = -9, // han 2008.12.11
	// the command is not supported by this device
	ACCESS_RESULT_STOPPED	 = -10, // han 2008.12.11
	ACCESS_RESULT_POWER_OFF	 = -11, // han 2008.12.17
} enumAccessResult;

// report mode bit field definition
typedef enum {
	REPORT_MODE_WAIT_DONE	= 1, // han 2008.12.11
	// default disabled; do not return API function until operation d finished. No message are generated
	REPORT_MODE_ACCESS_EPC	= 2, // han 2008.12.11
	// default enabled; do not generate message for the EPC report. EPC can be read when operation is finished successfully
	REPORT_MODE_EXTENDED_INFORMATION = 4, // han 2008.12.16
	// default disabled; report epc with additional auxiliary information
	REPORT_MODE_BATTERY_FAULT = 8, // han 2009.10.12
	// default enabled; check battery fault
	REPORT_MODE_THREAD_MESSAGE = 16, // han 2010.1.11
	// default disabled; application handle is thread id. use thread message for message 
	REPORT_MODE_NO_EPC_CRC = 32, // han 2010.1.11
	// default enabled; do not report crc word for epc
	REPORT_MODE_RFTX_INFO = 64, // han 2010.5.12
	// default disabled; for administrator use only
} enumReportMode;

#define MAX_MASK_BYTES	(256/8)

#define MAX_SELECT_MASK	8 // han 2010.12.31

typedef struct {
	BYTE mskMemBank;	// mem bank id for selection mask. it is one of the BANK_RESERVED,BANK_EPC,BANK_TID and BANK_USER.
	UINT mskOffset;		// mem bank bit offset for selection mask
	UINT mskBits;		// mem bank pattern bits for selection mask
	BYTE mskPattern[MAX_MASK_BYTES];// bit pattern for selection mask
} typeSelectMask;

typedef struct { // han 2010.12.31
	BYTE SelectTarget;	// select target, 0=s0,1=s1,2=s2,3=s3,4=select flag
	BYTE ActionCode;    // select action, 
					//+-------+----------------------------+---------------------------+
					//|       | SelectTarget==SL           | SelectTarget==Inventoried |
					//|Action +----------------------------+-----------+---------------+
					//| Code  | matching    | non-matching | matching  | non-matching  |
					//+-------+-------------+--------------+-----------+---------------+
					//| 0     | Assert SL   | De-assert SL | ->A       | ->B           |
					//| 1     | Assert SL   | No Action    | ->A       | No Action     |
					//| 2     | No Action   | De-assert SL | No Action | ->B           |
					//| 3     | Negate SL   | No Action    | Negate    | No Action     |
					//| 4     | De-assert SL| Assert SL    | ->B       | ->A           |
					//| 5     | De-assert SL| No Action    | ->B       | No Action     |
					//| 6     | No Action   | Assert SL    | No Action | ->A           |
					//| 7     | No Action   | Negate SL    | No Action | Negate        |
					//+-------+-------------+--------------+-----------+---------------+
	BYTE mskMemBank;	// mem bank id for selection mask. it is one of the BANK_RESERVED,BANK_EPC,BANK_TID and BANK_USER.
	UINT mskOffset;		// mem bank bit offset for selection mask
	UINT mskBits;		// mem bank pattern bits for selection mask
	BYTE mskPattern[MAX_MASK_BYTES];// bit pattern for selection mask
} typeSelectMaskEx;


typedef struct _tag_TAG_OP_PARAM {
	BOOL single_tag;		// access operation for only 1 tag
	BOOL QuerySelected;		// inventory only for selected tag
	typeSelectMask mask; // select mask for query
	UINT32 timeout;		// access operation timeout in [ms]
} *P_TAG_OP_PARAM, TAG_OP_PARAM;

typedef struct { // han 2010.1.25
	INT16	ChannelNo;
	INT32	ChannelFrequency; // frequency in khz
	INT16	ChannelPower; // attenuation from max power in 0.1dB, so negative value
} typeChanInfo;

typedef struct { // han 2010.1.25
	BOOL	Hopping;
	INT16	Channels;
	INT32	TxMaxPower;
	INT32	TxMinPower; // han 2010.5.12
	INT32	TxPowerStep; // han 2010.5.12
	INT16	TxOn;	// in msec
	INT16	TxOff; // in msec
	INT16	TxWait;	// in msec
	typeChanInfo	ChannelList[50];
} typeBandCap;


typedef struct {
    unsigned int ID_high;       /* Upper 32 bits of the 64-bit Link-profile ID */
    unsigned int ID_low;        /* Lower 32 bits of the 64-bit Link-profile ID */
    unsigned int Cfg;
    unsigned int protocol;      /* 0=iso_18k6c */
    union {
        struct {
            unsigned int R2T_mod_type;  /* 0=DSB-ASK, 1=SSB-ASK, 2=PR-ASK */
            unsigned int Tari_nsecs;    /* Tari that gets implemented by the link profile, in nsecs */
            unsigned int X;             /* X that gets implemented by the link profile. 0 means 0.5, 1 means 1 */
            unsigned int PW_nsecs;      /* Pulse-width that gets implemented by the link profile, in nsecs */
            unsigned int RTCal_nsecs;   /* RTCal that gets implemented by the link profile, in nsecs */
            unsigned int TRCal_nsecs;   /* TRCal that gets implemented by the link profile, in nsecs */
            unsigned int divide_ratio;  /* 0 means 8, while 1 means 64/3 */
            unsigned int miller_num;    /* 0=FM0, 1=M2, 2=M4, 3=M8 */
            unsigned int T2R_link_freq; /* specified in Hz. This is the frequency - not the  */
            unsigned int var_T2_delay_usecs;  /* specifies the amount of additional delay needed for T2 */
            unsigned int RX_delay;      /* Specifies the value that will be used in the EOT.rx_delay field */
            unsigned int tx_prop_latency_usecs; /* Specifies the number of usecs needed to propagate TX signals */
        } iso_18k6c;
    } prot;
} typeRFMode;

enum CMD_INFO {
	CMD_INFO_AMB_TEMP = 1,
	CMD_INFO_LBT_RSSI = 2,
	CMD_INFO_CHANNEL = 3,
	CMD_INFO_TX = 4,
	CMD_INFO_CUSTOM = 1000,
};


/*****************************************************************************************************
ERROR MESSAGE WORDING LIST

TAG Backscatter Error -------------------------------------------------------------------
	"Other Error"				Tag Error Code 0x00
	"Memory Overrun"			Tag Error Code 0x03
	"Memory Locked"				Tag Error Code 0x04
	"Insufficient Tag Power"	Tag Error Code 0x0B
	"Non-specific Error"		Tag Error Code 0x0F
General Error ---------------------------------------------------------------------------
	"Check Antenna"				antenna is not connected properly
	"Try after cooled"			the operation is stopped by overheat
	"Insufficient PDA Power"	the PDA battery level is low
Command end message -------------------------------------------------------------------
	"OK"						The API function finished successfully
	"Not Supported"				The function is not supported by the module
	"Not Connected"				The module is disconnected after open
	"Not Opened"				The module is not open
	"Bad Access Password"		bad access password is supplied for access operation
	"Invalid Parameter"			a Invalis parameter is supplied for a  API function
	"Command Error"				A error has occured durion command execution.
	"Success"					A command is finished with success
	"Not Detect"				No tags are detected for a access operation
	"Multi Read Stop"			A multi tag operation is stooped by stop command
*****************************************************************************************************/


/*****************************************************************************************************
///////////////////////////////////// general functions  /////////////////////////////////////////////
******************************************************************************************************/

UHFAPI_API BOOL UHFAPI_Open();
/*****************************************************************************************************
Description   : Open comport for UHF RFID device control
Parameter     : void
Return        : true on success, false on fail
Protocol Type : EPC Gen2
******************************************************************************************************/

UHFAPI_API BOOL UHFAPI_HWND_EX(HWND handle, UINT report_mode_set=0, UINT report_mode_reset=0); // han 2008.12.1
/*****************************************************************************************************
Description   : register window handle to receive window message
Parameter     : HWND handle of the application
Return        : true
remark        : refer to enumReportMode definition
Protocol Type : EPC Gen2
******************************************************************************************************/

UHFAPI_API BOOL UHFAPI_IsOpen();
/*****************************************************************************************************
Description   : Get comport open state
Parameter     : void
Return        : true if opened, false if no opened
Protocol Type : EPC Gen2
******************************************************************************************************/

UHFAPI_API BOOL UHFAPI_Close();
/*****************************************************************************************************
Description   : Release comport
Parameter     : void
Return        : true
Protocol Type : EPC Gen2
******************************************************************************************************/

UHFAPI_API BOOL UHFAPI_GetLibVersion(LPWSTR szValue);
/*****************************************************************************************************
Description   : get this library version
Parameter     : LPWSTR szValue to receive version string. should be long enough to receive version string
Return        : true
Protocol Type : EPC Gen2
******************************************************************************************************/

UHFAPI_API BOOL UHFAPI_IsBusy();
/*****************************************************************************************************
Description   : Get module status whether tag operation is underdoing or idle
Parameter     : void
Return        : TRUE if busy
Protocol Type : EPC Gen2
******************************************************************************************************/

UHFAPI_API BOOL UHFAPI_Stop(BOOL wait_done);
/*****************************************************************************************************
Description   : Stops current tag operation
Parameter     : wait_done; TRUE for waiting stop operation finished
Return        : true if stopped or stop operation is started with no problem
Protocol Type : EPC Gen2
******************************************************************************************************/

UHFAPI_API BOOL UHFAPI_GET_FilterMode(BOOL *mode); // han 2011.1.5
UHFAPI_API BOOL UHFAPI_SET_FilterMode(BOOL mode);  // han 2011.1.5
/*****************************************************************************************************
Description   : Enable/Disable unique tag report mode. check if the read epc is unique for an inventory process.
Parameter     : mode ; TRUE to enable, FALSE to disable
Return        : true 
Protocol Type : EPC Gen2
******************************************************************************************************/

//han 2010.10.27 UHFAPI_API BOOL UHFAPI_GET_RESULT(LPWSTR szResult);
UHFAPI_API BOOL UHFAPI_GET_RESULT_MESSAGE(LPWSTR szResult, UINT msg, WPARAM wParam, LPARAM lParam); // han 2008.11.29
UHFAPI_API BOOL UHFAPI_GET_EPC(LPWSTR szResult); // han 2008.12.16
UHFAPI_API BOOL UHFAPI_GET_DATA(LPWSTR szResult); // han 2008.12.16
UHFAPI_API LPWSTR UHFAPI_GET_LAST_ERROR(); // han 2008.12.1
UHFAPI_API enumAccessResult UHFAPI_GET_LAST_ERROR_CODE(); // han 2009.10.1
/*****************************************************************************************************
Description   : After operation a message is posted to the application if set to do. After receiving message 
                the application calls these functions to get operation result accordingly
Parameter     : LPWSTR szResult
                msg,wParam,lParam; paramters in the event message.
Return        : true if success
Protocol Type : EPC Gen2
Remark        : use *_GET_RESULT_MESSAGE() to get result with message queue maintenance. use this one instead of *_GET_RESULT()
                use *_GET_LAST_ERROR() to get result status after executing *_Done() function.
*****************************************************************************************************/


UHFAPI_API BOOL UHFAPI_GetFirmwareVersion(LPWSTR szValue); // han 2008.11.18
/*****************************************************************************************************
Description   : get firmware version of RFID module.
Parameter     : LPWSTR szValue , where to recieve the firmware version string 
Return        : true if success
Protocol Type : EPC Gen2
******************************************************************************************************/

UHFAPI_API tag_t UHFAPI_GetReaderClock(DWORD ReaderTick);
UHFAPI_API BOOL UHFAPI_SpecialAccessCtrl(UINT32 type, UINT32 code, UINT32 *value);
UHFAPI_API BOOL UHFAPI_ProprietaryCommand(UINT32 action, DWORD (*cbproc)(LPVOID context, LPVOID message), LPVOID context);
/*****************************************************************************************************
Description   : for engeering purpose
******************************************************************************************************/

//======================================  end of general function   =====================================



/*****************************************************************************************************
///////////////////////////////////// tag operation functions ////////////////////////////////////////
******************************************************************************************************/

UHFAPI_API enumAccessResult UHFAPI_Inventory(TAG_OP_PARAM *param = NULL, BOOL wait_done = FALSE);
/****************************************************************************************************
Description   : inventory tags for a given time
Parameter     : TAG_OP_PARAM *param : operation parameters
                wait_done : true means "DO NOT RETURN". return after all operations are done. 
                                And no message is posted to the host.
Return        : operation result status refer to enumAccessResult. ACCESS_RESULT_OK is returned if operation is started.
Remark        : use UHFAPI_GET_EPC() and/or UHFAPI_GET_RESULT_MESSAGE() on message reception to get the data or status.
                The system could be locked if wait_done is selected but no stop condition is given.
Protocol Type : EPC Gen2
******************************************************************************************************/

UHFAPI_API enumAccessResult UHFAPI_ReadTag(BYTE MemBank, UINT offset, UINT length,
							   UINT32 pwdACCESS=0, TAG_OP_PARAM *param=NULL, BOOL wait_done=FALSE);
/******************************************************************************************************
Description   : read data from a tag or tags
Parameter     : BYTE MemBank - bank address where to read
				UINT offset (Min:0 ~ Max:422820625) - word offset of the bank
				UINT length(Min:1 ~ Max:255) - word count to read in
				pwdACCESS : access password of the tag to read. 0 means no access password.
                TAG_OP_PARAM *param : operation parameters
                wait_done : true means "DO NOT RETURN". return after all operations are done. 
                                And no message is posted to the host.
                             After returning, use UHFAPI_GET_EPC() and UHFAPI_GET_DATA() to get result
Return        : result status
Remark        : use GET_LAST_ERROR() to get result status
                
Protocol Type : EPC Gen2
******************************************************************************************************/

UHFAPI_API enumAccessResult UHFAPI_WriteTag(BYTE MemBank, UINT offset, UINT length, WORD *szWriteData,
								UINT32 pwdACCESS=0, TAG_OP_PARAM *param=NULL, BOOL wait_done=FALSE);
/******************************************************************************************************
Description   : write data to a tag or tags
Parameter     : BYTE MemBank - bank address where to write
				UINT offset (Min:0 ~ Max:422820625) - word offset of the bank
				UINT length(Min:1 ~ Max:255) - word count to access
				pwdACCESS : access password of the tag to access. 0 means no access password.
                TAG_OP_PARAM *param : operation parameters
                wait_done : true means "DO NOT RETURN". return after all operations are done. 
                                And no message is posted to the host.
                             After returning, use UHFAPI_GET_EPC() and UHFAPI_GET_DATA() to get result
Return        : result status
Remark        : use GET_LAST_ERROR() to get result status
Protocol Type : EPC Gen2
******************************************************************************************************/

// MemBank
#define BANK_RESERVED          0x0
#define BANK_EPC               0x1
#define BANK_TID               0x2
#define BANK_USER              0x3



UHFAPI_API enumAccessResult UHFAPI_LockTag(bool kill_pwd, bool access_pwd, bool epc, bool tid, bool user,
							   UINT32 pwdACCESS=0, TAG_OP_PARAM *param=NULL, BOOL wait_done=FALSE);
/******************************************************************************************************
Decription    : lock the selected memory bank or password memory.
				passwords are only accessible using access password if locked.
				epc, tid, user memory banks are writable using access password if locked. but can be read without access password
Parameter     : bool kill_pwd, bool access_pwd, bool epc, bool tid, bool user - set to true if want to lock
				pwdACCESS : access password of the tag to access. 0 means no access password.
                TAG_OP_PARAM *param : operation parameters
                wait_done : true means "DO NOT RETURN". return after all operations are done. 
                                And no message is posted to the host.
                             After returning, use UHFAPI_GET_EPC() and UHFAPI_GET_DATA() to get result
Return        : result status
Protocol Type : EPC Gen2
******************************************************************************************************/


UHFAPI_API enumAccessResult UHFAPI_UnlockTag(bool kill_pwd, bool access_pwd, bool epc, bool tid, bool user,
							   UINT32 pwdACCESS=0, TAG_OP_PARAM *param=NULL, BOOL wait_done=FALSE);
/******************************************************************************************************
Decription    : unlock the selected memory bank or password memory.
Parameter     : bool kill_pwd, bool access_pwd, bool epc, bool tid, bool user - set to true if want to unlock
				pwdACCESS : access password of the tag to access. 0 means no access password.
                TAG_OP_PARAM *param : operation parameters
                wait_done : true means "DO NOT RETURN". return after all operations are done. 
                                And no message is posted to the host.
                             After returning, use UHFAPI_GET_EPC() and UHFAPI_GET_DATA() to get result
Return        : result status
Protocol Type : EPC Gen2
******************************************************************************************************/

UHFAPI_API enumAccessResult UHFAPI_PermalockTag(BYTE ActionField, bool lock,
											 UINT32 pwdACCESS=0, TAG_OP_PARAM *param=NULL, BOOL wait_done=FALSE);
/******************************************************************************************************
Decription    : permanently locks the memory or password designated by the ActionField.
				* Permanently locked memory or password cannot revert to unlocked sate.
Parameter     : ActionField = memory or password to lock. see codes below.
				lock = set to true to lock permanently
                TAG_OP_PARAM *param : operation parameters
                wait_done : true means "DO NOT RETURN". return after all operations are done. 
                                And no message is posted to the host.
                             After returning, use UHFAPI_GET_EPC() and UHFAPI_GET_DATA() to get result
Return        : result status
Protocol Type : EPC Gen2
******************************************************************************************************/
// Action Field
#define ActField_KillPWD	0x01
#define ActField_AccessPWD	0x02
#define ActField_EPC		0x03
#define ActField_TID		0x04
#define ActField_USER		0x05


typedef enum {
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
} typeLockMasks;

UHFAPI_API enumAccessResult UHFAPI_LockSetTag(typeLockMasks masks, typeLockMasks enables,
												UINT32 pwdACCESS=0, TAG_OP_PARAM *param=NULL, BOOL wait_done=FALSE);
/******************************************************************************************************
Decription    : change lock state of tag
Parameter     : TypeLockMasks masks : state to be changed
                TypeLockMasks enables : sert true to change corresponding state
                TAG_OP_PARAM *param : operation parameters
                wait_done : true means "DO NOT RETURN". return after all operations are done. 
                                And no message is posted to the host.
                             After returning, use UHFAPI_GET_EPC() and UHFAPI_GET_DATA() to get result
Return        : result status
Protocol Type : EPC Gen2
******************************************************************************************************/




UHFAPI_API enumAccessResult UHFAPI_KillTag(UINT32 Kill_PWD,
											 UINT32 pwdACCESS=0, TAG_OP_PARAM *param=NULL, BOOL wait_done=FALSE);
/******************************************************************************************************
Decription    : kill tag. a killed tag neverr respond to a command.
Parameter     : UINT32 Kill_PWD - Kill Password of the tag (8Byte)
                TAG_OP_PARAM *param : operation parameters
	                mskMemBank : the bank address of the select masks. one of BANK_RESERVED,BANK_EPC,BANK_TID and BANK_USER
		            mskOffset : bit offset address of the bank of the select mask.
		            mskBits : number of bits of the select mask
			        mskPattern : bit pattern of the select mask. MSB is the first bit.
					pwdACCESS : access password of the tag. 0 for null access password.
					timeout : maximum operation time in [ms]. 0 for endless until UHFAPI_Stop() is called.
				wait_done : TRUE for returning when success or operation timeout.
				                    tag id(PC/EPC) can be read using UHFAPI_GET_EPC() after return.
					        FALSE for using events to get operation result using UHFAPI_GET_RESULT_MESSAGE() after event.
Return        : result state
Remark        : To kill a tag, the tag must have non-0 kill password.
				A killed tag can not work permanently
Protocol Type : EPC Gen2
******************************************************************************************************/


//=====================================  end of tag operation  ============================================




/****************************************************************************************************
////////////////////////////////////// RFID module setting function  ////////////////////////////////
****************************************************************************************************/

// All settings are cleared after power cycle. If the host is PDA, it turns off by timeout.
// So, to keep the setting are kept, the application must reprogram the module after power cycling.
// or you can use UHFAPI_PowerOnInit() to recover setting after power up

UHFAPI_API BOOL UHFAPI_SET_PowerControl(UINT attDb10);
UHFAPI_API BOOL UHFAPI_GET_PowerControl(UINT *attDb10);
/*************************************************************************************************
Description   : set tc power level
				attDb10 Min:0(Full Power) ~ Max:300
				Default = 0
				attDb10 is attenuation value 
				ex) attDb10 = 30, the tx power is reduced by 3dB.

				 +-----------------------------------------------------------+
				 |attDb10   |     0     | 10  |  20 |  .......        | 100  |
				 |-----------------------------------------------------------|
				 |Power(dBm)|    Full   |-1db |-2db |  .......        |-10db |
				 +-----------------------------------------------------------+
Parameter     : UINT attDb10
Return        : true = success, false = fail
Protocol Type : EPC Gen2
*************************************************************************************************/


UHFAPI_API BOOL UHFAPI_SET_Session(BYTE SessionCode);
UHFAPI_API BOOL UHFAPI_GET_Session(BYTE *SessionCode);
/************************************************************************************************
Description   : set session value for query command(inventory)
Parameter     : BYTE SessionCode see below
Return        : true = Success, false = fail
Protocol Type : EPC Gen2
                
*************************************************************************************************/
//Session Code
#define SESSION_0              0x30 // han 2008.5.20
#define SESSION_1              0x31
#define SESSION_2              0x32
#define SESSION_3              0x33


UHFAPI_API BOOL UHFAPI_SET_QValue(UINT QValue);
UHFAPI_API BOOL UHFAPI_GET_QValue(UINT *QValue);
/**************************************************************************************************
Description   : set population Q for query command.
				QValue Min:0(Auto) ~ Max:15
				Default = 0
Parameter     : UINT QValue
Return        : true = success, false = fail
Protocol Type : EPC Gen2
***************************************************************************************************/

UHFAPI_API BOOL UHFAPI_SET_InventoryTarget(BYTE TargetCode);
UHFAPI_API BOOL UHFAPI_GET_InventoryTarget(BYTE *TargetCode);
/**************************************************************************************************
Description   : set inventorized falsg state for query command.
Parameter     : BYTE TargetCode see below
Return        : true = success, false = fail
Protocol Type : EPC Gen2
***************************************************************************************************/
#define TARGET_AB_A		0x30 // query only tags with inventorized flag A
#define TARGET_AB_B		0x31 // query only tags with inventorized flag B
#define TARGET_AB_AB	0x32 // query only tags with inventorized flag A or B

UHFAPI_API BOOL UHFAPI_SET_SelectActionMultiple(int count, typeSelectMaskEx *maskex); // han 2010.12.31
UHFAPI_API BOOL UHFAPI_SET_SelectAction(BOOL SelectFlag, BYTE ActionCode, typeSelectMask *mask = NULL);
UHFAPI_API BOOL UHFAPI_GET_SelectAction(BOOL *SelectFlag, BYTE *ActionCode);
/**************************************************************************************************
Description   : set select action(action for the inventorized and/or SL) for select command
Parameter     : SelectFlag : set true if action takes effect on SL flag, false to act on Inventorized flag
                ActionCode . see below. see gen2 specification
                mask : select mask to match
				count : number of actions in the list
				maskex : action list pointer
Return        : true = success, false = fail
Protocol Type : EPC Gen2
***************************************************************************************************/
#define SELECT_ACTION_0		0x30 //ASLINVA_DSLINVB
#define SELECT_ACTION_1		0x31 //ASLINVA_NOTHING
#define SELECT_ACTION_2		0x32 //NOTHING_DSLINVB
#define SELECT_ACTION_3		0x33 //NSLINVS_NOTHING
#define SELECT_ACTION_4		0x34 //DSLINVB_ASLINVA
#define SELECT_ACTION_5		0x35 //DSLINVB_NOTHING
#define SELECT_ACTION_6		0x36 //NOTHING_ASLINVA
#define SELECT_ACTION_7		0x37 //NOTHING_NSLINVS

UHFAPI_API BOOL UHFAPI_SET_OpMode(BOOL SingleTag, BOOL UseMask, BOOL QuerySelected, UINT32 timeout);
UHFAPI_API BOOL UHFAPI_GET_OpMode(BOOL *SingleTag, BOOL *UseMask, BOOL *QuerySelected, UINT32 *timeout);
/**************************************************************************************************
Description   : set tag operation mode
Parameter     : SingleTag : access on a single tag
                UseMask : access using select mask for tag singulation
                QuerySelcted : query only selected tags
				timeout : interval to try access
Return        : true = success, false = fail
Protocol Type : EPC Gen2
***************************************************************************************************/


UHFAPI_API BOOL UHFAPI_SET_LBT_CHState(UINT32 State);
UHFAPI_API BOOL UHFAPI_GET_LBT_CHState(UINT32 *State);
/************************************************************************************************
Description   : mask off channel for LBT channel. 
				Min:1 ~ Max:255
				Japan  Default : Japan  254 ( using ch2 to ch8 )
Parameter     : UINT State
				Ex) State = 254 = 1111 1110 
					=> use channel ch2 to ch8 ( LSB = ch1 )
Return        : true = Success, false = fail
Protocol Type : EPC Gen2
*************************************************************************************************/


UHFAPI_API BOOL UHFAPI_SET_LBT_Time(UINT LBT_Time);
/************************************************************************************************
Description   : maximum occupation time of a channel in ms. it apply only for LBTchannel
				Default = 4000
Parameter     : UINT LBT_Time (Min:0 ~ Max:4000)
Return        : true = Success, false = fail
remark        : the maxmum resident time is 4000msec. if set to 0, the resident time is the minimum time 
Protocol Type : EPC Gen2
************************************************************************************************/

UHFAPI_API BOOL UHFAPI_SET_Default();
/************************************************************************************************
Description   : reset settings to default values
Parameter     : void
Return        : true = Success, false = fail
Protocol Type : EPC Gen2
*************************************************************************************************/



// Tx duty control APIs 2008.10.24
UHFAPI_API BOOL UHFAPI_SetAirDura(UINT onms, UINT offms);
/************************************************************************************************
Description   : Set rf tx cycle duration. The durations must meet the natonal regulation.
Parameter     : onms ; on duration in msec unit
                offms ; off duration in msec unit
Return        : true = Success, false = fail
Remark        : The tatal cycle time ( onms + offms ) must be less than or equal to 
                 the maximium allowed cycle time based on the national regulation.
Protocol Type : EPC Gen2 ( AT870 only )
*************************************************************************************************/

UHFAPI_API BOOL UHFAPI_SetAirDuty(UINT speed);
/************************************************************************************************
Description   : Set rf tx cycle on-duty. The durations must meet the national regulation.
Parameter     : speed ; must be a value of 10 to 100
                        the total cycle duration is maintained. 100 means maximum duration
Return        : true = Success, false = fail
Remark        : The on and off durations are caculated based on pre-defined national regulation.
                 ie, the calcalation is not accumulative.
Protocol Type : EPC Gen2 ( AT870 only )
*************************************************************************************************/



//===================================== end of setting function  =====================================




//===================================== engineering function  =====================================

UHFAPI_API enumAccessResult UHFAPI_Custom_Access(BYTE *cmd, UINT cmdbytes, UINT respbits,
													UINT32 pwdACCESS, TAG_OP_PARAM *param); // han 2011.7.19
UHFAPI_API void *UHFAPI_GetTestHandle(void);
UHFAPI_API BOOL	UHFAPI_LibraryMode(INT32U mode); // han 2010.3.10
UHFAPI_API int UHFAPI_CheckBattery(void); // han 2009.1.17


// TEst Function
UHFAPI_API BOOL UHFAPI_PowerOnInit(void);

UHFAPI_API BOOL UHFAPI_SetBand(INT16 band_code); // han 2010.1.25 int band_code);	//han 2008.1.25
UHFAPI_API BOOL UHFAPI_GetBand(INT16 *band_code); // han 2010.1.25
UHFAPI_API BOOL UHFAPI_GetBandCapabilities(typeBandCap **ppCap);		//han 2010.1.25
UHFAPI_API BOOL UHFAPI_GetRFMode(typeRFMode **ppRFM); // han 2010.6.9

enum UHF_BAND_CODE {	// han 2008.1.25
	UHF_BAND_ANONYMOUS = 0, // han 2009.2.9
	UHF_BAND_FCC = 1,
	UHF_BAND_KMIC = 2,
	UHF_BAND_ARIB = 3,
	UHF_BAND_ETSI1 = 4,
	UHF_BAND_KCCh = 5,//han 2009.8.31 UHF_BAND_ETSI2 = 5,
	UHF_BAND_ARIBs = 6,
	UHF_BAND_CHINA = 7, // han 2008.7.8
	UHF_BAND_ARIBh = 8, // han 2008.10.29
};

//===================================== end of engineering function  =====================================

#endif

