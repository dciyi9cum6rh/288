#pragma checksum "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d37e488c81749312b82732df875bd44edb226e10"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_PostOrder_Default), @"mvc.1.0.view", @"/Views/Shared/Components/PostOrder/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/PostOrder/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_PostOrder_Default))]
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
#line 1 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
using DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d37e488c81749312b82732df875bd44edb226e10", @"/Views/Shared/Components/PostOrder/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28caaf0241098ecd91020ca85cf41e4615f1e192", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_PostOrder_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PostOrderViewModel1>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ECPayPayment_1.0.0.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-PaymentType", new global::Microsoft.AspNetCore.Html.HtmlString("ATM"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-PaymentName", new global::Microsoft.AspNetCore.Html.HtmlString("ATM"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-CustomerBtn", new global::Microsoft.AspNetCore.Html.HtmlString("1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-PaymentType", new global::Microsoft.AspNetCore.Html.HtmlString("CVS"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-PaymentName", new global::Microsoft.AspNetCore.Html.HtmlString("CVS"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
  
    //Layout = null;

#line default
#line hidden
#line 6 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
 if (@Model.RtnModel == null)
{
    if (Model.ret != 0)
    {
        //20181206更新 ---棋
        //綠界金流有誤時，導回自行滙款

#line default
#line hidden
            BeginContext(194, 371, true);
            WriteLiteral(@"        <div class=""container"">
            <div class=""title-box"">
                <div class=""title"">
                    <i class=""fas fa-dollar-sign""></i>訂單失敗
                </div>
            </div>
            <div class=""payway-box"">
                <div id=""Result"" style=""display:none;""></div>
                <div class=""mb-3"">
                    目前 ");
            EndContext();
            BeginContext(566, 13, false);
#line 21 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
                  Write(Model.product);

#line default
#line hidden
            EndContext();
            BeginContext(579, 229, true);
            WriteLiteral(" 商品補貨中，如有問題請洽客服人員 !\r\n                </div>\r\n                <div>\r\n                    <button type=\"button\" class=\"btn btn-maintype\" id=\"GetGoMember\">回到會員中心</button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 28 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
    }
    else
    {
        //20181206更新 ---棋
        //綠界金流有誤時，導回自行滙款

#line default
#line hidden
            BeginContext(885, 377, true);
            WriteLiteral(@"        <div class=""container"">
            <div class=""title-box"">
                <div class=""title"">
                    <i class=""fas fa-dollar-sign""></i>請選擇付款方式
                </div>
            </div>
            <div class=""payway-box"">
                <div id=""Result"" style=""display:none;""></div>
                <div class=""mb-3"">
                    銀行端錯誤(");
            EndContext();
            BeginContext(1263, 9, false);
#line 42 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
                     Write(Model.ret);

#line default
#line hidden
            EndContext();
            BeginContext(1272, 438, true);
            WriteLiteral(@")，請直接匯款至本公司帳戶  :戶名 : 馬士穎 郵局代號 : 700 帳號 : 00310220499344 ，<br />
                    滙款完成後請至[會員中心/我的訂單]提出己付款，或電洽服務人員(04)24260263，謝謝！
                </div>
                <div>
                    <button id=""FinishCart"" type=""button"" class=""btn btn-maintype"">完成</button>
                    <button type=""button"" class=""btn btn-maintype"" id=""GetGoMember"">回到會員中心</button>
                </div>
            </div>
        </div>
");
            EndContext();
#line 51 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
    }
}

#line default
#line hidden
#line 53 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
                                                          
else if (Model.OrderDetail != null && Model.OrderDetail.Count > 0)
{

#line default
#line hidden
            BeginContext(1851, 256, true);
            WriteLiteral(@"    <div class=""container"">
        <div class=""title-box"">
            <div class=""title"">
                <i class=""fas fa-dollar-sign""></i>請選擇付款方式
            </div>
        </div>
        <div class=""payway-box"">
            <input type=""hidden""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2107, "\"", 2129, 1);
#line 63 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
WriteAttributeValue("", 2115, Model.OrderId, 2115, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2130, 82, true);
            WriteLiteral(" id=\"ECPAYOrderId\" />\r\n            <div id=\"Result\" style=\"display:none;\"></div>\r\n");
            EndContext();
#line 65 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
             if (Model.CartTobal <= 10000)
            {
                

#line default
#line hidden
            BeginContext(2716, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(2732, 344, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "914fad131a19486cabcf8223bbd2461d", async() => {
                BeginContext(3049, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
#line 76 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
                                    Write(Model.RtnModel.MerchantID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-MerchantID", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 77 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
                                 Write(Model.RtnModel.SPToken);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-SPToken", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3076, 108, true);
            WriteLiteral("\r\n                <button onclick=\"checkOut(\'ATM\');\" type=\"button\" class=\"btn btn-maintype\">ATM滙款</button>\r\n");
            EndContext();
#line 83 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
                 if (Model.CartTobal <= 6000)
                {

#line default
#line hidden
            BeginContext(3250, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(3270, 368, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b25bc60c4e934ddd9f6ac7f041a6a243", async() => {
                BeginContext(3607, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
#line 86 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
                                        Write(Model.RtnModel.MerchantID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-MerchantID", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 87 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
                                     Write(Model.RtnModel.SPToken);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-SPToken", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3638, 111, true);
            WriteLiteral("\r\n                    <button onclick=\"checkOut(\'CVS\');\" type=\"button\" class=\"btn btn-maintype\">超商繳款</button>\r\n");
            EndContext();
#line 93 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
                }

#line default
#line hidden
#line 93 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
                 
            }
            else
            {

#line default
#line hidden
            BeginContext(3816, 327, true);
            WriteLiteral(@"                <div>
                    金額超過1萬元，請直接匯款至本公司帳戶  :戶名 : 馬士穎 郵局代號 : 700 帳號 : 00310220499344 ，<br />
                    匯款完成後請至[會員中心/我的訂單]提出己付款，或電洽服務人員(04)24260263，謝謝！
                </div>
                <div>
                    <button id=""FinishCart"" type=""button"" class=""btn btn-maintype"" data-OrderId=""");
            EndContext();
            BeginContext(4144, 13, false);
#line 102 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
                                                                                            Write(Model.OrderId);

#line default
#line hidden
            EndContext();
            BeginContext(4157, 140, true);
            WriteLiteral("\">完成</button>\r\n                    <button type=\"button\" class=\"btn btn-maintype\" id=\"GetGoMember\">回到會員中心</button>\r\n                </div>\r\n");
            EndContext();
#line 105 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
            }

#line default
#line hidden
            BeginContext(4312, 28, true);
            WriteLiteral("        </div>\r\n    </div>\r\n");
            EndContext();
#line 108 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
}
else
{
    // 17a.系統在View【Cart/PostOrder】判斷16回傳之OrderDetail == null。
    //  17a-1.系統顯示"系統錯誤，請連絡客服人員！”。

#line default
#line hidden
            BeginContext(4451, 162, true);
            WriteLiteral("    <div class=\"container\">\r\n        <h3>系統錯誤，請連絡客服人員！</h3>\r\n        <button type=\"button\" class=\"btn btn-maintype\" id=\"GetGoMember\">回到會員中心</button>\r\n    </div>\r\n");
            EndContext();
#line 117 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
    //  17a-2.結束。
}

#line default
#line hidden
            BeginContext(4635, 1325, true);
            WriteLiteral(@"
<script>
    var status = 0;
    function ECPAYmessage(e)
    {
        if (status == 0) {
        status++;
         var ret = JSON.parse(e.data);
        // 1.使用者在購物車確認付款頁點按某個付款按鈕並確認付款。
        if (ret.RtnCode == 1)
        {
            // 2.系統在Client端的message事件判斷RtnCode===1。
            // 3.系統顯示信用卡付款成功。
            alert(""信用卡付款成功！"");
            CloseIframe(""CREDIT"");
        }
        else if (ret.RtnCode == 2)
        {
            // 2a.系統在Client端的message事件判斷RtnCode===2。
            //  2a-1.系統顯示ATM取號成功。
            alert(""ATM取號成功！"");
            CloseIframe(""ATM"");
            //  2a-2.回4。
        }
        else if (ret.RtnCode == 10100073)
        {
            // 2b.系統在Client端的message事件判斷RtnCode===10100073。
            //  2b-1.系統顯示超商繳款取號成功。
            alert(""超商繳款取號成功！"");
            CloseIframe(""CVS"");
            //  2b-2.回4。
        }
        else
        {
            // 2c.系統在Client端的message事件判斷RtnCode!==1/2/10100073。
            //  2c-1.系統顯示執行失敗，錯誤代碼。
  ");
            WriteLiteral(@"          alert(""執行失敗，錯誤代碼："" + ret.RtnCode);
            //  2c-2.結束。
            return;
        }

        // 4.系統以ajax呼叫Post Action【Cart/Success】，並傳送ordeerId，contactData。
        $.ajax({
            type: ""Post"",
            cache: false,
            dataType: ""HTML"",
            url: '");
            EndContext();
            BeginContext(5961, 29, false);
#line 165 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
             Write(Url.Action("Success", "Cart"));

#line default
#line hidden
            EndContext();
            BeginContext(5990, 94, true);
            WriteLiteral("\',\r\n            data: {\r\n                ContactData: contactData,\r\n                OrderId: \'");
            EndContext();
            BeginContext(6085, 13, false);
#line 168 "D:\lab\288\YunQi1.7\YunQi\YunQiWholesale\Views\Shared\Components\PostOrder\Default.cshtml"
                     Write(Model.OrderId);

#line default
#line hidden
            EndContext();
            BeginContext(6098, 620, true);
            WriteLiteral(@"',
                MemberMobile: jMemberMobile,
                //20181206更新 ---棋
                OrderStateId: 1,
            }
        })
            .done(data =>
            {
                $(""#mainContent"").empty();
                $(""#mainContent"").html(data);
            })
                .fail(SystemError => { alert(""系統錯誤，請稍後再試！"") })
        };
     };

        var newECPAYmessage = function (e)
        {
            ECPAYmessage(e);
        };

    window.addEventListener('message', newECPAYmessage, false);
</script>
<style>

    /*20190109 ---棋*/
    /*螢幕尺寸小於 1440 FHD*/
    ");
            EndContext();
            BeginContext(6719, 417, true);
            WriteLiteral(@"@media (max-width: 1440.98px) {
        iframe {
            width: 330px !important;
            height: 520px !important;
            left: 106% !important;
            top: 50% !important;
        }

        .Close {
            left: 6% !important;
        }

        #ECPay.wrapper .header {
            height: 1px !important;
        }
    }
    /*20190109 ---棋*/
    /*螢幕尺寸小於 1080 QHD*/
    ");
            EndContext();
            BeginContext(7137, 468, true);
            WriteLiteral(@"@media (max-width: 1080.98px) {
        iframe {
            width: 350px !important;
            height: 530px !important;
            left: 98% !important;
            top: 58% !important;
        }

        .Close {
            left: 12% !important;
            top: 56% !important;
        }

        #ECPay.wrapper .header {
            height: 1px !important;
        }
    }
    /*20190108 ---棋*/
    /*iPhone X, 8/8 +, 7/7 +, 6/6 +, 5*/
    ");
            EndContext();
            BeginContext(7606, 517, true);
            WriteLiteral(@"@media only screen and (min-device-width : 375px) and (max-device-width : 812px) and (-webkit-device-pixel-ratio : 3) {
        iframe {
            width: 330px !important;
            height: 520px !important;
            left: 106% !important;
            top: 50% !important;
        }

        .Close {
            left: 6% !important;
        }

        #ECPay.wrapper .header {
            height: 1px !important;
        }
    }
    /*20190108 ---棋*/
    /*iPhone 6 +, 6s +, 7 + 和 8 +*/
    ");
            EndContext();
            BeginContext(8124, 460, true);
            WriteLiteral(@"@media only screen and (min-device-width : 414px) and (max-device-width : 736px) {
        iframe {
            width: 350px !important;
            height: 530px !important;
            left: 98% !important;
            top: 58% !important;
        }

        .Close {
            left: 12% !important;
            top: 56% !important;
        }

        #ECPay.wrapper .header {
            height: 1px !important;
        }
    }
</style>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PostOrderViewModel1> Html { get; private set; }
    }
}
#pragma warning restore 1591
