var SalaryDatas = [];
var BaseSalary = 0;

//20181212 ---棋
function Orderfunction(option) {
    var setting = {
        GetAccountSalary: '',
        GetEmployeeMonthSalary: '',
        PostInsertSalary: '',
        PostSalaryMonthEmployeeDetailList: '',
        GetSalaryClassList: '',
        GetDeleteSalary: '',
    };
    setting = $.extend(setting, option);

    //8.系統在4啟動之aax回呼函式中判斷7傳回值===0。
    //9.系統顯示營運獎金計算成功。
    function CaculateMemberBonus(data) {
        data === 0 ? (alert("員工薪資入賬成功")) : ("");
        data === -1 ? (alert("執行錯誤，請稍後再試！")) : ("");
        data === -2 ? (alert("月份還在進行中！")) : ("");
        data === -3 ? (alert("該月份薪資已經入帳！")) : ("");
        data === -4 ? (alert("該月份會計已經有薪資支出！")) : ("");
        data === -5 ? (alert("該月份還有人的薪資尚未調整！")) : ("");
        return;
    }
    function SystemError() {
        alert('執行錯誤，請稍後再試！');
    }
    function MemberBonusListResponse(response) {
        $('#EmployeeMonthSalary').html(response);
    }
    function SalaryData(Month, EmployeeMobile, SalaryClassId, Salary) {
        this.Month = Month;
        this.EmployeeMobile = EmployeeMobile;
        this.SalaryClassId = SalaryClassId;
        this.Salary = Salary;
    }
    function sum() {
        BaseSalary = 0
        var EmpBaseSalar = $(".EmpBaseSalar").show();
        for (var i = 0; i < EmpBaseSalar.length; i++) {
            BaseSalary += parseInt(EmpBaseSalar.eq(i).val());
        }
        var SalaryDetailData = $(".SalaryDetailData").show();
        for (var i = 0; i < SalaryDetailData.length; i++) {
            BaseSalary += parseInt(SalaryDetailData.eq(i).val());
        }
    }

    $('#selSalaryClass').on('change', function (e) {
        $('#txtSalary').val($("option:selected", this).data("classsalary"));
    });

    //20181211 ---棋
    //1.使用者在批發會員發展獎金管理首頁輸入日期並按獎金入帳。
    $(document).on('click', '#btnEntryAccount', event => {
        event.preventDefault();
        if ($('#sDate').val() == "") {
            alert("請輸入日期!");
            return;
        }
        //3.系統將1輸入資料暫存至jsDate。
        jsDate = ($('#sDate').val().substr(0, 4) + $('#sDate').val().substr(5, 2) + "01");
        console.log(jsDate); //測試用
        // 4.系統以ajax呼叫POST Action【MemberBonus / AccountMemberDevelopmentBonus】，並傳送jsDate
        $.ajax({
            type: 'POST',
            cache: false,
            dataType: 'Json',
            //url: setting.AccountMemberBonus,
            url: setting.GetAccountSalary,
            data: {
                'Month': jsDate,
            }
        })
            //6.系統判斷5成功執行。
            //7.系統回傳5傳回值。
            .done(CaculateMemberBonus)
            .fail(SystemError)
    })
    //20181210  ---棋
    //1.使用者在薪資管理首頁輸入員工手機/日期(月份)並按查詢。
    $(document).on('click', '#btnSearchEmpSalary', event => {
        event.preventDefault();
        //註.月份一定要填
        if ($('#sDate').val() == "") {
            alert("請輸入日期!");
            return;
        }
        jsDate = ($('#sDate').val().substr(0, 4) + $('#sDate').val().substr(5, 2) + "01");
        MemberMobile = $('#MemberMobile').val();
        //3.系統以ajax呼叫Get Action【MemberBonus/GetMemberBonusList】，並傳送jMemberMobile/jMemberMobileWhere/jsDate。
        //10.系統在3啟動之ajax呼叫回呼函式中將<Div MemberBonusList>.Html()更新為9-7回傳View。
        //4.系統以ajax呼叫POST Action【MemberBonus / CaculateMemberBonus】，並傳送jsDate
        $.ajax({
            type: 'POST',
            cache: false,
            dataType: 'HTML',
            url: setting.GetEmployeeMonthSalary,
            data: {
                EmployeeMobile: MemberMobile,
                jsDate: jsDate,
            }
        })
            //6.系統判斷5成功執行。
            //7.系統回傳5傳回值。
            .done(MemberBonusListResponse)
            .fail(SystemError)
    });
    // 20181210  ---棋
    //1.使用者點按某一列新增選項。
    $(document).on('click', '.btn-SalaryAdd', function () {
        event.preventDefault();
        var Month = $(this).data('month');
        var Mobile = $(this).data("mobile");
        var Account = $(this).data("account");
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: "json",
            url: setting.PostSalaryMonthEmployeeDetailList,
            data: {
                EmployeeMobile: Mobile,
                Month: Month,
            }
        })
            .done(SalaryClass)
            .fail(SystemError)
        function SalaryClass(data) {
            console.log(data);
            if (Account == 0) {
                BaseSalary = 0
                $("#selSalaryClass option").remove();
                $("#selSalaryClass").append(`<option  value="99">請選擇</option>`);
                for (var i = 0; i < data.lSCLVM.length; i++) {
                    if (data.lSCLVM[i].salaryClassId == 5) { continue };
                    $("#selSalaryClass").append(`<option data-ClassSalary=` + data.lSCLVM[i].classSalary + ` value="` + data.lSCLVM[i].salaryClassId + `">` + data.lSCLVM[i].salaryClass + `</option>`);
                };
                $('#subCancel').remove();
            }
            else {
                $('#editSalary').html("");
                $('#SalaryModelTitle').text("薪資明細");
                $('#subSalary').remove();
                $('#hr').remove();
            }
            if (data.lsmedlvm.length > 0) {
                $('#txtSalaryMonth').val(data.lsmedlvm[0].month);
                $('#txtSalaryEmpMobile').val(data.lsmedlvm[0].employeeMobile);
                $('#SalaryDetail').html("");
                $('#EmpBaseSalar').html("");

                //把本薪加進去
                $('#EmpBaseSalar').append(
                    `<div class="form-group row SalaryDetailList" >
                   <label class="col-xs-3 control-label" >本薪</label>
                   <div class="col-xs-6"><input type="text"  class="form-control SalaryDetailData" data-class="5" value="` + data.lGEBS[0].baseSalary + `" readonly /></div>
                   `);

                for (var i = 0; i < data.lsmedlvm.length; i++) {
                    if (data.lsmedlvm[i].salaryClassId == 3) {
                        $(`#selSalaryClass option:contains(` + data.lsmedlvm[i].salaryClass + `)`).remove();
                        $('#EmpBaseSalar').append(
                            `<div class="form-group row SalaryDetailList" >
                         <label class="col-xs-3 control-label" >`+ data.lsmedlvm[i].salaryClass + `</label>
                         <div class="col-xs-6"><input type="text"  class="form-control SalaryDetailData" data-class="`+ data.lsmedlvm[i].salaryClassId + `" value="` + data.lsmedlvm[i].salary + `" readonly /></div>`);
                    };
                }

                if (Account == 0) {
                    for (var i = 0; i < data.lsmedlvm.length; i++) {
                        if (data.lsmedlvm[i].salaryClassId == 5) { continue };
                        if (data.lsmedlvm[i].salaryClassId == 3) { continue };
                        $(`#selSalaryClass option:contains(` + data.lsmedlvm[i].salaryClass + `)`).remove();
                        $('#EmpBaseSalar').append(
                            `<div class="form-group row SalaryDetailList" >
                   <label class="col-xs-3 control-label" >`+ data.lsmedlvm[i].salaryClass + `</label>
                   <div class="col-xs-6"><input type="text"  class="form-control SalaryDetailData" data-class="`+ data.lsmedlvm[i].salaryClassId + `" value="` + data.lsmedlvm[i].salary + `" readonly /></div>
                     <a class="btn btn-default btn-ClassDelete" data-classsalary="`+ data.lsmedlvm[i].salary + `"   data-salaryclass=` + data.lsmedlvm[i].salaryClass + ` role="button" title="刪除"><span class="glyphicon glyphicon-remove" ariahidden="true"></span></a>
                   `);
                    }
                }
                else {
                    for (var i = 0; i < data.lsmedlvm.length; i++) {
                        if (data.lsmedlvm[i].salaryClassId == 5) { continue };
                        if (data.lsmedlvm[i].salaryClassId == 3) { continue };
                        $(`#selSalaryClass option:contains(` + data.lsmedlvm[i].salaryClass + `)`).remove();
                        $('#EmpBaseSalar').append(
                            `<div class="form-group row SalaryDetailList" >
                   <label class="col-xs-3 control-label" >`+ data.lsmedlvm[i].salaryClass + `</label>
                   <div class="col-xs-6"><input type="text"  class="form-control SalaryDetailData" data-class="`+ data.lsmedlvm[i].salaryClassId + `" value="` + data.lsmedlvm[i].salary + `" readonly /></div> `);
                    }
                }
                sum();
                $('#txtSalary').val("");
                $('#sumSalar').text(`本月總薪資 : ` + parseInt(BaseSalary) + ` 元`);
                $('#add-one').modal({ backdrop: "static" });
            }
            else {
                $('#txtSalaryMonth').val(Month);
                $('#txtSalaryEmpMobile').val(Mobile);
                $('#SalaryDetail').html("");
                $('#EmpBaseSalar').html("");
                $('#txtSalary').val("");
                $('#EmpBaseSalar').append(
                    `<div class="form-group row SalaryDetailList" >
                   <label class="col-xs-3 control-label" >本薪</label>
                   <div class="col-xs-6"><input type="text"  class="form-control SalaryDetailData" data-class="5" value="` + data.lGEBS[0].baseSalary + `" readonly /></div>
                   `);
                sum();
                $('#sumSalar').text(`本月總薪資 : ` + parseInt(BaseSalary) + ` 元`);
                $('#add-one').modal({ backdrop: "static" });
            };
        }
    });
    //20181210  ---棋
    //1.使用者點按某一列刪除選項。
    $(document).on('click', '.btn-SalaryDelete', function () {
        event.preventDefault();

        console.log($(this).data("mobile"), $(this).data("month"))

        $.ajax({
            type: 'POST',
            cache: false,
            dataType: 'json',
            url: setting.GetDeleteSalary,
            data: {
                EmployeeMobile: $(this).data("mobile"),
                Month: $(this).data("month"),
            }
        })
            //6.系統判斷5成功執行。
            //7.系統回傳5傳回值。
            .done(success)
            .fail(SystemError)
        function success(data) {
            data == 0 ? (alert("刪除成功 !")) : ("");
            data == -1 ? (alert("執行錯誤，請稍後再試！")) : ("");
            data == -3 ? (alert("這個月份沒有該員工 !")) : ("");
            data == -4 ? (alert("該月份薪資已經入帳 !")) : ("");
        }
    });
    //20181210 --棋
    //使用者在新增/修改薪資 model 中新增一個細項
    $(document).on('click', '.btn-ClassAdd', event => {
        event.preventDefault();
        var selSalary = $('#selSalaryClass option:selected');
        var selSalaryClassID = selSalary.val();
        var selSalaryClass = selSalary.text();
        var txtSalary = $('#txtSalary').val();
        if (txtSalary == "" || selSalaryClassID == 99) { return; };

        $('#SalaryDetail').append(
            `<div class="form-group row SalaryDetailList" >
                   <label class="col-xs-3 control-label" >`+ selSalaryClass + `</label>
                   <div class="col-xs-6"><input type="text"  class="form-control SalaryDetailData" data-class="`+ selSalaryClassID + `" value="` + txtSalary + `" readonly /></div>
                   <a class="btn btn-default btn-ClassDelete" data-salaryclass="`+ selSalaryClass + `" data-classsalary="` + txtSalary + `" role="button" title="刪除"><span class="glyphicon glyphicon-remove"  data-baseSalary="` + txtSalary + `" aria-hidden="true"></span></a>
              </div>`);
        selSalary.remove();
        sum();
        $('#sumSalar').text(`本月總薪資 : ` + BaseSalary + ` 元`);
        $('#txtSalary').val("");
    });
    //20181210 --棋
    //使用者在新增/修改薪資 model 中點選刪除任一項目
    $(document).on('click', '.btn-ClassDelete', function () {
        event.preventDefault();
        var classsalary = $(this).data('classsalary');
        var salaryclass = $(this).data('salaryclass');
        var sel = 0;
        $("#selSalaryClass option").each(function () {
            if ($(this).text() == salaryclass) {
                console.log($(this).text(), salaryclass)
                sel += 1;
            }
        });
        console.log(sel);
        if (sel == 0) { $("#selSalaryClass").append(`<option data-ClassSalary=` + classsalary + ` value="">` + salaryclass + `</option>`); }
        $(this).parent().remove();
        sum();
        $('#sumSalar').text(`本月總薪資 : ` + BaseSalary + ` 元`);
    });
    //20181210  ---棋
    // 1.使用者在新增/修改薪資 model點選送出。
    $(document).on('click', '#subSalary', event => {
        event.preventDefault();
        var Month = $('#txtSalaryMonth').val();
        var EmployeeMobile = $('#txtSalaryEmpMobile').val();
        //  2-2.糸統清空SalaryData。
        SalaryDatas = [];
        // 2-1.系統判斷SalaryMonth != '' && SalaryEmpMobile!= ''
        if (Month != '' && EmployeeMobile != '') {
            //  2-3.系統將薪資清單中的每一個項目Push至SalaryData。
            $("#EmpBaseSalar .SalaryDetailData").each(function (index, element) {
                var SalaryClassId = $(element).data('class')
                var Salary = parseInt($(element).val());
                SalaryDatas.push(new SalaryData(Month, EmployeeMobile, SalaryClassId, Salary));
            });
            $("#SalaryDetail .SalaryDetailData").each(function (index, element) {
                var SalaryClassId = $(element).data('class');
                var Salary = parseInt($(element).val());
                SalaryDatas.push(new SalaryData(Month, EmployeeMobile, SalaryClassId, Salary));
            });
        };
        $.ajax({
            type: 'POST',
            cache: false,
            dataType: 'Json',
            url: setting.PostInsertSalary,
            data: {
                Month: Month,
                EmployeeMobile: EmployeeMobile,
                SalaryDatas: SalaryDatas,
            }
        })
            //6.系統判斷5成功執行。
            //7.系統回傳5傳回值。
            .done(success)
            .fail(SystemError)
        function success(data) {
            if (data == 0) {
                alert("新增成功 !");
                $('#add-one').modal('hide');
            }
            data === 1 ? (alert("系統執行錯誤，請稍後再試！")) : ("");
            data === -1 ? (alert("資料庫錯誤，請稍後再試！")) : ("");
            data === -3 ? (alert("這個月份沒有該員工！")) : ("");
        }
    });
    //20181210  ---棋
    // 1.使用者在薪資管理按換頁連結。
    $(document).on('click', '.page-link', function (event) {
        event.preventDefault();
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        MemberMobile = $('#MemberMobile').val();
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetEmployeeMonthSalary,
            data: {
                EmployeeMobile: MemberMobile,
                jsDate: jsDate,
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1])
            }
        })
            .done(MemberBonusListResponse)
            .fail(SystemError)
    });
};