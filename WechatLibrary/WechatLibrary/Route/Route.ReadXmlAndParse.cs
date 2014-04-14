using System.IO;
using System.Xml.Linq;

namespace WechatLibrary
{
    internal partial class Route
    {
        /// <summary>
        /// 从 Http 请求中读取消息 xml。
        /// </summary>
        /// <exception cref="System.Xml.XmlException">接收的消息 xml 格式错误时。</exception>
        internal void ReadXmlAndParse()
        {
            using (StreamReader sr = new StreamReader(this.HttpContext.Request.InputStream))
            {
                string xml = sr.ReadToEnd();

#if DEBUG
                xml = "<xml><ToUserName><![CDATA[toUser]]></ToUserName><FromUserName><![CDATA[fromUser]]></FromUserName><CreateTime>1348831860</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[this is a test]]></Content><MsgId>1234567890123456</MsgId></xml>";
#endif

                RequestXml = XDocument.Parse(xml);
            }
        }
    }
}
