let jAccountingSubject = '', jAccountingId;
function Accountingfunction(option) {
    var setting = {
        GetAccountingListUrl: '',
        DeleteAccountingUrl:''
   };
    setting = $.extend(setting, option);
    $(window).keydown(function (event) {
        if (event.keyCode === 13) {
            event.preventDefault();
            return false;
        }
    });
    // 1.使用者在會計科目首頁輸入會計科目並按查詢。
    $(document).on('click', '#btnSearch', function (event) {
        event.preventDefault();
        // 2.系統將1輸入會計科目暫存至jAccountingSubject。
        jAccountingSubject = $('#AccountingSubject').val();
        // 3.系統以ajax呼叫Get Action【Accounting/GetAccountingList】，並傳送jAccountingSubject。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetAccountingListUrl,
            data: {
                'AccountingSubject': jAccountingSubject
            },
            beforeSend: LoadBefore,
            success: GetAccountingListSuccess,
            error: SystemError
        });
    });
    // 1.使用者在ERP系統會計科目管理之會計科目清單點按換頁連結。
    $(document).on('click', '.page-link', function (event) {
        event.preventDefault();
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 33.系統以ajax呼叫Get Action【Accounting/GetAccountingList】，並傳送jAccountingSubject以及1點按頁碼。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetAccountingListUrl,
            data: {
                'AccountingSubject': jAccountingSubject,
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1])
            },
            beforeSend: LoadBefore,
            success: GetAccountingListSuccess,
            error: SystemError
        });
    });
    // 1.使用者在會計科目管理首頁點按新增。
    $('#btnAdd').on('click', function (event) {
        event.preventDefault();
        $('#add-one input').val('');
        $('#add-one textarea').val('');
        // 2.系統顯示[新增會計科目]對話盒。
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
            AccountingId: $('#AccountingId').val(),
            AccountingSubject: $('#AccountingSubjectF').val()
        };
        var msgObj = {
            AccountingId: "科目代碼必填！",
            AccountingSubject: "科目名稱必填！"
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
            // 6.系統以ajax呼叫Post Action【Product/PostAccounting】，並傳送3輸入資料。
            $('#CreateForm').ajaxSubmit({
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
                // 12b-1.系統顯示科目代碼重覆。
                alert("新增失敗,科目代碼重覆！");
            }
            else if (response == 3) {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值==3
                // 12c-1.系統顯示科目名稱重覆。
                alert("新增失敗,科目名稱重覆！");
            }
            else {
                // 12d.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/2/3
                //  12d-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    // 1.使用者在會計科目管理首頁點按某一列會計科目之修改。
    $(document).on('click', '.btn-edit', function (event) {
        event.preventDefault();
        $('#add-one input').val('');
        $('#add-one textarea').val('');
        // 2.系統顯示[修改會計科目]對話盒，並將1點列之資料顯示在對應元件。
        $tr = $(this).closest("tr");
        $('#EditAccountingId').val($tr.find("td:eq(0)").text());
        $('#EditAccountingSubjectF').val($tr.find("td:eq(1)").text());
        $('#EditAccountingDescription').val($tr.find("td:eq(2)").text());
        $('#EditForm').attr('Style', '');
        $('#CreateForm').attr('Style', 'display: none;');
        $('#add-one').modal({ backdrop: "static" });
    });
    // 4.使用者點按確定修改。
    var $EditSubmit;
    $('#EditSubmit').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $EditSubmit = $(this);
        // 5.系統驗証3輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            AccountingId: $('#EditAccountingId').val(),
            AccountingSubject: $('#EditAccountingSubjectF').val()
        };
        var msgObj = {
            AccountingId: "科目代碼必填！",
            AccountingSubject: "科目名稱必填！"
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
            // 6.系統以ajax呼叫Post Action【Product/PutAccounting】，並傳送3輸入資料。
            $('#EditForm').ajaxSubmit({
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
            else if (response == 3) {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值==3
                // 12c-1.系統顯示科目名稱重覆。
                alert("修改失敗,科目名稱重覆！");
            }
            else {
                // 12d.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/2/3
                //  12d-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    // 1.使用者在會計科目管理首頁點按某一列會計科目之刪除。
    $(document).on('click', '.btn-delete', function (event) {
        if (!confirm('確定刪除？')) return;
        // 2.使用者確認要刪除。
        var $this = $(this);
        $selecteditadmin = $this.closest('tr');
        jAccountingId = $selecteditadmin.find("td:eq(0)").text();
        // 3.系統以ajax呼叫Post Action【Product/DeleteAccounting】，並傳送1點按列之AccountingId。
        $.ajax({
            type: 'POST',
            cache: false,
            url: setting.DeleteAccountingUrl,
            data: { "AccountingId": jAccountingId },
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
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/2
                //  13c-1.系統顯示"刪除失敗"。
                alert('刪除失敗，請稍後再試！');
                //  13a-2.結束。
            }
        }
    });
}
function GetAccountingListSuccess(response) {
    // 6.系統在3啟動之ajax呼叫回呼函式中將<Div AccountingList>.Html()更新為9-7回傳View。
    $('Div#AccountingList').html(response);
    // 11.結束。
}
function LoadBefore() { }
function SystemError() {
    alert('系統錯誤，請稍後再試！');
}