function PayBtn(ECPay) {
    var button = document.createElement("button");
    button.innerHTML = ECPay.dataPaymentName + "付款";
    button.type = "button";
    button.id = "Btn_Pay";
    button.setAttribute("style", "text-decoration: none;color: #ffffff;min-width: 150px;display: inline-block;padding: 10px 20px;border-radius: 5px;letter-spacing: 2px;margin: 15px 0;background-color: #3f3f3f;background-image: -webkit-gradient(linear, left top, left bottom, from(#3f3f3f), to(#000000));background-image: -webkit-linear-gradient(top, #3f3f3f, #000000);background-image:-moz-linear-gradient(top, #3f3f3f, #000000);background-image:-ms-linear-gradient(top, #3f3f3f, #000000);background-image:-o-linear-gradient(top, #3f3f3f, #000000);background-image:linear-gradient(top bottom, #3f3f3f, #000000);");
    button.setAttribute("onclick", "checkOut('" + ECPay.dataPaymentType + "');");
    ECPay.div.appendChild(button);
}

function BtnDecorator(ECPay) {
    var DivECPay = document.createElement("div");
    DivECPay.setAttribute("style", "z-index: 2147483646; display: none; background: rgba(0, 0, 0, 0.5);width: 100%; height: 100%; left:0%;top:0%; border: 0px none transparent; overflow-x: hidden; overflow-y: auto; visibility: visible;padding: 0px; -webkit-tap-highlight-color: transparent; position: fixed;");
    DivECPay.setAttribute("id", "DivECPay_" + ECPay.dataPaymentType);
    ECPay.div.appendChild(DivECPay);

    var iframebutton = document.createElement("button");
    iframebutton.setAttribute("id", "iframeECPayClose_" + ECPay.dataPaymentType);
    iframebutton.innerHTML = "X";
    iframebutton.type = "button";
    iframebutton.setAttribute("style", "z-index: 2147483647;display: none; position: fixed; left: 50%; top: 50%; margin-left:295px; margin-top:-275px; background-color: #fff;  color: #6d6d6d;  width: 25px;  height: 25px;  border-radius: 5px;  font-size: 16px;  cursor: pointer;  box-shadow: 0 2px 0 0 black;  font-weight: bold;  -webkit-transition: 0.3s;  -moz-transition: 0.3s;  -o-transition: 0.3s;  -ms-transition: 0.3s;  transition: 0.3s;");
    //20190108 ---棋
    iframebutton.setAttribute("class", "Close");
    iframebutton.setAttribute("onclick", "CloseIframe('" + ECPay.dataPaymentType + "')");
    ECPay.div.appendChild(iframebutton);
}

var
    version = "1.0.0",
    description = "綠界科技(ECPay)_ECPayPayment",
    //測試環境轉正式環境
    //正式環境
    domain = "https://payment.ecpay.com.tw";
//測試環境
//domain = "https://payment-stage.ecpay.com.tw";

