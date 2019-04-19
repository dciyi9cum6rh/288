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
    public class MembermoveViewComponent : ViewComponent
    {
        private IMemberRepository IMR { get; set; }
        private IConfiguration config { get; set; }

        public MembermoveViewComponent(IConfiguration configuration, IMemberRepository MemberRepository)
        {
            IMR = MemberRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
            config = configuration;
        }

        //20181222 ---棋
        public async Task<IViewComponentResult> InvokeAsync(int VersionId, DateTime? sDate, DateTime? eDate, string MessageValue, string NickName, int Page = 1, int StartPage = 1)
        {
            //9-1.系統在ViewComponent【Followertriumph】中讀取Appsetting.json中的每頁筆數BRowsPerPage以及分頁頁碼連結總數PageCount。
            int RowsPerPage = int.Parse(config["Page:BRowsPerPage"]);
            int PageCount = int.Parse(config["Page:PageCount"]);
            //9-2.系統在ViewComponent【Followertriumph】讀取我的下線業績總數。
            long MemberExchangeCount = await IMR.GetMemberExchangeCount(VersionId, sDate, eDate, MessageValue, NickName);
            //9-3.系統依9-2傳回值將9傳送頁碼重設在Between 1 and(9讀取記錄筆數/RowsPerPage)+(9讀取記錄筆數%RowsPerPage==0?0:1)。
            int TotalPages = (int)(MemberExchangeCount / RowsPerPage);
            if (MemberExchangeCount % RowsPerPage > 0) TotalPages += 1;
            if (Page < 1) Page = 1;
            if (Page > TotalPages) Page = TotalPages;
            if (Page <= 0) Page = 1;
            //9-4.系統計算資料Skip數 = (9傳送頁碼(預設1) - 1)*9 - 1讀取RowsPerPage。
            int Skip = (Page - 1) * RowsPerPage;
            //9-5系統在ViewComponent【FollowertriumphViewComponent】讀取我的下線業績清單：
            List<MemberExchangeListViewModel> GMEL = await IMR.GetMemberExchangeList(VersionId, sDate, eDate, MessageValue, NickName, Skip, RowsPerPage);
            //9-6.系統設定PagerTagHelper之相關參數
            int CurrentPage = Page;
            //9-6-1.系統將管理者權限清單Session["EmployeeRights"]暫存在ViewBag.TR。
            ViewBag.TR = HttpContext.Session.GetObjectFromJson<List<int>>("EmployeeRights");
            ViewBag.Page = Page;

            return View(new MembermoveManageViewModel
            {
                listMemberExchangeListViewModel = GMEL,
                CurrentPage = CurrentPage,
                TotalPages = TotalPages,
                PageCount = PageCount,
                StartPage = StartPage,
                //Parameters = Page,
            });
        }
    }
}
