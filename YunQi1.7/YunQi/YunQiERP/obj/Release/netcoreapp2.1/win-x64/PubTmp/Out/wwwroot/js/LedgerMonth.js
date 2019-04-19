//20181212 ---棋
function Orderfunction(option) {
    var setting = {
        GetLedgerMonthList: '',
        LedgerMontAddMoney: '',
    };
    setting = $.extend(setting, option);

    //8.系統在4啟動之aax回呼函式中判斷7傳回值===0。
    //9.系統顯示營運獎金計算成功。

    function SystemError() {
        alert('執行錯誤，請稍後再試！');
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
        Month = ($('#sDate').val().substr(0, 4) + $('#sDate').val().substr(5, 2) + "01");

        //10.系統在3啟動之ajax呼叫回呼函式中將<Div MemberBonusList>.Html()更新為9-7回傳View。
        //4.系統以ajax呼叫POST Action【MemberBonus / CaculateMemberBonus】，並傳送jsDate
        $.ajax({
            type: 'POST',
            cache: false,
            dataType: 'HTML',
            url: setting.GetLedgerMonthList,
            data: {
                Month: Month,
            }
        })
            //6.系統判斷5成功執行。
            //7.系統回傳5傳回值。
            .done(MemberBonusListResponse)
            .fail(SystemError)
    });

    function MemberBonusListResponse(response) {
        $('#LedgerMonthHtml').html(response);
        $('#newAddMoney').val($('#AddMoney').val());
        $('#newMinusMoney').val($('#MinusMoney').val());
        $('#newTotal').val($('#Total').val());
    }
};