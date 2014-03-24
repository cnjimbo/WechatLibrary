﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Message.Request
{
    public class TextRequest : RequestBase
    {
        /// <summary>
        /// 文本消息内容。
        /// </summary>
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// 消息 id，64 位整型。
        /// </summary>
        public long MsgId
        {
            get;
            set;
        }
    }
}
