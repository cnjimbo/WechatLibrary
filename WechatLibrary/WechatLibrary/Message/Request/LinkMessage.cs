using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Request
{
    /// <summary>
    /// 链接消息。
    /// </summary>
    public class LinkMessage : RequestMessageBase
    {
        /// <summary>
        /// 消息标题。
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 消息描述。
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 消息链接。
        /// </summary>
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// 消息 Id，64 位整型。
        /// </summary>
        public long MsgId
        {
            get;
            set;
        }

        public LinkMessage()
        {
        }

        public LinkMessage(RequestMessageBase message)
        {
            RequestMessageBase.CopyProperties(message, this);
        }
    }
}
