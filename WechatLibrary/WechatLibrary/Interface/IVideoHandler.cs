using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.Message.Request;
using WechatLibrary.Message.Response;

namespace WechatLibrary.Interface
{
    /// <summary>
    /// 视频消息处理接口。
    /// </summary>
    public interface IVideoHandler
    {
        /// <summary>
        /// 处理视频消息。
        /// </summary>
        /// <param name="message">视频消息。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(VideoMessage message);
    }
}
