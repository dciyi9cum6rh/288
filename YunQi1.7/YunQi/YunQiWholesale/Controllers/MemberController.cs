using DataModel;
using IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace YunQiWholesale.Controllers
{
    public class MemberController : Controller
    {
        private IMemberRepository IMR { get; set; }
        private IEmployeeRepository IER { get; set; }

        public MemberController(IConfiguration configuration, IMemberRepository MemberRepository, IEmployeeRepository EmployeeRepository)
        {
            IMR = MemberRepository;
            IER = EmployeeRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
            IER.constr = configuration.GetConnectionString("SqlConn");
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        //20181222 ---棋
        //1.登入之會員點按[會員中心-許願池]。
        //2.系統以ajax呼叫Get Controller Action【Member/Followertriumph】，並傳送jMemberMobile。
        public async Task<IActionResult> Wishipool(int VersionId, DateTime? sDate, DateTime? eDate, string MessageValue, string NickName, int Page)
        {
            return ViewComponent("Wishipool", new { VersionId = 2, sDate = sDate, eDate = eDate, MessageValue = MessageValue, NickName = NickName, Page = Page });
        }

        //2018 ---棋
        //1.登入之會員點按[會員中心-會員調撥區]。
        //2.系統以ajax呼叫Get Controller Action【Member/Followertriumph】，並傳送jMemberMobile。
        public async Task<IActionResult> Membermove(int VersionId, DateTime? sDate, DateTime? eDate, string MessageValue, string NickName, int Page)
        {
            return ViewComponent("Membermove", new { VersionId = 1, sDate = sDate, eDate = eDate, MessageValue = MessageValue, NickName = NickName, Page = Page });
        }

        //20181212 ---棋
        //新增留言
        public async Task<List<MemberCartOneListViewModel>> GetMemberCartOneList(string MemberMobile, int ProductId, int ProductSizeId, int ProductColorId)
        {
            List<MemberCartOneListViewModel> ret = null;
            ret = await IMR.GetMemberCartOneList(MemberMobile, ProductId, ProductSizeId, ProductColorId);
            return ret;
        }

        //20181212 ---棋
        //讀取版規圖檔
        public async Task<FileResult> GetCagegoryImage(int VersionId)
        {
            GetImgVersionRuleViewModel onePC = await IER.GetCagegoryImage(VersionId);
            return File(onePC.VersionRulePictureContent, onePC.VersionRulePictureType);
        }

        //20181212 ---棋
        //新增留言
        public async Task<long> InsertMessageManagement(int VersionId, string MessageTitle, string MessageValue, string MemberMobile)
        {
            long ret = 0;
            ret = await IMR.InsertMessageManagement(VersionId, MessageTitle, MessageValue, MemberMobile);
            return ret;
        }

        //20181212 ---棋
        //新增回復
        public async Task<long> InsertReplyMessageManagement(int MessageId, string ReplyMessageValue, string ReplyMobile)
        {
            long ret = 0;
            ret = await IER.InsertReplyMessageManagement(MessageId, ReplyMessageValue, ReplyMobile);
            return ret;
        }

        //20181220 ---棋
        //1.登入之會員點按[會員中心-送貨地址]。
        //2.系統以ajax呼叫Get Controller Action【Member/Followertriumph】，並傳送jMemberMobile。
        public async Task<IActionResult> Shipaddress(string MemberMobile, string MemberName, string Phone, string DeliveryAddress, int Page)
        {
            return ViewComponent("Shipaddress", new { MemberMobile = MemberMobile, MemberName = MemberName, Phone = Phone, DeliveryAddress = DeliveryAddress, Page = Page });
        }

        //20181215 ---棋
        //1.登入之會員點按[會員中心-點數異動紀錄]。
        //2.系統以ajax呼叫Get Controller Action【Member/Followertriumph】，並傳送jMemberMobile。
        public async Task<IActionResult> Pointnotes(string MemberMobile, DateTime? sDate, DateTime? eDate, string ReferrerMobile, int Page)
        {
            return ViewComponent("Pointnotes", new { MemberMobile = MemberMobile, sDate = sDate, eDate = eDate, ReferrerMobile = ReferrerMobile, Page = Page });
        }

        //20181219 ---棋
        //1.登入之會員點按[會員中心-郵件中心]。
        //2.系統以ajax呼叫Get Controller Action【Member/Followertriumph】，並傳送jMemberMobile。
        public async Task<IActionResult> Mailcenter(string MemberMobile, string MessageValue, int Page)
        {
            //20181224 ---棋
            //修改已讀訊息
            await IMR.UpdateMailCenterReadStates(MemberMobile);
            return ViewComponent("Mailcenter", new { MemberMobile = MemberMobile, MessageValue = MessageValue, Page = Page });
        }

        //20181220 ---棋
        //使用者在新增送貨地址點選送出
        public async Task<long> InsertMemberDeliveryAddress(string MemberMobile, string MemberName, string Phone, string DeliveryAddress, string eMail)
        {
            long ret;
            ret = await IMR.InsertMemberDeliveryAddress(MemberMobile, MemberName, Phone, DeliveryAddress, eMail);
            return ret;
        }

        //20181220 ---棋
        //使用者在送貨地址點選更新
        public async Task<long> UpdateMemberDeliveryAddress(int MemberAddressId, string MemberMobile, string MemberNameN, string PhoneN, string DeliveryAddressN, string eMailN)
        {
            long ret;
            ret = await IMR.UpdateMemberDeliveryAddress(MemberAddressId, MemberMobile, MemberNameN, PhoneN, DeliveryAddressN, eMailN);
            return ret;
        }

        //20181220 ---棋
        //使用者在送貨地址點選更新
        public async Task<JsonResult> GetMemberDeliveryAddress(int MemberAddressId, string MemberMobile)
        {
            List<MemberDeliveryAddressListViewModel> ret = await IMR.GetMemberDeliveryAddress(MemberMobile, MemberAddressId);
            return Json(ret);
        }

        //20181130 ---棋
        //3.系統以ajax呼叫Post Action【Member/DeleteMyfavorite】，並傳送1點按之ProductId以及jMemberMobile。
        public async Task<int> DeleteMyfavorite(string jMemberMobile, int ProductId)
        {
            int ret = 0;
            try
            {
                ret = await IMR.DeleteMyfavorite(jMemberMobile, ProductId);
            }
            catch (Exception ex)
            {
                ret = -1;
            }
            return ret;
        }

        //20181119 ---棋
        //2.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile。
        public async Task<IActionResult> Myfollower(string MemberMobile, DateTime? sDate, DateTime? eDate, string ReferrerMobile, int Page)
        {
            //3.系統在Controller Action【Member / Myfollower】呼叫ViewComponent【MyfollowerViewComponent】，並傳送2傳送之jMemberMobile。
            return ViewComponent("Myfollower", new { MemberMobile = MemberMobile, sDate = sDate, eDate = eDate, ReferrerMobile = ReferrerMobile, Page = Page });
        }

        //20181121 ---棋
        //1.登入之會員點按[會員中心-我的下線業績]。
        //2.系統以ajax呼叫Get Controller Action【Member/Followertriumph】，並傳送jMemberMobile。
        public async Task<IActionResult> Followertriumph(string MemberMobile, DateTime? sDate, DateTime? eDate, string ReferrerMobile)
        {
            return ViewComponent("Followertriumph", new { MemberMobile = MemberMobile, sDate = sDate, eDate = eDate, ReferrerMobile = ReferrerMobile });
        }

        public async Task<IActionResult> Personaldata(string MemberMobile)
        {
            // 2-1.系統在Action【Member/Personaldata】中讀取會員基本資料。
            MemberViewModel MVM = await IMR.GetMember(MemberMobile);
            // 3.系統在Action【Member/Personaldata】中回傳View，並傳回2-1讀取值。
            return View(MVM);
        }

        // 9.系統接收6上傳資料。
        [HttpPost]
        //public async Task<int> PutMember(string MemberMobile, string MemberName, string NickName, byte sex,
        //                                    DateTime Birthday, string eMail, string LineId, string Phone, string ContactAddress,
        //                                    string ID, string Bank, string Branch, string AccountNunber, string AccountName)
        public async Task<int> PutMember(string MemberMobile, string MemberName, string NickName, byte sex,
                                            DateTime? Birthday, string eMail, string LineId, string Phone, string ContactAddress)
        {
            int ret = 0;
            try
            {
                // 10.系統在Post Action【Member/PutMember】，修改一筆會員資料。
                ret = await IMR.UpdateMember(MemberMobile, MemberName, NickName, sex, Birthday, eMail, LineId, Phone, ContactAddress);  //, ID, Bank, Branch, AccountNunber, AccountName);
                                                                                                                                        // 11.系統判斷10執行成功。
                                                                                                                                        // 12.系統傳回10傳回值。
            }
            catch (Exception ex)
            {
                // 111a.系統判斷10執行時發生例外。
                //  11a-1.系統傳回1。
                ret = 1;
            }
            return ret;
        }

        //20181213更新 ---棋
        // 9.系統接收6上傳資料。
        [HttpPost]
        public async Task<int> PutMemberLevel(IFormFile UpImgExample, string MemberMobile, string ReferrerMobile, string ID, string Bank, string Branch, string AccountNunber, string AccountName)
        {
            int ret = 0;
            try
            {
                // 8.系統接收6上傳資料。
                string FileName = MemberMobile;
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
                // 10.系統在Post Action【Member/PutMemberLevel】，修改一筆會員等級資料。
                if (ReferrerMobile == "" || ReferrerMobile == null)
                    ReferrerMobile = "ibobo";
                ret = await IMR.UpdateMemberLevelCart(FileName, PictureContent, PictureType, MemberMobile, 2, ID, Bank, Branch, AccountNunber, AccountName, DateTime.Now, null, ReferrerMobile);
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
        [HttpPost]
        public async Task<int> UsedMemberBonus(string MemberMobile , int Bonus, int UsedBonus)
        {
            int ret = 0;
            try
            {               
                ret = await IMR.UsedMemberBonus(MemberMobile, Bonus, UsedBonus);
               
            }
            catch (Exception ex)
            {
                // 111a.系統判斷10執行時發生例外。
                //  11a-1.系統傳回1。
                ret = 1;
            }
            return ret;
        }
        [HttpPost]
        public async Task<int> PostMemberFavorite(int ProductId, string MemberMobile)
        {
            int ret = 0;
            try
            {
                // 10.系統在Post Action【Member/PostMemberFavorite】新增一筆會員之我的最愛資料。
                ret = await IMR.InsertMemberFavorite(MemberMobile, ProductId);
                // 11.系統判斷10執行成功。
                // 12.系統傳回10傳回值。
            }
            catch (Exception ex)
            {
                // 111a.系統判斷10執行時發生例外。
                //  11a-1.系統傳回1。
                ret = 1;
            }
            return ret;
        }

        public async Task<IActionResult> Memberlevel()
        {
            return View();
        }

        public async Task<IActionResult> Wholesaletips()
        {
            //var renderedView = await RenderPartialViewToString("Wholesaletips", null);

            //Do what you want with the renderedView here

            return View();
            //return Json(renderedView);
        }

        // 2.系統以ajax呼叫Get Controller Action【Member/MyOrder】，並傳送jMemberMobile。
        public async Task<IActionResult> Myorder(string MemberMobile, DateTime? sDate, DateTime? eDate, string Product = "", string OrderId = "", byte OrderStateId = 0, int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "page-link")
        {
            // 3.系統在Controller Action【Member/MyOrder】呼叫ViewComponent【MemberOrderListViewComponent】，並傳送2傳送之jMemberMobile與頁碼。
            return ViewComponent("MemberOrderList", new { MemberMobile = MemberMobile, sDate = sDate, eDate = eDate, Product = Product, OrderId = OrderId, OrderStateId = OrderStateId, Page = Page, LinkType = LinkType, StartPage = StartPage, aclass = AClass });
        }

        public async Task<IActionResult> Myfavorite(string MemberMobile, string Product, int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "page-link")
        {
            // 3.系統在Controller Action【Member/Myfavorite】呼叫ViewComponent【MemberFavoriteListViewComponent】
            //  ，並傳送2傳送之jMemberMobile與頁碼。
            return ViewComponent("MemberFavoriteList", new { MemberMobile = MemberMobile, Product = Product, Page = Page, LinkType = LinkType, StartPage = StartPage, AClass = AClass });
            //return View();
        }
        public async Task<IActionResult> Myorderbonus(string MemberMobile, int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "page-link")
        {
            // 3.系統在Controller Action【Member/Myorderbonus】呼叫ViewComponent【MemberOrderBonusListViewComponent】
            //  ，並傳送2傳送之jMemberMobile與頁碼。
            return ViewComponent("MemberOrderBonusList", new { MemberMobile = MemberMobile, Page = Page, LinkType = LinkType, StartPage = StartPage, AClass = AClass });
            //return View();
        }
        [HttpPost]
        public async Task<int> UpdateOrderState3(string MemberMobile, string OrderId)
        {
            int ret = 0;
            try
            {
                // 4.系統在Action【Member/UpdateOrderState3】變更訂單狀態。
                ret = await IMR.UpdateOrderState(OrderId, 3);
                // 5.系統判斷4執行成功。
                // 6.系統傳回4傳回值。
            }
            catch (Exception ex)
            {
                // 5a.系統判斷4執行時發生例外。
                //  5a-1.系統傳回1。
                ret = 1;
            }
            return ret;
        }

        public async Task<IActionResult> FavoriteDetail()
        {
            //var renderedView = await RenderPartialViewToString("Myfollower", null);

            //Do what you want with the renderedView here

            return View();
            //return Json(renderedView);
        }
    }
}
