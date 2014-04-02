using Common.Serialization;
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
    public class Menu
    {
        private List<MenuButton> button;

        /// <summary>
        /// 一级菜单数组，个数应为 1～3 个。
        /// </summary>
        [Json(Name = "button", CollectionCountGreaterThan = 0, CollectionCountLessThan = 4)]
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

        public static ReturnBase Build(Menu wxm, string registerId)
        {
            var query = GlobalConfig.HandlerAssemblies.Where(temp => temp.Id == registerId);
            if (query.Count() > 0)
            {
                return Build(wxm, query.FirstOrDefault().Assembly);
            }
            else
            {
                return Build(wxm, Assembly.GetCallingAssembly());
            }
        }

        public static ReturnBase Build(Menu wxm, Assembly assembly)
        {
            string requestBody;
            try
            {
                requestBody = JsonHelper.SerializeToJson(wxm);
            }
            catch (JsonCollectionCountException)
            {
                return new ReturnBase()
                {
                    ErrorCode = 40016,
                    ErrorMessage = "invalid button size"
                };
            }
            string url = string.Format(@"https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", AccessTokenManagement.Get(assembly));
            string response = HttpHelper.Post(url, requestBody);
            return JsonHelper.Deserialize<ReturnBase>(response);
        }

        public static ReturnBase Build(Menu wxm)
        {
            return Build(wxm, Assembly.GetCallingAssembly());
        }

        public ReturnBase Build()
        {
            return Menu.Build(this);
        }

        /// <summary>
        /// 获取当前部署在微信的自定义菜单的 Json 格式。
        /// </summary>
        /// <param name="assembly">注册的程序集。</param>
        /// <returns>Json。</returns>
        public static string GetJson(Assembly assembly)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", AccessTokenManagement.Get(assembly));
            return HttpHelper.Get(url);
        }

        /// <summary>
        /// 获取当前部署在微信的自定义菜单的 Json 格式。
        /// </summary>
        /// <param name="registerId">注册的 Id。</param>
        /// <returns>Json。</returns>
        public static string GetJson(string registerId)
        {
            var query = GlobalConfig.HandlerAssemblies.Where(temp => temp.Id == registerId);
            if (query.Count() > 0)
            {
                return GetJson(query.FirstOrDefault().Assembly);
            }
            else
            {
                return GetJson(Assembly.GetCallingAssembly());
            }
        }

        /// <summary>
        /// 获取当前部署在微信的自定义菜单的 Json 格式。
        /// </summary>
        /// <returns>Json。</returns>
        public static string GetJson()
        {
            return GetJson(Assembly.GetCallingAssembly());
        }

        /// <summary>
        /// 获取当前部署在微信的自定义菜单。
        /// </summary>
        /// <returns>菜单。</returns>
        public static Menu Get()
        {
            return JsonHelper.Deserialize<Menu>(GetJson());
        }

        /// <summary>
        /// 获取当前部署在微信的自定义菜单。
        /// </summary>
        /// <param name="registerId">注册的 Id。</param>
        /// <returns>菜单。</returns>
        public static Menu Get(string registerId)
        {
            var query = GlobalConfig.HandlerAssemblies.Where(temp => temp.Id == registerId);
            if (query.Count() > 0)
            {
                return JsonHelper.Deserialize<Menu>(GetJson(query.FirstOrDefault().Assembly));
            }
            else
            {
                return JsonHelper.Deserialize<Menu>(GetJson(Assembly.GetCallingAssembly()));
            }
        }

        /// <summary>
        /// 获取当前部署在微信的自定义菜单。
        /// </summary>
        /// <param name="assembly">注册的程序集。</param>
        /// <returns>菜单。</returns>
        public static Menu Get(Assembly assembly)
        {
            if (assembly == null)
            {
                assembly = Assembly.GetCallingAssembly();
            }
            return JsonHelper.Deserialize<Menu>(GetJson(assembly));
        }

        /// <summary>
        /// 删除当前使用的自定义菜单。
        /// </summary>
        /// <returns>操作结果。</returns>
        public static ReturnBase Delete()
        {
            return Delete(Assembly.GetCallingAssembly());
        }

        /// <summary>
        /// 删除当前使用的自定义菜单。
        /// </summary>
        /// <param name="registerId">注册的 Id。</param>
        /// <returns>操作结果。</returns>
        public static ReturnBase Delete(string registerId)
        {
            var query = GlobalConfig.HandlerAssemblies.Where(temp => temp.Id == registerId);
            if (query.Count() > 0)
            {
                return Delete(query.FirstOrDefault().Assembly);
            }
            else
            {
                return Delete(Assembly.GetCallingAssembly());
            }
        }

        /// <summary>
        /// 删除当前使用的自定义菜单。
        /// </summary>
        /// <param name="assembly">注册的程序集。</param>
        /// <returns>操作结果。</returns>
        public static ReturnBase Delete(Assembly assembly)
        {
            assembly = assembly ?? Assembly.GetCallingAssembly();
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}", AccessTokenManagement.Get(assembly));
            string responseBody = HttpHelper.Get(url);
            return JsonHelper.Deserialize<ReturnBase>(responseBody);
        }
    }
}
