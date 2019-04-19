var jMemberMobile, jMemberMobileWhere, jsDate;

function Orderfunction(option) {
    var setting = {
        MessageManagementList: '',
        MessageManagementData: '',
        InsertReplyMessageManagement: '',
        DeleteMessageManagement: '',
        DeleteReplyMessageManagement: '',
        UpdateMemberLevelCartImg: '',
        UpdateMemberEnabled: '',
    };
    setting = $.extend(setting, option);

    function SystemError() {
        alert('執行錯誤，請稍後再試！');
    }
    function MessageManagementResponse(response) {
        $('#MessageManagementList').html(response);
    }

    //20181220  ---棋
    //1.使用者在留言板管理輸入 .....並按查詢。
    $(document).on('click', '#btnSearchMessageManagement', event => {
        event.preventDefault();

        VersionId = $('#VersionListOption option:selected').val();
        VersionId == 99 ? (VersionId = null) : ("");
        sDate = $('#sDate').val();
        eDate = $('#jDate').val();
        MessageValue = $('#SearchMessageValue').val();
        MemberMobile = $('#SearchMemberMobile').val();
        NickName = $('#SearchNickName').val();

        ///console.log(VersionId);
        //console.log(sDate);
        //console.log(eDate);
        //console.log(MessageValue);
        //console.log(MemberMobile);
        //console.log(NickName);

        //3.系統以ajax呼叫Get Action【EmployeeDevelopmentBonus/GetEmployeeDevelopmentBonusList】，並傳送jMemberMobile/jMemberMobileWhere/jsDate。
        //10.系統在3啟動之ajax呼叫回呼函式中將<Div MemberBonusList>.Html()更新為9-7回傳View。
        //4.系統以ajax呼叫POST Action【EmployeeDevelopmentBonus / GetEmployeeDevelopmentBonusList】，並傳送jsDate
        $.ajax({
            type: 'POST',
            cache: false,
            dataType: 'HTML',
            url: setting.MessageManagementList,
            data: {
                VersionId: VersionId,
                sDate: sDate,
                eDate: eDate,
                MessageValue: MessageValue,
                MemberMobile: MemberMobile,
                NickName: NickName,
            }
        })
            //6.系統判斷5成功執行。
            //7.系統回傳5傳回值。
            .done(MessageManagementResponse)
            .fail(SystemError)
    });
    //20181218  ---棋
    // 1.使用者在銷貨清單點按換頁連結。
    $(document).on('click', '.page-link', function (event) {
        event.preventDefault();
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");

        VersionId = $('#VersionListOption option:selected').val();
        VersionId == 99 ? (VersionId = null) : ("");
        sDate = $('#sDate').val();
        eDate = $('#jDate').val();
        MessageValue = $('#SearchMessageValue').val();
        MemberMobile = $('#SearchMemberMobile').val();
        NickName = $('#SearchNickName').val();

        // 3.系統以ajax呼叫Get Action【EmployeeDevelopmentBonus/GetEmployeeDevelopmentBonusList】，並傳送ReferrerMobile/jsDate。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.MessageManagementList,
            data: {
                VersionId: VersionId,
                sDate: sDate,
                eDate: eDate,
                MessageValue: MessageValue,
                MemberMobile: MemberMobile,
                NickName: NickName,
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1])
            }
        })
            .done(MessageManagementResponse)
            .fail(SystemError)
    });
    // 1.在留言板管理首頁點按某一筆留言之回復明細。
    $(document).on('click', '.btn-MessageContent', function (event) {
        event.preventDefault();

        var $this = $(this);
        $this.closest("tr").next().html('');

        //如果已經展開有明細則隱藏
        $tr = $this.closest("tr");
        if ($this.find("span").first().hasClass("glyphicon-minus")) {
            //2a.系統判斷javascript變數IsSpread=true。
            //2a-1.系統清除下一個<tr>之html()，以隠藏下線之下線清單。
            $(this).closest("tr").next().html('');
            //2a-2.系統設定javascript變數IsSpread=false。
            //isSpread = false;
            //2a-3.系統設定展開按鈕圖示為+(展開)。
            $this.find("span").attr('title', '回復');
            $this.find("span").first().removeClass();
            $this.find("span").first().addClass('glyphicon glyphicon-align-center');
            //2a-4.結束。
            return;
        }

        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.MessageManagementData,
            data: {
                MessageId: $(this).parent().parent().children().eq(0).text(),
            }
        })
            .done(ExpandSuccess)
            .fail(SystemError)

        function ExpandSuccess(response) {
            // 10.系統在3啟動之ajax回呼函式中將下一列<tr>的Html內容更新為9-7.系統回傳View。
            $this.closest("tr").next().html(`<td colspan="10">` + response + `</td>`);
            // 10-1.系統設定javascript變數IsSpread=true。
            isSpread = true;
            // 10-2.系統設定展開按鈕圖示為-(隱藏)。
            $this.find("span").attr('title', '隠藏');
            $this.find("span").first().removeClass();
            $this.find("span").first().addClass('glyphicon glyphicon-minus');
            // 11.結束。
        }

        //if ($this.find("span").first().hasClass("glyphicon-minus"))
        //{
        //    //2a.系統判斷javascript變數IsSpread=true。
        //    //2a-1.系統清除下一個<tr>之html()，以隠藏下線之下線清單。
        //    $(this).closest("tr").next().html('');
        //    //2a-2.系統設定javascript變數IsSpread=false。
        //    //isSpread = false;
        //    //2a-3.系統設定展開按鈕圖示為+(展開)。
        //    $this.find("span").attr('title', '銷貨明細');
        //    $this.find("span").first().removeClass();
        //    $this.find("span").first().addClass('glyphicon glyphicon-th-list');
        //    //2a-4.結束。
        //    return;
        //}
        //// 2.系統判斷javascript變數IsSpread=false(預設值為false)。
        //// 3.系統以ajax呼叫Post Controller Action【Order/GetOrderDetailListNoButton】，並傳送jOrderId與1點按頁碼。

        //function ExpandBefore() { }

        //function ExpandSuccess(response)
        //{
        //    // 10.系統在3啟動之ajax回呼函式中將下一列<tr>的Html內容更新為9-7.系統回傳View。
        //    $this.closest("tr").next().html('<td colspan="10">' + response + '</td>');
        //    // 10-1.系統設定javascript變數IsSpread=true。
        //    //isSpread = true;
        //    // 10-2.系統設定展開按鈕圖示為-(隱藏)。
        //    $this.find("span").attr('title', '隠藏');
        //    $this.find("span").first().removeClass();
        //    $this.find("span").first().addClass('glyphicon glyphicon-minus');
        //    // 11.結束。
        //}
    });
    // 1.使用者在銷貨清單明細點按換頁連結。
    $(document).on('click', '.inner-page-link', function (event) {
        event.preventDefault();
        var $this = $(this);
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 3.系統以ajax呼叫Post Controller Action【Order/GetOrderDetailListNoButton】，並傳送jOrderId與1點按頁碼。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: href[0],
            data: {
                MessageId: jOrderIdDetail,
                'Page': parseInt(page[1]),
                'StartPage': parseInt(startPage[1]),
                'AClass': 'inner-page-link'
            },
            beforeSend: LoadBefore,
            success: ExpandInnerSuccess,
            error: SystemError
        });
        function ExpandInnerSuccess(response) {
            // 10.系統在3啟動之ajax回呼函式中將下一列<tr>的Html內容更新為9-7.系統回傳View。
            $tr.next().html('<td colspan="11">' + response + '</td>');
            // 11.結束。
        }
    });
    //20181221  ---棋
    //1.使用者點按某一列刪除留言選項。
    $(document).on('click', '.btn-DeleteMessageManagement', function () {
        event.preventDefault();
        if (!confirm('確定是否刪除？')) return;

        MessageId = $(this).parent().parent().children().eq(0).text();
        $.ajax({
            type: 'POST',
            cache: false,
            dataType: 'json',
            url: setting.DeleteMessageManagement,
            data: { MessageId: MessageId }
        })
            //6.系統判斷5成功執行。
            //7.系統回傳5傳回值。
            .done(success)
            .fail(SystemError)
        function success(data) {
            data == 0 ? (alert("刪除成功 !")) : ("");
            data == -1 ? (alert("執行錯誤，請稍後再試！")) : ("");
            data == -2 ? (alert("該訊息已刪除 !")) : ("");
        }
    });
    //20181221  ---棋
    //1.使用者點按某一列刪除回復選項。
    $(document).on('click', '.btn-DeleteReplyMessageManagement', function () {
        event.preventDefault();
        if (!confirm('確定是否刪除？')) return;

        ReplyMessageId = $(this).parent().parent().children().eq(0).text();

        $.ajax({
            type: 'POST',
            cache: false,
            dataType: 'json',
            url: setting.DeleteReplyMessageManagement,
            data: { ReplyMessageId: ReplyMessageId }
        })
            //6.系統判斷5成功執行。
            //7.系統回傳5傳回值。
            .done(success)
            .fail(SystemError)
        function success(data) {
            data == 0 ? (alert("刪除成功 !")) : ("");
            data == -1 ? (alert("執行錯誤，請稍後再試！")) : ("");
            data == -2 ? (alert("該訊息已刪除 !")) : ("");
        }
    });
    //20181221  ---棋
    //1.使用者點按查看板規。
    $(document).on('click', '#btn-Version', function () {
        event.preventDefault();
        var selected = $('#VersionListOption option:selected').val();
        console.log(selected);
        selected == 99 ? (alert("請選擇版別 ! ")) : ("");
        $(`#` + selected).modal({ backdrop: "static" });
    });
    //20181221  ---棋
    //1.使用者點在變更板規點選送出。
    $(document).on('click', '.btn-UpdateMemberLevelCartImg', function () {
        event.preventDefault();
        if ($('#UpImgExample').val() == null || $('#UpImgExample').val() == "") {
            alert("請選擇圖片 !");
            return;
        }
        if (!confirm('確定是否更改板規？')) return;
        $(this.form).ajaxSubmit({
            dataType: "json",
            success: success,
            error: SystemError
        });

        function SystemError() {
            alert('執行錯誤，請稍後再試！');
        }
        function success(data) {
            data == 0 ? (alert("更新成功 !")) : ("");
            data == -1 ? (alert("執行錯誤，請稍後再試！")) : ("");
        }
    });
    //20181221  ---棋
    //1.使用者點按某一列停權選項。
    $(document).on('click', '.btn-UpdateMemberEnabled', function () {
        event.preventDefault();
        if (!confirm('確定是否停權？')) return;
        MemberMobile = $(this).parent().parent().children().eq(3).text();
        $.ajax({
            type: 'POST',
            cache: false,
            dataType: 'json',
            url: setting.UpdateMemberEnabled,
            data: {
                MemberMobile: MemberMobile,
                Enabled: 0,
            }
        })
            //6.系統判斷5成功執行。
            //7.系統回傳5傳回值。
            .done(success)
            .fail(SystemError)
        function success(data) {
            data == 0 ? (alert("停權成功 !")) : ("");
            data == -1 ? (alert('執行錯誤，請稍後再試！')) : ("");
        }
    });
    //20181221  ---棋
    //1.使用者點按回覆留言某一列停權選項。
    $(document).on('click', '.btn-UpdateMemberEnabledData', function () {
        event.preventDefault();
        if (!confirm('確定是否停權？')) return;

        MemberMobile = $(this).parent().parent().children().eq(3).text();

        $.ajax({
            type: 'POST',
            cache: false,
            dataType: 'json',
            url: setting.UpdateMemberEnabled,
            data: {
                MemberMobile: MemberMobile,
                Enabled: 0,
            }
        })
            //6.系統判斷5成功執行。
            //7.系統回傳5傳回值。
            .done(success)
            .fail(SystemError)
        function success(data) {
            data == 0 ? (alert("停權成功 !")) : ("");
            data == -1 ? (alert('執行錯誤，請稍後再試！')) : ("");
        }
    });

    //20181225 ---棋
    //點選回復彈出Model
    $(document).on('click', '.btn-MessageReply', function () {
        $('#ReplyVersionid').val($(this).closest('tr').children('td').eq(0).text());
        $('#newReplyModal').modal('show');
    });

    //20181218 ---棋
    //1.使用這在新增訊息Model點選送出訊息
    $(document).on('click', '#btn-NewReplyMessage', function () {
        if ($('#newReplyMessageValue').val() == null || $('#newReplyMessageValue').val() == "") {
            alert("請填寫回復內容 !");
            return;
        }

        $.ajax({
            type: "GET",
            cache: false,
            dataType: "json",
            url: setting.InsertReplyMessageManagement,
            data: {
                MessageId: $('#ReplyVersionid').val(),
                ReplyMessageValue: $('#newReplyMessageValue').val(),
                ReplyMobile: $('#EmployeeMobile').val(),
            }
        })
            .done(data => {
                console.log(data);
                if (data == 0) {
                    alert("回復成功 !");
                    $('#newReplyModal').modal("hide");
                }

                data == -1 ? (alert("新增失敗，請稍後再試！")) : ("");
                data == -2 ? (alert("重複留言，請5分鐘後再試！")) : ("");
                data == -3 ? (alert("系統錯誤，請稍後再試！")) : ("");
            })
            .fail(SystemError);
    });
};