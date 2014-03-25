using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Response
{
    /// <summary>
    /// 不回复消息。
    /// </summary>
    public class EmptyResult : ResponseResultBase
    {
        internal override string Serialize()
        {
            return string.Empty;
        }
    }
}
