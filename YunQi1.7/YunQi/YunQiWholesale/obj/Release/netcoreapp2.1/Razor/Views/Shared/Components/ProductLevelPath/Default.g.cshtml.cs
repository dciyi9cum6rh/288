#pragma checksum "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductLevelPath\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b9e235ffea6d22e22748e7da3b5b7289a0e98034"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ProductLevelPath_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ProductLevelPath/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/ProductLevelPath/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_ProductLevelPath_Default))]
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
#line 1 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductLevelPath\Default.cshtml"
using DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9e235ffea6d22e22748e7da3b5b7289a0e98034", @"/Views/Shared/Components/ProductLevelPath/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28caaf0241098ecd91020ca85cf41e4615f1e192", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ProductLevelPath_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductCategoryLevelViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(151, 759, true);
            WriteLiteral(@"
<div class=""container mb-3"">
    <button id=""btnAlltypeClose"" type=""button"" class=""btn btn-close btn-maintype mobiletype"">關閉</button>
    <button type=""button"" class=""btn btn-subcategory"" id=""btnSubCategory"" title=""點按分類後再點按我切換顥示子分類"">子分類</button>
</div>
<div class=""searchtype-box form-group container mb-3"">
    <div class=""row"">
        <div class=""col-12 col-sm-12 col-md-12 col-lg-7 col-xl-7"">
            <input id=""ProductCategory"" type=""text"" placeholder=""分類名稱"" class=""form-control"" />
        </div>
        <div class=""col-12 col-sm-12 col-md-12 col-lg-5 col-xl-5"">
            <button type=""button"" class=""btn btn-block btn-maintype"" id=""btnSeatchProductCategory"">搜尋</button>
        </div>
    </div>
</div>
<div class=""container"">
");
            EndContext();
            BeginContext(930, 185, true);
            WriteLiteral("    <div class=\"row mb-3\">\r\n        <nav class=\"col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12\" aria-label=\"breadcrumb\">\r\n            <ol class=\"breadcrumb\" id=\"ProductCategoryLevel\">\r\n");
            EndContext();
#line 23 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductLevelPath\Default.cshtml"
                 for (int i = Model.ProductLevelPath.Count() - 1; i >= 0; i--)
                {

#line default
#line hidden
            BeginContext(1214, 175, true);
            WriteLiteral("                    <li class=\"breadcrumb-item\">\r\n                        <a title=\"單按顥示子分類與商品！\" href=\"#\" class=\"btn btn-alltype ProductLevelPathList\" data-productcategoryid=\"");
            EndContext();
            BeginContext(1390, 43, false);
#line 26 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductLevelPath\Default.cshtml"
                                                                                                                        Write(Model.ProductLevelPath[i].ProductCategoryId);

#line default
#line hidden
            EndContext();
            BeginContext(1433, 2, true);
            WriteLiteral("\">");
            EndContext();
            BeginContext(1436, 41, false);
#line 26 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductLevelPath\Default.cshtml"
                                                                                                                                                                      Write(Model.ProductLevelPath[i].ProductCategory);

#line default
#line hidden
            EndContext();
            BeginContext(1477, 33, true);
            WriteLiteral("</a>\r\n                    </li>\r\n");
            EndContext();
#line 28 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductLevelPath\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(1529, 47, true);
            WriteLiteral("            </ol>\r\n        </nav>\r\n    </div>\r\n");
            EndContext();
            BeginContext(1593, 151, true);
            WriteLiteral("    <div class=\"row mb-3\" id=\"ProductCategoryList\">\r\n        <ul class=\"nav subtype-list flex-column col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12\">\r\n");
            EndContext();
#line 35 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductLevelPath\Default.cshtml"
             foreach (var item in Model.ProductCategory)
            {

#line default
#line hidden
            BeginContext(1817, 150, true);
            WriteLiteral("                <li class=\"nav-item\">\r\n                    <a title=\"單按顥示商品，雙按顥示子分類與商品！\" class=\"nav-link text-white\" href=\"#\" data-productcategoryid=\"");
            EndContext();
            BeginContext(1968, 22, false);
#line 38 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductLevelPath\Default.cshtml"
                                                                                                          Write(item.ProductCategoryId);

#line default
#line hidden
            EndContext();
            BeginContext(1990, 2, true);
            WriteLiteral("\">");
            EndContext();
            BeginContext(1993, 20, false);
#line 38 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductLevelPath\Default.cshtml"
                                                                                                                                   Write(item.ProductCategory);

#line default
#line hidden
            EndContext();
            BeginContext(2013, 29, true);
            WriteLiteral("</a>\r\n                </li>\r\n");
            EndContext();
#line 40 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\ProductLevelPath\Default.cshtml"
            }

#line default
#line hidden
            BeginContext(2057, 35, true);
            WriteLiteral("        </ul>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductCategoryLevelViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
