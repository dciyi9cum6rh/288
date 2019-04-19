let jHomeImageSubject = '', jHomeImageId;
function HomeImagefunction(option) {
    var setting = {
        GetHomeImageListUrl: '',
        DeleteHomeImageUrl: ''
    };
    setting = $.extend(setting, option);
    // 1.使用者在ERP系統首頁行銷圖示管理之首頁行銷圖示清單點按換頁連結。
    $(document).on('click', '.page-link', function (event) {
        event.preventDefault();
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 33.系統以ajax呼叫Get Action【HomeImage/GetHomeImageList】，並傳送jHomeImageSubject以及1點按頁碼。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetHomeImageListUrl,
            data: {
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1])
            },
            beforeSend: LoadBefore,
            success: GetHomeImageListSuccess,
            error: SystemError
        });
    });
    // 1.使用者在首頁行銷圖示管理首頁點按新增圖示。
    $(document).on('click', '#btnAdd', function (event) {
        event.preventDefault();
        //// 1-1.系統將1點按首頁行銷圖示Id暫存在jHomeImageId。
        //jHomeImageId = $(this).closest("tr").find("td:eq(1)").text();
        // 2.系統顯示[修改首頁行銷圖示]對話盒。
        $('#add-oneI input').val('');
        $('#add-oneI textarea').val('');
        $('#CreateFormI').attr('Style', '');
        $('#EditFormI').attr('Style', 'display: none;');
        $('#add-oneI').modal({ backdrop: "static" });
    });
    // 4.使用者點按確定修新增。
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
            PictureContent: "首頁行銷圖示必填！"
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
            // 6.系統以ajax呼叫Post Action【HomeImage/PostHomeImageImage】，並傳送3輸入資料與。
            //alert(jHomeImageId);
            $('#CreateFormI').ajaxSubmit({
                //data: { 'HomeImageId': jHomeImageId },
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
                // 13.系統顯示新增改成功。
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
    // 1.使用者在首頁行銷圖示清單某一列點按修改。
    $(document).on('click', '.btn-edit', function (event) {
        event.preventDefault();
        // 1-1.系統將1點按首頁行銷圖示Id暫存在jHomeImageId，並將1點按列之說明顯示在對應輸入盒。
        jHomeImageId = $(this).closest("tr").find("td:eq(0)").text();
        $('#add-oneI input').val('');
        $('#add-oneI textarea').val('');
        $('#HomeImageDescriptionEdit').val($(this).closest("tr").find("td:eq(3)").text());
        // 2.系統顯示[修改首頁行銷圖示]對話盒。
        $('#EditFormI').attr('Style', '');
        $('#CreateFormI').attr('Style', 'display: none;');
        $('#add-oneI').modal({ backdrop: "static" });
    });
    // 4.使用者點按確定修改。
    $('#EditSubmitI').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmitI = $(this);
        // 5.系統驗証3輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            PictureContent: $('#PictureContentIEdit').val()
        };

        var msgObj = {
            PictureContent: "首頁行銷圖示必填！"
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
            // 6.系統以ajax呼叫Post Action【HomeImage/PutHomeImage】，並傳送3輸入資料以及jHomeImageId。
            $('#EditFormI').ajaxSubmit({
                data: { 'HomeImageId': jHomeImageId },
                beforeSubmit: EditIBefore,
                success: EditISuccess,
                error: SystemError
            });
        }

        $CreateSubmitI.prop("disabled", false);

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
    // 1.使用者在首頁行銷圖示清單某一列點按刪除。
    $(document).on('click', '.btn-delete', function (event) {
        if (!confirm('確定刪除？')) return;
        // 2.使用者確認要刪除。
        var $this = $(this);
        $selecteditadmin = $this.closest('tr');
        // 1-1.系統將1點按首頁行銷圖示Id暫存在jHomeImageId。
        jHomeImageId = $(this).closest("tr").find("td:eq(0)").text();
        // 6.系統以ajax呼叫Post Action【HomeImage/DeleteHomeImage】，並傳送jHomeImageId。
        $.ajax({
            type: 'POST',
            cache: false,
            url: setting.DeleteHomeImageUrl,
            data: { "HomeImageId": jHomeImageId },
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
function GetHomeImageListSuccess(response) {
    // 10.系統在2啟動之ajax回呼函式中將<Div HomeImageList>的內容更新為9-7傳回值。
    $('Div#HomeImageList').html(response);
    // 11.結束。
}
function LoadBefore() { }
function SystemError() {
    alert('系統錯誤，請稍後再試！');
}