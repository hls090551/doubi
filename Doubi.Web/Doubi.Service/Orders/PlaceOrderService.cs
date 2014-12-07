using Doubi.Core.Domain;
using Doubi.Core.MyEnum;
using Doubi.Data;
using Doubi.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubi.Service.Orders
{
    public class PlaceOrderService
    {
        private readonly UserService _userservice;
        private readonly OrderSerivce _orderservice;

        public PlaceOrderService()
        {
            _userservice = new UserService();
            _orderservice = new OrderSerivce();
        }

        /// <summary>
        /// 构建支付项
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<OrderPayment> GenerateOrderpayments(PlaceOrderRequest request)
        {
            if (request == null)
            {
                throw new ArgumentException("GenerateOrderpayments args error!");
            }
            int userid = request.User.Id;
            var order = request.Order;
            List<OrderPayment> payments = new List<OrderPayment>();
            decimal usedbalance = 0;
            if (request.IsuseBalance)
            {
                UserAccount account = _userservice.GetUserAccount(userid);
                if (account == null)
                {
                    throw new ArgumentException("useraccount not exits");
                }
                usedbalance = account.Balance > order.Ordertotal ? order.Ordertotal : account.Balance;
                OrderPayment payment = new OrderPayment();
                payment.Amount = usedbalance;
                payment.Paymenttype = (short)PaymentType.Doubi;
                payment.Paymentstatus = (short)PaymentStatus.New;
                payment.Associateid = userid;
                payment.Createtime = DateTime.Now;
                payments.Add(payment);
            }
            if (order.Ordertotal - usedbalance > 0)
            {
                OrderPayment payment = new OrderPayment();
                payment.Amount = usedbalance;
                payment.Paymenttype = (short)PaymentType.OnlineBank;
                payment.Paymentstatus = (short)PaymentStatus.New;
                payment.Associateid = userid;
                payment.Createtime = DateTime.Now;
                payments.Add(payment);
            }
            return payments;
        }

        /// <summary>
        /// 用户逗币充值
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
        public PlaceOrderResult DoubiCharge(PlaceOrderRequest request)
        {
            var user = request.User;
            PlaceOrderResult result = new PlaceOrderResult();
            if (user == null || user.Id <= 0 || request.OrderCharge.Chargeamount <= 0)
            {
                result.AddError(-1, "参数错误");
                return result;
            }
            if (user.Status != (short)UserStatus.Normal)
            {
                result.AddError(-1, "用户被锁定");
                return result;
            }
            try
            {
                using (var context = DBSettings.TransactionContext())
                {
                    //order_order,order_payment
                    bool r1 = _orderservice.AddOrderinfo(request.Order, request.Orderpayments, context);
                    bool r2 = _orderservice.AddOrderCharge(request.OrderCharge, context);
                    if (r1 && r2)
                    {
                        context.Commit();
                        return result;
                    }
                    else
                    {
                        context.Rollback();
                        result.AddError(-1, "写入错误");
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                result.AddError(-1, "充值异常:" + ex.Message);
                return result;
            }
        }
    }
}
