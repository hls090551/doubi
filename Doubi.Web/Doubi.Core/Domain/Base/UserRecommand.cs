using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class UserRecommand
    
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
			public int Reco_userid
			{
				get;
				set;
			}
			public decimal Totalcontribute
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
