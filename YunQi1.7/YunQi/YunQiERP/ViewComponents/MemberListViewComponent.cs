using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace YunQiERP.ViewComponents
{
    [Authorize]
    public class MemberListViewComponent : ViewComponent
    {
        private IMemberRepository IMR { get; set; }
        private IProductRepository IPR { get; set; }
        private IConfiguration config { get; set; }

        public MemberListViewComponent(IConfiguration configuration, IMemberRepository MemberRepository, IProductRepository ProductRepository)
        {
            IMR = MemberRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
            IPR = ProductRepository;
            IPR.constr = configuration.GetConnectionString("SqlConn");
            config = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(int Month, int Enabled, string MemberMobile = "", string MemberName = "", string ReferrerMobile = "", int MemberLevelId = 0, int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "page-link")
        {
            // 9-1.系統在ViewComponent【MemberList】中讀取Appsetting.json中的每頁筆數RowsPerPage以及分頁頁碼連結總數PageCount。
            int RowsPerPage = int.Parse(config["Page:RowsPerPage"]);
            int PageCount = int.Parse(config["Page:PageCount"]);
            // 9-2.系統在ViewComponent【MemberList】讀取會員總數。
            long memberCount = await IMR.GetMemberListCount(MemberMobile, MemberName, ReferrerMobile, MemberLevelId, Enabled);
            long BonusListCount = await IMR.GetMemberBonusListCount(Month, ReferrerMobile);
            // 9-3.系統依9-2傳回值將9傳送頁碼重設在Between 1 and (9讀取記錄筆數/RowsPerPage)+(9讀取記錄筆數%RowsPerPage==0?0:1)。
            int TotalPages = (int)(memberCount / RowsPerPage);
            if (memberCount % RowsPerPage > 0) TotalPages += 1;
            if (Page < 1) Page = 1;
            if (Page > TotalPages) Page = TotalPages;
            if (Page <= 0) Page = 1;
            // 9-4.系統計算資料Skip數=(9傳送頁碼(預設1)-1)*9-1讀取RowsPerPage。
            int Skip = (Page - 1) * RowsPerPage;
            // 9-5系統在ViewComponent【MemberListViewComponent】讀取會員清單：
            MemberViewModel Member = await IMR.GetMember(MemberMobile);
            List<MemberBonusListViewModel> o = await IPR.GetMemberBonusList(int.Parse(DateTime.Now.ToString("yyyyMM")), ReferrerMobile, Skip, RowsPerPage);
            List <MemberViewModel> lMLVM = await IMR.GetMemberList(MemberMobile, MemberName, ReferrerMobile, MemberLevelId, Enabled, Skip, RowsPerPage);
                        int ret = 0;
            foreach(MemberViewModel tmp in lMLVM)
            {
               lMLVM[ret].OrderBonus = await IMR.GetMemberOrderBonusSum(tmp.MemberMobile);
                ret++;
            }
            // 9-6.系統設定PagerTagHelper之相關參數
            int CurrentPage = Page;
            // 9-6-1.系統將管理者權限清單Session["EmployeeRights"]暫存在ViewBag.TR。
            ViewBag.TR = HttpContext.Session.GetObjectFromJson<List<int>>("EmployeeRights");
            // 9-7.系統回傳View(new MemberManageViewModel {
            //listMemberListViewModel = 9 - 5讀取值,
            //CurrentPage = 9 - 6設定值,
            //TotalPages = 9 - 6設定值,
            //PageCount = 9 - 6設定值,
            //StartPage = 9 - 6設定值,
            //Parameters = 9 - 6設定值
            //});
            return View(new MemberListManageViewModel
            {
                listMemberListViewModel = lMLVM,
                listMemberBonusListViewModel = o,               
                CurrentPage = CurrentPage,
                TotalPages = TotalPages,
                PageCount = PageCount,
                StartPage = StartPage,
                LinkType = LinkType,
                AClass = AClass
            });
        }
    }
}