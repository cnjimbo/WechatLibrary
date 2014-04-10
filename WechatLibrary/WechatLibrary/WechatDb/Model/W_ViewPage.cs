using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.WechatDb.Model
{
    public class W_ViewPage
    {
        public string VPID
        {
            get;
            set;
        }

        public string CataID
        {
            get;
            set;
        }

        public string VPTYpe
        {
            get;
            set;
        }

        public string VPTitle
        {
            get;
            set;
        }

        public string VPDescription
        {
            get;
            set;
        }

        public string VPURL
        {
            get;
            set;
        }

        public string ImgURL
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
