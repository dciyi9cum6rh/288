let jOfferProductSubject = '', jProductId;
function OfferProductfunction(option) {
    var setting = {
        DeleteOfferProductUrl: ''
    };
    setting = $.extend(setting, option);
    // 1.使用者在商品分類管理首頁點按新增。
    $('#btnAdd').on('click', function (event) {
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
        if (($("#ProductId").val() === "" && $("#Product").val() === "") || ($("#ProductId").val() === null && $("#Product").val() === null)) {
            status = false;
            error = "代碼與名稱至少必須輸入一項！";
        }
        if (!status) {
            // 驗証失敗
            alert(error);
        }
        else {
            // 驗証成功
            // 6.系統以ajax呼叫Post Action【OfferProduct/PostOfferProduct】，並傳送3輸入資料。
            $('#CreateForm').ajaxSubmit({
                beforeSubmit: LoadBefore,
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
                // 12b-1.系統顯示名稱重覆。
                alert("新增失敗,可能是商品重覆！");
            }
            else if (response == 3) {
                // 12b.系統在6啟動之ajax回呼函式中判斷11傳回值==3
                // 12b-1.系統顯示無此代碼/名稱。
                alert("新增失敗,查無此無此代碼/名稱！");
            }
            else if (response == 4) {
                // 12b.系統在6啟動之ajax回呼函式中判斷11傳回值==4
                // 12b-1.系統顯示優惠商品總數超過一頁(8筆)。
                alert("新增失敗,優惠商品總數超過一頁(8筆)！");
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/2/3
                //  12c-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });

    // 1.使用者在準批發會員優惠商品管理首頁點按某一列優惠商品之刪除。
    $(document).on('click', '.btn-delete', function (event) {
        if (!confirm('確定刪除？')) return;
        // 2.使用者確認要刪除。
        var $this = $(this);
        $selecteditadmin = $this.closest('tr');
        // 3.系統以ajax呼叫Post Action【OfferProduct/DeleteOfferProduct】，並傳送1點按列之ProductId。
        jProductId = $(this).closest("tr").find("td:eq(0)").text();
        $.ajax({
            type: 'POST',
            cache: false,
            url: setting.DeleteOfferProductUrl,
            data: { "ProductId": jProductId },
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
            else if (response == 1) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==1
                //  12a-1.系統顯示"無此權限"。
                alert('無此權限！');
                //  13b-2.結束。
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1
                //  13c-1.系統顯示"刪除失敗"。
                alert('刪除失敗，請稍後再試！');
                //  13a-2.結束。
            }
        }
    });
}
function LoadBefore() { }
function SystemError() {
    alert('系統錯誤，請稍後再試！');
}