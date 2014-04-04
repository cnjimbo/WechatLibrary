
namespace WechatLibrary.Request
{
    /// <summary>
    /// 语音消息。
    /// </summary>
    public class VoiceMessage : RequestMessageBase
    {
        /// <summary>
        /// 语音消息媒体 id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId
        {
            get;
            set;
        }

        /// <summary>
        /// 语音消息，如 amr，speex 等。
        /// </summary>
        public string Format
        {
            get;
            set;
        }

        /// <summary>
        /// 语音识别结果，UTF8 编码。
        /// </summary>
        public string Recognition
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
        /// 创建一个 VoiceMessage 的新实例。
        /// </summary>
        public VoiceMessage()
        {
        }

        /// <summary>
        /// 以已有消息创建一个 VoiceMessage 的新实例。
        /// </summary>
        /// <param name="message">已有消息。</param>
        public VoiceMessage(RequestMessageBase message)
        {
            RequestMessageBase.CopyProperties(message, this);
        }
    }
}
