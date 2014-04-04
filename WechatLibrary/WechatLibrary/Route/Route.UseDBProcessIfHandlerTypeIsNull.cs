
namespace WechatLibrary
{
    internal partial class Route
    {
        /// <summary>
        /// 若处理消息的类为空，则默认尝试使用数据库处理。
        /// </summary>
        internal void UseDBProcessIfHandlerTypeIsNull()
        {
            this.DBProcess = this.HandlerType == null;
        }
    }
}
