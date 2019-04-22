var jProductCategoryId, jProductCategory, jCurrentPage, jTotallPages;
var jProduct = "",
    jlowPrice = 0,
    jhightPrice = 10000000;
var jMemberMobile = "",
    jMemberlevelId = -1,
    jNickName,
    jProductId,
    jQuantity;
var jsDate = '', jeDate = '';
var carts = [];   // 購物車清單
var contactData;  // 送貨資料
var freight;      // 運費
var cartTobal = 0;  // 合計(含運費)
var orderId, jOrderId = '';  // 訂單編號
var green = [];    // 綠界
function Homepagefunction(
    mallUrl,
    cartUrl,
    homeLoginUrl,
    homeMainUrl,
    memberUrl,
    joinusUrl,
    memberPersonaldataUrl,
    memberMemberlevelUrl,
    memberWholesaletipsUrl,
    memberShipaddressUrl,
    memberMyorderUrl,    
    memberMyOrderBonusUrl,
    memberMyfavoriteUrl,
    memberMyfollowerUrl,
    memberFollowertriumphUrl,
    memberPointnotesUrl,
    memberWishipoolUrl,             //20181224 ---棋         "Member/Wishipool"
    memberMembermoveUrl,            //20181224 ---棋         "Member/Membermove"
    memberMailcenterUrl,
    joinusRegisterUrl,
    joinusShoppingflowUrl,
    joinusPaywayUrl,
    joinusQandaUrl,
    joinusShipdaysUrl,
    cartSuccessUrl,
    GetProductListUrl,
    GetProductLevelPathUrl,
    GetProductCategoryIdUrl,
    GetProductDetailUrl,
    GetOfferProductListUrl,
    JoinMemberUrl,
    LoginUrl,
    PutMemberUrl,
    PutMemberLevelUrl,
    PostMemberFavoriteUrl,
    GetProductStockUrl,
    PostMemberCartsUrl,
    memberFavoriteDetailUrl,
    DeleteCartUrl,
    DeleteCartsUrl,
    UpdateCartUrl,
    GetFreightUrl,
    GetOutFreightUrl,
    PostOrderUrl,
    UpdateOrderState3Url,
    DeleteMyfavorite,               //20181130 ---棋
    PostLogout,                     //20181207 ---棋
    GetHomeIndex,                   //20181207 ---棋
    InsertMemberForget,             //20181207 ---棋
    GetCancelOrderState,            //20181213 ---棋         "Cart/GetCancelOrderState"
    MemberVerification,             //20181216 ---棋         "Joinus/MemberVerification"
    MemberMailcenter,               //20181217 ---棋         "Member/Mailcenter"
    InsertMemberDeliveryAddress,    //20181220 ---棋         "Member/InsertMemberDeliveryAddress"
    UpdateMemberDeliveryAddress,    //20181220 ---棋         "Member/IUpdateMemberDeliveryAddress"
    GetMemberDeliveryAddress,       //20181220 ---棋         "Member/GetMemberDeliveryAddress"
    InsertMessageManagement,        //20181224 ---棋         "Member/InsertMessageManagement"
    InsertReplyMessageManagement,   //20181224 ---棋         "Member/InsertReplyMessageManagement"
    GetMemberCartOneList,           //20181227 ---棋         "Member/GetMemberCartOneList"
) {
    // let setting = {};
    // setting = $.extend(setting, option);

    const windowInnerHeight = $(window).innerHeight();
    let swiper;

    // 切換到不同功能頁面
    $(document).on("click", "#ulHome li a", function (event) {
        event.preventDefault();
        $(".spaDiv").hide();
        // console.log($(this).data('spadiv'));
        $(`#${$(this).data("spadiv")}`).show();
    });
    $(document).on("click", "#btnExpanProductCategory", event => {
        event.preventDefault();
        // $('#productsidenav').removeClass('col-sm-2 hidden-xs');
        // $('#productsidenav').addClass('col-xs-6');
        // $('#pruductPpage').removeClass('col-sm-10 col-xs-12');
        // $('#pruductPpage').addClass('col-xs-6');
        // console.log($('#productsidenav').hasClass('col-xs-6'));
        $("#divXsProductCategory").html($("#productsidenavcontent").html());
        $("#mainContent").hide();
        $("#divXsProductCategory").show();
    });
    $(document).on("click", "#btnProductCategoryClose", event => {
        event.preventDefault();
        // $('#productsidenav').removeClass('col-sm-2 hidden-xs');
        // $('#productsidenav').addClass('col-xs-6');
        // $('#pruductPpage').removeClass('col-sm-10 col-xs-12');
        // $('#pruductPpage').addClass('col-xs-6');
        // console.log($('#productsidenav').hasClass('col-xs-6'));
        $("#divXsProductCategory").hide();
        $("#mainContent").show();
    });
    $(document).on("click", "#btnCloseproductDetailView", event => {
        event.preventDefault();
        $("#productDetailPage").fadeOut();
        $("#productPage").fadeIn(); window.scrollTo(0, 0);
    });
    $(document).on("click", "#productView div div div a", event => {
        event.preventDefault();
        $("#productPage").fadeOut();
        $("#productDetailPage").fadeIn();
        window.scrollTo(0, 0);
    });

    const systemError = () => {
        alert("系統錯誤，請稍後再試！");
    };
    const loadBefore = () => { };

    const loginPage = (data) => {
        $("#mainContent").empty();
        $("#mainContent").html(data);

        // 收合MENU選單
        $('.header-box').find('.navbar-toggler').addClass('collapsed');
        $('#menuNavbar').removeClass('show');

        carts = [];
    };

    const homePage = data => {
        $("#mainContent").empty();
        $("#mainContent").html(data);

        /* eslint-disable */
        swiper = new Swiper(".swiper-container", {
            autoHeight: true,
            slidesPerView: 3,
            centeredSlides: true,
            spaceBetween: 30,
            loop: true,
            autoplay: {
                delay: 2500,
                disableOnInteraction: false
            },
            pagination: {
                el: ".swiper-pagination",
                clickable: true
            },
            navigation: {
                nextEl: ".swiper-button-next",
                prevEl: ".swiper-button-prev"
            }
        });
        /* eslint-enable */

        // 加入我們圖片
        $("#linkJoinUs").on("click", () => {
            $.ajax({
                type: "GET",
                cache: false,
                dataType: "HTML",
                url: joinusUrl
            })
                .done(joinusPage)
                .fail(systemError);

            $("#navMenu")
                .find(".nav-link")
                .removeClass("active");

            $("#navMenu")
                .find('.nav-link[data-nav="joinus"]')
                .addClass("active");
        });
    };

    const mallPage = data => {
        $("#mainContent").empty();
        $("#mainContent").html(data);

        if (jMemberlevelId !== 2) {
            $("#btnOfferProduct").hide();
            $("#btnAllProduct").hide();
        } else {
            $("#btnOfferProduct").show();
            $("#btnAllProduct").show();
        }
        // onst detailHieght = $('#productPanel').height();
        // alert(detailHieght);
        // $('#productDetail').height(detailHieght);
        // 設定列表商品圖片的寬高
        const imgWidth = $('.productlist-item .product-pic').width();
        $('.productlist-item .product-pic').height(imgWidth);

        //$("#mobileSide").on("click", () => {
        //    $(".alltype-box").toggleClass("active");
        //});
        $(document).on('click', '#mobileSide', () => {
            $(".alltype-box").addClass("active");
        });

        $("#btnAlltypeClose").on("click", () => {
            $(".alltype-box").removeClass("active");
        });

        //$("#btnProductDetailClose").on("click", () => {
        //    alert("");
        //    $("#productDetail").removeClass("active");
        //});

        // 1.使用者點按商品清單中的某個商品。
        $(document).on("click", ".productlist-item .product-pic, .productlist-item .btn-AddToCart, .btn-favoritedetail", event => {
            if (jMemberMobile === null || jMemberMobile === "") {
                alert("請先登入！");
                return;
            }
            // 2.系統以ajax呼叫Get Controller Action【Mall/GetProductDetail】，並傳送點按商品代碼。
            //alert("");
            jProductId = $(event.currentTarget).data("productid");
            $.ajax({
                type: "POST",
                cache: false,
                dataType: "HTML",
                url: GetProductDetailUrl,
                data: {
                    ProductId: $(event.currentTarget).data("productid"),
                    MemberLevelId: jMemberlevelId
                }
            })
                .done(GetProductDetail)
                .fail(systemError);
        }
        );

        //// 1.使用者點按商品清單中的某個商品。
        //$(".productlist-item")
        //  .find(".product-pic")
        //    .on("click", event => {
        //        // 2.系統以ajax呼叫Get Controller Action【Mall/GetProductDetail】，並傳送點按商品代碼。
        //        $.ajax({
        //            type: "POST",
        //            cache: false,
        //            dataType: "HTML",
        //            url: GetProductDetailUrl,
        //            data: {
        //                'ProductId': $(event.currentTarget).data('productid'),
        //                'MemberLevelId': jMemberlevelId
        //            }
        //        })
        //            .done(GetProductDetail)
        //            .fail(systemError);
        //  });
    };

    $(document).on("click", "#btnProductDetailClose", event => {
        event.preventDefault();
        $("#productDetail").removeClass("active");
    });

    const GetProductDetail = data => {
        // 9.系統在2啟動之ajax回呼函式中更新<Div id="productDetail">的內容為9-7傳回值。
        $("#productDetail").addClass("active");
        $("#productDetail").html(data);
        //// 清除購物清單物件
        //carts = [];
    };

    const successPage = data => {
        $("#mainContent").empty();
        $("#mainContent").html(data);
    };

    const cartPage = data => {
        $("#mainContent").empty();
        $("#mainContent").html(data);

        $("#cartlistPanel")
            .find(".btn-back")
            .on("click", () => {
                $("#navMenu")
                    .find(".nav-link")
                    .removeClass("active");
                $("#navMenu")
                    .find('.nav-link[data="nav"]')
                    .addClass("active");

                $.ajax({
                    type: "GET",
                    cache: false,
                    dataType: "HTML",
                    data: { MemberLevelId: jMemberlevelId },
                    url: mallUrl
                })
                    .done(mallPage)
                    .fail(systemError);
            });

        //20181226 ---國揚
        // 1.使用者在購物車首頁點按下一步。
        $("#cartlistPanel").find(".btn-next").on("click", () => {
            if ($("#CartLists tr").length > 0) {
                // 2.系統判斷購物項目>0。
                if (jMemberMobile != '') {
                    // 2-1.系統判斷jMemberMobile!=""
                    //  2-2.糸統清空carts。
                    carts = [];
                    //  2-3.系統將購物清單中的每一個購物項目Push至carts。
                    $("#CartLists input:checkbox").each(function (index, element) {
                        carts.push(new cart(
                            $(element).data("productid"),
                            $(element).data("producsizeid"),
                            $(element).data("productcolorid"),
                            $(element).data("quantity"),
                            $(element).data("product"),
                            $(element).data("price")));
                    });
                    //console.log(carts);
                }
                // 2-1.系統判斷jMemberMobile==""。
                //  2-1a-1.回2-4。
                // 2-4.系統將合計暫存到cartTobal。
                cartTobal = $("#cartTotals").text();
                // 3.切換到下一步。
                $(".flowpath-item").removeClass("active");
                $("#personalFlow").addClass("active");
                $("#cartlistPanel").removeClass("active");
                $("#personalPanel").addClass("active");
                // 讓頁面回到最上面
                window.scrollTo(0, 0);
            }
            else {
                // 2a.系統判斷購物項目<=0。
                //  2a-1.系統顯示"無任何購物項目！"。
                alert("無任何購物項目！");
            }
            // 4.結束。
        });
        $("#personalPanel").find(".btn-back").on("click", () => {
            $(".flowpath-item").removeClass("active");
            $("#cartlistFlow").addClass("active");
            $("#personalPanel").removeClass("active");
            $("#cartlistPanel").addClass("active");
        });
        // 1.使用者在購物車個人資料頁點按下一步。
        $("#personalPanel").find(".btn-next").on("click", () => {
            // 2.系統判斷送貨資料填寫完整。
            var status = true,
                error = "";
            var checkObj = {
                MemberNameCT: $("#MemberNameCT").val(),
                MemberMobileCT: $("#MemberMobileCT").val(),
                ContactAddressCT: $("#ContactAddressCT").val(),
                eMailCT: $("#eMailCT").val()
            };
            var msgObj = {
                MemberNameCT: "姓名必填！",
                MemberMobileCT: "手機必填！",
                ContactAddressCT: "地址必填！",
                eMailCT: "eMailo必填！"
            };

            $.each(checkObj, function (name, jobj) {
                if (jobj === "" || jobj === null) {
                    status = false;
                    error += msgObj[name] + "\r\n";
                }
            });

            if (!checkMobil($("#MemberMobileCT").val())) {
                status = false;
                error += "手機格式不正確！" + "\r\n";
            }
            if (!checkeMail($("#eMailCT").val())) {
                status = false;
                error += "eMail格式不正確！" + "\r\n";
            }

            if (!status) {
                // 驗証失敗
                alert(error);
                return;
            }

            // 3.系統將送貨資料暫存到contactData(含運費)。
            contactData = new ContactData(
                $("#MemberNameCT").val(),
                $("#MemberMobileCT").val(),
                $("#PhoneCT").val(),
                $("#ContactAddressCT").val(),
                $("#eMailCT").val(),
                $("#FreightCT").val()
            );
            // 3-1.切換到下一步顯示金流公司付款方式。
            $(".flowpath-item").removeClass("active");
            $("#paywayFlow").addClass("active");
            $("#personalPanel").removeClass("active");
            $("#paywayPanel").addClass("active");
            green = [];
            // 4.系統以ajax呼叫Post Action【Cart/PostOrder】，並傳送jMemberMobile、carts，contactData、cartTobal。
            $.ajax({
                type: "Post",
                cache: false,
                url: PostOrderUrl,
                data: {
                    MemberMobile: jMemberMobile,
                    Carts: carts,
                    ContactData: contactData,
                    CartTobal: cartTobal
                }
            })
                .done(response => {
                    // 21.系統在4啟動之ajax回呼函式中將div id="paywayPanel" class="paybill-panel">.html()設為16傳回View。
                    $("#paywayPanel").html(response);

                    // 讓頁面回到最上面
                    window.scrollTo(0, 0);

                    // 22.結束。
                })
                .fail(systemError);
        });

        // 圖按結帳時
        //$(document).on("click","#btnPay", () => {
        //        $.ajax({
        //            type: "Post",
        //            cache: false,
        //            dataType: "HTML",
        //            url: cartSuccessUrl
        //        })
        //            .done(successPage)
        //            .fail(systemError);
        //    });
    };

    const memberPage = data => {
        $("#mainContent").empty();
        $("#mainContent").html(data);

        $(document).on("click", "#mobileSide", () => {
            $("#memberMenu").addClass("active");
        });

        $("#btnMenuClose").on("click", () => {
            $("#memberMenu").removeClass("active");
        });
    };

    const memberComponent = data => {
        $("#memberPanel").empty();
        $("#memberPanel").html(data);

        $(document).on("click", "#mobileSide", () => {
            $("#memberMenu").addClass("active");
        });

        $("#btnMenuClose").on("click", () => {
            $("#memberMenu").removeClass("active");
        });

        $("#Birthday").datetimepicker(opt1);
        $("#sDateO").datetimepicker(opt1);
        $("#eDateO").datetimepicker(opt1);
    };

    const joinusPage = (data) => {
        $("#mainContent").empty();
        $("#mainContent").html(data);
        //alert($('#Birthday').val());
        $("#Birthday").datetimepicker(opt1);

        // 收合MENU選單
        $('.header-box').find('.navbar-toggler').addClass('collapsed');
        $('#menuNavbar').removeClass('show');

        $(document).on("click", "#mobileSide", () => {
            $("#helpMenu").addClass("active");
        });

        $("#btnMenuClose").on("click", () => {
            $("#helpMenu").removeClass("active");
        });
    };

    const joinusComponent = data => {
        $("#helpPanel").empty();
        $("#helpPanel").html(data);

        $(document).on("click", "#mobileSide", () => {
            $("#helpMenu").addClass("active");
        });

        $("#btnMenuClose").on("click", () => {
            $("#helpMenu").removeClass("active");
        });
    };

    // 1.使用者在購物車子系統點按登入。
    $("#btnLogin").on("click", () => {
        // 2.系統呼叫Controller Action【Home/Login】。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: homeLoginUrl,
        })
            .done(loginPage)
            .fail(systemError);
    });

    // MENU
    $("#navMenu")
        .find(".nav-link")
        .on("click", event => {
            const selectNav = $(event.currentTarget).data("nav");

            $("#navMenu")
                .find(".nav-link")
                .removeClass("active");
            $("#menuNavbar").removeClass("show");

            switch (selectNav) {
                case "home":
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: homeMainUrl,
                    })
                        .done(homePage)
                        .fail(systemError);
                    $(event.currentTarget).addClass("active");
                    break;
                case "mall":
                    //1.使用者在購物車子系統首頁點按[商城]。
                    // 2.系統呼叫Get Controller Action【Mall/Index】。
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        data: { MemberLevelId: jMemberlevelId },
                        url: mallUrl
                    })
                        .done(mallPage)
                        .fail(systemError);
                    $(event.currentTarget).addClass("active");
                    break;
                case "cart":
                    // 1.使用者在購物車子系統首頁點按[購物車]。
                    // 2.系統判斷jMemberMobile!=""。
                    // 3.系統以ajax呼叫Get Controller Action【Cart/Index】並傳送jMemberMobile與carts。
                    $.ajax({
                        type: "POST",
                        cache: false,
                        dataType: "HTML",
                        url: cartUrl,
                        data: {
                            MemberMobile: jMemberMobile,
                            Carts: carts
                        }
                    })
                        .done(cartPage)
                        .fail(systemError);
                    $(event.currentTarget).addClass("active");
                    break;
                case "member":
                    if (jMemberMobile != "") {
                        $.ajax({
                            type: "GET",
                            cache: false,
                            dataType: "HTML",
                            url: memberUrl
                        })
                            .done(memberPage)
                            .fail(systemError);

                        $(event.currentTarget).addClass("active");
                    } else {
                        alert("請先登入！");
                    }
                    break;
                case "joinus":
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: joinusUrl
                    })
                        .done(joinusPage)
                        .fail(systemError);

                    $(event.currentTarget).addClass("active");
                    break;
                default:
            }
        });

    $(document).on(
        "click",
        "#memberMenu > .nav > .nav-item > .nav-link",
        event => {
            const selectMember = $(event.currentTarget).data("member");

            $("#memberMenu")
                .find(".nav-link")
                .removeClass("active");

            $(event.currentTarget).addClass("active");

            $("#memberMenu").removeClass("active");

            switch (selectMember) {
                case "mail":
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: memberMailcenterUrl,
                        data: {
                            MemberMobile: jMemberMobile,
                        MemberLevelId: jMemberlevelId}
                    })
                        .done(memberComponent)
                        .fail(systemError);

                    break;
                case "data":
                    //1.使用者在購物車子系統首頁點按[會員中心/我的會員資料]。
                    // 2.系統以ajax呼叫Controller Action【Member/Personaldata】，並傳送jMemberMobile。
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: memberPersonaldataUrl,
                        data: { MemberMobile: jMemberMobile }
                    })
                        .done(memberComponent)
                        .fail(systemError);
                    break;
                case "level":
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: memberMemberlevelUrl
                    })
                        .done(memberComponent)
                        .fail(systemError);
                    //$('#Birthday').datetimepicker(opt1);
                    break;
                case "wholesale":
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: memberWholesaletipsUrl
                    })
                        .done(memberComponent)
                        .fail(systemError);

                    break;
                case "ship":
                    // 1.登入之會員點按[會員中心-送貨地址]。
                    // 2.系統以ajax呼叫Get Controller Action【Member/MyOrder】，並傳送jMemberMobile。
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: memberShipaddressUrl,
                        data: { MemberMobile: jMemberMobile }
                    })
                        .done(memberComponent)
                        .fail(systemError);

                    break;
                case "order":
                    // 1.登入之會員點按[會員中心-我的訂單]。
                    // 2.系統以ajax呼叫Get Controller Action【Member/MyOrder】，並傳送jMemberMobile。
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: memberMyorderUrl,
                        data: { MemberMobile: jMemberMobile }
                    })
                        .done(memberComponent)
                        .fail(systemError);

                    break;
                case "favorite":
                    // 1.登入之會員點按[會員中心-我的最愛]。
                    // 2.系統以ajax呼叫Get Controller Action【Member/Myfavorite】，並傳送jMemberMobile。
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: memberMyfavoriteUrl,
                        data: { MemberMobile: jMemberMobile }
                    })
                        .done(memberComponent)
                        .fail(systemError);
                    break;
                case "orderbonus":
                    // 1.登入之會員點按[會員中心-我的紅利]。
                    // 2.系統以ajax呼叫Get Controller Action【Member/MyOrderBonus】，並傳送jMemberMobile。
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: memberMyOrderBonusUrl,
                        data: { MemberMobile: jMemberMobile }
                    })
                        .done(memberComponent)
                        .fail(systemError);
                    break;
                case "follower":
                    //20181119 ---棋
                    //1.登入之會員點按[會員中心 - 我的下線]。
                    //2.系統以ajax呼叫Get Controller Action【Member / Myfollower】，並傳送jMemberMobile。
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: memberMyfollowerUrl,
                        data: { MemberMobile: jMemberMobile }
                    })
                        .done(memberComponent)
                        .fail(systemError);

                    break;
                case "triymph":
                    //20181121 ---棋
                    //1.登入之會員點按[會員中心 - 我的下線業績]。
                    //2.系統以ajax呼叫Get Controller Action【Member / Followertriumph】，並傳送jMemberMobile。
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: memberFollowertriumphUrl,
                        data: { MemberMobile: jMemberMobile }
                    })
                        .done(memberComponent)
                        .fail(systemError);

                    break;
                case "point":
                    //20181215 ---棋
                    //1.登入之會員點按[會員中心 - 點數異動記錄]。
                    //2.系統以ajax呼叫Get Controller Action【Member / Pointnotes】，並傳送jMemberMobile。
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: memberPointnotesUrl,
                        data: { MemberMobile: jMemberMobile }
                    })
                        .done(memberComponent)
                        .fail(systemError);

                    break;
                case "membermove":
                    //2018 ---棋
                    //1.登入之會員點按[會員中心 - 會員調撥區]。
                    //2.系統以ajax呼叫Get Controller Action【Member / Membermove】，並傳送jMemberMobile。
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: memberMembermoveUrl
                    })
                        .done(memberComponent)
                        .fail(systemError);

                    break;
                case "wishipool":
                    //20181121 ---棋
                    //1.登入之會員點按[會員中心 - 許願池]。
                    //2.系統以ajax呼叫Get Controller Action【Member / Wishipool】，並傳送jMemberMobile。
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: memberWishipoolUrl
                    })
                        .done(memberComponent)
                        .fail(systemError);

                    break;
                default:
                    //20181121 ---棋
                    //1.登入之會員點按[會員中心 - 訊息中心]。
                    //2.系統以ajax呼叫Get Controller Action【Member / Mailcenter】，並傳送jMemberMobile。
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: memberMailcenterUrl,
                        data: { MemberMobile: jMemberMobile }
                    })
                        .done(memberComponent)
                        .fail(systemError);
            }
        }
    );

    $(document).on(
        "click",
        "#helpMenu > .nav > .nav-item > .nav-link",
        event => {
            const selectHelp = $(event.currentTarget).data("help");

            $("#helpMenu")
                .find(".nav-link")
                .removeClass("active");

            $(event.currentTarget).addClass("active");

            $("#helpMenu").removeClass("active");

            switch (selectHelp) {
                case "register":
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: joinusRegisterUrl
                    })
                        //20181225 --棋
                        .done(joinusComponent)
                        .fail(systemError);

                    break;
                case "shoppingflow":
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: joinusShoppingflowUrl
                    })
                        .done(joinusComponent)
                        .fail(systemError);

                    break;
                case "payway":
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: joinusPaywayUrl
                    })
                        .done(joinusComponent)
                        .fail(systemError);

                    break;
                case "qanda":
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: joinusQandaUrl
                    })
                        .done(joinusComponent)
                        .fail(systemError);

                    break;
                case "shipdays":
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: joinusShipdaysUrl
                    })
                        .done(joinusComponent)
                        .fail(systemError);

                    break;
                default:
                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: joinusRegisterUrl
                    })
                        .done(joinusComponent)
                        .fail(systemError);
            }
        }
    );

    /* eslint-disable */
    swiper = new Swiper(".swiper-container", {
        autoHeight: true,
        slidesPerView: 3,
        centeredSlides: true,
        spaceBetween: 30,
        loop: true,
        autoplay: {
            delay: 2500,
            disableOnInteraction: false
        },
        pagination: {
            el: ".swiper-pagination",
            clickable: true
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev"
        }
    });
    /* eslint-enable */

    // 加入我們圖片
    $("#linkJoinUs").on("click", () => {
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: joinusUrl
        })
            .done(joinusPage)
            .fail(systemError);

        $("#navMenu")
            .find(".nav-link")
            .removeClass("active");

        $("#navMenu")
            .find('.nav-link[data-nav="joinus"]')
            .addClass("active");
    });

    $("#productDetail").height(windowInnerHeight);
    $("#favoriteDetail").height(windowInnerHeight);
    // 1.使用者在[商城]之商品清單區單按下一頁/前一頁/某一頁連結。
    $(document).on("click", "#btnNextPage", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage + 1 > jTotallPages) {
            alert("己到最後一頁");
            return;
        }
        // 3.系統將jCurrentPage+1。
        jCurrentPage += 1;
        // 4.系統呼叫Get Controller Action【Mall/GetProductList】，並傳送ProductCategoryId與ProductCategory以及jCurrentPage、jProduct、jlowPrice、jhightPrice。
        //jProductCategoryId = $(event.currentTarget).data("productcategoryid");
        jProductCategory = $("#spanProductCategory").text();
        $.ajax({
            type: "Post",
            cache: false,
            dataType: "HTML",
            url: GetProductListUrl,
            data: {
                ProductCategoryId: jProductCategoryId,
                ProductCategory: jProductCategory,
                Product: jProduct,
                lowPrice: jlowPrice,
                jhightPrice: jhightPrice,
                Page: jCurrentPage,
                MemberLevelId: jMemberlevelId
            }
        })
            .done(GetProductListSuccess)
            .fail(systemError);
    });
    // 1.使用者在[商城]之商品清單區單按下一頁/前一頁/某一頁連結。
    $(document).on("click", "#btnPrePage", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage - 1 < 1) {
            alert("己到第一頁");
            return;
        }
        // 3.系統將jCurrentPage-1。
        jCurrentPage -= 1;
        // 4.系統呼叫Get Controller Action【Mall/GetProductList】，並傳送ProductCategoryId與ProductCategory以及jCurrentPage、jProduct、jlowPrice、jhightPrice。
        //jProductCategoryId = $(event.currentTarget).data("productcategoryid");
        jProductCategory = $("#spanProductCategory").text();
        $.ajax({
            type: "Post",
            cache: false,
            dataType: "HTML",
            url: GetProductListUrl,
            data: {
                ProductCategoryId: jProductCategoryId,
                ProductCategory: jProductCategory,
                Product: jProduct,
                lowPrice: jlowPrice,
                jhightPrice: jhightPrice,
                Page: jCurrentPage,
                MemberLevelId: jMemberlevelId
            }
        })
            .done(GetProductListSuccess)
            .fail(systemError);
    });
    // 1.使用者在[商城]之商品清單區單按下一頁/前一頁/某一頁連結。
    $(document).on("click", "#PageList > .dropdown-item", event => {
        event.preventDefault();
        //// 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        //if (jCurrentPage - 1 < 1) {
        //    alert("己到第一頁");
        //    return;
        //}
        //// 3.系統將jCurrentPage-1。
        //jCurrentPage -= 1;
        // 4.系統呼叫Get Controller Action【Mall/GetProductList】，並傳送ProductCategoryId與ProductCategory以及jCurrentPage、jProduct、jlowPrice、jhightPrice。
        jCurrentPage = $(event.currentTarget).data("page");
        jProductCategory = $("#spanProductCategory").text();
        $.ajax({
            type: "Post",
            cache: false,
            dataType: "HTML",
            url: GetProductListUrl,
            data: {
                ProductCategoryId: jProductCategoryId,
                ProductCategory: jProductCategory,
                Product: jProduct,
                lowPrice: jlowPrice,
                jhightPrice: jhightPrice,
                Page: jCurrentPage,
                MemberLevelId: jMemberlevelId
            }
        })
            .done(GetProductListSuccess)
            .fail(systemError);
    });

    // 1.使用者在[商城]之商品清單區輸入商品名稱/最低定價/最高定價並點按搜尋商品。
    $(document).on("click", "#btnSerachProduct", event => {
        event.preventDefault();
        // 2.系統設定jProduct/jlowPrice/jhightPrice為1輸入條件。
        jProduct = $("#Product").val();
        if ($("#lowPrice").val() === "" || $("#lowPrice").val() === null) {
            jlowPrice = 0;
        } else {
            jlowPrice = $("#lowPrice").val();
        }
        if ($("#hightPrice").val() === "" || $("#hightPrice").val() === null) {
            jhightPrice = 1000000;
        } else {
            jhightPrice = $("#hightPrice").val();
        }
        // 3.系統將jCurrentPage設為1。
        jCurrentPage = 1;
        // 4.系統呼叫Get Controller Action【Mall/GetProductList】，並傳送ProductCategoryId與ProductCategory以及jCurrentPage、jProduct、jlowPrice、jhightPrice。
        jCurrentPage = $(event.currentTarget).data("page");
        jProductCategory = $("#spanProductCategory").text();
        $.ajax({
            type: "Post",
            cache: false,
            dataType: "HTML",
            url: GetProductListUrl,
            data: {
                ProductCategoryId: jProductCategoryId,
                ProductCategory: jProductCategory,
                Product: jProduct,
                lowPrice: jlowPrice,
                hightPrice: jhightPrice,
                MemberLevelId: jMemberlevelId,
                Page: jCurrentPage
            }
        })
            .done(GetProductListSuccess)
            .fail(systemError);
    });

    const GetProductListSuccess = response => {
        // 10.系統在2啟動之ajax回呼函式中更新<Div id="productPanel">的內容為9-7傳回值。
        // 11.系統在6啟動之ajax回呼函式中更新<Div id="productPanel">的內容為9-7傳回值。
        $("#productPanel").html(response);
        if (jMemberlevelId !== 2) {
            $("#btnOfferProduct").hide();
            $("#btnAllProduct").hide();
        } else {
            $("#btnOfferProduct").show();
            $("#btnAllProduct").show();
        }
        //設定列表商品圖片的寬高
        const imgWidth = $(".productlist-item .product-pic").width();
        $(".productlist-item .product-pic").height(imgWidth);
        // 收合類別選單面板
        $("#ProductLevelPath").removeClass("active");
        // 11.結束。
    };

    const GetProductLevelPathSuccess = response => {
        // 5.系統在2啟動之ajax回呼函式中更新<Div id="ProductLevelPath">的內容為8-3傳回值。
        // 9.系統在7啟動之ajax回呼函式中更新<Div id="ProductLevelPath">的內容為8-3傳回值。
        $("#ProductLevelPath").html(response);
        // 6.系統在2啟動之ajax回呼函式中呼叫Get Controller Action【Mall/GetProductList】，並傳送ProductCategoryId與ProductCategory以及jCurrentPage、jProduct、jlowPrice、jhightPrice。
        // 10.系統在7啟動之ajax回呼函式中呼叫Get Controller Action【Mall/GetProductList】，並傳送jProductCategoryId與jProductCategory以及jCurrentPage、jProduct、jlowPrice、jhightPrice。
        $.ajax({
            type: "Post",
            cache: false,
            async: false,
            dataType: "HTML",
            url: GetProductListUrl,
            data: {
                ProductCategoryId: jProductCategoryId,
                ProductCategory: jProductCategory,
                Product: jProduct,
                lowPrice: jlowPrice,
                hightPrice: jhightPrice,
                Page: jCurrentPage,
                MemberLevelId: jMemberlevelId
            }
        })
            .done(GetProductListSuccess)
            .fail(systemError);
        // 11.結束。
    };

    // 1.使用者在[商城]之分類區單按子分類清單中的某個分類。
    // 1.使用者在[商城]之分類區雙按子分類清單中的某個分類，或點按分類階層清單中的某個分類。
    let timer = 0;
    let delay = 200;
    let prevent = false;
    let $target;
    $(document)
        .on(
            "click",
            "#ProductCategoryList > .nav > .nav-item > .nav-link",
            event => {
                event.preventDefault();
                $target = $(event.currentTarget);
                timer = setTimeout(function () {
                    if (!prevent) {
                        //alert("click");
                        // 2.系統呼叫Get Controller Action【Mall/GetProductList】，並傳送1點按之ProductCategoryId與ProductCategory。
                        jProductCategoryId = $target.data("productcategoryid");
                        jProductCategory = $target.text();
                        $.ajax({
                            type: "Post",
                            cache: false,
                            dataType: "HTML",
                            url: GetProductListUrl,
                            data: {
                                ProductCategoryId: jProductCategoryId,
                                ProductCategory: jProductCategory,
                                MemberLevelId: jMemberlevelId
                            }
                        })
                            .done(GetProductListSuccess)
                            .fail(systemError);
                    }
                    prevent = false;
                }, delay);
            }
        )
        .on(
            "dblclick",
            "#ProductCategoryList > .nav > .nav-item > .nav-link",
            event => {
                event.preventDefault();
                $target = $(event.currentTarget);
                prevent = true;
                // 1-1.系統將1點按之分類代碼與分類別名分別指定給jProductCategoryId，jProductCategory，jProduct=""，jlowPrice=0，jhightPrice=1000000、jCurrentPage=1。
                jProductCategoryId = $target.data("productcategoryid");
                jProductCategory = $target.text();
                jProduct = "";
                jlowPrice = 0;
                jhightPrice = 1000000;
                jCurrentPage = 1;
                // 2.系統呼叫Get Controller Action【Mall/GetProductLevelPath】，並傳送1點按之ProductCategoryId。
                $.ajax({
                    type: "Post",
                    cache: false,
                    async: false,
                    dataType: "HTML",
                    url: GetProductLevelPathUrl,
                    data: {
                        ProductCategoryId: jProductCategoryId
                    }
                })
                    .done(GetProductLevelPathSuccess)
                    .fail(systemError);
            }
        );
    // 手機版方便取代雙按子類別
    $(document)
        .on(
            "click",
            "#btnSubCategory",
            event => {
                jProduct = "";
                jlowPrice = 0;
                jhightPrice = 1000000;
                jCurrentPage = 1;
                // 2.系統呼叫Get Controller Action【Mall/GetProductLevelPath】，並傳送1點按之ProductCategoryId。
                $.ajax({
                    type: "Post",
                    cache: false,
                    async: false,
                    dataType: "HTML",
                    url: GetProductLevelPathUrl,
                    data: {
                        ProductCategoryId: jProductCategoryId
                    }
                })
                    .done(GetProductLevelPathSuccess)
                    .fail(systemError);
            }
        );
    // 1.使用者在[商城]之分類區輸入分類名稱，然後點按搜尋。
    $(document).on("click", "#btnSeatchProductCategory", event => {
        event.preventDefault();
        // 2.系統呼叫Get Controller Action【Mall/GetProductCategoryId】，並傳送1輸入分類名稱。
        if (
            $("#ProductCategory").val() === "" ||
            $("#ProductCategory").val() === null
        ) {
            alert("請輸入分類名稱！");
            return;
        }
        jProductCategory = $("#ProductCategory").val();
        $.ajax({
            type: "Post",
            cache: false,
            url: GetProductCategoryIdUrl,
            data: {
                ProductCategory: jProductCategory
            }
        })
            .done(GetProductCategoryIdSuccess)
            .fail(systemError);
    });

    const GetProductCategoryIdSuccess = response => {
        // 5.系統在2啟動之ajax回呼函式中判斷4傳回值>0。
        if (response <= 0) {
            // 5a.系統在2啟動之ajax回呼函式中判斷4傳回值==0。
            //  5a-1.系統顯示"查無此分類！"。
            alert("查無此分類！");
            return;
        }
        // 6.系統將4傳回值指定給jProductCategoryId，再將jProduct=""，jlowPrice=0，jhightPrice=1000000、jCurrentPage=1。
        jProductCategoryId = response;
        jlowPrice = 0;
        jhightPrice = 1000000;
        jCurrentPage = 1;
        // 7.系統以ajax呼叫Get Controller Action【Mall/GetProductLevelPath】，並傳送ProductCategoryId。
        $.ajax({
            type: "Post",
            cache: false,
            async: false,
            dataType: "HTML",
            url: GetProductLevelPathUrl,
            data: {
                ProductCategoryId: jProductCategoryId
            }
        })
            .done(GetProductLevelPathSuccess)
            .fail(systemError);
        // 11.結束。
    };

    // 1.使用者在[商城]之分類區雙按子分類清單中的某個分類，或點按分類階層清單中的某個分類。
    $(document).on("click", "#ProductCategoryLevel > .breadcrumb-item > .ProductLevelPathList", event => {
        $target = $(event.currentTarget);
        event.preventDefault();
        // 1-1.系統將1點按之分類代碼與分類別名分別指定給jProductCategoryId，jProductCategory，jProduct=""，jlowPrice=0，jhightPrice=1000000、jCurrentPage=1。
        jProductCategoryId = $target.data("productcategoryid");
        jProductCategory = $target.text();
        jProduct = "";
        jlowPrice = 0;
        jhightPrice = 1000000;
        jCurrentPage = 1;
        // 2.系統呼叫Get Controller Action【Mall/GetProductLevelPath】，並傳送1點按之ProductCategoryId。
        $.ajax({
            type: "Post",
            cache: false,
            async: false,
            dataType: "HTML",
            url: GetProductLevelPathUrl,
            data: {
                ProductCategoryId: jProductCategoryId
            }
        })
            .done(GetProductLevelPathSuccess)
            .fail(systemError);
    });
    // 1.使用者點按商品首頁中的價惠商品按鈕。
    $(document).on("click", "#btnOfferProduct", event => {
        event.preventDefault();
        // 2.系統呼叫Get Controller Action【Mall/GetOfferProductList】。
        $.ajax({
            type: "Post",
            cache: false,
            dataType: "HTML",
            url: GetOfferProductListUrl
        })
            .done(GetProductListSuccess)
            .fail(systemError);
    });
    // 1.使用者在[商城]之分類區單按子分類清單中的某個分類。
    $(document).on("click", "#btnAllProduct", event => {
        // 2.系統呼叫Get Controller Action【Mall/GetProductList】，並傳送1點按之ProductCategoryId與ProductCategory。
        $.ajax({
            type: "Post",
            cache: false,
            dataType: "HTML",
            url: GetProductListUrl,
            data: {
                ProductCategoryId: jProductCategoryId,
                ProductCategory: jProductCategory,
                MemberLevelId: jMemberlevelId
            }
        })
            .done(GetProductListSuccess)
            .fail(systemError);
    });
    //20181123 --棋
    // 6.使用者按加入一般會員。
    $(document).on("click", "#btnJoinMember", function () {
        //20181228 ---棋
        var StatusCode = 0;
        // 7.系統驗証5輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            MemberMobile: $("#MemberMobile").val(),
            Password: $("#Password").val(),
            MemberName: $("#MemberName").val(),
            NickName: $("#NickName").val(),
            sex: $("#sex").val(),
            //Birthday: $("#Birthday").val(),
            eMail: $("#eMail").val(),
            //Phone: $("#Phone").val(),
            ContactAddress: $("#ContactAddress").val(),
            //ID: $("#ID").val(),
            //Bank: $("#Bank").val(),
            //Branch: $("#Branch").val(),
            //AccountNunber: $("#AccountNunber").val(),
            //AccountName: $("#AccountName").val()
        };
        var msgObj = {
            MemberMobile: "手機(帳號)必填！",
            Password: "密碼必填！",
            MemberName: "姓名必填！",
            NickName: "暱稱必填！",
            sex: "性別必填！",
            //Birthday: "生日必填！",
            eMail: "eMail必填！",
            //Phone: "住家/公司電話必填！",
            ContactAddress: "聯絡地址必填！",
            //ID: "身份證/統一編號必填！",
            //Bank: "銀行必填！",
            //Branch: "分行必填！",
            //AccountNunber: "帳號必填！",
            //AccountName: "帳戶名稱必填！"
        };
        $.each(checkObj, function (name, jobj) {
            if (jobj === "" || jobj === null) {
                status = false;
                error += msgObj[name] + "\r\n";
            }
        });
        if ($("#Password").val() !== $("#ConfirmPassword").val()) {
            error += "確認密碼必須和密碼相同！" + "\r\n";
        }
        if (!status) {
            // 驗証失敗
            alert(error);
            return;
        }
        // 資料格式驗証
        status = true;
        error = "";
        // 手機
        if (!checkMobil($("#MemberMobile").val())) {
            status = false;
            error += "手機格式不正確！" + "\r\n";
        }
        // eMail
        if (!checkeMail($("#eMail").val())) {
            status = false;
            error += "eMail格式不正確！" + "\r\n";
        }
        if (!status) {
            // 驗証失敗
            alert(error);
            return;
        }

        $("#refbutton").click();
        $("#ref_confirm_button").on("click", function () {
            //系統確認是否勾選同意
            if ($("#checkboxOK").prop('checked') == false) {
                alert('請勾選"已閱讀"');
                return;
            }
            //系統關閉modal視窗
            $("#modalOff").click();
            // 8.系統以ajax呼叫Post Action【Joinus/JoinMember】，並傳送5輸入資料。
            if (StatusCode == 0) {
                $.ajax({
                    type: "Post",
                    async: false,
                    cache: false,
                    dataType: 'json',
                    url: JoinMemberUrl,
                    data: {
                        MemberMobile: $("#MemberMobile").val(),
                        Password: $("#Password").val(),
                        MemberName: $("#MemberName").val(),
                        NickName: $("#NickName").val(),
                        sex: $("#sex").val(),
                        //Birthday: $("#Birthday").val(),
                        eMail: $("#eMail").val(),
                        //LineId: $("#LineId").val(),
                        //Phone: $("#Phone").val(),
                        ContactAddress: $("#ContactAddress").val(),
                        //ID: $("#ID").val(),
                        //Bank: $("#Bank").val(),
                        //Branch: $("#Branch").val(),
                        //AccountNunber: $("#AccountNunber").val(),
                        //AccountName: $("#AccountName").val()
                    }
                })
                    .done(response => {
                        StatusCode++;
                        if (response.ret === 0) {
                            alert("加入成功！");
                            //20181215更新  ---棋
                            //彈出驗證手機簡訊Model
                            $('#exampleModalPhone').modal({ backdrop: "static" });
                        } else if (response.ret === 2) {
                            alert("手機(帳號) 重覆！");
                        } else if (response.ret === 3) {
                            alert("暱稱 重覆!");
                        } else {
                            alert("執行失敗，請稍後再試！");
                        }
                    })
                    .fail(systemError)
            }
        });
    });
    //20181216 --棋
    // 6.使用者加入一般會員後驗證手機簡訊。
    $(document).on("click", "#MemberVerification", event => {
        $.ajax({
            type: "Post",
            cache: false,
            dataType: 'json',
            url: MemberVerification,
            data: {
                MemberMobile: $('#MemberMobile').val(),
                ValidateCode: $("#MobileVerification").val(),
            }
        })
            .done(success)
            .fail(systemError)

        function success(response) {
            if (response === 0) {
                alert("驗證成功");
                //重導回首頁重新登入
                location.reload();
            }
            response === -1 ? (alert("系統錯誤")) : ("");
            response === -2 ? (alert("驗證碼錯誤 !")) : ("");
            response === -3 ? (alert("驗證碼逾期，請重新申請 !")) : ("");
            response === -4 ? (alert("已驗證過，請直接登入 !")) : ("");
        }
    });

    // 6.使用者按登入。
    $(document).on("click", "#btnLoginMember", event => {
        // 7.系統驗証資料輸入無誤(參考流程5)。
        var status = true,
            error = "";
        var checkObj = {
            MemberMobileLogin: $("#MemberMobileLogin").val(),
            MemberPasswordLogin: $("#MemberPasswordLogin").val()
        };
        var msgObj = {
            MemberMobileLogin: "帳號(手機)必填！",
            MemberPasswordLogin: "密碼必填！"
        };

        $.each(checkObj, function (name, jobj) {
            if (jobj === "" || jobj === null) {
                status = false;
                error += msgObj[name] + "\r\n";
            }
        });

        if ($("#Password").val() !== $("#ConfirmPassword").val()) {
            error += "確認密碼必須和密碼相同！" + "\r\n";
        }

        if (!status) {
            // 驗証失敗
            alert(error);
            return;
        }

        //var Recaptcha = grecaptcha.getResponse()

        $('#Memberlogin').ajaxSubmit({
            dataType: "json",
            success: success,
            error: systemError
        });

        // 8.系統以ajax呼叫POST【Home/Login】，並傳送5輸入的資料。
        //$.ajax({
        //    type: "Post",
        //    cache: false,
        //    async: false,
        //    url: LoginUrl,
        //    data: {
        //        MemberMobile: $("#MemberMobileLogin").val(),
        //        MemberPassword: $("#MemberPasswordLogin").val(),
        //        //20181224 ---棋
        //        Recaptcha: Recaptcha,
        //    },
        //})
        function success(response) {
            //console.log(response);
            if (response.result === 0) {
                // 14.系在7啟動之ajax回呼函式中判斷12回傳之result===0。
                // 15.系統將11回傳之memberoobile指定給jMemberMobile，memberlevel指定給jMemberlevelId。
                jMemberMobile = response.memberoobile;
                jMemberlevelId = response.memberlevelId;
                jNickName = response.nickName;
                $("#nickname").text(jNickName);
                $("#btnLogin").hide();
                //20181206更新 ---棋
                //1.在登入狀態下是否不須有[註冊]、[加入會員]按鈕，待為非登入狀態時再行顯示
                $("#e-b").hide();
                $("#btnRegister").hide();
                $("#btnLogout").show();
                //把_NavbarPartial內購物車 / 會員中心
                $("#c-b").attr("style", "display:block");
                $("#d-b").attr("style", "display:block");
                //20181219 ---棋
                //顯示該會員未讀訊息比數
                response.mailCount != 0 ? ($('#MailCenterUnReadCount').text(response.mailCount)) : ("");
                //20181226 ---棋
                //顯示_FooterPartial 會員中心.購物車
                $('.footer-box').find('.nav-link').eq(1).css('display', 'block');
                $('.footer-box').find('.nav-link').eq(5).css('display', 'block');
                // 16.系統切換到會員中心。
                $.ajax({
                    type: "GET",
                    cache: false,
                    dataType: "HTML",
                    url: memberUrl
                })
                    .done(memberPage)
                    .fail(systemError);
                $("#navMenu")
                    .find(".nav-link")
                    .removeClass("active");
                $("#MemberCenter").addClass("active");
            }
            else if (response.result === 2) {
                // 14a.系在7啟動之ajax回呼函式中判斷12回傳之result===2。
                //  14b-1.系統顯示"帳號錯誤"。
                alert("帳號錯誤！");
            }
            else if (response.result === 3) {
                // 14b.系在7啟動之ajax回呼函式中判斷12回傳之result===3。
                //  14b-1.系統顯示"密碼錯誤"。
                alert("密碼錯誤！");
            }
            else if (response.result === 4) {
                // 14c.系在7啟動之ajax回呼函式中判斷12回傳之result===4。
                //  14c-1.系統顯示"停權中"。
                alert("停權中！");
            }
            else if (response.result === 5) {
                // 14c.系在7啟動之ajax回呼函式中判斷12回傳之result===4。
                //  14c-1.系統顯示"停權中"。
                alert(`請勾選 "我不是機器人" ！`);
            }
            else if (response.result === 6) {
                // 14c.系在7啟動之ajax回呼函式中判斷12回傳之result===4。
                //  14c-1.系統顯示"停權中"。
                alert("尚未取得手機認證 ！");
            }
            else {
                // 14c.系在7啟動之ajax回呼函式中判斷12回傳之result!==0/2/3/4。
                // 14c-1.系統顯示"執行失敗，請再試一次！"。
                alert("執行失敗，請再試一次！");
            }
        }
    });
    // 6.使用者按更新會員資料。
    $(document).on("click", "#btnUpdateMember", event => {
        // 7.系統驗証5輸入資料無誤。
        var status = true,
            error = "";
        var checkObj = {
            MemberMobile: $("#MemberMobile").val(),
            Password: $("#Password").val(),
            MemberName: $("#MemberName").val(),
            NickName: $("#NickName").val(),
            sex: $("#sex").val(),
            //Birthday: $("#Birthday").val(),
            eMail: $("#eMail").val(),
            //Phone: $("#Phone").val(),
            ContactAddress: $("#ContactAddress").val()
            //ID: $("#ID").val(),
            //Bank: $("#Bank").val(),
            //Branch: $("#Branch").val(),
            //AccountNunber: $("#AccountNunber").val(),
            //AccountName: $("#AccountName").val()
        };
        var msgObj = {
            MemberMobile: "手機(帳號)必填！",
            Password: "密碼必填！",
            MemberName: "姓名必填！",
            NickName: "暱稱必填！",
            sex: "性別必填！",
            //Birthday: "生日必填！",
            eMail: "eMail必填！",
            //Phone: "住家/公司電話必填！",
            ContactAddress: "聯絡地址必填！"
            //ID: "身份證/統一編號必填！",
            //Bank: "銀行必填！",
            //Branch: "分行必填！",
            //AccountNunber: "帳號必填！",
            //AccountName: "帳戶名稱必填！"
        };

        $.each(checkObj, function (name, jobj) {
            if (jobj === "" || jobj === null) {
                status = false;
                error += msgObj[name] + "\r\n";
            }
        });

        if (!status) {
            // 驗証失敗
            alert(error);
            return;
        }
        // 資料格式驗証
        status = true;
        error = "";
        // 手機
        if (!checkMobil($("#MemberMobile").val())) {
            status = false;
            error += "手機格式不正確！" + "\r\n";
        }
        // eMail
        if (!checkeMail($("#eMail").val())) {
            status = false;
            error += "eMail格式不正確！" + "\r\n";
        }
        if (!status) {
            // 驗証失敗
            alert(error);
            return;
        }

        // 8.系統以ajax呼叫Post Action【Member/PutMember】，並傳送5輸入資料。
        $.ajax({
            type: "Post",
            cache: false,
            url: PutMemberUrl,
            data: {
                MemberMobile: $("#MemberMobile").val(),
                MemberName: $("#MemberName").val(),
                NickName: $("#NickName").val(),
                sex: $("#sex").val(),
                Birthday: $("#Birthday").val(),
                eMail: $("#eMail").val(),
                LineId: $("#LineId").val(),
                Phone: $("#Phone").val(),
                ContactAddress: $("#ContactAddress").val()
                //ID: $("#ID").val(),
                //Bank: $("#Bank").val(),
                //Branch: $("#Branch").val(),
                //AccountNunber: $("#AccountNunber").val(),
                //AccountName: $("#AccountName").val()
            }
        })
            .done(response => {
                if (response === 0) {
                    alert("更新 成功！");
                } else if (response === 3) {
                    alert("暱稱 重覆！");
                } else {
                    alert("執行失敗，請稍後再試！");
                }
            })
            .fail(systemError);
    });

    //20181212更新 ---棋
    // 6.使用者按升級批發會員。
    $(document).on("click", "#btnUpgradeMemberLevel", event => {
        event.preventDefault();
        //7.系統驗証5輸入資料無誤。
        if ($("#ReferrerMobile").val() === "" || $("#ReferrerMobile").val() === null) {
            if (!confirm("推薦人手機(帳號)未填，你將成為公司直屬會員，確定嗎？")) { return; }
        }
        var status = true,
            error = "";
        var checkObj = {
            ID: $("#ID").val(),
            Bank: $("#Bank").val(),
            Branch: $("#Branch").val(),
            AccountNunber: $("#AccountNunber").val(),
            AccountName: $("#AccountName").val()
        };
        var msgObj = {
            ID: "身份證/統一編號必填！",
            Bank: "銀行必填！",
            Branch: "分行必填！",
            AccountNunber: "帳號必填！",
            AccountName: "帳戶名稱必填！"
        };
        $.each(checkObj, function (name, jobj) {
            if (jobj === "" || jobj === null) {
                status = false;
                error += msgObj[name] + "\r\n";
            }
        });
        if (!status) {
            //驗証失敗
            alert(error);
            return;
        };
        //資料格式驗証
        status = true;
        error = "";
        //推薦人手機
        if ($("#ReferrerMobile").val() != null && $("#ReferrerMobile").val() != "") {
            if (!checkMobil($("#ReferrerMobile").val())) {
                status = false;
                error += "推薦手機格式不正確！" + "\r\n";
            };
        };
        // 身份字號
        if (!checkID($("#ID").val())) {
            status = false;
            error += "身份證字號格式不正確！" + "\r\n";
        };
        //銀行帳號
        if (!checkBankAccount($("#AccountNunber").val())) {
            alert($("#AccountNunber").val());
            status = false;
            error += "銀行帳號格式不正確！" + "\r\n";
        };
        if (!status) {
            //  驗証失敗
            alert(error);
            return;
        };

        if ($('#UpImgExample').val() == "" || $('#UpImgExample').val() == null) {
            alert("請上傳資料照片");
            return;
        }

        $("#refbutton").click();
        $("#ref_confirm_button").on("click", function () {
            //系統確認是否勾選同意
            if ($("#checkboxOK").prop('checked') == false) {
                alert('請勾選"已閱讀"');
                return;
            }
            //關閉Model
            $("#modalOff").click();

            $('#CreateForm').ajaxSubmit({
                dataType: "json",
                success: success,
                error: systemError
            });

            function success(response) {
                if (response === 0) {
                    // 14.系統顯示"申請升級批發會員成功，你目前為準批發會員！"。
                    //  14-1.系統將[會員等級]輸入盒更新為"準批發會員"。
                    alert("申請升級批發會員成功，你目前為準批發會員！");
                    $("#MemberLevel").val("準批發會員");
                    $("#btnUpgradeMemberLevel").hide();
                } else if (response === 2) {
                    // 13b.系統在8啟動之ajax回呼函式中判斷12傳回值==2。
                    //  13b-1.系統顯示"推薦人非本公司員工或本平台會員！"。
                    alert("推薦人非本公司員工或本平台之批發會員！");
                } else {
                    alert("執行失敗，請稍後再試！");
                }
            };
        });

        //    // 8.系統以ajax呼叫Post Action【Member/PutMemberLevel】，並傳送5輸入資料。
        //    //$.ajax({
        //    //    type: "Post",
        //    //    cache: false,
        //    //    url: PutMemberLevelUrl,
        //    //    data: {
        //    //        MemberMobile: $("#MemberMobile").val(),
        //    //        ReferrerMobile: $("#ReferrerMobile").val(),
        //    //        ID: $("#ID").val(),
        //    //        Bank: $("#Bank").val(),
        //    //        Branch: $("#Branch").val(),
        //    //        AccountNunber: $("#AccountNunber").val(),
        //    //        AccountName: $("#AccountName").val(),
        //    //        UpImgExample: UpImgExample,   //20181212上傳圖片
        //    //    }
        //    //})
        //    //    .done(response =>
        //    //    {
        //    //        if (response === 0)
        //    //        {
        //    //            // 14.系統顯示"申請升級批發會員成功，你目前為準批發會員！"。
        //    //            //  14-1.系統將[會員等級]輸入盒更新為"準批發會員"。
        //    //            alert("申請升級批發會員成功，你目前為準批發會員！");
        //    //            $("#MemberLevel").val("準批發會員");
        //    //            $("#btnUpgradeMemberLevel").hide();
        //    //        } else if (response === 2)
        //    //        {
        //    //            // 13b.系統在8啟動之ajax回呼函式中判斷12傳回值==2。
        //    //            //  13b-1.系統顯示"推薦人非本公司員工或本平台會員！"。
        //    //            alert("推薦人非本公司員工或本平台之批發會員！");
        //    //        } else
        //    //        {
        //    //            alert("執行失敗，請稍後再試！");
        //    //        }
        //    //    })
        //    //    .fail(systemError);
    });
    // 1.使用者在商城點按商品清單中的某一樣商品的[加入我的最愛]按鈕。
    $(document).on("click", ".productlist-item .btn-favorite, #divmyfavorite .btn-favorite", event => {
        event.preventDefault();
        // 2.系統判斷jMemberMobile!=""。
        if (jMemberMobile === null || jMemberMobile === "") {
            alert("請先登入！");
            return;
        }
        if (!confirm("確定加入我的最愛嗎？")) return;
        // 3.系統以ajax呼叫Post Action【Member/PostMemberFavorite】，並傳送1點按之ProductIdd與jMemberMobile。
        $.ajax({
            type: "POST",
            cache: false,
            url: PostMemberFavoriteUrl,
            data: {
                ProductId: $(event.currentTarget).data("productid"),
                MemberMobile: jMemberMobile
            }
        })
            .done(response => {
                if (response === 0) {
                    // 13.系統在3啟動之ajax回呼函式中判斷6傳回值==0。
                    //  13-1.系統顯示"加入我的最愛成功！"。
                    alert("加入我的最愛成功！");
                } else if (response === 2) {
                    // 12a.系統在3啟動之ajax回呼函式中判斷6傳回值==2。
                    //  12a-1.系統顯示"產品先前己加入！"。
                    alert("產品先前己加入！");
                } else {
                    alert("執行失敗，請稍後再試！");
                }
            })
            .fail(systemError);
    });
    // 1.使用者在商品詳細資料頁面點選[尺寸/顏色]。
    $(document).on("change", "#sizeD, #colorD", event => {
        event.preventDefault();
        // 2.系統以ajax呼叫Get Action【Mall/GetProductStock】，並傳送1點按之SizeId與ColorId，以及jProductId。
        $.ajax({
            type: "Get",
            cache: false,
            url: GetProductStockUrl,
            data: {
                ProductId: jProductId,
                SizeId: $("#sizeD option:selected").val(),
                ColorId: $("#colorD option:selected").val()
            }
        })
            .done(response => {
                // 6.系統在2啟動之ajax回呼函式中將5傳回值指定給jQuantity，
                //  並顯示在 <label id = ""lblQuantityD""> 數量(@stock) 。
                jQuantity = response;
                $("#lblQuantityD").text("數量" + "(" + response + ")");
            })
            .fail(systemError);
    });

    //20181227更新 ---棋
    // 1.使用者在商品詳細資料頁面輸入尺寸/顏色/數量，然後點按[新增]按鈕。
    $(document).on("click", "#btnAddQuantity", event => {
        event.preventDefault();
        // 2.系統驗証資料輸入無誤。
        var status = true,
            error = "";
        var checkObj = {
            Quantity: $("#quantityD").val(),
            SizeId: $("#sizeD option:selected").val(),
            ColorId: $("#colorD option:selected").val()
        };
        var msgObj = {
            Quantity: "數量必填！",
            SizeId: "尺寸必填！",
            ColorId: "顏色必填！"
        };
        $.each(checkObj, function (name, jobj) {
            if (jobj === "" || jobj === null) {
                status = false;
                error += msgObj[name] + "\r\n";
            }
        });
        if ($("#quantityD").val() > jQuantity) {
            status = false;
            error += "庫存不足！";
        }
        if (!status) {
            // 驗証失敗
            alert(error);
            return;
        }
        // 驗証是否重覆加入購物清單
        let multi = false;
        carts.forEach(function (item) {
            if (
                item.sizeId == $("#sizeD option:selected").val() &&
                item.colorId == $("#colorD option:selected").val()
            ) {
                alert(
                    $("#sizeD option:selected").text() +
                    "/" +
                    $("#colorD option:selected").text() +
                    " 己加入購物清單！"
                );
                multi = true;
            }
        });
        if (multi) return;
        // 2.系統確認使用者要加入購物車。

        if (parseInt($("#quantityD").val()) <= 0) {
            alert("請輸入正確的購買數量 !");
            return;
        }

        if (!confirm("確定加入購物車嗎？")) return;

        // 5.系統在購物清單表格增加一列尺寸/顏色/數量。
        let doc =
            '<div class="choose-item row"><div class="border border-dark col-3 col-sm-3 col-md-3 col-lg-3 col-xl-3 d-flex align-items-center pt-1 pb-1">';
        doc += $("#sizeD option:selected").text() + "</div>";
        doc +=
            '<div class="border border-dark col-3 col-sm-3 col-md-3 col-lg-3 col-xl-3 d-flex align-items-center pt-1 pb-1">';
        doc += $("#colorD option:selected").text() + "</div>";
        doc +=
            '<div class="border border-dark col-3 col-sm-3 col-md-3 col-lg-3 col-xl-3 d-flex align-items-center pt-1 pb-1">';
        doc += $("#quantityD").val() + "</div>";
        doc +=
            '<div class="border border-dark col-3 col-sm-3 col-md-3 col-lg-3 col-xl-3 d-flex align-items-center pt-1 pb-1">';
        doc +=
            '<button type="button" class="btn btn-maintype btn-favorite btn-deletecart" data-sizeid="' +
            $("#sizeD option:selected").val() +
            '" data-colorid="' +
            $("#colorD option:selected").val() +
            '">刪除</button>';
        doc += "</div>";
        doc += "</div>";
        $("#collapseChoose .card-body").append(doc);
        // 3.系統依2輸入之尺寸/顏色/數量建立一個cart物年。
        let car = new cart(
            jProductId,
            $("#sizeD option:selected").val(),
            $("#colorD option:selected").val(),
            $("#quantityD").val(),
            $("#productD").text(),
            $("#priceD").text(),
            $("#sizeD option:selected").text(),
            $("#colorD option:selected").text()
        );
        // 4.系統將3建立之cart物件push到carts物件。
        carts.push(car);
        //console.log(car);

        jQuantity -= parseInt($("#quantityD").val());
        $("#lblQuantityD").text("數量" + "(" + jQuantity + ")");

        $.ajax({
            type: "POST",
            cache: false,
            //contentType: 'application/json',
            url: PostMemberCartsUrl,
            data: {
                MemberMobile: jMemberMobile,
                ProductId: jProductId,
                Carts: carts
            }
        })
            .done(response => {
                if (response === 0) {
                    // 8.系統在3啟動之ajax回呼函式中判斷7傳回值==0。
                    //  9.系統顯示"加入成功！"。
                    alert("加入購物車成功！");
                    //// 10.系統清除購物清單。
                    //$("#collapseChoose .card-body").empty();
                    // 11.系統清除carts。
                    carts = [];
                } else {
                    // 8a.系統在3啟動之ajax回呼函式中判斷7傳回值!==0。
                    //  8a-1.系統顯示"執行失敗，請稍後再試！"。
                    alert("執行失敗，請稍後再試！");
                }
            })
            .fail(systemError);
    });

    //20181227更新 ---棋
    // 1.使用者在商品詳細資料頁面點按[前往購物車]按鈕。
    $(document).on("click", "#divmyfavorite .btn-addcart", event => {
        event.preventDefault();

        //關閉active
        $('#btnProductDetailClose').click();

        //前往購物車
        $.ajax({
            type: "POST",
            cache: false,
            dataType: "HTML",
            url: cartUrl,
            data: {
                MemberMobile: jMemberMobile,
            }
        })
            .done(cartPage)
            .fail(systemError);
    });

    // 1.使用者在商品詳細資料頁面點按[刪除]按鈕。
    $(document).on("click", "#collapseChoose > .card-body > .choose-item > .pb-1 > .btn-deletecart", function (event) {
        event.preventDefault();
        // 2.系統確認使用者要刪除。
        if (!confirm("此項目將會自購物車永久刪除，確定嗎？")) return;
        let sizeId = $(event.currentTarget).data("sizeid");
        let colorId = $(event.currentTarget).data("colorid");
        // 3.系統自carts物件刪除一筆購物清單。
        let remove = false;
        let idx = -1;
        carts.every(function (item, index) {
            // Do your thing, then:
            if (item.sizeId == sizeId && item.colorId == colorId) {
                remove = true;
                idx = index;
                return false;
            } else {
                return true;
            }
        });
        if (remove) {
            // 3.系統自carts物件刪除一筆購物清單。
            carts.splice(idx, 1);
            // 4.系統在購物清單表格刪除一列尺寸/顏色/數量。
            $(event.currentTarget).closest("div.choose-item").remove();
        }
        // 5..結束。

        //20181220 ---棋
        //刪除商品後加回表格中的數量
        jQuantity += parseInt($("#quantityD").val());
        $("#lblQuantityD").text("數量" + "(" + jQuantity + ")");
        var NegQuantityD = parseInt($("#quantityD").val()) * (-1);
        // 3.系統依2輸入之尺寸/顏色/數量建立一個cart物年。
        let car = new cart(
            jProductId,
            sizeId,
            $("#colorD option:selected").val(),
            NegQuantityD,
            $("#productD").text(),
            $("#priceD").text(),
            $("#sizeD option:selected").text(),
            $("#colorD option:selected").text(),
        );
        // 4.系統將3建立之cart物件push到carts物件。
        carts.push(car);
        //更新購物車數量
        $.ajax({
            type: "POST",
            cache: false,
            async: false,
            url: PostMemberCartsUrl,
            data: {
                MemberMobile: jMemberMobile,
                ProductId: jProductId,
                Carts: carts
            }
        })
            .done(response => {
                $(this).closest("div.choose-item").remove();
                $.ajax({
                    type: "POST",
                    cache: false,
                    async: false,
                    url: GetMemberCartOneList,
                    data: {
                        MemberMobile: jMemberMobile,
                        ProductId: jProductId,
                        ProductSizeId: sizeId,
                        ProductColorId: colorId,
                        //ProductColorId: 9999,
                    }
                })
                    .done(response => {
                        carts = [];
                        if (response.length === 0) {
                            alert("該品項已從購物車中刪除 ! ");
                        } else {
                            var product = `目前購物車中 :` + response[0].product + `\n尺寸:` + response[0].productSize + `\n顏色:` + response[0].productColor + `\n數量為『` + response[0].quantity + `』個。`;
                            alert(product);
                        }
                    })
                    .find(systemError)
            })
            .find(systemError)
    });

    $(document).on("click", "#memberPanel .myfavorite-component .btn-favoritedetail", event => {
        jProductId = $(event.currentTarget).data("productid");
        $.ajax({
            type: "POST",
            cache: false,
            dataType: "HTML",
            url: GetProductDetailUrl,
            data: {
                ProductId: $(event.currentTarget).data("productid"),
                MemberLevelId: jMemberlevelId
            }
        })
            .done(GetFavoriteDetail)
            .fail(systemError);
    });
    const GetFavoriteDetail = data => {
        $("#favoriteDetail").empty();
        $("#favoriteDetail").html(data);

        // 網頁顯示我的最愛商品詳細資料
        $("#favoriteDetail").addClass("active");

        // 關閉我的最愛商品詳細資料
        $(document).on("click", "#favoriteDetail .btn-close", () => {
            $("#favoriteDetail").removeClass("active");
        });
    };

    // 1.使用者在購物車首頁點按某一列購物車清單中的刪除。
    $(document).on("click", "#CartLists .btn-cart-delete", event => {
        event.preventDefault();
        // 2.系統確認使用者要刪除。
        if (!confirm("此項目將會自購物車永久刪除，確定嗎？")) return;
        let target = $(event.currentTarget);
        let idx = parseInt($(event.currentTarget).closest("tr").find("td:eq(1)").text());
        if (jMemberMobile !== '') {
            // 3.系統判斷jMemberMobile!=""。
            // 4.系統以ajax呼叫Post Controller Action【Cart/DeleteCart】並傳送jMemberMobile與1點按列對應cart物件。
            $.ajax({
                type: "Post",
                cache: false,
                async: false,
                url: DeleteCartUrl,
                data: {
                    MemberMobile: jMemberMobile,
                    Cart: new cart($(event.currentTarget).data("productid"), $(event.currentTarget).data("producsizeid"), $(event.currentTarget).data("productcolorid"))
                }
            })
                .done(responsee => {
                    if (responsee === 0) {
                        // 8.系統在4啟動之ajax回呼函式中判斷7傳回值==0。
                        // 9.系統清除1點按列。
                        $("#cartTotals").text(parseInt($("#cartTotals").text()) - parseInt(target.data("subtotal")));
                        target.closest("tbody").find("tr:eq(" + (idx - 1) + ")").remove();
                        // 9-1.系統以ajax呼叫Get Action【Cart/GetFreight】，並傳送$("#cartTotals").text()。
                        $.ajax({
                            type: "Get",
                            cache: false,
                            //async: false,
                            url: GetFreightUrl,
                            data: {
                                CartTotals: parseInt($("#cartTotals").text()) - parseInt($("#FreightValue").text())
                            }
                        })
                            .done(responsee => {
                                // 9-4.系統在9-1啟動之ajax回呼函式中變更$("#FreightValue").text()=9-3回傳之freight.freightValue。
                                let tmp = parseInt(responsee.freight.freightValue) - parseInt($("#FreightValue").text());
                                $("#FreightValue").text(responsee.freight.freightValue);
                                // 9-5.系統更新freight.FreightValue。
                                freight.freightValue = responsee.freight.freightValue;
                                // 9-6.系統更新合計。
                                $("#cartTotals").text(parseInt($("#cartTotals").text()) + tmp);
                            })
                            .fail(systemError);
                        // 10.結束。
                    }
                    else {
                        // 8.a系統在4啟動之ajax回呼函式中判斷7傳回值!==0。
                        //  8a-1.系統顯示"執行失敗，請稍後再試！"。
                        alert("執行失敗，請稍後再試！");
                        //  8a-2.結束。
                    }
                }
                )
                .fail(systemError);
        }
        else {
            // 3a.系統判斷jMemberMobile==""。
            //  3a-1.系統刪除carts中的對應項目。
            carts.splice(idx, 1);
            $("#cartTotals").text(parseInt($("#cartTotals").text()) - parseInt(target.data("subtotal")));
            //  3a-2.系統清除1點按列。
            target.closest("tbody").find("tr:eq(" + (idx - 1) + ")").remove();
            // 9-1.系統以ajax呼叫Get Action【Cart/GetFreight】，並傳送$("#cartTotals").text()。
            $.ajax({
                type: "Get",
                cache: false,
                //async: false,
                url: GetFreightUrl,
                data: {
                    CartTotals: parseInt($("#cartTotals").text()) - parseInt($("#FreightValue").text())
                }
            })
                .done(responsee => {
                    // 9-4.系統在9-1啟動之ajax回呼函式中變更$("#FreightValue").text()=9-3回傳之freight.freightValue。
                    let tmp = parseInt(responsee.freight.freightValue) - parseInt($("#FreightValue").text());
                    $("#FreightValue").text(responsee.freight.freightValue);
                    // 9-5.系統更新freight.FreightValue。
                    freight.freightValue = responsee.freight.freightValue;
                    // 9-6.系統更新合計。
                    $("#cartTotals").text(parseInt($("#cartTotals").text()) + tmp);
                })
                .fail(systemError);
            //  3a-3.結束。
        }
    });
    // 全選/全不選
    $(document).on("click", "#CheckAll", event => {
        $("#CartLists input:checkbox").prop("checked", $("#CheckAll").prop("checked"));
    });
    // 1.使用者在購物車首頁點按刪除勾選。
    $(document).on("click", "#ClearCheckAll", event => {
        // 2.系統確認使用者要刪除。
        if (!confirm("所有勾選項目將會自購物車永久刪除，確定嗎？"))
            return;
        let delCarts = [];
        let idxs = [];
        if (jMemberMobile !== '') {
            // 3.系統判斷jMemberMobile!=""。
            //  3-1.系統將0勾選之所有購物項目建立為delCarts。
            $("#CartLists input:checkbox").each(function (index, element) {
                if ($(element).prop("checked")) {
                    delCarts.push(new cart($(element).data("productid"), $(element).data("producsizeid"), $(element).data("productcolorid")));
                }
            });
            // 4.系統以ajax呼叫Post Controller Action【Cart/DeleteCarts】並傳送jMemberMobile與delCarts物件。
            $.ajax({
                type: "Post",
                cache: false,
                async: false,
                url: DeleteCartsUrl,
                data: {
                    MemberMobile: jMemberMobile,
                    Carts: delCarts
                }
            })
                .done(responsee => {
                    if (responsee === 0) {
                        // 8.系統在4啟動之ajax回呼函式中判斷7傳回值==0。
                        let i = 0;
                        $("#CartLists input:checkbox").each(function (index, element) {
                            if ($(element).prop("checked")) {
                                // 9.系統清除0勾選列。
                                $("#CartLists").find("tr:eq(" + (index - i) + ")").remove();
                                // 9-1.系統更新合計。
                                $("#cartTotals").text(parseInt($("#cartTotals").text()) - parseInt($(element).data("subtotal")));
                                i += 1;
                            }
                        });
                        // 9-1.系統以ajax呼叫Get Action【Cart/GetFreight】，並傳送$("#cartTotals").text()。
                        $.ajax({
                            type: "Get",
                            cache: false,
                            //async: false,
                            url: GetFreightUrl,
                            data: {
                                CartTotals: parseInt($("#cartTotals").text()) - parseInt($("#FreightValue").text())
                            }
                        })
                            .done(responsee => {
                                // 9-4.系統在9-1啟動之ajax回呼函式中變更$("#FreightValue").text()=9-3回傳之freight.freightValue。
                                let tmp = parseInt(responsee.freight.freightValue) - parseInt($("#FreightValue").text());
                                $("#FreightValue").text(responsee.freight.freightValue);
                                // 9-5.系統更新freight.FreightValue。
                                freight.freightValue = responsee.freight.freightValue;
                                // 9-6.系統更新合計。
                                $("#cartTotals").text(parseInt($("#cartTotals").text()) + tmp);
                            })
                            .fail(systemError);
                        // 10.結束。
                    }
                    else {
                        // 8.a系統在4啟動之ajax回呼函式中判斷7傳回值!==0。
                        //  8a-1.系統顯示"執行失敗，請稍後再試！"。
                        alert("執行失敗，請稍後再試！");
                        //  8a-2.結束。
                    }
                }
                )
                .fail(systemError);
        }
        else {
            // 3a.系統判斷jMemberMobile == ""。
            //  3a-2.系統清除所有勾選列。
            let i = 0;
            $("#CartLists input:checkbox").each(function (index, element) {
                if ($(element).prop("checked")) {
                    idxs.push(index - i);
                    // 9.系統清除0勾選列。
                    $("#CartLists").find("tr:eq(" + (index - i) + ")").remove();
                    // 9-1.系統更新合計。
                    $("#cartTotals").text(parseInt($("#cartTotals").text()) - parseInt($(element).data("subtotal")));
                    i += 1;
                }
            });
            //  3a-1.系統刪除carts中的所有對應項目。
            i = 0;
            idxs.forEach(function (item, index) {
                carts.splice(item, 1);
            });
            // 9-1.系統以ajax呼叫Get Action【Cart/GetFreight】，並傳送$("#cartTotals").text()。
            $.ajax({
                type: "Get",
                cache: false,
                //async: false,
                url: GetFreightUrl,
                data: {
                    CartTotals: parseInt($("#cartTotals").text()) - parseInt($("#FreightValue").text())
                }
            })
                .done(responsee => {
                    // 9-4.系統在9-1啟動之ajax回呼函式中變更$("#FreightValue").text()=9-3回傳之freight.freightValue。
                    let tmp = parseInt(responsee.freight.freightValue) - parseInt($("#FreightValue").text());
                    $("#FreightValue").text(responsee.freight.freightValue);
                    // 9-5.系統更新freight.FreightValue。
                    freight.freightValue = responsee.freight.freightValue;
                    // 9-6.系統更新合計。
                    $("#cartTotals").text(parseInt($("#cartTotals").text()) + tmp);
                })
                .fail(systemError);
            //  3a-3.結束。
        }
    });
    // 1.使用者在購物車首頁點按某一列購物車清單中的更新。
    $(document).on("click", "#CartLists .btn-cart-update", event => {
        event.preventDefault();
        // 2.系統確認使用者要更新。
        let target = $(event.currentTarget);
        let idx = parseInt($(event.currentTarget).closest("tr").find("td:eq(1)").text());
        let price = parseInt($(event.currentTarget).closest("tr").find("td:eq(3)").text());
        let jProducSizeIdN = $($(event.currentTarget).closest("tr").find("td:eq(4)")).find(".productsize").val();
        let jProductColorIdN = $(event.currentTarget).closest("tr").find("td:eq(5)").find(".productcolor").val();
        let jProductSize = $($(event.currentTarget).closest("tr").find("td:eq(4)")).find(".productsize").text();
        let jProductColor = $(event.currentTarget).closest("tr").find("td:eq(5)").find(".productcolor").text();
        let jQuantityN = parseInt($(event.currentTarget).closest("tr").find("td:eq(6)").find("input").val());

        // 20181228 ---棋
        if (jQuantityN >= 999999999) {
            alert("請輸入正確的購買數量 !");
            return;
        }

        if (!confirm("此項目將會自購物車永久更新，確定嗎？"))
            return;

        if (jMemberMobile !== '') {
            // 3.系統判斷jMemberMobile!=""。
            // 4.系統以ajax呼叫Post Controller Action【Cart/UpdateCart】並傳送jMemberMobile與1點按列對應cart物件，以及0輸入之尺寸、顏色與數量。
            $.ajax({
                type: "Post",
                cache: false,
                async: false,
                url: UpdateCartUrl,
                data: {
                    MemberMobile: jMemberMobile,
                    Cart: new cart($(event.currentTarget).data("productid"), $(event.currentTarget).data("producsizeid"), $(event.currentTarget).data("productcolorid")),
                    ProducSizeIdN: jProducSizeIdN,
                    ProductColorIdN: jProductColorIdN,
                    ProductSize: jProductSize,
                    ProductColor: jProductColor,
                    QuantityN: jQuantityN
                }
            })
                .done(responsee => {
                    if (responsee === 0) {
                        // 8.系統在4啟動之ajax回呼函式中判斷7傳回值==0。
                        // 9.系統將更新列之小計更新。
                        let oldsub = parseInt(target.closest("tr").find("td:eq(7)").text());
                        let newsub = price * jQuantityN;
                        target.closest("tr").find("td:eq(7)").text(newsub);
                        // 9-1.系統將總計更新。
                        $("#cartTotals").text(parseInt($("#cartTotals").text()) + (newsub - oldsub));
                        // 9-1.系統以ajax呼叫Get Action【Cart/GetFreight】，並傳送$("#cartTotals").text()。
                        $.ajax({
                            type: "Get",
                            cache: false,
                            //async: false,
                            url: GetFreightUrl,
                            data: {
                                CartTotals: parseInt($("#cartTotals").text()) - parseInt($("#FreightValue").text())
                            }
                        })
                            .done(responsee => {
                                // 9-4.系統在9-1啟動之ajax回呼函式中變更$("#FreightValue").text()=9-3回傳之freight.freightValue。
                                let tmp = parseInt(responsee.freight.freightValue) - parseInt($("#FreightValue").text());
                                $("#FreightValue").text(responsee.freight.freightValue);
                                // 9-5.系統更新freight.FreightValue。
                                freight.freightValue = responsee.freight.freightValue;
                                // 9-6.系統更新合計。
                                $("#cartTotals").text(parseInt($("#cartTotals").text()) + tmp);
                            })
                            .fail(systemError);
                        // 10.結束。
                        alert("更新成功");
                    }
                    else if (responsee == 2) {
                        alert("庫存不足");
                    }
                    else if (responsee == 3) {
                        alert("購物清單重覆！");
                    }
                    else {
                        // 8.a系統在4啟動之ajax回呼函式中判斷7傳回值!==0。
                        //  8a-1.系統顯示"執行失敗，請稍後再試！"。
                        alert("執行失敗，請稍後再試！");
                        //  8a-2.結束。
                    }
                }
                )
                .fail(systemError);
        }
        else {
            // 3a.系統判斷jMemberMobile==""。
            //  3a-1.系統更新carts中的對應項目。
            carts[idx - 1].sizeId = jProducSizeIdN;
            carts[idx - 1].colorId = jProductColorIdN;
            carts[idx - 1].size = jProductSize;
            carts[idx - 1].color = jProductColor;
            carts[idx - 1].quantity = jQuantityN;
            // 3a-2.系統將更新列之小計更新。
            let oldsub = parseInt(target.closest("tr").find("td:eq(7)").text());
            let newsub = price * jQuantityN;
            target.closest("tr").find("td:eq(7)").text(newsub);
            // 3a-3系統將總計更新。
            $("#cartTotals").text(parseInt($("#cartTotals").text()) + (newsub - oldsub));
            // 9-1.系統以ajax呼叫Get Action【Cart/GetFreight】，並傳送$("#cartTotals").text()。
            $.ajax({
                type: "Get",
                cache: false,
                //async: false,
                url: GetFreightUrl,
                data: {
                    CartTotals: parseInt($("#cartTotals").text()) - parseInt($("#FreightValue").text())
                }
            })
                .done(responsee => {
                    // 9-4.系統在9-1啟動之ajax回呼函式中變更$("#FreightValue").text()=9-3回傳之freight.freightValue。
                    let tmp = parseInt(responsee.freight.freightValue) - parseInt($("#FreightValue").text());
                    $("#FreightValue").text(responsee.freight.freightValue);
                    // 9-5.系統更新freight.FreightValue。
                    freight.freightValue = responsee.freight.freightValue;
                    // 9-6.系統更新合計。
                    $("#cartTotals").text(parseInt($("#cartTotals").text()) + tmp);
                })
                .fail(systemError);
            //  3a-4.結束。
        }
    });
    // 4.商品批發/商品零售價：???改為加入會員=>加入會員。
    $(document).on("click", ".joinus-link", event => {
        event.preventDefault();
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: joinusUrl
        })
            .done(joinusPage)
            .fail(systemError);
    });
    //20190102 ---棋
    // 4.商品批發/商品零售價：???改為升級批發會員。
    $(document).on("click", ".JoinusWholesale-link", event => {
        event.preventDefault();
        $.ajax({
            type: "GET",
            cache: false,
            async: false,
            dataType: "HTML",
            url: memberUrl
        })
            .done(data => {
                $("#mainContent").empty();
                $("#mainContent").html(data);

                $(document).on("click", "#mobileSide", () => {
                    $("#memberMenu").addClass("active");
                });

                $("#btnMenuClose").on("click", () => {
                    $("#memberMenu").removeClass("active");
                });

                $.ajax({
                    type: "GET",
                    cache: false,
                    dataType: "HTML",
                    url: memberPersonaldataUrl,
                    data: { MemberMobile: jMemberMobile }
                })
                    .done(memberComponent)
                    .fail(systemError);
            })
            .fail(systemError);
    });
    // 註冊
    $(document).on("click", "#btnRegister", event => {
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: joinusUrl
        })
            .done(joinusPage)
            .fail(systemError);
        $(event.currentTarget).addClass("active");
    });
    // 1.使用者在購物車個人資料頁點按同個人資料。
    $(document).on("click", "#inlineCheckbox1", event => {
        if ($(event.currentTarget).prop("checked")) {
            // 2.系統判斷同個人資料打勾。
            // 3.系統將個人資料複製到送貨資料。
            $("#MemberNameCT").val($("#MemberNameC").val());
            $("#MemberMobileCT").val($("#MemberMobileC").val());
            $("#PhoneCT").val($("#PhoneC").val());
            $("#ContactAddressCT").val($("#ContactAddressC").val());
            $("#eMailCT").val($("#eMailC").val());
            // 3-1.系統以ajax呼叫Get Action【Cart/GetOutFreight】，並傳送$("#ContactAddressCT").val()。
            $.ajax({
                type: "Get",
                cache: false,
                //async: false,
                url: GetOutFreightUrl,
                data: {
                    ContactAddress: $("#ContactAddressCT").val()
                }
            })
                .done(responsee => {
                    if (responsee == 1) {
                        // 3-5.系統在3-1啟動之ajax回呼函式中判斷3-4回傳值===1。
                        // 3-6.系統更新freight.TrueOutFreightValue=freight.OutFreightValue。
                        freight.TrueOutFreightValue = freight.OutFreightValue;
                    }
                    else {
                        // 3-5a.系統在3-1啟動之ajax回呼函式中判斷3-4回傳值!==1。
                        //  3-5a-1.系統更新freight.TrueOutFreightValue=0
                        freight.TrueOutFreightValue = 0;
                        //  3-5a-2.回3-7。
                    }
                    // 3-7.系統更新$("#FreightCT").val()。
                    $("#FreightCT").val(freight.TrueOutFreightValue + freight.FreightValue);
                })
                .fail(systemError);
        }
        else {
            $("#MemberNameCT").val('');
            $("#MemberMobileCT").val('');
            $("#PhoneCT").val('');
            $("#ContactAddressCT").val('');
            $("#eMailCT").val('');
        }
        // 4.結束。
    });
    // 1.使用者在購物車個人資料頁編輯送貨地址後將插入點移出。
    $(document).on("blur", "#ContactAddressCT", event => {
        // 3-1.系統以ajax呼叫Get Action【Cart/GetOutFreight】，並傳送$("#ContactAddressCT").val()。
        $.ajax({
            type: "Get",
            cache: false,
            //async: false,
            url: GetOutFreightUrl,
            data: {
                ContactAddress: $("#ContactAddressCT").val()
            }
        })
            .done(responsee => {
                if (responsee == 1) {
                    // 3-5.系統在3-1啟動之ajax回呼函式中判斷3-4回傳值===1。
                    // 3-6.系統更新freight.TrueOutFreightValue=freight.OutFreightValue。
                    freight.TrueOutFreightValue = freight.OutFreightValue;
                }
                else {
                    // 3-5a.系統在3-1啟動之ajax回呼函式中判斷3-4回傳值!==1。
                    //  3-5a-1.系統更新freight.TrueOutFreightValue=0
                    freight.TrueOutFreightValue = 0;
                    //  3-5a-2.回3-7。
                }
                // 3-7.系統更新$("#FreightCT").val()。
                $("#FreightCT").val(freight.TrueOutFreightValue + freight.FreightValue);
            })
            .fail(systemError);
        // 4.結束。
    });

    //------------------------------------------20180000 YunQiWholesale 我的訂單
    // 1.使用者在[我的訂單]之商品清單區單按下一頁/前一頁/某一頁連結。
    $(document).on("click", "#MybtnNextPageO", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage + 1 > jTotallPages) {
            alert("己到最後一頁");
            return;
        }
        // 3.系統將jCurrentPage+1。
        jCurrentPage += 1;
        // 4.系統以ajax呼叫Get Controller Action【Member/MyOrder】，並傳送jMemberMobile、jProduct、jsDate、jeDate、1點按頁碼、jOrderId。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMyorderUrl,
            data: {
                MemberMobile: jMemberMobile,
                Product: jProduct,
                OrderId: jOrderId,
                sDate: jsDate,
                eDate: jeDate,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[我的訂單]之商品清單區單按下一頁/前一頁/某一頁連結。
    $(document).on("click", "#MybtnPrePageO", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage - 1 < 1) {
            alert("己到第一頁");
            return;
        }
        // 3.系統將jCurrentPage-1。
        jCurrentPage -= 1;
        // 4.系統以ajax呼叫Get Controller Action【Member/MyOrder】，並傳送jMemberMobile、jProduct、jsDate、jeDate、1點按頁碼、jOrderId。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMyorderUrl,
            data: {
                MemberMobile: jMemberMobile,
                Product: jProduct,
                OrderId: jOrderId,
                sDate: jsDate,
                eDate: jeDate,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[我的訂單]之商品清單區單按下一頁/前一頁/某一頁連結。
    $(document).on("click", "#FPageListO > .dropdown-item", event => {
        event.preventDefault();
        //// 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        //if (jCurrentPage - 1 < 1) {
        //    alert("己到第一頁");
        //    return;
        //}
        //// 3.系統將jCurrentPage-1。
        //jCurrentPage -= 1;
        // 4.系統以ajax呼叫Get Controller Action【Member/MyOrder】，並傳送jMemberMobile、jProduct、jsDate、jeDate、1點按頁碼、jOrderId。
        jCurrentPage = $(event.currentTarget).data("page");
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMyorderUrl,
            data: {
                MemberMobile: jMemberMobile,
                Product: jProduct,
                OrderId: jOrderId,
                sDate: jsDate,
                eDate: jeDate,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 2.使用者點按查詢按鈕。
    $(document).on("click", "#btnSearchMyOrder", event => {
        event.preventDefault();
        // 3.系統將1輸入條件暫存在jProduct、jsDate、jeDate、jOrderId，並將jCurrentPage重設為1。
        jOrderId = $("#OrderId").val();
        jProduct = $("#ProductO").val();
        jsDate = $("#sDateO").val();
        jeDate = $("#eDateO").val();
        jCurrentPage = 1;
        // 4.系統以ajax呼叫Get Controller Action【Member/MyOrder】，並傳送jMemberMobile、jProduct、jsDate、jeDate、1點按頁碼、jOrderId。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMyorderUrl,
            data: {
                MemberMobile: jMemberMobile,
                Product: jProduct,
                OrderId: jOrderId,
                sDate: jsDate,
                eDate: jeDate,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者點按某一筆訂單之通知己付款按鈕。
    $(document).on("click", ".UudateOrderState", event => {
        event.preventDefault();
        // 2.使用者確認。
        if (!confirm("確定己付款了嗎？"))
            return;
        // 3.系統以ajax呼叫Post Controller Action【Member/UpdateOrderState3】，並傳送jMemberMobile以及1點按之OrderId。
        $target = $(event.currentTarget);
        $.ajax({
            type: "Post",
            cache: false,
            url: UpdateOrderState3Url,
            data: {
                MemberMobile: jMemberMobile,
                OrderId: $(event.currentTarget).closest(".ordelist-box").data('orderid')
            }
        })
            .done(response => {
                if (response == 0) {
                    // 7.系統在3啟動之ajax回呼函式判斷6傳回值==0。
                    // 8.系統顯示"通知成功"。
                    alert("通知成功！");
                    // 9.系統將訂單狀態更新為"己付款(待確認)"。
                    $target.closest(".ordelist-box").find(".OrderState").val('己付款(待確認)');
                    $target.fadeOut();
                    // 10.結束。
                }
                else if (response == 2) {
                    // 7a.系統在3啟動之ajax回呼函式判斷6傳回值==2。
                    //  7a-1.系統顯示"訂單不存在！"。
                    alert("訂單不存在！");
                    //  7a-2.結束。
                }
                else {
                    // 7b.系統在3啟動之ajax回呼函式判斷6傳回值!=0/2。
                    //  7b-1.系統顯示"通知失敗，請稍會兒再試！"。
                    alert("通知失敗，請稍會兒再試！");
                    //  7b-2.結束。
                }
            })
            .fail(systemError);
    });
    ////20181213 ---棋
    ////使用者在會員中心-我的訂單-點擊取消訂單
    //20181213 ---棋
    //使用者在會員中心-我的訂單-點擊取消訂單
    $(document).on("click", ".UserCancelOrderbtn", function (event) {
        event.preventDefault();
        if (!confirm('確定要取消訂單？')) return;

        var OrderId = $(this).data('cancelorderid');

        $.ajax({
            type: "Post",
            cache: false,
            dataType: "HTML",
            url: GetCancelOrderState,
            data: {
                OrderId: OrderId,
            }
        })
            .done(success)
            .fail(systemError)

        const systemError = () => {
            alert("系統錯誤，請稍後再試！");
        };

        function success(data) {
            data == -1 ? (alert('系統錯誤，請稍後再試！')) : ("");
            data == 0 ? (alert("訂單取消成功 ! ")) : ("");
            data == 2 ? (alert("查無此訂單 ! ")) : ("");
        }
    });

    //------------------------------------------20180000 YunQiWholesale 我的訂單

    //------------------------------------------20181119 YunQiWholesale 我的下線
    //20181119 ---棋
    //1.使用者在[我的下線]之商品清單區單按 Serrch
    $(document).on("click", "#btnSerrchMyFollower", event => {
        event.preventDefault();
        // 3.系統將1輸入條件暫存在sDateO、eDateO並將jCurrentPage重設為1。
        jCurrentPage = 1;

        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、jProduct、jsDate、jeDate、1點按頁碼、jOrderId。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMyfollowerUrl,
            data: {
                MemberMobile: jMemberMobile,
                sDate: $("#sDateO").val(),
                eDate: $("#eDateO").val(),
                ReferrerMobile: $("#MemberMobileWhere").val(),
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[我的下線]之商品清單區單按前一頁連結。
    $(document).on("click", "#MyfollowerPrePageO", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage - 1 < 1) {
            alert("己到第一頁");
            return;
        }
        // 3.系統將jCurrentPage-1。
        jCurrentPage -= 1;
        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMyfollowerUrl,
            data: {
                MemberMobile: jMemberMobile,
                sDate: $("#sDateO").val(),
                eDate: $("#eDateO").val(),
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[我的下線]之商品清單區單按下一頁連結。
    $(document).on("click", "#MyfollowerNextPageO", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage + 1 > jTotallPages) {
            alert("己到最後一頁");
            return;
        }
        // 3.系統將jCurrentPage+1。
        jCurrentPage += 1;
        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMyfollowerUrl,
            data: {
                MemberMobile: jMemberMobile,
                sDate: $("#sDateO").val(),
                eDate: $("#eDateO").val(),
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[我的下線]之商品清單區單按某一頁連結。
    $(document).on("click", "#MFPageListO > .dropdown-item", event => {
        event.preventDefault();
        jCurrentPage = $(event.currentTarget).data("page");
        if (jTotallPages == 1) {
            alert("己到第一頁");
            return;
        };
        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page、。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMyfollowerUrl,
            data: {
                MemberMobile: jMemberMobile,
                sDate: $("#sDateO").val(),
                eDate: $("#eDateO").val(),
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    //------------------------------------------20181119 YunQiWholesale 我的下線

    //------------------------------------------20181121 YunQiWholesale 我的下線業績
    //20181121 ---棋
    //1.使用者在[我的下線業績]之商品清單區單按 Serrch
    $(document).on("click", "#btnSerrchFollowertriumph", event => {
        event.preventDefault();
        // 3.系統將1輸入條件暫存在sDateO、eDateO並將jCurrentPage重設為1。
        jCurrentPage = 1;
        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、jProduct、jsDate、jeDate、1點按頁碼、jOrderId。

        if ($("#sDateO").val() != "") {
            var dt = new Date();
            var dtt = new Date($("#sDateO").val().substring(0, 4), $("#sDateO").val().substring(5, 7), 0);
            var sDate = ($("#sDateO").val().substring(0, 8)) + "01 00:00:00";
            var eDate = ($("#sDateO").val().substring(0, 8)) + +dtt.getDate(0) + " 23:59:59";
        }

        // 2018/11/23 15:38:58
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberFollowertriumphUrl,
            data: {
                MemberMobile: jMemberMobile,
                sDate: sDate,
                eDate: eDate,
                ReferrerMobile: $("#MemberMobileWhere").val(),
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[我的下線業績]之商品清單區單按前一頁連結。
    $(document).on("click", "#FollowertriumphPrePage", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage - 1 < 1) {
            alert("己到第一頁");
            return;
        }
        // 3.系統將jCurrentPage-1。
        jCurrentPage -= 1;
        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page。

        if ($("#sDateO").val() != "") {
            var dt = new Date();
            var dtt = new Date($("#sDateO").val().substring(0, 4), $("#sDateO").val().substring(5, 7), 0);
            var sDate = ($("#sDateO").val().substring(0, 8)) + "01 00:00:00";
            var eDate = ($("#sDateO").val().substring(0, 8)) + +dtt.getDate(0) + " 23:59:59";
        }
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberFollowertriumphUrl,
            data: {
                MemberMobile: jMemberMobile,
                sDate: sDate,
                eDate: eDate,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[我的下線業績]之商品清單區單按下一頁連結。
    $(document).on("click", "#FollowertriumphNextPage", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage + 1 > jTotallPages) {
            alert("己到最後一頁");
            return;
        }
        // 3.系統將jCurrentPage+1。
        jCurrentPage += 1;

        //console.log(jCurrentPage);

        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page。
        if ($("#sDateO").val() != "") {
            var dt = new Date();
            var dtt = new Date($("#sDateO").val().substring(0, 4), $("#sDateO").val().substring(5, 7), 0);
            var sDate = ($("#sDateO").val().substring(0, 8)) + "01 00:00:00";
            var eDate = ($("#sDateO").val().substring(0, 8)) + +dtt.getDate(0) + " 23:59:59";
        }

        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberFollowertriumphUrl,
            data: {
                MemberMobile: jMemberMobile,
                sDate: sDate,
                eDate: eDate,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[我的下線業績]之商品清單區單按某一頁連結。
    $(document).on("click", "#FollowertriumphPageList > .dropdown-item", event => {
        event.preventDefault();
        jCurrentPage = $(event.currentTarget).data("page");
        if (jTotallPages == 1) {
            alert("己到第一頁");
            return;
        };
        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page、。
        if ($("#sDateO").val() != "") {
            var dt = new Date();
            var dtt = new Date($("#sDateO").val().substring(0, 4), $("#sDateO").val().substring(5, 7), 0);
            var sDate = ($("#sDateO").val().substring(0, 8)) + "01 00:00:00";
            var eDate = ($("#sDateO").val().substring(0, 8)) + +dtt.getDate(0) + " 23:59:59";
        }
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberFollowertriumphUrl,
            data: {
                MemberMobile: jMemberMobile,
                sDate: sDate,
                eDate: eDate,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    //------------------------------------------20181121 YunQiWholesale 我的下線業績

    //20181130 ---棋
    // 1.使用者在商品分類管理首頁點按某一列商品分類之刪除。
    $(document).on('click', '.btn-favoritedelete', function (event) {
        event.preventDefault();

        ProductId = $(this).attr('data-productid')

        // 2.使用者確認要刪除。
        if (!confirm('確定刪除？')) return;

        $selecteditadmin = $(this).parent().parent().parent().parent().parent().parent();

        // 3.系統以ajax呼叫Post Action【Member / DeleteMyfavorite】，並傳送1點按之ProductId以及jMemberMobile
        $.ajax({
            type: 'POST',
            cache: false,
            url: DeleteMyfavorite,
            data: {
                jMemberMobile: jMemberMobile,
                ProductId: ProductId,
            }
        })
            .done(DeleteSuccess)
            .fail(systemError)
    });
    function DeleteSuccess(response) {
        if (response == 0) {
            // 12.系統在6啟動之ajax回呼函式中判斷11傳回值==0。
            alert('刪除成功');
            // 8.系統將刪除列自管理者清單列中去除。
            $selecteditadmin.remove();
            //location.reload();   //重導會變回首頁
            //$.ajax({
            //    type: "GET",
            //    cache: false,
            //    dataType: "HTML",
            //    url: "Member/Myfavorite",
            //    data: { MemberMobile: jMemberMobile }
            //})
            //    .done(data => {
            //        $("#memberPanel").empty();
            //        $("#memberPanel").html(data)

            //    })
            //    .fail(data => { alert("系統錯誤，請稍後再試！") });
        }
        else if (response == 2) {
            alert('無此項商品！');
        }
        else {
            alert('刪除失敗，請稍後再試！');
        }
    };
    //20181207 ---棋
    //使用者在Login 點選忘記密碼
    $(document).on('click', '#LostPassword', function (event) {
        event.preventDefault();
        var MemberMobile = $('#MemberMobileLogin').val();
        //確定使用者有輸入帳號
        if (MemberMobile == "" || MemberMobile == null) {
            alert("請輸入帳號!!");
            return;
        }
        //再次與使用者確定是否重設密碼
        if (!confirm('確定申請重設定密碼？')) return;

        $.ajax({
            type: 'POST',
            cache: false,
            url: InsertMemberForget,
            data: {
                MemberMobile: MemberMobile,
            }
        })
            .done(success)
            .fail(systemError)

        function success(data) {
            data == 0 ? (alert("重設密碼信已寄出")) : ("");
            data == -1 ? (alert("查無此帳號")) : ("");
            data == -2 ? (alert("此帳號無設定信箱")) : ("");
        }
    });
    // 1.點按登出。
    $('#btnLogout').on('click', function (event) {
        event.preventDefault();

        $.ajax({
            type: 'Post',
            url: PostLogout,
            success: LogoutSuccess,
            error: systemError
        });
        function LogoutSuccess(response) {
            if (response == 0) {
                if (!confirm('確定登出？')) return;
                jMemberMobile = "";
                jMemberMobile = null;
                location.reload();
            }
            else {
                alert("登出失敗！");
            }
        }
    });
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
                location.href = GetHomeIndex;
            }
            else if (data == -2) {
                alert("密碼已變更過，請重新申請 ! ")
            }
        };
    });
    //------------------------------------------20181215 YunQiWholesale 點數異動記錄
    //20181215 ---棋
    //1.使用者在[點數異動記錄]之商品清單區單按 Serrch
    $(document).on("click", "#btnSerrchProductDetail", event => {
        event.preventDefault();
        // 3.系統將1輸入條件暫存在sDateO、eDateO並將jCurrentPage重設為1。
        jCurrentPage = 1;
        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、jProduct、jsDate、jeDate、1點按頁碼、jOrderId。

        jsDate = $('#sDateO').val();
        jeDate = $('#eDateO').val();

        //console.log(jsDate, jsDate, jMemberMobile);
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberPointnotesUrl,
            data: {
                MemberMobile: jMemberMobile,
                sDate: jsDate,
                eDate: jeDate,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[點數異動記錄]之商品清單區單按前一頁連結。
    $(document).on("click", "#ProductDetailPrePage", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage - 1 < 1) {
            alert("己到第一頁");
            return;
        }
        // 3.系統將jCurrentPage-1。
        jCurrentPage -= 1;

        //console.log(jCurrentPage);

        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page。

        jsDate = $('#sDateO').val();
        jeDate = $('#eDateO').val();

        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberPointnotesUrl,
            data: {
                MemberMobile: jMemberMobile,
                sDate: jsDate,
                eDate: jeDate,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[點數異動記錄]之商品清單區單按下一頁連結。
    $(document).on("click", "#ProductDetailNextPage", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage + 1 > jTotallPages) {
            alert("己到最後一頁");
            return;
        }
        // 3.系統將jCurrentPage+1。
        jCurrentPage += 1;

        //console.log(jCurrentPage);

        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page。
        jsDate = $('#sDateO').val();
        jeDate = $('#eDateO').val();

        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberPointnotesUrl,
            data: {
                MemberMobile: jMemberMobile,
                sDate: jsDate,
                eDate: jeDate,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[點數異動記錄]之商品清單區單按某一頁連結。
    $(document).on("click", "#ProductDetailPageList > .dropdown-item", event => {
        event.preventDefault();
        jCurrentPage = $(event.currentTarget).data("page");
        if (jTotallPages == 1) {
            alert("己到第一頁");
            return;
        };

        //console.log(jCurrentPage);

        jsDate = $('#sDateO').val();
        jeDate = $('#eDateO').val();

        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page、。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberPointnotesUrl,
            data: {
                MemberMobile: jMemberMobile,
                sDate: jsDate,
                eDate: jeDate,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    //------------------------------------------20181215 YunQiWholesale 點數異動記錄

    //------------------------------------------20181217 YunQiWholesale 訊息中心
    //20181217 ---棋
    //1.使用者在[點數異動記錄]之商品清單區單按 Serrch
    $(document).on("click", "#btnSerrchMessageValue", event => {
        event.preventDefault();
        // 3.系統將1輸入條件暫存在sDateO、eDateO並將jCurrentPage重設為1。
        jCurrentPage = 1;
        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、jProduct、jsDate、jeDate、1點按頁碼、jOrderId。

        MessageValue = $('#MessageValue').val();
        //console.log(MessageValue);
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMailcenterUrl,
            data: {
                MemberMobile: jMemberMobile,
                MessageValue: MessageValue,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[點數異動記錄]之商品清單區單按前一頁連結。
    $(document).on("click", "#MessageValuePrePage", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage - 1 < 1) {
            alert("己到第一頁");
            return;
        }
        // 3.系統將jCurrentPage-1。
        jCurrentPage -= 1;

        MessageValue = $('#MessageValue').val();

        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page。

        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMailcenterUrl,
            data: {
                MemberMobile: jMemberMobile,
                MessageValue: MessageValue,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[點數異動記錄]之商品清單區單按下一頁連結。
    $(document).on("click", "#MessageValueNextPage", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage + 1 > jTotallPages) {
            alert("己到最後一頁");
            return;
        }
        // 3.系統將jCurrentPage+1。
        jCurrentPage += 1;

        MessageValue = $('#MessageValue').val();

        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMailcenterUrl,
            data: {
                MemberMobile: jMemberMobile,
                MessageValue: MessageValue,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[點數異動記錄]之商品清單區單按某一頁連結。
    $(document).on("click", "#MessageValuePageList > .dropdown-item", event => {
        event.preventDefault();
        jCurrentPage = $(event.currentTarget).data("page");
        if (jTotallPages == 1) {
            alert("己到第一頁");
            return;
        };

        MessageValue = $('#MessageValue').val();

        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page、。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMailcenterUrl,
            data: {
                MemberMobile: jMemberMobile,
                MessageValue: MessageValue,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    //------------------------------------------20181217 YunQiWholesale 訊息中心

    //------------------------------------------20181220 YunQiWholesale 送貨地址
    //20181220 ---棋
    //1.使用者在[送貨地址]之商品清單區單按 Serrch
    $(document).on("click", "#btnSerrchMemberAddress", event => {
        event.preventDefault();
        // 3.系統將1輸入條件暫存在sDateO、eDateO並將jCurrentPage重設為1。
        jCurrentPage = 1;
        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、jProduct、jsDate、jeDate、1點按頁碼、jOrderId。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberShipaddressUrl,
            data: {
                MemberMobile: jMemberMobile,
                MemberName: $('#SerrchMemberName').val(),
                Phone: $('#SerrchPhone').val(),
                DeliveryAddress: $('#SerrchDeliveryAddress').val(),
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[送貨地址]之商品清單區單按前一頁連結。
    $(document).on("click", "#MemberAddressPrePage", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage - 1 < 1) {
            alert("己到第一頁");
            return;
        }
        // 3.系統將jCurrentPage-1。
        jCurrentPage -= 1;

        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberShipaddressUrl,
            data: {
                MemberMobile: jMemberMobile,
                MemberName: $('#SerrchMemberName').val(),
                Phone: $('#SerrchPhone').val(),
                DeliveryAddress: $('#SerrchDeliveryAddress').val(),
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[送貨地址]之商品清單區單按下一頁連結。
    $(document).on("click", "#MemberAddressNextPage", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage + 1 > jTotallPages) {
            alert("己到最後一頁");
            return;
        }
        // 3.系統將jCurrentPage+1。
        jCurrentPage += 1;
        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberShipaddressUrl,
            data: {
                MemberMobile: jMemberMobile,
                MemberName: $('#SerrchMemberName').val(),
                Phone: $('#SerrchPhone').val(),
                DeliveryAddress: $('#SerrchDeliveryAddress').val(),
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[送貨地址]之商品清單區單按某一頁連結。
    $(document).on("click", "#MemberAddressPageList > .dropdown-item", event => {
        event.preventDefault();
        jCurrentPage = $(event.currentTarget).data("page");
        if (jTotallPages == 1) {
            alert("己到第一頁");
            return;
        };
        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page、。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberShipaddressUrl,
            data: {
                MemberMobile: jMemberMobile,
                MemberName: $('#SerrchMemberName').val(),
                Phone: $('#SerrchPhone').val(),
                DeliveryAddress: $('#SerrchDeliveryAddress').val(),
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    //1.使用者點選新增送貨地址
    $(document).on("click", "#addMemberDeliveryAddress", function () {
        event.preventDefault();
        $('#InsertMemberDeliveryAddress').append(`<div class="card text-white">
                    <div class="card-header">新增送貨地址</div>
                    <div class="card-body">
                        <div class="form-group row">
                            <label for="" class="col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4">姓名：</label>
                            <div class="col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8">
                                <input type="text" id='newMemberName'  class="form-control" id="" value="">
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="" class="col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4">信箱：</label>
                            <div class="col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8">
                                <input type="text"  id='neweMail' class="form-control" id="" value="">
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="" class="col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4">住家/公司電話：</label>
                            <div class="col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8">
                                <input type="text" id='newPhone'  class="form-control" id="" value="">
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="" class="col-form-label col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4">送貨地址：</label>
                            <div class="col-12 col-sm-12 col-md-12 col-lg-8 col-xl-8">
                                <input type="text" id='newDeliveryAddress'  class="form-control" id="" value="">
                            </div>
                        </div>
                    </div>
                    <div class="card-footer text-muted">
                        <button type="button" id='newMemberDeliveryAddress' class="btn btn-add btn-maintype">新增</button>
                    </div>
                </div>`);
        $('#MemberDeliveryAddressList').empty();
    });
    //1.使用者點在新增送貨地址點選送出
    $(document).on("click", "#newMemberDeliveryAddress", function () {
        event.preventDefault();
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: InsertMemberDeliveryAddress,
            data: {
                MemberMobile: jMemberMobile,
                MemberName: $('#newMemberName').val(),
                Phone: $('#newPhone').val(),
                DeliveryAddress: $('#newDeliveryAddress').val(),
                eMail: $('#neweMail').val(),
            }
        })
            .done(success)
            .fail(systemError);
        function success(data) {
            data == 0 ? (alert("新增成功 !")) : ("");
            data == -1 ? (alert('執行錯誤，請稍後再試！')) : ("");
        }
    });
    //1.使用者點在送貨地址點選更新
    $(document).on("click", "#UpdateMemberDeliveryAddress", function () {
        event.preventDefault();

        MemberAddressId = $(this).data('memberaddressid');
        MemberNameN = $(this).parents().parents().children().children().eq(0).children().eq(1).children().val();
        PhoneN = $(this).parents().parents().children().children().eq(2).children().eq(1).children().val();
        eMailN = $(this).parents().parents().children().children().eq(1).children().eq(1).children().val();
        DeliveryAddressN = $(this).parents().parents().children().children().eq(3).children().eq(1).children().val();

        //console.log(MemberAddressId);
        //console.log(MemberNameN);
        //console.log(PhoneN);
        //console.log(DeliveryAddressN);
        //console.log(eMailN);
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: UpdateMemberDeliveryAddress,
            data: {
                MemberMobile: jMemberMobile,
                MemberAddressId: MemberAddressId,
                MemberNameN: MemberNameN,
                PhoneN: PhoneN,
                DeliveryAddressN: DeliveryAddressN,
                eMailN: eMailN,
            }
        })
            .done(data => {
                if (data == 0) {
                    alert("送貨地址更新成功");

                    $.ajax({
                        type: "GET",
                        cache: false,
                        dataType: "HTML",
                        url: memberShipaddressUrl,
                        data: { MemberMobile: jMemberMobile, }
                    })
                        .done(memberComponent)
                        .fail(systemError);
                }

                data == -1 ? (alert("系統錯誤，請稍後再試！")) : ("");
                data == -2 ? (alert("資料重複，請重新修改！")) : ("");
            })
            .fail(systemError);
    });
    //1.使用者在購物車選單中選取送貨地址
    $(document).on("change", "#CartShipaddress", function () {
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "json",
            url: GetMemberDeliveryAddress,
            data: {
                MemberMobile: jMemberMobile,
                MemberAddressId: this.value,
            }
        })
            .done(data => {
                $('#MemberNameCT').val(data[0].memberName);
                $('#MemberMobileCT').val(data[0].memberMobile);
                $('#PhoneCT').val(data[0].phone);
                $('#ContactAddressCT').val(data[0].deliveryAddress);
                $('#eMailCT').val(data[0].eMail);
            })
            .fail(systemError);
    });
    //20181228 ---棋
    //1.使用者在購物車選單中選取儲存至會員中心
    $(document).on("click", "#StorageMemberDeliveryAddress", function () {
        event.preventDefault();
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: InsertMemberDeliveryAddress,
            data: {
                MemberMobile: jMemberMobile,
                MemberName: $('#MemberNameCT').val(),
                Phone: $('#MemberMobileCT').val(),
                DeliveryAddress: $('#ContactAddressCT').val(),
                eMail: $('#eMailCT').val(),
            }
        })
            .done(success)
            .fail(systemError);
        function success(data) {
            data == 0 ? (alert("新增成功 !")) : ("");
            data == -1 ? (alert('執行錯誤，請稍後再試！')) : ("");
        }
    });
    //------------------------------------------20181220 YunQiWholesale 送貨地址

    //------------------------------------------20181217 YunQiWholesale 會員調撥區
    //20181223 ---棋
    //1.使用者在[會員調撥區]之商品清單區單按 Serrch
    $(document).on("click", "#btnSerrchMembermove", event => {
        event.preventDefault();
        // 3.系統將1輸入條件暫存在sDateO、eDateO並將jCurrentPage重設為1。
        jCurrentPage = 1;
        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、jProduct、jsDate、jeDate、1點按頁碼、jOrderId。

        sDate = $('#sDateO').val();
        eDate = $('#eDateO').val();
        MessageValue = $('#MessageValue').val();
        NickName = $('#NickName').val();

        //console.log(sDate);
        //console.log(eDate);
        //console.log(MessageValue);
        //console.log(NickName);

        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMembermoveUrl,
            data: {
                MessageValue: MessageValue,
                NickName: NickName,
                sDate: sDate,
                eDate: eDate,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[會員調撥區]之商品清單區單按前一頁連結。
    $(document).on("click", "#MembermovePrePage", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage - 1 < 1) {
            alert("己到第一頁");
            return;
        }
        // 3.系統將jCurrentPage-1。
        jCurrentPage -= 1;

        sDate = $('#sDateO').val();
        eDate = $('#eDateO').val();
        MessageValue = $('#MessageValue').val();
        NickName = $('#NickName').val();

        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMembermoveUrl,
            data: {
                MessageValue: MessageValue,
                NickName: NickName,
                sDate: sDate,
                eDate: eDate,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[會員調撥區]之商品清單區單按下一頁連結。
    $(document).on("click", "#MembermoveNextPage", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage + 1 > jTotallPages) {
            alert("己到最後一頁");
            return;
        }

        // 3.系統將jCurrentPage+1。
        jCurrentPage += 1;

        sDate = $('#sDateO').val();
        eDate = $('#eDateO').val();
        MessageValue = $('#MessageValue').val();
        NickName = $('#NickName').val();

        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMembermoveUrl,
            data: {
                MessageValue: MessageValue,
                NickName: NickName,
                sDate: sDate,
                eDate: eDate,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[會員調撥區]之商品清單區單按某一頁連結。
    $(document).on("click", "#MembermovePageList > .dropdown-item", event => {
        event.preventDefault();
        jCurrentPage = $(event.currentTarget).data("page");
        if (jTotallPages == 1) {
            alert("己到第一頁");
            return;
        };

        sDate = $('#sDateO').val();
        eDate = $('#eDateO').val();
        MessageValue = $('#MessageValue').val();
        NickName = $('#NickName').val();

        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page、。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMembermoveUrl,
            data: {
                MessageValue: MessageValue,
                NickName: NickName,
                sDate: sDate,
                eDate: eDate,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    //------------------------------------------20181217 YunQiWholesale 會員調撥區

    //20181223 ---棋
    //1.使用者在新增留言Model單按 送出
    $(document).on("click", "#btn-NewMembermove", function () {
        event.preventDefault();

        VersionId = parseInt($(this).data('versionid'));
        MessageTitle = $('#newMembermoveMessageTitle').val();
        MessageValue = $('#newMembermoveMessageValue').val();
        MemberMobile = jMemberMobile;

        $.ajax({
            type: "GET",
            cache: false,
            dataType: "json",
            url: InsertMessageManagement,
            data: {
                VersionId: VersionId,
                MessageTitle: MessageTitle,
                MessageValue: MessageValue,
                MemberMobile: MemberMobile,
            }
        })
            .done(data => {
                if (data == 0) {
                    alert("留言新增成功 !");
                    $('#newModal').modal("hide");
                }
                data == -3 ? (alert("系統錯誤，請稍後再試！")) : ("");
                data == -1 ? (alert("新增失敗，請稍後再試！")) : ("");
            })
            .fail(systemError);
    });

    //20181223 ---棋
    //1.使用者在留言區點選回復
    $(document).on("click", ".newReplyModal", function () {
        event.preventDefault();
        $('#ReplyVersionid').val($(this).data('messageid'));
        $('#newReplyModal').modal({ backdrop: "static" });
    });

    //20181223 ---棋
    //1.使用者在新增回復Model單按 送出
    $(document).on("click", "#btn-NewReplyMessage", function () {
        event.preventDefault();

        $.ajax({
            type: "GET",
            cache: false,
            dataType: "json",
            url: InsertReplyMessageManagement,
            data: {
                MessageId: $('#ReplyVersionid').val(),
                ReplyMessageValue: $('#newReplyMessageValue').val(),
                ReplyMobile: jMemberMobile,
            }
        })
            .done(data => {
                //console.log(data);
                if (data == 0) {
                    alert("回復成功 !");
                    $('#newReplyModal').modal("hide");
                }

                data == -1 ? (alert("新增失敗，請稍後再試！")) : ("");
                data == -2 ? (alert("重複留言，請5分鐘後再試！")) : ("");
                data == -3 ? (alert("系統錯誤，請稍後再試！")) : ("");
            })
            .fail(systemError);
    });

    //------------------------------------------20181217 YunQiWholesale 許願池
    //20181223 ---棋
    //1.使用者在[許願池]之商品清單區單按 Serrch
    $(document).on("click", "#btnSerrchWishipool", event => {
        event.preventDefault();
        // 3.系統將1輸入條件暫存在sDateO、eDateO並將jCurrentPage重設為1。
        jCurrentPage = 1;
        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、jProduct、jsDate、jeDate、1點按頁碼、jOrderId。

        sDate = $('#sDateO').val();
        eDate = $('#eDateO').val();
        MessageValue = $('#MessageValue').val();
        NickName = $('#NickName').val();

        //console.log(sDate);
        //console.log(eDate);
        //console.log(MessageValue);
        //console.log(NickName);

        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberWishipoolUrl,
            data: {
                MessageValue: MessageValue,
                NickName: NickName,
                sDate: sDate,
                eDate: eDate,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[許願池]之商品清單區單按前一頁連結。
    $(document).on("click", "#WishipoolPrePage", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage - 1 < 1) {
            alert("己到第一頁");
            return;
        }
        // 3.系統將jCurrentPage-1。
        jCurrentPage -= 1;

        sDate = $('#sDateO').val();
        eDate = $('#eDateO').val();
        MessageValue = $('#MessageValue').val();
        NickName = $('#NickName').val();

        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberWishipoolUrl,
            data: {
                MessageValue: MessageValue,
                NickName: NickName,
                sDate: sDate,
                eDate: eDate,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[許願池]之商品清單區單按下一頁連結。
    $(document).on("click", "#WishipoolNextPage", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage + 1 > jTotallPages) {
            alert("己到最後一頁");
            return;
        }

        // 3.系統將jCurrentPage+1。
        jCurrentPage += 1;

        sDate = $('#sDateO').val();
        eDate = $('#eDateO').val();
        MessageValue = $('#MessageValue').val();
        NickName = $('#NickName').val();

        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberWishipoolUrl,
            data: {
                MessageValue: MessageValue,
                NickName: NickName,
                sDate: sDate,
                eDate: eDate,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[許願池]之商品清單區單按某一頁連結。
    $(document).on("click", "#WishipoolPageList > .dropdown-item", event => {
        event.preventDefault();
        jCurrentPage = $(event.currentTarget).data("page");
        if (jTotallPages == 1) {
            alert("己到第一頁");
            return;
        };

        sDate = $('#sDateO').val();
        eDate = $('#eDateO').val();
        MessageValue = $('#MessageValue').val();
        NickName = $('#NickName').val();

        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、sDate、eDate、Page、。
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberWishipoolUrl,
            data: {
                MessageValue: MessageValue,
                NickName: NickName,
                sDate: sDate,
                eDate: eDate,
                Page: jCurrentPage,
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    //------------------------------------------20181217 YunQiWholesale 許願池

    //------------------------------------------20181217 YunQiWholesale 我的最愛

    //20181223 ---棋
    //1.使用者在[我的最愛]之商品清單區單按 Serrch
    $(document).on("click", "#btnSearchF", event => {
        event.preventDefault();
        // 3.系統將1輸入條件暫存在sDateO、eDateO並將jCurrentPage重設為1。
        jCurrentPage = 1;
        // 4.系統以ajax呼叫Get Controller Action【Member/Myfollower】，並傳送jMemberMobile、jProduct、jsDate、jeDate、1點按頁碼、jOrderId。

        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMyfavoriteUrl,
            data: {
                MemberMobile: jMemberMobile,
                Product: $('#fProduct').val(),
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[我的最愛]之商品清單區單按下一頁/前一頁/某一頁連結。
    $(document).on("click", "#MybtnNextPage", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage + 1 > jTotallPages) {
            alert("己到最後一頁");
            return;
        }
        // 3.系統將jCurrentPage+1。
        jCurrentPage += 1;
        // 4.系統以ajax呼叫Get Controller Action【Member/Myfavorite】，並傳送jMemberMobile、jProduct、1點按頁碼。
        jProduct = $("#fProduct").val();
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMyfavoriteUrl,
            data: {
                MemberMobile: jMemberMobile,
                Product: jProduct,
                Page: jCurrentPage
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[我的最愛]之商品清單區單按下一頁/前一頁/某一頁連結。
    $(document).on("click", "#MybtnPrePage", event => {
        event.preventDefault();
        // 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        if (jCurrentPage - 1 < 1) {
            alert("己到第一頁");
            return;
        }
        // 3.系統將jCurrentPage-1。
        jCurrentPage -= 1;
        // 4.系統以ajax呼叫Get Controller Action【Member/Myfavorite】，並傳送jMemberMobile、jProduct、1點按頁碼。
        jProduct = $("#fProduct").val();
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMyfavoriteUrl,
            data: {
                MemberMobile: jMemberMobile,
                Product: jProduct,
                Page: jCurrentPage
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    // 1.使用者在[我的最愛]之商品清單區單按下一頁/前一頁/某一頁連結。
    $(document).on("click", "#FPageList > .dropdown-item", event => {
        event.preventDefault();
        //// 2.系統判斷1<=jCurrentPage+1<=jTotallPages。
        //if (jCurrentPage - 1 < 1) {
        //    alert("己到第一頁");
        //    return;
        //}
        //// 3.系統將jCurrentPage-1。
        //jCurrentPage -= 1;
        jCurrentPage = $(event.currentTarget).data("page");
        // 4.系統以ajax呼叫Get Controller Action【Member/Myfavorite】，並傳送jMemberMobile、jProduct、1點按頁碼。
        jProduct = $("#fProduct").val();
        $.ajax({
            type: "GET",
            cache: false,
            dataType: "HTML",
            url: memberMyfavoriteUrl,
            data: {
                MemberMobile: jMemberMobile,
                Product: jProduct,
                Page: jCurrentPage
            }
        })
            .done(memberComponent)
            .fail(systemError);
    });
    //------------------------------------------20181217 YunQiWholesale 我的最愛

    //------------------------------------------20181217  _FooterPartial
    $('.footer-box').find('.nav-link').on('click', (event) => {
        event.preventDefault();
        const linkno = $(event.currentTarget).data('no');

        //品牌故事
        if (linkno === 1) {
            $('#BrandStory').addClass('active');
        }
        //會員中心
        if (linkno === 2) {
            $.ajax({
                type: "GET",
                cache: false,
                dataType: "HTML",
                url: memberUrl
            })
                .done(memberPage)
                .fail(systemError);
        }
        //會員等級
        if (linkno === 3) {
            $('#MemberLevel').addClass('active');
        }
        //Q&A
        if (linkno === 4) {
            $('#QuestionAnswer').addClass('active');
        }
        //購物流程
        if (linkno === 5) {
            $('#ShoppingProcess').addClass('active');
        }
        //maichangxuzhi
        //if (linkno === 7) {
        //    $('#ShoppingKnows').addClass('active');
        //}
        //操作指南
        if (linkno === 8) {
            $('#caozuozhinan').addClass('active');
        } 
        if (linkno === 9) {
            $('#shoujicaozuo').addClass('active');
        }
        if (linkno === 7) {
            $('#shoujishengji').addClass('active');
        }
        //購物車
        if (linkno === 6) {
            $.ajax({
                type: "POST",
                cache: false,
                dataType: "HTML",
                url: cartUrl,
                data: {
                    MemberMobile: jMemberMobile,
                    Carts: carts
                }
            })
                .done(cartPage)
                .fail(systemError);
        }
    });

    //關閉
    $('.btnFooterDetailClose').on('click', function () {
        var id = "#" + $(this).closest("div").attr('id');
        $(id).removeClass('active');
    });
    //------------------------------------------20181217  _FooterPartial

    //20181226 ---棋
    //訂購完成後回會員中心-訊息中心
    $(document).on("click", "#GetGoMember", function () {
        event.preventDefault();
        $.ajax({
            type: "Post",
            cache: false,
            dataType: "HTML",
            url: memberUrl,
            data: {
                ContactData: contactData,
                OrderId: memberUrl,
                OrderStateId: 1,
                MemberMobile: jMemberMobile
            }
        })
            .done(homePage)
            .fail(systemError)
    });

    //20190104 ---棋
    //------------------------------------------20190104  綠界API
    window.addEventListener('message', function ECPAYmessage(e) {
        var ret = JSON.parse(e.data);
        // 1.使用者在購物車確認付款頁點按某個付款按鈕並確認付款。
        if (ret.RtnCode == 1) {
            // 2.系統在Client端的message事件判斷RtnCode===1。
            // 3.系統顯示信用卡付款成功。
            alert("信用卡付款成功！");
            CloseIframe("CREDIT");
        }
        else if (ret.RtnCode == 2) {
            // 2a.系統在Client端的message事件判斷RtnCode===2。
            //  2a-1.系統顯示ATM取號成功。
            alert("ATM取號成功！");
            CloseIframe("ATM");
            //  2a-2.回4。
        }
        else if (ret.RtnCode == 10100073) {
            // 2b.系統在Client端的message事件判斷RtnCode===10100073。
            //  2b-1.系統顯示超商繳款取號成功。
            alert("超商繳款取號成功！");
            CloseIframe("CVS");
            //  2b-2.回4。
        }
        else {
            // 2c.系統在Client端的message事件判斷RtnCode!==1/2/10100073。
            //  2c-1.系統顯示執行失敗，錯誤代碼。
            alert("執行失敗，錯誤代碼：" + ret.RtnCode);
            //  2c-2.結束。
            return;
        }

        // 4.系統以ajax呼叫Post Action【Cart/Success】，並傳送ordeerId，contactData。
        $.ajax({
            type: "Post",
            cache: false,
            dataType: "HTML",
            async: false,
            url: cartSuccessUrl,
            data: {
                ContactData: contactData,
                OrderId: $('#ECPAYOrderId').val(),
                MemberMobile: jMemberMobile,
                //20181206更新 ---棋
                //OrderStateId: 2,
            }
        })
            .done(data => {
                $("#mainContent").empty();
                $("#mainContent").html(data);
            })
            .fail(SystemError => { alert("系統錯誤，請稍後再試！") })
    }, false);
    //------------------------------------------20190104  綠界API

    // 1.使者在購物車確認付款頁點按完成。
    $(document).on("click", "#FinishCart", function (event) {
        event.preventDefault();
        // 2.使用者確認。
        if (!confirm("確定完成訂單嗎？"))
            return;
        // 2.系統以ajax呼叫Post Action【Cart/Success】，並傳送ordeerId，contactData。

        $.ajax({
            type: "Post",
            cache: false,
            dataType: "HTML",
            url: cartSuccessUrl,
            data: {
                ContactData: contactData,
                OrderId: $(this).data('orderid'),
                OrderStateId: 1,
                MemberMobile: jMemberMobile
            }
        })
            .done(success)
            .fail(systemError)
        function success(data) {
            $("#mainContent").empty();
            $("#mainContent").html(data);
        }
    });

   
}
