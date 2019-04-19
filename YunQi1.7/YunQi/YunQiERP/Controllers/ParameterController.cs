using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    [Authorize]
    public class ParameterController : Controller
    {
        private IParameterRepository IAR { get; set; }

        public ParameterController(IConfiguration configuration, IParameterRepository ParameterRepository)
        {
            IAR = ParameterRepository;
            IAR.constr = configuration.GetConnectionString("SqlConn");
        }

        // 2.系統導向至Get  Action【Parameter/Index】。
        // 3.系統在Get Action【Parameter/Index】判斷登入者擁有[參數設定](8)之權限。
        [HavePrivilege(8)]
        public async Task<IActionResult> Index()
        {
            // 4-1.系統讀取參數設定。
            List<ParameterViewModel> lpvm = await IAR.GetParameterList();
            // 5.系統回傳View【Parameter/Index】，並傳回4-1讀取值。
            return View(lpvm);
        }

        // 3.系統在Postt Action【Parameter/PutParameter】判斷登入者擁有[參數設定](8)之權限。
        [HaveRightint1(8)]
        [HttpPost]
        public async Task<int> PutParameter(string ParameterId, string ParameterValue)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 4.系統重設參數設定。
                ret = await IAR.UpdateParameter(ParameterId, ParameterValue);
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