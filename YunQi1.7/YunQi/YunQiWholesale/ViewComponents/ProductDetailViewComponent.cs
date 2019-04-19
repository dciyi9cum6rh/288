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
    public class ProductDetailViewComponent : ViewComponent
    {
        private IProductRepository IMR { get; set; }

        public ProductDetailViewComponent(IConfiguration configuration, IProductRepository ProductRepository)
        {
            IMR = ProductRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
        }

        public async Task<IViewComponentResult> InvokeAsync(int ProductId, int MemberLevelId = -1)
        {
            // 3.系統在ViewComponent【ProductDetail】讀取商品基本資料。
            ProductListViewModel PLVM = await IMR.GetProduct(ProductId);
            // 4.系統在ViewComponent【ProductDetail】讀取商品尺寸資料。
            List<ProductSizeViewModel> lstPSVM = IMR.GetProductSizeSync(ProductId);
            // 5.系統在ViewComponent【ProductDetail】讀取商品顏色資料。
            List<ProductColorViewModel> lstPCVM = IMR.GetProductColorSync(ProductId);

            ProductStockListViewModel PSLVM;
            if (lstPSVM == null || lstPCVM == null || lstPSVM.Count == 0 || lstPCVM.Count == 0)
            {
                PSLVM = null;
            }
            else
            {
                // 6.系統在ViewComponent【ProductDetail】讀取商品第1個尺寸第1個顏色的庫存資料。
                PSLVM = await IMR.GetProductStock(ProductId, lstPSVM[0].ProducSizeId, lstPCVM[0].ProductColorId);
                if (PSLVM == null)
                {
                    // 6-1a.系統判斷6傳回null。
                    //  6-1a-1.系統New ProductStockListViewModel {}，將Stock設為0。
                    PSLVM = new ProductStockListViewModel { ProductId = ProductId, ProducSizeId = lstPSVM[0].ProducSizeId, ProductColorId = lstPCVM[0].ProductColorId, Stock = 0 };
                    //  6-1a-2.回7。
                }
            }
            // 6-0.系統在ViewComponent【ProductDetail】讀取讀取商品圖示清單：
            List<ProductImageListViewModel> lstPIVM = await IMR.GetProductImageList(ProductId, 0, 1000);
            // 7.系統回傳View(new ProductDetailMallViewModel { Product=3讀取值, ProductSize=4傳回值, ProductColor=5傳回值, ProductStock=6傳回值 })。
            //int? MemberLevelId = -1;
            //if (HttpContext.Session.GetInt32("MemberLevelId") != null)
            //    MemberLevelId = HttpContext.Session.GetInt32("MemberLevelId");
            //else
            //    MemberLevelId = -1;
            return View(new ProductDetailMallViewModel { Product = PLVM, ProductSize = lstPSVM, ProductColor = lstPCVM, ProductStock = PSLVM, ProductImage = lstPIVM, MemberLevelId = MemberLevelId });
        }
    }
}
