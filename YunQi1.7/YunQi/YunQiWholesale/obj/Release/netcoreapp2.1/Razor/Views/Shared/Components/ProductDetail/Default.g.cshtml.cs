#pragma checksum "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c04759115d4273e32c802e2cee99682e517848a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ProductDetail_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ProductDetail/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/ProductDetail/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_ProductDetail_Default))]
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
#line 1 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
using DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c04759115d4273e32c802e2cee99682e517848a7", @"/Views/Shared/Components/ProductDetail/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28caaf0241098ecd91020ca85cf41e4615f1e192", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ProductDetail_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductDetailMallViewModel>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
  
    int stock = 0;
    if (@Model.ProductStock != null)
    {
        stock = Model.ProductStock.Stock;
    }

#line default
#line hidden
            BeginContext(175, 293, true);
            WriteLiteral(@"<button id=""btnProductDetailClose"" type=""button"" class=""btn btn-close btn-maintype"">關閉</button>
<div class=""set-box"">
    <div class=""detail-box container"">
        <div class=""row"">
            <div class=""detailpic-box col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">
                <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 468, "\"", 557, 1);
#line 15 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
WriteAttributeValue("", 474, Url.Action("GetProductImage", "Mall", new { ProeuctId = Model.Product.ProductId }), 474, 83, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(558, 413, true);
            WriteLiteral(@" alt="""" class=""detail-pic"" />
            </div>
            <div class=""detailinfo-box col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">
                <div class=""detailinfo-item row pt-1 pb-1"">
                    <div class=""detailinfo-title col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">品名</div>
                    <div class=""detailinfo-value col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"" id=""productD"">");
            EndContext();
            BeginContext(972, 21, false);
#line 20 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
                                                                                                        Write(Model.Product.Product);

#line default
#line hidden
            EndContext();
            BeginContext(993, 306, true);
            WriteLiteral(@"</div>
                </div>
                <div class=""detailinfo-item row pt-1 pb-1"">
                    <div class=""detailinfo-title col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">零售價</div>
                    <div class=""detailinfo-value col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"" id=""priceD"">");
            EndContext();
            BeginContext(1300, 19, false);
#line 24 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
                                                                                                      Write(Model.Product.Price);

#line default
#line hidden
            EndContext();
            BeginContext(1319, 32, true);
            WriteLiteral("</div>\r\n                </div>\r\n");
            EndContext();
#line 26 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
                 if (Model.MemberLevelId < 3)
                {

#line default
#line hidden
            BeginContext(1417, 700, true);
            WriteLiteral(@"                    <div class=""detailinfo-item row pt-1 pb-1"">
                        <div class=""detailinfo-title col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">批發價</div>
                        <div class=""detailinfo-value col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8""><a href=""#"" class=""joinus-link"">加入我們</a></div>
                    </div>
                    <div class=""detailinfo-item row pt-1 pb-1"">
                        <div class=""detailinfo-title col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">量批價</div>
                        <div class=""detailinfo-value col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8""><a href=""#"" class=""joinus-link"">加入我們</a></div>
                    </div>
");
            EndContext();
#line 36 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"

                }
                else
                {

#line default
#line hidden
            BeginContext(2179, 274, true);
            WriteLiteral(@"                    <div class=""detailinfo-item row pt-1 pb-1"">
                        <div class=""detailinfo-title col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">批發價</div>
                        <div class=""detailinfo-value col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">");
            EndContext();
            BeginContext(2454, 28, false);
#line 42 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
                                                                                              Write(Model.Product.SaleLimitPrice);

#line default
#line hidden
            EndContext();
            BeginContext(2482, 310, true);
            WriteLiteral(@"</div>
                    </div>
                    <div class=""detailinfo-item row pt-1 pb-1"">
                        <div class=""detailinfo-title col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">量批價</div>
                        <div class=""detailinfo-value col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">");
            EndContext();
            BeginContext(2793, 24, false);
#line 46 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
                                                                                              Write(Model.Product.OfferPrice);

#line default
#line hidden
            EndContext();
            BeginContext(2817, 36, true);
            WriteLiteral("</div>\r\n                    </div>\r\n");
            EndContext();
#line 48 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"

                }

#line default
#line hidden
            BeginContext(2874, 1055, true);
            WriteLiteral(@"                <div class=""detailinfo-item row"" id=""product-item"">
                    <div class=""responsive col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"">
                        <div class=""accordion"" id=""accordionChoose"">
                            <div class=""card border"">
                                <div class=""card-header"" id=""headingOne"">
                                    <div class=""row"">
                                        <div class=""border border-dark col-12 col-sm-4 col-md-4 col-lg-4 col-xl-3 d-flex align-items-center pt-2 pb-2"">
                                            <div class=""container"">
                                                <div class=""row"">
                                                    <label class=""col-5 col-sm-5 col-md-12 col-lg-12 col-xl-12 col-form-label"">尺寸</label>
                                                    <div class=""col-7 col-sm-7 col-md-12 col-lg-12 col-xl-12"">
                                                        <select id=");
            WriteLiteral("\"sizeD\" class=\"form-control\">\r\n");
            EndContext();
#line 62 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
                                                             foreach (var item in Model.ProductSize)
                                                            {

#line default
#line hidden
            BeginContext(4094, 64, true);
            WriteLiteral("                                                                ");
            EndContext();
            BeginContext(4158, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "713a9ffe504a4f32aa590cfc548cd67c", async() => {
                BeginContext(4194, 16, false);
#line 64 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
                                                                                              Write(item.ProductSize);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 64 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
                                                                   WriteLiteral(item.ProducSizeId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4219, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 65 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
                                                            }

#line default
#line hidden
            BeginContext(4284, 922, true);
            WriteLiteral(@"                                                        </select>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class=""border border-dark col-12 col-sm-4 col-md-4 col-lg-4 col-xl-3 d-flex align-items-center pt-2 pb-2"">
                                            <div class=""container"">
                                                <div class=""row"">
                                                    <label class=""col-5 col-sm-5 col-md-12 col-lg-12 col-xl-12 col-form-label"">顏色</label>
                                                    <div class=""col-7 col-sm-7 col-md-12 col-lg-12 col-xl-12"">
                                                        <select id=""colorD"" class=""form-control"">
");
            EndContext();
#line 77 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
                                                             foreach (var item in Model.ProductColor)
                                                            {

#line default
#line hidden
            BeginContext(5372, 64, true);
            WriteLiteral("                                                                ");
            EndContext();
            BeginContext(5436, 64, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c86ed10b1844c208e78f994c88407db", async() => {
                BeginContext(5474, 17, false);
#line 79 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
                                                                                                Write(item.ProductColor);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 79 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
                                                                   WriteLiteral(item.ProductColorId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5500, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 80 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
                                                            }

#line default
#line hidden
            BeginContext(5565, 720, true);
            WriteLiteral(@"                                                        </select>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class=""border border-dark col-12 col-sm-4 col-md-4 col-lg-4 col-xl-3 d-flex align-items-center pt-2 pb-2"">
                                            <div class=""container"">
                                                <div class=""row"">
                                                    <label class=""col-6 col-sm-6 col-md-12 col-lg-12 col-xl-12 col-form-label"" id=""lblQuantityD"">數量(");
            EndContext();
            BeginContext(6286, 5, false);
#line 89 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
                                                                                                                                               Write(stock);

#line default
#line hidden
            EndContext();
            BeginContext(6291, 2365, true);
            WriteLiteral(@")</label>
                                                    <div class=""col-6 col-sm-6 col-md-12 col-lg-12 col-xl-12"">
                                                        <input id=""quantityD"" type=""text"" class=""form-control"" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class=""border border-dark col-12 col-sm-12 col-md-12 col-lg-12 col-xl-3 pt-2 pb-2"">
                                            <div class=""container"">
                                                <div class=""row  justify-content-between"">
                                                    <div class=""col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6 pt-1 pb-1"">
                                                        <button class=""btn btn-maintype"" type=""button"" data-toggle=""collapse"" data-target=""#collapseChoose"" aria");
            WriteLiteral(@"-expanded=""true"" aria-controls=""collapseChoose"">展開</button>
                                                    </div>
                                                    <div class=""col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6 pt-1 pb-1"">
                                                        <button type=""button"" class=""btn btn-addcart btn-maintype"" id=""btnAddQuantity"">新增</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id=""collapseChoose"" class=""collapse show"" aria-labelledby=""headingOne"" data-parent=""#accordionChoose"">
                                    <div class=""card-body"">
                                    </div>
                                </div>
                            </div>
              ");
            WriteLiteral(@"          </div>
                    </div>
                </div>
                <div class=""detailinfo-item row"" id=""divmyfavorite"">
                    <div class=""col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6"">
                        <button type=""button"" class=""btn btn-favorite btn-maintype"" data-productid=""");
            EndContext();
            BeginContext(8657, 23, false);
#line 120 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
                                                                                               Write(Model.Product.ProductId);

#line default
#line hidden
            EndContext();
            BeginContext(8680, 414, true);
            WriteLiteral(@"""><i class=""fas fa-star""></i>儲存至我的最愛</button>
                    </div>
                    <div class=""col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6"">
                        <button type=""button"" class=""btn btn-addcart btn-maintype""><i class=""fas fa-cart-plus""></i>前往購物車</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""morepic-box"">
");
            EndContext();
#line 130 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
         foreach (var item in Model.ProductImage)
        {

#line default
#line hidden
            BeginContext(9156, 65, true);
            WriteLiteral("            <div class=\"morepic-item mb-3\">\r\n                <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 9221, "\"", 9340, 1);
#line 133 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
WriteAttributeValue("", 9227, Url.Action("GetOneProductImage", "Mall", new { ProeuctId = item.ProductId, ProductImageId= item.ProductImageId}), 9227, 113, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(9341, 52, true);
            WriteLiteral(" alt=\"\" class=\"morepic-pic\" />\r\n            </div>\r\n");
            EndContext();
#line 135 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
        }

#line default
#line hidden
            BeginContext(9404, 56, true);
            WriteLiteral("    </div>\r\n</div>\r\n<script>\r\n    jQuantity = parseInt(\'");
            EndContext();
            BeginContext(9461, 5, false);
#line 139 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductDetail\Default.cshtml"
                     Write(stock);

#line default
#line hidden
            EndContext();
            BeginContext(9466, 16, true);
            WriteLiteral("\');\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductDetailMallViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
