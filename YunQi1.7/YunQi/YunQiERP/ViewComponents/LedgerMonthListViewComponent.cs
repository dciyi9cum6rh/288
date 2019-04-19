using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YunQiERP.ViewComponents
{
    //20181214 ---棋
    [Authorize]
    public class LedgerMonthListViewComponent : ViewComponent
    {
        private ISalaryRepository ISR { get; set; }
        private IConfiguration config { get; set; }

        public LedgerMonthListViewComponent(IConfiguration configuration, ISalaryRepository SalaryRepository)
        {
            ISR = SalaryRepository;
            ISR.constr = configuration.GetConnectionString("SqlConn");
            config = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(int Month)
        {
            List<GetLedgerMonthListViewModel> lGLMLVM = await ISR.GetLedgerMonthList(Month);
            long AddMoney = await ISR.GetLedgerMonthAddMoney(Month);
            long MinusMoney = await ISR.GetLedgerMonthMinusMoney(Month);

            return View(new GetLedgerMonthListManageViewModel
            {
                listGetLedgerMonthListViewModel = lGLMLVM,
                AddMoney = AddMoney,
                MinusMoney = MinusMoney,
            });
        }
    }
}