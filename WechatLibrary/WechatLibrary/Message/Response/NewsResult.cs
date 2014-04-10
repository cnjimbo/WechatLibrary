using System.Collections.Generic;
using System.Text;

namespace WechatLibrary.Response
{
    /// <summary>
    /// 回复图文消息。
    /// </summary>
    public class NewsResult : ResponseResultBase
    {
        private List<NewsArticle> _articles;

        /// <summary>
        /// 图文消息项。
        /// </summary>
        public List<NewsArticle> Articles
        {
            get
            {
                _articles = _articles ?? new List<NewsArticle>();
                return _articles;
            }
            set
            {
                _articles = value;
            }
        }

        /// <summary>
        /// 创建一条回复图文消息。
        /// </summary>
        public NewsResult()
        {
            MsgType = "news";
        }

        internal override string Serialize()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[{3}]]></MsgType>", ToUserName, FromUserName, CreateTime, MsgType));
            sb.Append(string.Format("<ArticleCount>{0}</ArticleCount>", Articles.Count));
            sb.Append("<Articles>");
            foreach (var article in Articles)
            {
                sb.Append(article.Serialize());
            }
            sb.Append("</Articles></xml>");
            return sb.ToString();
        }
    }
}
