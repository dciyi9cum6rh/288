let jParameterSubject = '', jParameterId;
function Parameterfunction(option) {
    var setting = {
        GetParameterListUrl: '',
        PutParameterUrl: ''
    };
    setting = $.extend(setting, option);
    // 1.使用者在參數設定首頁輸入參數值後按重設參數值。
    let $CreateSubmit;
    $('#btnReset').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmit = $(this);

        // 2.系統以ajax呼叫Post Action【Parameter/PutParameter】，並將1重設參數值以ParameterId"<id1>,<id2>,…,"與ParameterValue"<val1>,<val2>,…,"傳送。
        let ParameterId = '', ParameterValue = '';
        $("#qFrom input:text").each(function () {
            ParameterId += $(this).attr('id') + ',';
            ParameterValue += $(this).val() + ',';
        });
        $.ajax({
            type: 'POST',
            url: setting.PutParameterUrl,
            data: {
                "ParameterId": ParameterId, "ParameterValue": ParameterValue
            },
            beforeSend: LoadBefore,
            success: PutParameterSuccess,
            error: SystemError
        });

        $CreateSubmit.prop("disabled", false);

        function PutParameterSuccess(response) {
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