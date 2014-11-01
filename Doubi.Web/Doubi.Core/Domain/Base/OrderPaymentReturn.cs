using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class OrderPaymentReturn
    
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
			public int Opayid
			{
				get;
				set;
			}
			public string Paystatus
			{
				get;
				set;
			}
			public string Errorcode
			{
				get;
				set;
			}
			public string Errormsg
			{
				get;
				set;
			}
			public string Otherinfo
			{
				get;
				set;
			}
			public string Payname
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
