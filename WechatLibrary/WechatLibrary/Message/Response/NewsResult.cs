using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatLibrary.Response
{
    /// <summary>
    /// 回复图文消息。
    /// </summary>
    public class NewsResult : ResponseResultBase
    {
        private List<NewsArticle> articles;

        /// <summary>
        /// 图文消息项。
        /// </summary>
        public List<NewsArticle> Articles
        {
            get
            {
                articles = articles ?? new List<NewsArticle>();
                return articles;
            }
            set
            {
                articles = value;
            }
        }
    }
}
