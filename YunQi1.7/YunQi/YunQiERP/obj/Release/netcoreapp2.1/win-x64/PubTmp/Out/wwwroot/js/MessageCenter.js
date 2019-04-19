var jMemberMobile, jMemberMobileWhere, jsDate;
var MessageId = 0;
var MemberLevelId = 0;
var originalMessageId = 0;
var MailCenter = [];
var memberMailCenter = [];
var memberList = [];
function Orderfunction(option) {
    var setting = {
        GetMembevLevel: '',
        MessageCenterList: '',
        DeleteMailCenterMessage: '',
        GetMemberLevelList: '',
        GetMailCenterTop1: '',
        InsertMailCenterMessage: '',
        GetStrMembevLevel: '',
        InsertMemberMessage: '',
    };
    setting = $.extend(setting, option);

    function SystemError() {
        alert('執行錯誤，請稍後再試！');
    }

    function MemberBonusListResponse(response) {
        $('#MessageCenterList').html(response);
    }

    $(document).on('click', '#newMessageCenter', function () {
        //請求最後一筆 比數
        $.ajax({
            type: 'POST',
            cache: false,
            dataType: 'json',
            url: setting.GetMailCenterTop1,
        })
            .done(data => {
                MessageId = parseInt(data + 1)
                originalMessageId = parseInt(data);
            })
            .fail(SystemError)

        $('#myModal').modal({ backdrop: "static" });
    });

    //----------下拉選群組選單
    $(".dropdown dt a").on('click', function () {
        $(".dropdown dd ul").slideToggle('fast');
    });
    $(".dropdown dd ul li a").on('click', function () {
        $(".dropdown dd ul").hide();
    });
    function getSelectedValue(id) {
        return $("#" + id).find("dt a span.value").html();
    }
    $(document).bind('click', function (e) {
        var $clicked = $(e.target);
        if (!$clicked.parents().hasClass("dropdown")) $(".dropdown dd ul").hide();
    });
    $('.mutliSelect input[type="checkbox"]').on('click', function () {
        var title = $(this).closest('.mutliSelect').find('input[type="checkbox"]').val(),
            title = $(this).val() + ",";
        var memberlevelid = $(this).data('memberlevelid');
        if ($(this).is(':checked')) {
            var html = '<span title="' + memberlevelid + '">' + title + '</span>';
            $('.multiSel').append(html);
            $(".hida").hide();
        } else {
            $('span[title="' + memberlevelid + '"]').remove();
            var ret = $(".hida");
            $('.dropdown dt a').append(ret);
        }
    });
    //----------下拉選群組選單

    function MailCenterData(MessageId, MessageTime, MessageValue, MemberLevelId, EmployeeMobile, MessageTitle) {
        this.MessageId = MessageId;
        this.MessageTime = MessageTime;
        this.MessageValue = MessageValue;
        this.MemberLevelId = MemberLevelId;
        this.EmployeeMobile = EmployeeMobile;
        this.MessageTitle = MessageTitle;
    }

    function MemberMessageData(MemberMobile, MessageId, MemberLevelId) {
        this.MemberMobile = MemberMobile;
        this.MessageId = MessageId;
        this.MemberLevelId = MemberLevelId;
    }

    //20181218  ---棋
    //1.使用者在業務發展獎金管理首頁輸入會員手機/日期(月份)並按查詢。
    $(document).on('click', '#btnSearchCenter', event => {
        event.preventDefault();

        MessageValue = $('#MessageValue').val();
        sDate = $('#sDate').val();
        eDate = $('#eDate').val();
        MemberLevelId = $('#MemberLevelSelect option:selected').val();

        //3.系統以ajax呼叫Get Action【EmployeeDevelopmentBonus/GetEmployeeDevelopmentBonusList】，並傳送jMemberMobile/jMemberMobileWhere/jsDate。
        //10.系統在3啟動之ajax呼叫回呼函式中將<Div MemberBonusList>.Html()更新為9-7回傳View。
        //4.系統以ajax呼叫POST Action【EmployeeDevelopmentBonus / GetEmployeeDevelopmentBonusList】，並傳送jsDate
        $.ajax({
            type: 'POST',
            cache: false,
            dataType: 'HTML',
            url: setting.MessageCenterList,
            data: {
                MemberLevelId: MemberLevelId,
                MessageValue: MessageValue,
                sDate: sDate,
                eDate: eDate,
            }
        })
            //6.系統判斷5成功執行。
            //7.系統回傳5傳回值。
            .done(MemberBonusListResponse)
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
        MemberLevelId = $('#MemberLevelSelect option:selected').val();
        // 3.系統以ajax呼叫Get Action【EmployeeDevelopmentBonus/GetEmployeeDevelopmentBonusList】，並傳送ReferrerMobile/jsDate。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.MessageCenterList,
            data: {
                MemberLevelId: MemberLevelId,
                MessageValue: MessageValue,
                sDate: sDate,
                eDate: eDate,
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1])
            }
        })
            .done(MemberBonusListResponse)
            .fail(SystemError)
    });
    //20181210  ---棋
    //1.使用者點按某一列刪除選項。
    $(document).on('click', '.btn-DelMessage', function () {
        event.preventDefault();
        if (!confirm('確定是否刪除？')) return;

        MessageId = $(this).parent().parent().children().eq(0).text();
        MemberLevelid = $(this).data('memberlerelid');

        console.log(MessageId, MemberLevelid);

        $.ajax({
            type: 'POST',
            cache: false,
            dataType: 'json',
            url: setting.DeleteMailCenterMessage,
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
            data == -3 ? (alert("")) : ("");
        }
    });

    //20181218 ---棋
    //1.使用這在新增訊息Model點選送出訊息
    $(document).on('click', '#subNewMessage', function () {
        var multiSel = $('.multiSel').children();
        var MessageTitle = $('#AddMessageTitle').val();
        var MessageValue = $('#AddMessageValue').val();
        var EmployeeMobile = $('#EmployeeMobile').val();
        var status = 99;

        var dt = new Date();

        MessageTime = parseInt(dt.getFullYear()) + "/" + (dt.getMonth() + 1) + "/" + dt.getDate() + " " + dt.getHours() + ":" + dt.getMinutes() + ":" + dt.getSeconds() + "." + dt.getMilliseconds();

        MailCenter = [];
        $('.multiSel').children('span').each(function (index, element) {
            MemberLevelId = parseInt($(element).attr('title'));
            MailCenter.push(new MailCenterData(MessageId, MessageTime, MessageValue, MemberLevelId, EmployeeMobile, MessageTitle));
            MessageId++;
        })

        console.log(MailCenter);
        $.ajax({
            type: 'POST',
            cache: false,
            async: false,
            dataType: 'json',
            url: setting.InsertMailCenterMessage,
            data: {
                MailCenter: MailCenter,
            }
        })
            .done(data => { status = data; })
            .fail(SystemError)

        if (status == 0) {
            memberMailCenter = [];
            for (var i = 0; i < multiSel.length; i++) {
                originalMessageId++;
                MemberLevelid = $('.multiSel').children().eq(i).attr('title'),
                    //先讀取該群組所有會員帳號
                    $.ajax({
                        type: 'POST',
                        cache: false,
                        async: false,
                        dataType: 'json',
                        url: setting.GetMemberLevelList,
                        data: {
                            MemberLevelid: MemberLevelid,
                        }
                    })
                        .done(success)
                        .fail(SystemError)

                function success(data) {
                    for (var i = 0; i < data.length; i++) {
                        memberMailCenter.push(new MemberMessageData(data[i].memberMobile, originalMessageId, MemberLevelid))
                    }

                    //新增前台訊息
                }
            }

            console.log(memberMailCenter);

            $.ajax({
                type: 'POST',
                cache: false,
                dataType: 'json',
                url: setting.InsertMemberMessage,
                data: {
                    memberMailCenter: memberMailCenter,
                }
            })
                .done(data => {
                    if (data == 0) {
                        alert("訊息新增成功 ! ");
                        $('#myModal').modal('hide');
                    }
                    data == -1 ? (alert('執行錯誤，請稍後再試！')) : ("");
                })
                .fail(SystemError)
        }
        else {
            alert('執行錯誤，請稍後再試！');
        }

        //InsertMessage();

        ////新增後台訊息
        //for (var i = 0; i < multiSel.length; i++)
        //{
        //    //取得發送群組MemberLevelid
        //    var MemberLevelId = multiSel.eq(i).attr('title')

        //    //將資料新增到後台 訊息中心
        //    $.ajax({
        //        type: 'POST',
        //        cache: false,
        //        dataType: 'json',
        //        url: setting.InsertMailCenterMessage,
        //        data: {
        //            EmployeeMobile: EmployeeMobile,
        //            MemberLevelId: MemberLevelId,
        //            MessageTitle: AddMessageTitle,
        //            MessageValue: AddMessageValue,
        //            MessageId: MessageId,
        //        }
        //    })
        //        .done(success)
        //        .fail(SystemError)

        //    function success(data)
        //    {
        //        var status = 0;
        //        data == 0 ? (status = 1) : ("");
        //        data == -3 ? (status = 3) : ("");
        //        ////前台MessageData
        //        //var MessageData = [];
        //        //function MessageData(MemberMobile, MessageId, MemberLevelId)
        //        //{
        //        //    this.MemberMobile = MemberMobile;
        //        //    this.MessageId = MessageId;
        //        //    this.MemberLevelId = MemberLevelId;
        //        //}
        //        ////如果後臺新增成功
        //        //if (status == 9)
        //        //{
        //        //    //先讀取該群組所有會員帳號
        //        //    $.ajax({
        //        //        type: 'POST',
        //        //        cache: false,
        //        //        dataType: 'json',
        //        //        url: setting.GetMemberLevelList,
        //        //        data: {
        //        //            MemberLevel: MemberLevel,
        //        //        }
        //        //    })
        //        //        .done(success)
        //        //        .fail(SystemError)

        //        //    function success(data)
        //        //    {
        //        //        for (var i = 0; i < data.length; i++)
        //        //        {
        //        //            var MemberLevelId = 2;
        //        //            console.log(data[i].memberMobile, MessageId, 2);
        //        //            MessageData.push(new MessageData(data[i].memberMobile, MessageId, MemberLevelId));
        //        //        }
        //        //    }
        //        //}
        //        //else
        //        //{
        //        //    alert(status + "後台新增失敗");
        //        //}
        //    }
        //}
    });

    //for (var i = 0; i < multiSel.length; i++)
    //{
    //    var sub = multiSel.eq(i).attr('title').indexOf(",");
    //    var MemberLevel = multiSel.eq(i).attr('title').substring(0, sub);
    //    $.ajax({
    //        type: 'POST',
    //        cache: false,
    //        dataType: 'json',
    //        url: setting.GetMemberLevelList,
    //        data: {
    //            MemberLevel: MemberLevel,
    //        }
    //    })
    //        .done(success)
    //        .fail(SystemError)

    //    function success(data)
    //    {
    //        //console.log(data[0].memberMobile)
    //    }

    //}

    //$.ajax({
    //    type: 'POST',
    //    cache: false,
    //    dataType: 'json',
    //    url: setting.MessageCenterList,
    //    data: {
    //        EmployeeMobile: $(this).data("mobile"),
    //        Month: $(this).data("month"),
    //    }
    //})
    //    //6.系統判斷5成功執行。
    //    //7.系統回傳5傳回值。
    //    .done(success)
    //    .fail(SystemError)
    //function success(data)
    //{
    //    data == 0 ? (alert("刪除成功 !")) : ("");
    //    data == -1 ? (alert("執行錯誤，請稍後再試！")) : ("");
    //    data == -3 ? (alert("這個月份沒有該員工 !")) : ("");
    //    data == -4 ? (alert("該月份薪資已經入帳 !")) : ("");
    //}
};