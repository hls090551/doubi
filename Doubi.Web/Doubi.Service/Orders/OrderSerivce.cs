using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doubi.Core.Domain;
using Doubi.Data.DAL;
using Doubi.Core.PagedList;
using FluentData;
using Doubi.Data;

namespace Doubi.Service.Orders
{
    public class OrderSerivce
    {
        private readonly OrderRepository<Order> _orderRep;
        private readonly OrderPaymentRepository<OrderPayment> _orderpaymentRep;
        private readonly OrderChargeRepository<OrderCharge> _orderchargeRep;

        public OrderSerivce()
        {
            _orderRep = new OrderRepository<Order>();
            _orderpaymentRep = new OrderPaymentRepository<OrderPayment>();
            _orderchargeRep = new OrderChargeRepository<OrderCharge>();
        }

        /// <summary>
        /// 获取用户订单
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="status"></param>
        /// <param name="stime"></param>
        /// <param name="etime"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public List<Order> UserOrders(int? userid, short? status, short? type, DateTime? stime, DateTime? etime, int page, int size)
        {
            if (page <= 0 || size <= 0)
            {
                return null;
            }
            return _orderRep.MultiQuery(page, size, userid, type, status, null, null, stime, etime, "id desc") as PagedList<Order>;
        }

        public Order GetOrderbyid(int orderid)
        {
            if (orderid <= 0)
            {
                return null;
            }
            return _orderRep.GetById(orderid);
        }

        public Order GetOrderbyorderno(long orderno)
        {
            if (orderno <= 0)
            {
                return null;
            }
            return _orderRep.GetbyOrderno(orderno);
        }

        /// <summary>
        /// 添加订单和订单支付信息
        /// </summary>
        /// <param name="order"></param>
        /// <param name="payments"></param>
        /// <returns></returns>
        public bool AddOrderinfo(Order order, List<OrderPayment> payments, IDbContext context)
        {
            if (order == null || payments == null || payments.Count <= 0)
            {
                throw new ArgumentException("AddOrderinfo args error!");
            }
            //判断支付金额与订单金额
            decimal totalpay = 0;
            foreach (var op in payments)
            {
                totalpay += op.Amount;
            }
            if (order.Ordertotal != totalpay)
            {
                //log
                return false;
            }
            try
            {
                using (context = DBSettings.TransactionContext())
                {
                    bool r1 = _orderRep.InsertWithTransaction(order, context);
                    foreach (var op in payments)
                    {
                        op.Orderid = order.Id;
                        _orderpaymentRep.InsertWithTransaction(op, context);
                    }
                    if (r1)
                    {
                        context.Commit();
                        return true;
                    }
                    else
                    {
                        context.Rollback();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                //log
                return false;
            }           
        }

        /// <summary>
        /// 添加充值信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool AddOrderCharge(OrderCharge entity,IDbContext context)
        {
            if (entity == null||entity.Chargeamount<=0)
            {
                throw new ArgumentException("AddOrderCharge args error!");
            }
            return _orderchargeRep.InsertWithTransaction(entity, context);
        }
    }
}
