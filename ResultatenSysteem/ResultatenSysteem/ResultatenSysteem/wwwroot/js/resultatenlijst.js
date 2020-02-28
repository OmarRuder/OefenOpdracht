// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#858796';

studentIdList = [0];
var aantalVoldoende = parseInt($("#aantalVoldoende").text());
var aantalOnvoldoende = parseInt($("#aantalOnvoldoende").text());
var percentageVoldoende = aantalVoldoende * 100 / (aantalVoldoende + aantalOnvoldoende);
if (Number.isNaN(percentageVoldoende)) {
    percentageVoldoende = "";
} else {
    percentageVoldoende = percentageVoldoende.toString();
    percentageVoldoende = percentageVoldoende.substring(0, 5);
    percentageVoldoende += "%";
}


// Pie Chart Example
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
            fontSize: 30,
            position: "bottom",
            padding: -155,
            text: percentageVoldoende,
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


$(document).ready(function () {
    $(".toggler").click(function (e) {
        e.preventDefault();
        $('.student-' + $(this).attr('data-student-toggle')).fadeToggle("fast");
        $('.toggle-' + $(this).attr('data-student-toggle')).toggleClass("down");
        aantalVoldoende = parseInt($("#studentAantalVoldoende-" + $(this).attr('data-student-toggle')).text());
        aantalOnvoldoende = parseInt($("#studentAantalOnvoldoende-" + $(this).attr('data-student-toggle')).text());
        percentageVoldoende = aantalVoldoende * 100 / (aantalVoldoende + aantalOnvoldoende);
        if (Number.isNaN(percentageVoldoende)) {
            percentageVoldoende = "";
        } else {
            percentageVoldoende = percentageVoldoende.toString();
            percentageVoldoende = percentageVoldoende.substring(0, 5);
            percentageVoldoende += "%";
        }

        $('.chartjs-size-monitor').remove();
        ctx = $("#studentPieChart-" + $(this).attr('data-student-toggle'));
        myPieChart = new Chart(ctx, {
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
                    fontSize: 25,
                    position: "bottom",
                    padding: -150,
                    text: percentageVoldoende,
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
    });
});
