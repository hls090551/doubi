using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class UserMessage
    
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
			public string Content
			{
				get;
				set;
			}
			public short Type
			{
				get;
				set;
			}
			public bool Isread
			{
				get;
				set;
			}
			public DateTime Createtime
			{
				get;
				set;
			}
			public string Fromusername
			{
				get;
				set;
			}
	}
}
