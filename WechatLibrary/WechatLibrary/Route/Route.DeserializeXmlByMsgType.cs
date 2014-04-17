using WechatLibrary.Request;
using WechatLibrary.Tools;

namespace WechatLibrary
{
    internal partial class Route
    {
        /// <summary>
        /// 根据 MsgType 反序列化消息 xml 到相应的消息实体。
        /// </summary>
        internal void DeserializeXmlByMsgType()
        {
            RequestType = RequestType ?? string.Empty;
            switch (RequestType.ToLower())
            {
                case "text":
                    {
                        Request = RequestXmlConverter.Deserialize<TextMessage>(RequestXml);
                        break;
                    }
                case "image":
                    {
                        Request = RequestXmlConverter.Deserialize<ImageMessage>(RequestXml);
                        break;
                    }
                case "voice":
                    {
                        Request = RequestXmlConverter.Deserialize<VoiceMessage>(RequestXml);
                        break;
                    }
                case "video":
                    {
                        Request = RequestXmlConverter.Deserialize<VideoMessage>(RequestXml);
                        break;
                    }
                case "location":
                    {
                        Request = RequestXmlConverter.Deserialize<LocationMessage>(RequestXml);
                        break;
                    }
                case "link":
                    {
                        Request = RequestXmlConverter.Deserialize<LinkMessage>(RequestXml);
                        break;
                    }
                case "event":
                    {
                        var root = RequestXml.Root;
                        if (root != null)
                        {
                            var eventTypeElement = root.Element("Event");
                            if (eventTypeElement != null)
                            {
                                EventType = eventTypeElement.Value;
                                switch (EventType.ToLower())
                                {
                                    case "subscribe":
                                        {
                                            var eventKey = root.Element("EventKey");
                                            if (eventKey == null || string.IsNullOrWhiteSpace(eventKey.Value) == true)
                                            {
                                                Request = RequestXmlConverter.Deserialize<SubscribeMessage>(RequestXml);
                                            }
                                            else
                                            {
                                                Request = RequestXmlConverter.Deserialize<QRSubscribeMessage>(RequestXml);
                                            }
                                            break;
                                        }
                                    case "unsubscribe":
                                        {
                                            Request = RequestXmlConverter.Deserialize<UnsubscribeMessage>(RequestXml);
                                            break;
                                        }
                                    case "scan":
                                        {
                                            Request = RequestXmlConverter.Deserialize<QRScanMessage>(RequestXml);
                                            break;
                                        }
                                    case "location":
                                        {
                                            Request = RequestXmlConverter.Deserialize<UploadLocationMessage>(RequestXml);
                                            break;
                                        }
                                    case "click":
                                        {
                                            Request = RequestXmlConverter.Deserialize<MenuButtonMessage>(RequestXml);
                                            break;
                                        }
                                    default:
                                        {
                                            Request = null;
                                            break;
                                        }
                                }
                            }
                        }
                        break;
                    }
                default:
                    {
                        Request = null;
                        break;
                    }
            }
        }
    }
}
