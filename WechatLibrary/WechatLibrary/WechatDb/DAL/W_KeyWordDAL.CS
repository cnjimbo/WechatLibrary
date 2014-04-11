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
    public class W_KeyWordDAL
    {
        // 增
        public bool Add(W_KeyWord keyWord)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("insert into [W_KeyWord] values (@KWID,@CataID,@WContent,@WOption,@WKey,@ResponseType,@ResourcesID,@CreateTime,@IsDelete)", new SqlParameter("@KWID", keyWord.KWID), new SqlParameter("@CataID", keyWord.CataID), new SqlParameter("@WContent", keyWord.WContent), new SqlParameter("@WOption", keyWord.WOption), new SqlParameter("@WKey", keyWord.WKey), new SqlParameter("@ResponseType", keyWord.ResponseType), new SqlParameter("@ResourecesID", keyWord.ResourcesID), new SqlParameter("@CreateTime", keyWord.CreateTime), new SqlParameter("@IsDelete", keyWord.IsDelete));
                return rows > 0;
            }
        }

        // 删
        public bool Delete(W_KeyWord keyWord)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("delete from [W_KeyWord] where KWID=@KWID", new SqlParameter("@KWID", keyWord.KWID));
                return rows > 0;
            }
        }

        // 改
        public bool Update(W_KeyWord keyWord)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("update [W_KeyWord] set CataID=@CataID,WContent=@WContent,WOption=@WOption,WKey=@WKey,ResponseType=@ResponseType,ResourcesID=@ResourcesID,CreateTime=@CreateTime,IsDelete=@IsDelete", new SqlParameter("@CataID", keyWord.CataID), new SqlParameter("@WContent", keyWord.WContent), new SqlParameter("@WOption", keyWord.WOption), new SqlParameter("@WKey", keyWord.WKey), new SqlParameter("@ResponseType", keyWord.ResponseType), new SqlParameter("@ResourcesID", keyWord.ResourcesID), new SqlParameter("@CreateTime", keyWord.CreateTime), new SqlParameter("@IsDelete", keyWord.IsDelete));
                return rows > 0;
            }
        }

        // 查
        public W_KeyWord GetById(string kwid)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                DataTable table = helper.ExecuteTable("select * from [W_KeyWord] where KWID=@KWID", new SqlParameter("@KWID", kwid));
                DataRowCollection rows = table.Rows;
                if (rows.Count > 0)
                {
                    DataRow row = rows[0];
                    return SqlHelper.DataRowToEntity<W_KeyWord>(row);
                }
                else
                {
                    return null;
                }
            }
        }

        public List<W_KeyWord> GetAll()
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                DataTable table = helper.ExecuteTable("select * from [W_KeyWord]");
                return SqlHelper.DataTableToEntities<W_KeyWord>(table) as List<W_KeyWord>;
            }
        }
    }
}
