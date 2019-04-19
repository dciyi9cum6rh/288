let jDevelopmentBonusSubject = '', jDevelopmentBonusId;
function DevelopmentBonusfunction(option) {
    var setting = {
        GetDevelopmentBonusListUrl: '',
        PutDevelopmentBonusUrl: ''
    };
    setting = $.extend(setting, option);
    // 1.使用者在發展獎金設定首頁輸入發展獎金值後按重設發展獎金。
    let $CreateSubmit;
    $('#btnReset').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmit = $(this);

        // 2.系統以ajax呼叫Post Action【DevelopmentBonus/PutDevelopmentBonus】，
        //  並將1重設發展獎金值以DevelopmentBonusId"<id1>,<id2>,…,"、DevelopmentBonusLimit"<l1>,<l2>,…,"與DevelopmentBonusValue"<val1>,<val2>,…,"傳送。
        let DevelopmentBonusId = '', DevelopmentBonusValue = '', DevelopmentBonusLimit = '';
        $("#qFrom input:text").each(function () {
            if ($(this).hasClass('BonusLimit')) {
                DevelopmentBonusId += $(this).attr('id') + ',';
                DevelopmentBonusLimit += $(this).val() + ',';
            }
            else {
                DevelopmentBonusValue += $(this).val() + ',';
            }
        });
        $.ajax({
            type: 'POST',
            url: setting.PutDevelopmentBonusUrl,
            data: {
                "DevelopmentBonusId": DevelopmentBonusId, 'DevelopmentBonusLimit': DevelopmentBonusLimit, "DevelopmentBonusValue": DevelopmentBonusValue
            },
            beforeSend: LoadBefore,
            success: PutDevelopmentBonusSuccess,
            error: SystemError
        });

        $CreateSubmit.prop("disabled", false);

        function PutDevelopmentBonusSuccess(response) {
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