using System;
using Common.Serialization.Json;

namespace WechatLibrary.MenuManagement
{
    /// <summary>
    /// 微信菜单按钮类型自定义转换。
    /// </summary>
    internal class MenuButtonTypeConverter : JsonConverter
    {
        public override string Serialize(object value, Type type, ref bool skip)
        {
            var btnType = (MenuButtonType)value;
            if (btnType == MenuButtonType.Click)
            {
                return "\"click\"";
            }
            else if (btnType == MenuButtonType.View)
            {
                return "\"view\"";
            }
            else
            {
                skip = true;
                return string.Empty;
            }
        }

        public override object Deserialize(string value, Type type, ref bool skip)
        {
            if (value.Equals("\"click\"", StringComparison.OrdinalIgnoreCase) == true)
            {
                return MenuButtonType.Click;
            }
            else if (value.Equals("\"view\"", StringComparison.OrdinalIgnoreCase) == true)
            {
                return MenuButtonType.View;
            }
            else
            {
                skip = true;
                return null;
            }
        }
    }
}
