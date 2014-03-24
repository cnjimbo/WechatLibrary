using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Message.Response
{
    /// <summary>
    /// 回复图文消息。
    /// </summary>
    public class NewsResult : ResponseResultBase
    {
        private List<NewsArticle> articles;
        public List<NewsArticle> Articles
        {
            get
            {
                if (articles == null)
                {
                    articles = new List<NewsArticle>();
                }
                return articles;
            }
            set
            {
                articles = value;
            }
        }
    }
}
