using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.Request;
using WechatLibrary.WechatDb.BLL;
using WechatLibrary.WechatDb.Model;

namespace WechatLibrary
{
    internal partial class Route
    {

        internal void DbProcessMenuButton(MenuButtonMessage message)
        {

            W_WeChatInfoBLL weChatInfoBll = new W_WeChatInfoBLL();
            W_WeChatInfo weChatInfo = weChatInfoBll.GetByWechatID(message.ToUserName);
            if (weChatInfo == null)
            {
                return;
            }
            W_ResourcesCataBLL resourcesCataBll = new W_ResourcesCataBLL();
            List<W_ResourcesCata> resourcesCataList = resourcesCataBll.GetByWeChatInfo(weChatInfo);
            if (resourcesCataList.Count <= 0)
            {
                return;
            }
            W_KeyWordBLL keyWordBll = new W_KeyWordBLL();
            foreach (W_ResourcesCata resourcesCata in resourcesCataList)
            {
                List<W_KeyWord> keyWordList = keyWordBll.GetByResourcesCata(resourcesCata);
                foreach (W_KeyWord keyWord in keyWordList)
                {
                    if (message.EventKey == keyWord.WKey)
                    {
                        DoKeyWord(keyWord);
                        return;
                    }
                }
            }
        }
    }
}
