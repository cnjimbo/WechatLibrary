using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.WechatDb.Model
{
    public class W_Menu
    {
        public string MenuID
        {
            get;
            set;
        }

        public string WID
        {
            get;
            set;
        }

        public string MenuName
        {
            get;
            set;
        }

        public string MenuType
        {
            get;
            set;
        }

        public string MenuURL
        {
            get;
            set;
        }

        public string MenuKey
        {
            get;
            set;
        }

        public string PMenuID
        {
            get;
            set;
        }

        public string ResponseType
        {
            get;
            set;
        }

        public string ResourcesID
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
