
//uhfapi_def.h

#pragma once

typedef INT64 tag_t;
typedef unsigned __int16    INT16U;
typedef unsigned __int32    INT32U;
typedef unsigned __int32 RFID_RADIO_HANDLE;
typedef UINT32  RFID_18K6C_MEMORY_BANK;
typedef UINT32 RFID_RESPONSE_MODE;


typedef struct {
	WORD handle;
	BYTE *id;
	WORD len;
	int count;
	WORD wb_rssi;
	WORD nb_rssi;
	WORD lna_gain;
	float rssidb;
	tag_t first_time;
	tag_t last_time;
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
	OR_END_CMD, // han 2009.10.28
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
	OR_CUSTOM_ACCESS_RESPONSE, // han 2011.7.19
} typeOpResult;


typedef enum {
    RFID_18K6C_TARGET_ENUM_S0 = 0,
    RFID_18K6C_TARGET_ENUM_S1 = 1,
    RFID_18K6C_TARGET_ENUM_S2 = 2,
    RFID_18K6C_TARGET_ENUM_S3 = 3,
    RFID_18K6C_TARGET_ENUM_SELECTED = 4
} RFID_18K6C_TARGET_ENUM;

typedef enum {
    /* Match ?Assert SL or inventoried -> A       */
    /* Non-Match ?Deassert SL or inventoried -> B */
    RFID_18K6C_ACTION_ENUM_ASLINVA_DSLINVB = 0,
    /* Match ?Assert SL or inventoried -> A       */
    /* Non-Match ?Nothing                         */
    RFID_18K6C_ACTION_ENUM_ASLINVA_NOTHING = 1,
    /* Match ?Nothing                             */
    /* Non-Match ?Deassert SL or inventoried -> B */
    RFID_18K6C_ACTION_ENUM_NOTHING_DSLINVB = 2, 
    /* Match ?Negate SL or (A -> B, B -> A)       */
    /* Non-Match ?Nothing                         */
    RFID_18K6C_ACTION_ENUM_NSLINVS_NOTHING = 3,
    /* Match ?Deassert SL or inventoried -> B     */
    /* Non-Match ?Assert SL or inventoried -> A   */
    RFID_18K6C_ACTION_ENUM_DSLINVB_ASLINVA = 4,
    /* Match - Deassert SL or inventoried -> B     */
    /* Non-Match - Nothing                         */
    RFID_18K6C_ACTION_ENUM_DSLINVB_NOTHING = 5,
    /* Match ?Nothing                             */
    /* Non-Match ?Assert SL or inventoried -> A   */
    RFID_18K6C_ACTION_ENUM_NOTHING_ASLINVA = 6,
    /* Match ?Nothing                             */
    /* Non-Match ?Negate SL or (A -> B, B -> A)   */
    RFID_18K6C_ACTION_ENUM_NOTHING_NSLINVS = 7
} RFID_18K6C_ACTION_ENUM;


