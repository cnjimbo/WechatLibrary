using Common.Serialization;
using Common.Serialization.Json;
using Common.Web;
using System;
using System.Configuration;
using System.Linq;
using WechatLibrary.Return;

namespace WechatLibrary
{
    public static partial class UserInfoManagement
    {
        private const string OAuth2AccessTokenTemplate = "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";

        /// <summary>
        /// 获取网页授权 AccessToken。
        /// </summary>
        /// <param name="code">获取用户信息重定向的链接中的 code 参数。</param>
        /// <param name="appId">AppId。</param>
        /// <param name="secret">Secret。</param>
        /// <returns>网页授权 AccessToken。</returns>
        public static OAuth2AccessTokenReturn GetOAuth2AccessToken(string code, string appId, string secret)
        {
            string url = string.Format(OAuth2AccessTokenTemplate, appId, secret, code);

            string responseBody = HttpHelper.Get(url);

            return JsonHelper.Deserialize<OAuth2AccessTokenReturn>(responseBody);
        }
    }
}
