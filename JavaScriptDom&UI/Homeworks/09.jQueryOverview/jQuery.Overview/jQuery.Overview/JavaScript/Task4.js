/// <reference path="jQuery-1.11.0.min.js" />

$("body").ready(function () {
    $("body").css("background-color", $("#colorPicker").val());

    $("#colorPicker").change(function () {
        $("body").css("background-color", $("#colorPicker").val());
    })
});