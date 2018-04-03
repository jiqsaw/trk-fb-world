/// <reference path="../_references.js" />

var grid = null;

$(document).ready(function () {

    grid = $('#' + _kendoGridName);

    if (grid.length) {
        LoadingBegin();
        kGridSearch();
    }

});

(function ($) {

    $.fn.kendoDdlVal = function (value) {
        var ddl = this.data("kendoDropDownList");
        ddl.value(value);
    };

    $.fn.kendoDdlRender = function () {
        var ddl = this.data("kendoDropDownList"),
            popup = ddl.popup,
            element = popup.wrapper[0] ? popup.wrapper : popup.element;

        //remove popup element;
        element.remove();

        //unwrap element
        ddl.element.show().insertBefore(ddl.wrapper);
        ddl.wrapper.remove();

        ddl.element.removeData("kendoDropDownList");

        this.kendoDropDownList();
    };

})(jQuery);

function kGridOnDataBound(arg) {
    
    arg.sender.options.editable.confirmation = _kendoDeleteConfirmMsg;
    
    $("#" + _kendoGridName + " table tr td a.cb").has("img").colorbox();

    LoadingEnd();
    $('#Grid').show()

    $('.searchContainer').fadeIn('slow');
}

function kGridOnError() {
    LoadingEnd();
    //alert(_Error);
}

function kGridSearch() {
    $("#GridSearch").on("keyup focus", function (e) {
        
        var searchTerm = e.currentTarget.value;
        var ds = grid.data('kendoGrid').dataSource;
        
        if (searchTerm.length === 0) {
            ds.filter({});
            return false;
        }

        var fields = ds.options.schema.model.fields;
        var innerFilters = [];
        
        for (var key in fields) {
            if (!fields.hasOwnProperty(key) || fields[key].type != 'string') continue;
            innerFilters.push({
                field: key,
                operator: 'contains',
                value: searchTerm
            });
        }

        var filters = { logic: 'or', filters: innerFilters };
        ds.filter(filters);

        return false;
    });
}

function kGridRefresh() {
    if (grid.length)
        grid.data('kendoGrid').dataSource.read();
}

function kGridGoDetail(arg) {
    var dataItem = this.dataItem($(arg.currentTarget).closest("tr"));
    location.href = _FormActionUrl + "/" + dataItem.Id;
}

function kGridGoDetail2(arg) {
    var dataItem = this.dataItem($(arg.currentTarget).closest("tr"));
    location.href = _FormActionUrl + "/" + dataItem.Id + "?Type=" + dataItem.MenuTypeCode;
}

function kDateRangeStartChange() {
    var endPicker = $("#EndDate").data("kendoDatePicker"),
        startDate = this.value();

    if (startDate) {
        startDate = new Date(startDate);
        startDate.setDate(startDate.getDate() + 1);
        endPicker.min(startDate);
    }
}

function kDateRangeEndChange() {
    var startPicker = $("#StartDate").data("kendoDatePicker"),
        endDate = this.value();

    if (endDate) {
        endDate = new Date(endDate);
        endDate.setDate(endDate.getDate() - 1);
        startPicker.max(endDate);
    }
}

function kSlGridFilterChange(sender, slId, fieldName) {
    var sl = $("#" + slId).data("kendoDropDownList");

    if (grid.length) {
        gridData = grid.data("kendoGrid");

        var selectedValue = sl.value();

        if (selectedValue)
            gridData.dataSource.filter({ field: fieldName, operator: "eq", value: parseInt(selectedValue) });
        else
            gridData.dataSource.filter({});
    }
}