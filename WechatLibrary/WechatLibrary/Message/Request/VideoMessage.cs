
namespace WechatLibrary.Request
{
    /// <summary>
    /// 视频消息。
    /// </summary>
    public class VideoMessage : RequestMessageBase
    {
        /// <summary>
        /// 视频消息媒体 id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId
        {
            get;
            set;
        }

        /// <summary>
        /// 视频消息缩略图的媒体 id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string ThumbMediaId
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
        /// 创建一个 VideoMessage 的新实例。
        /// </summary>
        public VideoMessage()
        {
        }

        /// <summary>
        /// 以已有消息创建一个 VideoMessage 的新实例。
        /// </summary>
        /// <param name="message">已有消息。</param>
        public VideoMessage(RequestMessageBase message)
        {
            RequestMessageBase.CopyProperties(message, this);
        }
    }
}
