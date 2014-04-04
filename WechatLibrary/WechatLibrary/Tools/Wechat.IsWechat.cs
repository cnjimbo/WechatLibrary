using System;
using System.Web;

namespace WechatLibrary
{
    public static partial class Wechat
    {
        /// <summary>
        /// 通过 user-agent 检查是否使用微信浏览器进行当前 Http 请求。
        /// </summary>
        /// <returns>是否使用微信浏览器。</returns>
        public static bool IsUseWechatBrowser()
        {
            return IsUseWechatBrowser(HttpContext.Current);
        }

        /// <summary>
        /// 通过 user-agent 检查是否使用微信浏览器进行指定的 Http 请求。
        /// </summary>
        /// <param name="httpContext">Http 请求。</param>
        /// <returns>是否使用微信浏览器。</returns>
        public static bool IsUseWechatBrowser(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                return false;
            }
            else
            {
                try
                {
                    HttpRequest request = httpContext.Request;
                    string userAgent = request.UserAgent;
                    if (string.IsNullOrEmpty(userAgent) == true)
                    {
                        return false;
                    }
                    else
                    {
                        return userAgent.Contains("MicroMessenger", StringComparison.OrdinalIgnoreCase);
                    }
                }
                catch (HttpException)
                {
                    return false;
                }
            }
        }
    }
}
