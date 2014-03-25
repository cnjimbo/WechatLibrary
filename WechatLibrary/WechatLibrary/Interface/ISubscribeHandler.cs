using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.Request;
using WechatLibrary.Response;

namespace WechatLibrary.Interface
{
    /// <summary>
    /// 关注事件处理接口。
    /// </summary>
    public interface ISubscribeHandler
    {
        /// <summary>
        /// 处理关注事件。
        /// </summary>
        /// <param name="message">关注事件。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(SubscribeMessage message);
    }
}
