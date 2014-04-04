using System.Xml.Linq;

namespace WechatLibrary
{
    internal partial class Route
    {
        /// <summary>
        /// 从消息获取 MsgType。
        /// </summary>
        internal void GetMsgTypeFromXml()
        {
            XElement root = RequestXml.Root;
            if (root != null)
            {
                XElement msgTypeElement = root.Element("MsgType");
                if (msgTypeElement != null)
                {
                    RequestType = msgTypeElement.Value;
                }
            }
        }
    }
}
