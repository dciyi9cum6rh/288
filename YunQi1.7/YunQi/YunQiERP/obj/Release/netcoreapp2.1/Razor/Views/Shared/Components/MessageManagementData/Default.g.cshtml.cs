#pragma checksum "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11cfc734e40f0301308d62a7c72d265ac05f8f9c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_MessageManagementData_Default), @"mvc.1.0.view", @"/Views/Shared/Components/MessageManagementData/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/MessageManagementData/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_MessageManagementData_Default))]
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
#line 1 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
using DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11cfc734e40f0301308d62a7c72d265ac05f8f9c", @"/Views/Shared/Components/MessageManagementData/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b4f9f7d0ad6169b0d02079f8a353bf4ccfe20a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_MessageManagementData_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MessageManagementDataManageViewModel>
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
#line 3 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
  
    List<int> tR = ViewBag.TR;
    int Page = ViewBag.Page;
    int id = (Page - 1) * 10;

#line default
#line hidden
            BeginContext(298, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 9 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
 if (Model.listReplyMessageManagementDataListviewModel != null && Model.listReplyMessageManagementDataListviewModel.Count > 0)
{
    // 9-9.系統在View【Views/Shared/Components/OrderDetailListNoButton/Default.cshtml】中顯示[目前銷貨清單] (含修改與刪除，但應依ViewBag.TR之權限顯示)。

#line default
#line hidden
            BeginContext(555, 490, true);
            WriteLiteral(@"    <div class=""container container-fluid"">
        <table class=""table table-bordered table-condensed"" id=""tableProduct"">
            <thead>
                <tr style=""color:gainsboro;background-color:#000000"">
                    <th>項次</th>
                    <th>回覆者</th>
                    <th>回復時間</th>
                    <th>回覆者手機</th>
                    <th>回覆內容</th>
                    <th>#</th>
                </tr>
            </thead>
            <tbody>

");
            EndContext();
#line 26 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
                 foreach (var o in Model.listReplyMessageManagementDataListviewModel)
                {

#line default
#line hidden
            BeginContext(1151, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(1206, 16, false);
#line 29 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
                       Write(o.ReplyMessageId);

#line default
#line hidden
            EndContext();
            BeginContext(1222, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1258, 15, false);
#line 30 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
                       Write(o.ReplyNickName);

#line default
#line hidden
            EndContext();
            BeginContext(1273, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1309, 18, false);
#line 31 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
                       Write(o.ReplyMessageTime);

#line default
#line hidden
            EndContext();
            BeginContext(1327, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1363, 13, false);
#line 32 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
                       Write(o.ReplyMobile);

#line default
#line hidden
            EndContext();
            BeginContext(1376, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1412, 19, false);
#line 33 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
                       Write(o.ReplyMessageValue);

#line default
#line hidden
            EndContext();
            BeginContext(1431, 222, true);
            WriteLiteral("</td>\r\n                        <td>\r\n                            <a class=\"btn btn-default btn-DeleteReplyMessageManagement\" role=\"button\" title=\"刪除\"><span class=\"glyphicon glyphicon-trash\" aria-hidden=\"true\"></span></a>\r\n");
            EndContext();
#line 36 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
                             if (@o.ReplyMobile != "0911111111")
                            {

#line default
#line hidden
            BeginContext(1750, 185, true);
            WriteLiteral("                                <a class=\"btn btn-default btn-UpdateMemberEnabledData\" role=\"button\" title=\"停權\"><span class=\"glyphicon glyphicon-remove\" aria-hidden=\"true\"></span></a>\r\n");
            EndContext();
#line 39 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
                            }

#line default
#line hidden
            BeginContext(1966, 58, true);
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 42 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(2043, 52, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
            EndContext();
#line 46 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
    // 9-10.系統在View【Views/Shared/Components/OrderDetailListNoButton/Default.cshtml】中顯示換頁超連結。

#line default
#line hidden
            BeginContext(2189, 19, true);
            WriteLiteral("    <div>\r\n        ");
            EndContext();
            BeginContext(2208, 299, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pager", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd927d3916ce4344808c8b7a9c13621b", async() => {
            }
            );
            __YunQiERP_TagHelpers_PagerTagHelper = CreateTagHelper<global::YunQiERP.TagHelpers.PagerTagHelper>();
            __tagHelperExecutionContext.Add(__YunQiERP_TagHelpers_PagerTagHelper);
#line 48 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.CurrentPage = Model.CurrentPage;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("current-page", __YunQiERP_TagHelpers_PagerTagHelper.CurrentPage, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 48 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.PageCount = Model.PageCount;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("page-count", __YunQiERP_TagHelpers_PagerTagHelper.PageCount, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 48 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.Parameters = null;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("parameters", __YunQiERP_TagHelpers_PagerTagHelper.Parameters, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 48 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.StartPage = Model.StartPage;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("start-page", __YunQiERP_TagHelpers_PagerTagHelper.StartPage, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 48 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.TotalPages = Model.TotalPages;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("total-pages", __YunQiERP_TagHelpers_PagerTagHelper.TotalPages, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 48 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
                                                                                                                                                        WriteLiteral(Url.Action("GetOrderDetailListNoButton", "Order"));

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __YunQiERP_TagHelpers_PagerTagHelper.Url = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("url", __YunQiERP_TagHelpers_PagerTagHelper.Url, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __YunQiERP_TagHelpers_PagerTagHelper.PageLinkSize = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
#line 48 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
                                                                                                                                                                                                                                                    WriteLiteral(Model.AClass);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __YunQiERP_TagHelpers_PagerTagHelper.AClass = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("a-class", __YunQiERP_TagHelpers_PagerTagHelper.AClass, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 48 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
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
            BeginContext(2507, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 50 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(2533, 22, true);
            WriteLiteral("    <h3>沒有回覆的留言</h3>\r\n");
            EndContext();
#line 54 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagementData\Default.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MessageManagementDataManageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
