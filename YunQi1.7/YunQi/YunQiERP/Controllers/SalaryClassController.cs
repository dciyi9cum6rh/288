using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    [Authorize]
    public class SalaryClassController : Controller
    {
        private ISalaryRepository IAR { get; set; }

        public SalaryClassController(IConfiguration configuration, ISalaryRepository SalaryRepository)
        {
            IAR = SalaryRepository;
            IAR.constr = configuration.GetConnectionString("SqlConn");
        }

        // 2.系統導向至Get Action【SalaryClass/Index】。
        // 3.系統在Get Action【SalaryClass/Index】判斷登入者擁有[薪資類別](7)之權限。
        [HavePrivilege(7)]
        public IActionResult Index()
        {
            // 5.系統回傳View【SalaryClass/Index】
            return View();
        }

        [HttpPost]
        public IActionResult GetSalaryClassList(string SalaryClass = "", int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "page-link")
        {
            // 4.系統在Get Action【SalaryClass/GetSalaryClassList】呼叫ViewComponent【SalaryClassListViewComponent】(薪資類別清單)，並傳送SalaryClass=3上傳jSalaryClass與1點按頁碼。
            return ViewComponent("SalaryClassList", new { SalaryClass = SalaryClass, Page = Page, LinkType = LinkType, StartPage = StartPage, aclass = AClass });
        }

        // 7.系統在Post Action【Product/PostSalaryClass】驗証使用者有[薪資類別離(7)權限。
        [HaveRightint1(7)]
        [HttpPost]
        public async Task<int> PostSalaryClass()
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string SalaryClass = "";
                int ClassSalary = 0;
                string SalaryClassDescription = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async

                    SalaryClass = form["SalaryClassS"];
                    ClassSalary = int.Parse(form["ClassSalary"]);
                    SalaryClassDescription = form["SalaryClassDescription"];
                }
                // 9.系統新增一筆會計科目資料。
                ret = await IAR.InsertSalaryClass(SalaryClass, ClassSalary, SalaryClassDescription);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳4。
                ret = 4;
            }
            return ret;
        }

        // 7.系統在Post Action【SalaryClass/PutSalaryClass】驗証使用者有[薪資類別](7)權限。
        [HaveRightint1(7)]
        [HttpPost]
        public async Task<int> PutSalaryClass(int SalaryClassId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string SalaryClass = "";
                int ClassSalary = 0;
                string SalaryClassDescription = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async

                    SalaryClass = form["SalaryClassSEdit"];
                    ClassSalary = int.Parse(form["ClassSalaryEdit"]);
                    SalaryClassDescription = form["SalaryClassDescriptionEdit"];
                }
                // 9.系統新增一筆會計科目資料。
                ret = await IAR.UpdateSalaryClass(SalaryClass, ClassSalary, SalaryClassDescription, SalaryClassId);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳4。
                ret = 4;
            }
            return ret;
        }

        // 4.系統在Post Action【SalaryClass/DeleteSalaryClass】驗証使用者有[薪資類別管理](7)權限。
        [HaveRightint1(7)]
        [HttpPost]
        public async Task<int> DeleteSalaryClass(int SalaryClassId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 5.系統刪除一筆薪資類別資料。
                ret = await IAR.DeleteSalaryClass(SalaryClassId);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳2。
                ret = 2;
            }
            return ret;
        }
    }
}