#pragma checksum "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "577aa915764b24a2977360aba7b971bd5e016b89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Myfollower_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Myfollower/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Myfollower/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Myfollower_Default))]
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
#line 1 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
using DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"577aa915764b24a2977360aba7b971bd5e016b89", @"/Views/Shared/Components/Myfollower/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28caaf0241098ecd91020ca85cf41e4615f1e192", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Myfollower_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MyfollowerManageViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(69, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
 if (@Model.listMyfollowerViewModel != null && @Model.listMyfollowerViewModel.Count > 0)
{


#line default
#line hidden
            BeginContext(285, 1762, true);
            WriteLiteral(@"    <div class=""myfollower-component"">
        <div class=""container"">
            <div class=""title-box border-bottom d-flex align-items-center mb-3"">
                <h2 class=""mr-3"">我的下線</h2>
                <button id=""mobileSide"" type=""button"" class=""btn btn-maintype mb-2 mobiletype"">選單</button>
            </div>
            <div class=""search-box row mb-3"">
                <div class=""col-12 col-sm-12 col-md-12 col-lg-2 col-xl-2"">
                    <input id=""sDateO"" name=""sDateO"" type=""text"" placeholder=""VIP日(起)"" class=""form-control"" />
                </div>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-2 col-xl-2"">
                    <input id=""eDateO"" type=""text"" placeholder=""VIP日(迄)"" class=""form-control"" />
                </div>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-4 col-xl-2"">
                    <input id=""MemberMobileWhere"" type=""text"" placeholder=""下線手機(帳號)"" class=""form-control"" />
                </div>
                <div class=""co");
            WriteLiteral(@"l-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">
                    <button type=""button"" class=""btn btn-block btn-maintype"" id=""btnSerrchMyFollower"">搜尋</button>
                </div>
            </div>
            <div class=""pagination-box row mb-3"">
                <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">
                    <div class=""row"">
                        <div class=""col-3 col-sm-3 col-md-3 col-lg-3 col-xl-4"">
                            <button type=""button"" class=""btn btn-block btn-maintype"" id=""MyfollowerPrePageO""><i class=""fas fa-angle-left""></i></button>
                        </div>
                        <div class=""pagination flexcenter col-6 col-sm-6 col-md-6 col-lg-6 col-xl-4"">");
            EndContext();
            BeginContext(2048, 17, false);
#line 34 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
                                                                                                Write(Model.CurrentPage);

#line default
#line hidden
            EndContext();
            BeginContext(2065, 1, true);
            WriteLiteral("/");
            EndContext();
            BeginContext(2067, 16, false);
#line 34 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
                                                                                                                   Write(Model.TotalPages);

#line default
#line hidden
            EndContext();
            BeginContext(2083, 758, true);
            WriteLiteral(@"</div>
                        <div class=""col-3 col-sm-3 col-md-3 col-lg-3 col-xl-4"">
                            <button type=""button"" class=""btn btn-block btn-maintype"" id=""MyfollowerNextPageO""><i class=""fas fa-angle-right""></i></button>
                        </div>
                    </div>
                </div>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">
                    <div class=""dropdown"">
                        <button class=""btn btn-block dropdown-toggle btn-maintype"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">第1頁</button>
                        <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"" id=""MFPageListO"">

");
            EndContext();
#line 45 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
                             for (int i = 1; i <= Model.TotalPages; i++)
                            {

#line default
#line hidden
            BeginContext(2946, 77, true);
            WriteLiteral("                                <a class=\"dropdown-item\" href=\"#\" data-page=\"");
            EndContext();
            BeginContext(3025, 1, false);
#line 47 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
                                                                         Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(3027, 3, true);
            WriteLiteral("\">第");
            EndContext();
            BeginContext(3032, 1, false);
#line 47 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
                                                                                Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(3034, 7, true);
            WriteLiteral("頁</a>\r\n");
            EndContext();
#line 48 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
                            }

#line default
#line hidden
            BeginContext(3072, 150, true);
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"followerlist-box\">\r\n");
            EndContext();
#line 55 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
                 foreach (var item in @Model.listMyfollowerViewModel)
                {

#line default
#line hidden
            BeginContext(3312, 316, true);
            WriteLiteral(@"                    <div class=""card mb-3"">
                        <div class=""card-header"">
                            <div class=""row"">
                                <div class=""col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">
                                    <div class=""d-flex align-items-center"">姓名 :  ");
            EndContext();
            BeginContext(3629, 15, false);
#line 61 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
                                                                            Write(item.MemberName);

#line default
#line hidden
            EndContext();
            BeginContext(3644, 220, true);
            WriteLiteral("</div>\r\n                                </div>\r\n                                <div class=\"col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6\">\r\n                                    <div class=\"d-flex align-items-center\">電話 : ");
            EndContext();
            BeginContext(3865, 17, false);
#line 64 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
                                                                           Write(item.MemberMobile);

#line default
#line hidden
            EndContext();
            BeginContext(3882, 392, true);
            WriteLiteral(@"</div>
                                </div>
                            </div>
                        </div>
                        <div class=""card-body"">
                            <div class=""row"">
                                <div class=""col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">
                                    <div class=""d-flex align-items-center"">Email&nbsp;: ");
            EndContext();
            BeginContext(4275, 10, false);
#line 71 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
                                                                                   Write(item.eMail);

#line default
#line hidden
            EndContext();
            BeginContext(4285, 228, true);
            WriteLiteral("</div>\r\n                                </div>\r\n                                <div class=\"col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6\">\r\n                                    <div class=\"d-flex align-items-center\">LineID&nbsp;:");
            EndContext();
            BeginContext(4514, 11, false);
#line 74 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
                                                                                   Write(item.LineId);

#line default
#line hidden
            EndContext();
            BeginContext(4525, 323, true);
            WriteLiteral(@"</div>
                                </div>
                            </div>
                            <div class=""row"">
                                <div class=""col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"">
                                    <div class=""d-flex align-items-center"">入會日期&nbsp;:&nbsp;&nbsp;");
            EndContext();
            BeginContext(4849, 12, false);
#line 79 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
                                                                                             Write(item.Duedate);

#line default
#line hidden
            EndContext();
            BeginContext(4861, 317, true);
            WriteLiteral(@"</div>
                                </div>
                            </div>
                            <div class=""row"">
                                <div class=""col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">
                                    <div class=""d-flex align-items-center"">準VIP日期&nbsp;:&nbsp;");
            EndContext();
            BeginContext(5179, 17, false);
#line 84 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
                                                                                         Write(item.VipApplyDate);

#line default
#line hidden
            EndContext();
            BeginContext(5196, 233, true);
            WriteLiteral("</div>\r\n                                </div>\r\n                                <div class=\"col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6\">\r\n                                    <div class=\"d-flex align-items-center\">VIP日期&nbsp;:&nbsp;");
            EndContext();
            BeginContext(5430, 12, false);
#line 87 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
                                                                                        Write(item.VipDate);

#line default
#line hidden
            EndContext();
            BeginContext(5442, 462, true);
            WriteLiteral(@"</div>
                                </div>
                            </div>
                            <div class=""row"">
                                <div class=""col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"">
                                    <div class=""d-flex align-items-center""> 我的發展獎金&nbsp;:600元</div>
                                </div>
                            </div>
                        </div>
                    </div>
");
            EndContext();
#line 97 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"

                }

#line default
#line hidden
            BeginContext(5925, 48, true);
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 102 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(5985, 117, true);
            WriteLiteral("    <h3> 沒有下線 </h3>\r\n    <button id=\"mobileSide\" type=\"button\" class=\"btn btn-maintype mb-2 mobiletype\">選單</button>\r\n");
            EndContext();
#line 107 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
}

#line default
#line hidden
            BeginContext(6105, 109, true);
            WriteLiteral("\r\n<script>\r\n    // 10.系統設定jCurrentPage=9-7回傳CurrentPage，系統設定jTotallPages=9-7回傳TotalPages。\r\n    jCurrentPage =");
            EndContext();
            BeginContext(6215, 17, false);
#line 111 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
             Write(Model.CurrentPage);

#line default
#line hidden
            EndContext();
            BeginContext(6232, 21, true);
            WriteLiteral(";\r\n    jTotallPages =");
            EndContext();
            BeginContext(6254, 16, false);
#line 112 "D:\lab\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Myfollower\Default.cshtml"
             Write(Model.TotalPages);

#line default
#line hidden
            EndContext();
            BeginContext(6270, 14, true);
            WriteLiteral(";\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyfollowerManageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
