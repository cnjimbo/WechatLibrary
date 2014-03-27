using System.Reflection;

namespace WechatLibrary.GlobalSupport
{
    /// <summary>
    /// 微信类库注册处理程序集。
    /// </summary>
    internal class HandlerAssembly
    {
        /// <summary>
        /// 获取 Id。
        /// </summary>
        internal string Id
        {
            get;
            set;
        }

        /// <summary>
        /// AppId。
        /// </summary>
        internal string AppId
        {
            get;
            set;
        }

        /// <summary>
        /// Secret。
        /// </summary>
        internal string Secret
        {
            get;
            set;
        }

        /// <summary>
        /// Token。
        /// </summary>
        internal string Token
        {
            get;
            set;
        }

        /// <summary>
        /// 微信号 Id。
        /// </summary>
        internal string WechatId
        {
            get;
            set;
        }

        /// <summary>
        /// 处理该微信号消息的程序集。
        /// </summary>
        internal Assembly Assembly
        {
            get;
            set;
        }
    }
}
