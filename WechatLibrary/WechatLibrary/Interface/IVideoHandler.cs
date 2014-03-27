using WechatLibrary.Request;
using WechatLibrary.Response;

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
        /// <param name="dbProcess">是否由数据库默认处理。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(VideoMessage message, ref bool dbProcess);
    }
}
