using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubi.Core.Utilities
{
    public class AppConfig
    {
        public const string INVENTORY_WARNING_NUM = "inventory_warning_num";
        public const string INVENTORY_WARNING_SEND_MAIL = "inventory_send_mail";
        public const string INVENTORY_WARNING_SEND_PHONE = "inventory_send_phone";
        public const string SALES_SPECIAL_OFFERS_GRANT_IP_DAY_MAX = "sales_special_offers_grant_ip_day_max";

        public static string GetValue(string appConfigName)
        {
            return GetValue(appConfigName, string.Empty);
        }

        public static int GetInt(string appConfigName, int def=0)
        {
            try
            {
                return Convert.ToInt32(GetValue(appConfigName));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return def;
            }
        }

        public static string GetValue(string appConfigName, string defStr)
        {
            try
            {
                return ConfigurationManager.AppSettings[appConfigName].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return defStr;
            }
        }

        public static int GetValue(string appConfigName, int defStr)
        {
            try
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings[appConfigName].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return defStr;
            }
        }
    }
}
