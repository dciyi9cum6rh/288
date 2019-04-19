using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    [Authorize]
    public class LedgerController : Controller
    {
        private ISalaryRepository ISR { get; set; }

        public LedgerController(IConfiguration configuration, ISalaryRepository SalaryRepository)
        {
            ISR = SalaryRepository;
            ISR.constr = configuration.GetConnectionString("SqlConn");
        }

        // 2.系統導向至Get Action【HomeImage/Index】。
        // 3.系統在Get Action【HomeImage/Index】判斷登入者擁有[首頁行銷圖示管理](27)之權限。
        [HavePrivilege(27)]
        public async Task<IActionResult> Index()
        {
            // 5.系統回傳View【HomeImage/Index】。
            return View();
        }

        //20181208 ---棋
        //3.系統以ajax呼叫Get Action【EmployeeMonthSalary/GetEmployeeMonthSalary】，並傳送。
        [HttpPost]
        public IActionResult GetLedgerList(string AccountingSubject, int jsDate, int StartPage = 1, int Page = 1, int LinkType = 0, string AClass = "page-link")
        {
            // 9.系統在Controller Action【EmployeeMonthSalary/GetEmployeeMonthSalary】，呼叫ViewComponent【EmployeeMonthSalary】，並傳送3傳送之Month,EmployeeMobile。
            return ViewComponent("GetLedgerList", new { AccountingSubject = AccountingSubject, Month = jsDate, StartPage = StartPage, Page = Page, LinkType = LinkType, AClass = AClass });
        }

        //20181208 ---棋
        //3.系統以ajax呼叫Get Action【LedgerController/GetInsertLedger】，並傳送。
        [HttpPost]
        public async Task<long> PosInsertLedger(string AccountingId, int Month, string InvoiceId, string LedgerDescription, long Money)
        {
            long ret = -9;
            ret = await ISR.InsertLedger(AccountingId, Month, InvoiceId, LedgerDescription, Money);
            return ret;
        }

        //20181208 ---棋
        //3.系統以ajax呼叫Get Action【LedgerController/GetInsertLedger】，並傳送。
        [HttpPost]
        public async Task<long> PostUpdateLedger(string AccountingId, int LedgerId, long Money, string InvoiceId, string LedgerDescription, int Month)
        {
            long ret = -9;
            ret = await ISR.UpdateLedger(AccountingId, LedgerId, Money, InvoiceId, LedgerDescription, Month);
            return ret;
        }

        //20181208 ---棋
        //3.系統以ajax呼叫Get Action【LedgerController/GetInsertLedger】，並傳送。
        [HttpPost]
        public async Task<long> PosDeleteLedger(string AccountingId, int LedgerId)
        {
            long ret = -9;
            ret = await ISR.DeleteLedger(AccountingId, LedgerId);
            return ret;
        }
    }
}