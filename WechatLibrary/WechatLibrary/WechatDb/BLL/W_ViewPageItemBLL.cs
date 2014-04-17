using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.WechatDb.DAL;
using WechatLibrary.WechatDb.Model;

namespace WechatLibrary.WechatDb.BLL
{
    public class W_ViewPageItemBLL
    {

        // 增
        public bool Add(W_ViewPageItem viewPageItem)
        {
            return new W_ViewPageItemDAL().Add(viewPageItem);
        }

        // 删
        public bool Delete(W_ViewPageItem viewPageItem)
        {
            return new W_ViewPageItemDAL().Delete(viewPageItem);
        }

        // 改
        public bool Update(W_ViewPageItem viewPageItem)
        {
            return new W_ViewPageItemDAL().Update(viewPageItem);
        }

        // 查
        public W_ViewPageItem GetById(string vpitemid)
        {
            return new W_ViewPageItemDAL().GetById(vpitemid);
        }

        public List<W_ViewPageItem> GetAll()
        {
            return new W_ViewPageItemDAL().GetAll();
        }

        public List<W_ViewPageItem> GetByViewPage(W_ViewPage viewPage)
        {
            return GetAll().Where(temp => temp.VPID == viewPage.VPID).ToList();
        }
    }
}
