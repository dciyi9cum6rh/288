using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    [Authorize]
    public class ShipmentController : Controller
    {
        private IOrderRepository IAR { get; set; }
        private IHostingEnvironment _environment { get; set; }

        public ShipmentController(IConfiguration configuration, IOrderRepository OrderRepository, IHostingEnvironment environment)
        {
            IAR = OrderRepository;
            IAR.constr = configuration.GetConnectionString("SqlConn");
            _environment = environment;
        }

        // 2.系統導向至Get Action【Shipment/Index】。
        // 3.系統在Get Action【Shipment/Index】判斷登入者擁有[出貨單下載](21)之權限。
        [HavePrivilege(21)]
        public async Task<IActionResult> Index()
        {
            List<string> result = new List<string>();
            // 4-1.系統讀取出貨單.xlsx清單。
            DirectoryInfo DirPath = new DirectoryInfo(Path.Combine(_environment.WebRootPath, @"xlsx"));
            foreach (FileInfo item in DirPath.GetFiles().Where(m => (m.Name.Contains(".xlsx") || m.Name.Contains(".pdf")) && !m.Name.Contains("原始")))
            {
                result.Add(item.Name);
            }
            // 5.系統回傳View【Shipment/Index】，並傳回4-1讀取.xlsx清單。
            return View(result);
        }
    }
}