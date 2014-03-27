using WechatLibrary.Request;
using WechatLibrary.Response;

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
        /// <param name="dbProcess">是否由数据库默认处理。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(UnsubscribeMessage message, ref bool dbProcess);
    }
}
