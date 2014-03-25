using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(QRScanMessage message);
    }
}
