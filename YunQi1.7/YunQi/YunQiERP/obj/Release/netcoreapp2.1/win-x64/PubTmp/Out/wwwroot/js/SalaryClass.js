let jSalaryClass = '', jSalaryClassId;
function SalaryClassfunction(option) {
    var setting = {
        GetSalaryClassListUrl: '',
        DeleteSalaryClassUrl: ''
    };
    setting = $.extend(setting, option);
    // 1.使用者在薪資類別首頁輸入薪資類別並按查詢。
    $(document).on('click', '#btnSearch', function (event) {
        event.preventDefault();
        // 2.系統將1輸入薪資類別暫存至jSalaryClass。
        jSalaryClass = $('#SalaryClass').val();
        // 3.系統以ajax呼叫Get Action【SalaryClass/GetSalaryClassList】，並傳送jSalaryClass。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetSalaryClassListUrl,
            data: {
                'SalaryClass': jSalaryClass
            },
            beforeSend: LoadBefore,
            success: GetSalaryClassListSuccess,
            error: SystemError
        });
    });
    // 1.使用者在ERP系統薪資類別管理之薪資類別清單點按換頁連結。
    $(document).on('click', '.page-link', function (event) {
        event.preventDefault();
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 33.系統以ajax呼叫Get Action【SalaryClass/GetSalaryClassList】，並傳送jSalaryClass以及1點按頁碼。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetSalaryClassListUrl,
            data: {
                'SalaryClass': jSalaryClass,
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1])
            },
            beforeSend: LoadBefore,
            success: GetSalaryClassListSuccess,
            error: SystemError
        });
    });
    // 1.使用者在薪資類別管理首頁點按新增。
    $('#btnAdd').on('click', function (event) {
        event.preventDefault();
        $('#add-one input').val('');
        $('#add-one textarea').val('');
        // 2.系統顯示[新增薪資類別]對話盒。
        $('#CreateForm').attr('Style', '');
        $('#EditForm').attr('Style', 'display: none;');
        $('#add-one').modal({ backdrop: "static" });
    });
    // 4.使用者點按確定新增。
    let $CreateSubmit, $tr;
    $('#CreateSubmit').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmit = $(this);
        // 5.系統驗証3輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            SalaryClassS: $('#SalaryClassS').val(),
            ClassSalary: $('#ClassSalary').val()
        };
        var msgObj = {
            SalaryClassS: "薪資類別必填！",
            ClassSalary: "薪資必填！"
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
            // 6.系統以ajax呼叫Post Action【Product/PostSalaryClass】，並傳送3輸入資料。
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
                // 12b-1.系統顯示薪資類別重覆。
                alert("新增失敗,薪資類別重覆！");
            }
            else {
                // 12d.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/2/3
                //  12d-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    // 1.使用者在薪資類別管理首頁點按某一列薪資類別之修改。
    $(document).on('click', '.btn-edit', function (event) {
        event.preventDefault();
        $('#add-one input').val('');
        $('#add-one textarea').val('');
        // 2.系統顯示[修改薪資類別]對話盒，並將1點列之資料顯示在對應元件，再將1點按薪資類別代碼暫存在jSalaryClassId。
        $tr = $(this).closest("tr");
        $('#SalaryClassSEdit').val($tr.find("td:eq(1)").text());
        $('#ClassSalaryEdit').val($tr.find("td:eq(2)").text());
        $('#SalaryClassDescriptionEdit').val($tr.find("td:eq(3)").text());
        jSalaryClassId = $tr.find("td:eq(0)").text();
        $('#EditForm').attr('Style', '');
        $('#CreateForm').attr('Style', 'display: none;');
        $('#add-one').modal({ backdrop: "static" });
    });
    // 4.使用者點按確定修改。
    let $EditSubmit;
    $('#EditSubmit').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $EditSubmit = $(this);
        // 5.系統驗証3輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            SalaryClassSEdit: $('#SalaryClassSEdit').val(),
            ClassSalaryEdit: $('#ClassSalaryEdit').val()
        };
        var msgObj = {
            SalaryClassSEdit: "科目代碼必填！",
            ClassSalaryEdit: "科目名稱必填！"
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
            // 6.系統以ajax呼叫Post Action【SalaryClass/PutSalaryClass】，並傳送3輸入資料以及jSalaryClassId。
            $('#EditForm').ajaxSubmit({
                data: { "SalaryClassId": jSalaryClassId },
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
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值==3
                // 12c-1.系統顯示科目名稱重覆。
                alert("修改失敗,科目名稱重覆！");
            }
            else {
                // 12d.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/2
                //  12d-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    // 1.使用者在薪資類別管理首頁點按某一列薪資類別之刪除。
    $(document).on('click', '.btn-delete', function (event) {
        if (!confirm('確定刪除？')) return;
        // 2.使用者確認要刪除。
        var $this = $(this);
        $selecteditadmin = $this.closest('tr');
        jSalaryClassId = $selecteditadmin.find("td:eq(0)").text();
        // 3.系統以ajax呼叫Post Action【SalaryClass/DeleteSalaryClass】，並傳送1點按列之SalaryClassId。
        $.ajax({
            type: 'POST',
            cache: false,
            url: setting.DeleteSalaryClassUrl,
            data: { "SalaryClassId": jSalaryClassId },
            beforeSend: DeleteBefore,
            success: DeleteSuccess,
            error: SystemError
        });

        function DeleteBefore() { }

        function DeleteSuccess(response) {
            if (response === 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                alert('刪除成功');
                // 8.系統將刪除列自管理者清單列中去除。
                $selecteditadmin.html('');
            }
            else if (response === 1) {
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
function GetSalaryClassListSuccess(response) {
    // 6.系統在3啟動之ajax呼叫回呼函式中將<Div SalaryClassList>.Html()更新為9-7回傳View。
    $('Div#SalaryClassList').html(response);
    // 11.結束。
}
function LoadBefore() { }
function SystemError() {
    alert('系統錯誤，請稍後再試！');
}