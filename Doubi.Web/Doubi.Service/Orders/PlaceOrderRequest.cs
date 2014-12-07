using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doubi.Core.Domain;
using Doubi.Data;
using Doubi.Core.MyEnum;

namespace Doubi.Service.Orders
{
    public class PlaceOrderRequest
    {
        public Order Order { get; set; }
        public List<OrderPayment> Orderpayments { get; set; }
        public User User { get; set; }

        //充值        
        public OrderCharge OrderCharge { get; set; }
        //购卡


        //支付信息
        public bool IsuseBalance { get; set; }
    }
}
