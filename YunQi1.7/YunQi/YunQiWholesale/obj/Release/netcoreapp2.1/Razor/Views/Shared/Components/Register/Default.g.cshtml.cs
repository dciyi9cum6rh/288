#pragma checksum "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Register\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25c9c6bd360932799a59fe9eebcf28da1d7fe848"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Register_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Register/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Register/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Register_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25c9c6bd360932799a59fe9eebcf28da1d7fe848", @"/Views/Shared/Components/Register/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28caaf0241098ecd91020ca85cf41e4615f1e192", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Register_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2431, true);
            WriteLiteral(@"<div class=""register-component"">
    <div class=""container"">
        <div class=""title-box border-bottom d-flex align-items-center mb-3"">
            <h2 class=""mr-3"">會員申請表</h2>
            <button id=""mobileSide"" type=""button"" class=""btn btn-maintype mb-2 mobiletype"">選單</button>
        </div>
        <div class=""form-box"">
            <div class=""form-group row"">
                <label for="""" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">手機(帳號)*：</label>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">
                    <input id=""MemberMobile"" type=""text"" class=""form-control"" placeholder="""" />
                </div>
            </div>
            <div class=""form-group row"">
                <label for="""" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6 mb-3"">密碼*：</label>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">
                    <input id=""Password"" type=""password"" class=""form-control"" />");
            WriteLiteral(@"
                </div>
                <label for="""" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">確認密碼*：</label>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">
                    <input id=""ConfirmPassword"" type=""password"" class=""form-control"" />
                </div>
            </div>
            <div class=""form-group row"">
                <label for="""" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">姓名*：</label>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">
                    <input id=""MemberName"" type=""text"" class=""form-control"" placeholder=""中英文字"" />
                </div>
            </div>
            <div class=""form-group row"">
                <label for="""" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">暱稱*：</label>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">
                    <input id=""NickName"" type=""text"" class=""form-control");
            WriteLiteral(@""" placeholder=""中英文字"" />
                </div>
            </div>
            <div class=""form-group row"">
                <label for="""" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">性別*：</label>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">
                    <select id=""sex"" class=""form-control"">
                        ");
            EndContext();
            BeginContext(2431, 29, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2eabb1f17c4f465db537f706bf54b571", async() => {
                BeginContext(2449, 2, true);
                WriteLiteral("女性");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2460, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(2486, 29, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "59479c5e820447ef987c7a840e06c99c", async() => {
                BeginContext(2504, 2, true);
                WriteLiteral("男性");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2515, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(2541, 40, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cbeeafc9fc284146871f7bd14b4f30d0", async() => {
                BeginContext(2568, 4, true);
                WriteLiteral("暫不告知");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2581, 453, true);
            WriteLiteral(@"
                    </select>
                </div>
            </div>
            <div class=""form-group row"">
                <label for="""" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">E-Mail*：</label>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">
                    <input id=""eMail"" type=""text"" class=""form-control"" placeholder=""請使用GMAIL"" />
                </div>
            </div>
");
            EndContext();
            BeginContext(3790, 380, true);
            WriteLiteral(@"            <div class=""form-group row"">
                <label for="""" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">地址*：</label>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">
                    <input id=""ContactAddress"" type=""text"" class=""form-control"" placeholder=""中英文字與數字"" />
                </div>
            </div>
");
            EndContext();
            BeginContext(6445, 338, true);
            WriteLiteral(@"            <div class=""function-box d-flex justify-content-center pt-1 pb-1"">
                <button type=""button"" class=""btn btn-join btn-maintype"" id=""btnJoinMember"">加入一般會員</button>
                <button style=""display:none"" id=""refbutton"" type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#exampleModal"" />
");
            EndContext();
            BeginContext(6927, 56, true);
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
