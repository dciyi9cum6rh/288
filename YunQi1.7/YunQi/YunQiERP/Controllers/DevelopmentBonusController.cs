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
    public class DevelopmentBonusController : Controller
    {
        private IParameterRepository IAR { get; set; }

        public DevelopmentBonusController(IConfiguration configuration, IParameterRepository ParameterRepository)
        {
            IAR = ParameterRepository;
            IAR.constr = configuration.GetConnectionString("SqlConn");
        }

        // 2.系統導向至Get Action【DevelopmentBonus/Index】。
        // 3.系統在Get Action【DevelopmentBonus/Index】判斷登入者擁有[發展獎金設定] (9)之權限。
        [HavePrivilege(9)]
        public async Task<IActionResult> Index()
        {
            // 4-1.系統讀取發展獎金設定。
            List<DevelopmentBonusViewModel> lpvm = await IAR.GetDevelopmentBonusList();
            // 5.系統回傳View【DevelopmentBonus/Index】，並傳回4-1讀取值。
            return View(lpvm);
        }

        // 3.系統在Postt Action【DevelopmentBonus/PutDevelopmentBonus】判斷登入者擁有[發展獎金設定](9)之權限。
        [HaveRightint1(8)]
        [HttpPost]
        public async Task<int> PutDevelopmentBonus(string DevelopmentBonusId, string DevelopmentBonusLimit, string DevelopmentBonusValue)
        {
            int ret = 0;  // 12.系統回傳0。
            try
            {
                // 4.系統重設發展獎金設定。
                ret = await IAR.UpdateDevelopmentBonus(DevelopmentBonusId, DevelopmentBonusLimit, DevelopmentBonusValue);
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