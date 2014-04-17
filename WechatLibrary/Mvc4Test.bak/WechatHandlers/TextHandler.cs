using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WechatLibrary.Interface;
using WechatLibrary.Response;

// 请修改命名空间起始为数据库中注册的命名空间。
namespace TTTWX.Mvc4Test.WechatHandlers
{
    // 请实现相应的接口。
    public class TextHandler : ITextHandler
    {
        public WechatLibrary.Response.ResponseResultBase ProcessRequest(WechatLibrary.Request.TextMessage message, ref bool dbProcess)
        {
            return new TextResult()
            {
                Content = "this is a test"
            };
        }
    }
}
