using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Response
{
    /// <summary>
    /// 回复文本消息。
    /// </summary>
    public class ImageResult : ResponseResultBase
    {
        /// <summary>
        /// 通过上传多媒体文件，得到的 id。
        /// </summary>
        public string  MediaId { get; set; }
    }
}
