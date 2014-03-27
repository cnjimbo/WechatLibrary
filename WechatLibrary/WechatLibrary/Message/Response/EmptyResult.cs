
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
