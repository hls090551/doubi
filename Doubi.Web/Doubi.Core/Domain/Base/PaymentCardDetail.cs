using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class PaymentCardDetail
    
	{	
			public int Id
			{
				get;
				set;
			}
			public short Cardnolength
			{
				get;
				set;
			}
			public short Cardnopwd
			{
				get;
				set;
			}
			public string Cardname
			{
				get;
				set;
			}
			public string Extrano
			{
				get;
				set;
			}
			public string Extraid
			{
				get;
				set;
			}
	}
}
