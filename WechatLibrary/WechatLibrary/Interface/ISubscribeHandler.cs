using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.Message.Request.Event;
using WechatLibrary.Message.Response;

namespace WechatLibrary.Interface
{
    public interface ISubscribeHandler
    {
        ResponseResultBase ProcessRequest(SubscribeMessage message);
    }
}
