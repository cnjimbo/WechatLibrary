
namespace WechatLibrary
{
    public static partial class UserInfoManagement
    {
        public static string GetOpenId(string code, string registerId)
        {
            return GetOAuth2AccessToken(code, registerId).OpenId;
        }
    }
}
