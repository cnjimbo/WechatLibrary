

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.WechatDb.DAL;
using WechatLibrary.WechatDb.Model;

namespace WechatLibrary.WechatDb.BLL
{
    public class W_ViewPageBLL
    {
        // 增
        public bool Add(W_ViewPage viewPage)
        {
            return new W_ViewPageDAL().Add(viewPage);
        }

        // 删
        public bool Delete(W_ViewPage viewPage)
        {
            return new W_ViewPageDAL().Delete(viewPage);
        }

        // 改
        public bool Update(W_ViewPage viewPage)
        {
            return new W_ViewPageDAL().Update(viewPage);
        }

        // 查
        public W_ViewPage GetById(string vpid)
        {
            return new W_ViewPageDAL().GetById(vpid);
        }

        public List<W_ViewPage> GetAll()
        {
            return new W_ViewPageDAL().GetAll();
        }

        public W_ViewPage GetByResourcesID(string resourcesId)
        {
            return GetAll().FirstOrDefault(temp => temp.VPID == resourcesId);
        }
    }
}
