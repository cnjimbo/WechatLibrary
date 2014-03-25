using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Request
{
    /// <summary>
    /// 关注事件。
    /// </summary>
    public class SubscribeMessage : RequestMessageBase
    {
        /// <summary>
        /// 事件类型，subscribe(订阅)。
        /// </summary>
        public string Event
        {
            get;
            set;
        }
    }
}
