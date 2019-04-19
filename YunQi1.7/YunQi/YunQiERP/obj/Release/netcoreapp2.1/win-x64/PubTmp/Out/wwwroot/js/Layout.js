function Layoutfunction(option) {
    var setting = {
        LogoutUrl: '',
        LoginUrl: '',
        OnlineMemberUrl: ''
    };
    setting = $.extend(setting, option);
    // 1.點按登出。
    $('#aLogout').on('click', function (event) {
        event.preventDefault();
        // 2.系統以ajax呼叫Get Controller Action【Account/GetAllRight】。
        $.ajax({
            type: 'Post',
            //dataType: 'int',
            url: setting.LogoutUrl,
            //beforeSend: GetAllRightBefore,
            success: LogoutSuccess,
            error: SystemError
        });
        function LogoutSuccess(response) {
            if (response == 0)
                window.location = setting.LoginUrl;
            else
                alert("登出失敗！");
        }
    });
}

function SystemError() {
    alert('系統錯誤，請稍後再試！');
}