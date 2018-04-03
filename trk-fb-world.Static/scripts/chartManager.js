function chartFaturaKullanim(graphId, dataFaturaKullanimUrl) {
    setTimeout(function () {
        createChartFaturaKullanim(graphId, dataFaturaKullanimUrl);
    }, _animateSpeed*100);
}

function createChartFaturaKullanim(graphId, dataSourceUrl) {
    $("#" + graphId).kendoChart({
        theme: "highContrast",
        seriesHover: "false",
        dataSource: {
            transport: {
                read: {
                    url: dataSourceUrl,
                    dataType: "json"
                }
            },
            sort: {
                field: "year",
                dir: "asc"
            }
        },

        series: [{
            type: "pie",
            connectors: false,
            labels: {
                visible: true,
                format: '{0}%',
                font: '16px turkcellsaturameditaregular',
                distance: 10
            },
            field: "value",
            categoryField: "category"
            
        }],

        chartArea: {
            width: 500,
            height: 335,
            padding: 0,
            margin: { top: 0, left: -120 },
            background: ""
        },
        legend: {
            labels: {
                font: "normal normal 14px/25px turkcellsaturameditaregular",
                color: '#c5cff2'
            },
            margin: 0,
            padding: 0,
            offsetX: -110,
            offsetY: 0,
            position:'right'
        }
    });
}

function createChart(graphId, dataUrl) {
    $("#" + graphId).kendoChart({
        theme: $(document).data("kendoSkin") || "default",
        dataSource: {
            transport: {
                read: {
                    url: dataUrl,
                    dataType: "json"
                }
            },
            sort: {
                field: "year",
                dir: "asc"
            }
        },
        title: {
            text: "",
            visible: false
        },
        legend: {
            position: "top",
            visible: false
        },
        seriesDefaults: {
            type: "area"
        },
        series: [{
            field: "nuclear",
            name: "Nuclear",
            color: "#176de2"
        }, {
            field: "hydro",
            name: "Hydro",
            color: "#68a8ff"
        }],
        categoryAxis: {
            field: "year",
            labels: {
                rotation: -90,
                font: '20px turkcellsaturabolita',
                color: '#ffffff'
            },
            lineColor: "#ffffff"
        },
        valueAxis: {
            labels: {
                format: "N0",
                visible: false,
                font: '20px turkcellsaturabolita',
                color: '#ffffff'
            },
            majorUnit: 10000
        },
        tooltip: {
            visible: true,
            format: "N0"
        },
        chartArea: {
            background: ""
        }
    });
}