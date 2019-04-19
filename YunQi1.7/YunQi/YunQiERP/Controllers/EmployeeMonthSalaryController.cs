using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    [Authorize]
    public class EmployeeMonthSalaryController : Controller
    {
        private IEmployeeRepository IAR { get; set; }
        private ISalaryRepository ISR { get; set; }

        public EmployeeMonthSalaryController(IConfiguration configuration, IEmployeeRepository EmployeeRepository, ISalaryRepository SalaryRepository)
        {
            IAR = EmployeeRepository;
            ISR = SalaryRepository;
            IAR.constr = configuration.GetConnectionString("SqlConn");
            ISR.constr = configuration.GetConnectionString("SqlConn");
        }

        // 2.系統導向至Get Action【EmployeeMonthSalary/Index】。
        // 3.系統在Get Action【EmployeeMonthSalary/Index】判斷登入者擁有[薪資管理](25)之權限。
        [HavePrivilege(25)]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        //20181203 ---棋
        //4-1.系統在Get Action【EmployeeMonthSalaryController/GetAccountSalary】判斷登入者擁有批發會員獎金管理(25)之權限。
        [HttpPost]
        public async Task<int> GetAccountSalary(int Month)
        {
            int ret;
            ret = await ISR.AccountSalary(Month);
            return ret;
        }

        //2in1
        [HttpPost]
        public async Task<JsonResult> PostSalaryMonthEmployeeDetailList(string EmployeeMobile, int Month, int Skip = 0, int RowsPerPage = 10)
        {
            List<GetEmployeeBaseSalaryViewModel> lGEBS = await ISR.GetEmployeeBaseSalary(EmployeeMobile);
            List<SalaryClassListViewModel> lGSCL = await ISR.GetSalaryClassList();
            List<SalaryMonthEmployeeDetailListViewModel> LSMEDLVM = await ISR.GetSalaryMonthEmployeeDetailList(EmployeeMobile, Month, Skip, RowsPerPage);
            return Json(new SalaryMonthEmployeeDetailListManageViewModel
            {
                lGEBS = lGEBS,
                lSCLVM = lGSCL,
                LSMEDLVM = LSMEDLVM,
            });
        }

        [HttpPost]
        public async Task<int> GetDeleteSalary(string EmployeeMobile, int Month)
        {
            int ret = 0;
            ret = await ISR.GetDeleteSalary(EmployeeMobile, Month);
            return ret;
        }

        //20181208 ---棋
        //3.系統以ajax呼叫Get Action【EmployeeMonthSalary/GetEmployeeMonthSalary】，並傳送。
        [HttpPost]
        public IActionResult GetEmployeeMonthSalary(string EmployeeMobile, int jsDate, int StartPage = 1, int Page = 1, int LinkType = 0, string AClass = "page-link")
        {
            // 9.系統在Controller Action【EmployeeMonthSalary/GetEmployeeMonthSalary】，呼叫ViewComponent【EmployeeMonthSalary】，並傳送3傳送之Month,EmployeeMobile。
            return ViewComponent("EmployeeMonthSalary", new { EmployeeMobile = EmployeeMobile, Month = jsDate, StartPage = StartPage, Page = Page, LinkType = LinkType, AClass = AClass });
        }

        [HttpPost]
        public async Task<JsonResult> InsertSalary(int Month, string EmployeeMobile, List<SalaryDataModel> SalaryDatas)
        {
            int ret = 0;
            ret = await ISR.InsertSalary(Month, EmployeeMobile, SalaryDatas);
            return Json(ret);
        }
    }
}