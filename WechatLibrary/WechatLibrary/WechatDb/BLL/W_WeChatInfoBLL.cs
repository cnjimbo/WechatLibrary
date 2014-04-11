using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatLibrary.WechatDb.DAL;
using WechatLibrary.WechatDb.Model;

namespace WechatLibrary.WechatDb.BLL
{
    public class W_WeChatInfoBLL
    {
        // 增
        public bool Add(W_WeChatInfo weChatInfo)
        {
            return new W_WeChatInfoDAL().Add(weChatInfo);
        }

        // 删
        public bool Delete(W_WeChatInfo weChatInfo)
        {
            return new W_WeChatInfoDAL().Delete(weChatInfo);
        }

        // 改
        public bool Update(W_WeChatInfo weChatInfo)
        {
            return new W_WeChatInfoDAL().Update(weChatInfo);
        }

        // 查
        public W_WeChatInfo GetById(string wid)
        {
            return new W_WeChatInfoDAL().GetById(wid);
        }

        public List<W_WeChatInfo> GetAll()
        {
            return new W_WeChatInfoDAL().GetAll();
        }

        public W_WeChatInfo GetByWechatID(string wechatID)
        {
            return GetAll().Where(temp => temp.WechatID == wechatID).FirstOrDefault();
        }
    }
}
