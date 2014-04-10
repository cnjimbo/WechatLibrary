using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.WechatDb.Model
{
    public class W_WeChatInfo
    {
        public string WID
        {
            get;
            set;
        }

        public string AppID
        {
            get;
            set;
        }

        public string AppSecret
        {
            get;
            set;
        }

        public string Token
        {
            get;
            set;
        }

        public string WechatID
        {
            get;
            set;
        }

        public string AppNamespace
        {
            get;
            set;
        }

        public DateTime CreateTime
        {
            get;
            set;
        }

        public byte IsDelete
        {
            get;
            set;
        }
    }
}
