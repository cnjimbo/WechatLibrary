using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary
{
    internal partial class Route
    {
        /// <summary>
        /// 执行程序集中的类的 ProcessRequest 方法。
        /// </summary>
        internal void Sixth()
        {
            dynamic handler = Activator.CreateInstance(HandlerType);
            bool dbProcess;
            this.Response = handler.ProcessRequest(Request, out dbProcess);
            this.DBProcess = dbProcess;
        }
    }
}
