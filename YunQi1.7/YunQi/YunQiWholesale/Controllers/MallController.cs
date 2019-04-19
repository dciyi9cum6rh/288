using DataModel;
using IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YunQiWholesale.Controllers
{
    public class MallController : Controller
    {
        private ICompositeViewEngine _viewEngine;
        private IMediaRepository IMR { get; set; }
        private IParameterRepository IPR { get; set; }
        private IProductRepository IPRR { get; set; }
        private IMemberRepository IMER { get; set; }

        public MallController(ICompositeViewEngine viewEngine, IConfiguration configuration, IMediaRepository MediaRepository, IParameterRepository ParameterRepository, IProductRepository ProductRepository, IMemberRepository MemberRepository)
        {
            _viewEngine = viewEngine;
            IMR = MediaRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
            IPR = ParameterRepository;
            IPR.constr = configuration.GetConnectionString("SqlConn");
            IPRR = ProductRepository;
            IPRR.constr = configuration.GetConnectionString("SqlConn");
            IMER = MemberRepository;
            IMER.constr = configuration.GetConnectionString("SqlConn");
        }

        // 2.系統呼叫Get Controller Action【Mall/Index】。
        public async Task<IActionResult> Index(int MemberLevelId)
        {
            // 3.系統在Action【Mall /Index】讀取商城行銷圖示。
            //List<MallImageViewModel> lstMIVM = await IMR.GetMallImageList(0, 100);
            List<MallImageViewModel> lstMIVM = null;
            // 4.系統在Action【Mall/Index】讀取產品最上層分類。
            ProductCategoryViewModel pcvm = await IPRR.GetTopProductCategory();
            // 5.系統回傳View【Mall/Index】，並回傳new MallViewModel { MallImage=3傳回值,ProductCategory=4傳回值 }。
            return View(new MallViewModel { MallImage = lstMIVM, ProductCategory = pcvm, MemberLevelId = MemberLevelId });
        }

        public async Task<FileResult> GetOneMallImage(int MallImageId)
        {
            MallImageViewModel onePC = await IMR.GetOneMallImage(MallImageId);
            if (onePC == null) return null;
            return File(onePC.PictureContent, onePC.PictureType);
        }

        public async Task<FileResult> GetProductImage(int ProeuctId)
        {
            ProductImageViewModel onePC = await IPRR.GetProductImage(ProeuctId);
            if (onePC == null) return null;
            return File(onePC.PictureContent, onePC.PictureType);
        }

        [HttpPost]
        public IActionResult GetProductList(int ProductCategoryId, string ProductCategory, string Product = "", int lowPrice = 0, int hightPrice = 1000000000, int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "page-link", int MemberLevelId = -1)
        {
            // 3.系統在Controller Action【Mall/GetProductList】呼叫ViewComponent【ProductListViewComponent】，並傳送1點之ProductCategoryId與ProductCategory、頁碼。
            return ViewComponent("ProductList", new { ProductCategoryId = ProductCategoryId, ProductCategory = ProductCategory, Product = Product, lowPrice = lowPrice, hightPrice = hightPrice, Page = Page, LinkType = LinkType, StartPage = StartPage, AClass = AClass, MemberLevelId = MemberLevelId });
        }

        [HttpPost]
        public IActionResult GetProductLevelPath(int ProductCategoryId)
        {
            // 4.系統在Action【Mall/GetProductLevelPath】呼叫ViewComponent【ProductLevelPathViewComponent】(目前分類階層，格式為[總分類\子別\子子類別)，並傳送ProductCategoryId。
            return ViewComponent("ProductLevelPath", new { ProductCategoryId = ProductCategoryId });
        }

        [HttpPost]
        public async Task<int> GetProductCategoryId(string ProductCategory)
        {
            // 3.系統在Get Controller Action【Mall/GetProductCategoryId】讀取分類代碼。
            ProductCategoryViewModel ProductCategoryId = await IPRR.GetProductCategoryId(ProductCategory);
            // 4.系統回傳3讀取值。
            return ProductCategoryId.ProductCategoryId;
        }

        [HttpPost]
        public IActionResult GetProductDetail(int ProductId, int MemberLevelId = -1)
        {
            // 2-1.系統在Get Controller Action【Mall/GetProductDetail】呼叫ViewComponent【ProductDetail】並傳送2傳送之商品代碼。
            return ViewComponent("ProductDetail", new { ProductId = ProductId, MemberLevelId = MemberLevelId });
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailBlank(int ProductId, int MemberLevelId = -1)
        {
            // 2-1.系統在Get Controller Action【Mall/GetProductDetail】呼叫ViewComponent【ProductDetail】並傳送2傳送之商品代碼。
            // 3.系統在ViewComponent【ProductDetail】讀取商品基本資料。
            ProductListViewModel PLVM = await IPRR.GetProduct(ProductId);
            // 4.系統在ViewComponent【ProductDetail】讀取商品尺寸資料。
            List<ProductSizeViewModel> lstPSVM = IPRR.GetProductSizeSync(ProductId);
            // 5.系統在ViewComponent【ProductDetail】讀取商品顏色資料。
            List<ProductColorViewModel> lstPCVM = IPRR.GetProductColorSync(ProductId);

            ProductStockListViewModel PSLVM;
            if (lstPSVM == null || lstPCVM == null || lstPSVM.Count == 0 || lstPCVM.Count == 0)
            {
                PSLVM = null;
            }
            else
            {
                // 6.系統在ViewComponent【ProductDetail】讀取商品第1個尺寸第1個顏色的庫存資料。
                PSLVM = await IPRR.GetProductStock(ProductId, lstPSVM[0].ProducSizeId, lstPCVM[0].ProductColorId);
                if (PSLVM == null)
                {
                    // 6-1a.系統判斷6傳回null。
                    //  6-1a-1.系統New ProductStockListViewModel {}，將Stock設為0。
                    PSLVM = new ProductStockListViewModel { ProductId = ProductId, ProducSizeId = lstPSVM[0].ProducSizeId, ProductColorId = lstPCVM[0].ProductColorId, Stock = 0 };
                    //  6-1a-2.回7。
                }
            }
            // 6-0.系統在ViewComponent【ProductDetail】讀取讀取商品圖示清單：
            List<ProductImageListViewModel> lstPIVM = await IPRR.GetProductImageList(ProductId, 0, 1000);
            // 7.系統回傳View(new ProductDetailMallViewModel { Product=3讀取值, ProductSize=4傳回值, ProductColor=5傳回值, ProductStock=6傳回值 })。
            //int? MemberLevelId = -1;
            //if (HttpContext.Session.GetInt32("MemberLevelId") != null)
            //    MemberLevelId = HttpContext.Session.GetInt32("MemberLevelId");
            //else
            //    MemberLevelId = -1;
            return View(new ProductDetailMallViewModel { Product = PLVM, ProductSize = lstPSVM, ProductColor = lstPCVM, ProductStock = PSLVM, ProductImage = lstPIVM, MemberLevelId = MemberLevelId });
        }

        [HttpGet]
        public async Task<FileResult> GetOneProductImage(int ProeuctId, int ProductImageId)
        {
            ProductImageViewModel onePC = await IPRR.GetOneProductImage(ProeuctId, ProductImageId);
            if (onePC == null) return null;
            return File(onePC.PictureContent, onePC.PictureType);
        }

        [HttpPost]
        public IActionResult GetOfferProductList()
        {
            // 3.系統在Action【Mall/GetOfferProductList】呼叫ViewComponent【OfferProductListViewComponent】。
            return ViewComponent("OfferProductList");
        }

        [HttpGet]
        public async Task<int> GetProductStock(int ProductId, int SizeId, int ColorId)
        {
            // 3.系統在Post Action【Mall/GetProductStock】讀取商品庫存。
            ProductStockListViewModel model = await IPRR.GetProductStock(ProductId, SizeId, ColorId);
            if (model != null)
            {
                // 4.系統判斷3傳回值!=null。
                // 5.系統傳回3傳回值之Stock。
                return model.Stock;
            }
            // 4a.系統判斷3傳回值==null。
            //  4a-1.系統傳回0。
            return 0;
        }

        [HttpPost]
        public async Task<int> PostMemberCarts(string MemberMobile, int ProductId, List<CartsViewModel> Carts)
        {
            int ret = 0;
            try
            {
                // 4.系統在Post Action【Mall/PostMemberCarts】將3上傳carts轉換為List<MemberCartsViewModel>。
                MemberCartsViewModel mcvm;
                List<MemberCartsViewModel> lstMCVM = new List<MemberCartsViewModel>();
                foreach (CartsViewModel item in Carts)
                {
                    mcvm = new MemberCartsViewModel();
                    mcvm.MemberMobile = MemberMobile;
                    mcvm.ProductId = item.productId;
                    mcvm.ProducSizeId = item.sizeId;
                    mcvm.ProductColorId = item.colorId;
                    mcvm.Quantity = item.quantity;
                    mcvm.ProductSize = item.size;
                    mcvm.ProductColor = item.color;
                    mcvm.Price = item.price;
                    lstMCVM.Add(mcvm);
                }
                // 5.系統在Post Action【Mall/PostMemberCarts】，新增多筆購物車資料。
                ret = await IMER.InsertMemberCarts(lstMCVM);
                // 6.系統判斷5執行成功。
                // 7.系統傳回5傳回值。
            }
            catch (Exception ex)
            {
                // 6a.系統判斷5執行時發生例外。
                //  6a-1.系統傳回1。
                ret = 1;
            }
            return ret;
        }
    }
}
