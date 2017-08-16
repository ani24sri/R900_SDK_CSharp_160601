//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
//
// Use of this sample source code is subject to the terms of the Microsoft
// license agreement under which you licensed this sample source code. If
// you did not accept the terms of the license agreement, you are not
// authorized to use this sample source code. For the terms of the license,
// please see the license agreement between you and Microsoft or, if applicable,
// see the LICENSE.RTF on your install media or the root of your tools installation.
// THE SAMPLE SOURCE CODE IS PROVIDED "AS IS", WITH NO WARRANTIES OR INDEMNITIES.
//


#pragma once

#include <winsock2.h>
#include <ws2bth.h>

#include "bthapi.h"

#define MAX_NAME_SIZE 128
#define MAX_ADDR_SIZE 15
#define MAX_MESSAGE_SIZE 256

#ifndef ARRAYSIZE
#define ARRAYSIZE(a)   (sizeof(a)/sizeof(a[0]))
#endif

#define RFCOMM_CHANNEL_MULTIPLE		0xfe

typedef ULONGLONG bt_addr, *pbt_addr, BT_ADDR, *PBT_ADDR;

struct DeviceList
{ 
	BT_ADDR bthAddress;
	TCHAR bthName[40];
	DeviceList *NextDevice;
};

struct DeviceInfo 
{
	BT_ADDR *bt_addr;
	WCHAR szDeviceNameAddr[MAX_NAME_SIZE];
	WCHAR szDeviceName[MAX_NAME_SIZE];
	WCHAR szDeviceAddr[MAX_NAME_SIZE];
}; 


struct COMList
{
	TCHAR Name[10];
	TCHAR NickName[100];
	COMList *NextCOM;
};

struct COMInfo
{
	TCHAR Name[10];
	TCHAR NickName[100];
};

#if !defined(_WIN32_WCE)
#if !defined(AF_BTH) // defined in WDK
typedef struct _SOCKADDR_BTH
{
    USHORT   addressFamily;
    bt_addr  btAddr;
    GUID     serviceClassId;
    ULONG    port;
} SOCKADDR_BTH, *PSOCKADDR_BTH;
#endif
typedef ULONGLONG bt_addr, *pbt_addr, BT_ADDR, *PBT_ADDR;
typedef ULONG  bt_cod, BT_COD;
typedef ULONG  bt_lap, BT_LAP;

#define NAP_MASK                ((ULONGLONG) 0xFFFF00000000)
#define SAP_MASK                ((ULONGLONG) 0x0000FFFFFFFF)

#define NAP_BIT_OFFSET          (8 * 4)
#define SAP_BIT_OFFSET          (0)

#define GET_NAP(_bt_addr)       ((USHORT) (((_bt_addr) & NAP_MASK) >> NAP_BIT_OFFSET))
#define GET_SAP(_bt_addr)       ((ULONG)  (((_bt_addr) & SAP_MASK) >> SAP_BIT_OFFSET))

#define SET_NAP(_nap) (((ULONGLONG) ((USHORT) (_nap))) << NAP_BIT_OFFSET)
#define SET_SAP(_sap) (((ULONGLONG) ((ULONG)  (_sap))) << SAP_BIT_OFFSET)

#define SET_NAP_SAP(_nap, _sap) (SET_NAP(_nap) | SET_SAP(_sap))

typedef struct __bth_inquiry_result {
	BT_ADDR			ba;
	unsigned int	cod;
	unsigned short	clock_offset;
	unsigned char	page_scan_mode;
	unsigned char	page_scan_period_mode;
	unsigned char   page_scan_repetition_mode;
} BthInquiryResult;

#endif

#ifdef DEVICECTRL_EXPORTS
#define DEVICECTRL_API extern "C" __declspec(dllexport)
#else
#define DEVICECTRL_API extern "C" __declspec(dllimport)
#endif


class /*DEVICECTRL_API*/ CBthUtils
{
public:
	CBthUtils();
	~CBthUtils();
	int DiscoverDevices();
	int DiscoverDevicesEx(BOOL (*dispacher)(DeviceInfo *));
	int GetNumDevices(){return m_iNumDevices;};
	int GetDeviceInfo(DeviceInfo *pPeerDevicesInfo);
	int AddDeviceInfo(DeviceInfo *pPeerDevicesInfo);
	int GetLocalDeviceName(DeviceInfo *pLocalDeviceInfo);
	int GetDeviceInfo(DeviceInfo *pPeerDeviceInfo, int iSelectedItem);
	int OpenServerConnection(BYTE *rgbSdpRecord, int cSdpRecord, int iChannelOffset, void (*funcPtr)( WCHAR*));
	int SendMessageToServer(WCHAR *strGUID, WCHAR *szMessage, int iSelectedDeviceIndex);
	HANDLE ConnectComPort(BOOL client, BT_ADDR device, UINT32 *channel, UINT32 index, UINT32 stream_size);
	int DisconnectComPort(HANDLE h);
	int DisconnectComPort();
	BOOL QueryComPort(DWORD *index, HANDLE *h); // han 2010.3.8
	int BthComPort(HANDLE hDrv);
	// ext for com
	BOOL EnumCOMPorts();
	int GetNumCOMs(){return m_iNumCOMs;};
	int GetCOMInfo(COMInfo *pCOMInfo);

	static DWORD BluetoothNotificationThread(LPVOID pVoid);
	BOOL StartBluetoothMonitor();
	void StopBluetoothMonitor();

	int PerformServiceSearch (BT_ADDR pb);
#if defined(_WIN32_WCE)
	STDMETHODIMP ServiceAndAttributeSearchParse(
					UCHAR *szResponse,   // in - pointer to buffer representing 
									// the SDP record, in binary format, 
									// returned by the Bthnscreate tool.
					DWORD cbResponse,   // in - size of szResponse 
					ISdpRecord ***pppSdpRecords, // out - array of pSdpRecords
					ULONG *pNumRecords   // out - number of elements in pSdpRecords array
	);
	int RetrieveRCOMMChanId(ISdpRecord **pRecordArg, ULONG ulRecords);
#endif

private:
	DeviceList *m_pDeviceList, *m_pStart, *m_pEnd, *m_pCurrentDevice;
	int m_iNumDevices;
	void (*pCallBackFunction)( WCHAR* ) ;
	HANDLE m_hReadThread;
	SOCKET m_socketServer, m_socketClient;
	SOCKADDR_BTH m_saClient;
	DWORD m_dwBluetoothMode;

	int RegisterService(BYTE *rgbSdpRecord, int cSdpRecord, int iChannelOffset, UCHAR channel);
	int OpenClientConnection(WCHAR *strGUID, int iSelectedDeviceIndex);
	int GetGUID(WCHAR *psz, GUID *pGUID) ;

	static DWORD WINAPI ReadData(LPVOID voidArg);

	// ext for com
	int m_iNumCOMs;
	COMList *m_pCOMList;
};