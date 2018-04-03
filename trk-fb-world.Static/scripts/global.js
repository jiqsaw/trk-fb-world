/// <reference path="_references.js" />

$(function () {
    PageHandler();
    OffersAnimate();
    Tooltip();
    generateFriend();
    talkTabClick();
});

function MaxCharacter(_txt, _remaining, _max) {
    var CommentLength = parseInt($("#"+_txt).val().length);
    var maxlength = _max;
    var remaining = maxlength - CommentLength;

    if (CommentLength > maxlength) {
        $("#"+_txt).val($("#"+_txt).val().substring(0, maxlength));
        ("#"+_remaining).html("0");
        $("#" + _remaining).css("color", "#A9B2D4");
    }
    else {
        $("#"+_remaining).html(remaining);

        if (remaining < 10) {
            $("#" + _remaining).css("color", "#ff346d");
        }
        else if (remaining < 30) {
            $("#"+_remaining).css("color", "#ffa200");
        }
        else {
            $("#" + _remaining).css("color", "#A9B2D4");
        }
    }
}

function smsSentKeyUp(_txt) {
    var Length = parseInt($("#" + _txt).val().length);
    var SmsNumber = parseInt($("#smsNumber").html());
    $("#charLeft").html(Length);
    SmsNumber = parseInt(Length / 160)+1;
    if (Length == 0) {
        SmsNumber = 0;
    }
    $("#smsNumber").html(SmsNumber);
    $("#SMSNumber").val(SmsNumber);
    $("#CharNumber").val(Length);
}

function RateGenerate(Id, Full, FullText) {
    $("#" + Id).addClass("rateBar");
    var barClass = "";
    var percent = "%";
    Full = Full.replace(percent, "");
    barClass = "rateBarGreen";

    $("#" + Id).html("<div class=\"" + barClass + "\" style=\"width:0%;\"></div>");

    if (Full > 100) { Full = 100; }

    setTimeout(function () {

        var mainBarWidth = 0;
        if (Full < 30) {
            mainBarWidth = Full;
        }
        else {
            mainBarWidth = Full - 29;
            mainBarWidth = Full - mainBarWidth;
        }
        $("#" + Id + ">." + barClass + "").animate({
            width: mainBarWidth + percent
        }, 500, function () {


            if (Full > 29) {
                    var barWidth = 0;
                    if (Full < 90) {
                        barWidth = Full;
                    }
                    else {
                        barWidth = Full - 29;
                    }

                    $("#" + Id).append("<div class=\"rateBarYellow\" id=\"yellow_" + Id + "\" style=\"-moz-opacity:0;opacity:0;width:" + mainBarWidth + percent + "; position: absolute; \"></div>");
                    
                    $("#" + Id + ">." + barClass + "").animate({
                        width: barWidth + percent,
                        opacity:0
                    }, 500);
                   
                    $("#" + Id + ">#yellow_" + Id + "").animate({
                        width: barWidth + percent,
                        opacity:1
                    }, 400, function () {

                        if (Full > 89) {
                                var barPinkWidth = 0;
                                if (Full < 100) {
                                    barPinkWidth = Full;
                                }
                                else {
                                    barPinkWidth = Full;
                                }
                                $("#" + Id).append("<div class=\"rateBarPink\" id=\"pink_" + Id + "\" style=\"-moz-opacity:0; opacity:0; width:" + barWidth + percent + ";position: absolute;\"></div>");
                                $("#" + Id + ">#yellow_" + Id + "").animate({
                                    width: barPinkWidth + percent,
                                    opacity: 0
                                }, 500);

                                $("#" + Id + ">#pink_" + Id + "").animate(
                                {
                                    width: barPinkWidth + percent,
                                    opacity:1
                                }, 300);
                        }

                    });
            }

        });

        if (FullText != undefined) {
            FullText = FullText.replace("%", "");
            if (parseInt(FullText) < 0)
                FullText = 0;
          
            $("#" + Id).append("<div class=\"fIta\" style=\"position: absolute; z-index: 5; line-height: 21px; text-indent: 7px; display:none;\" id=\"barText_" + Id + "\">" + FullText + "%</div>");
            $("#barText_" + Id).fadeIn('slow');
        }
    }, 700);
}

