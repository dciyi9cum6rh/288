let jProduct = '';
function Stockfunction(option) {
    var setting = {
        GetStockListUrl: ''
    };
    setting = $.extend(setting, option);
    $(window).keydown(function (event) {
        if (event.keyCode === 13) {
            event.preventDefault();
            return false;
        }
    });
    let jsDate = setting.jsDate, jeDate = setting.jeDate;
    // 1.使用者在庫存盤整記首頁輸入庫存盤整日期與商品名稱並按查詢。。
    $('#btnSearch').on('click', function (event) {
        event.preventDefault();
        // 2.系統將1輸入資料暫存至jsDate/jeDate/jProduct。
        jProduct = $('#Product').val();
        jsDate = $('#sDate').val();
        jeDate = $('#eDate').val();
        var status = true, error = "";
        if (!status) {
            // 驗証失敗
            alert(error);
        }
        else {
            // 3.系統以ajax呼叫Get Action【Stock/GetStockList】，並傳送jsDate/jeDate/jProduct。
            $.ajax({
                type: 'Post',
                cache: false,
                dataType: 'HTML',
                data: {
                    'sDate': jsDate,
                    'eDate': jeDate,
                    'Product': jProduct
                },
                url: setting.GetStockListUrl,
                beforeSend: GetStockListBefore,
                success: GetStockListSuccess,
                error: SystemError
            });
        }
    });
    function GetStockListBefore() { }

    function GetStockListSuccess(response) {
        // 10.系統在3啟動之ajax呼叫回呼函式中將<Div StockList >.Html()更新為9-7回傳View。
        if (response !== null) {
            $('#StockList').html(response);
        }
        else {
            $('#StockList').html('');
        }
    }
    // 1.使用者在ERP系統庫存盤整記錄之庫存盤整記清單點按換頁連結。
    $(document).on('click', '.page-link', function (event) {
        event.preventDefault();
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 3.系統以ajax呼叫Get Action【Stock/GetStockList】，並傳送jsDate/jeDate/jProduct以及1點按頁碼。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            data: {
                'sDate': jsDate,
                'eDate': jeDate,
                'Product': jProduct,
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1])
            },
            url: setting.GetStockListUrl,
            beforeSend: GetStockListBefore,
            success: GetStockListSuccess,
            error: SystemError
        });
    });
}
function GetStockListSuccess(response) {
    // 6.系統在3啟動之ajax呼叫回呼函式中將<Div StockList>.Html()更新為9-7回傳View。
    $('Div#StockList').html(response);
    // 11.結束。
}
function LoadBefore() { }
function SystemError() {
    alert('系統錯誤，請稍後再試！');
}