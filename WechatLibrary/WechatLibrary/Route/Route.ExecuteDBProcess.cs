using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.Request;
using System.Configuration;

namespace WechatLibrary
{
    internal partial class Route
    {
        /// <summary>
        /// 执行数据库处理消息。
        /// </summary>
        internal void ExecuteDBProcess()
        {
            if (DBProcess == true && Request != null && string.IsNullOrEmpty(ConfigurationManager.AppSettings["WechatDataBaseConnectionString"]) == false)
            {
                if (this.RequestType == "text")
                {
                    DbProcessText((TextMessage)this.Request);
                }
                else if (this.Request is MenuButtonMessage)
                {
                    DbProcessMenuButton((MenuButtonMessage)this.Request);
                }
            }
        }
    }
}
