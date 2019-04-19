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
    //20181208  ---棋
    [Authorize]
    public class MessageCenterListViewComponent : ViewComponent
    {
        private IEmployeeRepository IER { get; set; }
        private IProductRepository IPR { get; set; }
        private IConfiguration config { get; set; }

        public MessageCenterListViewComponent(IConfiguration configuration, IEmployeeRepository EmployeeRepository, IProductRepository ProductRepository)
        {
            IER = EmployeeRepository;
            IER.constr = configuration.GetConnectionString("SqlConn");
            IPR = ProductRepository;
            IPR.constr = configuration.GetConnectionString("SqlConn");
            config = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(string MessageValue, int MemberLevelId, DateTime? sDate, DateTime? eDate, int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "inner-page-link")
        {
            // 9-1.系統在ViewComponent【EmployeeList】中讀取Appsetting.json中的每頁筆數RowsPerPage以及分頁頁碼連結總數PageCount。
            int RowsPerPage = int.Parse(config["Page:RowsPerPage"]);
            int PageCount = int.Parse(config["Page:PageCount"]);
            // 9-2.系統在ViewComponent【EmployeeList】讀取員工總數。
            long MessageCount = await IER.GetMailCenterMessageCount(MemberLevelId, MessageValue, sDate, eDate);
            // 9-3.系統依9-2傳回值將9傳送頁碼重設在Between 1 and (9讀取記錄筆數/RowsPerPage)+(9讀取記錄筆數%RowsPerPage==0?0:1)。
            int TotalPages = (int)(MessageCount / RowsPerPage);
            if (MessageCount % RowsPerPage > 0) TotalPages += 1;
            if (Page < 1) Page = 1;
            if (Page > TotalPages) Page = TotalPages;
            if (Page <= 0) Page = 1;
            // 9-4.系統計算資料Skip數=(9傳送頁碼(預設1)-1)*9-1讀取RowsPerPage。
            int Skip = (Page - 1) * RowsPerPage;
            // 9-5系統在ViewComponent【EmployeeListViewComponent】讀取部門員工清單：
            List<GetMailCenterMessageListViewModel> MessageList = await IER.GetMailCenterMessageList(MemberLevelId, MessageValue, sDate, eDate, Skip, RowsPerPage);
            // 9-6.系統設定PagerTagHelper之相關參數
            int CurrentPage = Page;
            // 9-6-1.系統將管理者權限清單Session["EmployeeRights"]暫存在ViewBag.TR。
            ViewBag.TR = HttpContext.Session.GetObjectFromJson<List<int>>("EmployeeRights");
            ViewBag.Page = Page;
            //9-7.系統回傳View(new EmployeeListManageViewModel {
            //listEmployeeListViewModel = 9 - 5讀取值,
            //CurrentPage = 9 - 6設定值,
            //TotalPages = 9 - 6設定值,
            //PageCount = 9 - 6設定值,
            //StartPage = 9 - 6設定值,
            //Parameters = 9 - 6設定值
            //});
            return View(new MessageCenterListManageViewModel
            {
                listGetMailCenterMessageListViewModel = MessageList,
                CurrentPage = CurrentPage,
                TotalPages = TotalPages,
                PageCount = PageCount,
                StartPage = StartPage,
                LinkType = LinkType,
                AClass = AClass,
            });
        }
    }
}