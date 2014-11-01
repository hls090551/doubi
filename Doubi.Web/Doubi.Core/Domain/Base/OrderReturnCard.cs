using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class OrderReturnCard
    
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
			public int Pcid
			{
				get;
				set;
			}
			public string Cardsn
			{
				get;
				set;
			}
			public string Cardpwd
			{
				get;
				set;
			}
			public string Salt
			{
				get;
				set;
			}
			public DateTime Createtime
			{
				get;
				set;
			}
			public string Cardfrom
			{
				get;
				set;
			}
			public int Fromid
			{
				get;
				set;
			}
	}
}
