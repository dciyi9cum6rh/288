var jMemberMobile, jMemberMobileWhere, jsDate;
function Orderfunction(option) {
    var setting = {
        CaculateMemberDevelopmentBonus: '',
        AccountMemberDevelopmentBonus: '',
        MemberDevelopmentBonusList: '',
        GetMemberDevelopmentBonusDetailList: '',
    };
    setting = $.extend(setting, option);

    function SystemError() {
        alert('執行錯誤，請稍後再試！');
    }

    //8.系統在4啟動之aax回呼函式中判斷7傳回值===0。
    //9.系統顯示營運獎金計算成功。
    function CaculateMemberBonus(data) {
        data === 0 ? (alert("營運獎金計算成功")) : ("");
        data === -1 ? (alert("執行錯誤，請稍後再試！")) : ("");
        data === -2 ? (alert("月份還在進行中！")) : ("");
        data === -3 ? (alert("已經入帳！")) : ("");
        data === -4 ? (alert("會計已經入帳！")) : ("");
        data === 1 ? (alert("Procedures 交易失敗！！")) : ("");
        data === 2 ? (alert("無此權限！！")) : ("");
        data === 3 ? (alert("本月營運獎金己完成入帳！")) : ("");
        return;
    };

    function MemberBonusListResponse(response) {
        $('#MemberBonusList').html(response);
    }

    //20181203  ---棋
    //1.使用者在批發會員發展獎金管理首頁輸入日期並按獎金計算。
    //2.系統確認使用者要計算。
    $(document).on('click', '#btnCaculate', event => {
        event.preventDefault();
        if ($('#sDate').val() == "") {
            alert("請輸入日期!");
            return;
        }
        //3.系統將1輸入資料暫存至jsDate。
        jsDate = ($('#sDate').val().substr(0, 4) + $('#sDate').val().substr(5, 2) + "01");
        console.log(jsDate); //測試用
        //4.系統以ajax呼叫POST Action【MemberBonus / CaculateMemberDevelopmentBonus】，並傳送jsDate
        $.ajax({
            type: 'POST',
            cache: false,
            dataType: 'Json',
            url: setting.CaculateMemberDevelopmentBonus,
            data: {
                'Month': jsDate,
            }
        })
            //6.系統判斷5成功執行。
            //7.系統回傳5傳回值。
            .done(CaculateMemberBonus)
            .fail(SystemError)
    });

    //20181203  ---棋
    //1.使用者在批發會員發展獎金管理首頁輸入日期並按獎金入帳。
    $(document).on('click', '#btnEntryAccount', event => {
        event.preventDefault();
        if ($('#sDate').val() == "") {
            alert("請輸入日期!");
            return;
        }
        //3.系統將1輸入資料暫存至jsDate。
        jsDate = ($('#sDate').val().substr(0, 4) + $('#sDate').val().substr(5, 2) + "01");
        console.log(jsDate); //測試用
        // 4.系統以ajax呼叫POST Action【MemberBonus / AccountMemberDevelopmentBonus】，並傳送jsDate
        $.ajax({
            type: 'POST',
            cache: false,
            dataType: 'Json',
            //url: setting.AccountMemberBonus,
            url: setting.AccountMemberDevelopmentBonus,
            data: {
                'Month': jsDate,
            }
        })
            //6.系統判斷5成功執行。
            //7.系統回傳5傳回值。
            .done(CaculateMemberBonus)
            .fail(SystemError)
    })

    //20181129  ---棋
    //1.使用者在批發會員獎金管理首頁輸入會員手機/日期(月份)並按查詢。
    $(document).on('click', '#btnSearchMemberBonus', event => {
        event.preventDefault();
        //註.月份一定要填
        MemberMobile = $('#ReferrerMobile').val();
        if ($('#sDate').val() == "") {
            alert("請輸入日期!");
            return;
        }
        jsDate = ($('#sDate').val().substr(0, 4) + $('#sDate').val().substr(5, 2) + "01");

        console.log(jsDate)
        console.log(ReferrerMobile)
        //3.系統以ajax呼叫Get Action【MemberBonus/GetMemberBonusList】，並傳送jMemberMobile/jMemberMobileWhere/jsDate。
        //10.系統在3啟動之ajax呼叫回呼函式中將<Div MemberBonusList>.Html()更新為9-7回傳View。
        //4.系統以ajax呼叫POST Action【MemberBonus / CaculateMemberBonus】，並傳送jsDate
        $.ajax({
            type: 'POST',
            cache: false,
            dataType: 'HTML',
            url: setting.MemberDevelopmentBonusList,
            data: {
                MemberMobile: MemberMobile,
                jsDate: jsDate,
            }
        })
            //6.系統判斷5成功執行。
            //7.系統回傳5傳回值。
            .done(MemberBonusListResponse)
            .fail(SystemError)
    });

    //20181129  ---棋
    // 1.使用者在銷貨清單點按換頁連結。
    $(document).on('click', '.page-link', function (event) {
        event.preventDefault();
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");
        // 3.系統以ajax呼叫Get Action【Order/GetOrderList】，並傳送jOrderId/jsDate/jeDate/jMemberMobile/jOrderStateId/jProduct。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetMemberBonusList,
            data: {
                ReferrerMobile: ReferrerMobile,
                jsDate: jsDate,
                'Page': parseInt(page[1]),
                'LinkType': parseInt(linkType[1]),
                'StartPage': parseInt(startPage[1])
            }
        })
            .done(MemberBonusListResponse)
            .fail(SystemError)
    });

    //20181129  ---棋
    // 1.使用者在直屬會員按換頁連結。
    $(document).on('click', '.inner-page-link', function (event) {
        event.preventDefault();

        var $this = $(this);
        var href = $(this).attr('href').split("?");
        var para = href[1].split("&");
        var page = para[0].split("=");
        var linkType = para[1].split("=");
        var startPage = para[2].split("=");

        console.log(jReferrerMobile)
        console.log(startPage)
        console.log(page)

        // 3.系統以ajax呼叫Post Controller Action【Order/GetOrderDetailListNoButton】，並傳送jOrderId與1點按頁碼。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetMemberDevelopmentBonusDetailList,
            data: {
                ReferrerMobile: jReferrerMobile,
                jsDate: jsDate,
                'Page': parseInt(page[1]),
                'StartPage': parseInt(startPage[1]),
                'AClass': 'inner-page-link'
            }
        })
            .done(ExpandInnerSuccess)
            .fail(SystemError)

        function ExpandInnerSuccess(response) {
            // 10.系統在3啟動之ajax回呼函式中將下一列<tr>的Html內容更新為9-7.系統回傳View。
            $tr.next().html('<td colspan="11">' + response + '</td>');
            // 11.結束。
        }
    });

    //20181129  ---棋
    //1.在批發會員獎金管理首頁點按某一筆批發會員獎金之直屬會員/隠藏。
    $(document).on('click', '.btn-detail', function (event) {
        event.preventDefault();
        var $this = $(this);
        // -1.系統將1點按會員手機號暫存在jReferrerMobile。
        jReferrerMobile = ($this.closest("tr").find("td:eq(0)").text()).toString();
        $tr = $this.closest("tr");

        console.log(jReferrerMobile)
        console.log(jsDate)

        if ($this.find("span").first().hasClass("glyphicon-minus")) {
            //2a.系統判斷javascript變數IsSpread=true。
            //2a-1.系統清除下一個<tr>之html()，以隠藏下線之下線清單。
            $(this).closest("tr").next().html('');
            //2a-2.系統設定javascript變數IsSpread=false。
            isSpread = false;
            //2a-3.系統設定展開按鈕圖示為+(展開)。
            $this.find("span").attr('title', '銷貨明細');
            $this.find("span").first().removeClass();
            $this.find("span").first().addClass('glyphicon glyphicon-th-list');
            //2a-4.結束。
            return;
        }

        //2.系統判斷javascript變數IsSpread=false(預設值為false)。
        //3.系統以ajax呼叫Post Controller Action【MemberBonus / GetMemberBonusDetailList】，並傳送jReferrerMobile、jsDate與1點按頁碼。
        $.ajax({
            type: 'Post',
            cache: false,
            dataType: 'HTML',
            url: setting.GetMemberDevelopmentBonusDetailList,
            data: {
                ReferrerMobile: jReferrerMobile,
                jsDate: jsDate,
            }
        })
            .done(ExpandSuccess)
            .fail(SystemError)

        function ExpandSuccess(response) {
            // 10.系統在3啟動之ajax回呼函式中將下一列<tr>的Html內容更新為9-7.系統回傳View。
            $this.closest("tr").next().html('<td colspan="10">' + response + '</td>');
            // 10-1.系統設定javascript變數IsSpread=true。
            //isSpread = true;
            // 10-2.系統設定展開按鈕圖示為-(隱藏)。
            $this.find("span").attr('title', '隠藏');
            $this.find("span").first().removeClass();
            $this.find("span").first().addClass('glyphicon glyphicon-minus');
            // 11.結束。
        }
    });
};