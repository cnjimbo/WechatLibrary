using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;

namespace WechatLibrary.Request
{
    /// <summary>
    /// 图片消息。
    /// </summary>
    public class ImageMessage : RequestMessageBase
    {
        /// <summary>
        /// 图片链接。
        /// </summary>
        public string PicUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 图片消息媒体 id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId
        {
            get;
            set;
        }

        /// <summary>
        /// 消息 id，64 位整型。
        /// </summary>
        public long MsgId
        {
            get;
            set;
        }

        public ImageMessage()
        {
        }

        public ImageMessage(RequestMessageBase message)
        {
            RequestMessageBase.CopyProperties(message, this);
        }
    }
}
