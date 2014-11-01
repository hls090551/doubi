using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class Level
    
	{	
			public int Id
			{
				get;
				set;
			}
			public int Viplevel
			{
				get;
				set;
			}
			public decimal Order_discount
			{
				get;
				set;
			}
			public string Desc
			{
				get;
				set;
			}
	}
}
