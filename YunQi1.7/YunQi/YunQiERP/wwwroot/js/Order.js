let jOrderId, jOrderIdDetail, jOrderDetailId;
let jsDate, jeDate, jProduct, jOrderStateId, jMemberMobile;
function Orderfunction(option) {
    var setting = {
        GetOrderListUrl: '',
        GetOrderDetailListUrl: '',
        GetOrderDetailListNoButtonUrl: '',
        GetOrderStateUrl: '',
        GetOrderDataUrl: '',
        PostShipmentUrl: '',
        ValidateProductUrl: '',
        PostOrderDetailUrl: '',
        GetCurrencyAndOrderUrl: '',
        PutOrderUrl: '',
        DeleteOrderUrl: '',
        DeleteOrderDetailUrl: '',
        UpdateOrderStateIdUrl: '',
        GetCancelOrderState: '',
    };
    setting = $.extend(setting, option);

    //20181213 ---棋
    //使用者在某一項商品列點選 取消訂單
    $(document).on('click', '.btn-Exchange', function (event) {
        event.preventDefault();
        if (!confirm('確定是否銷貨退回？')) return;

        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetCancelOrderState,
            data: {
                orderId: $(this).data('orderid'),
            },
            beforeSend: LoadBefore,
            success: GetOrderStateSuccess,
            error: SystemError
        });

        function GetOrderStateSuccess(response) {
            response == -1 ? (alert('系統錯誤，請稍後再試！')) : ("");
            response == 0 ? (alert("銷貨退回成功 !")) : ("");
            response == 2 ? (alert("查無此訂單 ! ")) : ("");
        }
    });

    // 1.使用者在銷貨管理首頁輸入銷貨單號/銷貨日期/會員帳號/訂單狀態/產品名稱並按查詢。
    $(document).on('click', '#btnSearchOrder', function (event) {
        event.preventDefault();
        // 2.系統將1輸入資料暫存至jOrderId/jsDate/jeDate/jMemberMobile/jOrderStateId/jProduct。
        jOrderId = $('#OrderId').val();
        jsDate = $('#sDate').val();
        jeDate = $('#eDate').val();
        jProduct = $('#Product').val();
        jOrderStateId = $('#OrderState').val();
        jMemberMobile = $('#MemberMobile').val();
        // 3.系統以ajax呼叫Get Action【Order/GetOrderList】，並傳送jOrderId/jsDate/jeDate/jMemberMobile/jOrderStateId/jProduct。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetOrderListUrl,
            data: {
                'sDate': jsDate,
                'eDate': jeDate,
                'Product': jProduct,
                'OrderId': jOrderId,
                'MemberMobile': jMemberMobile,
                'OrderStateId': jOrderStateId
            },
            beforeSend: LoadBefore,
            success: GetOrderListSuccess,
            error: SystemError
        });
    });
    // 1.使用者在銷貨清單點按換頁連結。
    $(document).on('click', '.page-link', function (event) {
        event.preventDefault();
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 3.系統以ajax呼叫Get Action【Order/GetOrderList】，並傳送jOrderId/jsDate/jeDate/jMemberMobile/jOrderStateId/jProduct。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetOrderListUrl,
            data: {
                'sDate': jsDate,
                'eDate': jeDate,
                'Product': jProduct,
                'OrderId': jOrderId,
                'MemberMobile': jMemberMobile,
                'OrderStateId': jOrderStateId,
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1])
            },
            beforeSend: LoadBefore,
            success: GetOrderListSuccess,
            error: SystemError
        });
    });
    let $tr;
    // 1.在銷貨管理首頁點按某一筆銷貨單之銷貨清單/隠藏。
    $(document).on('click', '.btn-detail', function (event) {
        event.preventDefault();
        var $this = $(this);
        // 1-1.系統將1點按銷貨單Id暫存在jOrderId。
        jOrderIdDetail = $this.closest("tr").find("td:eq(1)").text();
        $tr = $this.closest("tr");
        if ($this.find("span").first().hasClass("glyphicon-minus")) {
            //2a.系統判斷javascript變數IsSpread=true。
            //2a-1.系統清除下一個<tr>之html()，以隠藏下線之下線清單。
            $(this).closest("tr").next().html('');
            //2a-2.系統設定javascript變數IsSpread=false。
            //isSpread = false;
            //2a-3.系統設定展開按鈕圖示為+(展開)。
            $this.find("span").attr('title', '銷貨明細');
            $this.find("span").first().removeClass();
            $this.find("span").first().addClass('glyphicon glyphicon-th-list');
            //2a-4.結束。
            return;
        }
        // 2.系統判斷javascript變數IsSpread=false(預設值為false)。
        // 3.系統以ajax呼叫Post Controller Action【Order/GetOrderDetailListNoButton】，並傳送jOrderId與1點按頁碼。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetOrderDetailListNoButtonUrl,
            data: {
                'OrderId': jOrderIdDetail,
                'AClass': 'inner-page-link'
            },
            beforeSend: ExpandBefore,
            success: ExpandSuccess,
            error: SystemError
        });

        function ExpandBefore() { }

        function ExpandSuccess(response) {
            console.log(response);
            // 10.系統在3啟動之ajax回呼函式中將下一列<tr>的Html內容更新為9-7.系統回傳View。
            $this.closest("tr").next().html('<td colspan="10">' + response + '</td>');
            // 10-1.系統設定javascript變數IsSpread=true。
            //isSpread = true;
            // 10-2.系統設定展開按鈕圖示為-(隱藏)。
            $this.find("span").attr('title', '隠藏');
            $this.find("span").first().removeClass();
            $this.find("span").first().addClass('glyphicon glyphicon-minus');
            // 11.結束。
        }
    });
    // 1.使用者在銷貨清單明細點按換頁連結。
    $(document).on('click', '.inner-page-link', function (event) {
        //alert("");
        event.preventDefault();
        var $this = $(this);
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 3.系統以ajax呼叫Post Controller Action【Order/GetOrderDetailListNoButton】，並傳送jOrderId與1點按頁碼。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: href[0],
            data: {
                'OrderId': jOrderIdDetail,
                'Page': parseInt(page[1]),
                'StartPage': parseInt(startPage[1]),
                'AClass': 'inner-page-link'
            },
            beforeSend: LoadBefore,
            success: ExpandInnerSuccess,
            error: SystemError
        });
        function ExpandInnerSuccess(response) {
            // 10.系統在3啟動之ajax回呼函式中將下一列<tr>的Html內容更新為9-7.系統回傳View。
            $tr.next().html('<td colspan="11">' + response + '</td>');
            // 11.結束。
        }
    });
    // 在新增/修改銷貨單視窗中點按商品換頁時
    $(document).on('click', '.inner-page-link-Order', function (event) {
        //alert("");
        event.preventDefault();
        var $this = $(this);
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 3.系統以ajax呼叫Post Controller Action【Order/GetOrderDetailList】，並傳送jOrderId與1點按頁碼。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetOrderDetailListUrl,
            data: {
                'OrderId': $('#OrderIdP').val(),
                'Page': parseInt(page[1]),
                'StartPage': parseInt(startPage[1]),
                'AClass': 'inner-page-link-Order'
            },
            beforeSend: LoadBefore,
            success: GetOrderDetailPageSuccess,
            error: SystemError
        });
    });
    // 1.使用者點按某一列銷貨單之狀態。
    let orderId;
    let orderStateId;
    $(document).on('click', '.btn-OrdrState', function (event) {
        event.preventDefault();
        orderId = $(this).data('orderid');
        orderStateId = $(this).data('orderstateid');
        jMemberMobile = $(this).data('membermobile');

        //1-1.系統以ajax呼叫Get Action[Order/GetOrderState]。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'json',
            url: setting.GetOrderStateUrl,
            beforeSend: LoadBefore,
            success: GetOrderStateSuccess,
            error: SystemError
        });
        function GetOrderStateSuccess(response) {
            // 2.系統將今日日期顯示在[進貨日期]<input>，並將1-3傳回值顯示在幣別<Select>。
            $('#add-one input').val('');
            $('#add-one textarea').val('');
            $('#OrderStateP').html('');
            $('#OrderIdP').val(orderId);
            var doc = '';
            //更新20181205 ---棋     1.只有狀態1/2/3可以取消
            for (var o in response) {
                var item = parseInt(response[o].orderStateId);
                if (item == 2 || item == 6 || item == 7) continue;
                if ((orderStateId == 1 && item == 1) || (orderStateId == 1 && item == 4) || (orderStateId == 1 && item == 5)) continue;
                if ((orderStateId == 2 && item == 1) || (orderStateId == 2 && item == 2) || (orderStateId == 2 && item == 4) || (orderStateId == 2 && item == 5)) continue;
                if ((orderStateId == 3 && item == 1) || (orderStateId == 3 && item == 2) || (orderStateId == 3 && item == 3) || (orderStateId == 3 && item == 5)) continue;
                if ((orderStateId == 4 && item == 1) || (orderStateId == 4 && item == 2) || (orderStateId == 4 && item == 3) || (orderStateId == 4 && item == 4) || (orderStateId == 4 && item == 8)) continue;
                if (response[o].orderStateId == orderStateId) {
                    doc += '<option value="' + response[o].orderStateId + '" selected>' + response[o].orderState + '</option>';
                }
                else {
                    doc += '<option value="' + response[o].orderStateId + '">' + response[o].orderState + '</option>';
                }
            }

            $('#OrderStateP').html(doc);
            // 3.系統顯示[新增商品]對話盒。
            $('#add-one').modal({ backdrop: "static" });
        }
    });

    // 5.使用者點按變更狀態。
    var $CreateSubmit;
    $('#CreateSubmit').on('click', function (event) {
        event.preventDefault();
        if (!confirm('確定要變更？')) return;
        $(this).prop("disabled", true);
        $CreateSubmit = $(this);
        // 6.系統驗証4輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            OrderState: $('#OrderStateP').val()
        };

        var msgObj = { OrderState: "訂單狀態必填！" };

        $.each(checkObj, function (name, jobj) {
            if (jobj === "" || jobj === null) {
                status = false;
                error += msgObj[name] + '\r\n';
            }
        });

        if (!status) {
            // 驗証失敗
            alert(error);
        }
        else {
            // 驗証成功
            // 6-1.系統在6-1啟動之以ajax呼叫Post Action【Order/UpdateOrderState】，並傳送4輸入資料以及OrderId。

            //20181204更新  ---棋  修正抓不到值
            OrderId = $('#OrderIdP').val()
            orderStateId = $('#OrderStateP').val();

            $.ajax({
                type: 'Post',
                cache: false,
                dataType: 'text',
                url: setting.UpdateOrderStateIdUrl,
                data: {
                    OrderId: OrderId,
                    OrderStateId: orderStateId,
                    'MemberMobile': jMemberMobile
                },
                beforeSend: LoadBefore,
                success: CreateSuccess,
                error: SystemError,
            });
        }

        $CreateSubmit.prop("disabled", false);

        function CreateSuccess(response) {
            if (response === "0") {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示變更成功。
                alert("變更成功！");
                //20190103 ---棋
                $('#add-one').modal("hide");
                $('#btnSearchOrder').click();
            }
            else if (response === "1") {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==1
                //  12a-1.系統顯示無此權限。
                alert("無此權限！");
            }
            else if (response === "2") {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                //  12a-1.系統顯示無此訂單。
                alert("無此訂單！");
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/2
                //  12c-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });

    // 1.使用者點按某一列銷貨單之出貨單。
    $(document).on('click', '.btn-Shipment', function (event) {
        event.preventDefault();
        orderId = $(this).data('orderid');
        // 1-1.系統以ajax呼叫Get Action[Order/GetOrderData]，並傳送1點按列之OrderId。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'json',
            url: setting.GetOrderDataUrl,
            data: {
                "OrderId": orderId
            },
            beforeSend: LoadBefore,
            success: GetOrderDataSuccess,
            error: SystemError
        });
        function GetOrderDataSuccess(response) {
            // 2.系統在[出貨資料滙出]對話盒中顯示下列資料：
            $('#add-onePU input').val('');
            $('#add-onePU textarea').val('');
            // 	收貨人：1-2讀取資料。
            // 	地址：1-2讀取資料。
            // 	手機：1-2讀取資料。
            // 	收貨人代號：1-2讀取資料。
            // 	貨品內容：1-3讀取資料。
            $('#MemberName').val(response.order.memberName);
            $('#ContactAddress').val(response.order.contactAddress);
            $('#MemberMobileP').val(response.order.mobile);
            $('#MemberId').val(response.order.memberMobile);
            $('#PaymentType').val(response.order.paymentTypeDescription);
            $('#MemberId').val(response.order.memberMobile);
            var doc = '';
            for (var item in response.orderDetail) {
                doc += response.orderDetail[item].product + '.' + response.orderDetail[item].productSize + '.' + response.orderDetail[item].productColor + ' X ' + response.orderDetail[item].quantity + '\n';
            }
            $('#ProductA').val(doc);
            // 3.系統顯示[出貨資料滙出]對話盒。
            $('#add-onePU').modal({ backdrop: "static" });
        }
    });
    // 5.使用者點按滙出。
    $('#CreateSubmitPU').on('click', function (event) {
        event.preventDefault();
        if (!confirm('確定滙出？')) return;
        $(this).prop("disabled", true);
        $CreateSubmit = $(this);
        // 6.系統驗証4輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            MemberName: $('#MemberName').val(),
            ContactAddress: $('#ContactAddress').val(),
            MemberMobile: $('#MemberMobileP').val(),
            Product: $('#ProductA').val()
        };

        var msgObj = {
            MemberName: "收件人必填！",
            ContactAddress: "地址必填！",
            MemberMobile: "手機必填！",
            Product: "貨品內容必填！"
        };

        $.each(checkObj, function (name, jobj) {
            if (jobj === "" || jobj === null) {
                status = false;
                error += msgObj[name] + '\r\n';
            }
        });

        if (!status) {
            // 驗証失敗
            alert(error);
        }
        else {
            // 驗証成功
            // 6-1.系統以ajax呼叫Post Action【Order/PostShipment】，並傳送4輸入資料。
            $.ajax({
                type: 'Post',
                cache: false,
                url: setting.PostShipmentUrl,
                data: {
                    'OrderId': orderId,
                    'MemberName': $('#MemberName').val(),
                    'ContactAddress': $('#ContactAddress').val(),
                    'MemberMobile': $('#MemberMobileP').val(),
                    'Nnuber': $('#Nnuber').val(),
                    'Weight': $('#Weight').val(),
                    'Quantity': $('#Quantity').val(),
                    'Station': $('#Station').val(),
                    'MemberId': $('#MemberId').val(),
                    'ProductNo': $('#ProductNo').val(),
                    'Product': $('#ProductA').val(),
                    'Phone': $('#Phone').val(),
                    'Postal': $('#Postal').val(),
                    'PaymentType': $('#PaymentType').val(),
                    'InsteadReceive': $('#InsteadReceive').val(),
                    'ClearOld': $('#ClearOld').prop('checked'),
                    'Memo': $('#Memo').val()
                },
                beforeSend: LoadBefore,
                success: CreateShipSuccess,
                error: SystemError
            });
        }

        $CreateSubmit.prop("disabled", false);

        function CreateShipSuccess(response) {
            if (response === 0) {
                // 22.系統在6-1啟動之ajax回呼函式中判斷21傳回值==0。
                // 23.系統顯示滙出出貨單成功。
                alert("滙出出貨單成功！");
                //20190103 ---棋
                $('#add-onePU').modal("hide");
                $('#btnSearchOrder').click();
            }
            else if (response === 1) {
                // 22a.系統在6-1啟動之ajax回呼函式中判斷21傳回值==1。
                //  22a-1.系統顯示無此權限。
                alert("無此權限！");
            }
            else if (response === 2) {
                // 22b.系統在6-1啟動之ajax回呼函式中判斷21傳回值==2。
                //  22b-1.系統顯示新增出貨單失敗。
                alert("新增出貨單失敗！");
            }
            else if (response === 3) {
                // 22c.系統在6-1啟動之ajax回呼函式中判斷21傳回值==3。
                //  22c-1.系統顯示更新訂單狀態失敗。
                alert("更新訂單狀態失敗！");
            }
            else if (response === 4) {
                // 22d.系統在6-1啟動之ajax回呼函式中判斷21傳回值==4。
                //  22d-1.系統顯示更新商品庫存失敗。
                alert("更新商品庫存失敗！");
            }
            else if (response === 6) {
                // 22e.系統在6-1啟動之ajax回呼函式中判斷21傳回值==6。
                //  22e-1.系統顯示本訂單己出貨。
                alert("本訂單己出貨！");
            }
            else {
                // 22f.系統在6-1啟動之ajax回呼函式中判斷21傳回值!=0/1/2/3/4。
                //  22f-1.系統顯示系統執行錯誤。
                alert("執行失敗，請稍後再試！");
            }
            // 14.結束。
        }
    });
}
function GetOrderListSuccess(response) {
    // 10.系統在3啟動之ajax呼叫回呼函式中將<Div OrderList>.Html()更新為9-7回傳View。
    $('Div#OrderList').html(response);
    // 11.結束。
}
function LoadBefore() { }
function SystemError() {
    alert('系統錯誤，請稍後再試！');
}
function GetOrderDetailSuccess(response) {
    // 14-2.系統在3啟動之ajax回呼函式中將<Div PurcaseProductList>Html內容更新為9-7.系統回傳View。
    $('#PurcaseProductList').html(response);
    // 15.系統設定下列輸入盒內容：
    //  	商品費用。
    $('#ProductFee').val(parseFloat($('#OrderPrice').val()) * parseFloat($('#Quantity').val()));
    //  	商品費用(台幣)。
    $('#ProductFeeNT').val(parseFloat($('#ProductFee').val()) * parseFloat($('#ExchangeRate').val()));
    //  	銷貨商品總費用。
    $('#ProductFeeT').val(parseFloat($('#ProductFeeT').val()) + parseFloat($('#ProductFee').val()));
    //  	銷貨總費用(台幣) = (運費 + 雜費 + 商品總費用)/*滙率。
    $('#TotalExpenseNT').val(parseFloat($('#TotalExpenseNT').val()) + parseFloat($('#ProductFeeNT').val()));
    // 16.結束。
}
function GetOrderDetailPageSuccess(response) {
    // 14-2.系統在3啟動之ajax回呼函式中將<Div PurcaseProductList>Html內容更新為9-7.系統回傳View。
    $('#PurcaseProductList').html(response);
    // 16.結束。
}