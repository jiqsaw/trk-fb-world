/// <reference path="../_references.js" />

function AddDdlInitial() {
    $('select').prepend(new Option(_DdlInitial, _DdlInitialValue));
}

function ShowError() { $('.error').show(); }

function SortDisable() {
    $('.grid tbody:first-child tr:first-child a').attr('href', 'javascript:;');
    $('.grid tbody:first-child tr:first-child a').addClass('disabled');
}

function ChangePageBegin() {
    $("#PageBody").hide();
}

function ChangePageSuccess() {
    $("#PageBody").fadeIn(500);
}

function NoImage(e) {
    try {
        $(e).attr("src", "/images/app_utils/noimage.jpg");
        if ($(e).parent("a").length) {
            $(e).parent("a").attr("href", "javascript:;");
            $(e).parent("a").removeClass("cb").removeClass("cboxElement");
            $(e).parent("a").addClass("disable");
        }
    }
    catch (e) { }
}

function LoadingBegin() { if ($('#LoadingPage').length) $('#LoadingPage').show(); }
function LoadingEnd() { if ($('#LoadingPage').length) $('#LoadingPage').hide(); }

function SelectBindSubPlace(eId, parentId, selectedValue) {
    LoadingBegin();
    if (parentId != null && parentId != '') {
        $.getJSON('/Place/GetAllByParentId', { parentId: parentId }, function (ds) {
            SelectDataBind("#" + eId, ds, "Id", "PlaceName", selectedValue);
            LoadingEnd();
        });
    }
    else {
        SelectDataBind("#" + eId, null);
        LoadingEnd();
    }
    
}

function FormOnSuccess() {
    $(document).scrollTop(0);
}

function Sortable(controllerName, parentOrder) {
    $(".sortable").sortable({
        handle: ".hand",
        forcePlaceholderSize: true,
        opacity: .6,
        placeholder: "ui-state-highlight",
        update: function () {

            var values = $(this).sortable('toArray');

            LoadingBegin();

            var path = '/' + controllerName + '/UpdateOrders?values=' + values;

            if (parentOrder != undefined)
                path += "&parentOrder=" + parentOrder;

            $.getJSON(path, null, function (ds) {
                LoadingEnd();
            });

        }

    });
}