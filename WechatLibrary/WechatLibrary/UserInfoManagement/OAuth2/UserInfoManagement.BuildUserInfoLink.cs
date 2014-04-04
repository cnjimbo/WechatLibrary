using System;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace WechatLibrary
{
    public static partial class UserInfoManagement
    {
        private const string UserInfoLinkTemplate = @"https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_userinfo&state={2}#wechat_redirect";

        /// <summary>
        /// 创建一条获取用户信息的链接。
        /// </summary>
        /// <param name="url">授权后重定向的回调链接地址，请使用 urlencode 对链接进行处理。</param>
        /// <param name="state">重定向后会带上 state 参数，开发者可以填写 a-zA-Z0-9 的参数值。</param>
        /// <returns>链接。</returns>
        public static string BuildUserInfoLink(string url, object state = null)
        {
            return BuildUserInfoLink(url, string.Empty, state);
        }

        /// <summary>
        /// 创建一条获取用户信息的链接。
        /// </summary>
        /// <param name="url">授权后重定向的回调链接地址，请使用 urlencode 对链接进行处理。</param>
        /// <param name="registerId">注册的 Id。</param>
        /// <param name="state">重定向后会带上 state 参数，开发者可以填写 a-zA-Z0-9 的参数值。</param>
        /// <returns>链接。</returns>
        public static string BuildUserInfoLink(string url, string registerId, object state = null)
        {
            string appid;

            #region 根据注册 Id 获取 AppId。
            var query = GlobalConfig.HandlerAssemblies.Where(temp => temp.Id == registerId);
            if (query.Count() <= 0)
            {
                appid = ConfigurationManager.AppSettings["AppId"];
                if (string.IsNullOrEmpty(appid) == true)
                {
                    throw new ArgumentException("未发现可用的 AppId。");
                }
            }
            else
            {
                appid = query.FirstOrDefault().AppId;
            }
            #endregion

            state = state ?? string.Empty;

            return string.Format(UserInfoLinkTemplate, appid, url, state.ToString());
        }

        /// <summary>
        /// 创建一条获取用户信息的链接。
        /// </summary>
        /// <param name="url">授权后重定向的回调链接地址，请使用 urlencode 对链接进行处理。</param>
        /// <param name="assembly">注册的程序集。</param>
        /// <param name="state">重定向后会带上 state 参数，开发者可以填写 a-zA-Z0-9 的参数值。</param>
        /// <returns>链接。</returns>
        public static string BuildUserInfoLink(string url, Assembly assembly, object state = null)
        {
            string appid;

            #region 根据程序集获取 AppId。
            var query = GlobalConfig.HandlerAssemblies.Where(temp => temp.Assembly == assembly);
            if (query.Count() <= 0)
            {
                appid = ConfigurationManager.AppSettings["AppId"];
                if (string.IsNullOrEmpty(appid) == true)
                {
                    throw new ArgumentException("未发现可用的 AppId。");
                }
            }
            else
            {
                appid = query.FirstOrDefault().AppId;
            }
            #endregion

            state = state ?? string.Empty;

            return string.Format(UserInfoLinkTemplate, appid, state.ToString());
        }
    }
}
