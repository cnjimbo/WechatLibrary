using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.WechatDb.Model
{
    public class W_KeyWord
    {
        public string KWID
        {
            get;
            set;
        }

        public string CataID
        {
            get;
            set;
        }

        public string WContent
        {
            get;
            set;
        }

        public string WOption
        {
            get;
            set;
        }

        public string WKey
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
