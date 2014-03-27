using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using WechatLibrary.GlobalSupport;

namespace WechatLibrary
{
    public static partial class Wechat
    {
        /// <summary>
        /// 注册微信消息处理程序集。
        /// </summary>
        /// <param name="id">注册 Id。</param>
        /// <param name="appId">AppId。</param>
        /// <param name="secret">Secret。</param>
        /// <param name="token">Token。</param>
        /// <param name="wechatId">微信号 Id。</param>
        /// <param name="assembly">处理该微信号消息的程序集。</param>
        public static void Register(string id, string appId, string secret, string token, string wechatId,
            Assembly assembly)
        {
            if (string.IsNullOrEmpty(id)==true)
            {
                throw new ArgumentNullException("");
            }
            if (string.IsNullOrEmpty(appId)==true)
            {
                appId = ConfigurationManager.AppSettings["AppId"];
                if (string.IsNullOrEmpty(appId)==true)
                {
                    throw new ArgumentNullException("");
                }
            }
            if (string.IsNullOrEmpty(secret)==true)
            {
                secret = ConfigurationManager.AppSettings["Secret"];
                if (string.IsNullOrEmpty(secret)==true)
                {
                    throw new ArgumentNullException("");
                }
            }
            if (string.IsNullOrEmpty(token)==true)
            {
                token = ConfigurationManager.AppSettings["Token"];
                if (string.IsNullOrEmpty(token)==true)
                {
                    throw  new ArgumentNullException("");
                }
            }
            if (string.IsNullOrEmpty(wechatId)==true)
            {
                wechatId = ConfigurationManager.AppSettings["WechatId"];
                if (string.IsNullOrEmpty(wechatId)==true)
                {
                    throw new ArgumentNullException("");
                }
            }
            if (assembly==null)
            {
                assembly = Assembly.GetCallingAssembly();
            }

            var query = GlobalConfig.HandlerAssemblies.Where(temp => temp.Id == id);
            if (query.Count() > 0)
            {
                HandlerAssembly handlerAssembly = query.FirstOrDefault();
                handlerAssembly.Id = id;
                handlerAssembly.AppId = appId;
                handlerAssembly.Secret = secret;
                handlerAssembly.Token = token;
                handlerAssembly.WechatId = wechatId;
                handlerAssembly.Assembly = assembly;
            }
            else
            {
                GlobalConfig.HandlerAssemblies.Add(new HandlerAssembly()
                {
                    Id = id,
                    AppId = appId,
                    Secret = secret,
                    Token = token,
                    Assembly = assembly,
                    WechatId = wechatId
                });
            }
        }
    }
}
