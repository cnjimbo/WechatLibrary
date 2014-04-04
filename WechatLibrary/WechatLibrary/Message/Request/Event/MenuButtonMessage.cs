using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Request
{
    /// <summary>
    /// 自定义菜单事件。
    /// </summary>
    public class MenuButtonMessage : RequestMessageBase
    {
        /// <summary>
        /// 事件类型，CLICK 或 VIEW。
        /// </summary>
        public string Event
        {
            get;
            set;
        }

        /// <summary>
        /// 事件 KEY 值，与自定义菜单接口中 KEY 值对应或设置的跳转URL。
        /// </summary>
        public string EventKey
        {
            get;
            set;
        }

        /// <summary>
        /// 创建一个 MenuButtonMessage 的新实例。
        /// </summary>
        public MenuButtonMessage()
        {
        }

        /// <summary>
        /// 以已有消息创建一个 MenuButtonMessage 的新实例。
        /// </summary>
        /// <param name="message">已有消息。</param>
        public MenuButtonMessage(RequestMessageBase message)
        {
            RequestMessageBase.CopyProperties(message, this);
        }
    }
}
