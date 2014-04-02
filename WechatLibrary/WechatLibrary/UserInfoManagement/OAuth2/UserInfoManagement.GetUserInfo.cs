using Common.Serialization;
using Common.Web;
using System;
using System.ComponentModel;
using WechatLibrary.Return;

namespace WechatLibrary
{
    public static partial class UserInfoManagement
    {
        private const string UserInfoTemplate = "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang={2}";

        /// <summary>
        /// 拉取用户信息的语言。
        /// </summary>
        public enum UserInfoLanguage
        {
            /// <summary>
            /// 简体。
            /// </summary>
            ZhCn,
            /// <summary>
            /// 繁体。
            /// </summary>
            ZhTw,
            /// <summary>
            /// 英语。
            /// </summary>
            En
        }

        /// <summary>
        /// 拉取用户信息。
        /// </summary>
        /// <param name="oAuth2AccessToken">accessToken。</param>
        /// <returns>用户信息。</returns>
        public static UserInfoReturn GetUserInfo(OAuth2AccessTokenReturn oAuth2AccessToken)
        {
            return GetUserInfo(oAuth2AccessToken, UserInfoLanguage.ZhCn);
        }

        /// <summary>
        /// 拉取用户信息。
        /// </summary>
        /// <param name="oAuth2AccessToken">accessToken。</param>
        /// <param name="lang">语言。</param>
        /// <returns>用户信息。</returns>
        public static UserInfoReturn GetUserInfo(OAuth2AccessTokenReturn oAuth2AccessToken, UserInfoLanguage lang)
        {
            switch (lang)
            {
                case UserInfoLanguage.ZhCn:
                    {
                        return GetUserInfo(oAuth2AccessToken, "zh_CN");
                    }
                case UserInfoLanguage.ZhTw:
                    {
                        return GetUserInfo(oAuth2AccessToken, "zh_TW");
                    }
                case UserInfoLanguage.En:
                    {
                        return GetUserInfo(oAuth2AccessToken, "en");
                    }
                default:
                    {
                        throw new InvalidEnumArgumentException("lang", (int)lang, typeof(UserInfoLanguage));
                    }
            }
        }

        private static UserInfoReturn GetUserInfo(OAuth2AccessTokenReturn oAuth2AccessToken, string lang)
        {
            if (oAuth2AccessToken == null)
            {
                throw new ArgumentNullException("oAuth2AccessToken");
            }
            if (lang == null)
            {
                throw new ArgumentNullException("lang");
            }
            if (lang != "zh_CN" && lang != "zh_TW" && lang != "en")
            {
                throw new ArgumentException("lang 错误。", "lang");
            }
            string url = string.Format(UserInfoTemplate, oAuth2AccessToken.AccessToken, oAuth2AccessToken.OpenId, lang);
            string responseBody = HttpHelper.Get(url);
            var userInfoReturn = JsonHelper.Deserialize<UserInfoReturn>(responseBody);
            return userInfoReturn;
        }
    }
}
