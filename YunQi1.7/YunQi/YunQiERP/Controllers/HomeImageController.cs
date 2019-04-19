using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    [Authorize]
    public class HomeImageController : Controller
    {
        private IMediaRepository IAR { get; set; }

        public HomeImageController(IConfiguration configuration, IMediaRepository MediaRepository)
        {
            IAR = MediaRepository;
            IAR.constr = configuration.GetConnectionString("SqlConn");
        }

        // 2.系統導向至Get Action【HomeImage/Index】。
        // 3.系統在Get Action【HomeImage/Index】判斷登入者擁有[首頁行銷圖示管理](10)之權限。
        [HavePrivilege(10)]
        public async Task<IActionResult> Index()
        {
            // 5.系統回傳View【HomeImage/Index】。
            return View();
        }

        [HttpPost]
        public IActionResult GetHomeImageList(int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "page-link")
        {
            // 4.系統在Get Action【HomeImage/GetHomeImageList】呼叫View Component【HomeImageListViewComponent】(會計科目清單)，並傳送HomeImageSubject=3上傳jHomeImageSubject。
            return ViewComponent("HomeImageList", new { Page = Page, LinkType = LinkType, StartPage = StartPage, aclass = AClass });
        }

        public async Task<FileResult> GetOneHomeImage(int HomeImageId)
        {
            HomeImageViewModel onePC = await IAR.GetOneHomeImage(HomeImageId);
            return File(onePC.PictureContent, onePC.PictureType);
        }

        // 7.系統在Post Action【HomeImage/PostHomeImage】驗証使用者有[首頁行銷圖示管理](10)權限。
        [HaveRightint1(10)]
        [HttpPost]
        public async Task<int> PostHomeImage(IFormFile PictureContentI)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string FileName = "";
                string HomeImageDescription = "";
                byte[] PContent = null;
                string PictureType = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async
                    HomeImageDescription = form["HomeImageDescription"];
                    PictureType = PictureContentI.ContentType;
                    FileName = PictureContentI.FileName;
                    using (var memoryStream = new MemoryStream())
                    {
                        await PictureContentI.CopyToAsync(memoryStream);
                        PContent = memoryStream.ToArray();
                    }
                }
                // 9.系統新增一筆首頁行銷圖示資料。
                ret = await IAR.InsertHomeImage(FileName, PContent, PictureType, HomeImageDescription);
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

        // 7.系統在Post Action【HomeImage/PutHomeImage】驗証使用者有[首頁行銷圖示管理](10)權限。
        [HaveRightint1(10)]
        [HttpPost]
        public async Task<int> PutHomeImage(IFormFile PictureContentIEdit, int HomeImageId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string FileName = "";
                string HomeImageDescription = "";
                byte[] PContent = null;
                string PictureType = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async
                    HomeImageDescription = form["HomeImageDescriptionEdit"];
                    PictureType = PictureContentIEdit.ContentType;
                    FileName = PictureContentIEdit.FileName;
                    using (var memoryStream = new MemoryStream())
                    {
                        await PictureContentIEdit.CopyToAsync(memoryStream);
                        PContent = memoryStream.ToArray();
                    }
                }
                // 9.系統新增一筆首頁行銷圖示資料。
                ret = await IAR.UpdateHomeImage(FileName, PContent, PictureType, HomeImageDescription, HomeImageId);
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

        // 7.系統在Post Action【HomeImage/DeleteHomeImage】驗証使用者有[首頁行銷圖示管理](10)權限。
        [HaveRightint1(10)]
        [HttpPost]
        public async Task<int> DeleteHomeImage(int HomeImageId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 9.系統刪除一筆首頁行銷圖示資料。
                ret = await IAR.DeleteHomeImage(HomeImageId);
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