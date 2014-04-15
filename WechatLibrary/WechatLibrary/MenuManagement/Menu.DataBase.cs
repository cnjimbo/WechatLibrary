using System;
using Common.Serialization;
using Common.Serialization.Json;
using Common.Web;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WechatLibrary.GlobalSupport;
using WechatLibrary.Return;
using WechatLibrary.WechatDb.BLL;
using WechatLibrary.WechatDb.Model;

namespace WechatLibrary.MenuManagement
{
    public partial class Menu
    {
        public static Menu LoadFromDataBaseByAppId(string appid)
        {
            W_WeChatInfoBLL weChatInfoBll = new W_WeChatInfoBLL();
            W_WeChatInfo weChatInfo = weChatInfoBll.GetByAppID(appid);
            W_MenuBLL menuBll = new W_MenuBLL();
            W_Menu menu = menuBll.GetByWeChatInfo(weChatInfo);
            if (menu == null)
            {
                return null;
            }
            else
            {
                string json = menu.MenuName;
                return JsonHelper.Deserialize<Menu>(json);
            }
        }

        public static bool SaveToDataBase(Menu menu, string appid)
        {
            W_WeChatInfoBLL weChatInfoBll = new W_WeChatInfoBLL();
            W_WeChatInfo weChatInfo = weChatInfoBll.GetByAppID(appid);
            W_MenuBLL menuBll = new W_MenuBLL();
            W_Menu wmenu = menuBll.GetByWeChatInfo(weChatInfo);
            if (wmenu == null)
            {
                return menuBll.Add(new W_Menu()
                {
                    MenuID = Guid.NewGuid().ToString(),
                    MenuName = JsonHelper.SerializeToJson(menu),
                    MenuType = "",
                    MenuURL = "",
                    MenuKey = "",
                    PMenuID = "",
                    ResponseType = "",
                    ResourcesID = "",
                    CreateTime = DateTime.Now,
                    IsDelete = 0
                });
            }
            else
            {
                wmenu.MenuName = JsonHelper.SerializeToJson(menu);
                return menuBll.Update(wmenu);
            }
        }
    }
}
