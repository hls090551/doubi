using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class OrderPayment
    
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
			public decimal Amount
			{
				get;
				set;
			}
			public short Paymenttype
			{
				get;
				set;
			}
			public short Paymentstatus
			{
				get;
				set;
			}
			public int Associateid
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