ECPay = {
    //### 初始化
    init: function () {
        this.getIsMobileAgent();
        this.getContainer();
        this.createPayButton();
        this.createModal();
    },
    getIsMobileAgent: function () {
        this.IsMobileAgent = false;
        var userAgent = navigator.userAgent;
        var CheckMobile = new RegExp("android.+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino");
        var CheckMobile2 = new RegExp("mobile|mobi|nokia|samsung|sonyericsson|mot|blackberry|lg|htc|j2me|ucweb|opera mini|mobi|android|iphone");

        if (CheckMobile.test(userAgent) || CheckMobile2.test(userAgent.toLowerCase())) {
            this.IsMobileAgent = true;
        }
    },
    //### 設定參數值
    getContainer: function () {
        // 綠界提供：
        //var script = document.getElementsByTagName("script");
        //script = script[script.length - 1];

        //this.dataMerchantId = script.getAttribute("data-MerchantId");
        //this.dataSPToken = script.getAttribute("data-SPToken");
        //this.dataPaymentName = script.getAttribute("data-PaymentName");
        //this.dataPaymentType = script.getAttribute("data-PaymentType");
        //this.dataCustomerBtn = script.getAttribute("data-CustomerBtn");
        //this.div = script.parentElement;

        // 20188/10/24自行修改：
        var scripts = document.getElementsByTagName('script');
        for (var i = 0, l = scripts.length; i < l; i++) {
            if (scripts[i].getAttribute('data-PaymentType') === 'CREDIT' ||
                scripts[i].getAttribute('data-PaymentType') === 'ATM' ||
                scripts[i].getAttribute('data-PaymentType') === 'CVS') {
                if (!green.includes(scripts[i].getAttribute('data-PaymentType'))) {
                    this.dataMerchantId = scripts[i].getAttribute("data-MerchantId");
                    this.dataSPToken = scripts[i].getAttribute("data-SPToken");
                    this.dataPaymentName = scripts[i].getAttribute("data-PaymentName");
                    this.dataPaymentType = scripts[i].getAttribute("data-PaymentType");
                    this.dataCustomerBtn = scripts[i].getAttribute("data-CustomerBtn");
                    this.div = scripts[i].parentElement;
                    green.push(scripts[i].getAttribute('data-PaymentType'));
                    break;
                }
            }
        }
    },
    //### 建立Button按鈕
    createPayButton: function () {
        //使用客製化按鈕 不用幫忙創建按鈕
        if (ECPay.dataCustomerBtn == 1) {
            BtnDecorator(ECPay);
        }
        //else if (ECPay.IsMobileAgent) {
        //    PayBtn(ECPay);
        //}
        else {
            BtnDecorator(ECPay);
            PayBtn(ECPay);
        }
    },
    //### 初始化Iframe設定值
    createModal: function () {
        //如果是Pc才需創建Iframe
        //if (!ECPay.IsMobileAgent) {
        var iframe = document.createElement("iframe");
        iframe.setAttribute("id", "iframeECPay_" + ECPay.dataPaymentType);
        iframe.frameborder = 0;
        iframe.allowtransparency = true;
        iframe.setAttribute("style", "z-index: 2147483646; display: none; background: rgba(0, 0, 0, 0.00392157); border: 0px none transparent; overflow-x: hidden; overflow-y: auto; visibility: visible;padding: 0px; -webkit-tap-highlight-color: transparent; position: fixed; left: 50%; top: 50%; width: 710px; height: 700px;margin-left:-375px;margin-top:-300px;");

        //測試環境轉正式環境

        //測試
        //iframe.src = domain + "/SP/SPCheckOut?MerchantID=" + ECPay.dataMerchantId + "&SPToken=" + ECPay.dataSPToken + "&PaymentType=" + ECPay.dataPaymentType;
        //正式
        iframe.src = domain + "/SP/SPCheckOut?MerchantID=" + ECPay.dataMerchantId + "&SPToken=" + ECPay.dataSPToken + "&PaymentType=" + ECPay.dataPaymentType + "&ts=" + Date.now();

        this.div.appendChild(iframe);
        this.modalBody = iframe;
        return;
        //}
    }
}

function checkOut(Data) {
    //if (ECPay.IsMobileAgent) {
    //    var url = domain + "/SP/SPCheckOut?MerchantID=" + ECPay.dataMerchantId + "&SPToken=" + ECPay.dataSPToken + "&PaymentType=" + Data;
    //    window.open(url);
    //    return;
    //}
    document.getElementById("iframeECPay_" + Data).style.display = "block";
    document.getElementById("iframeECPayClose_" + Data).style.display = "block";
    document.getElementById("DivECPay_" + Data).style.display = "block";
}

function CloseIframe(Data) {
    document.getElementById("iframeECPay_" + Data).style.display = "none";
    document.getElementById("iframeECPayClose_" + Data).style.display = "none";
    document.getElementById("DivECPay_" + Data).style.display = "none";
}

//正式
window.onload = ECPay.init();
//測試
//ECPay.init();
