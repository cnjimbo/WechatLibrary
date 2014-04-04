using System.Linq;

namespace WechatLibrary
{
    internal partial class Route
    {
        /// <summary>
        /// 是否使用注册的程序集。
        /// </summary>
        internal void IsUseRegisterAssembly()
        {
            var query = GlobalConfig.HandlerAssemblies.Where(temp => temp.WechatId == Request.ToUserName);
            if (query.Count() > 0)
            {
                this.Assembly = query.First().Assembly;
            }
        }
    }
}
