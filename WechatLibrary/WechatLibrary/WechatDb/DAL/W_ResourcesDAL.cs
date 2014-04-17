using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common.DataBase;
using WechatLibrary.WechatDb.Model;

namespace WechatLibrary.WechatDb.DAL
{
    public class W_ResourcesDAL
    {
        // 增
        public bool Add(W_Resources resources)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("insert into [W_Resources] values (@RID,@CataID,@RContent,@RURL,@RHURL,@RType,@RTitle,@RDescription,@MediaID,@CreateTime,@IsDelete)", new SqlParameter("@RID", resources.RID), new SqlParameter("@CataID", resources.CataID), new SqlParameter("@RContent", resources.RContent), new SqlParameter("@RURL", resources.RURL), new SqlParameter("@RHURL", resources.RHURL), new SqlParameter("@RType", resources.RType), new SqlParameter("@RTitle", resources.RTitle), new SqlParameter("@RDescription", resources.RDescription), new SqlParameter("@MediaID", resources.MediaID), new SqlParameter("@CreateTime", resources.CreateTime), new SqlParameter("@IsDelete", resources.IsDelete));
                return rows > 0;
            }
        }

        // 删
        public bool Delete(W_Resources resources)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("delete from [W_Resources] where RID=@RID", new SqlParameter("@RID", resources.RID));
                return rows > 0;
            }
        }

        // 改
        public bool Update(W_Resources resources)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("update [W_Resources] set CataID=@CataID,RContent=@RContent,RURL=@RURL,RHURL=@RHURL,RType=@RType,RTitle=@RTitle,RDescription=@RDescription,MediaID=@MediaID,CreateTime=@CreateTime,IsDelete=@IsDelete where RID=@RID", new SqlParameter("@RID", resources.RID), new SqlParameter("@CataID", resources.CataID), new SqlParameter("@RContent", resources.RContent), new SqlParameter("@RURL", resources.RURL), new SqlParameter("@RHURL", resources.RHURL), new SqlParameter("@RType", resources.RType), new SqlParameter("@RTitle", resources.RTitle), new SqlParameter("@RDescription", resources.RDescription), new SqlParameter("@MediaID", resources.MediaID), new SqlParameter("@CreateTime", resources.CreateTime), new SqlParameter("@IsDelete", resources.IsDelete));
                return rows > 0;
            }
        }

        // 查
        public W_Resources GetById(string rid)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                DataTable table = helper.ExecuteTable("select * from [W_Resources] where RID=@RID", new SqlParameter("@RID", rid));
                DataRowCollection rows = table.Rows;
                if (rows.Count > 0)
                {
                    DataRow row = rows[0];
                    return SqlHelper.DataRowToEntity<W_Resources>(row);
                }
                else
                {
                    return null;
                }
            }
        }

        public List<W_Resources> GetAll()
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                DataTable table = helper.ExecuteTable("select * from [W_Resources]");
                return SqlHelper.DataTableToEntities<W_Resources>(table) as List<W_Resources>;
            }
        }
    }
}
