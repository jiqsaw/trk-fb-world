$(function () {

    $.preferCulture(_acceptLanguage);
    kendo.culture(_acceptLanguage);

    //Tell the validator that we want numbers parsed using Globalize.js
    $.validator.methods.number = function (value, element) {
        return !isNaN($.parseFloat(value));
    }

    //Tell the validator that we want dates parsed using Globalize.js
    $.validator.methods.date = function (value, element) {
        return !isNaN($.parseDate(value));
    }

    //Fix the range to use globalized methods
    jQuery.extend(jQuery.validator.methods, {
        range: function (value, element, param) {
            //Use the Globalization plugin to parse the value
            var val = $.parseFloat(value);
            return this.optional(element) || (val >= param[0] && val <= param[1]);
        }
    });

});
