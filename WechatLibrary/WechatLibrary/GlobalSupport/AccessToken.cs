using System;

namespace WechatLibrary.GlobalSupport
{
    internal class AccessToken
    {
        internal DateTime CreateTime
        {
            get;
            set;
        }

        internal string Value
        {
            get;
            set;
        }

        internal int ExpiresIn
        {
            get;
            set;
        }
    }
}
