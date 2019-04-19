using IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace YunQiWholesale.Controllers
{
    public class JoinusController : Controller
    {
        //private ICompositeViewEngine _viewEngine;

        private IMemberRepository IMR { get; set; }

        public JoinusController(IConfiguration configuration, IMemberRepository MemberRepository)
        {
            IMR = MemberRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
        }

        public async Task<IActionResult> Index()
        {
            //var renderedView = await RenderPartialViewToString("Index", null);

            //Do what you want with the renderedView here

            return View();
            //return Json(renderedView);
        }

        //20181225 ---棋
        public async Task<IActionResult> Register()
        {
            return ViewComponent("Register");
        }

        [HttpPost]
        public async Task<JsonResult> JoinMember(string MemberMobile, string Password, string MemberName, string NickName, byte sex, string eMail, string ContactAddress)
        {
            int ret = 0;
            int ValidateCode = 0;
            string smsresp = "";
            // 10.系統在Post Action【Joinus/JoinMember】，新增一筆會員資料。
            try
            {
                //20181216 ---棋
                //產生一筆6位數 Guid 手機驗證碼
                ValidateCode = int.Parse(Utility.Data.IntGuid().ToString().Substring(4, 6));
                // 5.系統刪除一筆商品分類資料。
                ret = await IMR.InsertMember(MemberMobile, Utility.Data.HashPassword(Password), 1, MemberName, NickName, sex, eMail, ContactAddress, ValidateCode);
                // 11.系統判斷10執行成功。
                // 12.系統傳回10傳回值。
                if (ret == 0)
                {
                    string url = "";
                    url = "username=yunqi2018";
                    url = url + "&password=ashin885api";
                    url = url + "&mobile=" + MemberMobile;
                    url = url + "&message=感謝您加入允奇國際會員，請在頁面上輸入驗證碼『" + ValidateCode + "』，20分鐘後失效，感謝您~";
                    WebClient wc = new WebClient();
                    Stream st = wc.OpenRead("http://api.twsms.com/json/sms_send.php?" + url);
                    StreamReader sr = new StreamReader(st);
                    smsresp = sr.ReadToEnd();
                    sr.Close();
                    st.Close();
                }
            }
            catch (Exception ex)
            {
                // 111a.系統判斷10執行時發生例外。
                //  11a-1.系統傳回1。
                ret = -99;
            }
            return Json(new { ret = ret, smsresp = smsresp });
        }

        [HttpPost]
        public async Task<int> MemberVerification(string MemberMobile, int ValidateCode)
        {
            int ret = 0;

            ret = await IMR.MemberVerification(MemberMobile, ValidateCode);

            return ret;
        }

        public async Task<IActionResult> Shoppingflow()
        {
            //var renderedView = await RenderPartialViewToString("Shoppingflow", null);

            //Do what you want with the renderedView here

            return View();
            //return Json(renderedView);
        }

        public async Task<IActionResult> Payway()
        {
            //var renderedView = await RenderPartialViewToString("Payway", null);

            //Do what you want with the renderedView here

            return View();
            //return Json(renderedView);
        }

        public async Task<IActionResult> Qanda()
        {
            //var renderedView = await RenderPartialViewToString("Qanda", null);

            //Do what you want with the renderedView here

            return View();
            //return Json(renderedView);
        }

        public async Task<IActionResult> Shipdays()
        {
            //var renderedView = await RenderPartialViewToString("Shipdays", null);

            //Do what you want with the renderedView here

            return View();
            //return Json(renderedView);
        }
    }
}
