using Common.Serialization;
using Common.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using WechatLibrary.GlobalSupport.Return;

namespace WechatLibrary.GlobalSupport
{
    internal class AccessTokenManagement
    {
        internal static Dictionary<Assembly, AccessToken> accessTokens = new Dictionary<Assembly, AccessToken>();

        internal static string Get(Assembly key)
        {
            if (accessTokens.ContainsKey(key) == true && accessTokens[key].CreateTime.AddSeconds(accessTokens[key].ExpiresIn) < DateTime.Now)
            {
                return accessTokens[key].Value;
            }
            else
            {
                var newToken = GetNewAccessToken(key);
                accessTokens.AddOrUpdate(key, newToken);
                return newToken.Value;
            }
        }

        private static AccessToken GetNewAccessToken(Assembly assembly)
        {
            HandlerAssembly handlerAssembly = GlobalConfig.HandlerAssemblies.Where(temp => temp.Assembly == assembly).FirstOrDefault();
            string appid;
            string secret;
            if (handlerAssembly == null)
            {
                appid = ConfigurationManager.AppSettings["AppId"] ?? string.Empty;
                secret = ConfigurationManager.AppSettings["Secret"] ?? string.Empty;
            }
            else
            {
                appid = handlerAssembly.AppId;
                secret = handlerAssembly.Secret;
            }

            string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appid, secret);
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
