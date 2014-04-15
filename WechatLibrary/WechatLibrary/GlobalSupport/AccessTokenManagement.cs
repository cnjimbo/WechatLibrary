using Common.Serialization;
using Common.Serialization.Json;
using Common.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using WechatLibrary.Return;
using WechatLibrary.WechatDb.BLL;

namespace WechatLibrary.GlobalSupport
{
    internal class AccessTokenManagement
    {
        internal static Dictionary<string, AccessToken> accessTokens = new Dictionary<string, AccessToken>();

        internal static string Get(string appId)
        {
            if (accessTokens.ContainsKey(appId) == true && accessTokens[appId].CreateTime.AddSeconds(accessTokens[appId].ExpiresIn) < DateTime.Now)
            {
                return accessTokens[appId].Value;
            }
            else
            {
                var newToken = GetNewAccessToken(appId);
                accessTokens.AddOrUpdate(appId, newToken);
                return newToken.Value;
            }
        }

        private static AccessToken GetNewAccessToken(string appId)
        {
            W_WeChatInfoBLL bll = new W_WeChatInfoBLL();
            var temp = bll.GetByAppID(appId);

            string secret = temp == null ? string.Empty : temp.AppSecret;

            string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appId, secret);
            string responseBody = HttpHelper.Get(url);
            AccessTokenReturn weiXinReturn = JsonHelper.Deserialize<AccessTokenReturn>(responseBody);

            return new AccessToken()
            {
                CreateTime = DateTime.Now,
                Value = weiXinReturn.AccessToken,
                ExpiresIn = weiXinReturn.ExpiresIn
            };
        }
    }
}
