
namespace WechatLibrary
{
    internal partial class Route
    {
        /// <summary>
        /// 将回复消息序列化并写入响应流中。
        /// </summary>
        internal void End()
        {
            string xml = Response == null ? string.Empty : Response.Serialize();
            HttpContext.Response.ContentType = "text/xml";
            HttpContext.Response.Write(xml);
            HttpContext.Response.End();
        }
    }
}
