using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using YunQiWholesale.Models;

namespace YunQiWholesale.Controllers
{
    public class HomeController : Controller
    {
        private ICompositeViewEngine _viewEngine;
        private IMediaRepository IMR { get; set; }
        private IParameterRepository IPR { get; set; }
        private IProductRepository IPRR { get; set; }
        private IMemberRepository IMER { get; set; }

        public HomeController(ICompositeViewEngine viewEngine, IConfiguration configuration, IMediaRepository MediaRepository, IParameterRepository ParameterRepository, IProductRepository ProductRepository, IMemberRepository MemberRepository)
        {
            _viewEngine = viewEngine;
            IMR = MediaRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
            IPR = ParameterRepository;
            IPR.constr = configuration.GetConnectionString("SqlConn");
            IPRR = ProductRepository;
            IPRR.constr = configuration.GetConnectionString("SqlConn");
            IMER = MemberRepository;
            IMER.constr = configuration.GetConnectionString("SqlConn");
        }

        public async Task<IActionResult> Index()
        {
            // 3.系統在Action【Home/Index】讀取首頁行銷圖示。
            List<HomeImageViewModel> lHIMV = await IMR.GetHomeImageList(0, 1000);
            // 4.系統在Action【Home/Index】讀取youtube影片網址。
            YoutubeVideoViewModel YVVM = await IPR.GetYoutubeVideoList();
            // 5.系統在Action【Home/Index】讀取最新商品清單。
            List<ProductListViewModel> lPLVM = await IPRR.GetNewProductList(6);
            // 6.系統傳回View【Home/Index】，並回傳new HomeViewModel { HomeImage=3讀取值, YoutubeVideo=4讀取值, NewProduct=5讀取值}。
            ViewBag.MemberMobile = HttpContext.Session.GetString("MemberMobile");
            if (HttpContext.Session.GetInt32("MemberLevelId") != null)
                ViewBag.MemberLevelId = HttpContext.Session.GetInt32("MemberLevelId");
            else
                ViewBag.MemberLevelId = -1;
            ViewBag.NickName = HttpContext.Session.GetString("NickName");
                      
            return View(new HomeViewModel { HomeImage = lHIMV, YoutubeVideo = YVVM, NewProduct = lPLVM });
        }

        public async Task<FileResult> GetOneHomeImage(int HomeImageId)
        {
            HomeImageViewModel onePC = await IMR.GetOneHomeImage(HomeImageId);
            if (onePC == null) return null;
            return File(onePC.PictureContent, onePC.PictureType);
        }

        public async Task<FileResult> GetProductImage(int ProeuctId)
        {
            ProductImageViewModel onePC = await IPRR.GetProductImage(ProeuctId);
            if (onePC == null) return null;
            return File(onePC.PictureContent, onePC.PictureType);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Main()
        {
            // 3.系統在Action【Home/Index】讀取首頁行銷圖示。
            List<HomeImageViewModel> lHIMV = await IMR.GetHomeImageList(0, 1000);
            // 4.系統在Action【Home/Index】讀取youtube影片網址。
            YoutubeVideoViewModel YVVM = await IPR.GetYoutubeVideoList();
            // 5.系統在Action【Home/Index】讀取最新商品清單。
            List<ProductListViewModel> lPLVM = await IPRR.GetNewProductList(6);
            // 6.系統傳回View【Home/Index】，並回傳new HomeViewModel { HomeImage=3讀取值, YoutubeVideo=4讀取值, NewProduct=5讀取值}。
            ViewBag.MemberMobile = HttpContext.Session.GetString("MemberMobile");
            if (HttpContext.Session.GetInt32("MemberLevelId") != null)
                ViewBag.MemberLevelId = HttpContext.Session.GetInt32("MemberLevelId");
            else
                ViewBag.MemberLevelId = -1;
            ViewBag.NickName = HttpContext.Session.GetString("NickName");
            return View(new HomeViewModel { HomeImage = lHIMV, YoutubeVideo = YVVM, NewProduct = lPLVM });
            //return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            // 2.系統呼叫Controller Action【Home/Login】。
            // 3.系統在Action【Home/Login】中回傳View【Home/Login】。
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateRecaptcha]   //20181224 ---棋 google驗證
        public async Task<JsonResult> Login(MemberLoginViewModel LoginViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // 10.系統在POST【Home/Login】驗証是否為合法會員。
                    int ret = await IMER.MemberLogin(LoginViewModel.MemberMobile, Utility.Data.HashPassword(LoginViewModel.MemberPassword));
                    if (ret == 0)
                    {
                        // 11.系統讀取會員資料。
                        MemberViewModel MVM = await IMER.GetMember(LoginViewModel.MemberMobile);
                        // 12.系統判斷10~11成功執行。
                        // 12-1.系統將11讀取MemberMobile，11讀取MemberLevel暫存在Session。
                        HttpContext.Session.SetString("MemberMobile", MVM.MemberMobile);
                        HttpContext.Session.SetInt32("MemberLevelId", MVM.MemberLevelId);
                        HttpContext.Session.SetString("NickName", MVM.NickName);
                        string MemberMobile1 = HttpContext.Session.GetString("MemberMobile");
                        int? MemberLevelId = -1;
                        if (HttpContext.Session.GetInt32("MemberLevelId") != null)
                            MemberLevelId = HttpContext.Session.GetInt32("MemberLevelId");
                        else
                            MemberLevelId = -1;
                        string NickName = HttpContext.Session.GetString("NickName");
                        //20181219 ---棋
                        //讀取會員未讀訊息比數
                        long MailCount = await IMER.GetMailCenterUnReadCount(LoginViewModel.MemberMobile);
                        // 13.系統回傳json(new { result=10傳回值, memberoobile=11讀取MemberMobile, memberlevel=MemberLevelId })。
                        return Json(new { result = ret, memberoobile = MVM.MemberMobile, memberlevelId = MVM.MemberLevelId, nickName = MVM.NickName, MailCount = MailCount });
                    }
                    else
                    {
                        return Json(new { result = ret });
                    }
                }
                return Json(new { result = 5 });
            }
            catch (Exception ex)
            {
                // 12a.系統判斷10~11成功執行。
                //  12a-1.系統回傳json(new {result=-1})。
                return Json(new { result = -1 });
            }
        }

        // 登出
        [HttpPost]
        public async Task<int> Logout()
        {
            try
            {
            //    await AuthenticationHttpContextExtensions.SignOutAsync(HttpContext);
            //    await HttpContext.SignOutAsync("HttpContext");
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return -1;
            }
            return 0;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
