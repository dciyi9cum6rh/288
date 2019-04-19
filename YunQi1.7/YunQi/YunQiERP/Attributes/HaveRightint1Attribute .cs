using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace YunQiERP.Attributes
{
    public class HaveRightint1Attribute : ActionFilterAttribute
    {
        public int rightId;

        public HaveRightint1Attribute(int rId)  // url is a positional parameter
        {
            this.rightId = rId;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            List<int> tR = context.HttpContext.Session.GetObjectFromJson<List<int>>("EmployeeRights");  // 權限清單，用來判斷是否可執行相關操作
            if (tR != null)
            {
                if (!tR.Contains(rightId))
                {
                    context.Result = new OkObjectResult(1);
                }
            }
        }
    }
}