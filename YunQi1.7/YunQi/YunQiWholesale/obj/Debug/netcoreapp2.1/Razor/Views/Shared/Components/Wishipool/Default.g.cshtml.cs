#pragma checksum "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eee560fbdc41431adac1cf1d5d41ab271ceb30b8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Wishipool_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Wishipool/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Wishipool/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Wishipool_Default))]
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
#line 1 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\_ViewImports.cshtml"
using YunQiWholesale;

#line default
#line hidden
#line 2 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\_ViewImports.cshtml"
using YunQiWholesale.Models;

#line default
#line hidden
#line 1 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
using DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eee560fbdc41431adac1cf1d5d41ab271ceb30b8", @"/Views/Shared/Components/Wishipool/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28caaf0241098ecd91020ca85cf41e4615f1e192", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Wishipool_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WishipoolManageViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("main-pic mr-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/member.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Generic placeholder image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 1865, true);
            WriteLiteral(@"
<div class=""membermove-component"">
    <div class=""container"">
        <div class=""title-box border-bottom d-flex align-items-center mb-3"">
            <h2 class=""mr-3"">許願池</h2>
            <button id=""mobileSide"" type=""button"" class=""btn btn-maintype mb-2 mobiletype"">選單</button>
        </div>
        <div class=""search-box row mb-3"">
            <div class=""col-12 col-sm-12 col-md-12 col-lg-2 col-xl-2"">
                <input id=""sDateO"" type=""text"" placeholder=""日期(起)"" class=""form-control"" />
            </div>
            <div class=""col-12 col-sm-12 col-md-12 col-lg-2 col-xl-2"">
                <input id=""eDateO"" type=""text"" placeholder=""日期(迄)"" class=""form-control"" />
            </div>
            <div class=""col-12 col-sm-12 col-md-12 col-lg-3 col-xl-3"">
                <input id=""MessageValue"" type=""text"" placeholder=""留言"" class=""form-control"" />
            </div>
            <div class=""col-12 col-sm-12 col-md-12 col-lg-3 col-xl-3"">
                <input id=""NickName"" type=""text"" p");
            WriteLiteral(@"laceholder=""發布者暱稱"" class=""form-control"" />
            </div>
            <div class=""col-12 col-sm-12 col-md-12 col-lg-2 col-xl-2"">
                <button id=""btnSerrchWishipool"" type=""button"" class=""btn btn-block btn-maintype"">搜尋</button>
            </div>
        </div>
        <div class=""control-box row mb-3"">
            <div class=""col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4 d-flex align-items-center pt-1 pb-1"">
                <button type=""button"" class=""btn btn-block btn-maintype"" data-toggle=""modal"" data-target=""#newModal"">新增留言</button>
            </div>
            <div class=""col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4 pt-1 pb-1"">
                <button type=""button"" class=""btn btn-block btn-maintype"" data-toggle=""modal"" data-target=""#noticeModal"">注意事項</button>
            </div>
        </div>

");
            EndContext();
#line 36 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
         if (@Model.listMemberExchangeListViewModel != null && @Model.listMemberExchangeListViewModel.Count > 0)
        {

#line default
#line hidden
            BeginContext(2041, 541, true);
            WriteLiteral(@"            <div class=""pagination-box row mb-3"">
                <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8 pt-1 pb-1"">
                    <div class=""row"">
                        <div class=""col-3 col-sm-3 col-md-3 col-lg-3 col-xl-3"">
                            <button type=""button"" class=""btn btn-block btn-maintype"" id=""WishipoolPrePage""><i class=""fas fa-angle-left""></i></button>
                        </div>
                        <div class=""pagination flexcenter col-6 col-sm-6 col-md-6 col-lg-6 col-xl-4"">");
            EndContext();
            BeginContext(2583, 17, false);
#line 44 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
                                                                                                Write(Model.CurrentPage);

#line default
#line hidden
            EndContext();
            BeginContext(2600, 1, true);
            WriteLiteral("/");
            EndContext();
            BeginContext(2602, 16, false);
#line 44 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
                                                                                                                   Write(Model.TotalPages);

#line default
#line hidden
            EndContext();
            BeginContext(2618, 766, true);
            WriteLiteral(@"</div>
                        <div class=""col-3 col-sm-3 col-md-3 col-lg-3 col-xl-3"">
                            <button type=""button"" class=""btn btn-block btn-maintype"" id=""WishipoolNextPage""><i class=""fas fa-angle-right""></i></button>
                        </div>
                    </div>
                </div>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4 pt-1 pb-1"">
                    <div class=""dropdown"">
                        <button class=""btn btn-block dropdown-toggle btn-maintype"" type=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">第1頁</button>
                        <div class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""dropdownMenuButton"" id=""WishipoolPageList"">
");
            EndContext();
#line 54 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
                             for (int i = 1; i <= Model.TotalPages; i++)
                            {

#line default
#line hidden
            BeginContext(3489, 77, true);
            WriteLiteral("                                <a class=\"dropdown-item\" href=\"#\" data-page=\"");
            EndContext();
            BeginContext(3568, 1, false);
#line 56 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
                                                                         Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(3570, 3, true);
            WriteLiteral("\">第");
            EndContext();
            BeginContext(3575, 1, false);
#line 56 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
                                                                                Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(3577, 7, true);
            WriteLiteral("頁</a>\r\n");
            EndContext();
#line 57 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
                            }

#line default
#line hidden
            BeginContext(3615, 104, true);
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 62 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
             foreach (var o in Model.listMemberExchangeListViewModel)
            {

#line default
#line hidden
            BeginContext(3805, 154, true);
            WriteLiteral("                <div class=\"bbslist-box\">\r\n                    <div class=\"bbslist-item bg-light mb-3 p-3\">\r\n                        <div class=\"media\">\r\n");
            EndContext();
            BeginContext(4004, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(4032, 85, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ace99ae69c4348ebabc5d1b9cf5d6471", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4117, 105, true);
            WriteLiteral("\r\n                            <div class=\"media-body\">\r\n                                <h5 class=\"mt-0\">");
            EndContext();
            BeginContext(4223, 14, false);
#line 70 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
                                            Write(o.MessageTitle);

#line default
#line hidden
            EndContext();
            BeginContext(4237, 84, true);
            WriteLiteral("</h5>\r\n                                <hr />\r\n                                <div>");
            EndContext();
            BeginContext(4322, 14, false);
#line 72 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
                                Write(o.MessageValue);

#line default
#line hidden
            EndContext();
            BeginContext(4336, 10, true);
            WriteLiteral("</div>\r\n\r\n");
            EndContext();
            BeginContext(4405, 32, true);
            WriteLiteral("                                ");
            EndContext();
            BeginContext(4438, 85, false);
#line 75 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
                           Write(await Component.InvokeAsync("MessageManagementData", new { MessageId = o.MessageId }));

#line default
#line hidden
            EndContext();
            BeginContext(4523, 227, true);
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"function-box\">\r\n                            <button type=\"button\" class=\"btn btn-maintype newReplyModal\" data-messageid=\"");
            EndContext();
            BeginContext(4751, 11, false);
#line 79 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
                                                                                                    Write(o.MessageId);

#line default
#line hidden
            EndContext();
            BeginContext(4762, 99, true);
            WriteLiteral("\">回復</button>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
#line 83 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
            }

#line default
#line hidden
#line 83 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
             
        }
        else
        {

#line default
#line hidden
            BeginContext(4912, 30, true);
            WriteLiteral("            <h3>沒有許願池內容</h3>\r\n");
            EndContext();
#line 88 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
        }

#line default
#line hidden
            BeginContext(4953, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(4979, 1595, true);
            WriteLiteral(@"        <div class=""modal fade"" id=""newModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
            <div class=""modal-dialog modal-lg"" role=""document"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title"" id=""exampleModalLabel"">新留言</h5>
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">&times;</span>
                        </button>
                    </div>
                    <div class=""modal-body"">
                        <div class=""form-group"">
                            <label for=""recipient-name"" class=""col-form-label"">標題:</label>
                            <input type=""text"" class=""form-control"" id=""newMembermoveMessageTitle"">
                        </div>
                        <div class=""form-group"">
                            <label for=""message-t");
            WriteLiteral(@"ext"" class=""col-form-label"">內容:</label>
                            <textarea class=""form-control"" id=""newMembermoveMessageValue""></textarea>
                        </div>
                    </div>
                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-maintype"" data-dismiss=""modal"">取消</button>
                        <button type=""button"" class=""btn btn-maintype"" data-versionid=""2"" id=""btn-NewMembermove"">送出</button>
                    </div>
                </div>
            </div>
        </div>
");
            EndContext();
            BeginContext(6598, 1373, true);
            WriteLiteral(@"        <div class=""modal fade"" id=""newReplyModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
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
 ");
            WriteLiteral(@"                   <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-maintype"" data-dismiss=""modal"">取消</button>
                        <button type=""button"" class=""btn btn-maintype"" id=""btn-NewReplyMessage"">送出</button>
                    </div>
                </div>
            </div>
        </div>
");
            EndContext();
            BeginContext(7995, 602, true);
            WriteLiteral(@"        <div class=""modal fade"" id=""noticeModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
            <div class=""modal-dialog modal-lg"" role=""document"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title"" id=""exampleModalLabel"">注意事項</h5>
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""></button>
                    </div>
                    <div class=""modal-body"">
                        <img id=""imgMember""");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 8597, "\"", 8666, 1);
#line 150 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
WriteAttributeValue("", 8603, Url.Action("GetCagegoryImage", "Member", new { VersionId = 2}), 8603, 63, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(8667, 482, true);
            WriteLiteral(@" style=""margin:0px auto; width:100%"" />
                    </div>
                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-maintype"" data-dismiss=""modal"">同意</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script>
    $(document).ready(function () {
        // 10.系統設定jCurrentPage=9-7回傳CurrentPage，系統設定jTotallPages=9-7回傳TotalPages。
        jCurrentPage =");
            EndContext();
            BeginContext(9150, 17, false);
#line 163 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
                 Write(Model.CurrentPage);

#line default
#line hidden
            EndContext();
            BeginContext(9167, 25, true);
            WriteLiteral(";\r\n        jTotallPages =");
            EndContext();
            BeginContext(9193, 16, false);
#line 164 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Wishipool\Default.cshtml"
                 Write(Model.TotalPages);

#line default
#line hidden
            EndContext();
            BeginContext(9209, 23, true);
            WriteLiteral(";\r\n    });\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WishipoolManageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
