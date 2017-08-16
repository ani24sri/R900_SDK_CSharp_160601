
#ifndef H_UI_CTRL_H
#define H_UI_CTRL_H

#define UI_CTRL_REG_ADDR 0xFF01
#define UI_BATT_REG_ADDR 0xFF02
#define REPORT_MASK_REG_ADDR 0xFF03
#define UI_BUZZER_REG_ADDR 0xFF04 // han 2009.10.28
#define UI_AUTO_OFF_DELAY_ADDR  0xff05  // han 2010.3.5
// update UI_CTRL_REG_END to the last address
// when you add new register

#define UI_CTRL_REG_BEGIN   UI_CTRL_REG_ADDR
#define UI_CTRL_REG_END     UI_AUTO_OFF_DELAY_ADDR

/* hst_cmd_ext_reg bit assignment */
// host ctrl ,, request extended interface || reader indication
#define UI_REG_IF_EXT    0x00000001
// host ctrl ,, request remote operation || reader indication
#define UI_REG_REMOTE    0x00000002
// host ctrl ,, auto power up operation || reader indication
#define UI_REG_AUTO_PWR    0x00000004
// host ctrl ,, auto power up operation || reader indication
#define UI_REG_REPORT_BAT_STATE    0x00000008
// reader capability indication ,, has heart beat
#define UI_REG_HEART_BEAT   0x00000010
// reader indication ,, trigger switch pressed
#define UI_REG_TRIGGER   0x00000100
// reader indication ,, low battery detected
#define UI_REG_LOW_BAT   0x00001000
// reader indication ,, under alerting
#define UI_REG_AUDIBLE_ALERT  0x00002000
// reader indication ,, under alerting
#define UI_REG_AUDIBLE_NOTIFY  0x00004000
// reader indication ,, tx lamp on || host ctrl
#define UI_REG_LMP_TX    0x00008000
// reader indication ,, pwr lamp on || host ctrl
#define UI_REG_LMP_PWR   0x00010000
// reader indication ,, link lamp on || host ctrl
#define UI_REG_LMP_LINK  0x00020000
// reader indication ,, inventory lamp on || host ctrl
#define UI_REG_LMP_INV   0x00040000
// host ctrl ,, remote lamp control
#define UI_REG_SET_LAMP  0x00080000
// reader indication ,, beep on || host ctrl
#define UI_REG_BEEP      0x00100000
// host ctrl ,, remote beep control
#define UI_REG_SET_BEEP  0x00800000
// host ctrl || reader indication ,, power on
#define UI_REG_PWR       0x10000000 
// reader indication ,, ready
#define UI_REG_READY     0x20000000 
// reader indication ,, linked || host ctrl
#define UI_REG_LINK      0x40000000 
// host ctrl ,, set marked bits only
#define UI_REG_SET_BIT   0x80000000 
// host ctrl ,, reset marked bits only
#define UI_REG_CLR_BIT   0x00000000 

#define UI_REG_LAMPS (UI_REG_LMP_TX|UI_REG_LMP_INV|UI_REG_LMP_LINK|UI_REG_LMP_PWR)
#define UI_REG_BEEPS (UI_REG_BEEP)
#define UI_REG_HOST_CTRL (UI_REG_IF_EXT\
                          |UI_REG_SET_LAMP|UI_REG_LMP_TX|UI_REG_LMP_PWR|UI_REG_LMP_LINK|UI_REG_LMP_INV\
                          |UI_REG_SET_BEEP|UI_REG_BEEP\
                          |UI_REG_LINK)

#define TIME_INT_INTERVAL     5 // 5 msec

#define OEMCFGADDR_ADC_BAT_SCALE  (OEMCFGADDR_CUSTOMER_BASE+4) // 0x504
#define OEMCFGADDR_BAT_THRESH_1		(OEMCFGADDR_CUSTOMER_BASE+5) // 0x505
#define OEMCFGADDR_BAT_THRESH_2		(OEMCFGADDR_CUSTOMER_BASE+6) // 0x506
#define OEMCFGADDR_BAT_THRESH_3		(OEMCFGADDR_CUSTOMER_BASE+7) // 0x507
#define	OEMCFGADDR_BOOT_OPT				(OEMCFGADDR_CUSTOMER_BASE+8) // 0x508
#define OEMCFGADDR_TX_DUTY				(OEMCFGADDR_CUSTOMER_BASE+9) // 0x509
#define OEMCFGADDR_BUZZER_CTRL		(OEMCFGADDR_CUSTOMER_BASE+10) // 0x50a
#define OEMCFGADDR_BUZZER_VOLUME		(OEMCFGADDR_CUSTOMER_BASE+11) // 0x50b
#define OEMCFGADDR_AUTO_OFF_DELAY		(OEMCFGADDR_CUSTOMER_BASE+14) // 0x50e

#define OEMCFGADDR_BACKUP_STORAGE	OEMCFGADDR_LPROF12_MAC// use profile register as epc storage 0x12c0


#endif //H_UI_CTRL_H
