using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class Payment
    
	{	
			public int Id
			{
				get;
				set;
			}
			public string Paycode
			{
				get;
				set;
			}
			public string Payname
			{
				get;
				set;
			}
			public short Position
			{
				get;
				set;
			}
			public bool Enable
			{
				get;
				set;
			}
	}
}
