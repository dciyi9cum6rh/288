using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    //20181205 ---棋
    [Authorize]
    public class EmployeeDevelopmentBonusController : Controller
    {
        private IMemberRepository IMR { get; set; }

        public EmployeeDevelopmentBonusController(IConfiguration configuration, IMemberRepository MemberRepository)
        {
            IMR = MemberRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
        }

        //20181203 ---棋
        //3.系統在Get Action【EmployeeDevelopmentBonus/Index】判斷登入者擁有批發會員獎金管理(24)之權限。
        [HavePrivilege(24)]
        public IActionResult Index()
        {
            return View();
        }

        //20181203 ---棋
        //4-1.系統在Get Action【MemberDevelopmentBonus/AccountMemberBonus】判斷登入者擁有批發會員獎金管理(24)之權限。
        [HavePrivilege(24)]
        [HttpPost]
        public async Task<int> AccountEmployeeDevelopmentBonus(int Month)
        {
            int ret;
            ret = await IMR.AccountEmployeeDevelopmentBonus(Month);
            return ret;
        }

        //4.系統以ajax呼叫POST Action【EmployeeDevelopmentBonus/CaculateEmployeeDevelopmentBonus】，並傳送jsDate。
        [HavePrivilege(24)]
        [HttpPost]
        public async Task<int> CaculateEmployeeDevelopmentBonus(int Month)
        {
            //5.系統在POST Action【EmployeeDevelopmentBonus / CaculateEmployeeDevelopmentBonus】計算業務發展獎金。
            int ret;
            ret = await IMR.CaculateEmployeeDevelopmentBonus(Month);
            return ret;
        }

        [HavePrivilege(24)]
        [HttpPost]
        public IActionResult GetEmployeeDevelopmentBonusList(string MemberMobile, int jsDate, int StartPage = 1, int Page = 1, int LinkType = 0, string AClass = "page-link")
        {
            return ViewComponent("EmployeeDevelopmentBonusList", new { EmployeeMobile = MemberMobile, Month = jsDate, StartPage = StartPage, Page = Page, LinkType = LinkType, AClass = AClass });
        }

        [HavePrivilege(24)]
        [HttpPost]
        public IActionResult GetEmployeeDevelopmentBonusDetailList(string ReferrerMobile, int jsDate, int StartPage = 1, int Page = 1, int LinkType = 0, string AClass = "inner-page-link")
        {
            return ViewComponent("EmployeeDevelopmentBonusDetailList", new { EmployeeMobile = ReferrerMobile, Month = jsDate, StartPage = StartPage, Page = Page, LinkType = LinkType, AClass = AClass });
        }
    }
}