function topLinkDeactive() {
    $('.clickToTalk>ul>li>a').each(function () {
        var aClass = $(this).attr('class');
        aClass = aClass.replace(" active", "");
        $(this).attr('class', aClass);
    });
}

function pageNavDeactive() {
    $('.pageNav').each(function () {
        
        $(this).attr("class", $(this).attr("class").replace(" active", ""));
        
    });
}

function MainPageOpen() {
    $(".tabs nav .pageNav").eq(0).click();
}

function TopPageOpen(Page) {
    var PagePath;
    var PageQuery;
    if (Page.indexOf('?') != -1) {
        var PageSplit = Page.split('?');
        PagePath = PageSplit[0].replace("/", "");
        PageQuery = PageSplit[1];
        $("a[data-ga='" + PagePath + "']").attr("data-ga", Page).attr("data-page", Page).click();
        $("a[data-ga='" + Page + "']").attr("data-ga", PagePath).attr("data-page", PagePath);
    }
    else {
        $("a[data-ga='" + Page + "']").click();
    }
    
    $.colorbox.close();
}

function PageHandler() {
    $('.pageNav').live('click', function (event) {
        if (event.handled !== true) {
            faqClose();

            var dataPage = $(this).attr("data-page");
            if (dataPage != undefined) {

                $('.pageBody').css('visibility', 'hidden'); 

                $('.pageLoading').fadeIn('slow');
                //var path = "/" + dataPage + "?v=" + randomNumber(500);
                var path = "/" + dataPage;
                if (path.indexOf("?") != -1) {
                    path = path;
                }
                else {
                    path = path + "?v=" + randomNumber(500);
                }
                pageNavDeactive();
                topLinkDeactive();

                PageTabClicked($(this));


                $('.pageBody').load(path, function (responseText, textStatus, req) {

                    $('.pageLoading').hide();

                    if (textStatus == "error") {
                        $.colorbox({ href: "/Error/Internal" });
                    }
                    else {
                        $('.pageBody').fadeOut('fast', function () {
                            $('.pageBody').css('visibility', 'visible');
                            $('.pageBody').fadeIn('slow', 'easeOutQuad');
                        });

                        $(".ajax").colorbox();

                        //if (FB != null) {
                        //    FB.Canvas.scrollTo(0, 0);
                        //}

                        PageRender();

                        //if (FB != null) {
                        //    $('html,body').animate(
                        //      { scrollTop: $(".pageBody").offset().top },
                        //      {
                        //          duration: 1000, step: function (top_offset) {
                        //              FB.Canvas.scrollTo(0, top_offset);
                        //          }
                        //      }, iFrameHeightRender);
                        //}

                    }
                    iFrameHeightRender();
                    
                });

            }
            event.handled = true;
        }
        return false;
    });


    $('.tabs nav a').click(function () {

    });

    
    $('.clickToTalk ul li a').click(function () {
        faqClose();
        var dataPage = $(this).attr("data-page");
        if (dataPage != undefined) {
            topLinkDeactive();
            var navClass = $(this).attr('class');
            navClass = navClass.replace("topNav", "").replace("active", "");
            $(this).removeAttr('class');

            $(this).attr("class", "topNav " + navClass + " active");
        }
    }); 
}

function PageTabClicked(sender) {
    faqClose();
    var dataPage = $(sender).attr("data-page");
    var dataActivePage = $(sender).attr("data-tab-page");
    
    if (dataActivePage != undefined) {
        dataPage = dataActivePage;
    }

    if (dataPage != undefined) {
        var navClass = $(".tabs nav a[data-page='" + dataPage + "']").attr("class");
        if (navClass != undefined) {
            $(".tabs nav a[data-page='" + dataPage + "']").attr("class", navClass + " active");
        }
        else {
            navClass = $(".clickToTalk ul li a[data-page='" + dataPage + "']").attr("class");
            if (navClass != undefined) {
                $(".clickToTalk ul li a[data-page='" + dataPage + "']").attr("class", navClass + " active");
            }
        }
    }
    
}

