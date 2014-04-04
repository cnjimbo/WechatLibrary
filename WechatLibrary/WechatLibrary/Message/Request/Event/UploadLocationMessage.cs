using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Request
{
    /// <summary>
    /// 上报地理位置事件。
    /// </summary>
    public class UploadLocationMessage : RequestMessageBase
    {
        /// <summary>
        /// 事件类型，LOCATION。
        /// </summary>
        public string Event
        {
            get;
            set;
        }

        /// <summary>
        /// 地理位置纬度。
        /// </summary>
        public string Latitude
        {
            get;
            set;
        }

        /// <summary>
        /// 地理位置经度。
        /// </summary>
        public string Longitude
        {
            get;
            set;
        }

        /// <summary>
        /// 地理位置精度。
        /// </summary>
        public string Precision
        {
            get;
            set;
        }

        /// <summary>
        /// 创建一个 UploadLocationMessage 的新实例。
        /// </summary>
        public UploadLocationMessage()
        {
        }

        /// <summary>
        /// 以已有消息创建一个 UploadLocationMessage 的新实例。
        /// </summary>
        /// <param name="message">已有消息。</param>
        public UploadLocationMessage(RequestMessageBase message)
        {
            RequestMessageBase.CopyProperties(message, this);
        }
    }
}
