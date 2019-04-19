using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    //20181130  --棋
    [Authorize]
    public class MemberBonusController : Controller
    {
        private IOrderRepository IOR { get; set; }

        public MemberBonusController(IConfiguration configuration, IOrderRepository OrderRepository)
        {
            IOR = OrderRepository;
            IOR.constr = configuration.GetConnectionString("SqlConn");
        }

        //3.系統在Get Action【MemberBonus /Index】判斷登入者擁有批發會員獎金管理(22)之權限。
        [HavePrivilege(22)]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        //4-1.系統在Get Action【MemberBonus/CaculateMemberBonus】判斷登入者擁有批發會員獎金管理(22)之權限。
        [HavePrivilege(22)]
        [HttpPost]
        public async Task<int> CaculateMemberBonus(int Month)
        {
            int ret;
            ret = await IOR.CaculateMemberBonus(Month);
            return ret;
        }

        //4-1.系統在Get Action【MemberBonus/AccountMemberBonus】判斷登入者擁有批發會員獎金管理(22)之權限。
        [HavePrivilege(22)]
        [HttpPost]
        public async Task<int> AccountMemberBonus(int Month)
        {
            int ret;
            ret = await IOR.AccountMemberBonus(Month);
            return ret;
        }

        //3.系統以ajax呼叫Get Action【MemberBonus/GetMemberBonusList】，並傳送jMemberMobile/jMemberMobileWhere/jsDate。
        [HttpPost]
        public IActionResult GetMemberBonusList(string ReferrerMobile, int jsDate, int StartPage = 1, int Page = 1, int LinkType = 0, string AClass = "page-link")
        {
            //4.系統在Get Action【MemberBonus/GetMemberBonusList】呼叫ViewComponent【MemberBonusListViewComponent】，並傳送jMemberMobile/jMemberMobileWhere/jsDate與1點按頁碼。
            return ViewComponent("MemberBonusList", new { ReferrerMobile = ReferrerMobile, Month = jsDate, StartPage = StartPage, Page = Page, LinkType = LinkType, AClass = AClass });
        }

        //9.系統在Controller Action【MemberBonus/GetMemberBonusDetailList】，呼叫ViewComponent【MemberBonusDetailList】，並傳送3傳送之jReferrerMobile。
        public IActionResult GetMemberBonusDetailList(string ReferrerMobile, int jsDate, int StartPage = 1, int Page = 1, int LinkType = 0, string AClass = "inner-page-link")
        {
            return ViewComponent("MemberBonusDetailList", new { ReferrerMobile = ReferrerMobile, Month = jsDate, StartPage = StartPage, Page = Page, LinkType = LinkType, AClass = AClass });
        }
    }
}