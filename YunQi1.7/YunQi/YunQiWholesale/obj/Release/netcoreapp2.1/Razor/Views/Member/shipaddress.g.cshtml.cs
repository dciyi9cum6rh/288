#pragma checksum "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Member\shipaddress.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8230c165b1a8d13edfd17d6e3f66e4180afabac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Member_shipaddress), @"mvc.1.0.view", @"/Views/Member/shipaddress.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Member/shipaddress.cshtml", typeof(AspNetCore.Views_Member_shipaddress))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8230c165b1a8d13edfd17d6e3f66e4180afabac", @"/Views/Member/shipaddress.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28caaf0241098ecd91020ca85cf41e4615f1e192", @"/Views/_ViewImports.cshtml")]
    public class Views_Member_shipaddress : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(120, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 5 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Member\shipaddress.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(151, 68, true);
            WriteLiteral("\r\n<div class=\"shipaddress-component\">\r\n    <div class=\"container\">\r\n");
            EndContext();
            BeginContext(365, 11119, true);
            WriteLiteral(@"        <div class=""title-box border-bottom mb-3"">
            <h2>送貨地址</h2>
            <button id=""mobileSide"" type=""button"" class=""btn btn-maintype mb-2 mobiletype"">選單</button>
        </div>
        <div class=""shipsearch-box row mb-3"">
            <div class=""col-12 col-sm-12 col-md-12 col-lg-2 col-xl-2"">
                <input id="""" type=""text"" placeholder=""姓名"" class=""form-control"" />
            </div>
            <div class=""col-12 col-sm-12 col-md-12 col-lg-2 col-xl-2"">
                <input id="""" type=""text"" placeholder=""手機(帳號)"" class=""form-control"" />
            </div>
            <div class=""col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">
                <input id="""" type=""text"" placeholder=""地址"" class=""form-control"" />
            </div>
            <div class=""col-12 col-sm-12 col-md-12 col-lg-2 col-xl-2"">
                <button type=""button"" class=""btn btn-block btn-function"">搜尋</button>
            </div>
            <div class=""col-12 col-sm-12 col-md-12 col-lg-2 col-xl-2"">");
            WriteLiteral(@"
                <button type=""button"" class=""btn btn-block btn-maintype"">新增</button>
            </div>
        </div>
        <div class=""pagination-box row mb-3"">
            <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">
                <div class=""row"">
                    <div class=""col-3 col-sm-3 col-md-3 col-lg-3 col-xl-3"">
                        <button type=""button"" class=""btn btn-block btn-page btn-maintype""><i class=""fas fa-angle-left""></i></button>
                    </div>
                    <div class=""pagination flexcenter col-6 col-sm-6 col-md-6 col-lg-6 col-xl-4"">1/3</div>
                    <div class=""col-3 col-sm-3 col-md-3 col-lg-3 col-xl-3"">
                        <button type=""button"" class=""btn btn-block btn-page btn-maintype""><i class=""fas fa-angle-right""></i></button>
                    </div>
                </div>
            </div>
            <div class=""col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">
                <div class=""dropdown"">
    ");
            WriteLiteral(@"                <button class=""btn btn-block dropdown-toggle btn-pageselect btn-maintype"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">第1頁</button>
                    <div class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""dropdownMenuButton"">
                        <a class=""dropdown-item"" href=""#"">第一頁</a>
                        <a class=""dropdown-item"" href=""#"">第二頁</a>
                        <a class=""dropdown-item"" href=""#"">第三頁</a>
                    </div>
                </div>
            </div>
        </div>
        <div class=""shiplist-box pb-2"">
            <div class=""card text-white mb-3"">
                <div class=""card-header"">#1</div>
                <div class=""card-body"">
                    <div class=""form-group row"">
                        <label for=""staticEmail"" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">姓名：</label>
                        <div class=""col-12 col-sm-12 col-md-");
            WriteLiteral(@"12 col-lg-8 col-xl-8"">
                            <input type=""text"" readonly class=""form-control"" id="""" value=""email@example.com"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label for=""staticEmail"" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">手機(帳號)：</label>
                        <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">
                            <input type=""text"" readonly class=""form-control"" id="""" value=""email@example.com"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label for=""staticEmail"" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">住家/公司電話：</label>
                        <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">
                            <input type=""text"" readonly class=""form-control"" id="""" value=""email@example.com"">
          ");
            WriteLiteral(@"              </div>
                    </div>
                    <div class=""form-group row"">
                        <label for=""staticEmail"" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">送貨地址：</label>
                        <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">
                            <input type=""text"" readonly class=""form-control"" id="""" value=""email@example.com"">
                        </div>
                    </div>
                </div>
                <div class=""card-footer"">
                    <button type=""button"" class=""btn btn-update btn-maintype"">更新</button>
                </div>
            </div>
            <div class=""card text-white mb-3"">
                <div class=""card-header"">#2</div>
                <div class=""card-body"">
                    <div class=""form-group row"">
                        <label for=""staticEmail"" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">姓名：</label>
               ");
            WriteLiteral(@"         <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">
                            <input type=""text"" readonly class=""form-control"" id="""" value=""email@example.com"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label for=""staticEmail"" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">手機(帳號)：</label>
                        <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">
                            <input type=""text"" readonly class=""form-control"" id="""" value=""email@example.com"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label for=""staticEmail"" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">住家/公司電話：</label>
                        <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">
                            <input type=""text"" readonly class=""form-control""");
            WriteLiteral(@" id="""" value=""email@example.com"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label for=""staticEmail"" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">送貨地址：</label>
                        <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">
                            <input type=""text"" readonly class=""form-control"" id="""" value=""email@example.com"">
                        </div>
                    </div>
                </div>
                <div class=""card-footer"">
                    <button type=""button"" class=""btn btn-update btn-maintype"">更新</button>
                </div>
            </div>
            <div class=""card text-white mb-3"">
                <div class=""card-header"">#3</div>
                <div class=""card-body"">
                    <div class=""form-group row"">
                        <label for=""staticEmail"" class=""col-form-label col-12 col-sm-12 col-md-12 co");
            WriteLiteral(@"l-lg-4 col-xl-4"">姓名：</label>
                        <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">
                            <input type=""text"" readonly class=""form-control"" id="""" value=""email@example.com"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label for=""staticEmail"" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">手機(帳號)：</label>
                        <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">
                            <input type=""text"" readonly class=""form-control"" id="""" value=""email@example.com"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label for=""staticEmail"" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">住家/公司電話：</label>
                        <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">
                            <in");
            WriteLiteral(@"put type=""text"" readonly class=""form-control"" id="""" value=""email@example.com"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label for="""" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">送貨地址：</label>
                        <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">
                            <input type=""text"" readonly class=""form-control"" id="""" value=""email@example.com"">
                        </div>
                    </div>
                </div>
                <div class=""card-footer"">
                    <button type=""button"" class=""btn btn-update btn-maintype"">更新</button>
                </div>
            </div>
        </div>
        <div class=""newship-box border-top pt-2"">
            <div class=""card text-white"">
                <div class=""card-header"">新增送貨地址</div>
                <div class=""card-body"">
                    <div class=""form-group row"">
");
            WriteLiteral(@"                        <label for="""" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">姓名：</label>
                        <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">
                            <input type=""text"" readonly class=""form-control"" id="""" value=""email@example.com"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label for="""" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">手機(帳號)：</label>
                        <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">
                            <input type=""text"" readonly class=""form-control"" id="""" value=""email@example.com"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label for="""" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">住家/公司電話：</label>
                        <div class=""col-12 col-s");
            WriteLiteral(@"m-12 col-md-12 col-lg-8 col-xl-8"">
                            <input type=""text"" readonly class=""form-control"" id="""" value=""email@example.com"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label for="""" class=""col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">送貨地址：</label>
                        <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8"">
                            <input type=""text"" readonly class=""form-control"" id="""" value=""email@example.com"">
                        </div>
                    </div>
                </div>
                <div class=""card-footer text-muted"">
                    <button type=""button"" class=""btn btn-add btn-maintype"">新增</button>
                </div>
            </div>
        </div>
    </div>
</div>
");
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
