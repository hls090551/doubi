using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class SiteAdmin
    
	{	
			public int Id
			{
				get;
				set;
			}
			public int Roleid
			{
				get;
				set;
			}
			public string Adminname
			{
				get;
				set;
			}
			public string Password
			{
				get;
				set;
			}
			public string Salt
			{
				get;
				set;
			}
			public int Groupid
			{
				get;
				set;
			}
			public string Mobile
			{
				get;
				set;
			}
			public DateTime Addtime
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
