using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class UserAccount
    
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
			public decimal Balance
			{
				get;
				set;
			}
			public string Paypassword
			{
				get;
				set;
			}
			public string Salt
			{
				get;
				set;
			}
	}
}
