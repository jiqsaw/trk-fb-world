// -- Textbox ta imleç i başa almak -- //
(function ($) {
    $.fn.caret = function (pos) {
        var target = this[0];
        if (arguments.length == 0) { //get
            if (target.selectionStart) { //DOM
                var pos = target.selectionStart;
                return pos > 0 ? pos : 0;
            }
            else if (target.createTextRange) { //IE
                target.focus();
                var range = document.selection.createRange();
                if (range == null)
                    return '0';
                var re = target.createTextRange();
                var rc = re.duplicate();
                re.moveToBookmark(range.getBookmark());
                rc.setEndPoint('EndToStart', re);
                return rc.text.length;
            }
            else return 0;
        }

        //set
        var pos_start = pos;
        var pos_end = pos;

        if (arguments.length > 1) {
            pos_end = arguments[1];
        }

        if (target.setSelectionRange) //DOM
            target.setSelectionRange(pos_start, pos_end);
        else if (target.createTextRange) { //IE
            var range = target.createTextRange();
            range.collapse(true);
            range.moveEnd('character', pos_end);
            range.moveStart('character', pos_start);
            range.select();
        }
    }
})(jQuery)


// -- SAYFAYI ORTALAMA -- //
jQuery.fn.center = function () {
    this.css("position", "absolute");
    this.css("top", (($(window).height() - this.outerHeight()) / 2) + $(window).scrollTop() + "px");
    this.css("left", (($(window).width() - this.outerWidth()) / 2) + $(window).scrollLeft() + "px");
    return this;
}


// -- RANDOM NUMBER -- //
jQuery.extend({
    random: function (X) {
        return Math.floor(X * (Math.random() % 1));
    },
    randomBetween: function (MinV, MaxV) {
        return MinV + jQuery.random(MaxV - MinV + 1);
    }
});



$.fn.hasAttr = function (name) {
    return this.attr(name) !== undefined;
};