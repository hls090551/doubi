using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubi.Core.MyEnum
{
   public enum MessageType:int
    {
       /// <summary>
       /// 领取逗币
       /// </summary>
       ReceiveDoubi=10,
       /// <summary>
       /// 订单信息
       /// </summary>
       OrderInfo=20,
       /// <summary>
       /// 好友信息
       /// </summary>
       FriendInfo=30
    }
}
