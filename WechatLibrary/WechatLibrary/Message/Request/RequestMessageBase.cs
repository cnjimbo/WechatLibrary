using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WechatLibrary.Request
{
    /// <summary>
    /// 接收消息基类。
    /// </summary>
    public abstract class RequestMessageBase
    {
        /// <summary>
        /// 开发者微信号。
        /// </summary>
        public string ToUserName
        {
            get;
            set;
        }

        /// <summary>
        /// 发送方帐号（一个 OpenID）。
        /// </summary>
        public string FromUserName
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

        /// <summary>
        /// 创建一个 RequestMessageBase 的新实例。
        /// </summary>
        public RequestMessageBase()
        {
        }

        /// <summary>
        /// 以已有消息创建一个 RequestMessageBase 的新实例。
        /// </summary>
        /// <param name="message">已有消息。</param>
        public RequestMessageBase(RequestMessageBase message)
        {
            CopyProperties(message, this);
        }

        internal static void CopyProperties(RequestMessageBase source, RequestMessageBase target)
        {
            Type sourceType = source.GetType();
            Type targetType = target.GetType();
            foreach (PropertyInfo property in targetType.GetProperties())
            {
                if (property.CanWrite == true)
                {
                    var sourceProperty = sourceType.GetProperty(property.Name);
                    if (sourceProperty != null)
                    {
                        if (sourceProperty.GetValue(source, null) != null)
                        {
                            property.SetValue(target, sourceProperty.GetValue(source, null), null);
                        }
                    }
                }
            }
        }
    }
}
