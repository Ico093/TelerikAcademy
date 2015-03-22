/// <reference path="jquery.min.js" />


$.fn.gallery = function (rows) {
    $this = $(this);

    var imgs = $(".gallery-list").find("img");

    var galleryList=$(".gallery-list");
    var images = $this.find(".image-container");

    var selected = $this.find(".selected");
    var imgSelected = $("#current-image");
    var imgNext = $("#next-image");
    var imgPrevious = $("#previous-image");
    var rows = rows != undefined ? rows : 4;

    $this.addClass("gallery");
    $this.css("width", 265 * rows + "px");

    galleryList.css("-moz-user-select", "-moz-none");
    galleryList.css("-khtml-user-select", "none");
    galleryList.css("-webkit-user-select", "none");
    galleryList.css("-o-user-select", "none");
    galleryList.css("user-select", "none");
    selected.css("-moz-user-select", "-moz-none");
    selected.css("-khtml-user-select", "none");
    selected.css("-webkit-user-select", "none");
    selected.css("-o-user-select", "none");
    selected.css("user-select", "none");

    selected.hide();

    imgSelected.click(function () {
        selected.hide();
        galleryList.removeClass("disabled-background");
        galleryList.removeClass("blurred");
        galleryList.css("pointer-events", "auto");
    });

    imgNext.click(function (ev) {
        changeSelected(this);
    });

    imgPrevious.click(function (ev) {
        changeSelected(this);
    });

    for (var i = 0; i < images.length; i++) {
        var img = $(images[i]).find("img");

        $(img).click(function (ev) {
            selected.show();
            galleryList.addClass("disabled-background");
            galleryList.css("pointer-events", "none");
            galleryList.addClass("blurred");

            changeSelected(this);
        });
    }

    function changeSelected(self) {
        for (var i = 0; i < imgs.length; i++) {
            if ($(imgs[i]).attr("src") == $(self).attr("src")) {
                $(imgSelected).attr("src", $(self).attr("src"));
                $(imgNext).attr("src", $(imgs[(i + 1) % imgs.length]).attr("src"));
                $(imgPrevious).attr("src", $(imgs[(i - 1) == -1 ? imgs.length - 1 : i - 1]).attr("src"));
                break;
            }
        }
    }
};