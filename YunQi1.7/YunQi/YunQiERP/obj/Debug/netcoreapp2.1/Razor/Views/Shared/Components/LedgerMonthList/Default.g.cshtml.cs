#pragma checksum "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\LedgerMonthList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "073315c02290fffc05a2fd0db35648890a0de808"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_LedgerMonthList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/LedgerMonthList/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/LedgerMonthList/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_LedgerMonthList_Default))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\_ViewImports.cshtml"
using YunQiERP;

#line default
#line hidden
#line 2 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\_ViewImports.cshtml"
using YunQiERP.Models;

#line default
#line hidden
#line 1 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\LedgerMonthList\Default.cshtml"
using DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"073315c02290fffc05a2fd0db35648890a0de808", @"/Views/Shared/Components/LedgerMonthList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b4f9f7d0ad6169b0d02079f8a353bf4ccfe20a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_LedgerMonthList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GetLedgerMonthListManageViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(181, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 5 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\LedgerMonthList\Default.cshtml"
 if (Model.listGetLedgerMonthListViewModel != null && Model.listGetLedgerMonthListViewModel.Count > 0)
{
    // 9-9.系統在View【Views/Shared/Components/EmployeeList/Default.cshtml】中顯示[目前部門員工清單] (含修改與刪除與權限，但應依ViewBag.TR之權限顯示)。

#line default
#line hidden
            BeginContext(410, 38, true);
            WriteLiteral("    <input type=\"hidden\" id=\"AddMoney\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 448, "\"", 471, 1);
#line 8 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\LedgerMonthList\Default.cshtml"
WriteAttributeValue("", 456, Model.AddMoney, 456, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(472, 45, true);
            WriteLiteral(" />\r\n    <input type=\"hidden\" id=\"MinusMoney\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 517, "\"", 542, 1);
#line 9 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\LedgerMonthList\Default.cshtml"
WriteAttributeValue("", 525, Model.MinusMoney, 525, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(543, 40, true);
            WriteLiteral(" />\r\n    <input type=\"hidden\" id=\"Total\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 583, "\"", 627, 1);
#line 10 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\LedgerMonthList\Default.cshtml"
WriteAttributeValue("", 591, @Model.AddMoney+@Model.MinusMoney, 591, 36, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(628, 388, true);
            WriteLiteral(@" />
    <div class=""container container-fluid"">
        <table class=""table table-bordered"">
            <thead>
                <tr style=""color:gainsboro;background-color:#000000"">
                    <th>科目名稱</th>
                    <th>收入</th>
                    <th>支出</th>
                    <th>結餘</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 22 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\LedgerMonthList\Default.cshtml"
                 foreach (var o in Model.listGetLedgerMonthListViewModel)
                {

#line default
#line hidden
            BeginContext(1110, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(1165, 19, false);
#line 25 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\LedgerMonthList\Default.cshtml"
                       Write(o.AccountingSubject);

#line default
#line hidden
            EndContext();
            BeginContext(1184, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1220, 10, false);
#line 26 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\LedgerMonthList\Default.cshtml"
                       Write(o.AddMoney);

#line default
#line hidden
            EndContext();
            BeginContext(1230, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1266, 12, false);
#line 27 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\LedgerMonthList\Default.cshtml"
                       Write(o.MinusMoney);

#line default
#line hidden
            EndContext();
            BeginContext(1278, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1315, 27, false);
#line 28 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\LedgerMonthList\Default.cshtml"
                        Write(@o.AddMoney + @o.MinusMoney);

#line default
#line hidden
            EndContext();
            BeginContext(1343, 35, true);
            WriteLiteral(" </td>\r\n                    </tr>\r\n");
            EndContext();
#line 30 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\LedgerMonthList\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(1397, 52, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
            EndContext();
#line 34 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\LedgerMonthList\Default.cshtml"

}
else
{
    // 9-8a.系統判斷!(9-7傳回之listEmployeeListViewModel!=null and Count>0)。

#line default
#line hidden
            BeginContext(1534, 21, true);
            WriteLiteral("    <h3>沒有總帳管理</h3>\r\n");
            EndContext();
#line 40 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\LedgerMonthList\Default.cshtml"
}

#line default
#line hidden
            BeginContext(1558, 242, true);
            WriteLiteral("<script>\r\n\r\n    var newAddMoney = parseInt($(\'#newAddMoney\').val());\r\n    var newMinusMoney = parseInt($(\'#newMinusMoney\').val());\r\n    var newTotal = parseInt($(\'#newTotal\').val());\r\n    //Model.MemberTotall 當自己批發總額超過3000 將內容改為紅色 否則為綠色\r\n    ");
            EndContext();
            BeginContext(1801, 14, false);
#line 47 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\LedgerMonthList\Default.cshtml"
Write(Model.AddMoney);

#line default
#line hidden
            EndContext();
            BeginContext(1815, 97, true);
            WriteLiteral(" < 0 ? ($(\"#newAddMoney\").css(\"color\", \"red\")) : ($(\"#newAddMoney\").css(\"color\", \"green\"));\r\n    ");
            EndContext();
            BeginContext(1913, 16, false);
#line 48 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\LedgerMonthList\Default.cshtml"
Write(Model.MinusMoney);

#line default
#line hidden
            EndContext();
            BeginContext(1929, 101, true);
            WriteLiteral(" < 0 ? ($(\"#newMinusMoney\").css(\"color\", \"red\")) : ($(\"#newMinusMoney\").css(\"color\", \"green\"));\r\n    ");
            EndContext();
            BeginContext(2032, 33, false);
#line 49 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\LedgerMonthList\Default.cshtml"
Write(@Model.AddMoney+@Model.MinusMoney);

#line default
#line hidden
            EndContext();
            BeginContext(2066, 96, true);
            WriteLiteral(" < 0 ? ($(\"#newTotal\").css(\"color\", \"red\")) : ($(\"#newTotal\").css(\"color\", \"green\"));\r\n</script>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GetLedgerMonthListManageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
