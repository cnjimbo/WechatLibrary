using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.Message.Request.Event;
using WechatLibrary.Message.Response;

namespace WechatLibrary.Interface
{
    /// <summary>
    /// 自定义菜单事件处理接口。
    /// </summary>
    public interface IMenuButtonHandler
    {
        /// <summary>
        /// 处理自定义菜单事件。
        /// </summary>
        /// <param name="message">自定义菜单事件。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(MenuButtonMessage message);
    }
}
