using WechatLibrary.Request;
using WechatLibrary.Response;

namespace WechatLibrary.Interface
{
    /// <summary>
    /// 自定义菜单事件处理接口。
    /// </summary>
    public interface IMenuButtonHandler
    {
        /// <summary>
        /// 处理自定义菜单事件。
        /// </summary>
        /// <param name="message">自定义菜单事件。</param>
        /// <param name="dbProcess">是否由数据库默认处理。</param>
        /// <returns>回复消息。</returns>
        ResponseResultBase ProcessRequest(MenuButtonMessage message, ref bool dbProcess);
    }
}
