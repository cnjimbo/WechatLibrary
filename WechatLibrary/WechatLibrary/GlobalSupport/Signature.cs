using Common.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WechatLibrary.GlobalSupport
{
    internal static class Signature
    {
        /// <summary>
        /// 指示 URL 验证是否成功。
        /// </summary>
        /// <param name="context">当前 Http 上下文。</param>
        /// <returns>验证是否成功。</returns>
        private static bool IsSignature(HttpContext context)
        {
            List<string> tokens = new List<string>();
            tokens.AddRange(from temp in GlobalConfig.HandlerAssemblies
                            where string.IsNullOrEmpty(temp.Token) == false
                            select temp.Token);
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["Token"]) == false)
            {
                tokens.Add(ConfigurationManager.AppSettings["Token"]);
            }
            tokens = tokens.Distinct().ToList();

            if (tokens.Count <= 0)
            {
                return false;
            }
            else
            {
                foreach (var token in tokens)
                {
                    // 微信加密签名，signature结合了开发者填写的token参数和请求中的timestamp参数、nonce参数。
                    string signature = context.Request["signature"] ?? string.Empty;
                    // 时间戳
                    string timestamp = context.Request["timestamp"] ?? string.Empty;
                    // 随机数
                    string nonce = context.Request["nonce"] ?? string.Empty;

                    // 将token、timestamp、nonce三个参数进行字典序排序并拼接成一个字符串
                    string validateStr = string.Join(string.Empty, new string[] { token, timestamp, nonce }.OrderBy(temp => temp));

                    // 将验证字符串进行sha1加密并于signature对比，标识该请求来源于微信
                    bool result = string.Equals(SHA1Helper.GetStringSHA1(validateStr), signature, StringComparison.OrdinalIgnoreCase);

                    if (result == true)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 根据 URL 验证返回内容给微信服务器。
        /// </summary>
        /// <param name="context">当前 http 上下文。</param>
        /// <param name="validateFailureReturn">验证失败时返回的字符串，默认为 error。</param>
        internal static void DoSignature(HttpContext context, string validateFailureReturn = "error")
        {
            context.Response.ContentType = "text/plain";
            string echostr = context.Request["echostr"];
            if (IsSignature(context) == true && string.IsNullOrEmpty(echostr) == false)
            {
                context.Response.Write(echostr);
            }
            else
            {
                context.Response.Write(validateFailureReturn);
            }
            context.Response.End();
        }
    }
}
