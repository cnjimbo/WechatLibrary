using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Response
{
    /// <summary>
    /// 回复视频消息。
    /// </summary>
    public class VideoResult:ResponseResultBase
    {
        /// <summary>
        /// 通过上传多媒体文件，得到的 id。
        /// </summary>
        public string MediaId
        {
            get;
            set;
        }
        /// <summary>
        /// 视频消息的标题。
        /// </summary>
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 视频消息的描述。
        /// </summary>
        public string Description
        {
            get;
            set;
        }
    }
}
