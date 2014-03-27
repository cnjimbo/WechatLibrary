using WechatLibrary.Request;
using WechatLibrary.Response;

namespace WechatLibrary.Interface
{
    /// <summary>
    /// 图片消息处理接口。
    /// </summary>
    public interface IImageHandler
    {
        /// <summary>
        /// 处理图片消息。
        /// </summary>
        /// <param name="message">图片消息。</param>
        /// <param name="dbProcess">是否由数据库默认处理。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(ImageMessage message, ref bool dbProcess);
    }
}
