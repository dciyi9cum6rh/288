using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YunQiERP.ViewComponents
{
    [Authorize]
    public class DepartmentLevelPathViewComponent : ViewComponent
    {
        private IEmployeeRepository IMR { get; set; }

        public DepartmentLevelPathViewComponent(IConfiguration configuration, IEmployeeRepository EmployeeRepository)
        {
            IMR = EmployeeRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
        }

        public async Task<IViewComponentResult> InvokeAsync(int DepartmentId)
        {
            // 8-1.系統在ViewComponent【DepartmentLevelPathViewComponent】讀取部門層級路徑清單：
            List<DepartmentLevelPathViewModel> lMLPVM = await IMR.GetDepartmentLevelPath(DepartmentId);
            // 8-2.系統回傳View(8-1傳回值)。
            return View(lMLPVM);
        }
    }
}