using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class OrderProduct
    
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
			public int Pcid
			{
				get;
				set;
			}
			public int Quantity
			{
				get;
				set;
			}
			public short Type
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
