let jMemberMobile, jMemberName, jReferrerMobile, jMemberLevelId, jEnabled;
function VipMemberfunction(option) {
    var setting = {
        GetMemberUrl: '',
        GetMemberListUrl: '',
        UpdateMemberEnabledUrl: '',
        UpdateMemberLevelUrl: '',
        UpdateMemberReferrerUrl: ''
    };
    setting = $.extend(setting, option);

    //2181212 ---棋
    //使用者點選查看VIP上傳資料
    $(document).on('click', '.btn-MemberMobileImg', function (event) {
        if ($(this).data("status") == "") {
            alert("沒有資料");
            return;
        }
        event.preventDefault();
        var mermobl = `#` + $(this).data("membermobile");
        $(mermobl).modal({ backdrop: "static" });
    });

    // 1.使用者在在批發會員管理首頁條件再按查詢。
    $(document).on('click', '#btnSearch', function (event) {
        event.preventDefault();
        // 1-1.系統將1輸入條件暫存在jMemberMobile、jMemberName、jReferrerMobile、jMemberLevelId、jEnaled。
        jMemberMobile = $('#MemberMobile').val();
        jMemberName = $('#MemberName').val();
        jReferrerMobile = $('#ReferrerMobile').val();
        jMemberLevelId = $('#MemberLevelId option:selected').val();
        jEnabled = parseInt($('#Enabled option:selected').val());
        // 2.系統以ajax呼叫Post Controller Action【VipMember/GetMemberList】，並傳送jMemberMobile、jMemberName、jReferrerMobile、jMemberLevelId、jEnaled。

        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetMemberListUrl,
            data: {
                'MemberMobile': jMemberMobile,
                'MemberName': jMemberName,
                'ReferrerMobile': jReferrerMobile,
                'MemberLevelId': jMemberLevelId,
                Enabled: jEnabled
            },
            beforeSend: LoadBefore,
            success: GetMemberListSuccess,
            error: SystemError
        });
    });
    // 1.使用者在ERP系統批發會員管理之批發會員清單點按換頁連結。
    $(document).on('click', '.page-link', function (event) {
        event.preventDefault();
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 2.系統以ajax呼叫Get Action【Accounting/GetAccountingList】，並傳送jMemberMobile、jMemberName、jReferrerMobile、jMemberLevelId、jEnabled以及1點按頁碼。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetMemberListUrl,
            data: {
                'MemberMobile': jMemberMobile,
                'MemberName': jMemberName,
                'ReferrerMobile': jReferrerMobile,
                'MemberLevelId': jMemberLevelId,
                'Enabled': jEnabled,
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1])
            },
            beforeSend: LoadBefore,
            success: GetMemberListSuccess,
            error: SystemError
        });
    });
    // 1.使用者在批發會員管理首頁點按某一列會員之停權/復權'。
    let $this, $selecteditadmin;
    $(document).on('click', '.btn-enabled', function (event) {
        event.preventDefault();
        if (!confirm('確定停權/復權？')) return;
        // 2.使用者確認要停權/復權。
        $this = $(this);
        let jMemberMobileE = $this.closest("tr").find("td:eq(0)").text();
        // 3.系統以ajax呼叫Post Action【VipMember//UpdateMemberEnabled】，並傳送1點按列之MemberMobile、以及停權/復權代碼0/1。
        let jEnabledE = 0;
        if ($this.find("span").first().hasClass("glyphicon-remove")) {
            jEnabledE = 0;
            //$this.find("span").attr('title', '圖示');
            //$this.find("span").first().removeClass();
            //$this.find("span").first().addClass('glyphicon glyphicon-camera');
        }
        else {
            jEnabledE = 1;
        }
        $.ajax({
            type: 'POST',
            cache: false,
            url: setting.UpdateMemberEnabledUrl,
            data: { "MemberMobile": jMemberMobileE, 'Enabled': jEnabledE },
            beforeSend: LoadBefore,
            success: UpdateMemberEnabledSuccess,
            error: SystemError
        });

        function UpdateMemberEnabledSuccess(response) {
            if (response == 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                alert('設定成功');
                // 13-1.系統改變停權狀態。
                if ($this.find("span").first().hasClass("glyphicon-remove")) {
                    $this.find("span").attr('title', '復權');
                    $this.find("span").first().removeClass();
                    $this.find("span").first().addClass('glyphicon glyphicon-ok');
                    $this.closest("tr").find("td:eq(4)").text('停權中');
                }
                else {
                    $this.find("span").attr('title', '停權');
                    $this.find("span").first().removeClass();
                    $this.find("span").first().addClass('glyphicon glyphicon-remove');
                    $this.closest("tr").find("td:eq(4)").text('使用中');
                }
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
                alert('設定失敗，請稍後再試！');
                //  13a-2.結束。
            }
        }
    });

    // 1.使用者在批發會員管理首頁點按某一列會員之升級為批發會員。
    $(document).on('click', '.btn-vip', function (event) {
        event.preventDefault();
        if (!confirm('確定升級為批發會員？')) return;
        // 2.使用者確認要升級為準批發會員。
        $this = $(this);
        let jMemberMobileE = $this.closest("tr").find("td:eq(0)").text();
        // 3.系統以ajax呼叫Post Action【VipMember/UpdateMemberLevel】，並傳送1點按列之MemberMobile、以及MemberLevelId=3。
        let jMemberLevelIdE = 3;
        $.ajax({
            type: 'POST',
            cache: false,
            url: setting.UpdateMemberLevelUrl,
            data: { "MemberMobile": jMemberMobileE, 'MemberLevelId': jMemberLevelIdE },
            beforeSend: LoadBefore,
            success: UpdateMemberLevelSuccess,
            error: SystemError
        });

        function UpdateMemberLevelSuccess(response) {
            if (response == 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                alert('設定成功');
                // 13-1.系統改變會員等級。
                $this.closest("tr").find("td:eq(2)").text('批發會員');
            }
            else if (response == 1) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                //  12a-1.系統顯示"無此權限"。
                alert('無此權限！');
                //  13b-2.結束。
            }
            else if (response == 2) {
                // 12b.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                //  12b-1.系統顯示推薦人非批發會員亦非本公司業務。
                alert('推薦人非批發會員亦非本公司業務！');
                //  13b-2.結束。
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/2
                //  13c-1.系統顯示"刪除失敗"。
                alert('設定失敗，請稍後再試！');
                //  13a-2.結束。
            }
        }
    });

    // 1.使用者在批發會員管理首頁輸入[新推薦人手機]之後點按變更會員推薦人。
    $(document).on('click', '#btnUpdateReferrer', function (event) {
        event.preventDefault();
        if ($("#NewReferrerMobile").val() === '' || $("#NewReferrerMobile").val() === null) {
            alert("請先輸入新推薦人手機！");
            return;
        }
        if (!confirm('確定變更推薦人？')) return;
        // 2.使用者確認要變更會員推薦人。
        $this = $(this);
        // 4.系統以ajax呼叫Post Controller Action【VipMember/UpdateMemberReferrer】，
        //  並傳送jMemberMobile、jMemberName、jReferrerMobile、jMemberLevelId、jEnabled與#NewReferrerMobile。
        let jMemberLevelIdE = 3;
        $.ajax({
            type: 'POST',
            cache: false,
            url: setting.UpdateMemberReferrerUrl,
            data: {
                'MemberMobile': $("#MemberMobile").val(),
                'MemberName': jMemberName,
                'ReferrerMobile': jReferrerMobile,
                'MemberLevelId': jMemberLevelId,
                'Enabled': jEnabled,
                'NewReferrerMobile': $("#NewReferrerMobile").val()
            },
            beforeSend: LoadBefore,
            success: UpdateMemberReferrerSuccess,
            error: SystemError
        });

        function UpdateMemberReferrerSuccess(response) {
            if (response == 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示變更成功，請再查詢驗証。
                alert('變更成功，請再查詢驗証！');
            }
            else if (response == 1) {
                // 12a.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                //  12a-1.系統顯示"無此權限"。
                alert('無此權限！');
                //  13b-2.結束。
            }
            else if (response == 2) {
                // 12b.系統在6啟動之ajax回呼函式中判斷11傳回值==2
                //  12b-1.系統顯示推薦人非批發會員亦非本公司業務。
                alert('推薦人非批發會員亦非本公司業務！');
                //  13b-2.結束。
            }
            else {
                // 12c.系統在6啟動之ajax回呼函式中判斷11傳回值!=0/1/2
                //  13c-1.系統顯示"刪除失敗"。
                alert('變更失敗，請稍後再試！');
                //  13a-2.結束。
            }
        }
    });

    $(document).on('click', '.btn-success', function (event) {
        event.preventDefault();
        memo = document.getElementById('memo_' + jMemberMobile).value;
        if (memo === '' || memo === null) {
            alert("請先輸入變更原因！");
            return;
        }
        if (!confirm('確定變更點數紅利？')) return;
        var $this = $(this);
        jMemberMobile = ($(this).closest('tr').find("td:eq(0)").text()).toString();
        jBonus = document.getElementById('bonus_' + jMemberMobile).value;

        $.ajax({
            type: 'Post',
            cache: false,

            url: './VipMember/ChangeMemberBonus',
            data: {
                'MemberMobile': jMemberMobile,
                'Memo' : memo ,
                'Bonus': jBonus
            },
            beforeSend: LoadBefore,
            success: ChangeBonusSuccess,
            error: SystemError
        });
    });
    function ChangeBonusSuccess(response) {
        alert('變更成功！');
    };

    $(document).on('click', '.btn-bonus', function (event) {
        event.preventDefault();
        var $this = $(this);
        jMemberMobile = ($(this).closest('tr').find("td:eq(0)").text()).toString();
        jMemberName = ($(this).closest('tr').find("td:eq(1)").text()).toString();
        //$tr = $this.clos("tr");
        console.log(jMemberMobile)
        console.log(jMemberName)

        if ($this.find("span").first().hasClass("glyphicon-minus")) {
            //2a.系統判斷javascript變數IsSpread=true。
            //2a-1.系統清除下一個<tr>之html()，以隠藏下線之下線清單。
            $(this).closest("tr").next().html('');
            //2a-2.系統設定javascript變數IsSpread=false。
            isSpread = false;
            //2a-3.系統設定展開按鈕圖示為+(展開)。
            $this.find("span").attr('title', '銷貨明細');
            $this.find("span").first().removeClass();
            $this.find("span").first().addClass('glyphicon glyphicon-usd');
            //2a-4.結束。
            return;
        }
        $.ajax({
            type: 'Post',
            cache: false,

            url: setting.GetMemberUrl,
            data: {
                'MemberMobile': jMemberMobile
            },
            beforeSend: LoadBefore,
            success: GetMemberSuccess,
            error: SystemError
        });
        function GetMemberSuccess(response) {
            $this.next("tr").html('<td colspan="11">' + response + '</td>');
            // 10.系統在3啟動之ajax回呼函式中將下一列<tr>的Html內容更新為9-7.系統回傳View。
            //$this.closest("tr").next().html('<td colspan="10">' + response + '</td>');
            // 10-1.系統設定javascript變數IsSpread=true。
            //isSpread = true;
            // 10-2.系統設定展開按鈕圖示為-(隱藏)。
            $this.find("span").attr('title', '隠藏');
            $this.find("span").first().removeClass();
            $this.find("span").first().addClass('glyphicon glyphicon-minus');
            // 11.結束。
        };
    });
}
function GetMemberListSuccess(response) {
    // 10.系統在2啟動之ajax回呼函式中將<div MemberList>.html()設為9-7傳回值。
    $('Div#MemberList').html(response);
    if (response.indexOf("h3") >= 0) {
        $("#btnUpdateReferrer").prop("disabled", true);
    }
    else {
        $("#btnUpdateReferrer").prop("disabled", false);
    }
    // 11.結束。
}
function LoadBefore() { }
function SystemError() {
    alert('系統錯誤，請稍後再試！');
}