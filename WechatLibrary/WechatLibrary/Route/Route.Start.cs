using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Xml.Linq;
using WechatLibrary.Request;
using WechatLibrary.Response;

namespace WechatLibrary
{
    internal partial class Route
    {
        /// <summary>
        /// 当前 Http 上下文。
        /// </summary>
        internal HttpContext HttpContext
        {
            get;
            set;
        }

        /// <summary>
        /// 处理该次微信消息的程序集。
        /// </summary>
        internal Assembly Assembly
        {
            get;
            set;
        }

        /// <summary>
        /// 接收消息的 XML。
        /// </summary>
        internal XDocument RequestXml
        {
            get;
            set;
        }

        /// <summary>
        /// 接收的消息。
        /// </summary>
        internal RequestMessageBase Request
        {
            get;
            set;
        }

        /// <summary>
        /// 回复的消息。
        /// </summary>
        internal ResponseResultBase Response
        {
            get;
            set;
        }

        /// <summary>
        /// 接收消息的 MsgType。
        /// </summary>
        internal string RequestType
        {
            get;
            set;
        }

        /// <summary>
        /// 接收消息的 Event。
        /// </summary>
        internal string EventType
        {
            get;
            set;
        }

        /// <summary>
        /// 处理该次消息的类。
        /// </summary>
        internal Type HandlerType
        {
            get;
            set;
        }

        /// <summary>
        /// 该次消息是否默认数据库处理。
        /// </summary>
        internal bool DBProcess
        {
            get;
            set;
        }

        internal Route(HttpContext context, Assembly handlerAssembly)
        {
            this.HttpContext = context;
            this.Assembly = handlerAssembly;
        }

        internal void Start()
        {
            try
            {
                First();
                Second();
                Third();
                Fourth();
                Fifth();
                Sixth();
                Seventh();
            }
            finally
            {
                End();
            }
        }
    }
}
