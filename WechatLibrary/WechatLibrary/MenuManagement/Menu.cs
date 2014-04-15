using Common.Serialization;
using Common.Serialization.Json;
using Common.Web;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WechatLibrary.GlobalSupport;
using WechatLibrary.Return;

namespace WechatLibrary.MenuManagement
{
    /// <summary>
    /// 微信菜单。
    /// </summary>
    public partial class Menu
    {
        private List<MenuButton> button;

        /// <summary>
        /// 一级菜单数组，个数应为 1～3 个。
        /// </summary>
        [Json(Name = "button", CountGreaterThan = 0, CountLessThan = 4)]
        public List<MenuButton> Button
        {
            get
            {
                button = button ?? new List<MenuButton>();
                return button;
            }
            set
            {
                button = value;
            }
        }

        /// <summary>
        /// 从 Json 生成一个 Menu 实例。
        /// </summary>
        /// <param name="json">Json 字符串。</param>
        /// <returns>Menu 实例。</returns>
        public static Menu LoadByJson(string json)
        {
            return JsonHelper.Deserialize<Menu>(json);
        }

        /// <summary>
        /// 创建微信自定义菜单。
        /// </summary>
        /// <param name="wxm">微信菜单。</param>
        /// <param name="appId">AppId。</param>
        /// <returns>操作结果。</returns>
        public static ReturnBase Build(Menu wxm, string appId)
        {
            string requestBody;
            try
            {
                requestBody = JsonHelper.SerializeToJson(wxm);
            }
            catch (JsonCountException)
            {
                return new ReturnBase()
                {
                    ErrorCode = 40016,
                    ErrorMessage = "invalid button size"
                };
            }
            string url = string.Format(@"https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", AccessTokenManagement.Get(appId));
            string response = HttpHelper.Post(url, requestBody);
            return JsonHelper.Deserialize<ReturnBase>(response);
        }

        /// <summary>
        /// 将当前菜单配置到微信上。
        /// </summary>
        /// <param name="appId">AppId。</param>
        /// <returns>操作结果。</returns>
        public ReturnBase Build(string appId)
        {
            return Menu.Build(this, appId);
        }

        /// <summary>
        /// 获取当前部署在微信的自定义菜单的 Json 格式。
        /// </summary>
        /// <param name="appId">AppId。</param>
        /// <returns>Json。</returns>
        public static string GetJson(string appId)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", AccessTokenManagement.Get(appId));
            return HttpHelper.Get(url);
        }

        /// <summary>
        /// 获取当前部署在微信的自定义菜单。
        /// </summary>
        /// <param name="appId">AppId。</param>
        /// <returns>菜单。</returns>
        public static Menu Get(string appId)
        {
            return JsonHelper.Deserialize<Menu>(GetJson(appId));
        }

        /// <summary>
        /// 删除当前使用的自定义菜单。
        /// </summary>
        /// <param name="appId">AppId。</param>
        /// <returns>操作结果。</returns>
        public static ReturnBase Delete(string appId)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}", AccessTokenManagement.Get(appId));
            string responseBody = HttpHelper.Get(url);
            return JsonHelper.Deserialize<ReturnBase>(responseBody);
        }
    }
}
