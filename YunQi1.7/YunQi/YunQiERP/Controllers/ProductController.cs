using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private IProductRepository IAR { get; set; }
        private IHostingEnvironment _environment;

        public ProductController(IConfiguration configuration, IProductRepository ProductRepository, IHostingEnvironment environment)
        {
            IAR = ProductRepository;
            IAR.constr = configuration.GetConnectionString("SqlConn");
            _environment = environment;
        }

        // 2.系統導向至Get Controller Action【Product/Index】。
        // 3.系統在Get Controller Action【Product/Index】判斷登入者擁有[商品管理] (2)之權限。
        [HavePrivilege(2)]
        public IActionResult Index()
        {
            // 4-1.系統設定ViewBag.ProductCategoryId=1(表總分類)。
            ViewBag.ProductCategoryId = 1;
            // 5.系統回傳View【Product/Index】
            return View();
        }

        public async Task<FileResult> GetCagegoryImage(int ProeuctCatagoryId)
        {
            OneProductCategoryViewModel onePC = await IAR.GetOneProductCategory(ProeuctCatagoryId);
            return File(onePC.PictureContent, onePC.PictureType);
        }

        //[HavePrivilege(2)]
        [HttpPost]
        public IActionResult GetProductCategory(int ProductCategoryId, string ProductCategory = "", int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "page-link")
        {
            // 5.系統呼叫ViewComponent【ProductCategory】，並傳送2傳送之jProductCategoryId與jProductCategory、以及1點按頁碼。
            return ViewComponent("ProductCategory", new { ProductCategoryId = ProductCategoryId, ProductCategory = ProductCategory, Page = Page, LinkType = LinkType, StartPage = StartPage, aclass = AClass });
        }

        [HttpPost]
        public IActionResult GetProductLevelPath(int ProductCategoryId)
        {
            // 10-2.系統在Action【Product/GetProductLevelPath】呼叫ViewComponent【ProductLevelPathViewComponent】(目前分類階層，格式為[總分類\子別\子子類別)，並傳送ProductCategoryId=jProductCategoryId。
            return ViewComponent("ProductLevelPath", new { ProductCategoryId = ProductCategoryId });
        }

        // 7.系統在Post Action【Product/AddProductCategory】驗証使用者有[商品管理](2)權限。
        [HaveRightint1(2)]
        [HttpPost]
        public async Task<int> PostProductCategory(IFormFile PictureContent, int ParentProductCategoryId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string ProductCategory = "", ProductCategoryDescription = "";
                byte[] PContent = null;
                string PictureType = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async

                    ProductCategory = form["ProductCategoryName"];
                    ProductCategoryDescription = form["ProductCategoryDescription"];
                    PictureType = PictureContent.ContentType;
                    using (var memoryStream = new MemoryStream())
                    {
                        await PictureContent.CopyToAsync(memoryStream);
                        PContent = memoryStream.ToArray();
                    }
                }
                // 10.系統在POST Action【Activity/PostActivity】新增一筆活動資料。
                ret = await IAR.InsertProductCategory(ProductCategory, ProductCategoryDescription, PContent, PictureType, ParentProductCategoryId);
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

        // 7.系統在Post Action【Product/PutProductCategory】驗証使用者有[商品管理](2)權限。
        [HaveRightint1(2)]
        [HttpPost]
        public async Task<int> PutProductCategory(IFormFile EditPictureContent, int ProductCategoryId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string ProductCategory = "", ProductCategoryDescription = "";
                byte[] PContent = null;
                string PictureType = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async

                    ProductCategory = form["EditProductCategoryName"];
                    ProductCategoryDescription = form["EditProductCategoryDescription"];
                    if (EditPictureContent != null)
                    {
                        PictureType = EditPictureContent.ContentType;
                        using (var memoryStream = new MemoryStream())
                        {
                            await EditPictureContent.CopyToAsync(memoryStream);
                            PContent = memoryStream.ToArray();
                        }
                    }
                }
                // 9.系統修改一筆商品分類資料。
                ret = await IAR.UpdateProductCategory(ProductCategory, ProductCategoryDescription, PContent, PictureType, ProductCategoryId);
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

        // 4.系統在Post Action【Product/DeleteProductCategory】驗証使用者有[商品管理](2)權限。
        [HaveRightint2(2)]
        [HttpPost]
        public async Task<int> DeleteProductCategory(int ProductCategoryId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 5.系統刪除一筆商品分類資料。
                ret = await IAR.DeleteProductCategory(ProductCategoryId);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                //10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳1。
                ret = 1;
            }
            return ret;
        }

        // 3.系統在Get Controller Action【Product/GetProductList】判斷登入者擁有[商品管理](2)之權限。
        [HttpPost]
        public IActionResult GetProductList(string ProductCategory = "", string Product = "", int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "page-link")
        {
            // 9.系統呼叫ViewComponent【ProductList】，並傳送2傳送之jProductCategoryProduct與jProduct(預設皆為'')。
            return ViewComponent("ProductList", new { ProductCategory = ProductCategory, Product = Product, Page = Page, LinkType = LinkType, StartPage = StartPage, AClass = AClass });
        }

        // 7.系統在Post Action【Product/PostProduct】驗証使用者有[商品管理](2)權限。
        [HaveRightint1(2)]
        [HttpPost]
        public async Task<int> PostProduct(int ProductCategoryId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string Product = "", ProductDescription = "";
                int Price = 0, OfferPrice = 0, SaleLimitPrice = 0;
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async

                    Product = form["ProductName"];
                    ProductDescription = form["ProductDescription"];
                    Price = int.Parse(form["Price"]);
                    OfferPrice = int.Parse(form["OfferPrice"]);
                    SaleLimitPrice = int.Parse(form["SaleLimitPrice"]);
                }
                // 9.系統新增一筆商品資料。
                ret = await IAR.InsertProduct(ProductCategoryId, Product, ProductDescription, Price, OfferPrice, SaleLimitPrice);
                ////if (ret == 0)
                ////{
                //// 9-1.系統讀取剛剛新增之商品Id。
                //int ProductId = await IAR.GetProductLastId();
                //// 9-2.系統新增n筆商品顏色資料。
                //ret = await IAR.InsertProductSize(ProductId, Size);
                //if(ret==0)
                //{
                //    // 9-3.系統新增n筆商品顏色資料。
                //    ret = await IAR.InsertProductColor(ProductId, Color);
                //}
                ////}
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

        public async Task<FileResult> GetProductImage(int ProeuctId)
        {
            ProductImageViewModel onePC = await IAR.GetProductImage(ProeuctId);
            if (onePC == null) return null;
            return File(onePC.PictureContent, onePC.PictureType);
        }

        public async Task<FileResult> GetOneProductImage(int ProeuctId, int ProductImageId)
        {
            ProductImageViewModel onePC = await IAR.GetOneProductImage(ProeuctId, ProductImageId);
            if (onePC == null) return null;
            return File(onePC.PictureContent, onePC.PictureType);
        }

        public async Task<JsonResult> GetProduct(int ProductId)
        {
            // 1-3.系統在Post Action【Product/GetProduct】讀取產品資料。
            ProductListViewModel onePC = await IAR.GetProduct(ProductId);
            //// 1-4.系統讀取產品尺寸資料。
            //List<ProductSizeViewModel> listPSVM = await IAR.GetProductSize(ProductId);
            //// 1-5.系統讀取產品色彩資料。
            //List<ProductColorViewModel> listPCVM = await IAR.GetProductColor(ProductId);
            // 1-6.系統以json回傳{ Product=1-3讀取值, ProductSize=1-4讀取值, ProductColor=1-4讀取值}。
            return Json(new { Product = onePC });
        }

        // 7.系統在Post Action【Product/PutProduct】驗証使用者有[商品管理](2)權限。
        [HaveRightint1(2)]
        [HttpPost]
        public async Task<int> PutProduct(int ProductId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string Product = "", ProductDescription = "";
                int Price = 0, OfferPrice = 0, SaleLimitPrice = 0;
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async

                    Product = form["EditProductName"];
                    ProductDescription = form["EditProductDescription"];
                    Price = int.Parse(form["EditPrice"]);
                    OfferPrice = int.Parse(form["EditOfferPrice"]);
                    SaleLimitPrice = int.Parse(form["EditSaleLimitPrice"]);
                }
                // 9.系統修改一筆商品資料。
                ret = await IAR.UpdateProduct(ProductId, Product, ProductDescription, Price, OfferPrice, SaleLimitPrice);
                //if (ret == 0)
                //{
                //    // 9-2.系統新增n筆商品尺寸資料。
                //    ret = await IAR.InsertProductSize(ProductId, Size);
                //    if (ret == 0)
                //    {
                //        // 9-3.系統新增n筆商品顏色資料。
                //        ret = await IAR.InsertProductColor(ProductId, Color);
                //    }
                //}
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

        // 4.系統在Post Action【Product/DeleteProductCategory】驗証使用者有[商品管理](2)權限。
        [HaveRightint2(2)]
        [HttpPost]
        public async Task<int> DeleteProduct(int ProductId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 5.系統刪除一筆商品資料。
                ret = await IAR.DeleteProduct(ProductId);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                //10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳1。
                ret = 1;
            }
            return ret;
        }

        [HttpPost]
        public IActionResult GetProductImageList(int ProductId, int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "inner-page-link")
        {
            // 9.系統在Controller Action【Product/GetProductImageList】，呼叫ViewComponent【ProductImageList】，並傳送3傳送之jProductId。
            return ViewComponent("ProductImageList", new { ProductId = ProductId, Page = Page, LinkType = LinkType, StartPage = StartPage, AClass = AClass });
        }

        // 7.系統在Post Action【Product/PostProductImage】驗証使用者有[商品管理](2)權限。
        [HaveRightint1(2)]
        [HttpPost]
        public async Task<int> PostProductImage(List<IFormFile> PictureContentI, int ProductId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                string FilePath = Path.Combine(_environment.WebRootPath, @"images");
                // 8.系統接收6上傳資料。
                //string FileName = "";
                //byte[] PContent = null;
                //string PictureType = "";
                List<UploadFile> lstUF = new List<UploadFile>();
                UploadFile UF;
                if (HttpContext.Request.HasFormContentType)
                {
                    //// 取得Client傳送之表單內容
                    //IFormCollection form;
                    ////form = HttpContext.Request.Form; // syncmbc
                    //// Or
                    //form = await HttpContext.Request.ReadFormAsync(); // async
                    int o = 0;
                    foreach (var item in PictureContentI)
                    {
                        o += 1;
                        UF = new UploadFile();
                        UF.ProductId = ProductId;
                        UF.FileName = item.FileName;
                        UF.FileName = Path.GetFileName(UF.FileName);
                        UF.DisplayOrder = o;
                        if (UF.FileName.Length > 50)
                            UF.FileName = UF.FileName.Substring(UF.FileName.Length - 50);
                        // 8-1.系統在Post Action【Import/ReportPost】將上傳.xlsx儲存至~/xlsx資料夾。
                        var fileName = item.FileName.Substring(item.FileName.LastIndexOf(@"\") + 1);
                        var FilePathTrue = Path.Combine(FilePath, fileName);
                        using (Image img = Image.FromStream(item.OpenReadStream()))
                        {
                            //img.Resize(1280, 960).Save(FilePathTrue);
                            img.Save(FilePathTrue);
                        }
                        using (Image img = Image.FromFile(FilePathTrue))
                        {
                            UF.PictureContent = img.ToByteArray();
                        }
                        UF.PictureType = item.ContentType;
                        lstUF.Add(UF);
                        System.IO.File.Delete(FilePathTrue);
                    }
                }
                // 9.系統新增多筆商品分類資料。
                if (lstUF.Count > 0)
                {
                    ret = await IAR.InsertProductImageMulti(lstUF);
                }
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳3。
                ret = 3;
            }
            return ret;
        }

        // 7.系統在Post Action【Product/PutProductImage】驗証使用者有[商品管理](2)權限。
        [HaveRightint1(2)]
        [HttpPost]
        public async Task<int> PutProductImage(IFormFile EditPictureContentI, int ProductId, int ProductImageId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string FileName = "";
                byte[] PContent = null;
                string PictureType = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    //// 取得Client傳送之表單內容
                    //IFormCollection form;
                    ////form = HttpContext.Request.Form; // syncmbc
                    //// Or
                    //form = await HttpContext.Request.ReadFormAsync(); // async
                    PictureType = EditPictureContentI.ContentType;
                    FileName = EditPictureContentI.FileName;
                    using (var memoryStream = new MemoryStream())
                    {
                        await EditPictureContentI.CopyToAsync(memoryStream);
                        PContent = memoryStream.ToArray();
                    }
                }
                // 9.系統修改一筆商品分類資料。
                ret = await IAR.UpdateProductImage(ProductId, ProductImageId, FileName, PContent, PictureType);
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

        // 4.系統在Post Action【Product/DeleteProductImage】驗証使用者有[商品管理](2)權限。
        [HaveRightint2(2)]
        [HttpPost]
        public async Task<int> DeleteProductImage(int ProductId, int ProductImageId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 5.系統刪除一筆商品圖示資料。
                ret = await IAR.DeleteProductImage(ProductId, ProductImageId);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                //10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳1。
                ret = 1;
            }
            return ret;
        }

        // 4.系統在Post Action【Product/SetProductImage】驗証使用者有[商品管理](2)權限。
        [HaveRightint2(2)]
        [HttpPost]
        public async Task<int> SetProductImage(int ProductId, int ProductImageId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 5.系統刪除一筆商品圖示資料。
                ret = await IAR.SetProductImage(ProductId, ProductImageId);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                //10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳1。
                ret = 1;
            }
            return ret;
        }

        // 4.系統在Post Action【Product/UpdateProductImageOrder】驗証使用者有[商品管理](2)權限。
        [HaveRightint2(2)]
        [HttpPost]
        public async Task<int> UpdateProductImageOrder(int ProductId, int ProductImageId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 5.系統讀取商品圖示清單：
                List<ProductImageListViewModel> lMLVM = await IAR.GetProductImageList(ProductId, 0, 200);
                // 6.系統重設5讀取值中每一個圖示之DisplayOrder：
                // 	先將3上傳ProductId/ProductImageId之對應圖示設為1。
                for (int i = 0; i <= lMLVM.Count - 1; i++)
                {
                    if (lMLVM[i].ProductId == ProductId && lMLVM[i].ProductImageId == ProductImageId)
                    {
                        lMLVM[i].DisplayOrder = 1;
                    }
                }
                // 	再將其他圖示設為2~N。
                int o = 1;
                for (int i = 0; i <= lMLVM.Count - 1; i++)
                {
                    if (!(lMLVM[i].ProductId == ProductId && lMLVM[i].ProductImageId == ProductImageId))
                    {
                        o += 1;
                        lMLVM[i].DisplayOrder = o;
                    }
                }
                // 7.系統重設商品圖示顯示順序。
                ret = await IAR.UpdateProductImageOrder(lMLVM);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                //10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳1。
                ret = 1;
            }
            // 11.系統回傳9傳回值。
            return ret;
        }

        // 7.系統在Post Action【Product/PostProductStock】驗証使用者有[商品管理](2)權限。
        [HaveRightint2(2)]
        [HttpPost]
        public async Task<int> PostProductStock(int ProductId, int ProducSizeId, int ProductColorId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                int Stock = 0, StockConsolidatio = 0, Consolidation = 0;
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async

                    Stock = int.Parse(form["Stock"]);
                    StockConsolidatio = int.Parse(form["StockConsolidatio"]);
                    Consolidation = int.Parse(form["Consolidation"]);
                }
                // 9.系統更新一筆商品庫存資料，並新增一筆庫存盤整記錄。
                string CurrentEmployeeMobile = HttpContext.Session.GetString("CurrentEmployeeMobile");
                ret = await IAR.UpdateProductStock(ProductId, ProducSizeId, ProductColorId, Stock, StockConsolidatio, Consolidation, CurrentEmployeeMobile);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳3。
                ret = 3;
            }
            return ret;
        }

        public async Task<JsonResult> GetProductSize(int ProductId)
        {
            // 5.系統在Post Action【Product/GetProductSize】讀取產品尺寸資料。
            List<ProductSizeViewModel> listPSVM = await IAR.GetProductSize(ProductId);
            //// 1-5.系統讀取產品色彩資料。
            //List<ProductColorViewModel> listPCVM = await IAR.GetProductColor(ProductId);
            // 6.系統回傳Json(5讀取值)。
            return Json(new { ProductSize = listPSVM });
        }

        // 10. Post Action【Product/PostProductSize】驗証使用者有[商品管理](2)權限。
        [HaveRightint2(2)]
        [HttpPost]
        public async Task<int> PostProductSize(int ProductId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 系統接收6上傳資料。
                string ProductSize = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async

                    ProductSize = form["ProductSize"];
                }
                // 11.系統新增一筆商品尺寸資料。
                ret = await IAR.InsertProductSize(ProductId, ProductSize);
                //    if (ret == 0)
                //    {
                //        // 9-3.系統新增n筆商品顏色資料。
                //        ret = await IAR.InsertProductColor(ProductId, Color);
                //    }
                //}
                // 12.系統判斷11執行成功。
                // 13.系統回傳11傳回值。
            }
            catch (Exception ex)
            {
                // 12a.系統判斷11執行失敗。
                //  12a-1.系統傳回1。
                ret = 3;
            }
            return ret;
        }

        // 19.系統在Post Action【Product/DeleteProductSize】驗証使用者有[商品管理](2)權限。
        [HaveRightint2(2)]
        [HttpPost]
        public async Task<int> DeleteProductSize(int ProductId, string ProductSize)
        {
            int ret = 0;
            try
            {
                // 20.系統刪除一筆商品尺寸資料。
                ret = await IAR.DeleteProductSize(ProductId, ProductSize);
                // 21.系統判斷20成功執行。
                // 22.系統回傳20傳回值。
            }
            catch (Exception ex)
            {
                // 21a.系統判斷20執行失敗。
                //  21a-1.系統傳回1。
                ret = 1;
            }
            return ret;
        }

        public async Task<JsonResult> GetProductColor(int ProductId)
        {
            // 5.系統在Post Action【Product/GetProductColor】讀取產品顏色資料。
            List<ProductColorViewModel> listPSVM = await IAR.GetProductColor(ProductId);
            //// 1-5.系統讀取產品色彩資料。
            //List<ProductColorViewModel> listPCVM = await IAR.GetProductColor(ProductId);
            // 6.系統回傳Json(5讀取值)。
            return Json(new { ProductColor = listPSVM });
        }

        // 10. Post Action【Product/PostProductColor】驗証使用者有[商品管理](2)權限。
        [HaveRightint2(2)]
        [HttpPost]
        public async Task<int> PostProductColor(int ProductId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 系統接收6上傳資料。
                string ProductColor = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async

                    ProductColor = form["ProductColor"];
                }
                // 11.系統新增一筆商品顏色資料。
                ret = await IAR.InsertProductColor(ProductId, ProductColor);
                //    if (ret == 0)
                //    {
                //        // 9-3.系統新增n筆商品顏色資料。
                //        ret = await IAR.InsertProductColor(ProductId, Color);
                //    }
                //}
                // 12.系統判斷11執行成功。
                // 13.系統回傳11傳回值。
            }
            catch (Exception ex)
            {
                // 12a.系統判斷11執行失敗。
                //  12a-1.系統傳回1。
                ret = 3;
            }
            return ret;
        }

        // 19.系統在Post Action【Product/DeleteProductColor】驗証使用者有[商品管理](2)權限。
        [HaveRightint2(2)]
        [HttpPost]
        public async Task<int> DeleteProductColor(int ProductId, string ProductColor)
        {
            int ret = 0;
            try
            {
                // 20.系統刪除一筆商品顏色資料。
                ret = await IAR.DeleteProductColor(ProductId, ProductColor);
                // 21.系統判斷20成功執行。
                // 22.系統回傳20傳回值。
            }
            catch (Exception ex)
            {
                // 21a.系統判斷20執行失敗。
                //  21a-1.系統傳回1。
                ret = 1;
            }
            return ret;
        }

        [HttpPost]
        public IActionResult GetProductStockList(int ProductId, int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "inner-page-link-stock")
        {
            // 9.系統在Controller Action【Product/GetProductStockList】，呼叫ViewComponent【ProductStockList】，並傳送3傳送之jProductId。
            return ViewComponent("ProductStockList", new { ProductId = ProductId, Page = Page, LinkType = LinkType, StartPage = StartPage, AClass = AClass });
        }
    }
}