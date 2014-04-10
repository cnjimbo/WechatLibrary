using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;

namespace WechatLibrary.WechatDb.Model
{
    public class W_ResourcesCata
    {
        public string CataID
        {
            get;
            set;
        }

        public string WID
        {
            get;
            set;
        }

        public string CataName
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
