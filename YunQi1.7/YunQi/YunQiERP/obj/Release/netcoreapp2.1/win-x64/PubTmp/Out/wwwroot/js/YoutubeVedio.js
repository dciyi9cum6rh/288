let jYoutubeVedioSubject = '', jYoutubeVedioId;
function YoutubeVediofunction(option) {
    var setting = {
        PutYoutubeVedioUrl: ''
    };
    setting = $.extend(setting, option);
    // 1.使用者在YouTube影片設定首頁輸入YouTube影片值後按重設YouTube影片值。
    let $CreateSubmit;
    $('#btnReset').on('click', function (event) {
        event.preventDefault();
        $(this).prop("disabled", true);
        $CreateSubmit = $(this);
        // 2.系統以ajax呼叫Post Action【YoutubeVideo/PutYoutubeVideo】，並傳送YouTube影片網址與YoutubeVideoId。
        let YoutubeVedioId = $(this).data("youtubevideoid");
        //if ($("#YouTubeVideo").val() === "" || $("#YouTubeVideo").val() === null) {
        //    alert("YouTube影片網址必填!");
        //    return;
        //}
        $.ajax({
            type: 'POST',
            url: setting.PutYoutubeVedioUrl,
            data: {
                "YoutubeVideoId": YoutubeVedioId, "YouTubeVideo": $("#YouTubeVideo").val()
            },
            beforeSend: LoadBefore,
            success: PutYoutubeVedioSuccess,
            error: SystemError
        });

        $CreateSubmit.prop("disabled", false);

        function PutYoutubeVedioSuccess(response) {
            if (response === 0) {
                // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
                // 13.系統顯示重設成功。
                alert("重設成功！");
                $("#youtubeif").attr("src", $("#YouTubeVideo").val());
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