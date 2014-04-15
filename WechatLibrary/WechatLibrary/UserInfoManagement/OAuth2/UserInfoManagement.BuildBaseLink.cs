using System;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace WechatLibrary
{
    /// <summary>
    /// 用户管理。
    /// </summary>
    public static partial class UserInfoManagement
    {
        private const string BaseLinkTemplate = @"https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_base&state={2}#wechat_redirect";
        
        /// <summary>
        /// 创建一条获取用户 openid 的链接。
        /// </summary>
        /// <param name="url">授权后重定向的回调链接地址，请使用 urlencode 对链接进行处理。</param>
        /// <param name="state">重定向后会带上 state 参数，开发者可以填写 a-zA-Z0-9 的参数值。</param>
        /// <returns>链接。</returns>
        public static string BuildBaseLink(string url, object state = null)
        {
            return BuildBaseLink(url, string.Empty, state);
        }

        /// <summary>
        /// 创建一条获取用户 openid 的链接。
        /// </summary>
        /// <param name="url">授权后重定向的回调链接地址，请使用 urlencode 对链接进行处理。</param>
        /// <param name="appId">AppId。</param>
        /// <param name="state">重定向后会带上 state 参数，开发者可以填写 a-zA-Z0-9 的参数值。</param>
        /// <returns>链接。</returns>
        public static string BuildBaseLink(string url, string appId, object state = null)
        {   
            state = state ?? string.Empty;

            return string.Format(BaseLinkTemplate, appId, url, state.ToString());
        }
    }
}
