﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.Message.Request;
using WechatLibrary.Message.Response;

namespace WechatLibrary.Interface
{
    public interface ITextHandler
    {
        ResponseResultBase ProcessRequest(TextMessage message);
    }
}
