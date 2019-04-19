let jDepartmentId, jDepartment, jDepartmentIdP, jPositionId, jPosition, jEmployeeName, jDepartmentE, jEmployeeMobile;
function Employeefunction(option) {
    var setting = {
        GetDepartmentListUrl: '',
        GetDepartmentLevelPathUrl: '',
        DeleteDepartmentUrl: '',
        GetPositionListUrl: '',
        DeletePositionUrl: '',
        GetEmployeeListUrl: '',
        DeleteEmployeeUrl: '',
        ValidatePositionUrl: '',
        PutEmployeePositionUrl: '',
        GetEmployeeRightUrl: '',
        PutEmployeeRightsUrl: ''
    };
    setting = $.extend(setting, option);
    jDepartmentId = setting.jDepartmentId;
    // 1.使用者在部門員工管理首頁輸入部門名稱並按查詢。
    $(document).on('click', '#btnSearchEmployee', function (event) {
        event.preventDefault();
        // 2.系統將1輸入資料暫存至jDepartment。
        jDepartment = $('#Department').val();
        // 3.系統以ajax呼叫Get Action【Employee/GetDepartmentList】，並傳送jDepartment jDepartmentId,。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetDepartmentListUrl,
            data: {
                'DepartmentId': jDepartmentId,
                'Department': jDepartment
            },
            beforeSend: LoadBefore,
            success: GetDepartmentListSuccess,
            error: SystemError
        });
    });
    // 1.使用者在部門清單點按換頁連結。
    $(document).on('click', '.page-link', function (event) {
        event.preventDefault();
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 3.系統以ajax呼叫Get Action【Employee/GetDepartmentList】，並傳送jDepartmentId ,jDepartment與1點按頁碼。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: href[0],
            data: {
                'DepartmentId': jDepartmentId,
                'Department': jDepartment,
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1])
            },
            beforeSend: LoadBefore,
            success: GetDepartmentListSuccess,
            error: SystemError
        });
    });
    // 1.使用者在部門階層清單點按部門名稱連結。
    $(document).on('click', 'a.DepartmentLevelPathList', function (event) {
        event.preventDefault();
        // 2..系統設定jDepartmentId=1點按之data-DepartmentId，jDepartment=''"。
        jDepartmentId = $(this).attr('title');
        jDepartment = '';
        //alert(jDepartmentId);
        // 2.系統以ajax呼叫Post Controller Action【Employee/GetDepartmentList】，並傳送jDepartmentId與jDepartment。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetDepartmentListUrl,
            data: {
                'DepartmentId': jDepartmentId,
                'Department': jDepartment
            },
            beforeSend: LoadBefore,
            success: GetDepartmentListSuccess,
            error: SystemError
        });
        // 11.系統以ajax呼叫Post Controller Action【Employee/GetDepartmentLevelPath】，並傳送jDepartmentId。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetDepartmentLevelPathUrl,
            data: {
                'DepartmentId': jDepartmentId
            },
            beforeSend: LoadBefore,
            success: GetDepartmentLevelPathSuccess,
            error: SystemError
        });
    });
    // 1.使用者在部門管理首頁點按新增。
    $('#btnAddEmployee').on('click', function (event) {
        event.preventDefault();
        $('#add-one input').val('');
        $('#add-one textarea').val('');
        // 2.系統顯示[新增部門]對話盒。
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
        //5.系統驗証3輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            Department: $('#DepartmentC').val()
        };
        var msgObj = {
            Department: "部門名稱必填！"
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
            // 6.系統以ajax呼叫Post Action【Employee/PostDepartment】，並傳送3輸入資料以及jDepartmentId。
            $('#CreateForm').ajaxSubmit({
                data: { "DepartmentId": jDepartmentId },
                beforeSubmit: LoadBefore,
                success: CreateSuccess,
                error: SystemError
            });
        }

        $CreateSubmit.prop("disabled", false);

        function CreateSuccess(response) {
            if (response === 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示新增成功。
                alert("新增成功！");
                $('#add-one').modal("hide");
            }
            else if (response === 1) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==1
                //  12a-1.系統顯示無此權限。
                alert("無此權限！");
            }
            else if (response === 2) {
                // 12b.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                // 12b-1.系統顯示分部門重覆。
                alert("新增失敗,可能是部門名稱重覆！");
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/2
                //  12c-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    // 1.使用者在部門管理首頁點按某一列部門之修改。
    let $this;
    $(document).on('click', '.btn-edit', function (event) {
        event.preventDefault();
        $this = $(this);
        $('#add-one input').val('');
        $('#add-one textarea').val('');
        // 2.系統顯示[修改部門]對話盒，並將1點按列之資料顯示於對應輸入元件。
        $('#EditForm').attr('Style', '');
        $('#CreateForm').attr('Style', 'display: none;');
        $('#add-one').modal({ backdrop: "static" });
        jDepartmentIdP = $(this).closest('tr').find("td:eq(0)").text();
        $('#DepartmentCEdit').val($(this).closest('tr').find("td:eq(1)").text());
        $('#DepartmentDescriptionEdit').val($(this).closest('tr').find("td:eq(2)").text());
    });
    // 4.使用者點按確定修改。
    $('#EditSubmit').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $EditSubmit = $(this);
        //5.系統驗証3輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            Department: $('#DepartmentCEdit').val()
        };
        var msgObj = {
            Department: "部門名稱必填！"
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
            // 6.系統以ajax呼叫Post Action【Employee/PuttDepartment】，並傳送3輸入資料以及jDepartmentId。
            $('#EditForm').ajaxSubmit({
                data: { "DepartmentId": jDepartmentIdP },
                beforeSubmit: LoadBefore,
                success: EditSuccess,
                error: SystemError
            });
        }

        $EditSubmit.prop("disabled", false);

        function EditSuccess(response) {
            if (response === 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示修改成功。
                alert("修改成功！");
                $('#add-one').modal("hide");
            }
            else if (response === 1) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==1
                //  12a-1.系統顯示無此權限。
                alert("無此權限！");
            }
            else if (response === 2) {
                // 12b.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                // 12b-1.系統顯示分部門重覆。
                alert("新增失敗,可能是部門名稱重覆！");
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/2
                //  12c-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    // 1.使用者在部門管理首頁點按某一列部門之刪除。
    $(document).on('click', '.btn-delete', function (event) {
        if (!confirm('確定刪除？')) return;
        // 2.使用者確認要刪除。
        var $this = $(this);
        $selecteditadmin = $this.closest('tr');
        let EditDepartmentId = $selecteditadmin.find("td:eq(0)").text();
        // 3.系統以ajax呼叫Post Action【Employee/DeleteDepartment】，並傳送1點按列之DepartmentId。
        $.ajax({
            type: 'POST',
            cache: false,
            url: setting.DeleteDepartmentUrl,
            data: { "DepartmentId": EditDepartmentId },
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
    // 1.使用者在某一列部門點按新職務。
    $(document).on('click', '.btn-new-position', function (event) {
        event.preventDefault();
        $this = $(this);
        $('#add-oneP input').val('');
        $('#add-oneP textarea').val('');
        // 2.系統顯示[新增職務]對話盒，並顯示1點按部門名稱，將1點按部門代碼暫存在jDepartmentIdP。
        $('#DepartmentP').val($(this).closest('tr').find("td:eq(1) a").text());
        jDepartmentIdP = $(this).closest('tr').find("td:eq(0)").text();
        $('#CreateFormP').attr('Style', '');
        $('#EditFormP').attr('Style', 'display: none;');
        $('#add-oneP').modal({ backdrop: "static" });
    });
    // 4.使用者點按確定新增。
    $('#CreateSubmitP').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmit = $(this);
        //5.系統驗証3輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            Position: $('#PositionC').val()
        };
        var msgObj = {
            Department: "職務名稱必填！"
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
            // 6.系統以ajax呼叫Post Action【Employee/PostPosition】，並傳送3輸入資料以及jDepartmentIdP。
            $('#CreateFormP').ajaxSubmit({
                data: { "DepartmentId": jDepartmentIdP },
                beforeSubmit: LoadBefore,
                success: CreateSuccess,
                error: SystemError
            });
        }

        $CreateSubmit.prop("disabled", false);

        function CreateSuccess(response) {
            if (response === 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示新增成功。
                alert("新增成功！");
                $('#add-oneP').modal("hide");
            }
            else if (response === 1) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==1
                //  12a-1.系統顯示無此權限。
                alert("無此權限！");
            }
            else if (response === 2) {
                // 12b.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                // 12b-1.系統顯示職務重覆。
                alert("新增失敗,可能是職務名稱重覆！");
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/2
                //  12c-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    // 1.在部門員工管理首頁點按某一筆部門之職務/隠藏。
    let $tr;
    $(document).on('click', '.btn-position', function (event) {
        event.preventDefault();
        var $this = $(this);
        // 1-1.系統將1點按部門Id暫存在jDepartmentIdP。
        jDepartmentIdP = $(this).closest('tr').find("td:eq(0)").text();
        jDepartment = $(this).closest('tr').find("td:eq(1)").text();
        $tr = $this.closest("tr");
        if ($this.find("span").first().hasClass("glyphicon-minus")) {
            //2a.系統判斷javascript變數IsSpread=true。
            //2a-1.系統清除下一個<tr>之html()，以隠藏下線之下線清單。
            $(this).closest("tr").next().html('');
            //2a-2.系統設定javascript變數IsSpread=false。
            //isSpread = false;
            //2a-3.系統設定展開按鈕圖示為+(展開)。
            $this.find("span").attr('title', '職務');
            $this.find("span").first().removeClass();
            $this.find("span").first().addClass('glyphicon glyphicon-th-list');
            //2a-4.結束。
            return;
        }
        // 2.系統判斷javascript變數IsSpread=false(預設值為false)。
        // 3.系統以ajax呼叫Post Controller Action【Employee/GetPositionList】，並傳送jDepartmentIdP。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetPositionListUrl,
            data: {
                'DepartmentId': jDepartmentIdP,
                'AClass': 'inner-page-link'
            },
            beforeSend: ExpandBefore,
            success: ExpandSuccess,
            error: SystemError
        });

        function ExpandBefore() { }

        function ExpandSuccess(response) {
            // 10.系統在3啟動之ajax回呼函式中將下一列<tr>的Html內容更新為9-7.系統回傳View。
            $this.closest("tr").next().html('<td colspan="4">' + response + '</td>');
            // 10-1.系統設定javascript變數IsSpread=true。
            //isSpread = true;
            // 10-2.系統設定展開按鈕圖示為-(隱藏)。
            $this.find("span").attr('title', '隠藏');
            $this.find("span").first().removeClass();
            $this.find("span").first().addClass('glyphicon glyphicon-minus');
            // 11.結束。
        }
    });
    // 1.在職務清單點按換頁連結。
    $(document).on('click', '.inner-page-link', function (event) {
        //alert("");
        event.preventDefault();
        var $this = $(this);
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 3.系統以ajax呼叫Post Controller Action【Employee/GetPositionList】，並傳送jDepartmentIdP與1點按頁碼。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: href[0],
            data: {
                'DepartmentId': jDepartmentIdP,
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
            $tr.next().html('<td colspan="4">' + response + '</td>');
            // 11.結束。
        }
    });
    // 1.使用者在部門管理首頁點按某一列職務之修改。
    $(document).on('click', '.btn-edit-position', function (event) {
        event.preventDefault();
        $this = $(this);
        $('#add-oneP input').val('');
        $('#add-oneP textarea').val('');
        // 2.系統顯示[修改職務]對話盒，並將1點按列之資料顯示於對應輸入元件。
        $('#DepartmentPEdit').val(jDepartment);
        $('#PositionCEdit').val($(this).closest('tr').find("td:eq(1)").text());
        $('#PositionDescriptionEdit').val($(this).closest('tr').find("td:eq(2)").text());
        jPositionId = $(this).closest('tr').find("td:eq(0)").text();
        $('#EditFormP').attr('Style', '');
        $('#CreateFormP').attr('Style', 'display: none;');
        $('#add-oneP').modal({ backdrop: "static" });
    });
    // 4.使用者點按確定修改。
    $('#EditSubmitP').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $EditSubmit = $(this);
        //5.系統驗証3輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            Position: $('#PositionCEdit').val()
        };
        var msgObj = {
            Department: "職務名稱必填！"
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
            // 6.系統以ajax呼叫Post Action【Employee/PutPosition】，並傳送3輸入資料與1點按列之PositionId。
            $('#EditFormP').ajaxSubmit({
                data: { "PositionId": jPositionId },
                beforeSubmit: LoadBefore,
                success: EditSuccess,
                error: SystemError
            });
        }

        $EditSubmit.prop("disabled", false);

        function EditSuccess(response) {
            if (response === 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示修改成功。
                alert("修改成功！");
                $('#add-oneP').modal("hide");
            }
            else if (response === 1) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==1
                //  12a-1.系統顯示無此權限。
                alert("無此權限！");
            }
            else if (response === 2) {
                // 12b.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                // 12b-1.系統顯示職務重覆。
                alert("新增失敗,可能是職務名稱重覆！");
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/2
                //  12c-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    // 1.使用者在部門管理首頁點按某一列職務之刪除。
    $(document).on('click', '.btn-delete-position', function (event) {
        if (!confirm('確定刪除？')) return;
        // 2.使用者確認要刪除。
        var $this = $(this);
        $selecteditadmin = $this.closest('tr');
        let jPositionId = $selecteditadmin.find("td:eq(0)").text();
        // 3.系統以ajax呼叫Post Action【Employee/DeletePosition】，並傳送1點按列之PositionId。
        $.ajax({
            type: 'POST',
            cache: false,
            url: setting.DeletePositionUrl,
            data: { "PositionId": jPositionId },
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
            //else if (response == 3) {
            //    // 12b.系統在6啟動之ajax回呼函式中判斷11傳回值==3
            //    //  12a-1.系統顯示有子分類。
            //    alert('無法刪除有子分類之分類！');
            //    //  13b-2.結束。
            //}
            //else if (response == 4) {
            //    // 12d.系統在6啟動之ajax回呼函式中判斷11傳回值==4
            //    //  12d-1.系統顯示有商品。
            //    alert('無法刪除有商品之分類！');
            //    //  13b-2.結束。
            //}
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/2
                //  13c-1.系統顯示"刪除失敗"。
                alert('刪除失敗，請稍後再試！');
                //  13a-2.結束。
            }
        }
    });
    // 1.使用者在某一列職務點按新員工。
    $(document).on('click', '.btn-new-employee', function (event) {
        event.preventDefault();
        $this = $(this);
        $('#add-oneE input').val('');
        $('#add-oneE textarea').val('');
        // 2.系統顯示[新增員工]對話盒，並顯示1點按職務名稱，將1點按職務代碼暫存在jPositionId。
        $('#PositionE').val($(this).closest('tr').find("td:eq(1)").text());
        jPositionId = $(this).closest('tr').find("td:eq(0)").text();
        $('#CreateFormE').attr('Style', '');
        $('#EditFormE').attr('Style', 'display: none;');
        $('#add-oneE').modal({ backdrop: "static" });
    });
    // 4.使用者點按確定新增。
    $('#CreateSubmitE').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmit = $(this);
        //5.系統驗証3輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            EmployeeName: $('#EmployeeName').val(),
            Birthday: $('#Birthday').val(),
            Duedate: $('#Duedate').val(),
            sex: $('#sex').val(),
            EmployeeMobile: $('#EmployeeMobile').val(),
            BaseSalary: $('#BaseSalary').val(),
            ID: $('#ID').val(),
            eMail: $('#eMail').val(),
            ContactPhone: $('#ContactPhone').val(),
            ContactAddress: $('#ContactAddress').val()
        };
        var msgObj = {
            EmployeeName: "員工姓名必填！",
            Birthday: "生日必填！",
            Duedate: "到職日必填！",
            sex: "性別必填！",
            EmployeeMobile: "手機必填！",
            BaseSalary: "本薪必填！",
            ID: "身份字號必填！",
            eMail: "eMail必填！",
            ContactPhone: "聯絡電話必填！",
            ContactAddress: "聯絡地址必填！"
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
            // 6.系統以ajax呼叫Post Action【Employee/PostEmployee】，並傳送3輸入資料以及jPositionId。
            $('#CreateFormE').ajaxSubmit({
                data: { "PositionId": jPositionId },
                beforeSubmit: LoadBefore,
                success: CreateSuccess,
                error: SystemError
            });
        }

        $CreateSubmit.prop("disabled", false);

        function CreateSuccess(response) {
            if (response === 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示新增成功。
                alert("新增成功！");
                $('#add-oneE').modal("hide");
            }
            else if (response === 1) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==1
                //  12a-1.系統顯示無此權限。
                alert("無此權限！");
            }
            else if (response === 2) {
                // 12b.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                // 12b-1.系統顯示手機重覆。
                alert("新增失敗,可能是手機重覆！");
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/2
                //  12c-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
    // 1.使用者在在部門員工管理首頁點按某一筆部門職務之員工。
    $(document).on('click', '.btn-employee', function (event) {
        event.preventDefault();
        // 1-1.系統將1點按職務名稱暫存在jPosition。
        jDepartmentE = jDepartment;
        jPosition = $(this).closest('tr').find("td:eq(1)").text();
        jEmployeeName = '';
        // 2.系統以ajax呼叫Post Controller Action【Employee/GetEmployeeList】，並傳送jDepartment,jPosition與''。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetEmployeeListUrl,
            data: {
                'Department': jDepartmentE,
                'Position': jPosition,
                'EmployeeName': jEmployeeName,
                'AClass': 'emp-page-link'
            },
            beforeSend: LoadBefore,
            success: GetEmployeeListSuccess,
            error: SystemError
        });
    });
    // 1.使用者在在部門員工管理首頁之員工區輸入職務名稱與員工名稱再按查詢。
    $(document).on('click', '#btnSearchEmployeeEF', function (event) {
        event.preventDefault();
        // 1-1.系統將1輸入資料暫存在jDepartmentE、jPosition、jEmployeeName。
        jDepartmentE = $("#DepartmentEF").val();
        jPosition = $("#PositionEF").val();
        jEmployeeName = $("#EmployeeNameEF").val();
        // 2.系統以ajax呼叫Post Controller Action【Employee/GetEmployeeList】，並傳送jDepartmentE、jPosition、jEmployeeName。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetEmployeeListUrl,
            data: {
                'Department': jDepartmentE,
                'Position': jPosition,
                'EmployeeName': jEmployeeName,
                'AClass': 'emp-page-link'
            },
            beforeSend: LoadBefore,
            success: GetEmployeeListSSuccess,
            error: SystemError
        });
    });
    // 1.使用者在在部門員工管理首頁之員工清單點按某一個頁碼。
    $(document).on('click', '.emp-page-link', function (event) {
        //alert("");
        event.preventDefault();
        var $this = $(this);
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 3.系統以ajax呼叫Post Controller Action【Employee/GetPositionList】，並傳送jDepartmentIdP與1點按頁碼。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: href[0],
            data: {
                'Department': jDepartmentE,
                'Position': jPosition,
                'EmployeeName': jEmployeeName,
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1]),
                'AClass': 'emp-page-link'
            },
            beforeSend: LoadBefore,
            success: GetEmployeeListSSuccess,
            error: SystemError
        });
    });
    // 1.使用者在某一列員工點按修改。
    $(document).on('click', '.btn-edit-Employee', function (event) {
        event.preventDefault();
        $this = $(this);
        $('#add-oneE input').val('');
        $('#add-oneE textarea').val('');
        // 2.系統顯示[修改員工]對話盒，並顯示1點按員工資料，將1點按員工代碼暫存在jEmployeeMobile。
        $('#PositionEEdit').val($(this).closest('tr').find("td:eq(7)").text());
        $('#EmployeeNameEdit').val($(this).closest('tr').find("td:eq(1)").text());
        $('#BirthdayEdit').val($(this).closest('tr').find("td:eq(3)").text());
        $('#DuedateEdit').val($(this).closest('tr').find("td:eq(4)").text());
        $('#sexEdit').val($(this).data('sex'));
        jEmployeeMobile = $(this).closest('tr').find("td:eq(0)").text();
        $('#EmployeeMobileEdit').val(jEmployeeMobile);
        $('#BaseSalaryEdit').val($(this).closest('tr').find("td:eq(8)").text());
        $('#IDEdit').val($(this).data('id'));
        $('#LineIdEdit').val($(this).data('lineid'));
        $('#eMailEdit').val($(this).data('email'));
        $('#ContactPhoneEdit').val($(this).data('contactphone'));
        $('#ContactAddressEdit').val($(this).data('contactaddress'));
        $('#EmergencyContactEdit').val($(this).closest('tr').find("td:eq(5)").text());
        $('#EmergencyContactPhoneEdit').val($(this).closest('tr').find("td:eq(6)").text());
        $('#EditFormE').attr('Style', '');
        $('#CreateFormE').attr('Style', 'display: none;');
        $('#add-oneE').modal({ backdrop: "static" });
    });
    // 4.使用者點按確定修改。
    $('#EditSubmitE').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmit = $(this);
        //5.系統驗証3輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            EmployeeName: $('#EmployeeNameEdit').val(),
            Birthday: $('#BirthdayEdit').val(),
            Duedate: $('#DuedateEdit').val(),
            sex: $('#sexEdit').val(),
            EmployeeMobile: $('#EmployeeMobileEdit').val(),
            BaseSalary: $('#BaseSalaryEdit').val(),
            ID: $('#IDEdit').val(),
            eMail: $('#eMailEdit').val(),
            ContactPhone: $('#ContactPhoneEdit').val(),
            ContactAddress: $('#ContactAddressEdit').val()
        };
        var msgObj = {
            EmployeeName: "員工姓名必填！",
            Birthday: "生日必填！",
            Duedate: "到職日必填！",
            sex: "性別必填！",
            EmployeeMobile: "手機必填！",
            BaseSalary: "本薪必填！",
            ID: "身份字號必填！",
            eMail: "eMail必填！",
            ContactPhone: "聯絡電話必填！",
            ContactAddress: "聯絡地址必填！"
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
            // 6.系統以ajax呼叫Post Action【Employee/PostEmployee】，並傳送3輸入資料。
            $('#EditFormE').ajaxSubmit({
                beforeSubmit: LoadBefore,
                success: CreateSuccess,
                error: SystemError
            });
        }

        $CreateSubmit.prop("disabled", false);

        function CreateSuccess(response) {
            if (response === 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示修改成功。
                alert("修改成功！");
                $('#add-oneE').modal("hide");
            }
            else if (response === 1) {
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
    // 1.使用者在部門管理首頁點按某一列員工之刪除。
    $(document).on('click', '.btn-delete-Employee', function (event) {
        if (!confirm('確定刪除？')) return;
        // 2.使用者確認要刪除。
        var $this = $(this);
        $selecteditadmin = $this.closest('tr');
        jEmployeeMobile = $(this).closest('tr').find("td:eq(0)").text();
        // 3.系統以ajax呼叫Post Action【Employee/DeleteEmployee】，並傳送1點按列之EmployeeMotile。
        $.ajax({
            type: 'POST',
            cache: false,
            url: setting.DeleteEmployeeUrl,
            data: { "EmployeeMotile": jEmployeeMobile },
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
    // 1.使用者在某一列員工點按變更職務。
    $(document).on('click', '.btn-employee-position', function (event) {
        event.preventDefault();
        $this = $(this);
        $('#add-onePO input').val('');
        $('#add-onePO textarea').val('');
        // 2.系統顯示[變更職]對話盒，並顯示1點按員工名稱/職務名稱/部門名稱，將1點按員工代碼暫存在jEmployeeMobile。
        $('#EmployeeNamePO').val($(this).closest('tr').find("td:eq(1)").text());
        $('#PositionPO').val($(this).closest('tr').find("td:eq(7)").text());
        jEmployeeMobile = $(this).closest('tr').find("td:eq(0)").text();
        $('#add-onePO').modal({ backdrop: "static" });
    });
    // 4.使用者按驗証職務名稱。
    $('#ValidatePosition').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmit = $(this);
        // 4-1.系統驗証3輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            Position: $('#PositionPO').val()
        };
        var msgObj = {
            Position: "職務名稱必填！"
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
            // 4-2.系統以ajax呼叫Post Action【Employee/ValidatePosition】，並傳送3輸入職務名稱。
            $.ajax({
                type: 'POST',
                cache: false,
                dataType: 'json',
                url: setting.ValidatePositionUrl,
                data: { "Position": $('#PositionPO').val() },
                beforeSend: LoadBefore,
                success: ValidatePositionSuccess,
                error: SystemError
            });
        }

        $CreateSubmit.prop("disabled", false);

        function ValidatePositionSuccess(response) {
            if (response.position !== null) {
                // 4-6.系統在4-2啟動之ajax回呼函式中判斷11傳回值!=null。
                // 4-7.系統將4-5回傳Department顯示在部門名稱輸入盒
                $("#DepartmentPO").val(response.position.department);
                // 4-8.系統致能變更職務按鈕。
                $("#CreateSubmitPO").prop("disabled", false);
            }
            else {
                // 4-6a.系統在6啟動之ajax回呼函式中判斷11傳回值==null。
                //  4-6a-1.系統顯示無效職務。
                alert("無效職務！");
                //  4-6a-2.系統將部門名稱輸入盒清為空白。
                $('#DepartmentPO').val('');
                //  4-6a-3.系統禁能變更職務按鈕。
                $("#CreateSubmitPO").prop("disabled", true);
            }
            // 14.結束。
        }
    });
    // 4-9.使用者點按變更職務。
    $('#CreateSubmitPO').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmit = $(this);
        // 5.系統驗証3輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            Position: $('#PositionPO').val()
        };
        var msgObj = {
            Position: "職務名稱必填！"
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
            // 6.系統以ajax呼叫Post Action【Employee/PutEmployeePosition】，並傳送3輸入資料以及jEmployeeMobile。
            $.ajax({
                type: 'POST',
                url: setting.PutEmployeePositionUrl,
                data: {
                    "Position": $('#PositionPO').val(), "EmployeeMotile": jEmployeeMobile
                },
                beforeSend: LoadBefore,
                success: PutEmployeePositionSuccess,
                error: SystemError
            });
        }

        $CreateSubmit.prop("disabled", false);

        function PutEmployeePositionSuccess(response) {
            if (response === 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示變更職務成功。
                alert("變更職務成功！");
            }
            else if (response === 1) {
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
    // 1.使用者在某一列員工點按員工權限。
    $(document).on('click', '.btn-employee-right', function (event) {
        event.preventDefault();
        $this = $(this);
        $('#rights').html('');
        jEmployeeMobile = $(this).closest('tr').find("td:eq(0)").text();
        // 2.系統以ajax呼叫Post Action【Employee/GetEmployeeRight】，並傳送1點按員工之EmployeeMobile。
        $.ajax({
            type: 'POST',
            cache: false,
            dataType: 'json',
            url: setting.GetEmployeeRightUrl,
            data: { "EmployeeMobile": jEmployeeMobile },
            beforeSend: LoadBefore,
            success: GetEmployeeRightSuccess,
            error: SystemError
        });
        function GetEmployeeRightSuccess(response) {
            // 5.系統在2啟動之ajax回呼函式中顯示[員工權限]對話盒，並將4傳回值，顯示為checkbox清單。
            let doc = '', check = false, col = 0;
            for (var item in response.right) {
                if (col % 3 === 0) {
                    doc += '<div class="row"><div class="col-xs-2"></div>';
                }
                if (response.rights.includes(response.right[item].employeeRightId) === true) {
                    doc += '<div class="col-xs-3"><label class="checkbox-inline"><input type="checkbox" value="' + response.right[item].employeeRightId + '" checked>' + response.right[item].rightzhtw + '</label></div>';
                }
                else {
                    doc += '<div class="col-xs-3"><label class="checkbox-inline"><input type="checkbox" value="' + response.right[item].employeeRightId + '">' + response.right[item].rightzhtw + '</label></div>';
                }
                if (col % 3 === 2) {
                    doc += '</div>';
                }
                col += 1;
            }
            $('Div#rights').html(doc);
            $('#add-oneR').modal({ backdrop: "static" });
            // 11.結束。
        }
    });
    // 6.使用者勾選權限後點按變更權限。
    $('#CreateSubmitR').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmit = $(this);

        // 7.系統以ajax呼叫Post Action【Employee/PutEmployeeRights】，並傳送6輸入資料以及jEmployeeMobile。
        let rights = '';
        $("#rights input:checkbox").each(function () {
            if ($(this).prop("checked")) {
                rights += $(this).val() + ',';
            }
        });
        $.ajax({
            type: 'POST',
            url: setting.PutEmployeeRightsUrl,
            data: {
                "rights": rights, "EmployeeMobile": jEmployeeMobile
            },
            beforeSend: LoadBefore,
            success: PutEmployeeRightsSuccess,
            error: SystemError
        });

        $CreateSubmit.prop("disabled", false);

        function PutEmployeeRightsSuccess(response) {
            if (response === 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示變更權限成功。
                alert("變更職權限成功！");
            }
            else if (response === 1) {
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
    // 6.使用者按變更密碼。
    $('#CreateSubmitPS').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmit = $(this);
        // 7.系統驗証6輸入資料無誤
        var status = true,
            error = "";
        if ($("#NewPassword").val() !== $("#NewPasswordConfirm").val()) {
            alert("確密密碼內容與宓碼必須相同！");
            return;
        }
        var checkObj = {
            OldPassword: $('#OldPassword').val(),
            NewPassword: $('#NewPassword').val()
        };
        var msgObj = {
            OldPassword: "舊密碼必填！",
            NewPassword: "新密碼必填！"
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
            // 8.系統以ajax呼叫Post Action【Employee/PutEmployeePassword】，並傳送3輸入舊密碼與新密碼。
            $('#CreateFormPS').ajaxSubmit({
                beforeSubmit: LoadBefore,
                success: CreateSuccess,
                error: SystemError
            });
        }

        $CreateSubmit.prop("disabled", false);

        function CreateSuccess(response) {
            if (response === 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示變更成功。
                alert("變更成功！");
            }
            else if (response === 1) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==1
                //  12a-1.系統顯示舊密碼錯誤。
                alert("舊密碼錯誤！");
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1
                //  12c-1.系統顯示執行失敗，請再試一次。
                alert("執行失敗，請再試一次！");
            }
            // 14.結束。
        }
    });
}
function GetDepartmentListSuccess(response) {
    // 10.系統在3啟動之ajax呼叫回呼函式中將<Div DepartmentList>.Html()更新為9-7回傳View。
    $('Div#DepartmentList').html(response);
    // 11.結束。
}
function GetDepartmentLevelPathSuccess(response) {
    // 13.系統在啟動之ajax回呼函式中更新<Div DepartmentLevelPath>內容為8-2傳回值。
    $('Div#DepartmentLevelPath').html(response);
}
function GetEmployeeListSuccess(response) {
    // 10.系統在2啟動之ajax回呼函式中將<div EmployeeList>.html()設為9-7傳回值。
    $('Div#EmployeeList').html(response);
    // 11.系統顯示下列元件內容：
    //  	DepartmentEF = jDepartment
    $('#DepartmentEF').val(jDepartmentE);
    //  	PositionEF = 點按列之職務名稱
    $('#PositionEF').val(jPosition);
    //  	EmployeeNameEF = ''
    $('#EmployeeNameEF').val('');
}
function GetEmployeeListSSuccess(response) {
    // 10.系統在2啟動之ajax回呼函式中將<div EmployeeList>.html()設為9-7傳回值。
    $('Div#EmployeeList').html(response);
}

function LoadBefore() { }
function SystemError() {
    alert('系統錯誤，請稍後再試！');
}