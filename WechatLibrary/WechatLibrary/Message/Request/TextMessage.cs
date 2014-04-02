using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Request
{
    /// <summary>
    /// 文本消息。
    /// </summary>
    public class TextMessage : RequestMessageBase
    {
        /// <summary>
        /// 文本消息内容。
        /// </summary>
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// 消息 id，64 位整型。
        /// </summary>
        public long MsgId
        {
            get;
            set;
        }

        public TextMessage()
        {
        }

        public TextMessage(RequestMessageBase message)
        {
            RequestMessageBase.CopyProperties(message, this);
        }
    }
}
