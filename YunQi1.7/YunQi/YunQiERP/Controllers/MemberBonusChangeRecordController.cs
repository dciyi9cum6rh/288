using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    //20181214 ---棋
    [Authorize]
    public class MemberBonusChangeRecordController : Controller
    {
        private IMemberRepository IMR { get; set; }
        private IMemberRepository IAR { get; set; }
        public MemberBonusChangeRecordController(IConfiguration configuration, IMemberRepository MemberRepository)
        {
            IMR = MemberRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
            IAR = MemberRepository;
            IAR.constr = configuration.GetConnectionString("SqlConn");
        }

        //4-1.系統在Get Action【MemberBonusChangeRecordController/Index】判斷登入者擁有批發會員獎金管理(29)之權限。
        [HavePrivilege(29)]
        public IActionResult Index()
        {
            return View();
        }
        
        //20181208 ---棋
        //3.系統以ajax呼叫Get Action【EmployeeMonthSalary/GetEmployeeMonthSalary】，並傳送。
        [HttpPost]
        public IActionResult GetMemberBonusChangeRecordList(string MemberMobile, int EventId , DateTime? sDate, DateTime? eDate, int StartPage = 1, int Page = 1, int LinkType = 0, string AClass = "page-link")
        {
            // 9.系統在Controller Action【EmployeeMonthSalary/GetEmployeeMonthSalary】，呼叫ViewComponent【EmployeeMonthSalary】，並傳送3傳送之Month,EmployeeMobile。
            return ViewComponent("MemberBonusChangeRecord", new { MemberMobile = MemberMobile, EventId = EventId , sDate = sDate, eDate = eDate, StartPage = StartPage, Page = Page, LinkType = LinkType, AClass = AClass });
        }

        public ActionResult GetBankAccountImg(string MemberPhone)
        {
            Task<MemberViewModel> ret = IMR.GetMember(MemberPhone) ;
            if(ret.Result.PictureContent !=null)
            {
                return File(ret.Result.PictureContent , "image/jpeg");
            }
            return new EmptyResult();
        }

        [HttpPost]
        public async Task<int> ChangeMemberBonusToMoney(int RecordId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                ret = await IAR.ChangeMemberBonusToMoney(RecordId);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                //10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳1。
                ret = 3;
            }
            return ret;
        }
    }
}