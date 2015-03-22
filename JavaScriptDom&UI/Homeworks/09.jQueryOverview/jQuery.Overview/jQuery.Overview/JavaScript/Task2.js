/// <reference path="jQuery-1.11.0.min.js" />

function getDiv() {
    var div = $('<div>');
    div.css("display", "inline-block");
    div.css("margin", "10px");

    var divInner = $('<div>');
    var hue = 'rgb(' + (Math.floor((256 - 199) * Math.random()) + 200) + ','
                     + (Math.floor((256 - 199) * Math.random()) + 200) + ','
                     + (Math.floor((256 - 199) * Math.random()) + 200) + ')';

    divInner.css('background-color', hue);
    divInner.css("width", "160px");
    divInner.css("height", "160px");
    var buttonBefore = $('<button>').text("Add Before").click(addBefore);
    var buttonAfter = $('<button>').text("Add After").click(addAfter);

    div.append(divInner);
    div.append(buttonBefore);
    div.append(buttonAfter);
    return div;
}

function addBefore() {
    $(this).parent().before(getDiv());
}

function addAfter() {
    $(this).parent().after(getDiv());
}

$("body").ready(function () {
    $("body").append(getDiv());
});