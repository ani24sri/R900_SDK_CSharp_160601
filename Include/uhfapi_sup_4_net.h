// uhfapi_sup_4_net.h : main header file for the uhfapi_sup_4_net DLL
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#ifdef STANDARDSHELL_UI_MODEL
#include "resource.h"
#endif
#ifdef SMARTPHONE2003_UI_MODEL
#include "resourcesp.h"
#endif

#ifdef UHFSUPAPI_EXPORTS
#define UHFSUPAPI_API extern "C" __declspec(dllexport)
#else
#define UHFSUPAPI_API extern "C" __declspec(dllimport)
#endif

UHFSUPAPI_API UINT UHFSUPAPI_GetMessageId();

UHFSUPAPI_API HANDLE UHFSUPAPI_GetDeviceLostEventId();

UHFSUPAPI_API UINT UHFSUPAPI_GetR900MessageId();

UHFSUPAPI_API UINT UHFSUPAPI_GetDeviceLostMessageId();

UHFSUPAPI_API UINT UHFSUPAPI_GetPlatformPowerMessageId();

UHFSUPAPI_API BOOL UHFSUPAPI_UploadInventory(DWORD (*UploadInv)(LPTSTR));
#if 1 // han 2010.8.9
UHFSUPAPI_API UINT32 UHFSUPAPI_OpenUploadInventoryList();
UHFSUPAPI_API LPTSTR UHFSUPAPI_GetUploadInventoryData(UINT32 index);
UHFSUPAPI_API void UHFSUPAPI_CloseUploadInventoryList();
#endif
UHFSUPAPI_API BOOL UHFSUPAPI_ClearInventory();
