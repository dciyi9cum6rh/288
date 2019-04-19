#pragma checksum "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d68afe09b6281746ddd89defa2a10b715884de23"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_EmployeeList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/EmployeeList/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/EmployeeList/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_EmployeeList_Default))]
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
#line 1 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\_ViewImports.cshtml"
using YunQiERP;

#line default
#line hidden
#line 2 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\_ViewImports.cshtml"
using YunQiERP.Models;

#line default
#line hidden
#line 1 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
using DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d68afe09b6281746ddd89defa2a10b715884de23", @"/Views/Shared/Components/EmployeeList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b4f9f7d0ad6169b0d02079f8a353bf4ccfe20a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_EmployeeList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EmployeeListManageViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-link-size", "pagination-md", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::YunQiERP.TagHelpers.PagerTagHelper __YunQiERP_TagHelpers_PagerTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
  
    List<int> tR = ViewBag.TR;
    int Page = ViewBag.Page;
    int id = (Page - 1) * 10;

#line default
#line hidden
            BeginContext(275, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 9 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
 if (Model.listEmployeeListViewModel != null && Model.listEmployeeListViewModel.Count > 0)
{
    // 9-9.系統在View【Views/Shared/Components/EmployeeList/Default.cshtml】中顯示[目前部門員工清單] (含修改與刪除與權限，但應依ViewBag.TR之權限顯示)。

#line default
#line hidden
            BeginContext(490, 183, true);
            WriteLiteral("    <div class=\"container container-fluid\">\r\n        <table class=\"table table-bordered\">\r\n            <thead>\r\n                <tr style=\"color:gainsboro;background-color:#000000\">\r\n");
            EndContext();
            BeginContext(709, 408, true);
            WriteLiteral(@"                    <th>員工手機</th>
                    <th>員工姓名</th>
                    <th>性別</th>
                    <th>生日</th>
                    <th>到職日</th>
                    <th>繴急聯絡人</th>
                    <th>繴急聯絡電話</th>
                    <th>職務名稱</th>
                    <th>本薪</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 30 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                 foreach (EmployeeListViewModel MLVM in Model.listEmployeeListViewModel)
                {
                    DateTime dt = (DateTime)MLVM.Duedate;
                    DateTime dtb = (DateTime)MLVM.Birthday;
                    id += 1;

#line default
#line hidden
            BeginContext(1376, 26, true);
            WriteLiteral("                    <tr>\r\n");
            EndContext();
            BeginContext(1444, 28, true);
            WriteLiteral("                        <td>");
            EndContext();
            BeginContext(1473, 19, false);
#line 37 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                       Write(MLVM.EmployeeMobile);

#line default
#line hidden
            EndContext();
            BeginContext(1492, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1528, 17, false);
#line 38 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                       Write(MLVM.EmployeeName);

#line default
#line hidden
            EndContext();
            BeginContext(1545, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 39 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                         if (MLVM.sex == 0)
                        {

#line default
#line hidden
            BeginContext(1624, 41, true);
            WriteLiteral("                            <td>女性</td>\r\n");
            EndContext();
#line 42 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(1749, 41, true);
            WriteLiteral("                            <td>男性</td>\r\n");
            EndContext();
#line 46 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                        }

#line default
#line hidden
            BeginContext(1817, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(1869, 30, true);
            WriteLiteral("\r\n                        <td>");
            EndContext();
            BeginContext(1900, 22, false);
#line 48 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                       Write(dtb.ToLongDateString());

#line default
#line hidden
            EndContext();
            BeginContext(1922, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1958, 21, false);
#line 49 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                       Write(dt.ToLongDateString());

#line default
#line hidden
            EndContext();
            BeginContext(1979, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(2015, 21, false);
#line 50 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                       Write(MLVM.EmergencyContact);

#line default
#line hidden
            EndContext();
            BeginContext(2036, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(2072, 26, false);
#line 51 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                       Write(MLVM.EmergencyContactPhone);

#line default
#line hidden
            EndContext();
            BeginContext(2098, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(2134, 13, false);
#line 52 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                       Write(MLVM.Position);

#line default
#line hidden
            EndContext();
            BeginContext(2147, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(2183, 15, false);
#line 53 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                       Write(MLVM.BaseSalary);

#line default
#line hidden
            EndContext();
            BeginContext(2198, 176, true);
            WriteLiteral("</td>\r\n                        <td>\r\n                            <a class=\"btn btn-default btn-edit-Employee\" role=\"button\" title=\"修改\"\r\n                               data-id=\"");
            EndContext();
            BeginContext(2375, 7, false);
#line 56 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                                   Write(MLVM.ID);

#line default
#line hidden
            EndContext();
            BeginContext(2382, 21, true);
            WriteLiteral("\" data-contactphone=\"");
            EndContext();
            BeginContext(2404, 17, false);
#line 56 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                                                                Write(MLVM.ContactPhone);

#line default
#line hidden
            EndContext();
            BeginContext(2421, 23, true);
            WriteLiteral("\" data-contactaddress=\"");
            EndContext();
            BeginContext(2445, 19, false);
#line 56 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                                                                                                         Write(MLVM.ContactAddress);

#line default
#line hidden
            EndContext();
            BeginContext(2464, 46, true);
            WriteLiteral("\"\r\n                               data-email=\"");
            EndContext();
            BeginContext(2511, 10, false);
#line 57 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                                      Write(MLVM.eMail);

#line default
#line hidden
            EndContext();
            BeginContext(2521, 15, true);
            WriteLiteral("\" data-lineid=\"");
            EndContext();
            BeginContext(2537, 11, false);
#line 57 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                                                                Write(MLVM.LineId);

#line default
#line hidden
            EndContext();
            BeginContext(2548, 12, true);
            WriteLiteral("\" data-sex=\"");
            EndContext();
            BeginContext(2561, 8, false);
#line 57 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                                                                                        Write(MLVM.sex);

#line default
#line hidden
            EndContext();
            BeginContext(2569, 19, true);
            WriteLiteral("\" data-positionid=\"");
            EndContext();
            BeginContext(2589, 15, false);
#line 57 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                                                                                                                    Write(MLVM.PositionId);

#line default
#line hidden
            EndContext();
            BeginContext(2604, 554, true);
            WriteLiteral(@""">
                                <span class=""glyphicon glyphicon-pencil"" aria-hidden=""true""></span>
                            </a>
                            <a class=""btn btn-default btn-delete-Employee"" role=""button"" title=""刪除""><span class=""glyphicon glyphicon-trash"" aria-hidden=""true""></span></a>
                            <a class=""btn btn-default btn-employee-position"" role=""button"" title=""更換職務""><span class=""glyphicon glyphicon-th-list"" aria-hidden=""true""></span><span class=""glyphicon glyphicon-user"" aria-hidden=""true""></span></a>
");
            EndContext();
#line 62 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                             if (tR.Contains(6))
                            {

#line default
#line hidden
            BeginContext(3239, 190, true);
            WriteLiteral("                                <a class=\"btn btn-default btn-employee-right\" role=\"button\" title=\"員工權限\"><span class=\"glyphicon glyphicon-object-align-right\" aria-hidden=\"true\"></span></a>\r\n");
            EndContext();
#line 65 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                            }

#line default
#line hidden
            BeginContext(3460, 89, true);
            WriteLiteral("                        </td>\r\n                    </tr>\r\n                    <tr></tr>\r\n");
            EndContext();
#line 69 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(3568, 52, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
            EndContext();
#line 73 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
    // 9-10.系統在View【Views/Shared/Components/EmployeeList/Default.cshtml】中顯示換頁超連結。

#line default
#line hidden
            BeginContext(3703, 19, true);
            WriteLiteral("    <div>\r\n        ");
            EndContext();
            BeginContext(3722, 291, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pager", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6c9f429909e04d3493c81694c473a872", async() => {
            }
            );
            __YunQiERP_TagHelpers_PagerTagHelper = CreateTagHelper<global::YunQiERP.TagHelpers.PagerTagHelper>();
            __tagHelperExecutionContext.Add(__YunQiERP_TagHelpers_PagerTagHelper);
#line 75 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.CurrentPage = Model.CurrentPage;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("current-page", __YunQiERP_TagHelpers_PagerTagHelper.CurrentPage, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 75 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.PageCount = Model.PageCount;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("page-count", __YunQiERP_TagHelpers_PagerTagHelper.PageCount, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 75 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.Parameters = null;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("parameters", __YunQiERP_TagHelpers_PagerTagHelper.Parameters, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 75 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.StartPage = Model.StartPage;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("start-page", __YunQiERP_TagHelpers_PagerTagHelper.StartPage, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 75 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.TotalPages = Model.TotalPages;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("total-pages", __YunQiERP_TagHelpers_PagerTagHelper.TotalPages, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 75 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                                                                                                                                                        WriteLiteral(Url.Action("GetEmployeeList", "Employee"));

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __YunQiERP_TagHelpers_PagerTagHelper.Url = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("url", __YunQiERP_TagHelpers_PagerTagHelper.Url, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __YunQiERP_TagHelpers_PagerTagHelper.PageLinkSize = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
#line 75 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
                                                                                                                                                                                                                                            WriteLiteral(Model.AClass);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __YunQiERP_TagHelpers_PagerTagHelper.AClass = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("a-class", __YunQiERP_TagHelpers_PagerTagHelper.AClass, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 75 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.LinkType = Model.LinkType;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("link-type", __YunQiERP_TagHelpers_PagerTagHelper.LinkType, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4013, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 77 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
}
else
{
    // 9-8a.系統判斷!(9-7傳回之listEmployeeListViewModel!=null and Count>0)。

#line default
#line hidden
            BeginContext(4110, 19, true);
            WriteLiteral("    <h3>沒有員工</h3>\r\n");
            EndContext();
#line 82 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeList\Default.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EmployeeListManageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
