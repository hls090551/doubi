using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class UserAccountLog
    
	{	
			public int Id
			{
				get;
				set;
			}
			public int Accountid
			{
				get;
				set;
			}
			public int Userid
			{
				get;
				set;
			}
			public decimal Amount
			{
				get;
				set;
			}
			public short Operatetype
			{
				get;
				set;
			}
			public long? Orderno
			{
				get;
				set;
			}
			public string Operatedesc
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
