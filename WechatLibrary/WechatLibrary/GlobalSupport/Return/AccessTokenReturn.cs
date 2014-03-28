using Common.Serialization;
using WechatLibrary.Return;

namespace WechatLibrary.GlobalSupport.Return
{
    internal class AccessTokenReturn : ReturnBase
    {
        /// <summary>
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
