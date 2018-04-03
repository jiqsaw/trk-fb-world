$(function () {
    SpecialFormStyles();
    faq();

    $(".ajax").colorbox();
    $(".faqContainer").hide();
    tooltipsy();

    csiPopupWindow();
});

function SpecialFormStyles() {

    $("input[type='radio']").live("click", function (e) {
        $(this).parents('.rdGroup').find("label").removeClass("rd-active");
        $(this).parents('.rdGroup').find("input[type='radio']").removeAttr("checked");
        $(this).next().toggleClass("rd-active");
        $(this).attr("checked", "checked");
    });


    //Checkbox
    //$("input[type='checkbox']").button();
    $("input[type='checkbox']:checked").next("label").toggleClass("check-active");
    $("input[type='checkbox']").click(function (e) {
        if ($(this).attr("checked") != "checked")
            $(this).removeAttr('checked');
        else
            $(this).attr('checked', 'checked');

        $(this.nextElementSibling).toggleClass("check-active");

    });

    radioChecked();
}

function radioChecked() {
    $("input[type=radio]:checked").next("label").attr("class", "rd-active");
}

function autoComplete(e, dataSource, placeHolderText) {
    $(e).kendoAutoComplete({
        dataSource: dataSource,
        filter: "startswith",
        placeholder: placeHolderText,
        separator: ", "
    });
}

function faq() {
    $("#faq").click(function () {
        var c = $(this).attr("class");
        if (c == undefined) {
            $(".faqContainer").html(getLoading2());
            $.ajax({
                url: "/Faq/",
                success: function (data) {
                    $(".faqContainer").html(data);
                    PageRender();
                }
            });
            $(this).attr("class", "sss");
            $(".faqContainer").css("display", "block");
            
            setTimeout(function () {
                $(".nano3").nanoScroller({ alwaysVisible: true });
            }, 500);
        }
        else {
            $(this).removeAttr("class");
            $(".faqContainer").css("display", "none");
            $(".faqContainer").html('');
        }
    });
}

function faqClose() {
    $("#faq").removeAttr("class");
    $(".faqContainer").css("display", "none");
}

function faqQuestionOpen(Id) {
    $.ajax({
        url: "/Faq/Detail/",
        data: { "id": Id },
        dataType: "json",
        success: function (response) {
            $("#faqSearch").hide();
            var temp = $("#templateDetail").html();
            temp = temp.replace("#= Title #", response.Title);
            temp = temp.replace("#= Content #", response.Content);
            $("#questions").hide();
            $("#answer").html(temp).fadeIn('slow');
            $(".answerBack").css("display", "block");
            $(".nano3").nanoScroller({ alwaysVisible: true });
        }
    });
}

function faqQuestionClose() {
    $(".answerBack>.back").click(function () {
        $(".answer").fadeOut('slow');
        $(".faqClose").css("margin-top", "-56px");
        $("#questions").fadeIn('slow');
        $(".answerBack").css("display", "none");
        $("#faqSearch").show();

        $(".nano3").nanoScroller({ alwaysVisible: true });
    });   
}

function tooltipsy() {
    $('.ttT').tipsy({ gravity: 's', fade: true, html: true, width:'300px' });
    $('.ttB').tipsy({ gravity: 'n', fade: true, html: true });
    $('.ttL').tipsy({ gravity: 'e', fade: true, html: true });
    $('.ttR').tipsy({ gravity: 'w', fade: true, html: true });
}

function getLoading2() {
    var template = "<ins class=\"space125\"></ins><center><img src=\""+_urlStatic+"/images/icons/load.gif\" id=\"faqLoading\" /></center>";
    return template;
}

function jsRun(file) {
    var script = document.createElement('script');
    script.type = 'text/javascript';
    script.src = file;
    document.getElementsByTagName('head')[0].appendChild(script);
}

function processResult(type, message, obj) {
    $(obj).hide();
    if (type == 1) {
        $(obj).html("<section class=\"error\">" + message + "</section>");
    }
    else if (type == 2) {
        $(obj).html("<section class=\"success\">" + message + "</section>");
    }
    else if (type == 3) {
        $(obj).html("<section class=\"successBlue\">" + message + "</section>");
    }
    $(obj).fadeIn();
}

function scrollTop() {
    $("html,body").stop().animate({ scrollTop: "0" }, 1000);
}

function PageRender() {
    setTimeout(function () {
        SpecialFormStyles();
        $(".ajax").colorbox();
        tooltipsy();
        if (navigator.userAgent.toLowerCase().indexOf("msie") != -1) {
            ieFunctions();
        }
    }, 500);
    
}

function appSubiFrameLoaded() {
    $('[name^=appSubIFrame]').fadeIn('slow');
}


var csiPopup = null;
function csiPopupWindow() {
    $('.csiLink').live('click', function (e) {
        var href = $(this).attr("href");

        csiPopup = window.open(href, 'popUpWindow', 'height=768,width=1024,left=10,top=10,resizable=yes,scrollbars=yes,toolbar=yes,menubar=no,location=no,directories=no,status=yes');
        csiPopup.focus();

        e.preventDefault();

    });
}