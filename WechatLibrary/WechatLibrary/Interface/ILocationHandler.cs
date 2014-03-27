using WechatLibrary.Request;
using WechatLibrary.Response;

namespace WechatLibrary.Interface
{
    /// <summary>
    /// 地理位置消息处理接口。
    /// </summary>
    public interface ILocationHandler
    {
        /// <summary>
        /// 处理地理位置消息。
        /// </summary>
        /// <param name="message">地理位置消息。</param>
        /// <param name="dbProcess">是否由数据库默认处理。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(LocationMessage message, ref bool dbProcess);
    }
}
