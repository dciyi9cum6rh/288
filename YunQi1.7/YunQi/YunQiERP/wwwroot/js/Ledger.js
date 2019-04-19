//20181212 ---棋
function Orderfunction(option) {
    var setting = {
        GetLedgerList: '',
        PosInsertLedger: '',
        PostUpdateLedger: '',
        PosDeleteLedger: '',
    };
    setting = $.extend(setting, option);

    //8.系統在4啟動之aax回呼函式中判斷7傳回值===0。
    //9.系統顯示營運獎金計算成功。

    function SystemError() {
        alert('執行錯誤，請稍後再試！');
    }
    function MemberBonusListResponse(response) {
        $('#AccountingLedger').html(response);
    }

    //20181213  ---棋
    //1.使用者在薪資管理首頁輸入員工手機/日期(月份)並按查詢。
    $(document).on('click', '#btnSearchLedger', event => {
        event.preventDefault();
        //註.月份一定要填

        if ($('#sDate').val() == "") {
            alert("請輸入日期!");
            return;
        }
        jsDate = ($('#sDate').val().substr(0, 4) + $('#sDate').val().substr(5, 2) + "01");
        AccountingSubject = $('#AccountingSubject').val();
        //3.系統以ajax呼叫Get Action【MemberBonus/GetMemberBonusList】，並傳送jMemberMobile/jMemberMobileWhere/jsDate。
        //10.系統在3啟動之ajax呼叫回呼函式中將<Div MemberBonusList>.Html()更新為9-7回傳View。
        //4.系統以ajax呼叫POST Action【MemberBonus / CaculateMemberBonus】，並傳送jsDate
        $.ajax({
            type: 'POST',
            cache: false,
            dataType: 'HTML',
            url: setting.GetLedgerList,
            data: {
                AccountingSubject: AccountingSubject,
                jsDate: jsDate,
            }
        })
            //6.系統判斷5成功執行。
            //7.系統回傳5傳回值。
            .done(MemberBonusListResponse)
            .fail(SystemError)
    });
    //20181213  ---棋
    // 1.使用者在薪資管理按換頁連結。
    $(document).on('click', '.page-link', function (event) {
        event.preventDefault();
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        jsDate = ($('#sDate').val().substr(0, 4) + $('#sDate').val().substr(5, 2) + "01");
        AccountingSubject = $('#AccountingSubject').val();
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetLedgerList,
            data: {
                AccountingSubject: AccountingSubject,
                jsDate: jsDate,
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1])
            }
        })
            .done(MemberBonusListResponse)
            .fail(SystemError)
    });

    //20181210 --棋
    //使用者在新增/修改薪資 model 中點選刪除任一項目
    $(document).on('click', '.btn-delete-AccountingId', function () {
        event.preventDefault();
        if (!confirm('確定是否刪除此筆分類帳？')) return;
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.PosDeleteLedger,
            data: {
                AccountingId: $(this).data('accountingid'),
                LedgerId: $(this).data('ledgerid'),
            }
        })
            .done(success)
            .fail(SystemError)

        function success(data) {
            data == 0 ? (alert("刪除成功 !")) : ("");
            data == -9 ? (alert("伺服器端執行錯誤，請稍後再試！")) : ("");
            data == -1 ? (alert("資料端執行錯誤，請稍後再試！ !")) : ("");
            data == -2 ? (alert("沒有此筆分類帳 !")) : ("");
        }
    });

    //20181210 --棋
    //使用者在某項點選修改
    $(document).on('click', '.btn-edit-AccountingId', function () {
        $('#SalaryModelTitle').text("修改分類帳");
        var $this = $(this).parent().parent().children();
        var AccountingId = $this.eq(6).text();
        var Money = $this.eq(4).text();
        var InvoiceId = $this.eq(2).text();
        var LedgerDescription = $this.eq(3).text();
        var Month = $this.eq(0).text();
        var LedgerId = $this.eq(5).text();
        var dt = new Date();
        var dateNow = parseInt(dt.getFullYear()) + "/" + (dt.getMonth() + 1) + "/" + dt.getDate();
        $('#AccountingId').val(AccountingId);
        $('#InvoiceId').val(InvoiceId);
        $('#LedgerDescription').val(LedgerDescription);
        $('#Money').val(Money);
        $('#Month').val(Month);
        $('#LedgerId').val(LedgerId);
        $('#jDate').val(dateNow);
        $('#Status').val("1");
        $('#myModal').modal('show');
    });

    //20181210 --棋
    //使用者在某項點選新增
    $(document).on('click', '#btnNewSearchLedger', function () {
        $('#SalaryModelTitle').text("新增分類帳");
        $('#AccountingId').val("");
        $('#InvoiceId').val("");
        $('#LedgerDescription').val("");
        $('#Money').val("");
        $('#Month').val("");
        $('#LedgerId').val("");
        $('#jDate').val("");
        $('#Status').val("");
        $('#myModal').modal('show');
    });

    //20181210 --棋
    //使用者在修改model 點選送出
    $(document).on('click', '#subSalary', function () {
        var AccountingId = $('#AccountingId').val();
        var Money = $('#Money').val();
        var InvoiceId = $('#InvoiceId').val();
        var LedgerDescription = $('#LedgerDescription').val();
        var Month = $('#jDate').val().substr(0, 4) + $('#jDate').val().substr(5, 2) + "01";
        var LedgerId = $('#LedgerId').val();
        var Status = $('#Status').val();

        //如果狀態碼 為1 代表修改 否則為新增
        if (Status == 1) {
            $.ajax({
                type: 'POST',
                cache: false,
                dataType: 'json',
                url: setting.PostUpdateLedger,
                data: {
                    AccountingId: AccountingId,
                    LedgerId: LedgerId,
                    Money: Money,
                    InvoiceId: InvoiceId,
                    LedgerDescription: LedgerDescription,
                    Month: Month,
                }
            })
                //6.系統判斷5成功執行。
                //7.系統回傳5傳回值。
                .done(success)
                .fail(SystemError)

            function success(data) {
                $('#myModal .close').click();
                data == 0 ? (alert("此筆分類帳修改成功 !")) : ("");
                data == -1 ? (alert('執行錯誤，請稍後再試！')) : ("");
                data == -2 ? (alert("沒有該筆分類帳，請重新查詢 !")) : ("");
                data == -3 ? (alert("該筆分類帳已存在，請重新查詢 !")) : ("");
            }
            $('#Status').val("");
        }
        else {
            $.ajax({
                type: 'POST',
                cache: false,
                dataType: 'json',
                url: setting.PosInsertLedger,
                data: {
                    AccountingId: AccountingId,
                    Money: Money,
                    InvoiceId: InvoiceId,
                    LedgerDescription: LedgerDescription,
                    Month: Month,
                }
            })
                //6.系統判斷5成功執行。
                //7.系統回傳5傳回值。
                .done(success)
                .fail(SystemError)

            function success(data) {
                $('#myModal .close').click();
                data == 0 ? (alert("此筆分類帳新增成功 !")) : ("");
                data == -1 ? (alert('執行錯誤，請稍後再試！')) : ("");
                data == -2 ? (alert("沒有該筆分類帳，請重新查詢 !")) : ("");
            }
        }
    });
};