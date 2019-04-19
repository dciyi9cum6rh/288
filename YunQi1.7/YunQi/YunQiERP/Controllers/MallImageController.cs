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
    public class MallImageController : Controller
    {
        private IMediaRepository IAR { get; set; }

        public MallImageController(IConfiguration configuration, IMediaRepository MediaRepository)
        {
            IAR = MediaRepository;
            IAR.constr = configuration.GetConnectionString("SqlConn");
        }

        // 2.系統導向至Get Action【MallImage/Index】。
        // 3.系統在Get Action【MallImage/Index】判斷登入者擁有[商城行銷圖示管理](10)之權限。
        [HavePrivilege(10)]
        public async Task<IActionResult> Index()
        {
            // 5.系統回傳View【MallImage/Index】。
            return View();
        }

        [HttpPost]
        public IActionResult GetMallImageList(int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "page-link")
        {
            // 4.系統在Get Action【MallImage/GetMallImageList】呼叫View Component【MallImageListViewComponent】(會計科目清單)，並傳送MallImageSubject=3上傳jMallImageSubject。
            return ViewComponent("MallImageList", new { Page = Page, LinkType = LinkType, StartPage = StartPage, aclass = AClass });
        }

        public async Task<FileResult> GetOneMallImage(int MallImageId)
        {
            MallImageViewModel onePC = await IAR.GetOneMallImage(MallImageId);
            return File(onePC.PictureContent, onePC.PictureType);
        }

        // 7.系統在Post Action【MallImage/PostMallImage】驗証使用者有[商城行銷圖示管理](10)權限。
        [HaveRightint1(11)]
        [HttpPost]
        public async Task<int> PostMallImage(IFormFile PictureContentI)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string FileName = "";
                string MallImageDescription = "";
                byte[] PContent = null;
                string PictureType = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async
                    MallImageDescription = form["MallImageDescription"];
                    PictureType = PictureContentI.ContentType;
                    FileName = PictureContentI.FileName;
                    using (var memoryStream = new MemoryStream())
                    {
                        await PictureContentI.CopyToAsync(memoryStream);
                        PContent = memoryStream.ToArray();
                    }
                }
                // 9.系統新增一筆商城行銷圖示資料。
                ret = await IAR.InsertMallImage(FileName, PContent, PictureType, MallImageDescription);
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

        // 7.系統在Post Action【MallImage/PutMallImage】驗証使用者有[商城行銷圖示管理](10)權限。
        [HaveRightint1(11)]
        [HttpPost]
        public async Task<int> PutMallImage(IFormFile PictureContentIEdit, int MallImageId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 8.系統接收6上傳資料。
                string FileName = "";
                string MallImageDescription = "";
                byte[] PContent = null;
                string PictureType = "";
                if (HttpContext.Request.HasFormContentType)
                {
                    // 取得Client傳送之表單內容
                    IFormCollection form;
                    //form = HttpContext.Request.Form; // syncmbc
                    // Or
                    form = await HttpContext.Request.ReadFormAsync(); // async
                    MallImageDescription = form["MallImageDescriptionEdit"];
                    PictureType = PictureContentIEdit.ContentType;
                    FileName = PictureContentIEdit.FileName;
                    using (var memoryStream = new MemoryStream())
                    {
                        await PictureContentIEdit.CopyToAsync(memoryStream);
                        PContent = memoryStream.ToArray();
                    }
                }
                // 9.系統新增一筆商城行銷圖示資料。
                ret = await IAR.UpdateMallImage(FileName, PContent, PictureType, MallImageDescription, MallImageId);
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

        // 7.系統在Post Action【MallImage/DeleteMallImage】驗証使用者有[商城行銷圖示管理](10)權限。
        [HaveRightint1(11)]
        [HttpPost]
        public async Task<int> DeleteMallImage(int MallImageId)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 9.系統刪除一筆商城行銷圖示資料。
                ret = await IAR.DeleteMallImage(MallImageId);
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