using WechatLibrary.Request;
using WechatLibrary.Response;

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
        /// <param name="dbProcess">是否有数据库默认处理。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(VoiceMessage message, ref bool dbProcess);
    }
}
