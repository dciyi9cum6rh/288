using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    [Authorize]
    public class YoutubeVideoController : Controller
    {
        private IParameterRepository IAR { get; set; }

        public YoutubeVideoController(IConfiguration configuration, IParameterRepository ParameterRepository)
        {
            IAR = ParameterRepository;
            IAR.constr = configuration.GetConnectionString("SqlConn");
        }

        // 2.系統導向至Get Action【YoutubeVideo/Index】。
        // 3.系統在Get Action【YoutubeVideo/Index】判斷登入者擁有[YouTube影片設定](12)之權限。
        [HavePrivilege(9)]
        public async Task<IActionResult> Index()
        {
            // 4-1.系統讀取發展獎金設定。
            YoutubeVideoViewModel lpvm = await IAR.GetYoutubeVideoList();
            // 5.系統回傳View【YoutubeVideo/Index】，並傳回4-1讀取值。
            return View(lpvm);
        }

        // 3.系統在Postt Action【YoutubeVideo/PutYoutubeVideo】判斷登入者擁有[YouTube影片設定](12)之權限。
        [HaveRightint1(12)]
        [HttpPost]
        public async Task<int> PutYoutubeVideo(int YoutubeVideoId, string YouTubeVideo)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 4.系統重設發展獎金設定。
                ret = await IAR.UpdateYoutubeVideo(YoutubeVideoId, YouTubeVideo);
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