using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class OrderPaymentCard
    
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
			public int Pcardid
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
			public decimal Amount
			{
				get;
				set;
			}
			public bool Issubmit
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
