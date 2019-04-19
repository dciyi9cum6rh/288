$(document).ready(function () {
    var url = location.href;
    //再來用去尋找網址列中是否有資料傳遞(QueryString)
    if (url.indexOf('?') != -1) {
        var ary = url.split('?')[1].split('&');
        //下迴圈去搜尋每個資料參數
        for (i = 0; i <= ary.length - 1; i++) {
            if (ary[i].split('=')[0] == 'MemberMobile')
                sMemberMobile = ary[i].split('=')[1];
        }
        for (i = 0; i <= ary.length - 1; i++) {
            if (ary[i].split('=')[0] == 'token')
                sToken = ary[i].split('=')[1];
        }
        console.log(sMemberMobile);
        console.log(sToken);
    }

    $('#MemberMobile').val(sMemberMobile);
    $('#MemberPassword').val("");
    $('#DoubleCheckPassword').val("");

    $.ajax({
        type: 'POST',
        cache: false,
        dataType: 'Json',
        url: "LostPassword/MemberForget",
        data: {
            MemberMobile: sMemberMobile,
            token: sToken,
        }
    })
        .done(success)
        .fail(systemError)

    function success(data) {
        if (data == -1) {
            alert("帳號錯誤 ! ");
            javascript: window.location = "/Home/Index";
        }  else if (data == -3) {
            alert("超過20分鐘，請重新申請 ! ");
            javascript: window.location = "/Home/Index";
        } else if (data == -4) {
            alert("查無此資料，請重新申請 ! ");
            javascript: window.location = "/Home/Index";
        } else if (data == -5) {
            alert("密碼已修改，請重新申請 ! ");
            javascript: window.location = "/Home/Index";
        }else { };
    };
});

const systemError = () => {
    alert("系統錯誤，請稍後再試！");
};

//使用者按下變更密碼
$('#ChangePassword').on('click', function (event) {
    event.preventDefault();

    if (!confirm('確定變更新設定密碼？')) return;

    var MemberPassword = $('#MemberPassword').val();
    var DoubleCheckPassword = $('#DoubleCheckPassword').val();

    if (MemberPassword == "" || DoubleCheckPassword == "") {
        alert("請輸入密碼!");
        return;
    };

    if (MemberPassword != DoubleCheckPassword) {
        alert("密碼欄位不相同!");
        return;
    };

    $.ajax({
        type: 'POST',
        cache: false,
        url: "LostPassword/UpdateMemberPassword",
        data: {
            MemberMobile: sMemberMobile,
            MemberPassword: MemberPassword,
            DoubleCheckPassword: DoubleCheckPassword,
            token: sToken,
        }
    })
        .done(success)
        .fail(systemError)

    function success(data) {
        if (data == 0) {
            alert("變更密碼成功 ! ");
            location.href = '/Home/Index';
        }
        else if (data == -2) {
            alert("密碼已變更過，請重新申請 ! ")
        }
    };
});
