var controls = (function () {
    function Accordion(selector) {
        var self = this;
        var accordionItem = document.querySelector(selector);

        accordionItem.addEventListener("click", change, false);

        var ul = document.createElement("ul");
        var items = new Array();

        self.add = function (title) {
            var newItem = new Item(title);
            items.push(newItem);
            return newItem;
        };

        self.render = function () {
            while (ul.firstChild) {
                ul.removeChild(ul.firstChild);
            }

            for (var i = 0; i < items.length; i++) {
                var item = items[i].render();
                ul.appendChild(item);
            }
            accordionItem.appendChild(ul);
            return this;
        };

        self.serialize = function () {
            var arr = new Array();

            for (var i = 0; i < items.length; i++) {
                arr.push(items[i].save());
            }

            return arr;
        }
    }

    function Item(title) {
        var self = this;
        var li = document.createElement("li");
        var a = document.createElement("a");
        a.textContent = title;
        a.style.display = "block";
        li.appendChild(a);
        var items = new Array();

        self.add = function (title) {
            var newItem = new Item(title);
            items.push(newItem)
            return newItem;
        };

        self.render = function () {
            if (items.length > 0) {
                var ul = document.createElement("ul");
                ul.style.display = "none";

                for (var i = 0; i < items.length; i++) {
                    var item = items[i].render();
                    ul.appendChild(item);
                }
                li.appendChild(ul);
            }
            li.getElementsByTagName("ul")
            return li;
        };

        self.save = function () {
            var returnObject = {
                title: title
            };
            if (items.length) {
                var arr = new Array();

                if (items.length != 0) {
                    for (var i = 0; i < items.length; i++) {
                        arr.push(items[i].save());
                    }
                }
                returnObject.items = arr;
            }
            return returnObject;
        }
    }

    function change(ev) {
        if (!ev) ev = window.event;
        ev.stopPropagation();
        ev.preventDefault();

        var li = ev.target.parentNode;
        var uls = li.childNodes;

        if (li.style.backgroundColor == "white") {
            li.style.backgroundColor = "#eeeeee";

            for (var i = 0; i < uls.length; i++) {
                if (uls[i].nodeName == "UL") {
                    uls[i].style.display = "none";
                }
            }
        }
        else {
            var parent = li.parentNode.childNodes;

            for (var i = 0; i < parent.length; i++) {
                if (parent[i].nodeName == "LI") {
                    parent[i].style.backgroundColor = "#eeeeee";
                    var ulsToHide = parent[i].childNodes;
                    for (var j = 0; j < ulsToHide.length; j++) {
                        if (ulsToHide[j].nodeName == "UL") {
                            ulsToHide[j].style.display = "none";
                        }
                    }
                }
            }

            if (uls.length > 1) {
                li.style.backgroundColor = "white";

                for (var i = 0; i < uls.length; i++) {
                    if (uls[i].nodeName == "UL") {
                        uls[i].style.display = "";
                    }
                }
            }
        }
    }

    function addItem(item, newItem)
    {
        var accItem = item.add(newItem.title);

        if(newItem.items)
        {
            for (var i = 0; i < newItem.items.length; i++) {
                addItem(accItem, newItem.items[i]);
            }
        }
    }

    return {
        getAccordion: function (selector) {
            return new Accordion(selector);
        },
        getDeserializedAccordion: function (selector, state) {
            var accordion = new Accordion(selector);

            if (state) {
                for (var i = 0; i < state.length; i++) {
                    addItem(accordion, state[i])
                }
            }
            return accordion;
        }
    }
})();