using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authorization;
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
    public class MessageCenterController : Controller
    {
        private IMemberRepository IMR { get; set; }
        private IEmployeeRepository IER { get; set; }

        public MessageCenterController(IConfiguration configuration, IMemberRepository MemberRepository, IEmployeeRepository EmployeeRepository)
        {
            IMR = MemberRepository;
            IER = EmployeeRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
            IER.constr = configuration.GetConnectionString("SqlConn");
        }

        //4-1.系統在Get Action【MessageCenterController/Index】判斷登入者擁有訊息管理(30)之權限。
        [HavePrivilege(30)]
        public async Task<IActionResult> Index()
        {
            List<MemberLevelViewModel> MembevLevel = await IMR.GetMembevLevel();
            return View(MembevLevel);
        }

        [HavePrivilege(30)]
        public async Task<List<MemberLevelViewModel>> GetMembevLevel()
        {
            List<MemberLevelViewModel> MembevLevel = await IMR.GetMembevLevel();
            return MembevLevel;
        }

        [HavePrivilege(30)]
        public async Task<List<MemberLevelViewModel>> GetStrMembevLevel(string MemberLevel)
        {
            List<MemberLevelViewModel> MembevLevel = await IMR.GetMembevLevel(MemberLevel);
            return MembevLevel;
        }

        [HavePrivilege(30)]
        public async Task<int> DeleteMailCenterMessage(int MessageId)
        {
            int ret = 0;
            ret = await IER.DeleteMailCenterMessage(MessageId);
            return ret;
        }

        [HavePrivilege(30)]
        public async Task<int> GetMailCenterTop1()
        {
            int ret = 0;
            ret = await IER.GetMailCenterTop1();
            return ret;
        }

        //新增後台訊息
        [HavePrivilege(30)]
        public async Task<int> InsertMailCenterMessage(List<MailCenterDataModel> MailCenter)
        {
            int ret = 0;
            ret = await IER.InsertMailCenterMessage(MailCenter);
            return ret;
        }

        //新增前台訊息
        [HavePrivilege(30)]
        public async Task<int> InsertMemberMessage(List<memberMailCenter> memberMailCenter)
        {
            int ret = 0;
            ret = await IMR.InsertMemberMessage(memberMailCenter);
            return ret;
        }

        [HttpPost]
        [HavePrivilege(30)]
        public async Task<List<MemberLevelListViewModel>> GetMemberLevelList(int MemberLevelid)
        {
            List<MemberLevelListViewModel> MemberLevelList = await IMR.GetMemberLevelList(MemberLevelid);
            return MemberLevelList;
        }

        //20181208 ---棋
        //3.系統以ajax呼叫Get Action【EmployeeMonthSalary/GetEmployeeMonthSalary】，並傳送。
        [HttpPost]
        public IActionResult MessageCenterList(string MessageValue, int MemberLevelId, DateTime? sDate, DateTime? eDate, int StartPage = 1, int Page = 1, int LinkType = 0, string AClass = "page-link")
        {
            // 9.系統在Controller Action【EmployeeMonthSalary/GetEmployeeMonthSalary】，呼叫ViewComponent【EmployeeMonthSalary】，並傳送3傳送之Month,EmployeeMobile。
            return ViewComponent("MessageCenterList", new { MessageValue = MessageValue, MemberLevelId = MemberLevelId, sDate = sDate, eDate = eDate, StartPage = StartPage, Page = Page, LinkType = LinkType, AClass = AClass });
        }
    }
}