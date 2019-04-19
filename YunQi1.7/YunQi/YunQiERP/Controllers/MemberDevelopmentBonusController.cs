using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    //20181203 ---棋
    [Authorize]
    public class MemberDevelopmentBonusController : Controller
    {
        private IMemberRepository IMR { get; set; }

        public MemberDevelopmentBonusController(IConfiguration configuration, IMemberRepository MemberRepository)
        {
            IMR = MemberRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
        }

        //20181203 ---棋
        //3.系統在Get Action【MemberDevelopmentBonus /Index】判斷登入者擁有批發會員獎金管理(22)之權限。
        [HavePrivilege(23)]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        //20181203 ---棋
        //4-1.系統在Get Action【MemberDevelopmentBonus/AccountMemberBonus】判斷登入者擁有批發會員獎金管理(22)之權限。
        [HavePrivilege(23)]
        [HttpPost]
        public async Task<int> AccountMemberDevelopmentBonus(int Month)
        {
            int ret;
            ret = await IMR.AccountMemberDevelopmentBonus(Month);
            return ret;
        }

        //20181203 ---棋
        //4-1.系統在Get Action【MemberDevelopmentBonus/MemberDevelopmentBonus】判斷登入者擁有批發會員獎金管理(22)之權限。
        [HavePrivilege(23)]
        [HttpPost]
        public async Task<int> CaculateMemberDevelopmentBonus(int Month)
        {
            int ret;
            ret = await IMR.CaculateMemberDevelopmentBonus(Month);
            return ret;
        }

        //20181203 ---棋
        //3.系統以ajax呼叫Get Action【MemberBonus/GetMemberBonusList】，並傳送jMemberMobile/jMemberMobileWhere/jsDate。
        [HavePrivilege(23)]
        [HttpPost]
        public IActionResult MemberDevelopmentBonusList(string MemberMobile, int jsDate, int StartPage = 1, int Page = 1, int LinkType = 0, string AClass = "page-link")
        {
            //4.系統在Get Action【MemberBonus/GetMemberBonusList】呼叫ViewComponent【MemberBonusListViewComponent】，並傳送jMemberMobile/jMemberMobileWhere/jsDate與1點按頁碼。
            return ViewComponent("MemberDevelopmentBonusList", new { MemberMobile = MemberMobile, Month = jsDate, StartPage = StartPage, Page = Page, LinkType = LinkType, AClass = AClass });
        }

        //9.系統在Controller Action【MemberDevelopmentBonus/GetMemberBonusDetailList】，呼叫ViewComponent【MemberBonusDetailList】，並傳送3傳送之jReferrerMobile。
        [HavePrivilege(23)]
        [HttpPost]
        public IActionResult MemberDevelopmentBonusDetailList(string ReferrerMobile, int jsDate, int StartPage = 1, int Page = 1, int LinkType = 0, string AClass = "inner-page-link")
        {
            return ViewComponent("MemberDevelopmentBonusDetailList", new { ReferrerMobile = ReferrerMobile, Month = jsDate, StartPage = StartPage, Page = Page, LinkType = LinkType, AClass = AClass });
        }
    }
}