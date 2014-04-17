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
            List<W_Menu> menuButtons = menuBll.GetByWeChatInfo(weChatInfo).OrderBy(temp => temp.Sort).ToList();// 获取对应的一级菜单并按 sort 排序。
            Menu menu = new Menu();
            foreach (W_Menu menuButton in menuButtons)
            {
                MenuButton button = new MenuButton();
                button.Name = menuButton.MenuName;
                if (menuButton.MenuType == "click")
                {
                    button.Type = MenuButtonType.Click;
                    button.Key = menuButton.MenuKey;
                }
                else if (menuButton.MenuType == "view")
                {
                    button.Type = MenuButtonType.View;
                    button.Url = menuButton.MenuURL;
                }

                List<W_Menu> menuSubButtons = menuBll.GetChildButtons(menuButton).OrderBy(temp => temp.Sort).ToList();
                foreach (W_Menu menuSubButton in menuSubButtons)
                {
                    MenuSubButton subButton = new MenuSubButton();
                    subButton.Name = menuButton.MenuName;
                    if (menuSubButton.MenuType == "click")
                    {
                        subButton.Type = MenuButtonType.Click;
                        subButton.Key = menuButton.MenuKey;
                    }
                    else if (menuSubButton.MenuType == "view")
                    {
                        subButton.Type = MenuButtonType.View;
                        subButton.Url = menuSubButton.MenuURL;
                    }

                    button.SubButton.Add(subButton);
                }

                menu.Button.Add(button);
            }

            return menu;
        }

        public static bool SaveToDataBase(Menu menu, string appid)
        {
            try
            {
                #region delete current database menu
                W_WeChatInfoBLL weChatInfoBll = new W_WeChatInfoBLL();
                W_WeChatInfo weChatInfo = weChatInfoBll.GetByAppID(appid);
                W_MenuBLL menuBll = new W_MenuBLL();

                List<W_Menu> menus = menuBll.GetByWeChatInfo(weChatInfo);// 一级菜单

                foreach (W_Menu wMenu in menus)
                {
                    List<W_Menu> subMenus = menuBll.GetChildButtons(wMenu);

                    foreach (W_Menu subMenu in subMenus)
                    {
                        menuBll.Delete(subMenu);
                    }

                    menuBll.Delete(wMenu);
                }
                #endregion

                #region add current to database
                List<W_Menu> addList = new List<W_Menu>();
                foreach (var button in menu.Button)
                {
                    W_Menu w = new W_Menu();
                    w.MenuID = Guid.NewGuid().ToString();
                    w.WID = weChatInfo.WID;
                    w.MenuName = button.Name;
                    if (button.Type == MenuButtonType.Click)
                    {
                        w.MenuType = "click";
                        w.MenuKey = button.Key;
                    }
                    else if (button.Type == MenuButtonType.View)
                    {
                        w.MenuType = "view";
                        w.MenuURL = button.Key;
                    }
                    w.PMenuID = "0";
                    w.ResponseType = "";
                    w.ResourcesID = "";
                    w.CreateTime = DateTime.Now;
                    w.IsDelete = 0;

                    addList.Add(w);

                    foreach (var subButton in button.SubButton)
                    {
                        W_Menu ww = new W_Menu();
                        ww.MenuID = Guid.NewGuid().ToString();
                        ww.WID = Guid.NewGuid().ToString();
                        ww.MenuName = subButton.Name;
                        if (subButton.Type == MenuButtonType.Click)
                        {
                            ww.MenuType = "click";
                            ww.MenuKey = subButton.Key;
                        }
                        else if (subButton.Type == MenuButtonType.View)
                        {
                            ww.MenuType = "view";
                            ww.MenuURL = subButton.Url;
                        }
                        ww.PMenuID = w.MenuID;
                        ww.ResponseType = "";
                        ww.ResourcesID = "";
                        ww.CreateTime = DateTime.Now;
                        ww.IsDelete = 0;

                        addList.Add(ww);
                    }
                }

                foreach (var temp in addList)
                {
                    menuBll.Add(temp);
                }

                return true;
                #endregion
            }
            catch
            {
                return false;
            }
        }
    }
}
