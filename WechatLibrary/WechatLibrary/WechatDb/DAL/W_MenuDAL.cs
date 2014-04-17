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
    public class W_MenuDAL
    {
        // 增
        public bool Add(W_Menu menu)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("insert into [W_Menu] values (@MenuID,@WID,@MenuName,@MenuType,@MenuURL,@MenuKey,@PMenuID,@ResponseType,@ResourceID,@CreateTime,@IsDelete,@Sort)", new SqlParameter("@MenuID", menu.MenuID), new SqlParameter("@WID", menu.WID), new SqlParameter("@MenuName", menu.MenuName), new SqlParameter("@MenuType", menu.MenuType), new SqlParameter("@MenuURL", menu.MenuURL), new SqlParameter("@MenuKey", menu.MenuKey), new SqlParameter("@PMenuID", menu.PMenuID), new SqlParameter("@ResponseType", menu.ResponseType), new SqlParameter("@ResourecesID", menu.ResourcesID), new SqlParameter("@CreateTime", menu.CreateTime), new SqlParameter("@IsDelete", menu.IsDelete),new SqlParameter("@Sort",menu.Sort));
                return rows > 0;
            }
        }

        // 删
        public bool Delete(W_Menu menu)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("delete from [W_Menu] where MenuID=@MenuID", new SqlParameter("@MenuID", menu.MenuID));
                return rows > 0;
            }
        }

        // 改
        public bool Update(W_Menu menu)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                int rows = helper.ExecuteNonQuery("update [W_Menu] set WID=@WID,MenuName=@MenuName,MenuType=@MenuType,MenuURL=@MenuURL,MenuKey=@MenuKey,PMenuID=@PMenuID,ResponseType=@ResponseType,ResourcesID=@ResourcesID,CreateTime=@CreateTime,IsDelete=@IsDelete,Sort=@Sort where MenuID=@MenuID", new SqlParameter("@MenuID", menu.MenuID), new SqlParameter("@WID", menu.WID), new SqlParameter("@MenuName", menu.MenuName), new SqlParameter("@MenuType", menu.MenuType), new SqlParameter("@MenuURL", menu.MenuURL), new SqlParameter("@MenuKey", menu.MenuKey), new SqlParameter("@PMenuID", menu.PMenuID), new SqlParameter("@ResponseType", menu.ResponseType), new SqlParameter("@ResourcesID", menu.ResourcesID), new SqlParameter("@CreateTime", menu.CreateTime), new SqlParameter("@IsDelete", menu.IsDelete),new SqlParameter("@Sort",menu.Sort));
                return rows > 0;
            }
        }

        // 查
        public W_Menu GetById(string menuId)
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                DataTable table = helper.ExecuteTable("select * from [W_Menu] where MenuID=@MenuID", new SqlParameter("@MenuID", menuId));
                DataRowCollection rows = table.Rows;
                if (rows.Count > 0)
                {
                    DataRow row = rows[0];
                    return SqlHelper.DataRowToEntity<W_Menu>(row);
                }
                else
                {
                    return null;
                }
            }
        }

        public List<W_Menu> GetAll()
        {
            using (SqlHelper helper = WechatDataBaseHelper.Create())
            {
                DataTable table = helper.ExecuteTable("select * from [W_Menu]");
                return SqlHelper.DataTableToEntities<W_Menu>(table) as List<W_Menu>;
            }
        }
    }
}
