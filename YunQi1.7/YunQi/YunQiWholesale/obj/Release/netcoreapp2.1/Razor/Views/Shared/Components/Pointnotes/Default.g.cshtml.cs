#pragma checksum "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "46de508f71fa2e0b807383441a33b14cb76ad860"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Pointnotes_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Pointnotes/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Pointnotes/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Pointnotes_Default))]
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
#line 1 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
using DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46de508f71fa2e0b807383441a33b14cb76ad860", @"/Views/Shared/Components/Pointnotes/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28caaf0241098ecd91020ca85cf41e4615f1e192", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Pointnotes_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PointnotesManageViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
  
    int id = 0;

#line default
#line hidden
            BeginContext(76, 1119, true);
            WriteLiteral(@"
<div class=""pointnotes-component"">
    <div class=""container"">
        <div class=""title-box border-bottom d-flex align-items-center mb-3"">
            <h2 class=""mr-3"">點數異動記錄</h2>
            <button id=""mobileSide"" type=""button"" class=""btn btn-maintype mb-2 mobiletype"">選單</button>
        </div>
        <div class=""search-box row mb-3"">
            <div class=""col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">
                <input id=""sDateO"" type=""text"" placeholder=""日期(起)"" class=""form-control"" />
            </div>
            <div class=""col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">
                <input id=""eDateO"" type=""text"" placeholder=""日期(迄)"" class=""form-control"" />
            </div>
            <div class=""col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4"">
                <button type=""button"" class=""btn btn-block btn-maintype"" id=""btnSerrchProductDetail"">搜尋</button>
            </div>
        </div>
        <div class=""detail-box row mb-3"">
            <div class=""col-12 col-sm-12 ");
            WriteLiteral("col-md-12 col-lg-10 col-xl-10 d-flex align-items-center pt-1 pb-1\">\r\n                <div>目前點數：");
            EndContext();
            BeginContext(1196, 18, false);
#line 26 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
                     Write(Model.Member.Bonus);

#line default
#line hidden
            EndContext();
            BeginContext(1214, 34, true);
            WriteLiteral(" 點 <input type=\"hidden\" id=\"bonus\"");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 1248, "\'", 1275, 1);
