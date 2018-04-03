function gridBind2(dataUrl, dataCount, gridName) {
    $(gridName).html("<center><img src=\"" + _urlStatic + "/images/global/loadingSmall.gif\" /></center>");
    setTimeout(function () {
        createGrid(dataCount, gridName);
    }, _animateSpeed * 100);
}

function createGrid(dataCount, gridName) {
    gridName = "#" + gridName;
    $(gridName).html('');
    dataCount = dataCount * 2;
    $(gridName).kendoGrid({
       
        dataSource: {
            data: createRandomData(dataCount),
            schema: {
                model: {
                    fields: {
                        TypeImage: { type: "string" },
                        BirthDate: { type: "date" },
                        Unit: { type: "string" },
                        Amount: { type: "string" },
                        IsType: { type: "string" }
                    }
                }
            }
        },
        columns: [
            {
                field: "TypeImage",
                title: " ",
                template: '<img src=\"'+_urlStatic+'images/icons/kendoGrid/type#= TypeImage #.png\" />',
                width: 20,
                encoded: false
            },
            {
                field: "BirthDate",
                title: "TARİH/SAAT",
                template: '#= kendo.toString(BirthDate,"MM/dd/yyyy HH:mm:ss") #',
                width: 140
            },
            {
                field: "Unit",
                title: "BİRİM",
                width: 80
            },
            {
                field: "Amount",
                title: "TUTAR"
            },
            {
                field: "IsType",
                title: "tümü",
                hidden: true
            }
        ]
    });

    dataArkadasSource = $(gridName).data('kendoGrid').dataSource;
}

function createRandomData(count) {
    count = count / 2;
    var data = [],
        now = new Date();
    for (var i = 0; i < count; i++) {

        var typeImage = typeImages[i],
            unit = units[i],
            amount = amounts[i],
            birthDate = birthDates[i],
            isType = isTypes[i];

        data.push({
            Id: i + 1,
            TypeImage: typeImage,
            Unit: unit,
            Amount: amount,
            BirthDate: birthDate,
            IsType: isType
        });
    }
    return data;
}

function generatePeople(itemCount, callback) {
    var data = [],
        delay = 25,
        interval = 500,
        starttime;

    var now = new Date();
    setTimeout(function () {
        starttime = +new Date();
        do {
            var typeImage = units[Math.floor(Math.random() * typeImages.length)],
            unit = units[Math.floor(Math.random() * units.length)],
            amount = amounts[Math.floor(Math.random() * amounts.length)],
            birthDate = birthDates[Math.floor(Math.random() * birthDates.length)],
            isType = isTypes[Math.floor(Math.random() * isTypes.length)];

            data.push({
                Id: i + 1,
                TypeImage: typeImage,
                Unit: unit,
                Amount: amount,
                BirthDate: birthDate,
                IsType: isType
            });
        } while (data.length < itemCount && +new Date() - starttime < interval);

        if (data.length < itemCount) {
            setTimeout(arguments.callee, delay);
        } else {
            callback(data);
        }
    }, delay);
}