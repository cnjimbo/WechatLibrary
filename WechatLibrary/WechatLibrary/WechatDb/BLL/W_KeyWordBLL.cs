using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.WechatDb.DAL;
using WechatLibrary.WechatDb.Model;

namespace WechatLibrary.WechatDb.BLL
{
    public class W_KeyWordBLL
    {
        // 增
        public bool Add(W_KeyWord resourcesCata)
        {
            return new W_KeyWordDAL().Add(resourcesCata);
        }

        // 删
        public bool Delete(W_KeyWord resourcesCata)
        {
            return new W_KeyWordDAL().Delete(resourcesCata);
        }

        // 改
        public bool Update(W_KeyWord resourcesCata)
        {
            return new W_KeyWordDAL().Update(resourcesCata);
        }

        // 查
        public W_KeyWord GetById(string kwid)
        {
            return new W_KeyWordDAL().GetById(kwid);
        }

        public List<W_KeyWord> GetAll()
        {
            return new W_KeyWordDAL().GetAll();
        }

        public List<W_KeyWord> GetByResourcesCata(W_ResourcesCata resourcesCata)
        {
            return GetAll().Where(temp => temp.CataID == resourcesCata.CataID).ToList();
        }
    }
}
