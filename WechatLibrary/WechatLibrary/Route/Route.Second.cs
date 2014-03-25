using System.Xml.Linq;

namespace WechatLibrary
{
    internal partial class Route
    {
        /// <summary>
        /// 从消息获取 MsgType。
        /// </summary>
        /// <exception cref="System.NullReferenceException">消息格式错误。</exception>
        internal void Second()
        {
            XElement root = RequestXml.Root;
            XElement msgTypeElement = root.Element("MsgType");
            RequestType = msgTypeElement.Value;
        }
    }
}
