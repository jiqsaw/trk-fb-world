$(function () {

    FormStyle();

});

function FormStyle() {
    $('input, textarea, select').not(":[data-val-required]").not(":[type=submit]").addClass('opt').prev("label").fadeTo(1700, .5);
}