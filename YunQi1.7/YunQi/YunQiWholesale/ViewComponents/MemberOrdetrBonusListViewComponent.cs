using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YunQiERP.ViewComponents
{
    [Authorize]
    public class MemberOrderBonusListViewComponent : ViewComponent
    {
        private IMemberRepository IMR { get; set; }
        private IConfiguration config { get; set; }

        public MemberOrderBonusListViewComponent(IConfiguration configuration, IMemberRepository MemberRepository)
        {
            IMR = MemberRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
            config = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(string MemberMobile, int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "page-link")
        {
            // 9-1.系統在ViewComponent【MemberFavoriteList】中讀取Appsetting.json中的每頁筆數RowsPerPage以及分頁頁碼連結總數PageCount。
            int RowsPerPage = int.Parse(config["Page:FRowsPerPage"]);
            int PageCount = int.Parse(config["Page:PageCount"]);
            // 9-2.系統在ViewComponent【MemberFavoriteList】讀取我的最愛總數。

            long memberCount = await IMR.GetMemberOrderBonusListCount(MemberMobile);
            // 9-3.系統依9-2傳回值將9傳送頁碼重設在Between 1 and (9讀取記錄筆數/RowsPerPage)+(9讀取記錄筆數%RowsPerPage==0?0:1)。
            int TotalPages = (int)(memberCount / RowsPerPage);
            if (memberCount % RowsPerPage > 0) TotalPages += 1;
            if (Page < 1) Page = 1;
            if (Page > TotalPages) Page = TotalPages;
            if (Page <= 0) Page = 1;
            // 9-4.系統計算資料Skip數=(9傳送頁碼(預設1)-1)*9-1讀取RowsPerPage。
            int Skip = (Page - 1) * RowsPerPage;
            // 9-5系統在ViewComponent【MemberFavoriteListViewComponent】讀取商品清單：
            List<MemberOrderBonusListViewModel> lMLVM = await IMR.GetMemberOrderBonusList(MemberMobile, Skip, RowsPerPage);
            // 9-6.系統設定PagerTagHelper之相關參數
            int CurrentPage = Page;
            
            return View(new MemberOrderBonusListManageViewModel
            {
                listMemberOrderBonusListViewModel = lMLVM,
                CurrentPage = CurrentPage,
                TotalPages = TotalPages,
                PageCount = PageCount,
                StartPage = StartPage,
                LinkType = LinkType                     
            });
        }
    }
}
