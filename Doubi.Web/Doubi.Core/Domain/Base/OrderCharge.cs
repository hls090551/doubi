using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class OrderCharge
    
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
			public string Account
			{
				get;
				set;
			}
			public decimal Chargeamount
			{
				get;
				set;
			}
			public short Type
			{
				get;
				set;
			}
			public decimal Saleprice
			{
				get;
				set;
			}
			public DateTime Createtime
			{
				get;
				set;
			}
	}
}
