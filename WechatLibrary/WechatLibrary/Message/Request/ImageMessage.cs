
namespace WechatLibrary.Request
{
    /// <summary>
    /// 图片消息。
    /// </summary>
    public class ImageMessage : RequestMessageBase
    {
        /// <summary>
        /// 图片链接。
        /// </summary>
        public string PicUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 图片消息媒体 id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId
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
        /// 创建一个 ImageMessage 的新实例。
        /// </summary>
        public ImageMessage()
        {
        }

        /// <summary>
        /// 以已有消息创建一个 ImageMessage 的新实例。
        /// </summary>
        /// <param name="message">已有消息。</param>
        public ImageMessage(RequestMessageBase message)
        {
            RequestMessageBase.CopyProperties(message, this);
        }
    }
}
