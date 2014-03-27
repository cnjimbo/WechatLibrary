using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Serialization;

namespace WechatLibrary.GlobalSupport.Return
{
    internal class AccessTokenReturn
    { /// <summary>
        /// 获取到的凭证。
        /// </summary>
        [Json(Name = "access_token")]
        internal string AccessToken
        {
            get;
            set;
        }

        /// <summary>
        /// 凭证有效时间，单位：秒。
        /// </summary>
        [Json(Name = "expires_in")]
        internal int ExpiresIn
        {
            get;
            set;
        }
    }
}
