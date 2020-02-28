// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#858796';

var aantalVoldoende = parseInt($("#aantalVoldoende").text());
var aantalOnvoldoende = parseInt($("#aantalOnvoldoende").text());
var percentageVoldoende = aantalVoldoende * 100 / (aantalVoldoende + aantalOnvoldoende);
if (Number.isNaN(percentageVoldoende)) {
    percentageVoldoende = "";
} else {
    percentageVoldoende += "%";
}

// Pie Chart Example
var ctx = document.getElementById("myPieChart");
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
            fontSize: 55,
            position: "bottom",
            padding: -165,
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