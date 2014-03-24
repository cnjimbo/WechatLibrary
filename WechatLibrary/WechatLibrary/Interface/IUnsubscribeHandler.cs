using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.Message.Request.Event;
using WechatLibrary.Message.Response;

namespace WechatLibrary.Interface
{
    /// <summary>
    /// 取消关注事件处理接口。
    /// </summary>
    public interface IUnsubscribeHandler
    {
        /// <summary>
        /// 处理取消关注事件。
        /// </summary>
        /// <param name="message">取消关注事件。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(UnsubscribeMessage message);
    }
}
