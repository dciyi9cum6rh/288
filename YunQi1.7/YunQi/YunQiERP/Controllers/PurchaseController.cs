using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utility;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    [Authorize]
    public class PurchaseController : Controller
    {
        private IPurchaseRepository IAR { get; set; }
        private IProductRepository IPR { get; set; }

        public PurchaseController(IConfiguration configuration, IPurchaseRepository PurchaseRepository, IProductRepository ProductRepository)
        {
            IAR = PurchaseRepository;
            IAR.constr = configuration.GetConnectionString("SqlConn");
            IPR = ProductRepository;
            IPR.constr = configuration.GetConnectionString("SqlConn");
        }

        // 2.系統導向至Get Action【Purchase/Index】。
        // 3.系統在Get Action【Purchase/Index】判斷登入者擁有[進貨管理](4)之權限。
        [HavePrivilege(4)]
        public IActionResult Index()
        {
            // 5.系統回傳View【Purchase/Index】
            return View();
        }

        [HttpPost]
        public IActionResult GetPurchaseList(DateTime? sDate, DateTime? eDate, string Product = "", string PurchaseId = "", int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "page-link")
        {
            // 4.系統在Get Action【Purchase/GetPurchaseList】呼叫ViewComponent【PurchaseListViewComponent】，並傳送jPurchaseId/jsDate/jeDate/jProduct與1點按頁碼。
            return ViewComponent("PurchaseList", new { sDate = sDate, eDate = eDate, Product = Product, PurchaseId = PurchaseId, Page = Page, LinkType = LinkType, StartPage = StartPage, aclass = AClass });
        }

        [HttpPost]
        public IActionResult GetPurchaseDetailList(string PurchaseId, int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "inner-page-link")
        {
            // 9.系統在Controller Action【Purchase/GetPurchaseDetailList】，呼叫ViewComponent【PurchaseDetailList】，並傳送3傳送之jPurchaseId。
            return ViewComponent("PurchaseDetailList", new { PurchaseId = PurchaseId, Page = Page, LinkType = LinkType, StartPage = StartPage, aclass = AClass });
        }

        [HttpPost]
        public IActionResult GetPurchaseDetailListNoButton(string PurchaseId, int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "inner-page-link")
        {
            // 9.系統在Controller Action【Purchase/GetPurchaseDetailList】，呼叫ViewComponent【PurchaseDetailList】，並傳送3傳送之jPurchaseId。
            return ViewComponent("PurchaseDetailListNoButton", new { PurchaseId = PurchaseId, Page = Page, LinkType = LinkType, StartPage = StartPage, aclass = AClass });
        }

        // 7.系統在Post Action【PostPurchase】驗証使用者有[進貨管理](4)權限。
        [HaveRightint1(4)]
        [HttpPost]
        // 8.系統接收6上傳資料。
        public async Task<int> PostPurchase(string PurchaseId, DateTime PurchaseTime, int CurrencyId, decimal ExchangeRate, decimal Freight, decimal miscellaneous, decimal ProductFee)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 9.系統新增一筆進貨資料。
                string UpdateEmployeeMobile = HttpContext.Session.GetString("CurrentEmployeeMobile");
                ret = await IAR.InsertPurchase(PurchaseId, PurchaseTime, UpdateEmployeeMobile, CurrencyId, ExchangeRate, Freight, miscellaneous, ProductFee);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳3。
                ret = 3;
            }
            return ret;
        }

        [HttpPost]
        public async Task<IActionResult> GetCurrency()
        {
            // 1-2.系統在Get Action[Purchase/GetCurrency]讀取幣別。
            List<CurrencyViewModel> lCVM = await IAR.GetCurrency();
            // 1-3.系統回傳Json(1-2讀取值)。
            return Json(lCVM);
        }

        [HttpPost]
        public async Task<string> GetNewPurchaseId(DateTime PurchaseTime)
        {
            // 6-2.系統在Get Action[Purchase/GetNewPurchaseId]讀取當日最後一張進貨單號。
            PurchaseIdViewModel lCVM = await IAR.GetNewPurchaseId(PurchaseTime);
            string PurchaseId = "";
            if (lCVM != null)
            {
                // 6-3.系統判斷6-2傳回值!=null。
                // 6-4.系統設定PurchaseId=年月日+<6-2讀取值最後4碼加1>。
                PurchaseId = Data.GetNewId(lCVM.PurchaseId, 9, 4);
            }
            else
            {
                // 6-3a.系統判斷6-2傳回值==null。
                //  6-3a-1.系統設定PurchaseId=年月日0001。
                //  6-3a-2.回6-5。
                PurchaseId = Data.GetStartId("A", PurchaseTime);
            }
            // 6-5.系統回傳string PurchaseId。
            return PurchaseId;
        }

        [HttpPost]
        public async Task<IActionResult> ValidateProduct(int ProductId, string Product)
        {
            // 1-3.系統在Get Action[Purchase/ValidateProduct]驗証商品是否存在。
            ValidateProductViewModel lCVM = await IPR.ValidateProduct(ProductId, Product);
            if (lCVM.ProductId == 0)
            {
                // 1-4a.系統判斷1-3讀取值中的ProductId==0。
                //  1-4a-1.系統回傳Json{err=1}。
                return Json(new { err = 1 });
            }
            // 1-4.系統判斷1-3讀取值中的ProductId!=0。
            // 1-5.系統讀取產品尺寸資料。
            List<ProductSizeViewModel> lPSVM = await IPR.GetProductSize(lCVM.ProductId);
            // 1-6.系統讀取產品色彩資料。
            List<ProductColorViewModel> lPCVM = await IPR.GetProductColor(lCVM.ProductId);
            // 1-7.系統回傳Json(Product=1-3讀取值, ProductSize=1-5讀取值, ProductColor=1-6讀取值)。
            return Json(new { Product = lCVM, ProductSize = lPSVM, ProductColor = lPCVM });
        }

        // 7.系統在Post Action【Purchase/PostPurchaseDetail】驗証使用者有[進貨管理](4)權限。
        [HaveRightint1(4)]
        [HttpPost]
        // 8.系統接收6上傳資料。
        public async Task<int> PostPurchaseDetail(string PurchaseId, int ProductId, int ProducSizeId, int ProductColorId, decimal PurchasePrice, int Quantity, decimal ExchangeRate)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 9.系統新增一筆進貨明細資料。
                ret = await IAR.InsertPurchaseDetail(PurchaseId, ProductId, ProducSizeId, ProductColorId, PurchasePrice, Quantity, ExchangeRate);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳3。
                ret = 3;
            }
            return ret;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrencyAndPurchase(string PurchaseId)
        {
            // 1-2.系統在Get Action[Purchase/GetCurrencyAndPurchase]讀取幣別。
            List<CurrencyViewModel> lCVM = await IAR.GetCurrency();
            // 1-3.系統在Get Action[Purchase/GetCurrencyAndPurchase]讀取進貨單。
            PurchaseListViewModel plvm = await IAR.GetPurchase(PurchaseId);
            // 1-4.系統回傳Json(new {Currency=1-2讀取值, Purchase=1-3讀取值})。
            return Json(new { Currency = lCVM, Purchase = plvm });
        }

        // 7.系統在Post Action【PutPurchase】驗証使用者有[進貨管理](4)權限。
        [HaveRightint1(4)]
        [HttpPost]
        // 8.系統接收6上傳資料。
        public async Task<int> PutPurchase(string PurchaseId, DateTime PurchaseTime, int CurrencyId, decimal ExchangeRate, decimal Freight, decimal miscellaneous, decimal ProductFee)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 9.系統修改一筆進貨資料。
                string UpdateEmployeeMobile = HttpContext.Session.GetString("CurrentEmployeeMobile");
                ret = await IAR.UpdatePurchase(PurchaseId, PurchaseTime, UpdateEmployeeMobile, CurrencyId, ExchangeRate, Freight, miscellaneous, ProductFee);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳3。
                ret = 3;
            }
            return ret;
        }

        // 4.系統在Post Action【Product/DeletePurchase】驗証使用者有[進貨單管理](4)權限。
        [HaveRightint2(4)]
        [HttpPost]
        public async Task<int> DeletePurchase(string PurchaseId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 5.系統刪除一筆進貨單資料。
                ret = await IAR.DeletePurchase(PurchaseId);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳3。
                ret = 3;
            }
            return ret;
        }

        // 4.系統在Post Action【Product/DeletePurchaseDetail】驗証使用者有[進貨單管理](4)權限。
        [HaveRightint2(4)]
        [HttpPost]
        public async Task<int> DeletePurchaseDetail(string PurchaseId, int PurchaseDetailId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 5.系統刪除一筆進貨單商品資料。
                ret = await IAR.DeletePurchaseDetail(PurchaseId, PurchaseDetailId);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳3。
                ret = 3;
            }
            return ret;
        }
    }
}