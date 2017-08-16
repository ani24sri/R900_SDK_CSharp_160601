
//uhfapi_def.h

#pragma once

typedef struct {
	WORD handle;
	BYTE *id;
	WORD len;
	int count;
	WORD wb_rssi;
	WORD nb_rssi;
	WORD lna_gain;
	DWORD first_time;
	DWORD last_time;
} typeInventoried;


typedef enum {
	OR_INVENTORY_RESULT,
	OR_INVENTORY_DONE,
	OR_ACCESS_RESULT,
	OR_ACCESS_DONE,
	OR_INVENTORIED,
	OR_READ_DATA,
	OR_ACCESS_EPC,
	OR_SELECT_DONE, // han 2008.11.20
	OR_BEGIN_CMD, // han 2008.11.21
	OR_TX_ON,
	OR_TX_OFF,
	OR_EASALARM,
	OR_EASALARM_RESULT, // han 2008.4.19
	OR_SYSINFO,			// han 2008.5.4
	OR_MACINFO,		// han 2008.9.26
	OR_LOCK_BITS,  // han 2008.11.7
	OR_DIAG,
	OR_PROPRIETARY,
	OR_PROPRIETARY_DONE,
} typeOpResult;

