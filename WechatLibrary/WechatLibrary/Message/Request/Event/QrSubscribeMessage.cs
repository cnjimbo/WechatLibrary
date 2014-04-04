
namespace WechatLibrary.Request
{
    /// <summary>
    /// 扫描二维码关注事件。
    /// </summary>
    public class QRSubscribeMessage : RequestMessageBase
    {
        /// <summary>
        /// 事件类型，subscribe。
        /// </summary>
        public string Event
        {
            get;
            set;
        }

        /// <summary>
        /// 事件 KEY 值，qrscene_ 为前缀，后面为二维码的参数值。
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
        /// 创建一个 QRSubscribeMessage 的新实例。
        /// </summary>
        public QRSubscribeMessage()
        {
        }

        /// <summary>
        /// 以已有消息创建一个 QRSubscribeMessage 的新实例。
        /// </summary>
        /// <param name="message">已有消息。</param>
        public QRSubscribeMessage(RequestMessageBase message)
        {
            RequestMessageBase.CopyProperties(message, this);
        }
    }
}
