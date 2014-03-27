using Common.Serialization;
using System.Collections.Generic;

namespace WechatLibrary.MenuManagement
{
    /// <summary>
    /// 微信菜单一级按钮。
    /// </summary>
    public class MenuButton : MenuButtonBase
    {
        private List<MenuSubButton> subButton;

        /// <summary>
        /// 二级菜单数组，个数应为 1～5 个。
        /// </summary>
        [Json(Name = "sub_button", IgnoreNull = true)]
        public List<MenuSubButton> SubButton
        {
            get
            {
                subButton = subButton ?? new List<MenuSubButton>();
                return subButton;
            }
            set
            {
                subButton = value;
            }
        }
    }
}
