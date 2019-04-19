using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace YunQiERP.Attributes
{
    public class HavePrivilegeAttribute : ActionFilterAttribute
    {
        public int rightId;

        public HavePrivilegeAttribute(int rId)  // url is a positional parameter
        {
            this.rightId = rId;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            List<int> tR = context.HttpContext.Session.GetObjectFromJson<List<int>>("EmployeeRights");  // 權限清單，用來判斷是否可執行相關操作
            var controller = context.Controller as Controller;
            if (controller == null) return;
            if (tR == null)
            {
                controller.ViewBag.HavePrivilege = true;
                return;
            }
            if (!tR.Contains(rightId))
            {
                // 3a.系統在Get Controller Action【Product/Index】判斷登入者沒有[商品管理](2)之權限。
                // 3a-1.系統設定ViewBag.HavePrivilege = true。
                controller.ViewBag.HavePrivilege = false;
                //var view = context.Result as ViewResult;
                //string viewName = "";
                //if (view != null)
                //{
                //    viewName = view.ViewName;
                //}
                context.Result = new ViewResult
                {
                    //ViewName = viewName,
                    ViewData = controller.ViewData,
                    TempData = controller.TempData,
                };
            }
            else
            {
                // 4.系統設定ViewBag.HavePrivilege = true。
                controller.ViewBag.HavePrivilege = true;
            }
        }
    }
}