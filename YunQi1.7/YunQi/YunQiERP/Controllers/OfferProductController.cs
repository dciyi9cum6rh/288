using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    [Authorize]
    public class OfferProductController : Controller
    {
        private IProductRepository IAR { get; set; }

        public OfferProductController(IConfiguration configuration, IProductRepository ProductRepository)
        {
            IAR = ProductRepository;
            IAR.constr = configuration.GetConnectionString("SqlConn");
        }

        // 2.系統導向至Get Action【OfferProduct/Index】。
        // 3.系統在Get Action【OfferProduct/Index】判斷登入者擁有[準批發會員優惠商品管理]](13)之權限。
        [HavePrivilege(10)]
        public async Task<IActionResult> Index()
        {
            // 4.系統在Get Action【OfferProduct/Index】讀取準批發會員優惠商品清單。
            List<ProductListViewModel> lstPLVM = await IAR.GetOfferProductList();
            // 5.系統回傳View【OfferProduct/Index】並傳回4讀取值。
            return View(lstPLVM);
        }

        public async Task<FileResult> GetProductImage(int ProeuctId)
        {
            ProductImageViewModel onePC = await IAR.GetProductImage(ProeuctId);
            if (onePC == null) return null;
            return File(onePC.PictureContent, onePC.PictureType);
        }

        // 7.系統在Post Action【OfferProduct/PostOfferProduct】驗証使用者有[準批發會員優惠商品管理](13)權限。
        [HaveRightint1(13)]
        [HttpPost]
        public async Task<int> PostOfferProduct()
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                int ProductId = 0;
                string Product = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async
                    if (form["ProductId"] != "")
                    {
                        ProductId = int.Parse(form["ProductId"]);
                    }
                    Product = form["Product"];
                }
                // 9.系統新增一筆優惠商品資料。
                ret = await IAR.InsertOfferProduct(ProductId, Product);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳5。
                ret = 5;
            }
            return ret;
        }

        //// 7.系統在Post Action【OfferProduct/PutOfferProduct】驗証使用者有[首頁行銷圖示管理](10)權限。
        //[HaveRightint1(10)]
        //[HttpPost]
        //public async Task<int> PutOfferProduct(IFormFile PictureContentIEdit, int OfferProductId)
        //{
        //    int ret = 0;  // 12.系統回傳0。
        //    try
        //    {
        //        // 8.系統接收6上傳資料。
        //        string FileName = "";
        //        string OfferProductDescription = "";
        //        byte[] PContent = null;
        //        string PictureType = "";
        //        if (HttpContext.Request.HasFormContentType)
        //        {
        //            // 取得Client傳送之表單內容
        //            IFormCollection form;
        //            //form = HttpContext.Request.Form; // syncmbc
        //            // Or
        //            form = await HttpContext.Request.ReadFormAsync(); // async
        //            OfferProductDescription = form["OfferProductDescriptionEdit"];
        //            PictureType = PictureContentIEdit.ContentType;
        //            FileName = PictureContentIEdit.FileName;
        //            using (var memoryStream = new MemoryStream())
        //            {
        //                await PictureContentIEdit.CopyToAsync(memoryStream);
        //                PContent = memoryStream.ToArray();
        //            }
        //        }
        //        // 9.系統新增一筆首頁行銷圖示資料。
        //        //ret = await IAR.UpdateOfferProduct(FileName, PContent, PictureType, OfferProductDescription, OfferProductId);
        //        // 10.系統判斷9成功執行。
        //        // 11.系統回傳9傳回值。
        //    }
        //    catch (Exception ex)
        //    {
        //        // 10.系統判斷9執行時發生例外。
        //        //  10a-1.系統回傳3。
        //        ret = 3;
        //    }
        //    return ret;
        //}

        [HaveRightint1(13)]
        // 4.系統在Post Action【OfferProduct/DeleteOfferProduct】驗証使用者有[準批發會員優惠商品管理](13)權限。
        [HttpPost]
        public async Task<int> DeleteOfferProduct(int ProductId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 9.系統刪除一筆首頁行銷圖示資料。
                ret = await IAR.DeleteOfferProduct(ProductId);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳3。
                ret = 2;
            }
            return ret;
        }
    }
}