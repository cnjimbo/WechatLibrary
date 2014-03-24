using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Message.Response
{
    public class TextResult : ResponseResultBase
    {
        /// <summary>
        /// 回复的消息内容（换行：在 content 中能够换行，微信客户端就支持换行显示）。
        /// </summary>
        public string Content
        {
            get;
            set;
        }
    }
}
