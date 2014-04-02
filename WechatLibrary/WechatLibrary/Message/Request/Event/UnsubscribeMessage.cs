using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Request
{
    /// <summary>
    /// 取消关注事件。
    /// </summary>
    public class UnsubscribeMessage : RequestMessageBase
    {
        /// <summary>
        /// 事件类型，unsubscribe(取消订阅)。
        /// </summary>
        public string Event
        {
            get;
            set;
        }

        public UnsubscribeMessage()
        {
        }

        public UnsubscribeMessage(RequestMessageBase message)
        {
            RequestMessageBase.CopyProperties(message, this);
        }
    }
}
