using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WechatLibrary.Interface;
using WechatLibrary.Request;
using WechatLibrary.Response;

namespace WebFormTest.Handler
{
    public class TextHandler : ITextHandler
    {
        public ResponseResultBase ProcessRequest(TextMessage message, ref bool dbProcess)
        {
            dbProcess = true;
            return new TextResult()
            {
                Content = "Haha"
            };
        }
    }
}