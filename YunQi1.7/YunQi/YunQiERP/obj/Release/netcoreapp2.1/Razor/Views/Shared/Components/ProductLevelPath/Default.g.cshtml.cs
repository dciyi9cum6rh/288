#pragma checksum "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\ProductLevelPath\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9be1d2faa20d3255251e4a56a7680082f104a50f"
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
#line 1 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\_ViewImports.cshtml"
using YunQiERP;

#line default
#line hidden
#line 2 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\_ViewImports.cshtml"
using YunQiERP.Models;

#line default
#line hidden
#line 1 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\ProductLevelPath\Default.cshtml"
using DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9be1d2faa20d3255251e4a56a7680082f104a50f", @"/Views/Shared/Components/ProductLevelPath/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b4f9f7d0ad6169b0d02079f8a353bf4ccfe20a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ProductLevelPath_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProductLevelPathViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(145, 56, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n    <ol class=\"breadcrumb\">\r\n");
            EndContext();
#line 6 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\ProductLevelPath\Default.cshtml"
         for (int i = Model.Count() - 1; i >= 0; i--)
        {

#line default
#line hidden
            BeginContext(267, 56, true);
            WriteLiteral("            <li><a href=\"#\" class=\"ProductLevelPathList\"");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 323, "\"", 358, 1);
#line 8 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\ProductLevelPath\Default.cshtml"
WriteAttributeValue("", 331, Model[i].ProductCategoryId, 331, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(359, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(361, 24, false);
#line 8 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\ProductLevelPath\Default.cshtml"
                                                                                        Write(Model[i].ProductCategory);

#line default
#line hidden
            EndContext();
            BeginContext(385, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 9 "D:\lab\288\YunQi1.7\YunQi\YunQiERP\Views\Shared\Components\ProductLevelPath\Default.cshtml"
        }

#line default
#line hidden
            BeginContext(407, 17, true);
            WriteLiteral("    </ol>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProductLevelPathViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
