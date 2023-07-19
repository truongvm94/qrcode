// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("#example").DataTable();
    $("#main").children(".col-md-12").after("<div class='hr'><div>");
});

$(document).ready(function () {
    $('#example tbody tr').click(function () {
        var url = $(this).data('href');
        if (url) {
            window.location.href = url;
        }
    });
});