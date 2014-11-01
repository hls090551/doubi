using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class Order
    
	{	
			public int Id
			{
				get;
				set;
			}
			public int Userid
			{
				get;
				set;
			}
			public decimal Ordertotal
			{
				get;
				set;
			}
			public string Goodname
			{
				get;
				set;
			}
			public short Type
			{
				get;
				set;
			}
			public short Status
			{
				get;
				set;
			}
			public bool Needshipping
			{
				get;
				set;
			}
			public long Orderno
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
