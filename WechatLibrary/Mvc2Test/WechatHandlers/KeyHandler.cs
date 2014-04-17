using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WechatLibrary.Interface;
using WechatLibrary.Response;

// 请修改命名空间起始为数据库中注册的命名空间。
namespace TTTWX.Mvc2Test.WechatHandlers
{
    // 请实现相应的接口，对于菜单点击事件，请将类命名为Key+Handler，其中Key不区分大小写。
    public class KeyHandler : IMenuButtonHandler
    {
        public WechatLibrary.Response.ResponseResultBase ProcessRequest(WechatLibrary.Request.MenuButtonMessage message, ref bool dbProcess)
        {
            return new TextResult()
            {
                Content = "this is test"
            };
        }
    }
}
