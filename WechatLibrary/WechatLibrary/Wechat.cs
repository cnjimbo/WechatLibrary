using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WechatLibrary
{
    /// <summary>
    /// 微信类库入口。
    /// </summary>
    public partial class Wechat
    {
        public static void ProcessRequest()
        {
        }

        public static void ProcessRequest(HttpContext context)
        {
        }

        public static void ProcessRequest(HttpContext context, Assembly handlerAssembly)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context 不能为空。");
            }

            handlerAssembly = handlerAssembly ?? Assembly.GetCallingAssembly();

            string method = context.Request.HttpMethod;
            if (method.Equals("POST", StringComparison.OrdinalIgnoreCase) == true)
            {
                Route route = new Route(context, handlerAssembly);
                route.Start();
            }
            else if (method.Equals("GET", StringComparison.OrdinalIgnoreCase) == true)
            {

            }
        }
    }
}
