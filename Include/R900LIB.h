
// R900LIB.h

#pragma once

#include "rfid_def.h"

#ifdef R900LIB_EXPORTS
#define R900LIB_API extern "C" __declspec(dllexport)
#else
#define R900LIB_API extern "C" __declspec(dllimport)
#endif

enum {
	BUZZER_VOLUME_MUTE = 0,
	BUZZER_VOLUME_LOW = 1,
	BUZZER_VOLUME_HIGH = 2,
};

//----------------------------------------------------
// function name : R900LIB_HWND_EX
// function : set event report window handle and 
//                 set report mode (when event will be sent)
// parameters :
//           handle ; windows handle or thread handle where the events are posted
//           report_mode_set ; bit-wise report option to set
//           report_mode_reset ; bit-wise report option to reset
// return : returns TRUE on success, FALSE on failure
// remark : only valid option is REPORT_MODE_THREAD_MESSAGE for this API. see uhfapi.h
//
R900LIB_API BOOL R900LIB_HWND_EX(HWND handle, UINT report_mode_set, UINT report_mode_reset);

//----------------------------------------------------
// function name : R900LIB_UploadInventory
// function : upload inventoried data stored in R900 reader.
// parameters :
//           UploadInv ; callback function to be called to receive data.
//           index ; start index of the inventoried data list to receive. 
//           count ; total data to receive starting from index.
//                     set to zero to get to the end of the list.
// return : returns TRUE on success, FALSE on failure
// remark : R900LIB_ClearInventory() clears the inventoried data in the R900 permanently.
//          The R900 must be linked to the host.
//
R900LIB_API BOOL R900LIB_UploadInventory(DWORD (*UploadInv)(typeInventoried *), UINT32 index, UINT32 count);
R900LIB_API BOOL R900LIB_ClearInventory();

//----------------------------------------------------
// function name : R900LIB_RefreshStatus
// function : refresh R900 status or reload staus from R900
// parameters : none
// return : returns TRUE on success, FALSE on failure
// remark : The status is kept internally to check status change
//
R900LIB_API BOOL R900LIB_RefreshStatus();

//----------------------------------------------------
// function name : R900LIB_IsTriggerEvent
// function : check current trigger state of the R900.
// parameters :
//           status ; where to get current trigger state
// return : returns TRUE if trigger state has changed after last call,
//              otherwise returns FALSE.
// remark : the parameter status could be NULL.
//            *status is TRUE if trigger is pressing, FALSE if released.
//
R900LIB_API BOOL R900LIB_IsTriggerEvent(BOOL *status);

//----------------------------------------------------
// function name : R900LIB_IsLinkEvent
// function : check current link state to the R900.
// parameters :
//           status ; where to get current link state (to host)
// return : returns TRUE if link state has changed after last call,
//              otherwise returns FALSE.
// remark : the parameter status could be NULL.
//            *status is TRUE if linked, FALSE if dislinked.
//
R900LIB_API BOOL R900LIB_IsLinkEvent(BOOL *status);

//----------------------------------------------------
// function name : R900LIB_SetBuzzerVolume
// function : set buzzer volume in the R900.
// parameters :
//           value ; buzzer volume to set. refer to BUZZER_VOLUME_* above.
//           nv ; set to TRUE to keep the setting after power cycle.
// return : returns TRUE on success, FALSE on failure
// remark : GetBuzzerVolume() gets current setting from the R900.
//          This setting is defaulted after power cycle.
//          The R900 must be linked to the host.
//
R900LIB_API BOOL R900LIB_SetBuzzerVolume(UINT32 value, BOOL nv);
R900LIB_API BOOL R900LIB_GetBuzzerVolume(UINT32 *value);

//----------------------------------------------------
// function name : R900LIB_SetConfiguration
// function : for enginnering purpose
// parameters :
// return : returns TRUE on success, FALSE on failure
// remark : The R900 must be linked to the host.
//
R900LIB_API BOOL R900LIB_SetConfiguration(UINT32 reg, UINT32 value);
R900LIB_API BOOL R900LIB_GetConfiguration(UINT32 reg, UINT32 value);

//----------------------------------------------------
// function name : R900LIB_SetPowerOffDelay
// function : set auto off timeout value of the R900.
// parameters :
//           value ; auto off timeout in seconds to set.
//           nv ; set to TRUE to keep the setting after power cycle.
// return : returns TRUE on success, FALSE on failure
// remark : GetPowerOffDelay() gets current setting from the R900.
//          This setting is defaulted after power cycle.
//          The R900 must be linked to the host.
//
R900LIB_API BOOL R900LIB_SetPowerOffDelay(UINT32 value, BOOL nv);
R900LIB_API BOOL R900LIB_GetPowerOffDelay(UINT32 *value);

//----------------------------------------------------
// function name : R900LIB_GetBatteryMeter
// function : get battery left quantity in the R900.
// parameters :
//           value ; where to recieve left quantity in %.
// return : returns TRUE on success, FALSE on failure
// remark : use RunBatteryMonitor(TRUE) to get event when battery level changes.
//             use GetBatteryMeter() to get battery state after event.
//          R900LIB_GetBatteryState() is for only engineering purpose.
//          The R900 must be linked to the host.
//
R900LIB_API BOOL R900LIB_GetBatteryMeter(UINT32 *value);
R900LIB_API BOOL R900LIB_GetBatteryState(UINT32 *value);
R900LIB_API BOOL R900LIB_RunBatteryMonitor(BOOL run);

//----------------------------------------------------
// function name : R900LIB_Beep
// function : turn buzzer sound on or off.
// parameters :
//           on ; set to TRUE to start buzzer sound or FALSE to stop buzzer sound.
// return : returns TRUE on success, FALSE on failure
// remark : the buzzer volume depends on the current setting.
//          This setting is defaulted after power cycle.
//          The R900 must be linked to the host.
//
R900LIB_API BOOL R900LIB_Beep(BOOL on);

//----------------------------------------------------
// function name : R900LIB_ReaderOff
// function : turn R900 off.
// parameters : none
// return : returns TRUE on success, FALSE on failure
// remark : After R900 off, link is released and all settings are vanished.
//          The R900 must be linked to the host.
//
R900LIB_API BOOL R900LIB_ReaderOff();


