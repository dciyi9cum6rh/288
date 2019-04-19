#pragma checksum "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9eee67dc1f4ef8df734a944e97faf55177331bb9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_PurchaseList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/PurchaseList/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/PurchaseList/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_PurchaseList_Default))]
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
#line 1 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
using DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9eee67dc1f4ef8df734a944e97faf55177331bb9", @"/Views/Shared/Components/PurchaseList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b4f9f7d0ad6169b0d02079f8a353bf4ccfe20a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_PurchaseList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PurchaseListManageViewModel>
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
#line 3 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
  
    List<int> tR = ViewBag.TR;
    int Page = ViewBag.Page;
    int id = (Page - 1) * 10;

#line default
#line hidden
            BeginContext(276, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 9 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
 if (Model.listPurchaseListViewModel != null && Model.listPurchaseListViewModel.Count > 0)
{
    // 9-9.系統在View【Views/Shared/Components/PurchaseList/Default.cshtml】中顯示[進貨單清單]。

#line default
#line hidden
            BeginContext(457, 623, true);
            WriteLiteral(@"    <div class=""container container-fluid"">
        <table class=""table table-bordered"">
            <thead>
                <tr style=""color:gainsboro;background-color:#000000"">
                    <th>#</th>
                    <th>進貨單號</th>
                    <th>進貨日期</th>
                    <th>幣別</th>
                    <th>滙率</th>
                    <th>運費</th>
                    <th>雜費</th>
                    <th>商品總額</th>
                    <th>進貨成本</th>
                    <th>進貨成本(台幣)</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 30 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
                 foreach (PurchaseListViewModel MLVM in Model.listPurchaseListViewModel)
                {
                    id += 1;

#line default
#line hidden
            BeginContext(1219, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(1274, 2, false);
#line 34 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
                       Write(id);

#line default
#line hidden
            EndContext();
            BeginContext(1276, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1312, 15, false);
#line 35 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
                       Write(MLVM.PurchaseId);

#line default
#line hidden
            EndContext();
            BeginContext(1327, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1363, 17, false);
#line 36 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
                       Write(MLVM.PurchaseTime);

#line default
#line hidden
            EndContext();
            BeginContext(1380, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1416, 13, false);
#line 37 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
                       Write(MLVM.Currency);

#line default
#line hidden
            EndContext();
            BeginContext(1429, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1465, 17, false);
#line 38 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
                       Write(MLVM.ExchangeRate);

#line default
#line hidden
            EndContext();
            BeginContext(1482, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1518, 12, false);
#line 39 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
                       Write(MLVM.Freight);

#line default
#line hidden
            EndContext();
            BeginContext(1530, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1566, 18, false);
#line 40 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
                       Write(MLVM.miscellaneous);

#line default
#line hidden
            EndContext();
            BeginContext(1584, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1620, 15, false);
#line 41 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
                       Write(MLVM.ProductFee);

#line default
#line hidden
            EndContext();
            BeginContext(1635, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1671, 17, false);
#line 42 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
                       Write(MLVM.TotalExpense);

#line default
#line hidden
            EndContext();
            BeginContext(1688, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1724, 19, false);
#line 43 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
                       Write(MLVM.TotalExpenseNT);

#line default
#line hidden
            EndContext();
            BeginContext(1743, 37, true);
            WriteLiteral("</td>\r\n                        <td>\r\n");
            EndContext();
#line 45 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
                             if (tR.Contains(19))
                            {

#line default
#line hidden
            BeginContext(1862, 166, true);
            WriteLiteral("                                <a class=\"btn btn-default btn-edit\" role=\"button\"><span class=\"glyphicon glyphicon-pencil\" aria-hidden=\"true\" title=\"修改\"></span></a>\r\n");
            EndContext();
#line 48 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
                            }

#line default
#line hidden
            BeginContext(2059, 28, true);
            WriteLiteral("                            ");
            EndContext();
#line 49 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
                             if (tR.Contains(20))
                            {

#line default
#line hidden
            BeginContext(2141, 167, true);
            WriteLiteral("                                <a class=\"btn btn-default btn-delete\" role=\"button\"><span class=\"glyphicon glyphicon-trash\" aria-hidden=\"true\" title=\"刪除\"></span></a>\r\n");
            EndContext();
#line 52 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
                            }

#line default
#line hidden
            BeginContext(2339, 256, true);
            WriteLiteral(@"                            <a class=""btn btn-default btn-detail"" role=""button""><span class=""glyphicon glyphicon-th-list"" aria-hidden=""true"" title=""進貨清單""></span></a>
                        </td>
                    </tr>
                    <tr></tr>
");
            EndContext();
#line 57 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(2614, 52, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
            EndContext();
#line 61 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
    // 9-10.系統在View【Views/Shared/Components/PurchaseList/Default.cshtml】中顯示換頁超連結。

#line default
#line hidden
            BeginContext(2749, 19, true);
            WriteLiteral("    <div>\r\n        ");
            EndContext();
            BeginContext(2768, 291, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pager", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61f476f5fc024bc3a4eaa5437e626c73", async() => {
            }
            );
            __YunQiERP_TagHelpers_PagerTagHelper = CreateTagHelper<global::YunQiERP.TagHelpers.PagerTagHelper>();
            __tagHelperExecutionContext.Add(__YunQiERP_TagHelpers_PagerTagHelper);
#line 63 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.CurrentPage = Model.CurrentPage;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("current-page", __YunQiERP_TagHelpers_PagerTagHelper.CurrentPage, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 63 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.PageCount = Model.PageCount;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("page-count", __YunQiERP_TagHelpers_PagerTagHelper.PageCount, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 63 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.Parameters = null;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("parameters", __YunQiERP_TagHelpers_PagerTagHelper.Parameters, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 63 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.StartPage = Model.StartPage;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("start-page", __YunQiERP_TagHelpers_PagerTagHelper.StartPage, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 63 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.TotalPages = Model.TotalPages;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("total-pages", __YunQiERP_TagHelpers_PagerTagHelper.TotalPages, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 63 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
                                                                                                                                                        WriteLiteral(Url.Action("GetPurchaseList", "Purchase"));

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __YunQiERP_TagHelpers_PagerTagHelper.Url = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("url", __YunQiERP_TagHelpers_PagerTagHelper.Url, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __YunQiERP_TagHelpers_PagerTagHelper.PageLinkSize = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
#line 63 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
                                                                                                                                                                                                                                            WriteLiteral(Model.AClass);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __YunQiERP_TagHelpers_PagerTagHelper.AClass = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("a-class", __YunQiERP_TagHelpers_PagerTagHelper.AClass, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 63 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
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
            BeginContext(3059, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 65 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
}
else
{
    // 9-8a.系統判斷!(9-7傳回之listPurchaseListViewModel!=null and Count>0)。

#line default
#line hidden
            BeginContext(3156, 20, true);
            WriteLiteral("    <h3>沒有進貨單</h3>\r\n");
            EndContext();
#line 70 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\PurchaseList\Default.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PurchaseListManageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
