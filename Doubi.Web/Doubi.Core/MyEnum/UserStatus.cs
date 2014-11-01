using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubi.Core.MyEnum
{
   public enum UserStatus:int
    {
       /// <summary>
       /// 正常
       /// </summary>
       Normal=10,
       /// <summary>
       /// 冻结，锁定
       /// </summary>
       Frozen=20,
       /// <summary>
       /// 非法
       /// </summary>
       Illegal=30
    }
}
