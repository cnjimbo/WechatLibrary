using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WechatLibrary.GlobalSupport
{
    internal class HandlerAssembly
    {
        /// <summary>
        /// AppId。
        /// </summary>
        internal string AppId
        {
            get;
            set;
        }

        /// <summary>
        /// Secret。
        /// </summary>
        internal string Secret
        {
            get;
            set;
        }

        /// <summary>
        /// Token。
        /// </summary>
        internal string Token
        {
            get;
            set;
        }

        /// <summary>
        /// 微信号 Id。
        /// </summary>
        internal string WechatId
        {
            get;
            set;
        }

        /// <summary>
        /// 处理该微信号消息的程序集。
        /// </summary>
        internal Assembly Assembly
        {
            get;
            set;
        }
    }
}
