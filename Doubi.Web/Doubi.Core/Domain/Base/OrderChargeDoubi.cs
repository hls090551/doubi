using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class OrderChargeDoubi
    
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
			public int Useraccountid
			{
				get;
				set;
			}
			public decimal Chargeamount
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
