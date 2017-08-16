
// devicectrl.h

#pragma once


#ifdef DEVICECTRL_EXPORTS
#define DEVICECTRL_API extern "C" __declspec(dllexport)
#else
#define DEVICECTRL_API extern "C" __declspec(dllimport)
#endif



/*--------------------------------------------------------
/
/ function : Turn reader power on or off respectively.
/
/ parameters :
/     BOOL reader : set to 1 if remote reader is to be used
/
/ return : returns power settle time required before operation in msecs. 
/              or returns -1 if failed.
/
/-------------------------------------------------------*/
DEVICECTRL_API DWORD DeviceCtrlOn(BOOL reader);
DEVICECTRL_API DWORD DeviceCtrlOff(BOOL reader);

/*--------------------------------------------------------
/
/ function : Open communication channel
/
/ parameters :
/     BOOL reader : set to 1 if remote reader is to be used
/
/ return : returns TRUE if successful.
/
/-------------------------------------------------------*/
DEVICECTRL_API BOOL DeviceCtrlOpen(BOOL reader);

/*--------------------------------------------------------
/
/ function : Close communication channel.
/
/ parameters :
/     BOOL reader : set to 1 if remote reader is to be used
/
/ return : returns TRUE if successful.
/
/-------------------------------------------------------*/
DEVICECTRL_API BOOL DeviceCtrlClose(BOOL reader);

/*--------------------------------------------------------
/
/ function : test purpose function. need not be implemented
/
/ parameters :
/		UINT32 mode : booting mode
/
/ return : return 1 on success, -1 on failure.
/
/-------------------------------------------------------*/
DEVICECTRL_API DWORD DeviceCtrlBoot(UINT32 mode);


/*--------------------------------------------------------
/
/ function : store or recall current communication mode permanently.
/
/ parameters :
/		UINT32 mode : communication channel mode
/
/ return : return 1 on success, -1 on failure.
/
/-------------------------------------------------------*/
DEVICECTRL_API BOOL DeviceCtrlSetComMode(DWORD mode);
DEVICECTRL_API BOOL DeviceCtrlGetComMode(DWORD *mode);

/*--------------------------------------------------------
/
/ function : store or recall default comport number permanently.
/
/ parameters :
/		UINT32 index : comport number
/
/ return : return index on success, 0 on failure.
/
/-------------------------------------------------------*/
DEVICECTRL_API INT32 DevSetDefaultPort(UINT32 index);
DEVICECTRL_API INT32 DevGetDefaultPort();

// ***************************************************************************
// Function Name: DevGetPhoneNumber (Obsolete)
// 
// Purpose: Recall phone number from the terminal.
//
// Paraameters:
//         LPTSTR phno : phone number
//
// return : return TRUE on success, FALSE on failure.
// ***************************************************************************
DEVICECTRL_API BOOL DevGetPhoneNumber(LPTSTR phno);

// ***************************************************************************
// Function Name: SendSMS (Obsolete)
// 
// Purpose: Send an SMS Message
//
// Arguments: none
//
// Return Values: result
//
// Description:
//	Called after everything has been set up, this function merely opens an
//	SMS_HANDLE and tries to send the SMS Message.
//
DEVICECTRL_API INT32 DevSendSMS(BOOL bSendConfirmation, LPCTSTR lpszRecipient, LPCTSTR lpszCallback, LPCTSTR lpszMessage);


/*---------------------------------------------------------------------------------
/
/	Application Menubar Control Library APIs
/
/---------------------------------------------------------------------------------*/


enum DOCK_MENUBAR_POS {
	DOCK_MENUBAR_HIDE = 0,
	DOCK_MENUBAR_SHOW,
	DOCK_MENUBAR_RELEASE,
	DOCK_MENUBAR_TOP,
	DOCK_MENUBAR_BOTTOM,
	DOCK_MENUBAR_LEFT,
	DOCK_MENUBAR_RIGHT,
};


DEVICECTRL_API BOOL DevSetupMenuBar(HWND hDlg, LPTSTR strLeft, INT32 idLeft, LPTSTR strRight, INT32 idRight);

DEVICECTRL_API BOOL DevHideMenuBar(HWND hDlg, BOOL hideLeft, INT32 idLeft, BOOL hideRight, INT32 idRight);

DEVICECTRL_API BOOL DevDockMenuBar(HWND hDlg, DOCK_MENUBAR_POS dock_pos);

DEVICECTRL_API BOOL DevInitMenuBar(HWND hDlg);
DEVICECTRL_API BOOL DevCloseMenuBar(HWND hDlg);

DEVICECTRL_API BYTE DevAssignAppKey( HWND hDlg );
DEVICECTRL_API void DevDeassignAppKey( BYTE key );


/*---------------------------------------------------------------------------------
/
/	Bluetooth Library APIs
/
/---------------------------------------------------------------------------------*/

#include "bthutils.h"

typedef LPVOID BthHANDLE;

DEVICECTRL_API BOOL BthEnumCOMPorts(BthHANDLE bh);
DEVICECTRL_API UINT32 BthGetNumCOMs(BthHANDLE bh);
DEVICECTRL_API BOOL BthGetCOMInfo(BthHANDLE bh, COMInfo *pCOMInfo);
DEVICECTRL_API BOOL BthStartBluetoothMonitor(BthHANDLE bh);
DEVICECTRL_API BOOL BthStopBluetoothMonitor(BthHANDLE bh);
DEVICECTRL_API INT32 BthGetNumDevices(BthHANDLE bh);
DEVICECTRL_API BOOL BthGetDeviceInfo(BthHANDLE bh, DeviceInfo *pPeerDevicesInfo);
DEVICECTRL_API BOOL BthAddDeviceInfo(BthHANDLE bh, DeviceInfo *pPeerDevicesInfo);
DEVICECTRL_API INT32 BthDiscoverDevices(BthHANDLE bh);
DEVICECTRL_API INT32 BthDiscoverDevicesEx(BthHANDLE bh, BOOL (*dispacher)(DeviceInfo *));
DEVICECTRL_API HANDLE BthConnectComPort(BthHANDLE bh, BOOL client, BT_ADDR device, UINT32 *channel, UINT32 index, UINT32 stream_size);
DEVICECTRL_API BOOL BthQueryComPort(BthHANDLE bh, DWORD *index, HANDLE *h);
DEVICECTRL_API BOOL BthDisconnectComPort(BthHANDLE bh, HANDLE h);
DEVICECTRL_API BthHANDLE BthCreate();
DEVICECTRL_API INT32 BthClose(BthHANDLE bh);
