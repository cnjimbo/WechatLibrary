
namespace WechatLibrary.Response
{
    /// <summary>
    /// 回复语音消息。
    /// </summary>
    public class VoiceResult : ResponseResultBase
    {
        /// <summary>
        /// 通过上传多媒体文件，得到的 id。
        /// </summary>
        public string MediaId
        {
            get;
            set;
        }

        /// <summary>
        /// 创建一条回复语音消息。
        /// </summary>
        public VoiceResult()
        {
            MsgType = "voice";
        }

        internal override string Serialize()
        {
            return string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[{3}]]></MsgType><Voice><MediaId><![CDATA[{4}]]></MediaId></Voice></xml>", ToUserName, FromUserName, CreateTime, MsgType, MediaId);
        }
    }
}
