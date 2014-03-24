using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Message.Request.Event
{
    public class UploadLocationRequest : RequestBase
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
    }
}
