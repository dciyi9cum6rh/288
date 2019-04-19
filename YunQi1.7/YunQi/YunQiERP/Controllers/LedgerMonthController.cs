using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    [Authorize]
    public class LedgerMonthController : Controller
    {
        private ISalaryRepository ISR { get; set; }

        public LedgerMonthController(IConfiguration configuration, ISalaryRepository SalaryRepository)
        {
            ISR = SalaryRepository;
            ISR.constr = configuration.GetConnectionString("SqlConn");
        }

        // 2.系統導向至Get Action【LedgerMonthController/Index】。
        // 3.系統在Get Action【LedgerMonthController/Index】判斷登入者擁有[首頁行銷圖示管理](28)之權限。
        [HavePrivilege(28)]
        public async Task<IActionResult> Index()
        {
            // 5.系統回傳View【LedgerMonthController/Index】。
            return View();
        }

        //20181214 ---棋
        //3.系統以ajax呼叫Get Action【LedgerMonthController/GetLedgerMonthList】，並傳送。
        [HttpPost]
        public IActionResult GetLedgerMonthList(int Month)
        {
            // 9.系統在Controller Action【LedgerMonthController/GetLedgerMonthList】，呼叫ViewComponent【GetLedgerMonthList】，並傳送3傳送之Month,EmployeeMobile。
            return ViewComponent("LedgerMonthList", new { Month = Month });
        }
    }
}