﻿
namespace WechatLibrary.Response
{
    /// <summary>
    /// 回复文本消息。
    /// </summary>
    public class TextResult : ResponseResultBase
    {
        /// <summary>
        /// 回复的消息内容（换行：在 content 中能够换行，微信客户端就支持换行显示）。
        /// </summary>
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// 创建一条回复文本消息。
        /// </summary>
        public TextResult()
        {
            MsgType = "text";
        }

        internal override string Serialize()
        {
            return string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[{3}]]></MsgType><Content><![CDATA[{4}]]></Content></xml>", ToUserName, FromUserName, CreateTime, MsgType, Content);
        }
    }
}
