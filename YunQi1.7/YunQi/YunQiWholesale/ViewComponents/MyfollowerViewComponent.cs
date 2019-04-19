using DataModel;
using IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YunQiERP;

namespace YunQiWholesale.ViewComponents
{
    public class MyfollowerViewComponent : ViewComponent
    {
        private IMemberRepository IMR { get; set; }
        private IConfiguration config { get; set; }

        public MyfollowerViewComponent(IConfiguration configuration, IMemberRepository MemberRepository)
        {
            IMR = MemberRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
            config = configuration;
        }

        //test
        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    return View();
        //}

        //20181119 ---棋
        public async Task<IViewComponentResult> InvokeAsync(string MemberMobile, DateTime? sDate, DateTime? eDate, string ReferrerMobile, int Page = 1, int StartPage = 1)
        {
            // 9-1.系統在ViewComponent【MemberOrderList】中讀取Appsetting.json中的每頁筆數RowsPerPage以及分頁頁碼連結總數PageCount。
            int RowsPerPage = int.Parse(config["Page:FRowsPerPage"]);   //改RowsPerPage
            int PageCount = int.Parse(config["Page:PageCount"]);
            //9-2.系統在ViewComponent【Myfollower】讀取我的下線總數。
            long memberCount = await IMR.GetMyfollowerCount(ReferrerMobile, sDate, eDate, MemberMobile);
            //9-3.系統依9-2傳回值將9傳送頁碼重設在Between 1 and(9讀取記錄筆數/RowsPerPage)+(9讀取記錄筆數%RowsPerPage==0?0:1)。
            int TotalPages = (int)(memberCount / RowsPerPage);
            if (memberCount % RowsPerPage > 0) TotalPages += 1;
            if (Page < 1) Page = 1;
            if (Page > TotalPages) Page = TotalPages;
            if (Page <= 0) Page = 1;
            // 9-4.系統計算資料Skip數=(9傳送頁碼(預設1)-1)*9-1讀取RowsPerPage。
            int Skip = (Page - 1) * RowsPerPage;
            //9-5系統在ViewComponent【MyfollowerViewComponent】讀取我的下線清單：
            List<MemberViewModel> lMLVM = await IMR.GetMyfollowerList(ReferrerMobile, sDate, eDate, MemberMobile, Skip, RowsPerPage);
            // 9-6.系統設定PagerTagHelper之相關參數
            int CurrentPage = Page;
            // 9-6-1.系統將管理者權限清單Session["EmployeeRights"]暫存在ViewBag.TR。
            ViewBag.TR = HttpContext.Session.GetObjectFromJson<List<int>>("EmployeeRights");
            ViewBag.Page = Page;

            return View(new MyfollowerManageViewModel
            {
                listMyfollowerViewModel = lMLVM,
                CurrentPage = CurrentPage,
                TotalPages = TotalPages,
                PageCount = PageCount,
                StartPage = StartPage,
            });
        }
    }
}
