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
    public class W_ViewPageItemDAL
    {// 增
        public bool Add(W_ViewPageItem viewPageItem)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("insert into [W_ViewPageItem] values (@VPItemID,@VPID,@VPItemTitle,@VPItemDescription,@VPItemUrl,@VPItemPicUrl,@CreateTime,@IsDelete)", new SqlParameter("@VPItemID", viewPageItem.VPItemID), new SqlParameter("@VPID", viewPageItem.VPID), new SqlParameter("@VPItemTitle", viewPageItem.VPItemTitle), new SqlParameter("@VPItemDescription", viewPageItem.VPItemDescription), new SqlParameter("@VPItemUrl", viewPageItem.VPItemUrl), new SqlParameter("@VPItemPicUrl", viewPageItem.VPItemPicUrl), new SqlParameter("@CreateTime", viewPageItem.CreateTime), new SqlParameter("@IsDelete", viewPageItem.IsDelete));
                return rows > 0;
            }
        }

        // 删
        public bool Delete(W_ViewPageItem viewPageItem)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("delete from [W_ViewPageItem] where VPItemID=@VPItemID", new SqlParameter("@VPItemID", viewPageItem.VPItemID));
                return rows > 0;
            }
        }

        // 改
        public bool Update(W_ViewPageItem viewPageItem)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("update [W_ViewPageItem] set VPID=@VPID,VPItemTitle=@VPItemTitle,VPItemDescription=@VPItemDescription,VPItemUrl=@VPItemUrl,VPItemPicUrl=@VPItemPicUrl,CreateTime=@CreateTime,IsDelete=@IsDelete where VPItemID=@VPItemID", new SqlParameter("@VPItemID", viewPageItem.VPItemID), new SqlParameter("@VPID", viewPageItem.VPID), new SqlParameter("@VPItemTitle", viewPageItem.VPItemTitle), new SqlParameter("@VPItemDescription", viewPageItem.VPItemDescription), new SqlParameter("@VPItemUrl", viewPageItem.VPItemUrl), new SqlParameter("@VPItemPicUrl", viewPageItem.VPItemPicUrl), new SqlParameter("@CreateTime", viewPageItem.CreateTime), new SqlParameter("@IsDelete", viewPageItem.IsDelete));
                return rows > 0;
            }
        }

        // 查
        public W_ViewPageItem GetById(string vpitemid)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                DataTable table = helper.ExecuteTable("select * from [W_ViewPageItem] where VPItemID=@VPItemID", new SqlParameter("@KWID", vpitemid));
                DataRowCollection rows = table.Rows;
                if (rows.Count > 0)
                {
                    DataRow row = rows[0];
                    return SqlHelper.DataRowToEntity<W_ViewPageItem>(row);
                }
                else
                {
                    return null;
                }
            }
        }

        public List<W_ViewPageItem> GetAll()
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                DataTable table = helper.ExecuteTable("select * from [W_ViewPageItem]");
                return SqlHelper.DataTableToEntities<W_ViewPageItem>(table) as List<W_ViewPageItem>;
            }
        }
    }
}
