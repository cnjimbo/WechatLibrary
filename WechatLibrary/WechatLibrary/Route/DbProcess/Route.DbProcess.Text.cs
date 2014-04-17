using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using WechatLibrary.Request;
using WechatLibrary.Response;
using WechatLibrary.WechatDb.BLL;
using WechatLibrary.WechatDb.Model;

namespace WechatLibrary
{
    internal partial class Route
    {
        private void DoResources(W_Resources resources)
        {
            if (resources.RType == "text")
            {
                this.Response = new TextResult()
                {
                    Content = resources.RContent
                };
            }
            else if (resources.RType == "image")
            {
                this.Response = new ImageResult()
                {
                    MediaId = resources.MediaID
                };
            }
            else if (resources.RType == "voice")
            {
                this.Response = new VoiceResult()
                {
                    MediaId = resources.MediaID
                };
            }
            else if (resources.RType == "video")
            {
                this.Response = new VideoResult()
                {
                    Description = resources.RDescription,
                    MediaId = resources.MediaID,
                    Title = resources.RTitle
                };
            }
            else if (resources.RType == "music")
            {
                this.Response = new MusicResult()
                {
                    Description = resources.RDescription,
                    HQMusicUrl = resources.RHURL,
                    MusicURL = resources.RURL,
                    ThumbMediaId = resources.MediaID,
                    Title = resources.RTitle
                };
            }
        }

        private void DoViewPage(W_ViewPage viewPage)
        {
            NewsResult result = new NewsResult();

            result.Articles.Add(new NewsArticle()
            {
                Title = viewPage.VPTitle,
                Description = viewPage.VPDescription,
                Url = viewPage.VPURL,
                PicUrl = viewPage.ImgURL
            });

            if (viewPage.VPTYpe == "single")
            {
                this.Response = result;
                return;
            }

            W_ViewPageItemBLL bll = new W_ViewPageItemBLL();
            List<W_ViewPageItem> childArticles = bll.GetByViewPage(viewPage);
            foreach (W_ViewPageItem viewPageItem in childArticles)
            {
                result.Articles.Add(new NewsArticle()
                {
                    Title = viewPageItem.VPItemTitle,
                    Description = viewPageItem.VPItemDescription,
                    Url = viewPageItem.VPItemUrl,
                    PicUrl = viewPageItem.VPItemPicUrl
                });
            }

            this.Response = result;
        }

        private void DoKeyWord(W_KeyWord keyWord)
        {
            if (string.Equals(keyWord.ResponseType, "viewPage", StringComparison.OrdinalIgnoreCase) == true)
            {
                W_ViewPageBLL bll = new W_ViewPageBLL();
                W_ViewPage viewPage = bll.GetByResourcesID(keyWord.ResourcesID);
                DoViewPage(viewPage);
            }
            else
            {
                W_ResourcesBLL bll = new W_ResourcesBLL();
                W_Resources resources = bll.GetByResourcesID(keyWord.ResourcesID);
                DoResources(resources);
            }
        }

        internal void DbProcessText(TextMessage message)
        {
            W_WeChatInfoBLL weChatInfoBll = new W_WeChatInfoBLL();
            W_WeChatInfo weChatInfo = weChatInfoBll.GetByWechatID(message.ToUserName);
            if (weChatInfo == null)
            {
                return;
            }
            W_ResourcesCataBLL resourcesCataBll = new W_ResourcesCataBLL();
            List<W_ResourcesCata> resourcesCataList = resourcesCataBll.GetByWeChatInfo(weChatInfo);
            if (resourcesCataList.Count <= 0)
            {
                return;
            }
            W_KeyWordBLL keyWordBll = new W_KeyWordBLL();
            foreach (W_ResourcesCata resourcesCata in resourcesCataList)
            {
                List<W_KeyWord> keyWordList = keyWordBll.GetByResourcesCata(resourcesCata);
                foreach (W_KeyWord keyWord in keyWordList)
                {
                    if (keyWord.WOption == "Equals" && keyWord.WContent == message.Content)
                    {
                        DoKeyWord(keyWord);
                        return;
                    }
                    else if (keyWord.WOption == "EqualsIgnoreCase" &&
                             string.Equals(keyWord.WContent, message.Content, StringComparison.OrdinalIgnoreCase) == true)
                    {
                        DoKeyWord(keyWord);
                        return;
                    }
                    else if (keyWord.WOption == "Contains" && string.IsNullOrEmpty(message.Content) == false && message.Content.Contains(keyWord.WContent) == true)
                    {
                        DoKeyWord(keyWord);
                        return;
                    }
                    else if (keyWord.WOption == "ContainsIgnoreCase" && string.IsNullOrEmpty(message.Content) == false && message.Content.IndexOf(keyWord.WContent, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        DoKeyWord(keyWord);
                        return;
                    }
                }
            }
        }
    }
}
