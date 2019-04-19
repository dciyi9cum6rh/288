let jProductCategoryProduct = '', jProductCategoryIdProduct, jProduct = '', jProductId, jProductImageId, jProducSizeId, jProductColorId;
function Productfunction(option) {
    var setting = {
        jProductCategoryId: 1,
        GetProductCategoryUrl: '',
        GetProductLevelPathUrl: '',
        DeleteProductCategoryUrl: '',
        GetProductListUrl: '',
        GetProductUrl: '',
        DeleteProductUrl: '',
        GetProductImageListUrl: '',
        DeleteProductImageUrl: '',
        SetProductImageUrl: '',
        jsDate: '',
        GetProductSizeUrl: '',
        DeleteProductSizeUrl: '',
        GetProductColorUrl: '',
        DeleteProductColorUrl: '',
        GetProductStockListUrl: '',
        UpdateProductImageOrderUrl: ''
    };
    setting = $.extend(setting, option);
    $(window).keydown(function (event) {
        if (event.keyCode === 13) {
            event.preventDefault();
            return false;
        }
    });
    let jProductCategoryId = setting.jProductCategoryId, jProductCategory;
    // 1.使用者在在商品分類管理首頁輸入分類名稱並點按查詢。
    $(document).on('click', '#btnCategorySearch', function (event) {
        event.preventDefault();
        // 1-1.系統將1輸入之分類名稱暫存在jProductCategory。
        jProductCategory = $('#ProductCategory').val();
        //alert(jProductCategory);
        // 2.系統以ajax呼叫Post Controller Action【Product/GetProductCategory】，並傳送jProductCategoryId與jProductCategory。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetProductCategoryUrl,
            data: {
                'ProductCategoryId': jProductCategoryId,
                'ProductCategory': jProductCategory
            },
            beforeSend: LoadBefore,
            success: GetProductCategorySuccess,
            error: SystemError
        });
    });
    $(document).on('click', '.page-link', function (event) {
        // alert("");
        event.preventDefault();

        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 3.系統以ajax呼叫Get Action【Artist/GetAll】，並上傳1點按之頁碼，以及BorkerBackend03_10主要流程1-1暫存之主類型代碼、次類型代碼、國籍、名稱。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetProductCategoryUrl,
            data: {
                'ProductCategoryId': jProductCategoryId,
                'ProductCategory': jProductCategory,
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1])
            },
            beforeSend: LoadBefore,
            success: GetProductCategorySuccess,
            error: SystemError
        });
    });
    // 1.使用者在商品分類管理首頁點按分類名稱超連結。
    $(document).on('click', 'a.ProductLevelPathList', function (event) {
        event.preventDefault();
        // 1-1.系統設定jProductCategoryId=1點按之data-ProductCategoryId，jProductCategory=''。
        jProductCategoryId = $(this).attr('title');
        jProductCategory = '';
        //alert(jProductCategoryId);
        // 2.系統以ajax呼叫Post Controller Action【Product/GetProductCategory】，並傳送jProductCategoryId與jProductCategory。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetProductCategoryUrl,
            data: {
                'ProductCategoryId': jProductCategoryId,
                'ProductCategory': jProductCategory
            },
            beforeSend: LoadBefore,
            success: GetProductCategorySuccess,
            error: SystemError
        });
        // 10-1.系統以ajax呼叫Post Controller Action【Product/GetProductLevelPath】，並傳送jProductCategoryId。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetProductLevelPathUrl,
            data: {
                'ProductCategoryId': jProductCategoryId
            },
            beforeSend: LoadBefore,
            success: GetProductLevelPathSuccess,
            error: SystemError
        });
    });
    // 1.使用者在商品分類管理首頁點按新增。
    $('#btnCategoryAdd').on('click', function (event) {
        event.preventDefault();
        $('#add-one input').val('');
        $('#add-one textarea').val('');
        // 2.系統顯示[新增商品分類]對話盒。
        $('#CreateForm').attr('Style', '');
        $('#EditForm').attr('Style', 'display: none;');
        $('#add-one').modal({ backdrop: "static" });
    });
    // 4.使用者點按確定新增。
    var $CreateSubmit;
    $('#CreateSubmit').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmit = $(this);
        // 5.系統驗証3輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            ProductCategory: $('#ProductCategoryName').val(),
            ProductCategoryDescription: $('#ProductCategoryDescription').val(),
            PictureContent: $('#PictureContent').val()
        };

        var msgObj = {
            ProductCategory: "商品分類名稱必填！",
            ProductCategoryDescription: "商品分類說明必填！",
            PictureContent: "分類圖示必填！"
        };

        $.each(checkObj, function (name, jobj) {
            if (jobj == "" || jobj == null) {
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
            // 6.系統以ajax呼叫Post Action【Product/AddProductCategory】，並傳送3輸入資料與jProductCategoryId。
            $('#CreateForm').ajaxSubmit({
                data: { "ParentProductCategoryId": jProductCategoryId },
                beforeSubmit: CreateBefore,
                success: CreateSuccess,
                error: SystemError
            });
        }

        $CreateSubmit.prop("disabled", false);

        function CreateBefore() { }

        function CreateSuccess(response) {
            if (response == 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示新增成功。
                alert("新增成功！");
                $('#add-one').modal("hide");
            }
            else if (response == 1) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==1
                //  12a-1.系統顯示無此權限。
                alert("無此權限！");
            }
            else if (response == 2) {
                // 12b.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                // 12b-1.系統顯示分類名稱重覆。
                alert("新增失敗,可能是商品分類名稱重覆！");
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/2
                //  12c-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    // 1.使用者在商品分類管理首頁點按某一列商品分類之修改。
    let $tr;
    let EditProductCategoryId;
    $(document).on('click', '.btn-edit', function (event) {
        event.preventDefault();
        // 先取得點按列之相關資料，做為修改時欄位預設值
        $tr = $(this).closest("tr");
        $('#add-one input').val('');
        $('#add-one textarea').val('');
        // 2.系統顯示[修改商品分類]對話盒，並將1點按列之資料顯示於對應輸入元件。
        $('#EditProductCategoryName').val($tr.find("td:eq(1)").text());
        $('#EditProductCategoryDescription').val($tr.find("td:eq(3)").text());
        EditProductCategoryId = $tr.find("td:eq(0)").text();
        $('#CreateForm').attr('Style', 'display: none;');
        $('#EditForm').attr('Style', '');
        $('#add-one').modal({ backdrop: "static" });
    });
    // 8.使用者按修改。4.使用者點按確定修改。
    var $selecteditadmin;
    var $EditSubmit;
    $('#EditSubmit').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $EditSubmit = $(this);
        // 5.系統驗証3輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            ProductCategory: $('#EditProductCategoryName').val(),
            ProductCategoryDescription: $('#EditProductCategoryDescription').val()
        };

        var msgObj = {
            ProductCategory: "商品分類名稱必填！",
            ProductCategoryDescription: "商品分類說明必填！"
        };

        $.each(checkObj, function (name, jobj) {
            if (jobj == "" || jobj == null) {
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
            // 6.系統以ajax呼叫Post Action【Product/PutProductCategory】，並傳送3輸入資料與1點按列之ProductCategoryId。
            $('#EditForm').ajaxSubmit({
                data: { "ProductCategoryId": EditProductCategoryId },
                beforeSubmit: EditBefore,
                success: EditSuccess,
                error: SystemError
            });
        }

        $EditSubmit.prop("disabled", false);

        function EditBefore() { }

        function EditSuccess(response) {
            if (response == 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示修改成功。
                alert("修改成功！");
                $('#add-one').modal("hide");
            }
            else if (response == 1) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==1
                //  12a-1.系統顯示無此權限。
                alert("無此權限！");
            }
            else if (response == 2) {
                // 12b.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                // 12b-1.系統顯示分類名稱重覆。
                alert("新增失敗,可能是商品分類名稱重覆！");
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/2
                //  12c-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    // 1.使用者在商品分類管理首頁點按某一列商品分類之刪除。
    $(document).on('click', '.btn-delete', function (event) {
        if (!confirm('確定刪除？')) return;
        // 2.使用者確認要刪除。
        var $this = $(this);
        $selecteditadmin = $this.closest('tr');
        EditProductCategoryId = $selecteditadmin.find("td:eq(0)").text();
        // 3.系統以ajax呼叫Post Action【Product/DeleteProductCategory】，並傳送1點按列之ProductCategoryId。
        $.ajax({
            type: 'POST',
            cache: false,
            url: setting.DeleteProductCategoryUrl,
            data: { "ProductCategoryId": EditProductCategoryId },
            beforeSend: DeleteBefore,
            success: DeleteSuccess,
            error: SystemError
        });

        function DeleteBefore() { }

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
    // 1.使用者在在商品分類管理首頁在商品分類管理首頁點按某一筆商品分類之商品。
    $(document).on('click', '.btn-product', function (event) {
        event.preventDefault();
        // 1-1.系統將1點按分類名稱暫存在jProductCategoryProduct。
        jProductCategoryProduct = $(this).closest('tr').find("td:eq(1)").text();
        console.log(jProductCategoryProduct);
        // 2.系統以ajax呼叫Post Controller Action【Product/GetProductList】，並傳送jProductCategoryProduct。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetProductListUrl,
            data: {
                'ProductCategory': jProductCategoryProduct,
                'AClass': 'pro-page-link'
            },
            beforeSend: LoadBefore,
            success: GetProductListSuccess,
            error: SystemError
        });
    });
    // 1.使用者在在商品分類管理首頁之商品區輸入分類名稱與商品名稱再按查詢。
    $(document).on('click', '#btnSearch', function (event) {
        event.preventDefault();
        // 1-1.系統將1輸入分類名稱暫存在jProductCategoryProduct、商品名稱暫存在jProduct。
        jProductCategoryProduct = $('#ProductCategoryProduct').val();
        jProduct = $('#Product').val();
        // 2.系統以ajax呼叫Post Controller Action【Product/GetProductList】，並傳送jProductCategoryProduct、jProduct。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetProductListUrl,
            data: {
                'ProductCategory': jProductCategoryProduct,
                'Product': jProduct,
                'AClass': 'pro-page-link'
            },
            beforeSend: LoadBefore,
            success: GetProductListSuccess,
            error: SystemError
        });
    });
    // 1.使用者在在商品分類管理首頁之商品清單點按某一個頁碼。
    $(document).on('click', '.pro-page-link', function (event) {
        event.preventDefault();
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 2.系統以ajax呼叫Post Controller Action【Product/GetProductList】，並傳送jProductCategoryProduct、jProduct，以及1點按頁碼。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetProductListUrl,
            data: {
                'ProductCategory': jProductCategoryProduct,
                'Product': jProduct,
                'AClass': 'pro-page-link',
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1])
            },
            beforeSend: LoadBefore,
            success: GetProductListSuccess,
            error: SystemError
        });
    });
    // 1.使用者在在商品分類管理首頁點按某一筆商品分類之新增商品。
    $(document).on('click', '.btn-addproduct', function (event) {
        event.preventDefault();
        // 1-1.系統將1點按分類名稱暫存在jProductCategoryProduct、分類Id暫存在jProductCategoryIdProduct。
        jProductCategoryProduct = $(this).closest('tr').find("td:eq(1)").text();
        jProductCategoryIdProduct = $(this).closest('tr').find("td:eq(0)").text();
        $('#add-oneP input').val('');
        $('#add-oneP textarea').val('');
        $('#add-oneP select').html('');
        // 2.系統顯示[新增商品]對話盒。
        $('#CreateFormP').attr('Style', '');
        $('#EditFormP').attr('Style', 'display: none;');
        $('#add-oneP').modal({ backdrop: "static" });
        // 3.系統將jProductCategoryProduct顯示在[分類名稱]輸入盒，此內容無法變更。
        $('#ProductCategoryNameP').val(jProductCategoryProduct);
    });
    // 5.使用者點按確定新增。
    var $CreateSubmitP;
    $('#CreateSubmitP').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmitP = $(this);
        // 6.系統驗証4輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            ProductName: $('#ProductName').val(),
            Price: $('#Price').val(),
            SaleLimitPrice: $('#SaleLimitPrice').val(),
            OfferPrice: $('#OfferPrice').val(),
        };

        var msgObj = {
            ProductName: "商品名稱必填！",
            Price: "零售價必填！",
            SaleLimitPrice: "批發價必填！",
            OfferPrice: "量批價必填！",
        };

        $.each(checkObj, function (name, jobj) {
            if (jobj == "" || jobj == null) {
                status = false;
                error += msgObj[name] + '\r\n';
            }
        });

        if ($('#Price').val() < 1) {
            error += '零售價要>0' + '\r\n';
        }
        if ($('#SaleLimitPrice').val() < 1) {
            error += '批發價要>0' + '\r\n';
        }
        if ($('#OfferPrice').val() < 1) {
            error += '量批價要>0' + '\r\n';
        }

        if (!status) {
            // 驗証失敗
            alert(error);
        }
        else {
            // 驗証成功
            // 6-1.系統以ajax呼叫Post Action【Product/PostProduct】，並傳送3輸入資料與jProductCategoryIdProduct。
            //// <Select>處理
            //let arraySelSize = '';
            //$("#selSize option").each(function () {
            //    arraySelSize += $(this).val() + ',';
            //});
            ////arraySelSize = arraySelSize.substring(0, arraySelSize.length - 1);
            //let arraySelColor = '';
            //$("#selColor option").each(function () {
            //    arraySelColor += $(this).val() + ',';
            //});
            ////arraySelColor = arraySelColor.substring(0, arraySelColor.length - 1);
            $('#CreateFormP').ajaxSubmit({
                data: { "ProductCategoryId": jProductCategoryIdProduct },
                beforeSubmit: CreatePBefore,
                success: CreatePSuccess,
                error: SystemError
            });
        }

        $CreateSubmitP.prop("disabled", false);

        function CreatePBefore() { }

        function CreatePSuccess(response) {
            if (response == 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示新增成功。
                alert("新增成功！");
                $('#add-oneP').modal("hide");
            }
            else if (response == 1) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==1
                //  12a-1.系統顯示無此權限。
                alert("無此權限！");
            }
            else if (response == 2) {
                // 12b.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                // 12b-1.系統顯示商品名稱重覆。
                alert("新增失敗,可能是商品名稱重覆！");
            }
            else if (response == -3) {
                // 12b.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                // 12b-1.系統顯示商品名稱重覆。
                alert("價格輸入錯誤 (零售價>批發價>量批價) !");
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/2
                //  12c-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    // 1.使用者在在商品分類管理首頁點按某一筆商品之修改。
    $(document).on('click', '.btn-edit-product', function (event) {
        event.preventDefault();
        // 1-1.系統將1點按商品Id暫存在jProductId。
        jProductId = $(this).closest('tr').find("td:eq(1)").text();
        $('#add-oneP input').val('');
        $('#add-oneP textarea').val('');
        $('#add-oneP select').html('');
        // 1-2.系統以ajax呼叫Post Action【Product/GetProduct】，並傳送jProductId。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'json',
            url: setting.GetProductUrl,
            data: {
                'ProductId': jProductId
            },
            beforeSend: LoadBefore,
            success: GetProductSuccess,
            error: SystemError
        });
        function GetProductSuccess(response) {
            // 2.系統在1-2啟動之ajax回呼函式將1-6傳回值顯示在對應元件，並顯示[修改商品]對話盒。
            $('#EditFormP').attr('Style', '');
            $('#CreateFormP').attr('Style', 'display: none;');
            $('#add-oneP').modal({ backdrop: "static" });
            // 2.系統在1-2啟動之ajax回呼函式將1-6傳回值顯示在對應元件，並顯示[修改商品]對話盒。
            $('#EditProductCategoryNameP').val(response.product.productCategory);
            $('#EditProductName').val(response.product.product);
            $('#EditPrice').val(response.product.price);
            $('#EditOfferPrice').val(response.product.offerPrice);
            $('#EditSaleLimitPrice').val(response.product.saleLimitPrice);
            $('#EditProductDescription').val(response.product.productDescription);
            //var doc = '';
            //for (var item in response.productSize)
            //{
            //    doc += '<option>' + response.productSize[item].productSize + '</option>';
            //}
            //$('#EditselSize').html(doc);
            //var doc = '';
            //for (var item in response.productColor) {
            //    doc += '<option>' + response.productColor[item].productColor + '</option>';
            //}
            //$('#EditselColor').html(doc);
        }
    });
    // 5.使用者點按確定修改。
    var $EditSubmitP;
    $('#EditSubmitP').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $EditSubmitP = $(this);
        // 6.系統驗証4輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            ProductName: $('#EditProductName').val(),
            Price: $('#EditPrice').val(),
            SaleLimitPrice: $('#EditSaleLimitPrice').val(),
            OfferPrice: $('#EditOfferPrice').val(),
        };

        var msgObj = {
            ProductName: "商品名稱必填！",
            Price: "零售價必填！",
            SaleLimitPrice: "批發價必填！",
            OfferPrice: "量批價必填！",
        };

        $.each(checkObj, function (name, jobj) {
            if (jobj == "" || jobj == null) {
                status = false;
                error += msgObj[name] + '\r\n';
            }
        });

        if ($('#EditPrice').val() < 1) {
            error += '零售價要>0' + '\r\n';
        }
        if ($('#EditSaleLimitPrice').val() < 1) {
            error += '零售要>0' + '\r\n';
        }
        if ($('#EditOfferPrice').val() < 1) {
            error += '量批價要>0' + '\r\n';
        }

        if (!status) {
            // 驗証失敗
            alert(error);
        }
        else {
            // 驗証成功
            // 6-1.系統以ajax呼叫Post Action【Product/PutProduct】，並傳送3輸入資料與jProductId。
            //// <Select>處理
            //let arraySelSize = '';
            //$("#EditselSize option").each(function () {
            //    arraySelSize += $(this).val() + ',';
            //});
            ////arraySelSize = arraySelSize.substring(0, arraySelSize.length - 1);
            //let arraySelColor = '';
            //$("#EditselColor option").each(function () {
            //    arraySelColor += $(this).val() + ',';
            //});
            ////arraySelColor = arraySelColor.substring(0, arraySelColor.length - 1);
            $('#EditFormP').ajaxSubmit({
                data: { "ProductId": jProductId },
                beforeSubmit: EditPBefore,
                success: EditPSuccess,
                error: SystemError
            });
        }

        $EditSubmitP.prop("disabled", false);

        function EditPBefore() { }

        function EditPSuccess(response) {
            console.log(response);
            if (response == 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示修改成功。
                alert("修改成功！");
                $('#add-oneP').modal("hide");
            }
            else if (response == 1) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==1
                //  12a-1.系統顯示無此權限。
                alert("無此權限！");
            }
            else if (response == 2) {
                // 12b.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                // 12b-1.系統顯示商品名稱重覆。
                alert("新增失敗,可能是商品名稱重覆！");
            }
            else if (response == -3) {
                // 12b.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                // 12b-1.系統顯示商品名稱重覆。
                alert("價格輸入錯誤 (零售價>批發價>量批價) !");
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/2
                //  12c-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    //// 新增尺寸
    //$(document).on('click', '.btn-EditAddSize', function (event) {
    //    $('#EditselSize').append('<option>' + $('#EditProductSize').val() + '</option>');
    //});
    //// 刪除尺寸
    //$(document).on('click', '.btn-EditDelSize', function (event) {
    //    var doc = '';
    //    $("#EditselSize option").each(function () {
    //        if ($(this).val() !== $('#EditselSize').val()) {
    //            doc += '<option>' + $(this).val() + '</option>';
    //        }
    //    });
    //    $('#EditselSize').html(doc);
    //});
    //// 新增顏色
    //$(document).on('click', '.btn-EditAddColor', function (event) {
    //    $('#EditselColor').append('<option>' + $('#EditProductColor').val() + '</option>');
    //});
    //// 刪除顏色
    //$(document).on('click', '.btn-EditDelColor', function (event) {
    //    var doc = '';
    //    $("#EditselColor option").each(function () {
    //        if ($(this).val() !== $('#EditselColor').val()) {
    //            doc += '<option>' + $(this).val() + '</option>';
    //        }
    //    });
    //    $('#EditselColor').html(doc);
    //});
    // 1.使用者在商品管理首頁點按某一列商品之刪除。
    let EditProductId;
    $(document).on('click', '.btn-delete-product', function (event) {
        if (!confirm('確定刪除？')) return;
        // 2.使用者確認要刪除。
        var $this = $(this);
        $selecteditadmin = $this.closest('tr');
        EditProductId = $selecteditadmin.find("td:eq(1)").text();
        // 3.系統以ajax呼叫Post Action【Product/DeleteProduct】，並傳送1點按列之ProductId。
        $.ajax({
            type: 'POST',
            cache: false,
            url: setting.DeleteProductUrl,
            data: { "ProductId": EditProductId },
            beforeSend: DeletePBefore,
            success: DeletePSuccess,
            error: SystemError
        });

        function DeletePBefore() { }

        function DeletePSuccess(response) {
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
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/2
                //  13c-1.系統顯示"刪除失敗"。
                alert('刪除失敗，請稍後再試！');
                //  13a-2.結束。
            }
        }
    });
    // 1.在商品分類管理首頁點按某一筆商品之圖示/隠藏。
    $(document).on('click', '.btn-image-product', function (event) {
        event.preventDefault();
        var $this = $(this);
        // 1-1.系統將1點按商品Id暫存在jProductId。
        jProductId = $this.closest("tr").find("td:eq(1)").text();
        $tr = $this.closest("tr");
        if ($this.find("span").first().hasClass("glyphicon-minus")) {
            //2a.系統判斷javascript變數IsSpread=true。
            //2a-1.系統清除下一個<tr>之html()，以隠藏下線之下線清單。
            $(this).closest("tr").next().html('');
            //2a-2.系統設定javascript變數IsSpread=false。
            //isSpread = false;
            //2a-3.系統設定展開按鈕圖示為+(展開)。
            $this.find("span").attr('title', '圖示');
            $this.find("span").first().removeClass();
            $this.find("span").first().addClass('glyphicon glyphicon-camera');
            //2a-4.結束。
            return;
        }
        // 2.系統判斷javascript變數IsSpread=false(預設值為false)。
        // 3.系統以ajax呼叫Post Controller Action【Product/GetProductImageList】，並傳送jProductId。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetProductImageListUrl,
            data: {
                'ProductId': jProductId,
                'AClass': 'inner-page-link'
            },
            beforeSend: ExpandBefore,
            success: ExpandSuccess,
            error: SystemError
        });

        function ExpandBefore() { }

        function ExpandSuccess(response) {
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
    // 1.在商品圖示清單點按換頁連結。
    $(document).on('click', '.inner-page-link', function (event) {
        //alert("");
        event.preventDefault();
        var $this = $(this);
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 3.系統以ajax呼叫Get Action【Artist/GetAll】，並上傳1點按之頁碼，以及BorkerBackend03_10主要流程1-1暫存之主類型代碼、次類型代碼、國籍、名稱。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: href[0],
            data: {
                'ProductId': jProductId,
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1]),
                'AClass': 'inner-page-link'
            },
            beforeSend: LoadBefore,
            success: ExpandInnerSuccess,
            error: SystemError
        });
        function ExpandInnerSuccess(response) {
            // 10.系統在3啟動之ajax回呼函式中將下一列<tr>的Html內容更新為9-7.系統回傳View。
            $tr.next().html('<td colspan="10">' + response + '</td>');
            // 11.結束。
        }
    });
    // 1.使用者在商品清單之某一列商品點按新增圖示。
    $(document).on('click', '.btn-addimage', function (event) {
        event.preventDefault();
        // 1-1.系統將1點按商品Id暫存在jProductId。
        jProductId = $(this).closest("tr").find("td:eq(1)").text();
        $('#add-oneI input').val('');
        $('#add-oneI textarea').val('');
        // 2.系統顯示[新增商品圖示]對話盒。
        $('#CreateFormI').attr('Style', '');
        $('#EditFormI').attr('Style', 'display: none;');
        $('#add-oneI').modal({ backdrop: "static" });
    });
    // 4.使用者點按確定新增。
    var $CreateSubmitI;
    $('#CreateSubmitI').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmitI = $(this);
        // 5.系統驗証3輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            PictureContent: $('#PictureContentI').val()
        };

        var msgObj = {
            PictureContent: "商品圖示必填！"
        };

        $.each(checkObj, function (name, jobj) {
            if (jobj == "" || jobj == null) {
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
            // 6.系統以ajax呼叫Post Action【Product/PostProductImage】，並傳送3輸入資料與jProductId。
            //alert(jProductId);
            $('#CreateFormI').ajaxSubmit({
                data: { 'ProductId': jProductId },
                beforeSubmit: CreateIBefore,
                success: CreateISuccess,
                error: SystemError
            });
        }

        $CreateSubmitI.prop("disabled", false);

        function CreateIBefore() { }

        function CreateISuccess(response) {
            if (response == 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示新增成功。
                alert("新增成功！");
                $('#add-oneI').modal("hide");
            }
            else if (response == 1) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==1
                //  12a-1.系統顯示無此權限。
                alert("無此權限！");
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1
                //  12c-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    // 1.使用者在商品清單之某一列商品點按修改圖示。
    $(document).on('click', '.btn-edit-productimage', function (event) {
        event.preventDefault();
        // 1-1.系統將1點按ProductId/ProductImageId暫存在jProductId/jProductImageId。
        jProductId = $(this).closest("tr").data("productid");
        jProductImageId = $(this).closest("tr").data("productimageid");
        $('#add-oneI input').val('');
        $('#add-oneI textarea').val('');
        // 2.系統顯示[修改商品圖示]對話盒。
        $('#EditFormI').attr('Style', '');
        $('#CreateFormI').attr('Style', 'display: none;');
        $('#add-oneI').modal({ backdrop: "static" });
    });
    // 4.使用者點按確定修改。
    var $EditeSubmitI;
    $('#EditSubmitI').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $EditSubmitI = $(this);
        // 5.系統驗証3輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            PictureContent: $('#EditPictureContentI').val()
        };

        var msgObj = {
            PictureContent: "商品圖示必填！"
        };

        $.each(checkObj, function (name, jobj) {
            if (jobj == "" || jobj == null) {
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
            // 6.系統以ajax呼叫Post Action【Product/PutProductImage】，並傳送3輸入資料與jProductId。
            //alert(jProductId);
            $('#EditFormI').ajaxSubmit({
                data: { 'ProductId': jProductId, 'ProductImageId': jProductImageId },
                beforeSubmit: EditIBefore,
                success: EditISuccess,
                error: SystemError
            });
        }

        $EditSubmitI.prop("disabled", false);

        function EditIBefore() { }

        function EditISuccess(response) {
            if (response == 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示修改成功。
                alert("修改成功！");
                $('#add-oneI').modal("hide");
            }
            else if (response == 1) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==1
                //  12a-1.系統顯示無此權限。
                alert("無此權限！");
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1
                //  12c-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    // 1.使用者在商品管理首頁點按某一列商品圖示之刪除。
    $(document).on('click', '.btn-delete-productimage', function (event) {
        if (!confirm('確定刪除？')) return;
        // 2.使用者確認要刪除。
        var $this = $(this);
        jProductId = $(this).closest("tr").data("productid");
        jProductImageId = $(this).closest("tr").data("productimageid");
        // 3.系統以ajax呼叫Post Action【Product/DeleteProductImage】，並傳送1點按列之ProductId/ProductImageId。
        $.ajax({
            type: 'POST',
            cache: false,
            url: setting.DeleteProductImageUrl,
            data: { 'ProductId': jProductId, 'ProductImageId': jProductImageId },
            beforeSend: DeleteImagePBefore,
            success: DeleteImagePSuccess,
            error: SystemError
        });

        function DeleteImagePBefore() { }

        function DeleteImagePSuccess(response) {
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
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/2
                //  13c-1.系統顯示"刪除失敗"。
                alert('刪除失敗，請稍後再試！');
                //  13a-2.結束。
            }
        }
    });
    // 1.使用者在商品管理首頁點按某一列商品圖示之主圖示。
    $(document).on('click', '.btn-product-majorimage', function (event) {
        if (!confirm('確定設定？')) return;
        // 2.使用者確認要設定。
        var $this = $(this);
        jProductId = $(this).closest("tr").data("productid");
        jProductImageId = $(this).closest("tr").data("productimageid");
        // 3.系統以ajax呼叫Post Action【Product/SetProductImage】，並傳送1點按列之ProductId/ProductImageId。
        $.ajax({
            type: 'POST',
            cache: false,
            url: setting.SetProductImageUrl,
            data: { 'ProductId': jProductId, 'ProductImageId': jProductImageId },
            beforeSend: SetImagePBefore,
            success: SetImagePSuccess,
            error: SystemError
        });

        function SetImagePBefore() { }

        function SetImagePSuccess(response) {
            if (response == 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                alert('設定成功');
            }
            else if (response == 2) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                //  12a-1.系統顯示"無此權限"。
                alert('無此權限！');
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

    // 1.使用者在商品管理首頁點按某一列商品圖示之置頂。
    $(document).on('click', '.btn-product-top', function (event) {
        //if (!confirm('確定設定？')) return;
        // 2.使用者確認要設定。
        var $this = $(this);
        jProductId = $(this).closest("tr").data("productid");
        jProductImageId = $(this).closest("tr").data("productimageid");
        // 3.系統以ajax呼叫Post Action【Product/UpdateProductImageOrder】，並傳送1點按列之ProductId/ProductImageId。
        $.ajax({
            type: 'POST',
            cache: false,
            async: false,
            url: setting.UpdateProductImageOrderUrl,
            data: { 'ProductId': jProductId, 'ProductImageId': jProductImageId },
            beforeSend: UpdateProductImageOrderBefore,
            success: UpdateProductImageOrderSuccess,
            error: SystemError
        });

        function UpdateProductImageOrderBefore() { }

        function UpdateProductImageOrderSuccess(response) {
            if (response == 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統以ajax呼叫Post Controller Action【Product/GetProductImageList】，並傳送jProductId。
                $.ajax({
                    type: 'Post',
                    cache: false,
                    dataType: 'HTML',
                    url: setting.GetProductImageListUrl,
                    data: {
                        'ProductId': jProductId,
                        'AClass': 'inner-page-link'
                    }
                }).done(response => {
                    //20181205更新 ---棋
                    // 10.系統在3啟動之ajax回呼函式中將目前<tr>的Html內容更新為9-7.系統回傳View。
                    $this.closest("tr").parent().parent().parent().parent().html('<td colspan="10">' + response + '</td>');
                    alert('設定成功');
                    // 11.結束。
                }).fail(res => {
                    alert('設定失敗');
                });
            }
            else if (response == 2) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                //  12a-1.系統顯示"無此權限"。
                alert('無此權限！');
                //  13b-2.結束。
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/2
                //  13c-1.系統顯示"執行失敗"。
                alert('執行失敗，請稍後再試！');
                //  13a-2.結束。
            }
        }
    });
    // 1.使用者在商品管理某一列商品庫存點按盤整。
    $(document).on('click', '.btn-stock', function (event) {
        event.preventDefault();
        // 2.系統顯示[商品庫存盤整]對話盒，並將1點按之商品名稱/尺寸/顏色顯示在對應輸入盒，
        //   庫存顯示在[原庫存]輸入盒(4者皆不能修改) ，今日日期顯示在[盤整日期]輸入盒。
        //   並將點按列ProducSizeId/ProductColorId暫存至jProducSizeId/jProductColorId
        //jProductId = $(this).closest("tr").find("td:eq(1)").text();
        jProducSizeId = $(this).data('productsizeid');
        jProductColorId = $(this).data('productcollorid');
        console.log(jProducSizeId);
        console.log(jProductColorId);
        $('#add-oneS input').val('');
        $('#ProductN').val(jProduct);
        $('#ProductSizeN').val($(this).closest("tr").find("td:eq(1)").text());
        $('#ProductColorN').val($(this).closest("tr").find("td:eq(2)").text());
        $('#StockConsolidationTime').val(setting.jsDate);
        $('#Stock').val($(this).closest("tr").find("td:eq(3)").text());
        $('#add-oneS').modal({ backdrop: "static" });
    });
    // 4.使用者點按確定。
    var $CreateSubmitS;
    $('#CreateSubmitS').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmitS = $(this);
        // 5.系統驗証3輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            Stock: $('#Stock').val(),
            StockConsolidatio: $('#StockConsolidatio').val(),
            Consolidation: $('#Consolidation').val()
        };

        var msgObj = {
            Stock: "原庫存必填！",
            StockConsolidatio: '正確庫存必填！',
            Consolidation: '盤整量必填！'
        };

        $.each(checkObj, function (name, jobj) {
            if (jobj == "" || jobj == null) {
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
            // 6.系統以ajax呼叫Post Action【Product/PostProductStock】，並傳送3輸入資料與jProductId/jProducSizeId/j ProductColorId。
            $('#CreateFormS').ajaxSubmit({
                data: {
                    'ProductId': jProductId, 'ProducSizeId': jProducSizeId, 'ProductColorId': jProductColorId
                },
                beforeSubmit: CreateSBefore,
                success: CreateSSuccess,
                error: SystemError
            });
        }

        $CreateSubmitS.prop("disabled", false);

        function CreateSBefore() { }

        function CreateSSuccess(response) {
            if (response == 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示新增成功。
                alert("盤整成功！");
                //20181225 ---棋
                //新增Model成功後隱藏
                $('#add-oneS').modal('hide');
            }
            else if (response == 2) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                //  12a-1.系統顯示無此權限。
                alert("無此權限！");
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1
                //  12c-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    // 1.使用者在商品管理首頁點按某一列商品之尺寸。
    $(document).on('click', '.btn-size', function (event) {
        event.preventDefault();
        // 1-1.系統將1點按商品Id暫存在jProductId。
        jProductId = $(this).closest('tr').find("td:eq(1)").text();
        $('#add-oneSize input').val('');
        $('#add-oneSize textarea').val('');
        $('#add-oneSize select').html('');
        // 3.系統以ajax呼叫Post Action【Product/GetProductSize】，並傳送1點按列之ProductId。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'json',
            url: setting.GetProductSizeUrl,
            data: {
                'ProductId': jProductId
            },
            beforeSend: LoadBefore,
            success: GetProductSizeSuccess,
            error: SystemError
        });
        function GetProductSizeSuccess(response) {
            // 7.系統在3啟動之ajax回呼函式將6傳回值顯示在對應元件，並顯示[商品尺寸]對話盒。
            $('#add-oneSize').modal({ backdrop: "static" });
            var doc = '';
            for (var item in response.productSize) {
                doc += '<option>' + response.productSize[item].productSize + '</option>';
            }
            $('#selSize').html(doc);
            //var doc = '';
            //for (var item in response.productColor) {
            //    doc += '<option>' + response.productColor[item].productColor + '</option>';
            //}
            //$('#selColor').html(doc);
        }
    });
    // 8.使用者輸入尺寸，按新增。
    $(document).on('click', '.btn-AddSize', function (event) {
        // 9.系統以ajax呼叫Post Action【Product/PosttProductSize】，並傳送8輸入尺寸以及jProductId。
        var $this = $(this);
        $(this).prop("disabled", true);
        var status = true,
            error = "";
        var checkObj = {
            ProductSize: $('#ProductSize').val()
        };

        var msgObj = {
            ProductSize: "商品尺寸必填！"
        };

        $.each(checkObj, function (name, jobj) {
            if (jobj == "" || jobj == null) {
                status = false;
                error += msgObj[name] + '\r\n';
            }
        });

        if (!status) {
            // 驗証失敗
            alert(error);
        }
        else {
            // 9.系統以ajax呼叫Post Action【Product/PostProductSize】，並傳送8輸入尺寸以及jProductId。
            $('#CreateFormSize').ajaxSubmit({
                data: { 'ProductId': jProductId },
                beforeSubmit: LoadBefore,
                success: PostProductSize,
                error: SystemError
            });
        }

        function PostProductSize(response) {
            if (response == 0) {
                // 14.系統在9啟動之ajax回呼函式中判斷13傳回值==0。
                // 15.系統將8輸入尺寸新增到尺寸Select。
                $('#selSize').append('<option>' + $('#ProductSize').val() + '</option>');
            }
            else if (response == 2) {
                // 14a.系統在9啟動之ajax回呼函式中判斷11傳回值==2
                //  14a-1.系統顯示無此權限。
                alert('無此權限！');
            }
            else if (response == 3) {
                // 14b.系統在9啟動之ajax回呼函式中判斷11傳回值==3
                //  14b-1.系統顯示尺寸重覆。
                alert('尺寸重覆！');
            }
            else {
                // 14c.系統在9啟動之ajax回呼函式中判斷11傳回值!=0/2/3
                //  14c-1.系統顯示執行失敗，請再試一次。
                alert('執行失敗，請再試一次！');
            }
            $this.prop("disabled", false);
        }
    });
    // 16.使用者選擇尺寸Select中的尺寸按刪除。
    $(document).on('click', '.btn-DelSize', function (event) {
        if (!confirm('確定刪除？')) return;
        // 17.使用者確認要刪。
        var $this = $(this);
        // 18.系統以ajax呼叫Post Action【Product/DeleteProductSize】，並傳送1點按列之ProductId/選擇尺寸。
        $.ajax({
            type: 'POST',
            cache: false,
            url: setting.DeleteProductSizeUrl,
            data: { 'ProductId': jProductId, 'ProductSize': $('#selSize option:selected').val() },
            beforeSend: DeleteSizePBefore,
            success: DeleteSizePSuccess,
            error: SystemError
        });

        function DeleteSizePBefore() { }

        function DeleteSizePSuccess(response) {
            if (response == 0) {
                // 23.系統在18啟動之ajax回呼函式中判斷22傳回值==0。
                alert('刪除成功');
                // 24.系統將刪除列自尺寸清單列中去除。
                var doc = '';
                $("#selSize option").each(function () {
                    if ($(this).val() !== $('#selSize').val()) {
                        doc += '<option>' + $(this).val() + '</option>';
                    }
                });
                $('#selSize').html(doc);
            }
            else if (response == 2) {
                // 23a.系統在18啟動之ajax回呼函式中判斷22傳回值==2。
                //  23a-1.系統顯示無此權限。
                alert('無此權限！');
            }
            else if (response == 3) {
                // 23b.系統在18啟動之ajax回呼函式中判斷22傳回值==3
                //  23b-1.系統顯示有庫存不能刪。
                alert('有庫存不能刪！');
            }
            else {
                // 23c.系統在18啟動之ajax回呼函式中判斷22傳回值!=0/2/3
                //  23c-1.系統顯示有刪除失敗，請稍後再試。
                alert('刪除失敗，請稍後再試！');
            }
        }
    });

    // 1.使用者在商品管理首頁點按某一列商品之顏色。
    $(document).on('click', '.btn-color', function (event) {
        event.preventDefault();
        // 1-1.系統將1點按商品Id暫存在jProductId。
        jProductId = $(this).closest('tr').find("td:eq(1)").text();
        $('#add-oneColor input').val('');
        $('#add-oneColor textarea').val('');
        $('#add-oneColor select').html('');
        // 3.系統以ajax呼叫Post Action【Product/GetProductColor】，並傳送1點按列之ProductId。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'json',
            url: setting.GetProductColorUrl,
            data: {
                'ProductId': jProductId
            },
            beforeSend: LoadBefore,
            success: GetProductColorSuccess,
            error: SystemError
        });
        function GetProductColorSuccess(response) {
            // 7.系統在3啟動之ajax回呼函式將6傳回值顯示在對應元件，並顯示[商品顏色]對話盒。
            $('#add-oneColor').modal({ backdrop: "static" });
            var doc = '';
            for (var item in response.productColor) {
                doc += '<option>' + response.productColor[item].productColor + '</option>';
            }
            $('#selColor').html(doc);
        }
    });
    // 8.使用者輸入顏色，按新增。
    $(document).on('click', '.btn-AddColor', function (event) {
        // 9.系統以ajax呼叫Post Action【Product/PosttProductColor】，並傳送8輸入顏色以及jProductId。
        var $this = $(this);
        $(this).prop("disabled", true);
        var status = true,
            error = "";
        var checkObj = {
            ProductColor: $('#ProductColor').val()
        };

        var msgObj = {
            ProductColor: "商品顏色必填！"
        };

        $.each(checkObj, function (name, jobj) {
            if (jobj == "" || jobj == null) {
                status = false;
                error += msgObj[name] + '\r\n';
            }
        });

        if (!status) {
            // 驗証失敗
            alert(error);
        }
        else {
            // 9.系統以ajax呼叫Post Action【Product/PostProductColor】，並傳送8輸入顏色以及jProductId。
            $('#CreateFormColor').ajaxSubmit({
                data: { 'ProductId': jProductId },
                beforeSubmit: LoadBefore,
                success: PostProductColor,
                error: SystemError
            });
        }

        function PostProductColor(response) {
            if (response == 0) {
                // 14.系統在9啟動之ajax回呼函式中判斷13傳回值==0。
                // 15.系統將8輸入顏色新增到顏色Select。
                $('#selColor').append('<option>' + $('#ProductColor').val() + '</option>');
            }
            else if (response == 2) {
                // 14a.系統在9啟動之ajax回呼函式中判斷11傳回值==2
                //  14a-1.系統顯示無此權限。
                alert('無此權限！');
            }
            else if (response == 3) {
                // 14b.系統在9啟動之ajax回呼函式中判斷11傳回值==3
                //  14b-1.系統顯示顏色重覆。
                alert('顏色重覆！');
            }
            else {
                // 14c.系統在9啟動之ajax回呼函式中判斷11傳回值!=0/2/3
                //  14c-1.系統顯示執行失敗，請再試一次。
                alert('執行失敗，請再試一次！');
            }
            $this.prop("disabled", false);
        }
    });
    // 16.使用者選擇顏色Select中的顏色按刪除。
    $(document).on('click', '.btn-DelColor', function (event) {
        if (!confirm('確定刪除？')) return;
        // 17.使用者確認要刪。
        var $this = $(this);
        // 18.系統以ajax呼叫Post Action【Product/DeleteProductColor】，並傳送1點按列之ProductId/選擇顏色。
        $.ajax({
            type: 'POST',
            cache: false,
            url: setting.DeleteProductColorUrl,
            data: { 'ProductId': jProductId, 'ProductColor': $('#selColor option:selected').val() },
            beforeSend: DeleteColorPBefore,
            success: DeleteColorPSuccess,
            error: SystemError
        });

        function DeleteColorPBefore() { }

        function DeleteColorPSuccess(response) {
            if (response == 0) {
                // 23.系統在18啟動之ajax回呼函式中判斷22傳回值==0。
                alert('刪除成功');
                // 24.系統將刪除列自顏色清單列中去除。
                var doc = '';
                $("#selColor option").each(function () {
                    if ($(this).val() !== $('#selColor').val()) {
                        doc += '<option>' + $(this).val() + '</option>';
                    }
                });
                $('#selColor').html(doc);
            }
            else if (response == 2) {
                // 23a.系統在18啟動之ajax回呼函式中判斷22傳回值==2。
                //  23a-1.系統顯示無此權限。
                alert('無此權限！');
            }
            else if (response == 3) {
                // 23b.系統在18啟動之ajax回呼函式中判斷22傳回值==3
                //  23b-1.系統顯示有庫存不能刪。
                alert('有庫存不能刪！');
            }
            else {
                // 23c.系統在18啟動之ajax回呼函式中判斷22傳回值!=0/2/3
                //  23c-1.系統顯示有刪除失敗，請稍後再試。
                alert('刪除失敗，請稍後再試！');
            }
        }
    });
    // 1.在商品分類管理首頁點按某一筆商品之庫存/隠藏。
    $(document).on('click', '.btn-stock-pro', function (event) {
        event.preventDefault();
        var $this = $(this);
        // 1-1.系統將1點按商品Id暫存在jProductId。
        jProductId = $this.closest("tr").find("td:eq(1)").text();
        //jProduct = $this.closest("tr").find("td:eq(2)").text();
        $tr = $this.closest("tr");
        if ($this.find("span").first().hasClass("glyphicon-minus")) {
            //2a.系統判斷javascript變數IsSpread=true。
            //2a-1.系統清除下一個<tr>之html()，以隠藏下線之下線清單。
            $(this).closest("tr").next().html('');
            //2a-2.系統設定javascript變數IsSpread=false。
            //isSpread = false;
            //2a-3.系統設定展開按鈕庫存為+(展開)。
            $this.find("span").attr('title', '庫存');
            $this.find("span").first().removeClass();
            $this.find("span").first().addClass('glyphicon glyphicon-asterisk');
            //2a-4.結束。
            return;
        }
        // 2.系統判斷javascript變數IsSpread=false(預設值為false)。
        // 3.系統以ajax呼叫Post Controller Action【Product/GetProductStockList】，並傳送jProductId。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetProductStockListUrl,
            data: {
                'ProductId': jProductId,
                'AClass': 'inner-page-link-stock'
            },
            beforeSend: ExpandBefore,
            success: ExpandSuccess,
            error: SystemError
        });

        function ExpandBefore() { }

        function ExpandSuccess(response) {
            // 10.系統在3啟動之ajax回呼函式中將下一列<tr>的Html內容更新為9-7.系統回傳View。
            $this.closest("tr").next().html('<td colspan="10">' + response + '</td>');
            // 10-1.系統設定javascript變數IsSpread=true。
            //isSpread = true;
            // 10-2.系統設定展開按鈕庫存為-(隱藏)。
            $this.find("span").attr('title', '隠藏');
            $this.find("span").first().removeClass();
            $this.find("span").first().addClass('glyphicon glyphicon-minus');
            // 11.結束。
        }
    });
    // 1.在商品庫存清單點按換頁連結。
    $(document).on('click', '.inner-page-link-stock', function (event) {
        //alert("");
        event.preventDefault();
        var $this = $(this);
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 3.系統以ajax呼叫Post Controller Action【Product/GetProductStockList】，並傳送jProductId。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: href[0],
            data: {
                'ProductId': jProductId,
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1]),
                'AClass': 'inner-page-link-stock'
            },
            beforeSend: LoadBefore,
            success: ExpandInnerSuccess,
            error: SystemError
        });
        function ExpandInnerSuccess(response) {
            // 10.系統在3啟動之ajax回呼函式中將下一列<tr>的Html內容更新為9-7.系統回傳View。
            $tr.next().html('<td colspan="10">' + response + '</td>');
            // 11.結束。
        }
    });
}
$('#StockConsolidatio').on('change', function (event) {
    // 盤整量：[正確庫存]-[原庫存]。
    $('#Consolidation').val($('#StockConsolidatio').val() - $('#Stock').val());;
});
function GetProductCategorySuccess(response) {
    // 10.系統在2啟動之ajax回呼函式中將<div ProductCategory>.html()設為9-7傳回值。
    $('Div#ProductCategory').html(response);
    // 11.結束。
}
function GetProductLevelPathSuccess(response) {
    // 10-3.系統在10-1啟動之ajax回呼函式中更新<div ProductLevelPath>.html()=8-2回傳值。
    $('Div#ProductLevelPath').html(response);
}
function GetProductListSuccess(response) {
    // 10.系統在2啟動之ajax回呼函式中將<div ProductList>.html()設為9-7傳回值。
    $('Div#ProductList').html(response);
    $('#ProductCategoryProduct').val(jProductCategoryProduct);
}
function LoadBefore() {
}
function SystemError() {
    alert('系統錯誤，請稍後再試！');
}