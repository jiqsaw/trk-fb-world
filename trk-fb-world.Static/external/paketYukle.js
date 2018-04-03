$(document).ready(function () {

    //if (parent != null)
        //parent.appSubiFrameLoaded();

    $("select").kendoDropDownList();

    if (self == top) {
        $("body").attr("style", "background-color:#1e45a2 !important;");
    }
});