using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.WechatDb.Model
{
    public class W_UserInfo
    {
        public string OpenID
        {
            get;
            set;
        }

        public string NickName
        {
            get;
            set;
        }

        public byte? Sex
        {
            get;
            set;
        }

        public string Province
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string Country
        {
            get;
            set;
        }

        public string HeadImgURL
        {
            get;
            set;
        }

        public string Privilege
        {
            get;
            set;
        }

        public byte? Subscribe
        {
            get;
            set;
        }

        public string Subscribe_time
        {
            get;
            set;
        }

        public DateTime? CreateTime
        {
            get;
            set;
        }

        public DateTime? LastUpdateTime
        {
            get;
            set;
        }

        public string WID
        {
            get;
            set;
        }
    }
}
