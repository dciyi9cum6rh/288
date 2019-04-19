let jPurchaseId, jPurchaseIdDetail, jPurchaseDetailId;
function Purchasefunction(option) {
    var setting = {
        dt: '',
        GetPurchaseListUrl: '',
        GetPurchaseDetailListUrl: '',
        GetPurchaseDetailListNoButtonUrl: '',
        GetCurrencyUrl: '',
        GetNewPurchaseIdUrl: '',
        PostPurchaseUrl: '',
        ValidateProductUrl: '',
        PostPurchaseDetailUrl: '',
        GetCurrencyAndPurchaseUrl: '',
        PutPurchaseUrl: '',
        DeletePurchaseUrl: '',
        DeletePurchaseDetailUrl: ''
    };
    setting = $.extend(setting, option);
    $(window).keydown(function (event) {
        if (event.keyCode === 13) {
            event.preventDefault();
            return false;
        }
    });
    // 1.使用者在進貨管理首頁輸入進貨單號/商品名稱/進貨日期並按查詢。
    $(document).on('click', '#btnSearchPurchase', function (event) {
        event.preventDefault();
        // 2.系統將1輸入資料暫存至jPurchaseId/jsDate/jeDate/jProduct。
        jPurchaseId = $('#PurchaseId').val();
        jsDate = $('#sDate').val();
        jeDate = $('#eDate').val();
        jProduct = $('#Product').val();
        // 3.系統以ajax呼叫Get Action【Purchase/GetPurchaseList】，並傳送jPurchaseId/jsDate/jeDate/jProduct。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetPurchaseListUrl,
            data: {
                'sDate': jsDate,
                'eDate': jeDate,
                'Product': jProduct,
                'PurchaseId': jPurchaseId
            },
            beforeSend: LoadBefore,
            success: GetPurchaseListSuccess,
            error: SystemError
        });
    });
    // 1.使用者在進貨清單點按換頁連結。
    $(document).on('click', '.page-link', function (event) {
        event.preventDefault();
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 3.系統以ajax呼叫Get Action【Purchase/GetPurchaseList】，並傳送jPurchaseId/jsDate/jeDate/jProduct以及1點按頁碼。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetPurchaseListUrl,
            data: {
                'sDate': jsDate,
                'eDate': jeDate,
                'Product': jProduct,
                'PurchaseId': jPurchaseId,
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1])
            },
            beforeSend: LoadBefore,
            success: GetPurchaseListSuccess,
            error: SystemError
        });
    });
    // 1.在進貨管理首頁點按某一筆進貨單之進貨清單/隠藏。
    $(document).on('click', '.btn-detail', function (event) {
        event.preventDefault();
        var $this = $(this);
        // 1-1.系統將1點按進貨單Id暫存在jPurchaseId。
        jPurchaseIdDetail = $this.closest("tr").find("td:eq(1)").text();
        $tr = $this.closest("tr");
        if ($this.find("span").first().hasClass("glyphicon-minus")) {
            //2a.系統判斷javascript變數IsSpread=true。
            //2a-1.系統清除下一個<tr>之html()，以隠藏下線之下線清單。
            $(this).closest("tr").next().html('');
            //2a-2.系統設定javascript變數IsSpread=false。
            //isSpread = false;
            //2a-3.系統設定展開按鈕圖示為+(展開)。
            $this.find("span").attr('title', '進貨清單');
            $this.find("span").first().removeClass();
            $this.find("span").first().addClass('glyphicon glyphicon-th-list');
            //2a-4.結束。
            return;
        }
        // 2.系統判斷javascript變數IsSpread=false(預設值為false)。
        // 3.系統以ajax呼叫Post Controller Action【Purchase/GetPurchaseDetailList】，並傳送jPurchaseId。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetPurchaseDetailListNoButtonUrl,
            data: {
                'PurchaseId': jPurchaseIdDetail,
                'AClass': 'inner-page-link'
            },
            beforeSend: ExpandBefore,
            success: ExpandSuccess,
            error: SystemError
        });

        function ExpandBefore() { }

        function ExpandSuccess(response) {
            // 10.系統在3啟動之ajax回呼函式中將下一列<tr>的Html內容更新為9-7.系統回傳View。
            $this.closest("tr").next().html('<td colspan="11">' + response + '</td>');
            // 10-1.系統設定javascript變數IsSpread=true。
            //isSpread = true;
            // 10-2.系統設定展開按鈕圖示為-(隱藏)。
            $this.find("span").attr('title', '隠藏');
            $this.find("span").first().removeClass();
            $this.find("span").first().addClass('glyphicon glyphicon-minus');
            // 11.結束。
        }
    });
    // 1.使用者在進貨清單點按換頁連結。
    $(document).on('click', '.inner-page-link', function (event) {
        //alert("");
        event.preventDefault();
        var $this = $(this);
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 3.系統以ajax呼叫Post Controller Action【Purchase/GetPurchaseDetailList】，並傳送jPurchaseId與1點按頁碼。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: href[0],
            data: {
                'PurchaseId': jPurchaseIdDetail,
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
    // 1.使用者在進貨管理首頁點按新增。
    $(document).on('click', '#btnAddPurchase', function (event) {
        event.preventDefault();
        // 1-1.系統以ajax呼叫Get Action[Purchase/GetCurrency]。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'json',
            url: setting.GetCurrencyUrl,
            beforeSend: LoadBefore,
            success: GetCurrencySuccess,
            error: SystemError
        });
        function GetCurrencySuccess(response) {
            // 2.系統將今日日期顯示在[進貨日期]<input>，並將1-3傳回值顯示在幣別<Select>。
            $('#add-one input').val('');
            $('#add-one textarea').val('');
            $('#PurcaseProductList').html('');
            $('#CreateSubmit').prop('disabled', false);
            $('#EditSubmit').prop('disabled', true);
            $('#PurchaseTime').val(setting.dt);
            $('#ProductFeeT').val(0);
            $('#TotalExpenseNT').val(0);
            var doc = '';
            for (var item in response) {
                doc += '<option value="' + response[item].currencyId + '">' + response[item].currency + '</option>';
            }
            $('#CurrencyId').html(doc);
            // 3.系統顯示[新增商品]對話盒。
            $('#add-one').modal({ backdrop: "static" });
            $('#InsertProduct').prop("disabled", true);
        }
    });
    // 5.使用者點按確定新增。
    var $CreateSubmit;
    $('#CreateSubmit').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmit = $(this);
        // 6.系統驗証4輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            PurchaseTime: $('#PurchaseTime').val(),
            CurrencyId: $('#CurrencyId').val(),
            ExchangeRate: $('#ExchangeRate').val(),
            miscellaneous: $('#miscellaneous').val(),
            Freight: $('#Freight').val()
        };

        var msgObj = {
            PurchaseTime: "進貨日期必填！",
            CurrencyId: "幣別必填！",
            ExchangeRate: "滙率必填！",
            miscellaneous: "雜費必填！",
            Freight: "運費必填！"
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
            // 6-1.系統以ajax呼叫Get Action[Purchase/GetNewPurchaseId]，並上傳4輸入進貨日期。
            $.ajax({
                type: 'Post',
                cache: false,
                dataType: 'text',
                url: setting.GetNewPurchaseIdUrl,
                data: {
                    'PurchaseTime': $('#PurchaseTime').val()
                }, beforeSend: LoadBefore,
                success: GetNewPurchaseIdSuccess,
                error: SystemError
            });
        }

        $CreateSubmit.prop("disabled", false);

        function GetNewPurchaseIdSuccess(response) {
            // 6-6.系統在6-1啟動之以ajax呼叫Post Action【Purchase/PostPurchase】，
            // 並傳送4輸入資料以及1-5回傳PurchaseId
            $("#PurchaseIdP").val(response);
            $.ajax({
                type: 'Post',
                cache: false,
                url: setting.PostPurchaseUrl,
                data: {
                    'PurchaseId': $('#PurchaseIdP').val(),
                    'PurchaseTime': $('#PurchaseTime').val(),
                    'CurrencyId': $('#CurrencyId option:selected').val(),
                    'ExchangeRate': $('#ExchangeRate').val(),
                    'Freight': $('#Freight').val(),
                    'miscellaneous': $('#miscellaneous').val(),
                    'ProductFee': $('#ProductFeeT').val()
                }, beforeSend: LoadBefore,
                success: CreateSuccess,
                error: SystemError
            });
        }

        function CreateSuccess(response) {
            if (response === 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示新增成功。
                alert("新增成功！");
                // 14.系統設定進貨總成本(台幣)=(運費+雜費+商品費用)/*滙率。
                let TotalExpenseNT = (parseFloat($('#Freight').val()) +
                    parseFloat($('#miscellaneous').val()) +
                    parseFloat($('#ProductFeeT').val())) *
                    parseFloat($('#ExchangeRate').val());
                $('#TotalExpenseNT').val(TotalExpenseNT);
            }
            else if (response === 1) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==1
                //  12a-1.系統顯示無此權限。
                alert("無此權限！");
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/3
                //  12c-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    // 1.在進貨管理新增/修改視窗中輸入下列欄位並點按驗証商品。
    $(document).on('click', '#ValidateProduct', function (event) {
        event.preventDefault();
        // 1-1.系統驗証輸入資料無誤。
        var status = true;
        if (($('#ProductId').val() === "" || $('#ProductId').val() === null) && ($('#ProductP').val() === "" || $('#ProductP').val() === null)) {
            // 驗証失敗
            alert("商品代碼與商品名稱至少必須輸入一項！");
            return;
        }
        // 1-2.系統以ajax呼叫Post Action[Purchase/ValidateProduct]，並傳送1輸入資料。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'json',
            data: {
                'ProductId': $('#ProductId').val(),
                'Product': $('#ProductP').val()
            },
            url: setting.ValidateProductUrl,
            beforeSend: LoadBefore,
            success: ValidateProductSuccess,
            error: SystemError
        });
        function ValidateProductSuccess(response) {
            if (response.err === 1) {
                // 2a.系統判斷1-7回傳err==1。
                //  2a-1.系統顯示"'無效商品代碼或名稱！"。
                alert("無效商品代碼或名稱！");
                //  2a-2.系統設定新增商品按鈕.disabled設為true。
                $('#InsertProduct').prop("disabled", true);
                //  2a-3.結束。
                return;
            }
            // 2.系統判斷1-7回傳err!=1。
            // 3.系統在[商品代碼]與[商品名稱]輸入盒中顯示1-7回傳值，[尺寸]/[顏色]Select內容設為1-7傳回值，新增商品按鈕.disabled設為false。
            $('#ProductId').val(response.product.productId);
            $('#ProductP').val(response.product.product);
            let doc = '';
            for (let item in response.productSize) {
                doc += '<option value="' + response.productSize[item].producSizeId + '">' + response.productSize[item].productSize + '</option>';
            }
            $('#ProducSizeId').html(doc);
            doc = '';
            for (let item in response.productColor) {
                doc += '<option value="' + response.productColor[item].productColorId + '">' + response.productColor[item].productColor + '</option>';
            }
            $('#ProductColorId').html(doc);
            $('#InsertProduct').prop("disabled", false);
        }
    });
    // 5.在進貨管理新增/修改視窗中點按新增商品。
    $(document).on('click', '#InsertProduct', function (event) {
        event.preventDefault();
        if ($('#PurchaseIdP').val() === '' || $('#PurchaseIdP').val() === null) {
            alert("請先新增進貨單再新增商品！");
            return;
        }
        $(this).prop("disabled", true);
        $CreateSubmit = $(this);
        // 6.系統驗証4輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            ProducSizeId: $('#ProducSizeId').val(),
            ProductColorId: $('#ProductColorId').val(),
            PurchasePrice: $('#PurchasePrice').val(),
            Quantity: $('#Quantity').val()
        };

        var msgObj = {
            ProducSizeId: "商品尺寸必填！",
            ProductColorId: "商品顏色必填！",
            PurchasePrice: "商品進價必填！",
            Quantity: "進貨數量必填！"
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
            // 6-1.系統在6-1啟動之以ajax呼叫Post Action【Purchase/PostPurchaseDetail】，並傳送4輸入資料以及輸入盒PurchaseId/ExchangeRate的內容。
            $.ajax({
                type: 'Post',
                cache: false,
                async: false,
                url: setting.PostPurchaseDetailUrl,
                data: {
                    'PurchaseId': $('#PurchaseIdP').val(),
                    'ProductId': $('#ProductId').val(),
                    'ProducSizeId': $('#ProducSizeId option:selected').val(),
                    'ProductColorId': $('#ProductColorId option:selected').val(),
                    'PurchasePrice': $('#PurchasePrice').val(),
                    'Quantity': $('#Quantity').val(),
                    'ExchangeRate': $('#ExchangeRate').val()
                }, beforeSend: LoadBefore,
                success: PostPurchaseDetailSuccess,
                error: SystemError
            });
            // 14-1.系統以ajax呼叫Post Controller Action【Purchase/GetPurchaseDetailList】，並傳送jPurchaseId。
            //setTimeout(function () {
            //    $.ajax({
            //        type: 'Post',
            //        cache: false,
            //        dataType: 'HTML',
            //        url: setting.GetPurchaseDetailListUrl,
            //        data: {
            //            'PurchaseId': $('#PurchaseIdP').val(),
            //            'AClass': 'inner-page-link-purchase'
            //        },
            //        beforeSend: LoadBefore,
            //        success: GetPurchaseDetailSuccess,
            //        error: SystemError
            //    });
            //}, 200);
        }

        $CreateSubmit.prop("disabled", false);

        function PostPurchaseDetailSuccess(response) {
            if (response === 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示新增成功。
                alert("新增成功！");
                $.ajax({
                    type: 'Post',
                    cache: false,
                    dataType: 'HTML',
                    url: setting.GetPurchaseDetailListUrl,
                    data: {
                        'PurchaseId': $('#PurchaseIdP').val(),
                        'AClass': 'inner-page-link-purchase'
                    },
                    beforeSend: LoadBefore,
                    success: GetPurchaseDetailSuccess,
                    error: SystemError
                });
            }
            else if (response === 1) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==1
                //  12a-1.系統顯示無此權限。
                alert("無此權限！");
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/3
                //  12c-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    // 在新增/修改進貨單視窗中點按商品換頁時
    $(document).on('click', '.inner-page-link-purchase', function (event) {
        //alert("");
        event.preventDefault();
        var $this = $(this);
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 3.系統以ajax呼叫Post Controller Action【Purchase/GetPurchaseDetailList】，並傳送jPurchaseId與1點按頁碼。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetPurchaseDetailListUrl,
            data: {
                'PurchaseId': $('#PurchaseIdP').val(),
                'Page': parseInt(page[1]),
                'StartPage': parseInt(startPage[1]),
                'AClass': 'inner-page-link-purchase'
            },
            beforeSend: LoadBefore,
            success: GetPurchaseDetailPageSuccess,
            error: SystemError
        });
    });
    // 1.使用者在進貨清單點按某一列進貨單之修改。
    $(document).on('click', '.btn-edit', function (event) {
        event.preventDefault();
        jPurchaseIdDetail = $(this).closest("tr").find("td:eq(1)").text();
        // 1-1.系統以ajax呼叫Post Action[Purchase/GetCurrencyAndPurchase]，並傳送1點按列之PurchaseId(jPurchaseIdDetail)。
        $.ajax({
            type: 'Get',
            cache: false,
            dataType: 'json',
            url: setting.GetCurrencyAndPurchaseUrl,
            data: {
                'PurchaseId': jPurchaseIdDetail
            },
            beforeSend: LoadBefore,
            success: GetCurrencyAndPurchaseSuccess,
            error: SystemError
        });
        function GetCurrencyAndPurchaseSuccess(response) {
            // 2.系統將今日日期顯示在[進貨日期]<input>，並將1-3傳回值顯示在幣別<Select>。
            $('#add-one input').val('');
            $('#add-one textarea').val('');
            $('#PurcaseProductList').html('');
            //$('#CreateSubmit').prop('disabled', false);
            //$('#EditSubmit').prop('disabled', true);
            // 2.系統在1-1啟動之ajax回呼函式中依1-4傳回值更新下列資料：
            //  	1-4傳回值之currency顯示在幣別<Select>。
            var doc = '';
            for (var item in response.currency) {
                doc += '<option value="' + response.currency[item].currencyId + '">' + response.currency[item].currency + '</option>';
            }
            $('#CurrencyId').html(doc);
            //  	進貨單號。
            $('#PurchaseIdP').val(response.purchase.purchaseId);
            //  	進貨日期。
            $('#PurchaseTime').val(response.purchase.purchaseTime);
            //  	運費。
            $('#Freight').val(response.purchase.freight);
            //  	雜費。
            $('#miscellaneous').val(response.purchase.miscellaneous);
            //  	商品總費用。
            $('#ProductFeeT').val(response.purchase.productFee);
            //  	幣別。
            $('#CurrencyId').val(response.purchase.currencyId);
            //  	滙率。
            $('#ExchangeRate').val(response.purchase.exchangeRate);
            //  	進貨總費用(台幣)。
            $('#TotalExpenseNT').val(response.purchase.totalExpenseNT);
        }
        // 2-1.系統以ajax呼叫Post Controller Action【Purchase/GetPurchaseDetailList】，並傳送jPurchaseIdDetail。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetPurchaseDetailListUrl,
            data: {
                'PurchaseId': jPurchaseIdDetail,
                'AClass': 'inner-page-link-purchase'
            },
            beforeSend: LoadBefore,
            success: GetPurchaseDetailPageSuccess,
            error: SystemError
        });
        // 3.系統顯示[修改商品]對話盒。
        $('#add-one').modal({ backdrop: "static" });
        //  3-1.系統禁能[新增進貨單]/[新增商品]，致能[修改進貨單]。
        $('#InsertProduct').prop("disabled", true);
        $('#CreateSubmit').prop("disabled", true);
        $('#EditSubmit').prop("disabled", false);
    });
    // 5.使用者點按確定修改。
    $('#EditSubmit').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmit = $(this);
        // 6.系統驗証4輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            PurchaseTime: $('#PurchaseTime').val(),
            CurrencyId: $('#CurrencyId').val(),
            ExchangeRate: $('#ExchangeRate').val(),
            miscellaneous: $('#miscellaneous').val(),
            Freight: $('#Freight').val()
        };

        var msgObj = {
            PurchaseTime: "進貨日期必填！",
            CurrencyId: "幣別必填！",
            ExchangeRate: "滙率必填！",
            miscellaneous: "雜費必填！",
            Freight: "運費必填！"
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
            // 6-1.系統以ajax呼叫Post Action【Purchase/PutPurchase】，並傳送4輸入資料以及jPurchaseIdDetail。
            $.ajax({
                type: 'Post',
                cache: false,
                url: setting.PutPurchaseUrl,
                data: {
                    'PurchaseId': $('#PurchaseIdP').val(),
                    'PurchaseTime': $('#PurchaseTime').val(),
                    'CurrencyId': $('#CurrencyId option:selected').val(),
                    'ExchangeRate': $('#ExchangeRate').val(),
                    'Freight': $('#Freight').val(),
                    'miscellaneous': $('#miscellaneous').val(),
                    'ProductFee': $('#ProductFeeT').val()
                }, beforeSend: LoadBefore,
                success: EditSuccess,
                error: SystemError
            });
        }

        $CreateSubmit.prop("disabled", false);

        function EditSuccess(response) {
            if (response === 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示修改成功。
                alert("修改成功！");
                // 14.系統設定進貨總成本(台幣)=(運費+雜費+商品費用)/*滙率。
                let TotalExpenseNT = (parseFloat($('#Freight').val()) +
                    parseFloat($('#miscellaneous').val()) +
                    parseFloat($('#ProductFeeT').val())) *
                    parseFloat($('#ExchangeRate').val());
                $('#TotalExpenseNT').val(TotalExpenseNT);
            }
            else if (response === 1) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==1
                //  12a-1.系統顯示無此權限。
                alert("無此權限！");
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/3
                //  12c-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    // 1.使用者點按某一列進貨單之刪除。
    let $selecteditadmin;
    $(document).on('click', '.btn-delete', function (event) {
        if (!confirm('確定刪除？')) return;
        // 2.使用者確認要刪除。
        var $this = $(this);
        $selecteditadmin = $this.closest('tr');
        jPurchaseIdDetail = $(this).closest("tr").find("td:eq(1)").text();
        // 3.系統以ajax呼叫Post Action【Product/DeletePurchase】，並傳送1點按列之jPurchaseIdDetail。
        $.ajax({
            type: 'POST',
            cache: false,
            url: setting.DeletePurchaseUrl,
            data: { "PurchaseId": jPurchaseIdDetail },
            beforeSend: LoadBefore,
            success: DeleteSuccess,
            error: SystemError
        });

        function DeleteSuccess(response) {
            if (response == 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                alert('刪除成功');
                // 8.系統將刪除列自管理者清單列中去除。
                $selecteditadmin.html('');
            }
            else if (response == 2) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                //  12a-1.系統顯示"無此權限"。
                alert('無此權限！');
                //  13b-2.結束。
            }
            else if (response == 3) {
                // 12b.系統在6啟動之ajax回呼函式中判斷11傳回值==3
                //  12a-1.系統顯示有子分類。
                alert('無法刪除有子分類之分類！');
                //  13b-2.結束。
            }
            else if (response == 4) {
                // 12d.系統在6啟動之ajax回呼函式中判斷11傳回值==4
                //  12d-1.系統顯示有商品。
                alert('無法刪除有商品之分類！');
                //  13b-2.結束。
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/2
                //  13c-1.系統顯示"刪除失敗"。
                alert('刪除失敗，請稍後再試！');
                //  13a-2.結束。
            }
        }
    });
    // 1.使用者點按某一列進貨單商品之刪除。
    $(document).on('click', '.btn-delete-detaill', function (event) {
        if (!confirm('確定刪除？')) return;
        // 2.使用者確認要刪除。
        var $this = $(this);
        $selecteditadmin = $this.closest('tr');
        jPurchaseIdDetail = $(this).data("purchaseid");
        jPurchaseDetailId = $(this).data("purchasedetaiid");
        // 3.系統以ajax呼叫Post Action【Product/DeletePurchaseDetail】，並傳送1點按列之PurchaseDetailId。
        $.ajax({
            type: 'POST',
            cache: false,
            url: setting.DeletePurchaseDetailUrl,
            data: { "PurchaseId": jPurchaseIdDetail, "PurchaseDetailId": jPurchaseDetailId },
            beforeSend: LoadBefore,
            success: DeletePurchaseDetailSuccess,
            error: SystemError
        });

        function DeletePurchaseDetailSuccess(response) {
            if (response == 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                alert('刪除成功');
                // 8.系統將刪除列自管理者清單列中去除。
                $selecteditadmin.html('');
                //// 15.系統設定下列輸入盒內容：
                ////  	商品費用。
                //$('#ProductFee').val(parseFloat($('#PurchasePrice').val()) * parseFloat($('#Quantity').val()));
                ////  	商品費用(台幣)。
                //$('#ProductFeeNT').val(parseFloat($('#ProductFee').val()) * parseFloat($('#ExchangeRate').val()));
                ////  	進貨商品總費用。
                //$('#ProductFeeT').val(parseFloat($('#ProductFeeT').val()) + parseFloat($('#ProductFee').val()));
                ////  	進貨總費用(台幣) = (運費 + 雜費 + 商品總費用)/*滙率。
                //$('#TotalExpenseNT').val(parseFloat($('#TotalExpenseNT').val()) + parseFloat($('#ProductFeeNT').val()));
            }
            else if (response == 2) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                //  12a-1.系統顯示"無此權限"。
                alert('無此權限！');
                //  13b-2.結束。
            }
            else if (response == 3) {
                // 12b.系統在6啟動之ajax回呼函式中判斷11傳回值==3
                //  12a-1.系統顯示有子分類。
                alert('無法刪除有子分類之分類！');
                //  13b-2.結束。
            }
            else if (response == 4) {
                // 12d.系統在6啟動之ajax回呼函式中判斷11傳回值==4
                //  12d-1.系統顯示有商品。
                alert('無法刪除有商品之分類！');
                //  13b-2.結束。
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/2
                //  13c-1.系統顯示"刪除失敗"。
                alert('刪除失敗，請稍後再試！');
                //  13a-2.結束。
            }
        }
    });
}
function GetPurchaseListSuccess(response) {
    // 10.系統在3啟動之ajax呼叫回呼函式中將<Div PurchaseList>.Html()更新為9-7回傳View。
    $('Div#PurchaseList').html(response);
    // 11.結束。
}
function LoadBefore() { }
function SystemError() {
    alert('系統錯誤，請稍後再試！');
}
function GetPurchaseDetailSuccess(response) {
    // 14-2.系統在3啟動之ajax回呼函式中將<Div PurcaseProductList>Html內容更新為9-7.系統回傳View。
    $('#PurcaseProductList').html(response);
    // 15.系統設定下列輸入盒內容：
    //  	商品費用。
    $('#ProductFee').val(parseFloat($('#PurchasePrice').val()) * parseFloat($('#Quantity').val()));
    //  	商品費用(台幣)。
    $('#ProductFeeNT').val(parseFloat($('#ProductFee').val()) * parseFloat($('#ExchangeRate').val()));
    //  	進貨商品總費用。
    $('#ProductFeeT').val(parseFloat($('#ProductFeeT').val()) + parseFloat($('#ProductFee').val()));
    //  	進貨總費用(台幣) = (運費 + 雜費 + 商品總費用)/*滙率。
    $('#TotalExpenseNT').val(parseFloat($('#TotalExpenseNT').val()) + parseFloat($('#ProductFeeNT').val()));
    // 16.結束。
}
function GetPurchaseDetailPageSuccess(response) {
    // 14-2.系統在3啟動之ajax回呼函式中將<Div PurcaseProductList>Html內容更新為9-7.系統回傳View。
    $('#PurcaseProductList').html(response);
    // 16.結束。
}