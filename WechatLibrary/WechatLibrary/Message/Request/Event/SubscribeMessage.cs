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

        /// <summary>
        /// 创建一个 SubscribeMessage 的新实例。
        /// </summary>
        public SubscribeMessage()
        {
        }

        /// <summary>
        /// 以已有消息创建一个 SubscribeMessage 的新实例。
        /// </summary>
        /// <param name="message">已有消息。</param>
        public SubscribeMessage(RequestMessageBase message)
        {
            RequestMessageBase.CopyProperties(message, this);
        }
    }
}