function Tooltip() {
    $(".tbutton").click(function () {
        var tooltip = $(this).parent().find(".tooltip");
        if (tooltip.css("display") != "block") {
            $(this).parent().find(".tooltip").stop().hide().fadeIn('slow');
        }
        else {
            $(this).parent().find(".tooltip").stop().fadeOut('slow');
        }
    });
    $(".tbutton").mouseout(function () {
        $(this).parent().find(".tooltip").stop().fadeOut('slow');
    });

    $("#birthdayTooltipLink").live("mouseover", function () {
        setTimeout(function () {
            $("#birthdayTooltip").fadeIn('slow');
        }, _animateSpeed * 250);
    });
    $("#birthdayTooltipLink").live("mouseout", function () {
        setTimeout(function () {
            $("#birthdayTooltip").stop().fadeOut('slow');
        }, _animateSpeed * 300);
    });

    $(".iframe .rdGroup label").live("mouseover", function () {
        $(this).children("span.narTooltip").show();
    });
    $(".iframe .rdGroup label").live("mouseout", function () {
        $(this).children("span.narTooltip").hide();
    });
}

function OffersAnimate() {
    $(".offers>.f_menu>a").mouseover(function () {
        $($(this).parent().find("img")).animate({
            width: '103px',
            'margin': '10px 0px 10px 0px'
        }, _animateSpeed * 250).stop();
    });
    $(".offers>.f_menu>a").mouseout(function () {
        $($(this).parent().find("img")).stop().animate({ 
            width: '97px',
            'margin': '20px 0px 0px 0px'
        }, _animateSpeed * 300);
    });
}

function generateFriend(friendName, friendSurname, friendPhoto) {
    var scriptTemplate = kendo.template("#= firstName #<br />#= lastName #");
    var scriptData = { firstName: friendName, lastName: friendSurname };

    return "<a class=\"lProfile ajax\" href=\"partial/arkadasDetay.html\"><figure class=\"fLeft user userMedium\">"
            + "<img src=\"" + friendPhoto + "\" border=\"0\" />"
            + "</figure>"
            + "<p class=\"friendName\">" + scriptTemplate(scriptData) + "</p></a>"
            + "<a href=\"partial/ceptenAra.html\" class=\"friendCall ajax\">ara</a>";
}

function tabOpen(allTab, tabId) {
    $(allTab).css("display", "none");
    $(tabId).hide().fadeIn('1000');
}

function talkTabClick() {
    $(".talkTabs nav a").click(function () {
        var Type = $(this).attr("data-id");
        var Div = $(this).attr("data-div");
        $("#" + Div).html('');
        $(".talkTabs nav a").removeClass("active");
        $(this).addClass("active");

        friendsTalk(Type, Div);
    });
}

function invoiceTabOpen(TabId) {

    var onTab = parseInt(TabId) - 1;

    var containerWidth = 0;
    var firstChildrenWidth = 0;
    

    var dataLoadPage = $("a[href='javascript:invoiceTabOpen(" + TabId + ");']").attr("data-load-page");
    if (dataLoadPage != undefined) {

        var contentId = null;
        if (TabId == 0) {
            contentId = "invoiceDetail";
        }
        else if (TabId == 2) {
            contentId = "analysisDetail";
        }

        $("#" + contentId).load("/Global/LoadingSmall", function () {

            $("#" + contentId).load(dataLoadPage, function (responseText, textStatus, req) {


                $(this).hide().fadeIn();


                

                $("#invoiceTabCont").children().each(function () {
                    containerWidth = containerWidth + parseInt($(this).css("width").replace("%", "").replace("px", ""));
                    if (firstChildrenWidth == 0) {
                        firstChildrenWidth = parseInt($(this).css("width").replace("%", "").replace("px", ""));
                    }
                });
                containerWidth = (parseInt(containerWidth) - firstChildrenWidth + 10) * TabId;

                if (onTab > 0) {
                    for (var i = 0; i < onTab; i++) {
                        $('.invoiceTab').eq(i).animate({
                            marginLeft: '-' + containerWidth / parseInt(onTab + 1) + 'px'
                        }, 500);
                    }
                }

                $('.invoiceTab').eq(onTab).animate({
                    marginLeft: '-' + containerWidth + 'px'
                }, 500);

                $('.invoiceTab').eq(TabId).stop(false, false).animate({
                    marginLeft: '0px'
                }, 500);

                $(".invoicePoints nav a").removeClass("active");
                $(".invoicePoints nav a").eq(TabId).addClass("active");

                invoiceTabHeightRender(TabId);
            });

        });

    }
    else {

        $("#invoiceTabCont").children().each(function () {
            containerWidth = containerWidth + parseInt($(this).css("width").replace("%", "").replace("px", ""));
            if (firstChildrenWidth == 0) {
                firstChildrenWidth = parseInt($(this).css("width").replace("%", "").replace("px", ""));
            }
        });
        containerWidth = (parseInt(containerWidth) - firstChildrenWidth + 10) * TabId;

        if (onTab > 0) {
            for (var i = 0; i < onTab; i++) {
                $('.invoiceTab').eq(i).animate({
                    marginLeft: '-' + containerWidth / parseInt(onTab + 1) + 'px'
                }, 500);
            }
        }

        $('.invoiceTab').eq(onTab).animate({
            marginLeft: '-' + containerWidth + 'px'
        }, 500);

        $('.invoiceTab').eq(TabId).stop(false, false).animate({
            marginLeft: '0px'
        }, 500);

        $(".invoicePoints nav a").removeClass("active");
        $(".invoicePoints nav a").eq(TabId).addClass("active");

        invoiceTabHeightRender(TabId);
    }

    PageRender();
}

