#pragma checksum "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MemberDevelopmentBonusDetailList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4deea3cc2bfc26a4a2f46fc2adbc03b55be9026"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_MemberDevelopmentBonusDetailList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/MemberDevelopmentBonusDetailList/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/MemberDevelopmentBonusDetailList/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_MemberDevelopmentBonusDetailList_Default))]
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
#line 1 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MemberDevelopmentBonusDetailList\Default.cshtml"
using DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4deea3cc2bfc26a4a2f46fc2adbc03b55be9026", @"/Views/Shared/Components/MemberDevelopmentBonusDetailList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b4f9f7d0ad6169b0d02079f8a353bf4ccfe20a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_MemberDevelopmentBonusDetailList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MemberDevelopmentBonusDetailListManageViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-link-size", "pagination-md", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("a-class", "inner-page-link", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MemberDevelopmentBonusDetailList\Default.cshtml"
  
    List<int> tR = ViewBag.TR;
    int Page = ViewBag.Page;
    int id = (Page - 1) * 10;

#line default
#line hidden
            BeginContext(422, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 10 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MemberDevelopmentBonusDetailList\Default.cshtml"
 if (Model.listMemberDevelopmentBonusDetailListViewModel != null && Model.listMemberDevelopmentBonusDetailListViewModel.Count > 0)
{
    //9-9.系統在View【Views/Shared/Components/MemberBonusDetailList/Default.cshtml】中顯示[批發會員獎金清單]。

#line default
#line hidden
            BeginContext(656, 388, true);
            WriteLiteral(@"    <div class=""container container-fluid"">
        <table class=""table table-bordered table-condensed"" id=""tableProduct"">
            <thead>
                <tr style=""color:gainsboro;background-color:#000000"">
                    <th>會員手機</th>
                    <th>會員姓名</th>
                    <th>採購總額</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 23 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MemberDevelopmentBonusDetailList\Default.cshtml"
                 foreach (var o in Model.listMemberDevelopmentBonusDetailListViewModel)
                {

#line default
#line hidden
            BeginContext(1152, 54, true);
            WriteLiteral("                    <tr>\r\n                        <th>");
            EndContext();
            BeginContext(1207, 14, false);
#line 26 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MemberDevelopmentBonusDetailList\Default.cshtml"
                       Write(o.MemberMobile);

#line default
#line hidden
            EndContext();
            BeginContext(1221, 35, true);
            WriteLiteral("</th>\r\n                        <th>");
            EndContext();
            BeginContext(1257, 12, false);
#line 27 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MemberDevelopmentBonusDetailList\Default.cshtml"
                       Write(o.MemberName);

#line default
#line hidden
            EndContext();
            BeginContext(1269, 35, true);
            WriteLiteral("</th>\r\n                        <th>");
            EndContext();
            BeginContext(1305, 9, false);
#line 28 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MemberDevelopmentBonusDetailList\Default.cshtml"
                       Write(o.VipDate);

#line default
#line hidden
            EndContext();
            BeginContext(1314, 34, true);
            WriteLiteral("</th>\r\n                    </tr>\r\n");
            EndContext();
#line 30 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MemberDevelopmentBonusDetailList\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(1367, 52, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
            EndContext();
#line 34 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MemberDevelopmentBonusDetailList\Default.cshtml"
    //9-10.系統在View【Views/Shared/Components/MemberBonusDetailList/Default.cshtml】中顯示換頁超連結。

#line default
#line hidden
            BeginContext(1510, 19, true);
            WriteLiteral("    <div>\r\n        ");
            EndContext();
            BeginContext(1529, 244, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pager", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "43235d19aded4bc3be44b1ce2356289a", async() => {
            }
            );
            __YunQiERP_TagHelpers_PagerTagHelper = CreateTagHelper<global::YunQiERP.TagHelpers.PagerTagHelper>();
            __tagHelperExecutionContext.Add(__YunQiERP_TagHelpers_PagerTagHelper);
#line 36 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MemberDevelopmentBonusDetailList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.CurrentPage = Model.CurrentPage;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("current-page", __YunQiERP_TagHelpers_PagerTagHelper.CurrentPage, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 36 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MemberDevelopmentBonusDetailList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.PageCount = Model.PageCount;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("page-count", __YunQiERP_TagHelpers_PagerTagHelper.PageCount, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 36 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MemberDevelopmentBonusDetailList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.Parameters = null;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("parameters", __YunQiERP_TagHelpers_PagerTagHelper.Parameters, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 36 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MemberDevelopmentBonusDetailList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.StartPage = Model.StartPage;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("start-page", __YunQiERP_TagHelpers_PagerTagHelper.StartPage, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 36 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MemberDevelopmentBonusDetailList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.TotalPages = Model.TotalPages;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("total-pages", __YunQiERP_TagHelpers_PagerTagHelper.TotalPages, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __YunQiERP_TagHelpers_PagerTagHelper.PageLinkSize = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __YunQiERP_TagHelpers_PagerTagHelper.AClass = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 36 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MemberDevelopmentBonusDetailList\Default.cshtml"
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
            BeginContext(1773, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 38 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MemberDevelopmentBonusDetailList\Default.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(1799, 23, true);
            WriteLiteral("    <h3>沒有會員發展獎金</h3>\r\n");
            EndContext();
#line 42 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MemberDevelopmentBonusDetailList\Default.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MemberDevelopmentBonusDetailListManageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
