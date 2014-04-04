using System;
using System.Reflection;
using System.Web;
using WechatLibrary.GlobalSupport;

namespace WechatLibrary
{
    /// <summary>
    /// 微信类库入口。
    /// </summary>
    public static partial class Wechat
    {
        /// <summary>
        /// 处理微信用户消息。
        /// </summary>
        /// <exception cref="System.ArgumentNullException">当前 Http 上下文为空。</exception>
        public static void ProcessRequest()
        {
            ProcessRequest(HttpContext.Current, Assembly.GetCallingAssembly());
        }

        /// <summary>
        /// 处理微信用户消息。
        /// </summary>
        /// <param name="context">当前 Http 上下文。</param>
        /// <exception cref="System.ArgumentNullException"><c>context</c> 为 null。</exception>
        public static void ProcessRequest(HttpContext context)
        {
            ProcessRequest(context, Assembly.GetCallingAssembly());
        }

        /// <summary>
        /// 处理微信用户消息。
        /// </summary>
        /// <param name="handlerAssembly">处理该次消息的程序集。</param>
        public static void ProcessRequest(Assembly handlerAssembly)
        {
            handlerAssembly = handlerAssembly ?? Assembly.GetCallingAssembly();
            ProcessRequest(HttpContext.Current, handlerAssembly);
        }

        /// <summary>
        /// 处理微信用户消息。
        /// </summary>
        /// <param name="context">当前 Http 上下文。</param>
        /// <param name="handlerAssembly">处理该次消息的程序集。</param>
        /// <exception cref="System.ArgumentNullException"><c>context</c> 为 null。</exception>
        public static void ProcessRequest(HttpContext context, Assembly handlerAssembly)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context", "context 不能为空。");
            }

            // handlerAssembly 参数为空，则设置为调用该方法的程序集。
            handlerAssembly = handlerAssembly ?? Assembly.GetCallingAssembly();

            try
            {
                HttpRequest request = context.Request;
                
                // 该次 Http 请求方法。
                string method = request.HttpMethod;

                if (method.Equals("POST", StringComparison.OrdinalIgnoreCase) == true)
                {
                    // Post 请求。

                    Route route = new Route(context, handlerAssembly);
                    route.Start();
                }
                else if (method.Equals("GET", StringComparison.OrdinalIgnoreCase) == true)
                {
                    // Get 请求。

#if DEBUG
                    Route route = new Route(context, handlerAssembly);
                    route.Start();
                    return;
#endif
                    Signature.DoSignature(context);
                }
            }
            catch (HttpException)
            {
            }
        }
    }
}
