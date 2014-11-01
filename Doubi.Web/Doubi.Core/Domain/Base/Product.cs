using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class Product
    
	{	
			public int Id
			{
				get;
				set;
			}
			public string Pname
			{
				get;
				set;
			}
			public decimal Price
			{
				get;
				set;
			}
			public decimal Vip_price
			{
				get;
				set;
			}
			public int Inventory
			{
				get;
				set;
			}
			public bool Need_kucun
			{
				get;
				set;
			}
			public bool Need_deliver
			{
				get;
				set;
			}
			public short Type
			{
				get;
				set;
			}
			public bool Isonsale
			{
				get;
				set;
			}
			public string Pcode
			{
				get;
				set;
			}
			public int Weight
			{
				get;
				set;
			}
			public DateTime Addtime
			{
				get;
				set;
			}
			public string Pinyin
			{
				get;
				set;
			}
			public string Flpinyin
			{
				get;
				set;
			}
	}
}
