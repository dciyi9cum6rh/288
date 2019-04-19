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
    public class ProductLevelPathViewComponent : ViewComponent
    {
        private IProductRepository IMR { get; set; }

        public ProductLevelPathViewComponent(IConfiguration configuration, IProductRepository ProductRepository)
        {
            IMR = ProductRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
        }

        public async Task<IViewComponentResult> InvokeAsync(int ProductCategoryId)
        {
            // 8-1.系統在ViewComponent【ProductLevelPathViewComponent】讀取會員層級路徑清單：
            List<ProductLevelPathViewModel> lMLPVM = await IMR.GetProductLevelPath(ProductCategoryId);
            // 8-2.系統回傳View(8-1傳回值)。
            return View(lMLPVM);
        }
    }
}