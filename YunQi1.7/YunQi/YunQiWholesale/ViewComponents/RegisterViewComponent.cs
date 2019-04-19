using IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace YunQiWholesale.ViewComponents
{
    public class RegisterViewComponent : ViewComponent
    {
        private IMemberRepository IMR { get; set; }
        private IConfiguration config { get; set; }

        public RegisterViewComponent(IConfiguration configuration, IMemberRepository MemberRepository)
        {
            IMR = MemberRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
            config = configuration;
        }

        //20181225 ---棋
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
