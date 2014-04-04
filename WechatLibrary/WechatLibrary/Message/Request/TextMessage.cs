
namespace WechatLibrary.Request
{
    /// <summary>
    /// 文本消息。
    /// </summary>
    public class TextMessage : RequestMessageBase
    {
        /// <summary>
        /// 文本消息内容。
        /// </summary>
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// 消息 id，64 位整型。
        /// </summary>
        public long MsgId
        {
            get;
            set;
        }

        /// <summary>
        /// 创建一个 TextMessage 的新实例。
        /// </summary>
        public TextMessage()
        {
        }

        /// <summary>
        /// 以已有消息创建一个 TextMessage 的新实例。
        /// </summary>
        /// <param name="message">已有消息。</param>
        public TextMessage(RequestMessageBase message)
        {
            RequestMessageBase.CopyProperties(message, this);
        }
    }
}
