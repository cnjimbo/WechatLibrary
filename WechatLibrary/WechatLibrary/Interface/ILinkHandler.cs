using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.Request;
using WechatLibrary.Response;

namespace WechatLibrary.Interface
{
    /// <summary>
    /// 链接消息处理接口。
    /// </summary>
    public interface ILinkHandler
    {
        /// <summary>
        /// 处理链接消息。
        /// </summary>
        /// <param name="message">链接消息。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(LinkMessage message);
    }
}
