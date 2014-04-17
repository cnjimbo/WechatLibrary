using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.WechatDb.Model
{
    public class W_ViewPageItem
    {
        public string VPItemID
        {
            get;
            set;
        }

        public string VPID
        {
            get;
            set;
        }

        public string VPItemTitle
        {
            get;
            set;
        }

        public string VPItemDescription
        {
            get;
            set;
        }

        public string VPItemUrl
        {
            get;
            set;
        }

        public string VPItemPicUrl
        {
            get;
            set;
        }

        public DateTime CreateTime
        {
            get;
            set;
        }

        public byte IsDelete
        {
            get;
            set;
        }
    }
}
