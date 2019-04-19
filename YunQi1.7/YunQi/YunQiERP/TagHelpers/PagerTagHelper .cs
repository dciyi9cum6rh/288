using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

//using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using System.Text;
using System.Threading.Tasks;

namespace YunQiERP.TagHelpers
{
    public class PagerTagHelper : TagHelper
    {
        // 分頁基本資料
        public int CurrentPage { get; set; }  // 目前頁

        public int TotalPages { get; set; }   // 總頁數
        public int PageCount { get; set; }    // 分頁頁碼連結總數
        public int StartPage { get; set; }    // 分頁頁碼起始值
        public string PageLinkSize { get; set; }  // 頁碼超連結大小
        public string AClass { get; set; }  // 頁碼超連結之識別Class
        public string Url { get; set; }
        public int LinkType { get; set; }

        // 查訽參數
        public SortedList<string, object> Parameters { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            switch (LinkType)
            {
                case 0:
                    StartPage = 1; break;
                case 1:
                    if (CurrentPage < StartPage)
                        StartPage -= 1;
                    break;

                case 2:
                    if (CurrentPage >= StartPage + PageCount)
                        StartPage += 1;
                    break;

                case 3:
                    //if (CurrentPage < StartPage)
                    StartPage -= PageCount;
                    //if (StartPage < 1)
                    //    StartPage = 1;
                    break;

                case 4:
                    //if (CurrentPage > StartPage + PageCount)
                    StartPage += PageCount;
                    //if (StartPage > TotalPages)
                    //    StartPage = TotalPages;
                    break;

                case 5:
                    //if (CurrentPage >= StartPage + PageCount || CurrentPage <= StartPage - PageCount)
                    if (CurrentPage >= StartPage + PageCount || CurrentPage < StartPage)
                        StartPage = CurrentPage;
                    break;

                default:
                    break;
            }
            PageCount = PageCount < TotalPages ? PageCount : TotalPages;
            output.TagName = "div";
            // output.PreContent.SetContent("<ul class=\"pagination\">");
            output.PreContent.SetHtmlContent($"<ul class=\"pagination {PageLinkSize}\">");
            StringBuilder items = new StringBuilder();
            // 前一頁
            if (CurrentPage > 1)
            {
                string Pre = $"<li><a class=\"{AClass}\" href=\"";
                int cp = CurrentPage - 1 > 0 ? CurrentPage - 1 : CurrentPage;
                Pre += $"{Url}?page={cp}&LinkType={1}&StartPage={StartPage}";
                //foreach (var tmp in Parameters)
                //{
                //    Pre += $"&{tmp.Key}={tmp.Value}";
                //}
                Pre += "\" ><span class=\"glyphicon glyphicon-chevron-left\" aria-hidden=\"true\"></span></a>";
                items.Append(Pre);
            }
            // 前10(PageCount)頁
            if (StartPage - PageCount > 0)
            {
                string Pre10 = $"<li><a class=\"{AClass}\" href=\"";
                int cp10 = CurrentPage - PageCount > 0 ? CurrentPage - PageCount : CurrentPage;
                Pre10 += $"{Url}?page={cp10}&LinkType={3}&StartPage={StartPage}";
                //foreach (var tmp in Parameters)
                //{
                //    Pre10 += $"&{tmp.Key}={tmp.Value}";
                //}
                Pre10 += "\" ><span class=\"glyphicon glyphicon-backward\" aria-hidden=\"true\"></span></a>";
                items.Append(Pre10);
            }
            // 第一頁
            if (StartPage > 1)
            {
                // 只有分頁頁碼不包含第一頁時才顯示
                string First = "";
                if (1 == CurrentPage)
                    First = $"<li class=\"active\"><a class=\"{AClass}\"  href=\"";
                else
                    First = $"<li><a class=\"{AClass}\" href=\"";
                First += $"{Url}?page=1&LinkType={5}&StartPage={StartPage}";
                //foreach (var tmp in Parameters)
                //{
                //    First += $"&{tmp.Key}={tmp.Value}";
                //}
                First += "\" >1</a>";
                items.Append(First);
            }
            // 分頁頁碼
            //int sp = StartPage;
            if (StartPage > TotalPages - PageCount)
                StartPage = TotalPages - PageCount;
            if (StartPage < 1)
                StartPage = 1;
            for (var i = StartPage; i < StartPage + PageCount; i++)
            {
                string Html = "";
                if (i == CurrentPage)
                    Html += $"<li class=\"active\"><a class=\"{AClass}\"  href=\"";
                else
                    Html += $"<li><a class=\"{AClass}\" href=\"";
                Html += $"{Url}?page={i}&LinkType={5}&StartPage={StartPage}";
                //foreach(var tmp in Parameters)
                //{
                //    Html += $"&{tmp.Key}={tmp.Value}";
                //}
                Html += $"\" >{i}</a>";
                items.Append(Html);
            }
            // 最後一頁
            if (StartPage + PageCount - 1 < TotalPages)
            {
                // 只有分頁頁碼不包含最後一頁時才顯示
                string Last = "";
                if (TotalPages == CurrentPage)
                    Last = $"<li class=\"active\"><a class=\"{AClass}\" href=\"";
                else
                    Last = $"<li><a class=\"{AClass}\" href=\"";
                Last += $"{Url}?page={TotalPages}&LinkType={5}&StartPage={StartPage}";
                //foreach (var tmp in Parameters)
                //{
                //    Last += $"&{tmp.Key}={tmp.Value}";
                //}
                Last += $"\" >{TotalPages}</a>";
                items.Append(Last);
            }
            // 後10(PageCount)頁
            if (StartPage + PageCount < TotalPages)
            {
                string Post10 = $"<li><a class=\"{AClass}\" href=\"";
                int cp10 = CurrentPage + PageCount;
                Post10 += $"{Url}?page={cp10}&LinkType={4}&StartPage={StartPage}";
                //foreach (var tmp in Parameters)
                //{
                //    Post10 += $"&{tmp.Key}={tmp.Value}";
                //}
                Post10 += "\" ><span class=\"glyphicon glyphicon-forward\" aria-hidden=\"true\"></span></a>";
                items.Append(Post10);
            }
            // 後一頁
            if (CurrentPage < TotalPages)
            {
                string Post = $"<li><a class=\"{AClass}\" href=\"";
                int cp = CurrentPage + 1;
                Post += $"{Url}?page={cp}&LinkType={2}&StartPage={StartPage}";
                //foreach (var tmp in Parameters)
                //{
                //    Post += $"&{tmp.Key}={tmp.Value}";
                //}
                Post += "\" ><span class=\"glyphicon glyphicon-chevron-right\" aria-hidden=\"true\"></span></a>";
                items.Append(Post);
            }
            //output.Content.SetContent(items.ToString());
            output.Content.SetHtmlContent(items.ToString());
            output.Attributes.Clear();
            output.Attributes.Add("class", "container");
        }
    }

    //public enum LinkType:int
    //{
    //    none=0,          // 未按連結(即剛進入時)
    //    PreOnePage=1,    // 前一頁
    //    NextOnePage=2,   // 後一頁
    //    PreTenPage=3,    // 前10頁
    //    NextTenPage=4,   // 後10頁
    //    CettainPage=5    // 特定頁
    //}
}