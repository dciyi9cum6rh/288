#pragma checksum "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32621dac9ad24b4d1a0db536dfdc27b02922ee9c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Followertriumph_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Followertriumph/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Followertriumph/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Followertriumph_Default))]
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
#line 1 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\_ViewImports.cshtml"
using YunQiWholesale;

#line default
#line hidden
#line 2 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\_ViewImports.cshtml"
using YunQiWholesale.Models;

#line default
#line hidden
#line 3 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
using DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32621dac9ad24b4d1a0db536dfdc27b02922ee9c", @"/Views/Shared/Components/Followertriumph/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28caaf0241098ecd91020ca85cf41e4615f1e192", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Followertriumph_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FollowertriumphManageViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(17, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(85, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
 if (@Model.listFollowertriumphViewModel != null && @Model.listFollowertriumphViewModel.Count > 0)
{

#line default
#line hidden
            BeginContext(190, 1254, true);
            WriteLiteral(@"    <div class=""followertriumph-component"">
        <div class=""container"">
            <div class=""title-box border-bottom d-flex align-items-center mb-3"">
                <h2 class=""mr-3"">我的下線業績</h2>
                <button id=""mobileSide"" type=""button"" class=""btn btn-maintype mb-2 mobiletype"">選單</button>
            </div>
            <div class=""search-box row mb-3"">
                <div class=""col-12 col-sm-12 col-md-12 col-lg-4 col-xl-3"">
                    <input id=""MemberMobileWhere"" type=""text"" placeholder=""下線手機"" class=""form-control"" />
                </div>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-4 col-xl-3"">
                    <input id=""sDateO"" type=""text"" placeholder=""日期"" class=""form-control"" value="""" />
                </div>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-4 col-xl-3"">
                    <button type=""button"" class=""btn btn-block btn-maintype"" id=""btnSerrchFollowertriumph"">搜尋</button>
                </div>
            </d");
            WriteLiteral("iv>\r\n            <div class=\"detail-box row mb-3\">\r\n                <div class=\"col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4 pt-1 pb-1\">\r\n                    <div id=\"FollowertriumphTotal\" class=\"d-flex align-items-center\">下線批發總額：");
            EndContext();
            BeginContext(1445, 33, false);
#line 29 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                                                                                       Write(Model.FollowertriumphTotall.Total);

#line default
#line hidden
            EndContext();
            BeginContext(1478, 205, true);
            WriteLiteral(" 元</div>\r\n                </div>\r\n                <div class=\"col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4 pt-1 pb-1\">\r\n                    <div id=\"MemberTotall\" class=\"d-flex align-items-center\">我的批發總額： ");
            EndContext();
            BeginContext(1684, 24, false);
#line 32 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                                                                                Write(Model.MemberTotall.Total);

#line default
#line hidden
            EndContext();
            BeginContext(1708, 197, true);
            WriteLiteral(" 元</div>\r\n                </div>\r\n                <div class=\"col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4 pt-1 pb-1\">\r\n                    <div id=\"Bonus\" class=\"d-flex align-items-center\">我的營運獎金：");
            EndContext();
            BeginContext(1906, 11, false);
#line 35 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                                                                        Write(Model.Bonus);

#line default
#line hidden
            EndContext();
            BeginContext(1917, 10, true);
            WriteLiteral(" 元</div>\r\n");
            EndContext();
            BeginContext(2010, 581, true);
            WriteLiteral(@"                </div>
            </div>
            <div class=""pagination-box row mb-3"">
                <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">
                    <div class=""row"">
                        <div class=""col-3 col-sm-3 col-md-3 col-lg-3 col-xl-3"">
                            <button type=""button"" class=""btn btn-block btn-maintype"" id=""FollowertriumphPrePage""><i class=""fas fa-angle-left""></i></button>
                        </div>
                        <div class=""pagination flexcenter col-6 col-sm-6 col-md-6 col-lg-6 col-xl-4"">");
            EndContext();
            BeginContext(2592, 17, false);
#line 45 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                                                                                                Write(Model.CurrentPage);

#line default
#line hidden
            EndContext();
            BeginContext(2609, 1, true);
            WriteLiteral("/");
            EndContext();
            BeginContext(2611, 16, false);
#line 45 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                                                                                                                   Write(Model.TotalPages);

#line default
#line hidden
            EndContext();
            BeginContext(2627, 792, true);
            WriteLiteral(@"</div>
                        <div class=""col-3 col-sm-3 col-md-3 col-lg-3 col-xl-3"">
                            <button type=""button"" class=""btn btn-block btn-maintype"" id=""FollowertriumphNextPage""><i class=""fas fa-angle-right""></i></button>
                        </div>
                    </div>
                </div>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">
                    <div class=""dropdown"">
                        <button class=""btn btn-block dropdown-toggle btn-maintype"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">第1頁</button>
                        <div class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""dropdownMenuButton"" id=""FollowertriumphPageList"">
");
            EndContext();
#line 55 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                             for (int i = 1; i <= Model.TotalPages; i++)
                            {

#line default
#line hidden
            BeginContext(3524, 77, true);
            WriteLiteral("                                <a class=\"dropdown-item\" href=\"#\" data-page=\"");
            EndContext();
            BeginContext(3603, 1, false);
#line 57 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                                                                         Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(3605, 3, true);
            WriteLiteral("\">第");
            EndContext();
            BeginContext(3610, 1, false);
#line 57 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                                                                                Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(3612, 7, true);
            WriteLiteral("頁</a>\r\n");
            EndContext();
#line 58 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                            }

#line default
#line hidden
            BeginContext(3650, 147, true);
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"triumphlist-box\">\r\n");
            EndContext();
#line 64 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                 for (int i = 0; i < @Model.listFollowertriumphViewModel.Count; i += 2)
                {

#line default
#line hidden
            BeginContext(3905, 476, true);
            WriteLiteral(@"                    <div class=""row mb-3"">
                        <div class=""col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">
                            <div class=""card"">
                                <div class=""card-body"">
                                    <div class=""row"">
                                        <div class=""col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"">
                                            <div class=""d-flex align-items-center"">姓名：");
            EndContext();
            BeginContext(4382, 48, false);
#line 72 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                                                                                 Write(Model.listFollowertriumphViewModel[i].MemberName);

#line default
#line hidden
            EndContext();
            BeginContext(4430, 244, true);
            WriteLiteral("</div>\r\n                                        </div>\r\n                                        <div class=\"col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12\">\r\n                                            <div class=\"d-flex align-items-center\">手機：");
            EndContext();
            BeginContext(4675, 50, false);
#line 75 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                                                                                 Write(Model.listFollowertriumphViewModel[i].MemberMobile);

#line default
#line hidden
            EndContext();
            BeginContext(4725, 246, true);
            WriteLiteral("</div>\r\n                                        </div>\r\n                                        <div class=\"col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12\">\r\n                                            <div class=\"d-flex align-items-center\">訂購總額：");
            EndContext();
            BeginContext(4972, 43, false);
#line 78 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                                                                                   Write(Model.listFollowertriumphViewModel[i].Total);

#line default
#line hidden
            EndContext();
            BeginContext(5015, 208, true);
            WriteLiteral("</div>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
            EndContext();
#line 84 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                         if (i + 1 < Model.listFollowertriumphViewModel.Count)
                        {

#line default
#line hidden
            BeginContext(5330, 456, true);
            WriteLiteral(@"                            <div class=""col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">
                                <div class=""card"">
                                    <div class=""card-body"">
                                        <div class=""row"">
                                            <div class=""col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"">
                                                <div class=""d-flex align-items-center"">姓名：");
            EndContext();
            BeginContext(5787, 52, false);
#line 91 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                                                                                     Write(Model.listFollowertriumphViewModel[i + 1].MemberName);

#line default
#line hidden
            EndContext();
            BeginContext(5839, 256, true);
            WriteLiteral(@"</div>
                                            </div>
                                            <div class=""col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"">
                                                <div class=""d-flex align-items-center"">手機：");
            EndContext();
            BeginContext(6096, 54, false);
#line 94 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                                                                                     Write(Model.listFollowertriumphViewModel[i + 1].MemberMobile);

#line default
#line hidden
            EndContext();
            BeginContext(6150, 258, true);
            WriteLiteral(@"</div>
                                            </div>
                                            <div class=""col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"">
                                                <div class=""d-flex align-items-center"">訂購總額：");
            EndContext();
            BeginContext(6409, 47, false);
#line 97 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                                                                                       Write(Model.listFollowertriumphViewModel[i + 1].Total);

#line default
#line hidden
            EndContext();
            BeginContext(6456, 229, true);
            WriteLiteral(" </div>\r\n                                            </div>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
            EndContext();
#line 103 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                        }

#line default
#line hidden
            BeginContext(6712, 28, true);
            WriteLiteral("                    </div>\r\n");
            EndContext();
#line 105 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(6759, 48, true);
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 109 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(6819, 117, true);
            WriteLiteral("    <h3>沒有下線業績</h3>\r\n    <button id=\"mobileSide\" type=\"button\" class=\"btn btn-maintype mb-2 mobiletype\">選單</button>\r\n");
            EndContext();
#line 114 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
}

#line default
#line hidden
            BeginContext(6939, 156, true);
            WriteLiteral("\r\n<script>\r\n\r\n    $(document).ready(function () {\r\n        // 10.系統設定jCurrentPage=9-7回傳CurrentPage，系統設定jTotallPages=9-7回傳TotalPages。\r\n        jCurrentPage =");
            EndContext();
            BeginContext(7096, 17, false);
#line 120 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                 Write(Model.CurrentPage);

#line default
#line hidden
            EndContext();
            BeginContext(7113, 25, true);
            WriteLiteral(";\r\n        jTotallPages =");
            EndContext();
            BeginContext(7139, 16, false);
#line 121 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
                 Write(Model.TotalPages);

#line default
#line hidden
            EndContext();
            BeginContext(7155, 72, true);
            WriteLiteral(";\r\n\r\n        //Model.MemberTotall 當自己批發總額超過3000 將內容改為紅色 否則為綠色\r\n         ");
            EndContext();
            BeginContext(7228, 24, false);
#line 124 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
    Write(Model.MemberTotall.Total);

#line default
#line hidden
            EndContext();
            BeginContext(7252, 181, true);
            WriteLiteral(" >= 3000 ? ($(\"#MemberTotall\").css(\"color\", \"green\")) : ($(\"#MemberTotall\").css(\"color\", \"red\"));\r\n        //Model.FollowertriumphTotal 當我的下線批發總額超過3000 將\"我的營運獎金\"改為紅色 否則為綠色\r\n        ");
            EndContext();
            BeginContext(7434, 24, false);
#line 126 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Followertriumph\Default.cshtml"
   Write(Model.MemberTotall.Total);

#line default
#line hidden
            EndContext();
            BeginContext(7458, 106, true);
            WriteLiteral("  >= 3000 ? ($(\"#Bonus\").css(\"color\", \"green\")) : ($(\"#Bonus\").css(\"color\", \"red\"));\r\n    });\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FollowertriumphManageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
