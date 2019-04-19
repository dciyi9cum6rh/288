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
    [Authorize]
    public class VipMemberController : Controller
    {
        private IMemberRepository IAR { get; set; }

        public VipMemberController(IConfiguration configuration, IMemberRepository MemberRepository)
        {
            IAR = MemberRepository;
            IAR.constr = configuration.GetConnectionString("SqlConn");
        }

        //20181212 ---棋
        //讀取準VIP客戶上傳圖檔
        public async Task<FileResult> GetCagegoryImage(string MemberMobile)
        {
            MemberViewModel onePC = await IAR.GetMember(MemberMobile);
            return File(onePC.PictureContent, onePC.PictureType);
        }

        // 2.系統導向至Get  Action【VipMember /Index】。
        // 3.系統在Get Action【VipMember/Index】判斷登入者擁有[批發會員管理] (14)之權限。
        [HavePrivilege(14)]
        public async Task<IActionResult> Index()
        {
            // 4-1.系統讀取會員等級資料：
            List<MemberLevelViewModel> lstMLVM = await IAR.GetMembevLevel();
            ViewBag.EmployeeMobile = HttpContext.Session.GetString("CurrentEmployeeMobile");
            ViewBag.TR = HttpContext.Session.GetObjectFromJson<List<int>>("EmployeeRights");
            // 5.系統回傳View【VipMember/Index】
            return View(lstMLVM);
        }

        [HttpPost]
        public IActionResult GetMemberList(int Enabled, string MemberMobile = "", string MemberName = "", string ReferrerMobile = "", int MemberLevelId = 0, int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "page-link")
        {
            // 3.系統在Post Controller Action【VipMember/GetMemberList】呼叫ViewComponent【MemberList】，並傳送jMemberMobile、jMemberName、jReferrerMobile、jMemberLevelId、jEnaled。
            return ViewComponent("MemberList", new { Enabled = Enabled, MemberMobile = MemberMobile, MemberName = MemberName, ReferrerMobile = ReferrerMobile, MemberLevelId = MemberLevelId, Page = Page, LinkType = LinkType, StartPage = StartPage, aclass = AClass });
        }

        // 4.系統在Post Action【VipMember//UpdateMemberEnabled】驗証使用者有[會員停權](15)權限。
        [HaveRightint2(15)]
        [HttpPost]
        public async Task<int> UpdateMemberEnabled(string MemberMobile, byte Enabled)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 5.系統重設會員停權狀態料。
                ret = await IAR.UpdateMemberEnabled(MemberMobile, Enabled);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                //10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳1。
                ret = 1;
            }
            return ret;
        }

        // 4.系統在Post Action【VipMember/UpdateMemberLevel】驗証使用者有[核準批發會員](16)權限。
        [HaveRightint1(16)]
        [HttpPost]
        public async Task<int> UpdateMemberLevel(string MemberMobile, int MemberLevelId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 5.系統重設會員等級。
                ret = await IAR.UpdateMemberLevel(MemberMobile, MemberLevelId, null, DateTime.Now, "");
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

        // 5-0.系統在Post Action【VipMember/UpdateMemberReferrer】驗証使用者有[轉換會員推薦人](17)權限。
        [HaveRightint1(17)]
        [HttpPost]
        public async Task<int> UpdateMemberReferrer(string NewReferrerMobile, string MemberMobile = "", string MemberName = "", string ReferrerMobile = "", int MemberLevelId = 0, byte Enabled = 10)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 5-1.系統驗証新推薦人手機：
                int val = await IAR.ValidateReferrerMobile(NewReferrerMobile);
                if (val != 0) return val;
                // 5-2.系統在Post Controller Action【VipMember/UpdateMemberReferrer】讀取會員清單：
                List<MemberViewModel> lMLVM = await IAR.GetMemberList(MemberMobile, MemberName, ReferrerMobile, MemberLevelId, Enabled, 0, 1000);
                // 6.系統將5-2讀取值轉換為List<UpdateMemberReferrerModel>。
                List<UpdateMemberReferrerModel> lstUMRM = new List<UpdateMemberReferrerModel>();
                UpdateMemberReferrerModel UMRM;

                UMRM = new UpdateMemberReferrerModel();
                UMRM.MemberMobile = MemberMobile;
                UMRM.ReferrerMobile = NewReferrerMobile;
                lstUMRM.Add(UMRM);

                // 7.系統更新會員之推薦人手機。
                ret = await IAR.UpdateMemberReferrer(lstUMRM);
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
        [HttpPost]
        public async Task<int> ChangeMemberBonus(string MemberMobile, string Memo,int Bonus)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {              
                ret = await IAR.ChangeMemberBonus(MemberMobile,Memo, Bonus);
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
        public async Task<IActionResult> GetMember(string MemberMobile)
        {
            return ViewComponent("MemberList", new { MemberMobile = MemberMobile });
        }
    }
}