// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


window.$ = window.jquery = require('./node_modules/jquery');
window.dt = require('./node_modules/datatables.net')();

$(document).ready(function () {
    $('#jquerytable').DataTable();
});