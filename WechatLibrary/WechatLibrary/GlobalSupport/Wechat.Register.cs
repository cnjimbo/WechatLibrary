using System.Reflection;
using WechatLibrary.GlobalSupport;

namespace WechatLibrary
{
    public partial class Wechat
    {
        /// <summary>
        /// 注册微信消息处理程序集。
        /// </summary>
        /// <param name="appId">AppId。</param>
        /// <param name="secret">Secret。</param>
        /// <param name="token">Token。</param>
        /// <param name="wechatId">微信号 Id。</param>
        /// <param name="assembly">处理该微信号消息的程序集。</param>
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
