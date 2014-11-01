using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Doubi.Core.Utilities
{
    public class IP
    {
        public static long ToLong(string addr)
        {
            byte[] bytes = IPAddress.Parse(addr).GetAddressBytes();
            return BitConverter.ToInt32(bytes, 0);
        }

        public static string ToAddr(long address)
        {
            return new IPAddress(BitConverter.GetBytes(address)).ToString();
        }

        //字符串转换为数字 
        public static long MyToLong(string addr)
        {
            try
            {
                System.Net.IPAddress ipaddress = System.Net.IPAddress.Parse(addr);
                long dreamduip = ipaddress.Address;
                return dreamduip;
            }
            catch (Exception)
            {

                return 0;
            }

        }
        //数字转换为字符串  
        public static string MyToAddr(long dreamduip)
        {
            System.Net.IPAddress ipaddress = System.Net.IPAddress.Parse(dreamduip.ToString());
            string strdreamduip = ipaddress.ToString();
            string ip = "";
            string[] ch = strdreamduip.Split('.');
            for (int i = ch.Length - 1; i >= 0; i--)
            {
                ip += ch[i] + ".";
            }
            ip = ip.Remove(ip.Length - 1);
            return ip;
        }
    }
}
