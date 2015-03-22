var controls = (function () {
    function ImageGallery(selector) {
        var self = this;
        var div = document.querySelector(selector);

        if (addEventListener) {
            div.addEventListener("click", change, false);
            div.addEventListener("click", enlarge, false);
        }
        else if (attachEvent) {
            div.attachEvent("onclick", change);
            div.attachEvent("onclick", enlarge);
        }
        else {
            div["onclick"] = change;
            div["onclick"] = enlarge;
        }

        var elems = new Array();

        self.addImage = function (title, src) {
            elems.push(new Image(title, src));
            return this;
        }

        self.addAlbum = function (title) {
            var album = new Album(title);
            elems.push(album);
            return album;
        }

        self.getImageGalleryData = function () {
            if (elems.length > 0) {
                elems = rearange(elems);

                var arr = new Array();

                for (var i = 0; i < elems.length; i++) {
                    arr.push(elems[i].getData());
                }

                return arr;
            }
            else {
                return 0;
            }
        }

        self.render = function () {
            while (div.firstChild) {
                div.removeChild(div.firstChild);
            }

            elems = rearange(elems);

            var create = document.createDocumentFragment();
            var button = document.createElement("button");
            button.textContent = "Sort ascending!";
            button.addEventListener("click", sort);
            create.appendChild(button);

            for (var i = 0; i < elems.length; i++) {
                create.appendChild(elems[i].render());
            }
            div.appendChild(create);
            return div;
        }

        function sort(ev) {
            if (!ev) ev = window.event;
            ev.preventDefault();
            ev.stopPropagation();
            var button = ev.target;
            debugger;
            if (button.nodeName == "BUTTON") {
                var arr = new Array();
                for (var i = 0; i < elems.length; i++) {
                    if (elems[i] instanceof Album) {
                        arr.push(elems[i]);
                    }
                }

                arr.sort(function (arr1, arr2) { return arr1.title > arr2.title; });
                var name = button.textContent;
                if (button.textContent != "Sort ascending!") {
                    arr.reverse();
                }


                for (var i = 0; i < arr.length; i++) {
                    elems.pop();
                }
                for (var i = 0; i < arr.length; i++) {
                    elems.push(arr[i]);
                }

                var div = self.render();
                button = div.childNodes[0];
                if (name == "Sort ascending!") {
                    button.textContent = "Sort descending!"
                }
                else {
                    arr.reverse();
                    button.textContent = "Sort ascending!"
                }
            }
        }
    }

    function Image(title, src) {
        var self = this;

        self.title = title;
        self.src = src;

        self.getData = function () {
            return {
                title: self.title,
                src: self.src
            }
        }

        self.render = function () {
            var div = document.createElement("div");
            var a = document.createElement("a");
            a.textContent = self.title;
            div.appendChild(a);
            var img = document.createElement("img");
            img.src = src;
            img.style.width = 135 + "px";
            img.style.height = 100 + "px";
            div.appendChild(img);
            return div;
        }
    }

    function Album(title) {
        var self = this;
        self.title = title;
        var elems = new Array();

        self.addImage = function (title, src) {
            elems.push(new Image(title, src));
            return this;
        }

        self.addAlbum = function (title) {
            var album = new Album(title);
            elems.push(album);
            return album;
        }

        self.getData = function () {
            if (elems.length > 0) {
                elems = rearange(elems);

                var arr = new Array();

                for (var i = 0; i < elems.length; i++) {
                    arr.push(elems[i].getData());
                }

                return {
                    title: self.title,
                    arr: arr
                }
            }
            else {
                return {
                    title: self.title,
                    arr: 0
                }
            }
        }

        self.render = function () {
            var div = document.createElement("div");
            div.className = "album";
            var a = document.createElement("a");
            a.textContent = self.title;
            a.className = "title";
            div.appendChild(a);

            elems = rearange(elems);

            var button = document.createElement("button");
            button.textContent = "Sort ascending!";
            button.addEventListener("click", sort);
            div.appendChild(button);

            for (var i = 0; i < elems.length; i++) {
                var divNotShown = elems[i].render();
                divNotShown.style.display = "none";
                div.appendChild(divNotShown);
            }
            return div;
        }

        function sort(ev) {
            if (!ev) ev = window.event;
            ev.preventDefault();
            ev.stopPropagation();
            var button = ev.target;
            debugger;
            if (button.nodeName == "BUTTON") {
                var arr = new Array();
                for (var i = 0; i < elems.length; i++) {
                    if (elems[i] instanceof Album) {
                        arr.push(elems[i]);
                    }
                }

                arr.sort(function (arr1, arr2) { return arr1.title > arr2.title; });
                var name = button.textContent;
                if (button.textContent != "Sort ascending!") {
                    arr.reverse();
                }

                for (var i = 0; i < arr.length; i++) {
                    elems.pop();
                }
                for (var i = 0; i < arr.length; i++) {
                    elems.push(arr[i]);
                }


                var div = self.render();
                var firstDiv = button.parentNode;
                while (firstDiv.firstChild)
                {
                    firstDiv.removeChild(firstDiv.firstChild);
                }
                for (var i = 0; i < div.childNodes.length; i++) {
                    firstDiv.appendChild(div.childNodes[i]);
                    i--;
                }
                button = firstDiv.childNodes[1];
                if (name == "Sort ascending!") {
                    button.textContent = "Sort descending!"
                }
                else {
                    arr.reverse();
                    button.textContent = "Sort ascending!"
                }
                for (var i = 2; i < firstDiv.childNodes.length; i++) {
                    firstDiv.childNodes[i].style.display = "";
                }
            }
        }
    }

    function change(ev) {
        if (!ev) ev = window.event;
        ev.preventDefault();
        ev.stopPropagation();
        var a = ev.target;

        if (a.nodeName == "A") {
            var div = a.parentNode;
            var children = div.childNodes;
            for (var i = 0; i < children.length; i++) {
                if (children[i].nodeName == "IMG" || children[i].nodeName == "DIV") {
                    if (children[i].style.display == "none") {
                        children[i].style.display = "";
                    }
                    else {
                        children[i].style.display = "none";
                    }
                }
            }
        }
    }

    function enlarge(ev) {
        if (!ev) ev = window.event;
        ev.preventDefault();
        ev.stopPropagation();
        var img = ev.target;
        var imgClone = img.cloneNode(true);
        imgClone.style.height = (img.style.height.substr(0, img.style.height.length - 2) | 0) * 3 + "px";
        imgClone.style.width = (img.style.width.substr(0, img.style.width.length - 2) | 0) * 3 + "px";

        if (imgClone.nodeName == "IMG") {
            var div = document.getElementById("bigPhoto");

            while (div.firstChild) {
                div.removeChild(div.firstChild);
            }
            div.appendChild(imgClone);
        }
    }

    function rearange(elems) {
        var arr = new Array();
        for (var i = 0; i < elems.length; i++) {
            if (elems[i] instanceof Image) {
                arr.push(elems[i]);
            }
        }

        for (var i = 0; i < elems.length; i++) {
            if (elems[i] instanceof Album) {
                arr.push(elems[i]);
            }
        }
        return arr;
    }

    function buildImageGalleryFirst(selector, data) {
        var gallery = new ImageGallery(selector);

        for (var i = 0; i < data.length; i++) {
            if (!(data[i].hasOwnProperty("arr"))) {
                gallery.addImage(data[i].title, data[i].src);
            }
            else {
                var album = gallery.addAlbum(data[i]["title"]);
                buildAlbumGallery(album, data[i]["arr"]);
            }
        }

        return gallery;
    }

    function buildAlbumGallery(album, data) {
        for (var i = 0; i < data.length; i++) {
            if (!(data[i].hasOwnProperty("arr"))) {
                album.addImage(data[i].title, data[i].src);
            }
            else {
                var albumInner = album.addAlbum(data[i]["title"]);
                buildAlbumGallery(albumInner, data[i]["arr"]);
            }
        }
    }

    return {
        getImageGallery: function (selector) {
            return new ImageGallery(selector);
        },
        buildImageGallery: function (selector, data) {
            return buildImageGalleryFirst(selector, data);
        }
    }
})();

var imageGalleryRepository = (function () {
    var self = this;

    self.save = function (key, data) {
        localStorage.setItem(key, JSON.stringify(data));
    }

    self.load = function (key) {
        return JSON.parse(localStorage.getItem(key));
    }

    return {
        save: self.save,
        load: self.load
    }
})();