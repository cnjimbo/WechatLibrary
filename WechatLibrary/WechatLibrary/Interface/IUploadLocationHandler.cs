using WechatLibrary.Request;
using WechatLibrary.Response;

namespace WechatLibrary.Interface
{
    /// <summary>
    /// 上报地理位置事件处理接口。
    /// </summary>
    public interface IUploadLocationHandler
    {
        /// <summary>
        /// 处理上报地理位置事件。
        /// </summary>
        /// <param name="message">上报地理位置事件。</param>
        /// <param name="dbProcess">是否由数据库默认处理。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(UploadLocationMessage message, ref bool dbProcess);
    }
}
