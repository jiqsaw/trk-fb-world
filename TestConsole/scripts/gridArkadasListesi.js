var grid = null;
function gridBind(dataUrl, dataCount) {
    grid = $('#' + _kendoGridName);
    $(grid).html("<center><img src=\"images/global/loading.gif\" /></center>");
    setTimeout(function () {
        createGrid(dataUrl, dataCount);
    }, _animateSpeed * 100);
}

function createGrid(dataSourceUrl, dataCount) {
    
    $(grid).html('');
    dataCount = dataCount * 2;

    $(grid).kendoGrid({
        dataSource: {
            data: createRandomData(dataCount),
            schema: {
                model: {
                    fields: {
                        PersonSought: { type: "string" }
                    }
                }
            },
            pageSize: 10,
            serverPaging: false,
            serverFiltering: false,
            serverSorting: false
        },
        height: 760,
        scrollable: false,
        sortable: false,
        filterable: false,
        pageable: {
            input: false,
            numeric: false
        },
        columns: [
            {
                field: "PersonSought",
                title: "ARANAN KİŞİ",
                width: 210,
                encoded: false
            }
        ]
    });
}

function createRandomData(count) {
    var data = [],
        now = new Date();
    for (var i = 0; i < count; i++) {
        i++;
        var rd = 0 + "." + i;
        var personSought = personSoughts[Math.floor(rd * personSoughts.length)];

        data.push({
            Id: i + 1,
            PersonSought: personSought
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
            var personSought = personSoughts[Math.floor(Math.random() * personSoughts.length)];

            data.push({
                Id: i + 1,
                PersonSought: personSought
            });
        } while (data.length < itemCount && +new Date() - starttime < interval);

        if (data.length < itemCount) {
            setTimeout(arguments.callee, delay);
        } else {
            callback(data);
        }
    }, delay);
}