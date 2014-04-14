using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WechatLibrary.Interface;
using WechatLibrary.Response;
using EmptyResult = System.Web.Mvc.EmptyResult;

namespace MvcTest.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            WechatLibrary.Wechat.ProcessRequest(System.Web.HttpContext.Current, Assembly.GetExecutingAssembly());
            return new EmptyResult();
        }

    }
}

namespace TTTWX
{
    public class TextHandler : ITextHandler
    {
        public WechatLibrary.Response.ResponseResultBase ProcessRequest(WechatLibrary.Request.TextMessage message, ref bool dbProcess)
        {
            dbProcess = true;
            return new WechatLibrary.Response.EmptyResult();
        }
    }

}
