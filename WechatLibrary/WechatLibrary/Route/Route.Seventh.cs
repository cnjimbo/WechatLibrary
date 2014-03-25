using System;

namespace WechatLibrary
{
    internal partial class Route
    {
        /// <summary>
        /// 填充默认缺失信息。
        /// </summary>
        internal void Seventh()
        {
            if (string.IsNullOrEmpty(Response.ToUserName) == true)
            {
                Response.ToUserName = Request.FromUserName;
            }
            if (string.IsNullOrEmpty(Response.FromUserName) == true)
            {
                Response.FromUserName = Request.ToUserName;
            }
            if (Response.CreateTime == 0)
            {
                Response.CreateTime = (int)(DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            }
        }
    }
}
