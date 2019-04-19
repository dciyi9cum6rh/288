using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YunQiERP.ViewComponents
{
    //20181203
    [Authorize]
    public class MemberDevelopmentBonusDetailListViewComponent : ViewComponent
    {
        private IMemberRepository IMR { get; set; }
        private IConfiguration config { get; set; }

        public MemberDevelopmentBonusDetailListViewComponent(IConfiguration configuration, IMemberRepository MemberRepository)
        {
            IMR = MemberRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
            config = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(string ReferrerMobile, int Month, string AClass, int Page = 1, int StartPage = 1)
        {
            //9-1.系統在ViewComponent【MemberBonusDetailList】中讀取Appsetting.json中的每頁筆數RowsPerPage以及分頁頁碼連結總數PageCount。
            int RowsPerPage = int.Parse(config["Page:RowsPerPage"]);
            int PageCount = int.Parse(config["Page:PageCount"]);
            //9-2.系統在ViewComponent【MemberBonusDetailList】讀取批發會員獎金記錄總數。
            long MemberBonusCount = await IMR.GetMemberDevelopmentBonusDetailListCount(ReferrerMobile, Month);
            //9-3.系統依9-2傳回值將9傳送頁碼重設在Between 1 and(9讀取記錄筆數/RowsPerPage)+(9讀取記錄筆數%RowsPerPage==0?0:1)。
            int TotalPages = (int)(MemberBonusCount / RowsPerPage);
            if (MemberBonusCount % RowsPerPage > 0) TotalPages += 1;
            if (Page < 1) Page = 1;
            if (Page > TotalPages) Page = TotalPages;
            if (Page <= 0) Page = 1;
            //9-4.系統計算資料Skip數 = (9傳送頁碼(預設1) - 1)*9 - 1讀取RowsPerPage。
            int Skip = (Page - 1) * RowsPerPage;
            //9-5系統在ViewComponent【MemberBonusDetailListViewComponent】讀取批發會員獎金清單：
            List<MemberDevelopmentBonusDetailList> GMDBDL = await IMR.GetMemberDevelopmentBonusDetailList(ReferrerMobile, Month, Skip, RowsPerPage);
            //9-6.系統設定PagerTagHelper之相關參數
            int CurrentPage = Page;
            //9-6-1.系統將管理者權限清單Session["EmployeeRights"]暫存在ViewBag.TR。
            ViewBag.TR = HttpContext.Session.GetObjectFromJson<List<int>>("EmployeeRights");
            ViewBag.Page = Page;

            return View(new MemberDevelopmentBonusDetailListManageViewModel
            {
                listMemberDevelopmentBonusDetailListViewModel = GMDBDL,
                CurrentPage = CurrentPage,
                TotalPages = TotalPages,
                PageCount = PageCount,
                StartPage = StartPage,
                Parameters = Page,
                AClass = AClass,
                BonusListCount = MemberBonusCount,
            });
        }
    }
}