$(document).ready(function () {

    //if (parent != null)
        //parent.appSubiFrameLoaded();

    $("select").kendoDropDownList();

    formValidate();

    function formValidate() {
        //$("#formLogin").validationEngine();
    }

    if (self == top) {
        $("body").attr("style", "background-color:#1e45a2 !important;");
    }
});