$(document).ready(function () {
    ieFunctions();
});

function ieFunctions() {
    if (navigator.userAgent.toLowerCase().indexOf("msie") != -1) {
        allPlaceHolder();
        formLabels();
    }
}

function allPlaceHolder() {
    $('input').each(function () {
        if ($(this).attr("placeholder") != undefined) {
            var placeHolder = $(this).attr("placeholder");
            $(this).removeAttr("placeholder");
            $(this).attr("value", placeHolder);
            $(this).attr("onblur", "if(this.value=='')this.value='" + placeHolder + "';");
            $(this).attr("onfocus", "if(this.value=='" + placeHolder + "')this.value='';");
        }
    });
}

function formLabels() {
    $("input[type='radio']").next("label").addClass("lb1");
    $("input[type='checkbox']").next("label").addClass("lb2");

    $(".lb1").click(function (e) {
        $(this).prev().click();
    });
}

if (typeof (console) == "undefined") { console = {}; }
if (typeof (console.log) == "undefined") { console.log = function () { return 0; } }