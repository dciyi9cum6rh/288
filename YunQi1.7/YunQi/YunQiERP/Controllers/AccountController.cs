using IRepository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using YunQiERP.ViewModels;

namespace YunQiERP.Controllers
{
    public class AccountController : Controller
    {
        private IEmployeeRepository IAR { get; set; }

        public AccountController(IConfiguration configuration, IEmployeeRepository EmployeeRepository)
        {
            IAR = EmployeeRepository;
            IAR.constr = configuration.GetConnectionString("SqlConn");
        }

        // 1.使用者連上ACC平台營運後台首頁(例如http://YunQiERP.com)。
        // 2.系統呼叫Controller Action【Product/Index】。
        // 2-1.系統發現尚未驗証，轉向到Action【Account/Login】
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            // 3.系統在Action【Account/Login】中回傳View【Account/Login】。
            return View();
        }

        // 7.系統呼叫POST【Account/Login】，並傳送5輸入的資料(LoginViewModel)。
        [HttpPost]
        [AllowAnonymous]
        //[ValidateRecaptcha]           //測試用 先關掉GOOGLE驗證
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // 8.系統在POST【Account/Login】驗証資料輸入無誤(參考流程5)。
                    // 9.系統加密7傳送Password。
                    string Password = Utility.Data.HashPassword(model.Password);
                    // 10.系統驗証7傳送之LoginViewModel是否為合法員工。
                    int ret;
                    ret = await IAR.EmployeeLogin(model.EmployeeMobile, Password);
                    // 11.系統判斷10成功執行。
                    if (ret == 0)
                    {
                        // 12.系統判斷10傳回值==0。
                        // 13.系統設定已經通過表單驗証，以便導向設有[Authorize]之頁面。
                        var identity = new ClaimsIdentity("Account");
                        identity.AddClaim(new Claim(ClaimTypes.Name, model.EmployeeMobile));
                        ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                        //await HttpContext.Authentication.SignInAsync("Cookieauth", principal);
                        await AuthenticationHttpContextExtensions.SignInAsync(HttpContext, principal);
                        // 14-1.系統讀取登入會員之權限列表：
                        List<int> MemberRights = await IAR.GetEmployeeRights(model.EmployeeMobile);
                        // 14-2.系統將14-1讀取會員權限暫存在Session["EmployeeRights"]。
                        HttpContext.Session.SetObjectAsJson("EmployeeRights", MemberRights);
                        // 14-3.系統設定Session["CurrentEmployeeMobile"]=7上傳之EmployeeMobile。
                        HttpContext.Session.SetString("CurrentEmployeeMobile", model.EmployeeMobile);
                        // 15.系統導向Get Action【Product/Index】。
                        return RedirectToAction("Index", "Product");
                        // 16.結束。
                    }
                    else if (ret == 2)
                    {
                        // 11b.系統判斷10傳回值=2。
                        //  11b-1.系統設定ViewBag.Error="帳號錯誤！"。
                        ViewBag.Error = "帳號錯誤！";
                        //  11b - 2.系統回傳View【Account / Login】，並回傳7傳送之LoginViewModel。
                        return View(model);
                    }
                    else if (ret == 3)
                    {
                        // 11c.系統判斷10傳回值=3。
                        //  11c-1.系統設定ViewBag.Error = "密碼錯誤！"。
                        ViewBag.Error = "密碼錯誤！";
                        //  11c-2.系統回傳View【Account / Login】，並回傳7傳送之LoginViewModel。
                        return View(model);
                    }
                    else
                    {
                        // 11d.系統判斷10傳回值!=0/2/3。
                        //  11d-1.系統設定ViewBag.Error = "執行錯誤，請再試一次！"。
                        ViewBag.Error = "執行錯誤，請再試一次！";
                        //  11c - 2.系統回傳View【Account / Login】，並回傳7傳送之LoginViewModel。
                        return View(model);
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                // 11a.系統判斷10執行時發生例外。
                // 11a - 1.系統設定ViewBag.Error = "執行錯誤，請再試一次！"。
                ViewBag.Error = $"執行錯誤:{ex.Message}，請再試一次！";
                //  11a - 2.系統回傳View【Account/Login】，並回傳7傳送之LoginViewModel。
                return View(model);
            }
        }

        // 登出
        [HttpPost]
        public async Task<int> Logout()
        {
            try
            {
                await AuthenticationHttpContextExtensions.SignOutAsync(HttpContext);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return -1;
            }
            return 0;
        }

        // 禁止瀏灠
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Forbidden()
        {
            return View();
        }
    }
}