#pragma checksum "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e61e5d406d8a1448b0756d4eecd00e4526d0c040"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OfferProduct_Index), @"mvc.1.0.view", @"/Views/OfferProduct/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/OfferProduct/Index.cshtml", typeof(AspNetCore.Views_OfferProduct_Index))]
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
#line 1 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml"
using DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e61e5d406d8a1448b0756d4eecd00e4526d0c040", @"/Views/OfferProduct/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b4f9f7d0ad6169b0d02079f8a353bf4ccfe20a", @"/Views/_ViewImports.cshtml")]
    public class Views_OfferProduct_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProductListViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("qFrom"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PostOfferProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "OfferProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("CreateForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PutOfferProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("EditForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery.form.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/OfferProduct.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml"
  
    ViewData["Title"] = "準批發會員優惠商品管理";

#line default
#line hidden
#line 6 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml"
 if (ViewBag.HavePrivilege == true)
{
    // 5-1.系統在View【OfferProduct/Index】判斷ViewBag.HavePrivilege=true。

#line default
#line hidden
            BeginContext(209, 77, true);
            WriteLiteral("    <div class=\"page-header\">\r\n        <h2>準批發會員優惠商品管理</h2>\r\n    </div>\r\n    ");
            EndContext();
            BeginContext(286, 133, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3d4340c793094bb98a28d8aa85cf0169", async() => {
                BeginContext(323, 89, true);
                WriteLiteral("\r\n        <button type=\"submit\" class=\"btn btn-default\" id=\"btnAdd\">新增優惠商品</button>\r\n    ");
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
            BeginContext(419, 14, true);
            WriteLiteral("\r\n    <hr />\r\n");
            EndContext();
#line 16 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml"
    // 6.系統在View【OfferProduct/Index】顯示準批發會員優惠商品清單。

#line default
#line hidden
            BeginContext(485, 522, true);
            WriteLiteral(@"    <div class=""container container-fluid"">
        <table class=""table table-bordered"">
            <thead>
                <tr style=""color:gainsboro;background-color:#000000"">
                    <th>商品代碼</th>
                    <th>商品名稱</th>
                    <th>商品圖示</th>
                    <th>商品說明</th>
                    <th>零售價</th>
                    <th>批發價</th>
                    <th>量批價</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 32 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml"
                 foreach (ProductListViewModel MLVM in Model)
                {

#line default
#line hidden
            BeginContext(1089, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(1144, 14, false);
#line 35 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml"
                       Write(MLVM.ProductId);

#line default
#line hidden
            EndContext();
            BeginContext(1158, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1194, 12, false);
#line 36 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml"
                       Write(MLVM.Product);

#line default
#line hidden
            EndContext();
            BeginContext(1206, 56, true);
            WriteLiteral("</td>\r\n                        <td class=\"item-pic\"><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1262, "\"", 1350, 1);
#line 37 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml"
WriteAttributeValue("", 1268, Url.Action("GetProductImage", "OfferProduct", new { ProeuctId = MLVM.ProductId }), 1268, 82, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1351, "\"", 1370, 1);
#line 37 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml"
WriteAttributeValue("", 1357, MLVM.Product, 1357, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1371, 103, true);
            WriteLiteral(" class=\"img-responsive\" style=\"max-width:200px;max-height:200px;\" /></td>\r\n                        <td>");
            EndContext();
            BeginContext(1475, 23, false);
#line 38 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml"
                       Write(MLVM.ProductDescription);

#line default
#line hidden
            EndContext();
            BeginContext(1498, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1534, 10, false);
#line 39 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml"
                       Write(MLVM.Price);

#line default
#line hidden
            EndContext();
            BeginContext(1544, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1580, 19, false);
#line 40 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml"
                       Write(MLVM.SaleLimitPrice);

#line default
#line hidden
            EndContext();
            BeginContext(1599, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1635, 15, false);
#line 41 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml"
                       Write(MLVM.OfferPrice);

#line default
#line hidden
            EndContext();
            BeginContext(1650, 37, true);
            WriteLiteral("</td>\r\n                        <td>\r\n");
            EndContext();
            BeginContext(1853, 252, true);
            WriteLiteral("                            <a class=\"btn btn-default btn-delete\" role=\"button\"><span class=\"glyphicon glyphicon-trash\" aria-hidden=\"true\" title=\"刪除\"></span></a>\r\n                        </td>\r\n                    </tr>\r\n                    <tr></tr>\r\n");
            EndContext();
#line 48 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(2124, 52, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
            EndContext();
#line 52 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml"

    //Model

#line default
#line hidden
            BeginContext(2191, 528, true);
            WriteLiteral(@"    <div id=""add-one"" class=""modal fade bs-example-modal-lg"" tabindex=""-1"" role=""dialog"">
        <div class=""modal-dialog modal-lg"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <button type=""button"" class=""close"" data-dismiss=""modal""><span aria-hidden=""true"">&times;</span><span class=""sr-only"">Close</span></button>
                    <h4 class=""modal-title"">新增/修改優惠商品</h4>
                </div>
                <div class=""modal-body"">
                    ");
            EndContext();
            BeginContext(2719, 1370, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f30761ba5687475f99ea5ff1612823f2", async() => {
                BeginContext(2845, 1237, true);
                WriteLiteral(@"
                        <div class=""form-horizontal"">
                            <div class=""form-group row"">
                                <label for=""ProductId"" class=""col-xs-2 control-label"">商品代碼</label>
                                <div class=""col-xs-4""><input type=""text"" name=""ProductId"" id=""ProductId"" class=""form-control"" /></div>
                                <label for=""Product"" class=""col-xs-2 control-label"">商品名稱</label>
                                <div class=""col-xs-4""><input type=""text"" name=""Product"" id=""Product"" class=""form-control"" /></div>
                            </div>
                            <div class=""form-group row"">
                                <label for="""" class=""col-xs-2 control-label""></label>
                                <div class=""col-xs-8"">
                                    <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">取消</button>
                                    <button type=""submit"" id=""CreateSubmit"" class=""btn btn");
                WriteLiteral("-primary\">新增</button>\r\n                                </div>\r\n                                <div class=\"col-xs-2\"></div>\r\n                            </div>\r\n                        </div>\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4089, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(4111, 1389, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e694d01635d748ebb238354afdccd039", async() => {
                BeginContext(4234, 1259, true);
                WriteLiteral(@"
                        <div class=""form-horizontal"">
                            <div class=""form-group row"">
                                <label for=""ProductIdEdit"" class=""col-xs-2 control-label"">商品代碼</label>
                                <div class=""col-xs-4""><input type=""text"" name=""ProductIdEdit"" id=""ProductIdEdit"" class=""form-control"" /></div>
                                <label for=""ProductEdit"" class=""col-xs-2 control-label"">商品名稱</label>
                                <div class=""col-xs-4""><input type=""text"" name=""ProductEdit"" id=""ProductEdit"" class=""form-control"" /></div>
                            </div>
                            <div class=""form-group row"">
                                <label for="""" class=""col-xs-2 control-label""></label>
                                <div class=""col-xs-8"">
                                    <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">取消</button>
                                    <button type=""submit"" id=""Edit");
                WriteLiteral("Submit\" class=\"btn btn-primary\">修改</button>\r\n                                </div>\r\n                                <div class=\"col-xs-2\"></div>\r\n                            </div>\r\n                        </div>\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5500, 74, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(5597, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(6080, 8, true);
                WriteLiteral("        ");
                EndContext();
                BeginContext(6088, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9643fa0a45e14193865b529c42ddbe5d", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(6132, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(6142, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7834d713f6654c43b3887e767b3d9d70", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(6186, 135, true);
                WriteLiteral("\r\n        <script>\r\n\r\n            $(function () {\r\n                OfferProductfunction({\r\n                    DeleteOfferProductUrl: \'");
                EndContext();
                BeginContext(6322, 48, false);
#line 118 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml"
                                       Write(Url.Action("DeleteOfferProduct", "OfferProduct"));

#line default
#line hidden
                EndContext();
                BeginContext(6370, 64, true);
                WriteLiteral("\'\r\n                });\r\n            });\r\n        </script>\r\n    ");
                EndContext();
            }
            );
#line 122 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml"
     
}
else
{
    // 5-1a.系統在View【Member/Index】判斷ViewBag.HavePrivilege=false。
    //  5-1a-1.系統顯示"無此權限"。

#line default
#line hidden
            BeginContext(6542, 66, true);
            WriteLiteral("    <div class=\"page-header\">\r\n        <h2>無此權限</h2>\r\n    </div>\r\n");
            EndContext();
#line 131 "D:\lab\YunQi1.7\YunQi\YunQiERP\Views\OfferProduct\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProductListViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