#line 26 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
WriteAttributeValue("", 1256, Model.Member.Bonus, 1256, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1276, 258, true);
            WriteLiteral(@" /> &nbsp;&nbsp;<input type=""text"" value=""0"" size=""6"" style='text-align:right;' id=""used_bonus"" />&nbsp;&nbsp;<button type=""button"" class=""btn btn-secondary"" id=""btnChangeBonus"">提領</button>&nbsp;&nbsp;(每次提領須扣 50 點)</div>
            </div>
        </div>
");
            EndContext();
#line 29 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
         if (@Model.listGetMemberBonusChangeRecordListViewModel != null && @Model.listGetMemberBonusChangeRecordListViewModel.Count > 0)
        {

#line default
#line hidden
            BeginContext(1683, 545, true);
            WriteLiteral(@"            <div class=""pagination-box row mb-3"">
                <div class=""col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8 pt-1 pb-1"">
                    <div class=""row"">
                        <div class=""col-3 col-sm-3 col-md-3 col-lg-3 col-xl-3"">
                            <button type=""button"" class=""btn btn-block btn-maintype"" id=""ProductDetailPrePage""><i class=""fas fa-angle-left""></i></button>
                        </div>
                        <div class=""pagination flexcenter col-6 col-sm-6 col-md-6 col-lg-6 col-xl-4"">");
            EndContext();
            BeginContext(2229, 17, false);
#line 37 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
                                                                                                Write(Model.CurrentPage);

#line default
#line hidden
            EndContext();
            BeginContext(2246, 1, true);
            WriteLiteral("/");
            EndContext();
            BeginContext(2248, 16, false);
#line 37 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
                                                                                                                   Write(Model.TotalPages);

#line default
#line hidden
            EndContext();
            BeginContext(2264, 798, true);
            WriteLiteral(@"</div>
                        <div class=""col-3 col-sm-3 col-md-3 col-lg-3 col-xl-3"">
                            <button type=""button"" class=""btn btn-block btn-maintype"" id=""ProductDetailNextPage""><i class=""fas fa-angle-right""></i></button>
                        </div>
                    </div>
                </div>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4 pt-1 pb-1"">
                    <div class=""dropdown"">
                        <button class=""btn btn-block dropdown-toggle btn-maintype"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">第1頁</button>
                        <div class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""dropdownMenuButton"" id=""ProductDetailPageList"">
");
            EndContext();
#line 47 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
                             for (int i = 1; i <= Model.TotalPages; i++)
                            {

#line default
#line hidden
            BeginContext(3167, 77, true);
            WriteLiteral("                                <a class=\"dropdown-item\" href=\"#\" data-page=\"");
            EndContext();
            BeginContext(3246, 1, false);
#line 49 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
                                                                         Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(3248, 3, true);
            WriteLiteral("\">第");
            EndContext();
            BeginContext(3253, 1, false);
#line 49 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
                                                                                Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(3255, 7, true);
            WriteLiteral("頁</a>\r\n");
            EndContext();
#line 50 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
                            }

#line default
#line hidden
            BeginContext(3293, 104, true);
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 55 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
        }

#line default
#line hidden
            BeginContext(3408, 120, true);
            WriteLiteral("        <div class=\"triumphlist-box\">\r\n            <div class=\"noteslist-box\">\r\n                <div class=\"row mb-3\">\r\n");
            EndContext();
#line 59 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
                     foreach (var item in Model.listGetMemberBonusChangeRecordListViewModel)
                    {
                        id += 1;


#line default
#line hidden
            BeginContext(3681, 437, true);
            WriteLiteral(@"                        <div class=""col-6 ol-sm-6 col-md-12 col-lg-6 col-xl-6 mb-3"">
                            <div class=""card"">
                                <div class=""card-body"">
                                    <div class=""row mb-3"">
                                        <div class=""col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">
                                            <div class=""d-flex align-items-center"">項次：");
            EndContext();
            BeginContext(4119, 2, false);
#line 68 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
                                                                                 Write(id);

#line default
#line hidden
            EndContext();
            BeginContext(4121, 246, true);
            WriteLiteral("</div>\r\n                                        </div>\r\n                                        <div class=\"col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12\">\r\n                                            <div class=\"d-flex align-items-center\">異動時間：");
            EndContext();
            BeginContext(4368, 15, false);
#line 71 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
                                                                                   Write(item.ChangeTime);

#line default
#line hidden
            EndContext();
            BeginContext(4383, 350, true);
            WriteLiteral(@"</div>
                                        </div>
                                    </div>
                                    <div class=""row mb-3"">
                                        <div class=""col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"">
                                            <div class=""d-flex align-items-center"">異動類型：");
            EndContext();
            BeginContext(4734, 10, false);
#line 76 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
                                                                                   Write(item.Event);

#line default
#line hidden
            EndContext();
            BeginContext(4744, 342, true);
            WriteLiteral(@"</div>
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">
                                            <div class=""d-flex align-items-center"">異動前：");
            EndContext();
            BeginContext(5087, 16, false);
#line 81 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
                                                                                  Write(item.BeforeBonus);

#line default
#line hidden
            EndContext();
            BeginContext(5103, 246, true);
            WriteLiteral(" 點</div>\r\n                                        </div>\r\n                                        <div class=\"col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12\">\r\n                                            <div class=\"d-flex align-items-center\">異動：");
            EndContext();
            BeginContext(5350, 16, false);
#line 84 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
                                                                                 Write(item.ChangeBonus);

#line default
#line hidden
            EndContext();
            BeginContext(5366, 344, true);
            WriteLiteral(@" 點</div>
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">
                                            <div class=""d-flex align-items-center"">異動後：");
            EndContext();
            BeginContext(5711, 15, false);
#line 89 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
                                                                                  Write(item.AfterBonus);

#line default
#line hidden
            EndContext();
            BeginContext(5726, 345, true);
            WriteLiteral(@" 點</div>
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6"">
                                            <div class=""d-flex align-items-center"">異動原因：");
            EndContext();
            BeginContext(6072, 9, false);
#line 94 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
                                                                                   Write(item.Memo);

#line default
#line hidden
            EndContext();
            BeginContext(6081, 209, true);
            WriteLiteral(" </div>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
            EndContext();
#line 100 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"

                    }

#line default
#line hidden
            BeginContext(6315, 270, true);
            WriteLiteral(@"                </div>

            </div>
                    
        </div>
    </div>

    </div>
        <script>
    $(document).ready(function () {
        // 10.系統設定jCurrentPage=9-7回傳CurrentPage，系統設定jTotallPages=9-7回傳TotalPages。
        jCurrentPage =");
            EndContext();
            BeginContext(6586, 17, false);
#line 113 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
                 Write(Model.CurrentPage);

#line default
#line hidden
            EndContext();
            BeginContext(6603, 25, true);
            WriteLiteral(";\r\n        jTotallPages =");
            EndContext();
            BeginContext(6629, 16, false);
#line 114 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\Pointnotes\Default.cshtml"
                 Write(Model.TotalPages);

#line default
#line hidden
            EndContext();
            BeginContext(6645, 1396, true);
            WriteLiteral(@";
    });


    $(""#btnChangeBonus"").unbind(""click"").click(function (event) {
        event.preventDefault();
        jBonus = document.getElementById('bonus').value;
        jUsedBonus = document.getElementById('used_bonus').value;

        if (jUsedBonus > (jBonus - 50)) {
            alert('不得大於剩餘點數！');
        }
        else if (jUsedBonus <= 0) {
            alert('請輸入正確數值');
        }


        else {
            $.ajax({
                type: 'Post',
                cache: false,

                url: './Member/UsedMemberBonus',
                data: {
                    'MemberMobile': jMemberMobile,
                    'Bonus': jBonus,
                    'UsedBonus': jUsedBonus
                },
                beforeSend: LoadBefore,
                success: ChangeBonusSuccess,
                error: SystemError

            });

        }





    });
    function ChangeBonusSuccess(response) {
        document.getElementById('btnSerrchProductDetail').cl");
            WriteLiteral(@"ick();
        //
        var a = jBonus
        var b = jUsedBonus
        var c = a - 50 - b;
        alert('申請提領成功！');
        alert('目前點數:' + a.toString() + ""\n"" + '手續費扣除:' + '50' + ""\n"" + '提領點數:' + b.toString() + ""\n"" + '剩餘點數:' + c);
    };
    function LoadBefore() { }
    function SystemError() {
        alert('系統錯誤，請稍後再試！');
    }
        </script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PointnotesManageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
