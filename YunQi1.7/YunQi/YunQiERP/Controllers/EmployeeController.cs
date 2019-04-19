using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utility;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private IEmployeeRepository IAR { get; set; }

        public EmployeeController(IConfiguration configuration, IEmployeeRepository EmployeeRepository)
        {
            IAR = EmployeeRepository;
            IAR.constr = configuration.GetConnectionString("SqlConn");
        }

        // 2.系統導向至Get Action【Employee/Index】。
        // 3.系統在Get Action【Employee/Index】判斷登入者擁有[部門員工管理](5)之權限。
        [HavePrivilege(5)]
        public IActionResult Index()
        {
            // 5.系統回傳View【Employee/Index】
            ViewBag.DepartmentId = 1;
            return View();
        }

        [HttpPost]
        public IActionResult GetDepartmentList(int DepartmentId, string Department = "", int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "page-link")
        {
            // 4.系統在Get Action【Employee/GetDepartmentList】呼叫ViewComponent【DepartmentListViewComponent】，並傳送jDepartment與1點按頁碼。
            return ViewComponent("DepartmentList", new { DepartmentId = DepartmentId, Department = Department, Page = Page, LinkType = LinkType, StartPage = StartPage, aclass = AClass });
        }

        [HttpPost]
        public IActionResult GetDepartmentLevelPath(int DepartmentId)
        {
            // 12. 系統在Post Controller Action【Employee/GetDepartmentLevelPath】呼叫ViewComponent【DepartmentLevelPathViewComponent】(目前部門階層，格式為[總公司\子部門\子子類別)，並傳送DepartmentId=11上傳DepartmentId。
            return ViewComponent("DepartmentLevelPath", new { DepartmentId = DepartmentId });
        }

        // 7.系統在Post Action【Employee/PostDepartment】驗証使用者有部門員工管理](5)權限。
        [HaveRightint1(5)]
        [HttpPost]
        public async Task<int> PostDepartment(int DepartmentId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string Department = "", DepartmentDescription = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async

                    Department = form["DepartmentC"];
                    DepartmentDescription = form["DepartmentDescription"];
                }
                // 9.系統新增一筆部門資料
                ret = await IAR.InsertDepartment(DepartmentId, Department, DepartmentDescription);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳3。
                ret = 3;
            }
            return ret;
        }

        // 7.系統在Post Action【Employee/PutDepartment】驗証使用者有部門員工管理](5)權限。
        [HaveRightint1(5)]
        [HttpPost]
        public async Task<int> PutDepartment(int DepartmentId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string Department = "", DepartmentDescription = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async

                    Department = form["DepartmentCEdit"];
                    DepartmentDescription = form["DepartmentDescriptionEdit"];
                }
                // 9.系統修改一筆部門資料。
                ret = await IAR.UpdateDepartment(DepartmentId, Department, DepartmentDescription);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳3。
                ret = 3;
            }
            return ret;
        }

        // 4.系統在Post Action【Employee/DeleteDepartment】驗証使用者有部門員工管理](5)權限。
        [HaveRightint2(5)]
        [HttpPost]
        public async Task<int> DeleteDepartment(int DepartmentId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 5.系統刪除一筆商品分類資料。
                ret = await IAR.DeleteDepartment(DepartmentId);
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

        // 7.系統在Post Action【Employee/PostPosition】驗証使用者有部門員工管理](5)權限。
        [HaveRightint1(5)]
        [HttpPost]
        public async Task<int> PostPosition(int DepartmentId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string Position = "", PositionDescription = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async

                    Position = form["PositionC"];
                    PositionDescription = form["PositionDescription"];
                }
                // 9.系統新增一筆職務資料。
                ret = await IAR.InsertPosition(DepartmentId, Position, PositionDescription);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳3。
                ret = 3;
            }
            return ret;
        }

        [HttpPost]
        public IActionResult GetPositionList(int DepartmentId, int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "inner-page-link")
        {
            // 9.系統在Controller Action【Employee/GetPositionList】，呼叫ViewComponent【PositionList】，並傳送3傳送之jDepartmentIdP。
            return ViewComponent("PositionList", new { DepartmentId = DepartmentId, Page = Page, LinkType = LinkType, StartPage = StartPage, aclass = AClass });
        }

        // 7.系統在Post Action【Employee/PutPosition】驗証使用者有部門員工管理](5)權限。
        [HaveRightint1(5)]
        [HttpPost]
        public async Task<int> PutPosition(int PositionId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string Position = "", PositionDescription = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async

                    Position = form["PositionCEdit"];
                    PositionDescription = form["PositionDescriptionEdit"];
                }
                // 9.系統修改一筆職務料。
                ret = await IAR.UpdatePosition(PositionId, Position, PositionDescription);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳3。
                ret = 3;
            }
            return ret;
        }

        // 4.系統在Post Action【Employee/DeletePosition】驗証使用者有部門員工管理](5)權限。
        [HaveRightint2(5)]
        [HttpPost]
        public async Task<int> DeletePosition(int PositionId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 5.系統刪除一筆商品分類資料。
                ret = await IAR.DeletePosition(PositionId);
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

        // 7.系統在Post Action【Employee/PostEmployee】驗証使用者有部門員工管理](5)權限。
        [HaveRightint1(5)]
        [HttpPost]
        public async Task<int> PostEmployee(int PositionId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string EmployeeName = "";
                DateTime Birthday = DateTime.Now;
                DateTime Duedate = DateTime.Now;
                byte sex = 0;
                string EmployeeMobile = "";
                int BaseSalary = 0;
                string ID = "";
                string eMail = "";
                string ContactPhone = "";
                string ContactAddress = "";
                string LineId = "";
                string EmergencyContact = "";
                string EmergencyContactPhone = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async

                    EmployeeName = form["EmployeeName"];
                    Birthday = DateTime.Parse(form["Birthday"]);
                    Duedate = DateTime.Parse(form["Duedate"]);
                    sex = Byte.Parse(form["sex"]);
                    EmployeeMobile = form["EmployeeMobile"];
                    BaseSalary = int.Parse(form["BaseSalary"]);
                    ID = form["ID"];
                    eMail = form["eMail"];
                    ContactPhone = form["ContactPhone"];
                    ContactAddress = form["ContactAddress"];
                    LineId = form["LineId"];
                    EmergencyContact = form["EmergencyContact"];
                    EmergencyContactPhone = form["EmergencyContactPhone"];
                }
                // 9.系統新增一筆員工資料。
                string UpdateEmployeeMobile = HttpContext.Session.GetString("CurrentEmployeeMobile");
                ret = await IAR.InsertEmployee(EmployeeMobile, Data.HashPassword(EmployeeMobile), PositionId, EmployeeName, Birthday, Duedate, sex, BaseSalary, ID, EmergencyContact, EmergencyContactPhone, ContactPhone, ContactAddress, eMail, DateTime.Now, UpdateEmployeeMobile, LineId);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳3。
                ret = 3;
            }
            return ret;
        }

        [HttpPost]
        public IActionResult GetEmployeeList(string Department, string Position, string EmployeeName, int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "emp-page-link")
        {
            // 9.系統呼叫ViewComponent【EmployeeList】，並傳送2傳送之jPosition與jEmployeeName、jDepartment、EmployeeName(預設皆為'')。
            return ViewComponent("EmployeeList", new { Department = Department, Position = Position, EmployeeName = EmployeeName, Page = Page, LinkType = LinkType, StartPage = StartPage, aclass = AClass });
        }

        // 7.系統在Post Action【Employee/PutEmployee】驗証使用者有部門員工管理](5)權限。
        [HaveRightint1(5)]
        [HttpPost]
        public async Task<int> PutEmployee()
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string EmployeeName = "";
                DateTime Birthday = DateTime.Now;
                DateTime Duedate = DateTime.Now;
                byte sex = 0;
                string EmployeeMobile = "";
                int BaseSalary = 0;
                string ID = "";
                string eMail = "";
                string ContactPhone = "";
                string ContactAddress = "";
                string LineId = "";
                string EmergencyContact = "";
                string EmergencyContactPhone = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async

                    EmployeeName = form["EmployeeNameEdit"];
                    Birthday = DateTime.Parse(form["BirthdayEdit"]);
                    Duedate = DateTime.Parse(form["DuedateEdit"]);
                    sex = Byte.Parse(form["sexEdit"]);
                    EmployeeMobile = form["EmployeeMobileEdit"];
                    BaseSalary = int.Parse(form["BaseSalaryEdit"]);
                    ID = form["IDEdit"];
                    eMail = form["eMailEdit"];
                    ContactPhone = form["ContactPhoneEdit"];
                    ContactAddress = form["ContactAddressEdit"];
                    LineId = form["LineIdEdit"];
                    EmergencyContact = form["EmergencyContactEdit"];
                    EmergencyContactPhone = form["EmergencyContactPhoneEdit"];
                }
                // 9.系統修改一筆員工資料。
                string UpdateEmployeeMobile = HttpContext.Session.GetString("CurrentEmployeeMobile");
                ret = await IAR.UpdateEmployee(EmployeeMobile, EmployeeName, Birthday, Duedate, sex, BaseSalary, ID, EmergencyContact, EmergencyContactPhone, ContactPhone, ContactAddress, eMail, DateTime.Now, UpdateEmployeeMobile, LineId);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳3。
                ret = 3;
            }
            return ret;
        }

        // 4.系統在Post Action【Employee/DeleteEmployee】驗証使用者有部門員工管理](5)權限。
        [HaveRightint2(5)]
        [HttpPost]
        public async Task<int> DeleteEmployee(string EmployeeMotile)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 5.系統刪除一筆職務資料。
                ret = await IAR.DeleteEmployee(EmployeeMotile);
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

        [HttpPost]
        public async Task<JsonResult> ValidatePosition(string Position)
        {
            // 4-3.系統在Post Action【Employee/ValidatePosition】驗証職務名稱。
            PositionViewModel onePC = await IAR.ValidatePosition(Position);
            // 4-5.系統以Json回傳4-3傳回值。
            return Json(new { Position = onePC });
        }

        // 7.系統在Post Action【Employee/PutEmployeePosition】驗証使用者有部門員工管理](5)權限。
        [HaveRightint1(5)]
        [HttpPost]
        // 8.系統接收6上傳資料。
        public async Task<int> PutEmployeePosition(string Position, string EmployeeMotile)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 9.系統修改一筆員工職務資料。
                string UpdateEmployeeMobile = HttpContext.Session.GetString("CurrentEmployeeMobile");
                ret = await IAR.UpdateEmployeePosition(EmployeeMotile, Position, DateTime.Now, UpdateEmployeeMobile);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳3。
                ret = 3;
            }
            return ret;
        }

        [HttpPost]
        public async Task<JsonResult> GetEmployeeRight(string EmployeeMobile)
        {
            // 3-1.系統在Post Action【Employee/GetEmployeeRight】讀取員工)。
            List<int> eRights = await IAR.GetEmployeeRights(EmployeeMobile);
            // 3-2.系統在Post Action【Employee/GetEmployeeRight】讀取員工權限列表(顯示用)。
            List<EmplyoeeRightViewModel> eRight = await IAR.GetEmployeeRight(EmployeeMobile);
            // 4.系統以json傳回{rights=3-1讀取值,right=3-2讀取值}。
            return Json(new { rights = eRights, right = eRight });
        }

        // 8.系統在Post Action【Employee/PutEmployeeRights】驗証使用者有部門員工管理](5)權限。
        [HaveRightint1(5)]
        [HttpPost]
        public async Task<int> PutEmployeeRights(string rights, string EmployeeMobile)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                //9.系統變更員工權限。
                ret = await IAR.UpdateEmployeeRights(EmployeeMobile, rights);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳3。
                ret = 3;
            }
            return ret;
        }

        // 2.系統導向至Get Action【Employee/ChangeEmployeePassword】。
        [HttpGet]
        public IActionResult ChangeEmployeePassword()
        {
            // 3.系統回傳View【Employee/ChangeEmployeePassword】
            return View();
        }

        [HttpPost]
        public async Task<int> PutEmployeePassword()
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string OldPassword = "";
                string NewPassword = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async

                    OldPassword = form["OldPassword"];
                    NewPassword = form["NewPassword"];
                }
                // 9.系統在Post Action【Employee/PutEmployeePassword】變更員工自己的密碼。
                string UpdateEmployeeMobile = HttpContext.Session.GetString("CurrentEmployeeMobile");
                ret = await IAR.UpdateEmployeePassword(UpdateEmployeeMobile, Data.HashPassword(OldPassword), Data.HashPassword(NewPassword), DateTime.Now, UpdateEmployeeMobile);
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳3。
                ret = 3;
            }
            return ret;
        }
    }
}