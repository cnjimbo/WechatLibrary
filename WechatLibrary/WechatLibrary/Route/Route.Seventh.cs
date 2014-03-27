using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WechatLibrary.Response;

namespace WechatLibrary
{
    internal partial class Route
    {
        /// <summary>
        /// 执行程序集中的类的 ProcessRequest 方法。
        /// </summary>
        internal void Seventh()
        {
            if (DBProcess == false)
            {
                object handler = Activator.CreateInstance(HandlerType);
                MethodInfo method = HandlerType.GetMethod("ProcessRequest");
                object[] parameters = new object[] {Request, DBProcess};
                Response = (ResponseResultBase) method.Invoke(handler, parameters);
                DBProcess = (bool) parameters[1];
            }
        }
    }
}
