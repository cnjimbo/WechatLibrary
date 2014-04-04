using System.Threading;
using System.Web;

namespace WechatLibrary
{
    internal partial class Route
    {
        /// <summary>
        /// 将回复消息序列化并写入响应流中。
        /// </summary>
        internal void SerializeResponseResultAndWriteToResponseStream()
        {
            string xml = Response == null ? string.Empty : Response.Serialize();
            try
            {
                HttpResponse httpResponse = this.HttpContext.Response;
                httpResponse.ContentType = "text/xml";
                httpResponse.Write(xml);
                try
                {
                    httpResponse.End();
                }
                catch (ThreadAbortException)
                {
                }
            }
            catch (HttpException)
            {
            }
        }
    }
}
