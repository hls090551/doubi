using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubi.Core.MyEnum
{
    public enum OrderStatus : int
    {
        /// <summary>
        /// 新订单 未支付
        /// </summary>
        New = 10,
        /// <summary>
        /// 处理过程中
        /// </summary>
        Processing = 15,
        /// <summary>
        /// 已支付 未发货
        /// </summary>
        Paid = 20,
        /// <summary>
        /// 部分支付
        /// </summary>
        PartialPaid = 25,
        /// <summary>
        /// 已发货成功
        /// </summary>
        Success = 30,
        /// <summary>
        /// 用户取消
        /// </summary>
        Cancelled = 40,
        /// <summary>
        /// 订单退回
        /// </summary>
        Refunded = 45,
        /// <summary>
        /// 系统关闭 非正常结束
        /// </summary>
        Closed = 50
    }


    public struct OrderChargeStr
    {
        static Dictionary<OrderStatus, string> dic = new Dictionary<OrderStatus, string>();
        static OrderChargeStr()
        {
            dic.Add(OrderStatus.New, "未支付");
            dic.Add(OrderStatus.Paid, "支付完成，等待发货");
            dic.Add(OrderStatus.PartialPaid, "部分支付，等待继续支付");
            dic.Add(OrderStatus.Success, "交易成功");
            dic.Add(OrderStatus.Cancelled, "系统关闭");
            dic.Add(OrderStatus.Refunded, "订单已退款");
        }

        public static string GetVal(OrderStatus status)
        {
            return dic[status];
        }
    }
}
