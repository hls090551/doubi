using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class User
    
	{	
			public int Id
			{
				get;
				set;
			}
			public string Username
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
			public string Email
			{
				get;
				set;
			}
			public string Mobile
			{
				get;
				set;
			}
			public int Viplevel
			{
				get;
				set;
			}
			public bool Isonline
			{
				get;
				set;
			}
			public short Status
			{
				get;
				set;
			}
			public DateTime Createtime
			{
				get;
				set;
			}
			public DateTime Lastlogintime
			{
				get;
				set;
			}
			public int Recommanderid
			{
				get;
				set;
			}
	}
}
