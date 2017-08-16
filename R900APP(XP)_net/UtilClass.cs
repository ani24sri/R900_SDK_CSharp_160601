using System;
using System.Collections.Generic;
using System.Text;

namespace R900APP_net
{
    class UtilClass
    {
        public static bool HEX32(out UInt32 number, string hexastr)
        {
            number = 0;
            string str = hexastr.ToLower();
            for (int i = 0; i < hexastr.Length; i++)
            {
                number <<= 4;
                if ((str[i] >= '0') && (str[i] <= '9'))
                {
                    number += (UInt32)(str[i] - '0');
                }
                else if ((str[i] >= 'a') && (str[i] <= 'f'))
                {
                    number += (UInt32)(str[i] - 'a' + 10);
                }
                else
                    return false;
            }
            return true;
        }

        public static bool HEXSTR(out ushort[] buff, string hexastr)
        {
            string str = hexastr.ToLower();
            string str4;

            buff = new ushort[(hexastr.Length + 3) / 4];
            for (int i = 0; i < hexastr.Length; )
            {
                UInt32 val;
                buff[i / 4] = 0;
                str4 = str.Substring(i, 4);
                if (!HEX32(out val, str4))
                {
                    return false;
                }
                buff[i / 4] = (ushort)val;
                i += 4;
            }
            return true;
        }

        public static bool BitCount(out uint number, string hexastr)
        {
            int getline = hexastr.Length;
            number = (uint)getline * 4;
            return true;
        }

        public static bool HexStrToByteArray(out byte[] buff, string hexastr)
        {
            string str = hexastr.ToLower();
            int joo = (hexastr.Length) % 2;
            string temp;
            string n = "0";
            if (joo == 1)
            {

                hexastr = hexastr + n;
                str = hexastr.ToLower();

            }

            buff = new byte[hexastr.Length / 2];

            for (int i = 0; i < hexastr.Length; )
            {
                UInt32 val;
                temp = str.Substring(i, 2);
                if (!HEX32(out val, temp))
                {
                    return false;
                }
                buff[i / 2] = (byte)val;
                i += 2;
            }
            return true;

        }

        public static byte[] StrToByteArray(string sStr)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(sStr);
        }
    }
}
