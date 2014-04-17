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
                xml = "<xml><ToUserName><![CDATA[toUser]]></ToUserName><FromUserName><![CDATA[FromUser]]></FromUserName><CreateTime>123456789</CreateTime><MsgType><![CDATA[event]]></MsgType><Event><![CDATA[CLICK]]></Event><EventKey><![CDATA[testkey]]></EventKey></xml>";
#endif

                RequestXml = XDocument.Parse(xml);
            }
        }
    }
}
