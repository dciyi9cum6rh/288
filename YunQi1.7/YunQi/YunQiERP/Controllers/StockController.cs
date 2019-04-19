using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        private IProductRepository IAR { get; set; }

        public StockController(IConfiguration configuration, IProductRepository ProductRepository)
        {
            IAR = ProductRepository;
            IAR.constr = configuration.GetConnectionString("SqlConn");
        }

        // 2.系統導向至Get  Action【Stock/Index】。
        // 3.系統在Get Action【Stock/Index】判斷登入者擁有[商品管理](2)之權限。
        [HavePrivilege(2)]
        public IActionResult Index()
        {
            // 5.系統回傳View【Stock/Index】
            return View();
        }

        [HttpPost]
        public IActionResult GetStockList(DateTime? sDate, DateTime? eDate, string Product = "", int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "page-link")
        {
            // 4.系統在Get Action【Stock/GetStockList】呼叫ViewComponent【StockListViewComponent】(庫存盤整記清單)，並傳送StockSubject=3上傳jsDate/jeDate與1點按頁碼。
            return ViewComponent("StockList", new { sDate = sDate, eDate = eDate, Product = Product, Page = Page, LinkType = LinkType, StartPage = StartPage, aclass = AClass });
        }
    }
}