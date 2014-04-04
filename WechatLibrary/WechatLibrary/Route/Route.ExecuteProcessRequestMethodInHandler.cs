using System;
using System.Reflection;
using WechatLibrary.Response;

namespace WechatLibrary
{
    internal partial class Route
    {
        /// <summary>
        /// 执行程序集中的类的 ProcessRequest 方法。
        /// </summary>
        internal void ExecuteProcessRequestMethodInHandler()
        {
            if (this.DBProcess == false && this.HandlerType != null && this.Request != null)
            {
                // 创建实例。
                object handler = Activator.CreateInstance(HandlerType);

                // 获取 ProcessRequest 执行方法。
                MethodInfo method = HandlerType.GetMethod("ProcessRequest");

                // 创建参数数组。
                object[] parameters = new object[] { this.Request, this.DBProcess };

                // 执行方法。
                this.Response = (ResponseResultBase)method.Invoke(handler, parameters);

                // 设置 ref 参数。
                this.DBProcess = (bool)parameters[1];
            }
        }
    }
}
