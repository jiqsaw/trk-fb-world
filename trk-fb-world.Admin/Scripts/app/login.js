$(document).ready(function () {

    MoveToCenter();    

});

$(window).resize(function () {

    MoveToCenter();

});

function MoveToCenter() {
    $('.login').center();
}