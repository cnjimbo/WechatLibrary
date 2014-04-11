using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.WechatDb.BLL;
using WechatLibrary.WechatDb.Model;

namespace WechatLibrary
{
    internal partial class Route
    {
        internal void GetNamespaceFromDataBase()
        {
            if (this.Request != null)
            {
                string toUserName = this.Request.ToUserName;
                W_WeChatInfoBLL bll = new W_WeChatInfoBLL();
                W_WeChatInfo weChatInfo = bll.GetByWechatID(toUserName);
                if (weChatInfo != null)
                {
                    this.Namespace = weChatInfo.AppNamespace;
                }
            }
        }
    }
}
