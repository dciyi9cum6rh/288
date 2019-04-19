let jsDate, jeDate, jProduct,jEventId, jMemberMobile;
function Orderfunction(option) {
    var setting = {
        GetMemberBonusChangeRecordList: '',
    };
    setting = $.extend(setting, option);

    function success(response) {
        $('#MemberBonusChangeRecordList').html(response);
    }
    function SystemError() {
        alert('執行錯誤，請稍後再試！');
    }

    // 1.使用者在會員點數異動記錄首頁輸入銷貨單號/銷貨日期/會員帳號/訂單狀態/產品名稱並按查詢。
    $(document).on('click', '#btnSearchChangeRecord', function (event) {
        event.preventDefault();
        // 2.系統將1輸入資料暫存至jOrderId/jsDate/jeDate/jMemberMobile/jOrderStateId/jProduct。
        sDate = $('#sDate').val();
        eDate = $('#eDate').val();
        MemberMobile = $('#MemberMobile').val();
        EventId = $('#EventId').val();
       
        // 3.系統以ajax呼叫Get Action【Order/GetOrderList】，並傳送jOrderId/jsDate/jeDate/jMemberMobile/jOrderStateId/jProduct。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetMemberBonusChangeRecordList,
            data: {
                MemberMobile: MemberMobile,
                EventId:EventId,
                sDate: sDate,
                eDate: eDate,
            }
        })
            .done(success)
            .fail(SystemError)
    });

    // 1.使用者在點數異動單點按換頁連結。
    $(document).on('click', '.page-link', function (event) {
        event.preventDefault();
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");

        sDate = $('#sDate').val();
        eDate = $('#eDate').val();
        MemberMobile = $('#MemberMobile').val();

        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetMemberBonusChangeRecordList,
            data: {
                MemberMobile: MemberMobile,
                sDate: sDate,
                eDate: eDate,
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1])
            }
        })
            .done(success)
            .fail(SystemError)
    });

    $(document).on('click', '.btn-success', function (event) {
      
        event.preventDefault();
        if (!confirm('確定撥款？')) return;
        var $this = $(this);
        jRecordId = ($(this).closest('tr').find("td:eq(0)").text()).toString();
        

        $.ajax({
            type: 'Post',
            cache: false,

            url: './MemberBonusChangeRecord/ChangeMemberBonusToMoney',
            data: {
                'RecordId': jRecordId             
            },
            beforeSend: LoadBefore,
            success: ChangeBonusSuccess,
            error: SystemError
        });
    });

    $(document).on('click', '.btn-danger', function (event) {

        event.preventDefault();       
        var $this = $(this);
        jMemberPhone = ($(this).closest('tr').find("td:eq(1)").text()).toString();

        window.open('/MemberBonusChangeRecord/GetBankAccountImg?MemberPhone=' + jMemberPhone , '_blank');

     
    });
    function LoadBefore() { }
    function SystemError() {
        alert('系統錯誤，請稍後再試！');
    }
    function ChangeBonusSuccess(response) {
        document.getElementById('btnSearchChangeRecord').click();
        //alert('撥款成功！');
    };
}