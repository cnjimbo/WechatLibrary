using Common.Serialization;

namespace WechatLibrary.Return
{
    /// <summary>
    /// 网页授权 AccessToken。
    /// </summary>
    public class OAuth2AccessTokenReturn : ReturnBase
    {
        /// <summary>
        /// 网页授权接口调用凭证，注意：此 access_token 与基础支持的 access_token 不同。
        /// </summary>
        [Json(Name = "access_token")]
        public string AccessToken
        {
            get;
            set;
        }

        /// <summary>
        /// access_token 接口调用凭证超时时间，单位（秒）。
        /// </summary>
        [Json(Name = "expires_in")]
        public int ExpiresIn
        {
            get;
            set;
        }

        /// <summary>
        /// 用户刷新 access_token。
        /// </summary>
        [Json(Name = "refresh_token")]
        public string RefreshToken
        {
            get;
            set;
        }

        /// <summary>
        /// 用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的 OpenID。
        /// </summary>
        [Json(Name = "openid")]
        public string OpenId
        {
            get;
            set;
        }

        /// <summary>
        /// 用户授权的作用域，使用逗号（,）分隔。
        /// </summary>
        [Json(Name = "scope")]
        public string Scope
        {
            get;
            set;
        }

        internal OAuth2AccessTokenReturn()
        {
        }
    }
}
