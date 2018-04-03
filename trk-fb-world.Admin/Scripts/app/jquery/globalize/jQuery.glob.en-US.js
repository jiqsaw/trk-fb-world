(function($) {
    var cultures = $.cultures,
        en = cultures.invariant,
        standard = en.calendars.standard,
        culture = cultures["en-US"] = $.extend(true, {}, en, {

            calendars: {
                standard: $.extend(true, {}, standard, {
                    patterns: {
                        d: "dd/MM/yyyy",
                        D: "dd MMMM yyyy dddd",
                        t: "HH:mm",
                        T: "HH:mm:ss",
                        f: "dd MMMM yyyy dddd HH:mm",
                        F: "dd MMMM yyyy dddd HH:mm:ss",
                        M: "dd MMMM",
                        Y: "MMMM yyyy"
                    }
                })
            }

    }, cultures["en-US"]);
    culture.calendar = culture.calendars.standard;
})(jQuery);