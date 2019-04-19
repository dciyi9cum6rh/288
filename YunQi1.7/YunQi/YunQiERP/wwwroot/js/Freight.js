let jFreightSubject = '', jFreightId;
function Freightfunction(option) {
    var setting = {
        GetFreightListUrl: '',
        PutFreightUrl: ''
    };
    setting = $.extend(setting, option);
    // 1.使用者在運費設定首頁輸入運費值後按重設運費。
    let $CreateSubmit;
    $('#btnReset').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmit = $(this);

        // 2.系統以ajax呼叫Post Action【Freight/PutFreight】，
        //  並將1重設運費值以FreightId"<id1>,<id2>,…,"、FreightLimit"<l1>,<l2>,…,"與FreightValue"<val1>,<val2>,…,"傳送。
        let FreightId = '', FreightValue = '', FreightLimit = '';
        $("#qFrom input:text").each(function () {
            if ($(this).hasClass('BonusLimit')) {
                FreightId += $(this).attr('id') + ',';
                FreightLimit += $(this).val() + ',';
            }
            else {
                FreightValue += $(this).val() + ',';
            }
        });
        $.ajax({
            type: 'POST',
            url: setting.PutFreightUrl,
            data: {
                "FreightId": FreightId, 'FreightLimit': FreightLimit, "FreightValue": FreightValue
            },
            beforeSend: LoadBefore,
            success: PutFreightSuccess,
            error: SystemError
        });

        $CreateSubmit.prop("disabled", false);

        function PutFreightSuccess(response) {
            if (response === 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示重設成功。
                alert("重設成功！");
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
}
function LoadBefore() { }
function SystemError() {
    alert('系統錯誤，請稍後再試！');
}