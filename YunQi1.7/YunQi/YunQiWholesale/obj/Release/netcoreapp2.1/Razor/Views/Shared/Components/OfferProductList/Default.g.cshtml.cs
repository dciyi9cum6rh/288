#pragma checksum "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\OfferProductList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3adfb88e48d80928369dbc8f4020d82eb74e3d0f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_OfferProductList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/OfferProductList/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/OfferProductList/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_OfferProductList_Default))]
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
#line 1 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\OfferProductList\Default.cshtml"
using DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3adfb88e48d80928369dbc8f4020d82eb74e3d0f", @"/Views/Shared/Components/OfferProductList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28caaf0241098ecd91020ca85cf41e4615f1e192", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_OfferProductList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductListManageViewModel>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\OfferProductList\Default.cshtml"
  
    string tmp = Model.ProductCategory;

#line default
#line hidden
            BeginContext(231, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\OfferProductList\Default.cshtml"
 if (Model.listProductListViewModel != null && Model.listProductListViewModel.Count > 0)
{
    

#line default
#line hidden
            BeginContext(415, 289, true);
            WriteLiteral(@"    <div class=""productsearch-box row"">
        <div class=""formobile col-12 col-sm-12 col-md-12 mb-3"">
            <button id=""mobileSide"" type=""button"" class=""btn btn-maintype"">分類</button>
        </div>
        <div class=""col-12 col-sm-12 col-md-4 col-lg-3 col-xl-3"">
            ");
            EndContext();
            BeginContext(704, 310, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7f103e1bd31d4cd1888b3a1a9dc1fac1", async() => {
                BeginContext(710, 297, true);
                WriteLiteral(@"
                <div class=""input-group"">
                    <span class=""input-group-addon"" style=""color:green;"" id=""spanProductCategory""></span>
                    <input id=""Product"" type=""text"" class=""form-control"" name=""Product"" placeholder=""商品名稱"">
                </div>
            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1014, 676, true);
            WriteLiteral(@"
        </div>
        <div class=""col-5 col-sm-5 col-md-2 col-lg-3 col-xl-3"">
            <input id=""lowPrice"" type=""text"" placeholder=""最低價"" class=""form-control"" name=""lowPrice"" />
        </div>
        <div class=""flexcenter col-2 col-sm-2 col-md-1 col-lg-1 col-xl-1"">~</div>
        <div class=""col-5 col-sm-5 col-md-2 col-lg-3 col-xl-3"">
            <input id=""hightPrice"" type=""text"" placeholder=""最高價"" class=""form-control"" name=""hightPrice"" />
        </div>
        <div class=""col-12 col-sm-12 col-md-2 col-lg-2 col-xl-2"">
            <button type=""button"" class=""btn btn-block btn-maintype"" id=""btnSerachProduct"">搜尋商品</button>
        </div>
    </div>
");
            EndContext();
            BeginContext(1773, 359, true);
            WriteLiteral(@"    <div class=""pagination-box row justify-content-between"">
        <div class=""col-12 col-sm-12 col-md-12 col-lg-5 col-xl-5"">
            <div class=""row mb-3"">
                <div class=""col-8 col-sm-8 col-md-9 col-lg-9 col-xl-9"">
                    <div class=""row"">
                        <div class=""col-3 col-sm-3 col-md-3 col-lg-3 col-xl-4"">
");
            EndContext();
            BeginContext(2282, 222, true);
            WriteLiteral("                        </div>\r\n                        <div class=\"pagination flexcenter col-6 col-sm-6 col-md-6 col-lg-6 col-xl-4\"></div>\r\n                        <div class=\"col-3 col-sm-3 col-md-3 col-lg-3 col-xl-4\">\r\n");
            EndContext();
            BeginContext(2656, 201, true);
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-4 col-sm-4 col-md-3 col-lg-3 col-xl-3\">\r\n                    <div class=\"dropdown\">\r\n");
            EndContext();
            BeginContext(3444, 653, true);
            WriteLiteral(@"                    </div>
                </div>
            </div>
        </div>
        <div class=""col-12 col-sm-12 col-md-12 col-lg-5 col-xl-5"">
            <div class=""row"">
                <div class=""col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6"">
                    <button type=""button"" class=""btn btn-block btn-maintype"" id=""btnOfferProduct"">優惠商品</button>
                </div>
                <div class=""col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6"">
                    <button type=""button"" class=""btn btn-block btn-maintype"" id=""btnAllProduct"">所有商品</button>
                </div>
            </div>
        </div>
    </div>
");
            EndContext();
            BeginContext(4180, 72, true);
            WriteLiteral("    <div class=\"productlist-box container\">\r\n        <div class=\"row\">\r\n");
            EndContext();
#line 76 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\OfferProductList\Default.cshtml"
             foreach (var item in Model.listProductListViewModel)
            {

#line default
#line hidden
            BeginContext(4425, 114, true);
            WriteLiteral("                <div class=\"productlist-item col-6 col-sm-6 col-md-6 col-lg-3 col-xl-3\">\r\n                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 4539, "\"", 4619, 1);
#line 79 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\OfferProductList\Default.cshtml"
WriteAttributeValue("", 4545, Url.Action("GetProductImage", "Mall", new { ProeuctId = item.ProductId }), 4545, 74, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 4620, "\"", 4639, 1);
#line 79 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\OfferProductList\Default.cshtml"
WriteAttributeValue("", 4626, item.Product, 4626, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4640, 37, true);
            WriteLiteral(" class=\"product-pic\" data-productid=\"");
            EndContext();
            BeginContext(4678, 14, false);
#line 79 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\OfferProductList\Default.cshtml"
                                                                                                                                                             Write(item.ProductId);

#line default
#line hidden
            EndContext();
            BeginContext(4692, 53, true);
            WriteLiteral("\" />\r\n                    <div class=\"producty-name\">");
            EndContext();
            BeginContext(4746, 12, false);
#line 80 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\OfferProductList\Default.cshtml"
                                          Write(item.Product);

#line default
#line hidden
            EndContext();
            BeginContext(4758, 61, true);
            WriteLiteral("</div>\r\n                    <div class=\"product-pricing\">零售價：");
            EndContext();
            BeginContext(4821, 21, false);
#line 81 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\OfferProductList\Default.cshtml"
                                                 Write($"{item.Price:#,###}");

#line default
#line hidden
            EndContext();
            BeginContext(4843, 60, true);
            WriteLiteral("元</div>\r\n                    <div class=\"product-upset\">批發價：");
            EndContext();
            BeginContext(4905, 30, false);
#line 82 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\OfferProductList\Default.cshtml"
                                               Write($"{item.SaleLimitPrice:#,###}");

#line default
#line hidden
            EndContext();
            BeginContext(4936, 62, true);
            WriteLiteral("元</div>\r\n                    <div class=\"product-special\">量批價：");
            EndContext();
            BeginContext(5000, 26, false);
#line 83 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\OfferProductList\Default.cshtml"
                                                 Write($"{item.OfferPrice:#,###}");

#line default
#line hidden
            EndContext();
            BeginContext(5027, 695, true);
            WriteLiteral(@"元</div>
                    <div class=""function-box container"">
                        <div class=""row"">
                            <div class=""col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6"">
                                <button type=""button"" class=""btn btn-block btn-maintype""><i class=""fas fa-cart-plus""></i></button>
                            </div>
                            <div class=""col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6"">
                                <button type=""button"" class=""btn btn-block btn-maintype""><i class=""fas fa-star""></i></button>
                            </div>
                        </div>
                    </div>
                </div>
");
            EndContext();
#line 95 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\OfferProductList\Default.cshtml"
            }

#line default
#line hidden
            BeginContext(5737, 28, true);
            WriteLiteral("        </div>\r\n    </div>\r\n");
            EndContext();
            BeginContext(5781, 81, true);
            WriteLiteral("    <div id=\"productDetail\" class=\"productdetail-box bg-light p-3\">\r\n    </div>\r\n");
            EndContext();
#line 101 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\OfferProductList\Default.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(5874, 115, true);
            WriteLiteral("    <h3>沒有商品</h3>\r\n    <button id=\"mobileSide\" type=\"button\" class=\"btn btn-maintype mb-2 mobiletype\">選單</button>\r\n");
            EndContext();
#line 106 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\OfferProductList\Default.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductListManageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
