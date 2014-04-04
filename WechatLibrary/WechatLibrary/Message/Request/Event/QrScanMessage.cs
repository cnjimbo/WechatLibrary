
namespace WechatLibrary.Request
{
    /// <summary>
    /// 扫描带参数二维码事件。
    /// </summary>
    public class QRScanMessage : RequestMessageBase
    {
        /// <summary>
        /// 事件类型，SCAN。
        /// </summary>
        public string Event
        {
            get;
            set;
        }

        /// <summary>
        /// 事件 KEY 值，是一个 32 位无符号整数，即创建二维码时的二维码scene_id。
        /// </summary>
        public string EventKey
        {
            get;
            set;
        }

        /// <summary>
        /// 二维码的 ticket，可用来换取二维码图片。
        /// </summary>
        public string Ticket
        {
            get;
            set;
        }

        /// <summary>
        /// 创建一个 QRScanMessage 的新实例。
        /// </summary>
        public QRScanMessage()
        {
        }

        /// <summary>
        /// 以已有消息创建一个 QRScanMessage 的新实例。
        /// </summary>
        /// <param name="message">已有消息。</param>
        public QRScanMessage(RequestMessageBase message)
        {
            RequestMessageBase.CopyProperties(message, this);
        }
    }
}
