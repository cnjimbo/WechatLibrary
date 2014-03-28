using System;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace WechatLibrary
{
    public static partial class UserInfoManagement
    {
        private const string UserInfoLinkTemplate = @"https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_userinfo&state={2}#wechat_redirect";

        public static string BuildUserInfoLink(string url, object state = null)
        {
            return BuildUserInfoLink(url, string.Empty, state);
        }

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
