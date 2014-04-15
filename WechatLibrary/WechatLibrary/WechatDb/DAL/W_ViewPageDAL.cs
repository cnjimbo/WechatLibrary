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
    public class W_ViewPageDAL
    {
        // 增
        public bool Add(W_ViewPage viewPage)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("insert into [W_ViewPage] values (@VPID,@CataID,@VPTYpe,@VPTitle,@VPDescription,@VPURL,@ImgURL,@CreateTime,@IsDelete)", new SqlParameter("@VPID", viewPage.VPID), new SqlParameter("@CataID", viewPage.CataID), new SqlParameter("@VPTYpe", viewPage.VPTYpe), new SqlParameter("@VPTitle", viewPage.VPTitle), new SqlParameter("@VPDescription", viewPage.VPDescription), new SqlParameter("@VPURL", viewPage.VPURL), new SqlParameter("@ImgURL", viewPage.ImgURL), new SqlParameter("@CreateTime", viewPage.CreateTime), new SqlParameter("@IsDelete", viewPage.IsDelete));
                return rows > 0;
            }
        }

        // 删
        public bool Delete(W_ViewPage viewPage)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("delete from [W_ViewPage] where VPID=@VPID", new SqlParameter("@VPID", viewPage.VPID));
                return rows > 0;
            }
        }

        // 改
        public bool Update(W_ViewPage viewPage)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("update [W_ViewPage] set CataID=@CataID,VPTYpe=@VPTYpe,VPTitle=@VPTitle,VPDescription=@VPDescription,VPURL=@VPURL,ImgURL=@ImgURL,CreateTime=@CreateTime,IsDelete=@IsDelete where VPID=@VPID", new SqlParameter("@VPID", viewPage.VPID), new SqlParameter("@CataID", viewPage.CataID), new SqlParameter("@VPTYpe", viewPage.VPTYpe), new SqlParameter("@VPTitle", viewPage.VPTitle), new SqlParameter("@VPDescription", viewPage.VPDescription), new SqlParameter("@VPURL", viewPage.VPURL), new SqlParameter("@ImgURL", viewPage.ImgURL), new SqlParameter("@CreateTime", viewPage.CreateTime), new SqlParameter("@IsDelete", viewPage.IsDelete));
                return rows > 0;
            }
        }

        // 查
        public W_ViewPage GetById(string vpid)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                DataTable table = helper.ExecuteTable("select * from [W_ViewPage] where VPID=@VPID", new SqlParameter("@VPID", vpid));
                DataRowCollection rows = table.Rows;
                if (rows.Count > 0)
                {
                    DataRow row = rows[0];
                    return SqlHelper.DataRowToEntity<W_ViewPage>(row);
                }
                else
                {
                    return null;
                }
            }
        }

        public List<W_ViewPage> GetAll()
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                DataTable table = helper.ExecuteTable("select * from [W_ViewPage]");
                return SqlHelper.DataTableToEntities<W_ViewPage>(table) as List<W_ViewPage>;
            }
        }
    }
}
