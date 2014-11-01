using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubi.Core.MyEnum
{
   public enum PaymentStatus:int
    {
       /// <summary>
       /// 待支付
       /// </summary>
       New=10,
       /// <summary>
       /// 处理中
       /// </summary>
       Pending=20,
       /// <summary>
       /// 支付完成
       /// </summary>
       Paid=30,
       /// <summary>
       /// 已退款
       /// </summary>
       Refurned=40
    }
}
