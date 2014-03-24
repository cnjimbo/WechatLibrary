using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Message.Request.Event
{
    public class MenuButtonRequest : RequestBase
    {
        /// <summary>
        /// 事件类型，CLICK。
        /// </summary>
        public string Event
        {
            get;
            set;
        }

        /// <summary>
        /// 事件 KEY 值，与自定义菜单接口中 KEY 值对应。
        /// </summary>
        public string EventKey
        {
            get;
            set;
        }
    }
}
