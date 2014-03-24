using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.Message.Request;
using WechatLibrary.Message.Response;

namespace WechatLibrary.Interface
{
    /// <summary>
    /// 文本消息处理接口。
    /// </summary>
    public interface ITextHandler
    {
        /// <summary>
        /// 处理文本消息。
        /// </summary>
        /// <param name="message">文本消息。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(TextMessage message);
    }
}
