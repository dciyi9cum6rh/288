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
    public class OrderDetailViewComponent : ViewComponent
    {
        private IOrderRepository IMR { get; set; }

        public OrderDetailViewComponent(IConfiguration configuration, IOrderRepository OrderRepository)
        {
            IMR = OrderRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
        }

        public async Task<IViewComponentResult> InvokeAsync(string OrderId)
        {
            // 4.系統在ViewComponent【OrderDetail】讀取訂單明細。
            List<CartListViewModel> lstPSVM = await IMR.GetOrderDetail(OrderId);
            // 6.系統傳回View(4讀取值)。
            return View(lstPSVM);
        }
    }
}
