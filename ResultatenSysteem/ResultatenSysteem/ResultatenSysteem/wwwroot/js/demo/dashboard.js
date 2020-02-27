$(document).ready(function () {
    // Set new default font family and font color to mimic Bootstrap's default styling
    Chart.pluginService.register({
        beforeDraw: function (chart) {
            if (chart.config.options.elements.center) {
                //Get ctx from string
                var ctx = chart.chart.ctx;

                //Get options from the center object in options
                var centerConfig = chart.config.options.elements.center;
                var fontStyle = centerConfig.fontStyle || 'Arial';
                var txt = centerConfig.text;
                var color = centerConfig.color || '#000';
                var sidePadding = centerConfig.sidePadding || 20;
                var sidePaddingCalculated = (sidePadding / 100) * (chart.innerRadius * 2)
                //Start with a base font of 30px
                ctx.font = "30px " + fontStyle;

                //Get the width of the string and also the width of the element minus 10 to give it 5px side padding
                var stringWidth = ctx.measureText(txt).width;
                var elementWidth = (chart.innerRadius * 2) - sidePaddingCalculated;

                // Find out how much the font can grow in width.
                var widthRatio = elementWidth / stringWidth;
                var newFontSize = Math.floor(30 * widthRatio);
                var elementHeight = (chart.innerRadius * 2);

                // Pick a new font size so it will not be larger than the height of label.
                var fontSizeToUse = Math.min(newFontSize, elementHeight);

                //Set font settings to draw it correctly.
                ctx.textAlign = 'center';
                ctx.textBaseline = 'middle';
                var centerX = ((chart.chartArea.left + chart.chartArea.right) / 2);
                var centerY = ((chart.chartArea.top + chart.chartArea.bottom) / 2);
                ctx.font = fontSizeToUse + "px " + fontStyle;
                ctx.fillStyle = color;

                //Draw text in center
                ctx.fillText(txt, centerX, centerY);
            }
        }
    });
    Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
    Chart.defaults.global.defaultFontColor = '#858796';

    var html = "<div class='row'>";
    groepsVoldoendes = [];
    groepsOnvoldoendes = [];
    groepsCodes = [];
    groepId = 0;
    var displayText = "";

    var percentageVoldoende = totaalVoldoende * 100 / (totaalVoldoende + totaalOnvoldoende);
    if (Number.isNaN(percentageVoldoende)) {
        percentageVoldoende = "";
    } else {
        percentageVoldoende = percentageVoldoende.toString().substring(0, 5);
    }

    //groepdata arrays vullen
    for (i = 0; i < groepData.length; i++) {
        groepsCodes.push(groepData[i].groepsCode); //groepscodes vullen
        groepsVoldoendes.push(groepData[i].aantalVoldoendes);
        groepsOnvoldoendes.push(groepData[i].aantalOnvoldoendes);
    }

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
                data: [totaalVoldoende, totaalOnvoldoende],
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

    for (i = 0; i < groepData.length; i++) {
        groepId = groepData[i].Id;
        displayText = groepData[i].groepNaam + " (" + groepData[i].groepsCode + ")";
        percentageVoldoende = groepsVoldoendes[i] * 100 / (groepsVoldoendes[i] + groepsOnvoldoendes[i]);
        if (i % 4 == 0 && i != 0) { //checken of i gedeeld door 4 gelijk is aan 0, zo check je of je elke keer 4x door de loop heen bent gegaan.
            html += "</div>"; //als het de 4e is eindig je de row div
            html += "<div class='row'>"; //en maak je een nieuwe row div (elke 4 columns een nieuwe row)
        }
        html += `<div class='col groupChartCol'><div class='chartCard cartBody clickable grow shadow'><a class='stretched-link' href='/Medewerker/Groepen/Overzicht/${groepId}'></a><div class='chart-area small'><canvas id='pieChart-${groepsCodes[i]}'></canvas><span class='innerPieChartText'>${percentageVoldoende.toString().substring(0, 5)}</span></div><hr><span>${displayText}</span></div></div><br>`;
    }
    //hier voeren we de opgebouwde html in de groupCharts div
    $("#groupCharts").append(html);

    for (i = 0; i < groepData.length; i++) {
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
                center: {
                    text: 'Desktop',
                    color: '#36A2EB', //Default black
                    sidePadding: 15 //Default 20 (as a percentage)
                },
                //title: {
                //    display: true,
                //    fontSize: 20,
                //    position: "bottom",
                //    padding: -55,
                //    text:  "%",
                //},
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

    $("#nextPageButton").click(function () {
        $(this).toggle();
        $("#previousPageButton").toggle();
        $("#snel-bekijken").toggleClass("selected");
        $("#snel-invoeren").toggleClass("unselected");
    });
    $("#previousPageButton").click(function () {
        $(this).toggle();
        $("#nextPageButton").toggle();
        $("#snel-bekijken").toggleClass("selected");
        $("#snel-invoeren").toggleClass("unselected");
    });
});

