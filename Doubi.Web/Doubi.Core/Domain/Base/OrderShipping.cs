using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class OrderShipping
    
	{	
			public int Id
			{
				get;
				set;
			}
			public int Orderid
			{
				get;
				set;
			}
			public int Userid
			{
				get;
				set;
			}
			public short Shipping_status
			{
				get;
				set;
			}
			public string Consignee
			{
				get;
				set;
			}
			public string Mobile
			{
				get;
				set;
			}
			public int Province
			{
				get;
				set;
			}
			public int City
			{
				get;
				set;
			}
			public int Country
			{
				get;
				set;
			}
			public string Address
			{
				get;
				set;
			}
			public string Goods_name
			{
				get;
				set;
			}
			public int Shippingid
			{
				get;
				set;
			}
			public DateTime? Best_time
			{
				get;
				set;
			}
			public decimal Shippingfee
			{
				get;
				set;
			}
			public string Delivery_sn
			{
				get;
				set;
			}
			public DateTime Createtime
			{
				get;
				set;
			}
			public DateTime Updatetime
			{
				get;
				set;
			}
	}
}
