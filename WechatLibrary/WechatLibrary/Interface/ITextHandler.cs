using WechatLibrary.Request;
using WechatLibrary.Response;

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
        /// <param name="dbProcess">是否由数据库默认处理。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(TextMessage message, ref bool dbProcess);
    }
}
