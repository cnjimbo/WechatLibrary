using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.WechatDb.DAL;
using WechatLibrary.WechatDb.Model;

namespace WechatLibrary.WechatDb.BLL
{
 public   class W_ResourcesBLL
    {
        // 增
        public bool Add(W_Resources resources)
        {
            return new W_ResourcesDAL().Add(resources);
        }

        // 删
        public bool Delete(W_Resources resources)
        {
            return new W_ResourcesDAL().Delete(resources);
        }

        // 改
        public bool Update(W_Resources resources)
        {
            return new W_ResourcesDAL().Update(resources);
        }

        // 查
        public W_Resources GetById(string rid)
        {
            return new W_ResourcesDAL().GetById(rid);
        }

        public List<W_Resources> GetAll()
        {
            return new W_ResourcesDAL().GetAll();
        }

        public W_Resources GetByResourcesID(string resourcesId)
        {
            return GetAll().FirstOrDefault(temp => temp.RID == resourcesId);
        }
    }
}
