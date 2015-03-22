/// <reference path="Scripts/jquery-2.1.1.js" />
window.onload = function () {
    $.extend($.expr[":"], {
        "selected": function (elem, index, match) {

            console.log("Ne me zanimavai s gluposti...");
            console.log(index);
            console.log(elem);


            if (elem.nodeName == "SELECT") {
                var childrenOfSelect = elem.children;

                for (var i = 0; i < childrenOfSelect.length; i++) {
                    if($(childrenOfSelect[i]).attr("selected")!=null){
                        elem = 4;
                        console.log(match);

                        return true;
                    }
                }
            }
            else {
                return false;
            }
        }
    });

    $.fn.dropdown = function () {
        this.css("display", "none");

        var div = $('<div/>')
                    .addClass('dropdown-list-container');

        var ul = $('<ul/>')
                    .addClass('dropdown-list-options');

        var children=this.children();

        for (var i = 0; i < children.length; i++) {
            var li = $('<ul/>')
                    .addClass('dropdown-list-option')
                    .attr("data-value", i)
                    .html(children[i].innerText)
                    .click(function () {
                        console.log(children);
                        for (var j = 0; j < children.length; j++) {
                            if ($(children[j]).attr("selected")!=null) {
                                $(children[j]).removeAttr("selected");
                            }

                            if (children[j].innerText == this.innerText) {
                                $(children[j]).attr("selected","selected");
                            }
                        }

                        console.log($('#dropdown:selected'));
                    });

            ul.append(li);
        }

        div.append(ul);

        this.after(div);
    }

    $('#dropdown').dropdown();
}