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
    public class PurchaseDetailListViewComponent : ViewComponent
    {
        private IPurchaseRepository IMR { get; set; }
        private IConfiguration config { get; set; }

        public PurchaseDetailListViewComponent(IConfiguration configuration, IPurchaseRepository PurchaseRepository)
        {
            IMR = PurchaseRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
            config = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(string PurchaseId = "", int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "inner-page-link")
        {
            // 9-1.系統在ViewComponent【PurchaseDetailList】中讀取Appsetting.json中的每頁筆數RowsPerPage以及分頁頁碼連結總數PageCount。
            int RowsPerPage = int.Parse(config["Page:RowsPerPage"]);
            int PageCount = int.Parse(config["Page:PageCount"]);
            // 9-2.系統在ViewComponent【PurchaseDetailList】讀取進貨單進貨清單總數。
            long memberCount = await IMR.GetPurchaseDetailListCount(PurchaseId);
            // 9-3.系統依9-2傳回值將9傳送頁碼重設在Between 1 and (9讀取記錄筆數/RowsPerPage)+(9讀取記錄筆數%RowsPerPage==0?0:1)。
            int TotalPages = (int)(memberCount / RowsPerPage);
            if (memberCount % RowsPerPage > 0) TotalPages += 1;
            if (Page < 1) Page = 1;
            if (Page > TotalPages) Page = TotalPages;
            if (Page <= 0) Page = 1;
            // 9-4.系統計算資料Skip數=(9傳送頁碼(預設1)-1)*9-1讀取RowsPerPage。
            int Skip = (Page - 1) * RowsPerPage;
            // 9-5系統在ViewComponent【PurchaseDetailListViewComponent】讀取進貨單進貨清單清單：
            List<PurchaseDetailListViewModel> lMLVM = await IMR.GetPurchaseDetailList(PurchaseId, Skip, RowsPerPage);
            // 9-6.系統設定PagerTagHelper之相關參數
            int CurrentPage = Page;
            // 9-6-1.系統將管理者權限清單Session["EmployeeRights"]暫存在ViewBag.TR。
            ViewBag.TR = HttpContext.Session.GetObjectFromJson<List<int>>("EmployeeRights");
            ViewBag.Page = Page;
            // 9-7.系統回傳View(new PurchaseDetailListManageViewModel  {
            //listPurchaseDetailListViewModel = 9 - 5讀取值,
            //CurrentPage = 9 - 6設定值,
            //TotalPages = 9 - 6設定值,
            //PageCount = 9 - 6設定值,
            //StartPage = 9 - 6設定值,
            //Parameters = 9 - 6設定值
            //});
            return View(new PurchaseDetailListManageViewModel
            {
                listPurchaseDetailListViewModel = lMLVM,
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