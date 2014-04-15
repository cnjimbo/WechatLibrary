using Common.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using WechatLibrary.WechatDb.BLL;

namespace WechatLibrary.GlobalSupport
{
    /// <summary>
    /// 验证 URL。
    /// </summary>
    internal static class Signature
    {
        /// <summary>
        /// 指示 URL 验证是否成功。
        /// </summary>
        /// <param name="context">当前 Http 上下文。</param>
        /// <returns>验证是否成功。</returns>
        /// <exception cref="System.ArgumentNullException"><c>context</c> 为 null。</exception>
        private static bool IsSignature(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            List<string> tokens = new List<string>();

            // 获取数据库的 Token。
            W_WeChatInfoBLL bll = new W_WeChatInfoBLL();
            tokens.AddRange(bll.GetAll().Select(temp => temp.Token));

            // 获取 web.config 的 Token。
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["Token"]) == false)
            {
                tokens.Add(ConfigurationManager.AppSettings["Token"]);
            }

            // 去重。
            tokens = tokens.Distinct().ToList();

            if (tokens.Count <= 0)
            {
                return false;
            }
            else
            {
                // 尝试校验每个 Token。
                foreach (var token in tokens)
                {
                    // 微信加密签名，signature 结合了开发者填写的 token 参数和请求中的 timestamp 参数、nonce 参数。
                    string signature = context.Request["signature"] ?? string.Empty;
                    // 时间戳。
                    string timestamp = context.Request["timestamp"] ?? string.Empty;
                    // 随机数。
                    string nonce = context.Request["nonce"] ?? string.Empty;

                    // 将 token、timestamp、nonce 三个参数进行字典序排序并拼接成一个字符串。
                    string validateStr = string.Join(string.Empty, new string[] { token, timestamp, nonce }.OrderBy(temp => temp));

                    // 将验证字符串进行 sha1 加密并与 signature 对比，标识该请求来源于微信。
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
        /// <exception cref="System.ArgumentNullException"><c>context</c> 为 null。</exception>
        internal static void DoSignature(HttpContext context, string validateFailureReturn = "error")
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (validateFailureReturn == null)
            {
                MethodBase methodBase = MethodBase.GetCurrentMethod();
                ParameterInfo[] parameters = methodBase.GetParameters();
                var parameter = parameters.Where(temp => temp.Name == "validateFailureReturn").FirstOrDefault();
                if (parameter == null)
                {
                    // 反射方法自身参数失败。
                    validateFailureReturn = string.Empty;
                }
                else
                {
                    validateFailureReturn = Convert.ToString(parameter.DefaultValue);
                }
            }

            try
            {
                HttpRequest request = context.Request;
                string echostr = context.Request["echostr"];

                HttpResponse response = context.Response;
                response.ContentType = "text/plain";

                if (string.IsNullOrEmpty(echostr) == false && IsSignature(context) == true)
                {
                    response.Write(echostr);
                }
                else
                {
                    response.Write(validateFailureReturn);
                }
                response.End();
            }
            catch (HttpException)
            {
            }
        }
    }
}
