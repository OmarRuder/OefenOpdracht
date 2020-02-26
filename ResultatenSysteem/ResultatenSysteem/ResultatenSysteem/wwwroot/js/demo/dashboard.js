$(document).ready(function () {

    // Set new default font family and font color to mimic Bootstrap's default styling
    Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
    Chart.defaults.global.defaultFontColor = '#858796';

    var aantalVoldoende = parseInt($("#totaalVoldoende").attr('aantalVoldoendes'));
    var aantalOnvoldoende = parseInt($("#totaalOnvoldoende").attr('aantalOnvoldoendes'));
    var html = "<div class='row'>";
    groepsVoldoendes = [0];
    groepsOnvoldoendes = [0];
    groepsCodes = [""];
    groepId = 0;

    var percentageVoldoende = aantalVoldoende * 100 / (aantalVoldoende + aantalOnvoldoende);
    if (Number.isNaN(percentageVoldoende)) {
        percentageVoldoende = "";
    } else {
        percentageVoldoende = percentageVoldoende.toString().substring(0, 5);
    }

    // groepsVoldoendes vullen met data 
    groepsVoldoendes = $("#groepData").find(".groepsVoldoendes")
        .map(function () {
            return parseInt(this.getAttribute('aantalVoldoendes'));
        })
        .get();

    groepsOnvoldoendes = $("#groepData").find(".groepsOnvoldoendes")
        .map(function () {
            return parseInt(this.getAttribute('aantalOnvoldoendes'));
        })
        .get();

    // groepsCodes vullen met data 
    groepsCodes = $("#groepData").find(".groepsCode")
        .map(function () {
            return this.getAttribute('groepscode');
        })
        .get();

    function number_format(number, decimals, dec_point, thousands_sep) {
        // *     example: number_format(1234.56, 2, ',', ' ');
        // *     return: '1 234,56'
        number = (number + '').replace(',', '').replace(' ', '');
        var n = !isFinite(+number) ? 0 : +number,
            prec = !isFinite(+decimals) ? 0 : Math.abs(decimals),
            sep = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep,
            dec = (typeof dec_point === 'undefined') ? '.' : dec_point,
            s = '',
            toFixedFix = function (n, prec) {
                var k = Math.pow(10, prec);
                return '' + Math.round(n * k) / k;
            };
        // Fix for IE parseFloat(0.55).toFixed(0) = 0;
        s = (prec ? toFixedFix(n, prec) : '' + Math.round(n)).split('.');
        if (s[0].length > 3) {
            s[0] = s[0].replace(/\B(?=(?:\d{3})+(?!\d))/g, sep);
        }
        if ((s[1] || '').length < prec) {
            s[1] = s[1] || '';
            s[1] += new Array(prec - s[1].length + 1).join('0');
        }
        return s.join(dec);
    }

    //hoofd piechart
    var ctx = document.getElementById("myPieChart");
    ctx.height = 100;
    ctx.width = 100;
    var myPieChart = new Chart(ctx, {
        type: 'doughnut',
        data: {
            labels: ["Voldoende", "Onvoldoende"],
            datasets: [{
                data: [aantalVoldoende, aantalOnvoldoende],
                backgroundColor: ['#1cc88a', '#eb4034'],
                hoverBorderColor: "rgba(234, 236, 244, 1)",
            }],
        },
        options: {
            title: {
                display: true,
                fontSize: 60,
                position: "bottom",
                padding: -190,
                text: percentageVoldoende + "%",
            },
            maintainAspectRatio: false,
            tooltips: {
                backgroundColor: "rgb(255,255,255)",
                bodyFontColor: "#858796",
                borderColor: '#dddfeb',
                borderWidth: 1,
                xPadding: 15,
                yPadding: 15,
                displayColors: false,
                caretPadding: 10,
            },
            legend: {
                display: false
            },
            cutoutPercentage: 80,
        },
    });

    //hoofd barchart
    var ctx = document.getElementById("myBarChart");
    var myBarChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: groepsCodes,
            datasets: [{
                label: "Aantal voldoendes",
                backgroundColor: "#4e73df",
                hoverBackgroundColor: "#2e59d9",
                borderColor: "#4e73df",
                data: groepsVoldoendes,
            }],
        },
        options: {
            maintainAspectRatio: false,
            layout: {
                padding: {
                    left: 10,
                    right: 25,
                    top: 25,
                    bottom: 0
                }
            },
            scales: {
                xAxes: [{
                    time: {
                        unit: 'month'
                    },
                    gridLines: {
                        display: false,
                        drawBorder: false
                    },
                    ticks: {
                        maxTicksLimit: 6
                    },
                    maxBarThickness: 25,
                }],
                yAxes: [{
                    ticks: {
                        min: 0,
                        max: 10,
                        maxTicksLimit: 5,
                        padding: 10,
                    },
                    gridLines: {
                        color: "rgb(234, 236, 244)",
                        zeroLineColor: "rgb(234, 236, 244)",
                        drawBorder: false,
                        borderDash: [2],
                        zeroLineBorderDash: [2]
                    }
                }],
            },
            legend: {
                display: false
            },
            tooltips: {
                titleMarginBottom: 10,
                titleFontColor: '#6e707e',
                titleFontSize: 14,
                backgroundColor: "rgb(255,255,255)",
                bodyFontColor: "#858796",
                borderColor: '#dddfeb',
                borderWidth: 1,
                xPadding: 15,
                yPadding: 15,
                displayColors: false,
                caretPadding: 10,
                callbacks: {
                    label: function (tooltipItem, chart) {
                        var datasetLabel = chart.datasets[tooltipItem.datasetIndex].label || '';
                        return datasetLabel + ': ' + number_format(tooltipItem.yLabel);
                    }
                }
            },
        }
    });


    for (i = 0; i < groepsCodes.length; i++) {
        groepId = $("#groep-" + groepsCodes[i]).attr('groep-id');
        if (i % 4 == 0 && i != 0) { //checken of i gedeeld door 4 gelijk is aan 0, zo check je of je elke keer 4x door de loop heen bent gegaan.
            html += "</div>"; //als het de 4e is eindig je de row div
            html += "<div class='row'>"; //en maak je een nieuwe row div (elke 4 columns een nieuwe row)
        }
        html += "<div class='col groupChartCol'><div class='chartCard body clickable grow'><a class='stretched-link' href='/Medewerker/Groepen/Overzicht/" + groepId + "'></a><div class='chart-area small'><canvas id='pieChart-" + groepsCodes[i] + "'></canvas></div><hr><span>" + groepsCodes[i] + "</span></div></div><br>"
    }
    //hier voeren we de opgebouwde html in de groupCharts div
    $("#groupCharts").append(html);


    for (i = 0; i < groepsCodes.length; i++) {

        percentageVoldoende = groepsVoldoendes[i] * 100 / (groepsVoldoendes[i] + groepsOnvoldoendes[i]);

        if (Number.isNaN(percentageVoldoende)) {
            percentageVoldoende = "";
        } else {
            percentageVoldoende = percentageVoldoende.toString().substring(0, 5); //zorgen dat het nummer maar 2 cijfers achter de komma heeft
        }

        var ctx = document.getElementById("pieChart-" + groepsCodes[i]);
        myPieChart = new Chart(ctx, {
            type: 'doughnut',
            data: {
                labels: ["Voldoende", "Onvoldoende"],
                datasets: [{
                    data: [groepsVoldoendes[i], groepsOnvoldoendes[i]],
                    backgroundColor: ['#1cc88a', '#eb4034'],
                    hoverBorderColor: "rgba(234, 236, 244, 1)",
                }],
            },
            options: {
                title: {
                    display: true,
                    fontSize: 20,
                    position: "bottom",
                    padding: -65,
                    text: percentageVoldoende + "%",
                },
                maintainAspectRatio: false,
                tooltips: {
                    backgroundColor: "rgb(255,255,255)",
                    bodyFontColor: "#858796",
                    borderColor: '#dddfeb',
                    borderWidth: 1,
                    xPadding: 15,
                    yPadding: 15,
                    displayColors: false,
                    caretPadding: 10,
                },
                legend: {
                    display: false
                },
                cutoutPercentage: 80,
            },
        });
    }

});

