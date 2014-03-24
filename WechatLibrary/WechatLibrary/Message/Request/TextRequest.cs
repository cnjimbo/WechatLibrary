using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Message.Request
{
    /// <summary>
    /// 
    /// </summary>
    public class TextRequest : RequestBase
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
        /// 消息id，64位整型。
        /// </summary>
        public long MsgId
        {
            get;
            set;
        }
    }
}
