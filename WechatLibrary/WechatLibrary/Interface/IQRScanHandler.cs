using WechatLibrary.Request;
using WechatLibrary.Response;

namespace WechatLibrary.Interface
{
    /// <summary>
    /// 扫描带参数二维码事件处理接口。
    /// </summary>
    public interface IQRScanHandler
    {
        /// <summary>
        /// 处理带参数二维码事件。
        /// </summary>
        /// <param name="message">带参数二维码事件。</param>
        /// <param name="dbProcess">是否由数据库默认处理。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(QRScanMessage message, ref bool dbProcess);
    }
}
