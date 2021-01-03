// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var noOfCisco = 0;
var noOfEricsson = 0;
var noOfPhones = 0;
var noOfAvailableExtension = 0;
var noOfUsedExtension = 0;

$(document).ready(function () {
    $('#dataTable').DataTable();
});

// uncomment this
//$(document).ready (function () {
//    $.ajax({
//        type: 'GET',
//        url: 'Home/GetAll',
//        contentType: 'application/json',
//        data: JSON.stringify({}),
//        success: function (data) {
//            console.log(data);
//            noOfPhones = parseInt(data.noOfPhones);
//            noOfCisco = parseInt(data.noOfCisco);
//            noOfEricsson = parseInt(data.noOfEricsson);
//            noOfAvailableExtension = parseInt(data.noOfAvailableExtension);
//            noOfUsedExtension = parseInt(data.noOfUsedExtension);
//            createChart(noOfPhones, noOfCisco, noOfEricsson, noOfAvailableExtension, noOfUsedExtension);
//        },
//        error: function (status) {
//            console.log(status);
//        }
//    });

//});

//function createChart(noOfPhones, noOfCisco, noOfEricsson, noOfAvailableExtension, noOfUsedExtension) {
//    var ctx = document.getElementById('myChart').getContext('2d');
//    var myChart = new Chart(ctx, {
//        type: 'bar',
//        data: {
//            labels: ['No. Phones', 'No. Cisco', 'No. Ericsson', 'Available Extension', 'Used Extension'],
//            datasets: [{
//                label: '# of Votes',
//                data: [noOfPhones, noOfCisco, noOfEricsson, noOfAvailableExtension, noOfUsedExtension],
//                backgroundColor: [
//                    'rgba(255, 99, 132, 0.2)',
//                    'rgba(54, 162, 235, 0.2)',
//                    'rgba(255, 206, 86, 0.2)',
//                    'rgba(75, 192, 192, 0.2)',
//                    'rgba(153, 102, 255, 0.2)',
//                    'rgba(255, 159, 64, 0.2)'
//                ],
//                borderColor: [
//                    'rgba(255, 99, 132, 1)',
//                    'rgba(54, 162, 235, 1)',
//                    'rgba(255, 206, 86, 1)',
//                    'rgba(75, 192, 192, 1)',
//                    'rgba(153, 102, 255, 1)',
//                    'rgba(255, 159, 64, 1)'
//                ],
//                borderWidth: 1
//            }]
//        },
//        options: {
//            scales: {
//                yAxes: [{
//                    ticks: {
//                        beginAtZero: true
//                    }
//                }]
//            }
//        }
//    });
//}