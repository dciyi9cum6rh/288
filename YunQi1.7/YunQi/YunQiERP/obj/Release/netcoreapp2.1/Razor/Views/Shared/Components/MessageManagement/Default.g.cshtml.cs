#pragma checksum "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "030113e792a9b94a3b2ac1adbb2f8ee7a4bfa313"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_MessageManagement_Default), @"mvc.1.0.view", @"/Views/Shared/Components/MessageManagement/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/MessageManagement/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_MessageManagement_Default))]
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
#line 1 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
using DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"030113e792a9b94a3b2ac1adbb2f8ee7a4bfa313", @"/Views/Shared/Components/MessageManagement/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b4f9f7d0ad6169b0d02079f8a353bf4ccfe20a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_MessageManagement_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MessageManagementManageViewModel>
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
#line 3 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
  
    List<int> tR = ViewBag.TR;
    int Page = ViewBag.Page;
    int id = (Page - 1) * 10;

#line default
#line hidden
            BeginContext(159, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 10 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
 if (Model.listMessageManagementList != null && Model.listMessageManagementList.Count > 0)
{
    

#line default
#line hidden
            BeginContext(459, 557, true);
            WriteLiteral(@"    <div class=""container container-fluid"">
        <table class=""table table-bordered table-condensed"" id=""tableProduct"">
            <thead>
                <tr style=""color:gainsboro;background-color:#000000"">
                    <th>項次</th>
                    <th>版別</th>
                    <th>發佈時間</th>
                    <th>留言者手機</th>
                    <th>留言者暱稱</th>
                    <th>留言標題</th>
                    <th>留言內容</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 28 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
                 foreach (var o in @Model.listMessageManagementList)
                {

#line default
#line hidden
            BeginContext(1105, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(1160, 11, false);
#line 31 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
                       Write(o.MessageId);

#line default
#line hidden
            EndContext();
            BeginContext(1171, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1207, 13, false);
#line 32 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
                       Write(o.VersionName);

#line default
#line hidden
            EndContext();
            BeginContext(1220, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1256, 13, false);
#line 33 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
                       Write(o.MessageTime);

#line default
#line hidden
            EndContext();
            BeginContext(1269, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1305, 14, false);
#line 34 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
                       Write(o.MemberMobile);

#line default
#line hidden
            EndContext();
            BeginContext(1319, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1355, 10, false);
#line 35 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
                       Write(o.NickName);

#line default
#line hidden
            EndContext();
            BeginContext(1365, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1401, 14, false);
#line 36 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
                       Write(o.MessageTitle);

#line default
#line hidden
            EndContext();
            BeginContext(1415, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1451, 14, false);
#line 37 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
                       Write(o.MessageValue);

#line default
#line hidden
            EndContext();
            BeginContext(1465, 568, true);
            WriteLiteral(@"</td>
                        <td>
                            <a class=""btn btn-default btn-MessageContent"" role=""button"" title=""內容""><span class=""glyphicon glyphicon-align-center"" aria-hidden=""true""></span></a>
                            <a class=""btn btn-default btn-MessageReply"" role=""button"" title=""回復""><span class=""glyphicon glyphicon-text-size"" aria-hidden=""true""></span></a>
                            <a class=""btn btn-default btn-DeleteMessageManagement"" role=""button"" title=""刪除""><span class=""glyphicon glyphicon-trash"" aria-hidden=""true""></span></a>
");
            EndContext();
#line 42 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
                             if (@o.MemberMobile != "0911111111" && @o.MemberMobile != "1111111111")
                            {

#line default
#line hidden
            BeginContext(2166, 181, true);
            WriteLiteral("                                <a class=\"btn btn-default btn-UpdateMemberEnabled\" role=\"button\" title=\"停權\"><span class=\"glyphicon glyphicon-remove\" aria-hidden=\"true\"></span></a>\r\n");
            EndContext();
#line 45 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
                            }

#line default
#line hidden
            BeginContext(2378, 89, true);
            WriteLiteral("                        </td>\r\n                    </tr>\r\n                    <tr></tr>\r\n");
            EndContext();
#line 49 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(2486, 52, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
            EndContext();
#line 53 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"

    //Model 新增回復

#line default
#line hidden
            BeginContext(2558, 1281, true);
            WriteLiteral(@"    <div class=""modal fade"" id=""newReplyModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
        <div class=""modal-dialog modal-lg"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLabel"">新增回復</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <input type=""hidden"" id=""ReplyVersionid"" />
                    <div class=""form-group"">
                        <label for=""message-text"" class=""col-form-label"">內容:</label>
                        <textarea class=""form-control"" id=""newReplyMessageValue""></textarea>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <");
            WriteLiteral(@"button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">取消</button>
                    <button type=""button"" class=""btn btn-primary"" id=""btn-NewReplyMessage"">送出</button>
                </div>
            </div>
        </div>
    </div>
");
            EndContext();
#line 78 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"

    // 9-10.系統在View【Views/Shared/Components/OrderList/Default.cshtml】中顯示換頁超連結。

#line default
#line hidden
            BeginContext(3921, 19, true);
            WriteLiteral("    <div>\r\n        ");
            EndContext();
            BeginContext(3940, 238, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pager", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b997149aea3e45f1b798a3ef54bc24cb", async() => {
            }
            );
            __YunQiERP_TagHelpers_PagerTagHelper = CreateTagHelper<global::YunQiERP.TagHelpers.PagerTagHelper>();
            __tagHelperExecutionContext.Add(__YunQiERP_TagHelpers_PagerTagHelper);
#line 81 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.CurrentPage = Model.CurrentPage;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("current-page", __YunQiERP_TagHelpers_PagerTagHelper.CurrentPage, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 81 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.PageCount = Model.PageCount;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("page-count", __YunQiERP_TagHelpers_PagerTagHelper.PageCount, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 81 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.Parameters = null;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("parameters", __YunQiERP_TagHelpers_PagerTagHelper.Parameters, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 81 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.StartPage = Model.StartPage;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("start-page", __YunQiERP_TagHelpers_PagerTagHelper.StartPage, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 81 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
__YunQiERP_TagHelpers_PagerTagHelper.TotalPages = Model.TotalPages;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("total-pages", __YunQiERP_TagHelpers_PagerTagHelper.TotalPages, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __YunQiERP_TagHelpers_PagerTagHelper.PageLinkSize = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __YunQiERP_TagHelpers_PagerTagHelper.AClass = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 81 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
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
            BeginContext(4178, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 83 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
}
else
{
    // 9-8a.系統判斷!(9-7傳回之listOrderListViewModel!=null and Count>0)。

#line default
#line hidden
            BeginContext(4272, 22, true);
            WriteLiteral("    <h3>沒有留言待管理</h3>\r\n");
            EndContext();
#line 88 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\MessageManagement\Default.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MessageManagementManageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
