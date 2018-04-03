$(document).ready(function () {
    $("select").kendoDropDownList();

    formValidate();

    function formValidate() {
        $("#formLogin").validationEngine({ validationEventTrigger: "keyup blur" });
    }

    if (self == top) {
        $("body").attr("style", "background-color:#1e45a2 !important;");
    }
});