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
        internal void First()
        {
            using (StreamReader sr = new StreamReader(this.HttpContext.Request.InputStream))
            {
                string xml = sr.ReadToEnd();
#if DEBUG
                RequestXml = XDocument.Parse("<xml><ToUserName><![CDATA[toUser]]></ToUserName><FromUserName><![CDATA[fromUser]]></FromUserName><CreateTime>12345678</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[你好]]></Content></xml>");
#else 
                RequestXml = XDocument.Parse(xml);
#endif
            }
        }
    }
}
