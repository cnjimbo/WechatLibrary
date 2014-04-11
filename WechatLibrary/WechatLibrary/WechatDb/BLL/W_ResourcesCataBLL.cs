using System.Collections.Generic;
using System.Linq;
using WechatLibrary.WechatDb.DAL;
using WechatLibrary.WechatDb.Model;

namespace WechatLibrary.WechatDb.BLL
{
    public class W_ResourcesCataBLL
    {
        // 增
        public bool Add(W_ResourcesCata resourcesCata)
        {
            return new W_ResourcesCataDAL().Add(resourcesCata);
        }

        // 删
        public bool Delete(W_ResourcesCata resourcesCata)
        {
            return new W_ResourcesCataDAL().Delete(resourcesCata);
        }

        // 改
        public bool Update(W_ResourcesCata resourcesCata)
        {
            return new W_ResourcesCataDAL().Update(resourcesCata);
        }

        // 查
        public W_ResourcesCata GetById(string kwid)
        {
            return new W_ResourcesCataDAL().GetById(kwid);
        }

        public List<W_ResourcesCata> GetAll()
        {
            return new W_ResourcesCataDAL().GetAll();
        }

        public List<W_ResourcesCata> GetByWeChatInfo(W_WeChatInfo weChatInfo)
        {
            return GetAll().Where(temp => temp.WID == weChatInfo.WID).ToList();
        }
    }
}
