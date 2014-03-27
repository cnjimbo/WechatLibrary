using System.Collections.Generic;

namespace WechatLibrary.Return
{
    /// <summary>
    /// 微信返回码消息类。
    /// </summary>
    public static class ReturnCode
    {
        private static readonly Dictionary<int, string> ERRORCODE;

        static ReturnCode()
        {
            ERRORCODE = new Dictionary<int, string>();
            ERRORCODE.Add(-1, "系统繁忙");
            ERRORCODE.Add(0, "请求成功");
            ERRORCODE.Add(40001, "获取access_token时AppSecret错误，或者access_token无效");
            ERRORCODE.Add(40002, "不合法的凭证类型");
            ERRORCODE.Add(40003, "不合法的OpenID");
            ERRORCODE.Add(40004, "不合法的媒体文件类型");
            ERRORCODE.Add(40005, "不合法的文件类型");
            ERRORCODE.Add(40006, "不合法的文件大小");
            ERRORCODE.Add(40007, "不合法的媒体文件id");
            ERRORCODE.Add(40008, "不合法的消息类型");
            ERRORCODE.Add(40009, "不合法的图片文件大小");
            ERRORCODE.Add(40010, "不合法的语音文件大小");
            ERRORCODE.Add(40011, "不合法的视频文件大小");
            ERRORCODE.Add(40012, "不合法的缩略图文件大小");
            ERRORCODE.Add(40013, "不合法的APPID");
            ERRORCODE.Add(40014, "不合法的access_token");
            ERRORCODE.Add(40015, "不合法的菜单类型");
            ERRORCODE.Add(40016, "不合法的按钮个数");
            ERRORCODE.Add(40017, "不合法的按钮个数");
            ERRORCODE.Add(40018, "不合法的按钮名字长度");
            ERRORCODE.Add(40019, "不合法的按钮KEY长度");
            ERRORCODE.Add(40020, "不合法的按钮URL长度");
            ERRORCODE.Add(40021, "不合法的菜单版本号");
            ERRORCODE.Add(40022, "不合法的子菜单级数");
            ERRORCODE.Add(40023, "不合法的子菜单按钮个数");
            ERRORCODE.Add(40024, "不合法的子菜单按钮类型");
            ERRORCODE.Add(40025, "不合法的子菜单按钮名字长度");
            ERRORCODE.Add(40026, "不合法的子菜单按钮KEY长度");
            ERRORCODE.Add(40027, "不合法的子菜单按钮URL长度");
            ERRORCODE.Add(40028, "不合法的自定义菜单使用用户");
            ERRORCODE.Add(40029, "不合法的oauth_code");
            ERRORCODE.Add(40030, "不合法的refresh_token");
            ERRORCODE.Add(40031, "不合法的openid列表");
            ERRORCODE.Add(40032, "不合法的openid列表长度");
            ERRORCODE.Add(40033, "不合法的请求字符，不能包含\\uxxxx格式的字符");
            ERRORCODE.Add(40035, "不合法的参数");
            ERRORCODE.Add(40038, "不合法的请求格式");
            ERRORCODE.Add(40039, "不合法的URL长度");
            ERRORCODE.Add(40050, "不合法的分组id");
            ERRORCODE.Add(40051, "分组名字不合法");
            ERRORCODE.Add(41001, "缺少access_token参数");
            ERRORCODE.Add(41002, "缺少appid参数");
            ERRORCODE.Add(41003, "缺少refresh_token参数");
            ERRORCODE.Add(41004, "缺少secret参数");
            ERRORCODE.Add(41005, "缺少多媒体文件数据");
            ERRORCODE.Add(41006, "缺少media_id参数");
            ERRORCODE.Add(41007, "缺少子菜单数据");
            ERRORCODE.Add(41008, "缺少oauth code");
            ERRORCODE.Add(41009, "缺少openid");
            ERRORCODE.Add(42001, "access_token超时");
            ERRORCODE.Add(42002, "refresh_token超时");
            ERRORCODE.Add(42003, "oauth_code超时");
            ERRORCODE.Add(43001, "需要GET请求");
            ERRORCODE.Add(43002, "需要POST请求");
            ERRORCODE.Add(43003, "需要HTTPS请求");
            ERRORCODE.Add(43004, "需要接收者关注");
            ERRORCODE.Add(43005, "需要好友关系");
            ERRORCODE.Add(44001, "多媒体文件为空");
            ERRORCODE.Add(44002, "POST的数据包为空");
            ERRORCODE.Add(44003, "图文消息内容为空");
            ERRORCODE.Add(44004, "文本消息内容为空");
            ERRORCODE.Add(45001, "多媒体文件大小超过限制");
            ERRORCODE.Add(45002, "消息内容超过限制");
            ERRORCODE.Add(45003, "标题字段超过限制");
            ERRORCODE.Add(45004, "描述字段超过限制");
            ERRORCODE.Add(45005, "链接字段超过限制");
            ERRORCODE.Add(45006, "图片链接字段超过限制");
            ERRORCODE.Add(45007, "语音播放时间超过限制");
            ERRORCODE.Add(45008, "图文消息超过限制");
            ERRORCODE.Add(45009, "接口调用超过限制");
            ERRORCODE.Add(45010, "创建菜单个数超过限制");
            ERRORCODE.Add(45015, "回复时间超过限制");
            ERRORCODE.Add(45016, "系统分组，不允许修改");
            ERRORCODE.Add(45017, "分组名字过长");
            ERRORCODE.Add(45018, "分组数量超过上限");
            ERRORCODE.Add(46001, "不存在媒体数据");
            ERRORCODE.Add(46002, "不存在的菜单版本");
            ERRORCODE.Add(46003, "不存在的菜单数据");
            ERRORCODE.Add(46004, "不存在的用户");
            ERRORCODE.Add(47001, "解析JSON/XML内容错误");
            ERRORCODE.Add(48001, "api功能未授权");
            ERRORCODE.Add(50001, "用户未授权该api");
        }

        /// <summary>
        /// 根据错误码获取错误消息。
        /// </summary>
        /// <param name="code">错误码。</param>
        /// <returns>错误消息。</returns>
        public static string GetMessage(int code)
        {
            if (ERRORCODE.ContainsKey(code) == true)
            {
                return ERRORCODE[code];
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
