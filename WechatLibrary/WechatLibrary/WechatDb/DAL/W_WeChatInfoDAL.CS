using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using Common.DataBase;
using WechatLibrary.WechatDb.Model;

namespace WechatLibrary.WechatDb.DAL
{
    public class W_WeChatInfoDAL
    {
        // 增
        public bool Add(W_WeChatInfo weChatInfo)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("insert into [W_WeChatInfo] values (@WID,@AppID,@AppSecret,@Token,@WechatID,@AppNamespace,@CreateTime,@IsDelete)", new SqlParameter("@WID", weChatInfo.WID), new SqlParameter("@AppID", weChatInfo.AppID), new SqlParameter("@AppSecret", weChatInfo.AppSecret), new SqlParameter("@Token", weChatInfo.Token), new SqlParameter("@WechatID", weChatInfo.WechatID), new SqlParameter("@AppNamespace", weChatInfo.AppNamespace), new SqlParameter("@CreateTime", weChatInfo.CreateTime), new SqlParameter("@IsDelete", weChatInfo.IsDelete));
                return rows > 0;
            }
        }

        // 删
        public bool Delete(W_WeChatInfo weChatInfo)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("delete from [W_WeChatInfo] where WID=@WID", new SqlParameter("@WID", weChatInfo.WID));
                return rows > 0;
            }
        }

        // 改
        public bool Update(W_WeChatInfo weChatInfo)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("update [W_WeChatInfo] set AppID=@AppID,AppSecret=@AppSecret,Token=@Token,WechatID=@WechatID,AppNamespace=@AppNamespace,CreateTime=@CreateTime,IsDelete=@IsDelete where WID=@WID", new SqlParameter("@WID", weChatInfo.WID), new SqlParameter("@AppID", weChatInfo.AppID), new SqlParameter("@AppSecret", weChatInfo.AppSecret), new SqlParameter("@Token", weChatInfo.Token), new SqlParameter("@WechatID", weChatInfo.WechatID), new SqlParameter("@AppNamespace", weChatInfo.AppNamespace), new SqlParameter("@CreateTime", weChatInfo.CreateTime), new SqlParameter("@IsDelete", weChatInfo.IsDelete));
                return rows > 0;
            }
        }

        // 查
        public W_WeChatInfo GetById(string wid)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                DataTable table = helper.ExecuteTable("select * from [W_WeChatInfo] where WID=@WID", new SqlParameter("@WID", wid));
                DataRowCollection rows = table.Rows;
                if (rows.Count > 0)
                {
                    DataRow row = rows[0];
                    return SqlHelper.DataRowToEntity<W_WeChatInfo>(row);
                }
                else
                {
                    return null;
                }
            }
        }

        public List<W_WeChatInfo> GetAll()
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                DataTable table = helper.ExecuteTable("select * from [W_WeChatInfo]");
                return SqlHelper.DataTableToEntities<W_WeChatInfo>(table) as List<W_WeChatInfo>;
            }
        }
    }
}
