using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    //20181220 ---棋
    [Authorize]
    public class MessageManagementController : Controller
    {
        private IEmployeeRepository IER { get; set; }
        private IMemberRepository IMR { get; set; }

        public MessageManagementController(IConfiguration configuration, IEmployeeRepository EmployeeRepository, IMemberRepository MemberRepository)
        {
            IER = EmployeeRepository;
            IMR = MemberRepository;
            IER.constr = configuration.GetConnectionString("SqlConn");
            IMR.constr = configuration.GetConnectionString("SqlConn");
        }

        // 2.系統導向至Get Action【EmployeeMonthSalary/Index】。
        // 3.系統在Get Action【EmployeeMonthSalary/Index】判斷登入者擁有[薪資管理](25)之權限。
        [HavePrivilege(31)]
        public async Task<IActionResult> Index()
        {
            List<VersionListViewModel> VersionList = await IER.GetVersion();
            return View(VersionList);
        }

        //9.系統在Controller Action【MemberBonus/GetMemberBonusDetailList】，呼叫ViewComponent【MemberBonusDetailList】，並傳送3傳送之jReferrerMobile。
        public IActionResult MessageManagementList(int VersionId, DateTime? sDate, DateTime? jDate, string MessageValue, string MemberMobile, string NickName, int StartPage = 1, int Page = 1, int LinkType = 0, string AClass = "inner-page-link")
        {
            return ViewComponent("MessageManagement", new { VersionId = VersionId, sDate = sDate, jDate = jDate, MessageValue = MessageValue, MemberMobile = MemberMobile, NickName = NickName, StartPage = StartPage, Page = Page, LinkType = LinkType, AClass = AClass });
        }

        //9.系統在Controller Action【MemberBonus/GetMemberBonusDetailList】，呼叫ViewComponent【MemberBonusDetailList】，並傳送3傳送之jReferrerMobile。
        public IActionResult MessageManagementData(int MessageId, int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "inner-page-link")
        {
            return ViewComponent("MessageManagementData", new { MessageId = MessageId, Page = Page, LinkType = LinkType, StartPage = StartPage, AClass = AClass });
        }

        //使用者在留言清單中點選回覆留言
        public async Task<long> InsertReplyMessageManagement(int MessageId, string ReplyMessageValue, string ReplyMobile)
        {
            long ret;
            ret = await IER.InsertReplyMessageManagement(MessageId, ReplyMessageValue, ReplyMobile);
            return ret;
        }

        //使用者在留言版中點選刪除留言
        public async Task<long> DeleteMessageManagement(int MessageId)
        {
            long ret;
            ret = await IER.DeleteMessageManagement(MessageId);
            return ret;
        }

        //使用者在留言清單中點選刪除回覆
        public async Task<long> DeleteReplyMessageManagement(int ReplyMessageId)
        {
            long ret;
            ret = await IER.DeleteReplyMessageManagement(ReplyMessageId);
            return ret;
        }

        //20181213更新 ---棋
        // 上傳版規照片
        [HttpPost]
        public async Task<int> UpdateMemberLevelCartImg(int upVersionId, IFormFile UpImgExample)
        {
            int ret = 0;
            try
            {
                // 8.系統接收6上傳資料。
                string FileName = upVersionId.ToString();
                byte[] PictureContent = null;
                string PictureType = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async
                    PictureType = UpImgExample.ContentType;
                    using (var memoryStream = new MemoryStream())
                    {
                        await UpImgExample.CopyToAsync(memoryStream);
                        PictureContent = memoryStream.ToArray();
                    }
                }

                ret = await IER.UpdateMemberLevelCart(upVersionId, PictureContent, PictureType, FileName);
                // 11.系統判斷10執行成功。
                // 12.系統傳回10傳回值。
                return ret;
            }
            catch (Exception ex)
            {
                // 111a.系統判斷10執行時發生例外。
                //  11a-1.系統傳回1。
                ret = 1;
            }
            return ret;
        }

        //20181212 ---棋
        //讀取版規圖檔
        public async Task<FileResult> GetCagegoryImage(int VersionId)
        {
            GetImgVersionRuleViewModel onePC = await IER.GetCagegoryImage(VersionId);
            return File(onePC.VersionRulePictureContent, onePC.VersionRulePictureType);
        }
    }
}