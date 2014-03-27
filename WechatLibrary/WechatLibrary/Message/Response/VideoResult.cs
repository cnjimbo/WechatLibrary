
namespace WechatLibrary.Response
{
    /// <summary>
    /// 回复视频消息。
    /// </summary>
    public class VideoResult:ResponseResultBase
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
        /// 视频消息的标题。
        /// </summary>
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 视频消息的描述。
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 创建一条回复视频消息。
        /// </summary>
        public VideoResult()
        {
            MsgType = "video";
        }

        internal override string Serialize()
        {
            return string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[{3}]]></MsgType><Video><MediaId><![CDATA[{4}]]></MediaId><Title><![CDATA[{5}]]></Title><Description><![CDATA[{6}]]></Description></Video> </xml>", ToUserName, FromUserName, CreateTime, MsgType, MediaId, Title, Description);
        }
    }
}
