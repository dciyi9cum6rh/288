#pragma checksum "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ede4a2bdf8b94b464ff9550d4ef552f287fa5cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_EmployeeDevelopmentBonusList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/EmployeeDevelopmentBonusList/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/EmployeeDevelopmentBonusList/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_EmployeeDevelopmentBonusList_Default))]
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
#line 1 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml"
using DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ede4a2bdf8b94b464ff9550d4ef552f287fa5cc", @"/Views/Shared/Components/EmployeeDevelopmentBonusList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b4f9f7d0ad6169b0d02079f8a353bf4ccfe20a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_EmployeeDevelopmentBonusList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EmployeeDevelopmentBonusListManageViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-link-size", "pagination-md", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("a-class", "page-link", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml"
  
    List<int>
    tR = ViewBag.TR;
    int Page = ViewBag.Page;
    int id = (Page - 1) * 10;

#line default
#line hidden
            BeginContext(175, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(396, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 13 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml"
 if (Model.listEmployeeDevelopmentBonusListViewModel != null && Model.listEmployeeDevelopmentBonusListViewModel.Count > 0)
{

#line default
#line hidden
            BeginContext(525, 424, true);
            WriteLiteral(@"    <div class=""container container-fluid"">
        <table class=""table table-bordered"">
            <thead>
                <tr style=""color:gainsboro;background-color:#000000"">
                    <th>會員手機 </th>
                    <th>會員姓名</th>
                    <th>會員發展獎金</th>
                    <th>己入帳</th>
                    <th></th>
                </tr>
            </thead>

            <tbody>
");
            EndContext();
#line 28 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml"
                 foreach (var o in Model.listEmployeeDevelopmentBonusListViewModel)
                    {

#line default
#line hidden
            BeginContext(1057, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(1120, 16, false);
#line 31 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml"
                           Write(o.EmployeeMobile);

#line default
#line hidden
            EndContext();
            BeginContext(1136, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1176, 14, false);
#line 32 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml"
                           Write(o.EmployeeName);

#line default
#line hidden
            EndContext();
            BeginContext(1190, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1230, 7, false);
#line 33 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml"
                           Write(o.Bonus);

#line default
#line hidden
            EndContext();
            BeginContext(1237, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1277, 12, false);
#line 34 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml"
                           Write(o.IsRecorded);

#line default
#line hidden
            EndContext();
            BeginContext(1289, 311, true);
            WriteLiteral(@"</td>
                            <td>
                                <a class=""btn btn-default btn-detail"" role=""button"" title=""業務""><span class=""glyphicon glyphicon-th-list"" aria-hidden=""true""></span></a>
                            </td>
                        </tr>
                        <tr></tr>
");
            EndContext();
#line 40 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml"
                    }

#line default
#line hidden
            BeginContext(1623, 52, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
            EndContext();
#line 44 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml"

    // 9-10.系統在View【Views/Shared/Components/MemberBonusList/Default.cshtml】中顯示換頁超連結。

#line default
#line hidden
            BeginContext(1763, 19, true);
            WriteLiteral("    <div>\r\n        ");
            EndContext();
            BeginContext(1782, 238, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pager", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c58d92a1626e493598daeceb7e7dd494", async() => {
            }
            );
            __YunQiERP_TagHelpers_PagerTagHelper = CreateTagHelper<global::YunQiERP.TagHelpers.PagerTagHelper>();
            __tagHelperExecutionContext.Add(__YunQiERP_TagHelpers_PagerTagHelper);
#line 47 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.CurrentPage = Model.CurrentPage;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("current-page", __YunQiERP_TagHelpers_PagerTagHelper.CurrentPage, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 47 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.PageCount = Model.PageCount;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("page-count", __YunQiERP_TagHelpers_PagerTagHelper.PageCount, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 47 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.Parameters = null;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("parameters", __YunQiERP_TagHelpers_PagerTagHelper.Parameters, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 47 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.StartPage = Model.StartPage;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("start-page", __YunQiERP_TagHelpers_PagerTagHelper.StartPage, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 47 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.TotalPages = Model.TotalPages;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("total-pages", __YunQiERP_TagHelpers_PagerTagHelper.TotalPages, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __YunQiERP_TagHelpers_PagerTagHelper.PageLinkSize = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __YunQiERP_TagHelpers_PagerTagHelper.AClass = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 47 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml"
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
            BeginContext(2020, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 49 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml"
}
else
{
    //9-8a.系統判斷!(9-7傳回之listMemberBonusListViewModel!=null and Count>0)。
    //9 - 8a - 1.回11。

#line default
#line hidden
            BeginContext(2142, 39, true);
            WriteLiteral("    <h3>\r\n        沒有業務發展獎金\r\n    </h3>\r\n");
            EndContext();
#line 57 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\EmployeeDevelopmentBonusList\Default.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EmployeeDevelopmentBonusListManageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
