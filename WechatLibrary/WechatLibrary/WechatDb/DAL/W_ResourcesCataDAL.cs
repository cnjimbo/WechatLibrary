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
    public class W_ResourcesCataDAL
    {
        // 增
        public bool Add(W_ResourcesCata resourcesCata)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("insert into [W_ResourcesCata] values (@CataID,@WID,@CataName,@CreateTime,@IsDelete)", new SqlParameter("@CataID", resourcesCata.CataID), new SqlParameter("@WID", resourcesCata.WID), new SqlParameter("@CataName", resourcesCata.CataName), new SqlParameter("@CreateTime", resourcesCata.CreateTime), new SqlParameter("@IsDelete", resourcesCata.IsDelete));
                return rows > 0;
            }
        }

        // 删
        public bool Delete(W_ResourcesCata resourcesCata)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("delete from [W_ResourcesCata] where CataID=@CataID", new SqlParameter("@CataID", resourcesCata.CataID));
                return rows > 0;
            }
        }

        // 改
        public bool Update(W_ResourcesCata resourcesCata)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("update [W_ResourcesCata] set WID=@WID,CataName=@CataName,CreateTime=@CreateTime,IsDelete=@IsDelete where CataID=@CataID", new SqlParameter("@CataID", resourcesCata.CataID), new SqlParameter("@CataID", resourcesCata.CataID), new SqlParameter("@WID", resourcesCata.WID), new SqlParameter("@CataName", resourcesCata.CataName), new SqlParameter("@CreateTime", resourcesCata.CreateTime), new SqlParameter("@IsDelete", resourcesCata.IsDelete));
                return rows > 0;
            }
        }

        // 查
        public W_ResourcesCata GetById(string kwid)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                DataTable table = helper.ExecuteTable("select * from [W_ResourcesCata] where CataID=@CataID", new SqlParameter("@CataID", kwid));
                DataRowCollection rows = table.Rows;
                if (rows.Count > 0)
                {
                    DataRow row = rows[0];
                    return SqlHelper.DataRowToEntity<W_ResourcesCata>(row);
                }
                else
                {
                    return null;
                }
            }
        }

        public List<W_ResourcesCata> GetAll()
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                DataTable table = helper.ExecuteTable("select * from [W_ResourcesCata]");
                return SqlHelper.DataTableToEntities<W_ResourcesCata>(table) as List<W_ResourcesCata>;
            }
        }
    }
}
