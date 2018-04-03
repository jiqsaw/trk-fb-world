function donutFaturaKullanim(graphId, dataFaturaKullanimUrl) {
    setTimeout(function () {
        createDonutFaturaKullanim(graphId, dataFaturaKullanimUrl);
    }, _animateSpeed*100);
}

function createDonutFaturaKullanim(graphId, dataSourceUrl) {
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
            type: "donut",
            connectors: true,
            labels: {
                visible: true,
                format: '{0}%',
                font: '20px turkcellsaturabolita',
                distance: 10
            },
            field: "value",
            categoryField: "category"
            
        }],

        chartArea: {
            width: 600,
            height: 435,
            padding: 0,
            margin: { top: -15, left: -35 },
            background: ""
        },
        legend: {
            labels: {
                font: "normal normal 14px/25px turkcellsaturameditaregular",
                color: '#c5cff2'
            },
            margin: 0,
            padding: 0,
            offsetX: -20,
            offsetY: -20,
            position: 'bottom',
            visible:true
        }
    });
}