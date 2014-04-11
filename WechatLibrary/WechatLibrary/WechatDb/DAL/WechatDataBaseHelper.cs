using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common.DataBase;

namespace WechatLibrary.WechatDb.DAL
{
    internal class WechatDataBaseHelper
    {
        internal static SqlHelper Create()
        {
            return new SqlHelper(System.Configuration.ConfigurationManager.AppSettings["WechatDataBaseConnectionString"], typeof(SqlConnection));
        }
    }
}
