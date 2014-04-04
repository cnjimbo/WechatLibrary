
namespace WechatLibrary
{
    public static partial class UserInfoManagement
    {
        /// <summary>
        /// 获取用户的 openid。
        /// </summary>
        /// <param name="code">获取用户信息重定向的链接中的 code 参数。</param>
        /// <param name="registerId">注册的 Id。</param>
        /// <returns>用户的 openid。</returns>
        public static string GetOpenId(string code, string registerId)
        {
            return GetOAuth2AccessToken(code, registerId).OpenId;
        }
    }
}
