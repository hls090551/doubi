using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class PaymentCard
    
	{	
			public int Id
			{
				get;
				set;
			}
			public string Cardname
			{
				get;
				set;
			}
			public decimal Facevalue
			{
				get;
				set;
			}
			public decimal Rate
			{
				get;
				set;
			}
			public int Detailid
			{
				get;
				set;
			}
			public string Cardimg
			{
				get;
				set;
			}
			public int Position
			{
				get;
				set;
			}
			public short Cardtype
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
