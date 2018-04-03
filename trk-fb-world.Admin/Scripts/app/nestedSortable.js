$(document).ready(function () {

    Sort();

});

function SortToggleSetup() {

    $("ol.sortable ol").each(function (index, domEle) {
        var olTemp = $(this)
        var prev = $(this).prev();
        $(this).remove();

        $(prev).append(olTemp);
    });


    //$('ol.sortable ol').slideToggle();
    
    $('ol.sortable li').children('ol').before("<aside><a class='mute DESC' href='javascript:;'></a></aside>");

    $('ol.sortable li').has('ol').children('aside').children('a.mute').show();

    $('ol.sortable a.mute').click(function () {
        $(this).parent().parent().children('ol').slideToggle();
        $(this).toggleClass('mute');
        $(this).toggleClass('muteActive');
    });
}

function Sort() {
    
    SortToggleSetup();

    $('ol.sortable').nestedSortable({
        disableNesting: 'no-nest',
        forcePlaceholderSize: true,
        handle: '.handle',
        helper: 'clone',
        items: 'li',
        maxLevels: 20,
        opacity: .6,
        placeholder: 'placeholder',
        revert: 250,
        tabSize: 25,
        tolerance: 'pointer',
        toleranceElement: '> div',
        update: function () {

            var order = $(this).sortable('serialize');

            $('#hdItemOrders').val(order);
            $('#objOrderValues').click();

        }
    });

    $('.handle').mousedown(function () { $(this).parent().addClass("drag"); });
    $('.handle').mouseout(function () { $(this).parent().removeClass("drag"); });
}

function SortableHide() {
    $('.handle').removeClass("handle");
}