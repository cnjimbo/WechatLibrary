using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.WechatDb.DAL;
using WechatLibrary.WechatDb.Model;

namespace WechatLibrary.WechatDb.BLL
{
    public class W_MenuBLL
    {
        // 增
        public bool Add(W_Menu menu)
        {
            return new W_MenuDAL().Add(menu);
        }

        // 删
        public bool Delete(W_Menu menu)
        {
            return new W_MenuDAL().Delete(menu);
        }

        // 改
        public bool Update(W_Menu menu)
        {
            return new W_MenuDAL().Update(menu);
        }

        // 查
        public W_Menu GetById(string menuId)
        {
            return new W_MenuDAL().GetById(menuId);
        }

        public List<W_Menu> GetAll()
        {
            return new W_MenuDAL().GetAll();
        }

        public W_Menu GetByWeChatInfo(W_WeChatInfo weChatInfo)
        {
            return GetAll().Where(temp => temp.WID == weChatInfo.WID).FirstOrDefault();
        }
    }
}
