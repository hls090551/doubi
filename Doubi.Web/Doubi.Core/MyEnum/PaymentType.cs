using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubi.Core.MyEnum
{
   public enum PaymentType:int
    {
       /// <summary>
       /// 网银
       /// </summary>
       OnlineBank=10,
       /// <summary>
       /// 支付宝
       /// </summary>
       ZhiFuBao=20,
       /// <summary>
       /// 逗币
       /// </summary>
       Doubi=30,
       /// <summary>
       /// 翼支付
       /// </summary>
       Yizhifu=40,
       /// <summary>
       /// 19pay
       /// </summary>
       NineteenPay
    }
}