function invoiceTabActive() {
    $(".invoicePoints nav a").click(function () {
        $(".invoicePoints nav a").removeClass("active");
        $(this).addClass("active");
    });
}

function invoiceTabHeightRender(TabId) {
    setTimeout(function () {
        var tabHeight = parseInt($('.invoiceTab').eq(TabId).css("height").replace("%", "").replace("px", "")) + 10;
        $('#invoiceContainer').stop(false, false).animate({
            height: tabHeight + 'px'
        }, 200, function () {
            iFrameHeightRender();
        });
    }, 500);
}

function friendsCallDetails(Type, Id) {
    $.each(friendNames, function (i, v) {
        var temp = $("#friendTemplate").html();
        temp = temp.replace("#-- id --#", "f" + i);
        temp = temp.replace("#-- username --#", friendNames[i]);
        temp = temp.replace("#-- profile --#", friendProfiles[i]);
        temp = temp.replace("#-- minute --#", friendMinutes[i]);
        temp = temp.replace("#-- sms --#", friendSms[i]);
        temp = temp.replace("#-- minuteRate --#", "0%");
        temp = temp.replace("#-- smsRate --#", "0%");

        var datas = $("#" + Id);
        datas.html(datas.html() + temp);

        if (Type == 1) {
            $("#" + Id + " #f" + i).children().children("._contSms").css("display", "none");
        }
        else if (Type == 2) {
            $("#" + Id + " #f" + i).children().children("._contCall").css("display", "none");
            $("#" + Id + " #f" + i).children().children(".h2").css("display", "none");
        }

    });

    $.each(friendNames, function (i, v) {
        $("#" + Id + " #f" + i).children().children("._contSms").children().children(".rateBarGreenSmall").animate({
            width: friendSmsRates[i]
        }, 500);

        $("#" + Id + " #f" + i).children().children("._contCall").children().children(".rateBarYellowSmall").animate({
            width: friendMinuteRates[i]
        }, 500);
    });
}

function partialViewLoad(contentId, partialUrl, hasLoad) {

    if (hasLoad == undefined) {

        $("#" + contentId).load("/Global/LoadingSmall", function () {

            $("#" + contentId).load(partialUrl, function (responseText, textStatus, req) {
                $(this).hide().fadeIn();
                if (textStatus == "error") {
                    partialError(contentId);
                    return false;
                }
                else { return true; }
                iFrameHeightRender();
            });

        });
    }
    else {

        if (hasLoad == false) {
            $("#" + contentId).load(partialUrl, function () {
                $(this).hide().fadeIn();
                iFrameHeightRender();
                return true;
            });
        }

    }
}

function partialError(contentId) {
    $("#" + contentId).fadeOut('fast');

    setTimeout(function () {
        
        $("#" + contentId).load("/Global/PartialError", function (responseText, textStatus, req) {
            $("#" + contentId).fadeIn('slow');
        });

    }, 500);
}

function CharLength(obj, addObj, maxChar) {
    var objText = $("#" + obj).html();
    var remaining = parseInt(maxChar-objText.length);
    $("#" + addObj).html(remaining);
}