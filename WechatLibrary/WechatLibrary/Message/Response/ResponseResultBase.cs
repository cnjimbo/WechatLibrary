using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Message.Response
{
    /// <summary>
    /// 回复消息基类。
    /// </summary>
    public abstract class ResponseResultBase
    {
        /// <summary>
        /// 接收方帐号（收到的 OpenID）。
        /// </summary>
        public string ToUserName
        {
            get;
            set;
        }

        /// <summary>
        /// 消息创建时间（整型）。
        /// </summary>
        public int CreateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 消息类型。
        /// </summary>
        public string MsgType
        {
            get;
            set;
        }
    }
}
