using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WechatLibrary;

namespace Mvc2Test.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Wechat.ProcessRequest();
            return new EmptyResult();
        }

    }
}
