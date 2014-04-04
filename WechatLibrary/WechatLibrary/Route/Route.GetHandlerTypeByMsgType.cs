using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.Interface;

namespace WechatLibrary
{
    internal partial class Route
    {
        /// <summary>
        /// 获取执行程序集中实现了相应接口的类。
        /// </summary>
        internal void GetHandlerTypeByMsgType()
        {
            RequestType = RequestType ?? string.Empty;
            switch (RequestType.ToLower())
            {
                case "text":
                    {
                        this.HandlerType = GetTypeByInterface(typeof(ITextHandler));
                        break;
                    }
                case "image":
                    {
                        this.HandlerType = GetTypeByInterface(typeof(IImageHandler));
                        break;
                    }
                case "voice":
                    {
                        this.HandlerType = GetTypeByInterface(typeof(IVoiceHandler));
                        break;
                    }
                case "video":
                    {
                        this.HandlerType = GetTypeByInterface(typeof(IVideoHandler));
                        break;
                    }
                case "location":
                    {
                        this.HandlerType = GetTypeByInterface(typeof(ILocationHandler));
                        break;
                    }
                case "link":
                    {
                        this.HandlerType = GetTypeByInterface(typeof(ILinkHandler));
                        break;
                    }
                case "event":
                    {
                        switch (EventType.ToLower())
                        {
                            case "subscribe":
                                {
                                    var root = RequestXml.Root;
                                    if (root != null)
                                    {
                                        var eventKey = root.Element("EventKey");
                                        if (eventKey == null || string.IsNullOrWhiteSpace(eventKey.Value) == true)
                                        {
                                            this.HandlerType = GetTypeByInterface(typeof(ISubscribeHandler));
                                        }
                                        else
                                        {
                                            this.HandlerType = GetTypeByInterface(typeof(IQRSubscribeHandler));
                                        }
                                    }
                                    break;
                                }
                            case "unsubscribe":
                                {
                                    this.HandlerType = GetTypeByInterface(typeof(IUnsubscribeHandler));
                                    break;
                                }
                            case "scan":
                                {
                                    this.HandlerType = GetTypeByInterface(typeof(IQRScanHandler));
                                    break;
                                }
                            case "location":
                                {
                                    this.HandlerType = GetTypeByInterface(typeof(IUploadLocationHandler));
                                    break;
                                }
                            case "click":
                                {
                                    var root = RequestXml.Root;
                                    if (root != null)
                                    {
                                        var eventKey = root.Element("EventKey");
                                        if (eventKey != null)
                                        {
                                            this.HandlerType = GetTypeByInterfaceAndKey(eventKey.Value);
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    this.HandlerType = null;
                                    break;
                                }
                        }
                        this.HandlerType = null;
                        break;
                    }
                default:
                    {
                        this.HandlerType = null;
                        break;
                    }
            }
        }
        private Type GetTypeByInterface(Type interfaceType)
        {
            return this.Assembly.GetTypes().Where(temp => interfaceType.IsAssignableFrom(temp) == true).FirstOrDefault();
        }

        private Type GetTypeByInterfaceAndKey(string key)
        {
            return this.Assembly.GetTypes().Where(temp => typeof(IMenuButtonHandler).IsAssignableFrom(temp) == true && temp.Name.Equals(key + "Handler", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }
    }
}
