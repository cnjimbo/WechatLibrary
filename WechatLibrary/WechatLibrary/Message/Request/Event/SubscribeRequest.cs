using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Message.Request.Event
{
    public class SubscribeRequest : RequestBase
    {
        /// <summary>
        /// 事件类型，subscribe(订阅)、unsubscribe(取消订阅)。
        /// </summary>
        public string Event
        {
            get;
            set;
        }
    }
}
