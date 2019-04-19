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
    public class AccountingController : Controller
    {
        private IAccountingRepository IAR { get; set; }

        public AccountingController(IConfiguration configuration, IAccountingRepository AccountingRepository)
        {
            IAR = AccountingRepository;
            IAR.constr = configuration.GetConnectionString("SqlConn");
        }

        // 2.系統導向至Get  Action【Accounting/Index】。
        // 3.系統在Get  Action【Accounting/Index】判斷登入者擁有[會計](3)之權限。
        [HavePrivilege(3)]
        public IActionResult Index()
        {
            // 5.系統回傳View【Accounting/Index】
            return View();
        }

        [HttpPost]
        public IActionResult GetAccountingList(string AccountingSubject = "", int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "page-link")
        {
            // 4.系統在Get Action【Accounting/GetAccountingList】呼叫View Component【AccountingListViewComponent】(會計科目清單)，並傳送AccountingSubject=3上傳jAccountingSubject。
            return ViewComponent("AccountingList", new { AccountingSubject = AccountingSubject, Page = Page, LinkType = LinkType, StartPage = StartPage, aclass = AClass });
        }

        // 7.系統在Post Action【Product/PostAccounting】驗証使用者有[會計科目](3)權限。
        [HaveRightint1(3)]
        [HttpPost]
        public async Task<int> PostAccounting()
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string AccountingId = "", AccountingSubject = "";
                string AccountingDescription = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async

                    AccountingId = form["AccountingId"];
                    AccountingSubject = form["AccountingSubjectF"];
                    AccountingDescription = form["AccountingDescription"];
                }
                // 9.系統新增一筆會計科目資料。
                ret = await IAR.InsertAccounting(AccountingId, AccountingSubject, AccountingDescription);
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

        // 7.系統在Put Action【Product/PutAccounting】驗証使用者有[會計科目](3)權限。
        [HaveRightint1(3)]
        [HttpPost]
        public async Task<int> PutAccounting()
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string AccountingId = "", AccountingSubject = "";
                string AccountingDescription = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async

                    AccountingId = form["EditAccountingId"];
                    AccountingSubject = form["EditAccountingSubjectF"];
                    AccountingDescription = form["EditAccountingDescription"];
                }
                // 9.系統修改一筆會計科目資料。
                ret = await IAR.UpdateAccounting(AccountingId, AccountingSubject, AccountingDescription);
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

        // 4.系統在Post Action【Product/DeleteAccounting】驗証使用者有[會計科目管理](3)權限。
        [HaveRightint2(3)]
        [HttpPost]
        public async Task<int> DeleteAccounting(string AccountingId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 5.系統刪除一筆商品分類資料。
                ret = await IAR.DeleteAccounting(AccountingId);
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
    }
}