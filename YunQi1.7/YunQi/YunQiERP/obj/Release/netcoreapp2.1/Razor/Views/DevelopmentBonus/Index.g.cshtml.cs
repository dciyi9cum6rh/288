#pragma checksum "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa904a0d41d80db50c38ad7fd8da3bf8f6066aa7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DevelopmentBonus_Index), @"mvc.1.0.view", @"/Views/DevelopmentBonus/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/DevelopmentBonus/Index.cshtml", typeof(AspNetCore.Views_DevelopmentBonus_Index))]
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
#line 1 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
using DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa904a0d41d80db50c38ad7fd8da3bf8f6066aa7", @"/Views/DevelopmentBonus/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b4f9f7d0ad6169b0d02079f8a353bf4ccfe20a", @"/Views/_ViewImports.cshtml")]
    public class Views_DevelopmentBonus_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DevelopmentBonusViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("qFrom"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/lib/jquery.form.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/DevelopmentBonus.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("names", "Development", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/lib/jquery.form.min.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("names", "Staging,Production", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
  
    ViewData["Title"] = "發展獎金設定";

#line default
#line hidden
#line 6 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
 if (ViewBag.HavePrivilege == true)
{
    // 6.系統在View【DevelopmentBonus/Index】判斷ViewBag.HavePrivilege=true。

#line default
#line hidden
            BeginContext(211, 68, true);
            WriteLiteral("    <div class=\"page-header\">\r\n        <h2>發展獎金設定</h2>\r\n    </div>\r\n");
            EndContext();
#line 12 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
    // 6.系統在View【DevelopmentBonus/Index】判斷ViewBag.HavePrivilege=true。

#line default
#line hidden
            BeginContext(350, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(354, 1358, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31d1a3a6a34f4ad7af2837af75b4fe71", async() => {
                BeginContext(384, 41, true);
                WriteLiteral("\r\n        <div class=\"form-horizontal\">\r\n");
                EndContext();
#line 15 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
             foreach (DevelopmentBonusViewModel item in Model)
            {

#line default
#line hidden
                BeginContext(504, 109, true);
                WriteLiteral("                <div class=\"form-group row\">\r\n                    <label class=\"col-xs-2 control-label left\">");
                EndContext();
                BeginContext(614, 13, false);
#line 18 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
                                                          Write(item.Operator);

#line default
#line hidden
                EndContext();
                BeginContext(627, 58, true);
                WriteLiteral("</label>\r\n                    <div class=\"col-xs-2\"><input");
                EndContext();
                BeginWriteAttribute("id", " id=\"", 685, "\"", 714, 1);
#line 19 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
WriteAttributeValue("", 690, item.DevelopmentBonusId, 690, 24, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(715, 12, true);
                WriteLiteral(" type=\"text\"");
                EndContext();
                BeginWriteAttribute("name", " name=\"", 727, "\"", 758, 1);
#line 19 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
WriteAttributeValue("", 734, item.DevelopmentBonusId, 734, 24, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(759, 32, true);
                WriteLiteral(" class=\"form-control BonusLimit\"");
                EndContext();
                BeginWriteAttribute("value", " value=\'", 791, "\'", 826, 1);
#line 19 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
WriteAttributeValue("", 799, item.DevelopmentBonusLimit, 799, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(827, 11, true);
                WriteLiteral(" /></div>\r\n");
                EndContext();
#line 20 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
                     if (item.All == 0)
                    {

#line default
#line hidden
                BeginContext(902, 79, true);
                WriteLiteral("                        <label class=\"col-xs-2 control-label left\">全部</label>\r\n");
                EndContext();
#line 23 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
                BeginContext(1053, 80, true);
                WriteLiteral("                        <label class=\"col-xs-2 control-label left\">每個人</label>\r\n");
                EndContext();
#line 27 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
                    }

#line default
#line hidden
                BeginContext(1156, 48, true);
                WriteLiteral("                    <div class=\"col-xs-2\"><input");
                EndContext();
                BeginWriteAttribute("id", " id=\"", 1204, "\"", 1233, 1);
#line 28 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
WriteAttributeValue("", 1209, item.DevelopmentBonusId, 1209, 24, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1234, 12, true);
                WriteLiteral(" type=\"text\"");
                EndContext();
                BeginWriteAttribute("name", " name=\"", 1246, "\"", 1277, 1);
#line 28 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
WriteAttributeValue("", 1253, item.DevelopmentBonusId, 1253, 24, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1278, 32, true);
                WriteLiteral(" class=\"form-control BonusValue\"");
                EndContext();
                BeginWriteAttribute("value", " value=\'", 1310, "\'", 1345, 1);
#line 28 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
WriteAttributeValue("", 1318, item.DevelopmentBonusValue, 1318, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1346, 35, true);
                WriteLiteral(" /></div>\r\n                </div>\r\n");
                EndContext();
#line 30 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
            }

#line default
#line hidden
                BeginContext(1396, 309, true);
                WriteLiteral(@"            <hr />
            <div class=""form-group row"">
                <div class=""col-xs-2""></div>
                <div class=""col-xs-2"">
                    <button type=""submit"" class=""btn btn-default"" id=""btnReset"">重設發展獎金</button>
                </div>
            </div>
        </div>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1712, 14, true);
            WriteLiteral("\r\n    <hr />\r\n");
            EndContext();
#line 41 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
    // 8.系統在查詢元件下方安置<Div DevelopmentBonusList>以便用來顯示發展獎金設定查詢結果清單。
    

#line default
#line hidden
            DefineSection("scripts", async() => {
                BeginContext(1814, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(1824, 229, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f677755b68274ebbafc04fa7cfacedea", async() => {
                    BeginContext(1857, 14, true);
                    WriteLiteral("\r\n            ");
                    EndContext();
                    BeginContext(1871, 70, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c9a568ba49f48c48b841c38b4ac761a", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_2.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#line 44 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(1941, 14, true);
                    WriteLiteral("\r\n            ");
                    EndContext();
                    BeginContext(1955, 74, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4690b81cd45a463f953466b3abcb20ba", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_3.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#line 45 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(2029, 10, true);
                    WriteLiteral("\r\n        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Names = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2053, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(2063, 240, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d4714ab12ff4d27b0e60937034301a6", async() => {
                    BeginContext(2103, 14, true);
                    WriteLiteral("\r\n            ");
                    EndContext();
                    BeginContext(2117, 74, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a244967df2834914a5cf26b2c530e14a", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_5.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
#line 48 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(2191, 14, true);
                    WriteLiteral("\r\n            ");
                    EndContext();
                    BeginContext(2205, 74, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27600ac10e2140e0a862e33807e96311", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_3.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#line 49 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(2279, 10, true);
                    WriteLiteral("\r\n        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Names = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2303, 144, true);
                WriteLiteral("\r\n        <script>\r\n\r\n            $(function () {\r\n                DevelopmentBonusfunction({\r\n                    GetDevelopmentBonusListUrl: \'");
                EndContext();
                BeginContext(2448, 57, false);
#line 55 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
                                            Write(Url.Action("GetDevelopmentBonusList", "DevelopmentBonus"));

#line default
#line hidden
                EndContext();
                BeginContext(2505, 49, true);
                WriteLiteral("\',\r\n                    PutDevelopmentBonusUrl: \'");
                EndContext();
                BeginContext(2555, 53, false);
#line 56 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
                                        Write(Url.Action("PutDevelopmentBonus", "DevelopmentBonus"));

#line default
#line hidden
                EndContext();
                BeginContext(2608, 64, true);
                WriteLiteral("\'\r\n                });\r\n            });\r\n        </script>\r\n    ");
                EndContext();
            }
            );
#line 60 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
     
}
else
{
    // 6a.系統在View【DevelopmentBonus/Index】判斷ViewBag.HavePrivilege=false。
    //  6a-1.系統顯示"無此權限"。

#line default
#line hidden
            BeginContext(2786, 66, true);
            WriteLiteral("    <div class=\"page-header\">\r\n        <h2>無此權限</h2>\r\n    </div>\r\n");
            EndContext();
#line 69 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\DevelopmentBonus\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DevelopmentBonusViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
