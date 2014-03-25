using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WechatLibrary.GlobalSupport;

namespace WechatLibrary
{
    public partial class Wechat
    {
        public static void Register(string appId, string secret, string token, string wechatId, Assembly assembly)
        {
            GlobalConfig.HandlerAssemblies.Add(new HandlerAssembly()
            {
                AppId = appId,
                Secret = secret,
                Token = token,
                Assembly = assembly,
                WechatId = wechatId
            });
        }
    }
}
