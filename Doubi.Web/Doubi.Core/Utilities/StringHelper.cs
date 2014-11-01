using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Doubi.Core.Utilities
{
    public static class StringHelper
    {
        #region BuildWjGameCardNum
        /// <summary>
        /// 构建 万集游戏一卡通卡号 16 位
        /// </summary>
        /// <param name="date">6 位日期：YYMMDD</param>
        /// <param name="area">4 位区域：(0)010</param>
        /// <param name="batch">2 位批次： (0)1</param>
        /// <param name="start">4 位开始卡号:(000)1</param>
        /// <param name="end">4 位结算卡号:(000)9</param>
        /// <returns></returns>
        public static SortedSet<string> BuildWjGameCardNum(string date, string area, int batch, int start, int end)
        {
            if (date == null || date.Length != 6)
                date = DateTime.Now.ToString("YYMMDD");
            if (area.Length != 4)
                area = ToStrInsertZero(area, 4);
            if (batch > 99)
                return null;
            if (start > 9999)
                return null;
            if (end > 9999 || end < start)
                return null;

            string batchStr = ToStrInsertZero(batch, 2);

            SortedSet<string> list = new SortedSet<string>();

            int len = 4;

            string basNum = date + area + batchStr;

            for (int i = start; i < end; i++)
            {
                list.Add(basNum + ToStrInsertZero(i, len));
            }

            return list;
        }

        /// <summary>
        /// 转换成指定长度的字符，不够前方补(0)
        /// </summary>
        /// <param name="ob"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string ToStrInsertZero(Object ob, int len)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ob);
            if (sb.Length != len)
            {
                for (int i = sb.Length; i < len; i++)
                {
                    sb.Insert(0, '0');
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 生成随机字母与数字或字符
        /// </summary>
        /// <param name="len">生成长度</param>
        /// <returns></returns>
        public static string RandomStr(int len, bool sleep = true)
        {
            if (sleep)
                System.Threading.Thread.Sleep(3); // 防止生成重复

            char[] Pattern = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string result = "";
            int n = Pattern.Length;
            System.Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < len; i++)
            {
                int rnd = random.Next(0, n);
                result += Pattern[rnd];
            }
            return result;
        }
        #endregion

        public static string Md5(string prestr,Encoding encoding)
        {
            StringBuilder sb = new StringBuilder(64);
            MD5 md5 = new MD5CryptoServiceProvider();
            Console.WriteLine("Source:\t" + prestr);
            byte[] t = md5.ComputeHash(encoding.GetBytes(prestr));
            //byte[] t = md5.ComputeHash(Encoding.UTF8.GetBytes(prestr));            
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            Console.WriteLine("Md5:\t"+sb);
            return sb.ToString();
        }
    }
}
