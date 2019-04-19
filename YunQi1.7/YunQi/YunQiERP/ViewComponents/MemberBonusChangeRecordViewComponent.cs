using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YunQiERP.ViewComponents
{
    //20181214 ---棋
    [Authorize]
    public class MemberBonusChangeRecordViewComponent : ViewComponent
    {
        private IMemberRepository IMR { get; set; }
        private IConfiguration config { get; set; }

        public MemberBonusChangeRecordViewComponent(IConfiguration configuration, IMemberRepository MemberRepository, IProductRepository ProductRepository)
        {
            IMR = MemberRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
            config = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(string MemberMobile, DateTime? sDate, DateTime? eDate, int EventId,int Page = 1, int LinkType = 0, int StartPage = 1,string AClass = "inner-page-link")
        {
            //9-1.系統在ViewComponent【MemberBonusList】中讀取Appsetting.json中的每頁筆數RowsPerPage以及分頁頁碼連結總數PageCount。
            int RowsPerPage = int.Parse(config["Page:RowsPerPage"]);
            int PageCount = int.Parse(config["Page:PageCount"]);
            //9-2.系統在ViewComponent【MemberBonusList】讀取批發會員獎金記錄總數。
            long BonusChangeRecordCount = await IMR.GetMemberBonusChangeRecordCount(MemberMobile, sDate, eDate);
            //long BonusListCount = 1;
            //9-3.系統依9-2傳回值將9傳送頁碼重設在Between 1 and(9讀取記錄筆數/RowsPerPage)+(9讀取記錄筆數%RowsPerPage==0?0:1)。
            int TotalPages = (int)(BonusChangeRecordCount / RowsPerPage);
            if (BonusChangeRecordCount % RowsPerPage > 0) TotalPages += 1;
            if (Page < 1) Page = 1;
            if (Page > TotalPages) Page = TotalPages;
            if (Page <= 0) Page = 1;
            //9-4.系統計算資料Skip數 = (9傳送頁碼(預設1) - 1)*9 - 1讀取RowsPerPage。
            int Skip = (Page - 1) * RowsPerPage;
            //9-5.系統在ViewComponent【MemberBonusListViewComponent】讀取批發會員獎金記錄清單：
            List<MemberBonusChangeRecordListViewModel> BCRL = await IMR.GetMemberBonusChangeRecordList(MemberMobile,EventId,sDate, eDate, Skip, RowsPerPage);

            int id = Skip + 1;

            //9-6.系統設定PagerTagHelper之相關參數
            int CurrentPage = Page;
            //9-6-1.系統將管理者權限清單Session["EmployeeRights"]暫存在ViewBag.TR。
            ViewBag.TR = HttpContext.Session.GetObjectFromJson<List<int>>("EmployeeRights");
            ViewBag.Page = Page;

            return View(new MemberBonusChangeRecordListManageViewModel
            {
                listMemberBonusChangeRecordListViewModel = BCRL,
                CurrentPage = CurrentPage,
                TotalPages = TotalPages,
                PageCount = PageCount,
                StartPage = StartPage,
                LinkType = LinkType,
                AClass = AClass,
                id = id,
            });
        }
    }
}