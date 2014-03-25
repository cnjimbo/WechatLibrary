using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WechatLibrary.GlobalSupport
{
    internal class HandlerAssembly
    {
        public string AppId
        {
            get;
            set;
        }

        public string Secret
        {
            get;
            set;
        }

        public string Token
        {
            get;
            set;
        }

        public string WechatId
        {
            get;
            set;
        }

        public Assembly Assembly
        {
            get;
            set;
        }
    }
}
