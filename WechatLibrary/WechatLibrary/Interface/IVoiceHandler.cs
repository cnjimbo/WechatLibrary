using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.Message.Request;
using WechatLibrary.Message.Response;

namespace WechatLibrary.Interface
{
    /// <summary>
    /// 语音消息处理接口。
    /// </summary>
    public interface IVoiceHandler
    {
        /// <summary>
        /// 处理语音消息。
        /// </summary>
        /// <param name="message">语音消息。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(VoiceMessage message);
    }
}
