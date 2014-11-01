using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class ShoppingCart
    
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
			public int Pcid
			{
				get;
				set;
			}
			public string Goodsname
			{
				get;
				set;
			}
			public int Quantity
			{
				get;
				set;
			}
			public int Weigth
			{
				get;
				set;
			}
			public decimal Price
			{
				get;
				set;
			}
			public bool Needshipping
			{
				get;
				set;
			}
			public DateTime Addtime
			{
				get;
				set;
			}
	}
}
