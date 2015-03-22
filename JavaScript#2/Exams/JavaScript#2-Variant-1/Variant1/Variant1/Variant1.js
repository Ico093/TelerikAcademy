var controls = (function () {
    function GridView(selector) {
        var self = this;
        var gridView = document.querySelector(selector);

        var table = document.createElement("table");
        table.addEventListener("click", change, false);
        var rows = new Array();
        var maxCellSpan = 0;


        self.addHeader = function () {
            var tr = document.createElement("tr");
            var th = document.createElement("th");

            for (var i = 0; i < arguments.length; i++) {
                th.textContent = arguments[i];
                tr.appendChild(th);
                th = th.cloneNode(true);
            }

            if (arguments.length > maxCellSpan) {
                maxCellSpan = arguments.length;
            }

            rows.push(tr);
            return self;
        }

        self.addRow = function () {
            var tr = document.createElement("tr");
            var td = document.createElement("td");

            for (var i = 0; i < arguments.length; i++) {
                td.textContent = arguments[i];
                tr.appendChild(td);
                td = td.cloneNode(true);
            }

            if (arguments.length > maxCellSpan) {
                maxCellSpan = arguments.length;
            }

            rows.push(tr);
            return self;
        }

        self.getNestedGridView = function () {
            var grid = new GridViewRow();
            rows.push(grid);
            return grid;
        }

        self.getGridViewData = function () {
            var schools = new Array();

            for (var i = 0; i < rows.length; i++) {
                var children = rows[i].childNodes;
                if (rows[i] instanceof GridViewRow) {
                    children = rows[i].render();
                    var courseRows = children.childNodes;

                    var courses = new Array();
                    for (var j = 0; j < courseRows.length; j++) {
                        var coursesChildren = courseRows[j].childNodes;
                        if (coursesChildren[0].nodeName == "TD") {

                            var kalin = coursesChildren[0].getElementsByTagName("table");
                            if (coursesChildren[0].getElementsByTagName("table").length != 0) {
                                var studentRows = coursesChildren[0].getElementsByTagName("tr");

                                var students = new Array();
                                for (var k = 0; k < studentRows.length; k++) {
                                    var studentChildren = studentRows[k].childNodes;
                                    if (studentChildren[0].nodeName == "TD") {
                                        students.push(new Student(studentChildren[0].textContent, studentChildren[1].textContent, studentChildren[2].textContent, studentChildren[3].textContent));
                                    }
                                }
                                courses[courses.length - 1].addStudents(students);
                            }
                            else {
                                courses.push(new Course(coursesChildren[0].textContent, coursesChildren[1].textContent, coursesChildren[2].textContent));
                            }
                        }
                    }

                    schools[schools.length - 1].addCourses(courses);
                }
                else {
                    schools.push(new School(children[0].textContent, children[1].textContent, children[2].textContent, children[3].textContent));
                }
            }

            return schools;
        }



        self.render = function () {
            if (rows.length > 0) {
                while (table.firstChild) {
                    table.removeChild(table.firstChild);
                }

                for (var i = 0; i < rows.length; i++) {
                    if (rows[i] instanceof GridViewRow) {
                        var tr = document.createElement("tr");
                        var td = document.createElement("td");
                        td.colSpan = maxCellSpan;
                        td.appendChild(rows[i].render());
                        tr.appendChild(td);
                        table.appendChild(tr);
                    }
                    else {
                        table.appendChild(rows[i]);
                    }
                }

                gridView.appendChild(table);
            }
        }
    }

    function GridViewRow() {
        var self = this;

        var table = document.createElement("table");
        var rows = new Array();
        var maxCellSpan = 0;

        self.addHeader = function () {
            var tr = document.createElement("tr");
            var th = document.createElement("th");

            for (var i = 0; i < arguments.length; i++) {
                th.textContent = arguments[i];
                tr.appendChild(th);
                th = th.cloneNode(true);
            }

            if (arguments.length > maxCellSpan) {
                maxCellSpan = arguments.length;
            }

            rows.push(tr);
            return self;
        }

        self.addRow = function () {
            var tr = document.createElement("tr");
            var td = document.createElement("td");

            for (var i = 0; i < arguments.length; i++) {
                td.textContent = arguments[i];
                tr.appendChild(td);
                td = td.cloneNode(true);
            }

            if (arguments.length > maxCellSpan) {
                maxCellSpan = arguments.length;
            }

            rows.push(tr);
            return self;
        }

        self.getNestedGridView = function () {
            var grid = new GridViewRow();
            rows.push(grid);
            return grid;
        }

        self.render = function () {
            if (rows.length > 0) {
                while (table.firstChild) {
                    table.removeChild(table.firstChild);
                }

                for (var i = 0; i < rows.length; i++) {
                    if (rows[i] instanceof GridViewRow) {
                        var tr = document.createElement("tr");
                        var td = document.createElement("td");
                        td.colSpan = maxCellSpan;
                        td.appendChild(rows[i].render());
                        tr.appendChild(td);
                        table.appendChild(tr);
                    }
                    else {
                        table.appendChild(rows[i]);
                    }
                }

                return table;
            }
        }
    }

    function change(ev) {
        if (!ev) ev = window.event;
        ev.preventDefault();
        ev.stopPropagation();
        var tr = ev.target.parentNode.nextElementSibling;
        if (tr) {
            if (tr.getElementsByTagName("table")[0]) {
                if (tr.style.display == "none") {
                    tr.style.display = "";
                }
                else {
                    tr.style.display = "none";
                }
            }
        }
    }

    return {
        getGridView: function (selector) {
            return new GridView(selector);
        },
        buildGridView: function (selector, data) {
            if (data.length != 0) {
                debugger;
                var grid = new GridView(selector);
                var arr = new Array();
                for (var property in data[0]) {
                    arr.push(property);
                }

                grid.addHeader(arr[0], arr[1], arr[2], arr[3]);

                for (var i = 1; i < data.length; i++) {
                    arr = [];
                    for (var property in data[i]) {
                        arr.push(data[i][property]);
                    }
                    grid.addRow(arr[0], arr[1], arr[2], arr[3]);
                    if (data[i].courses.length != 0) {
                        var grid1 = grid.getNestedGridView();

                        delete arr;
                        arr = new Array();
                        for (var property in data[i].courses[0]) {
                            arr.push(property);
                        }

                        grid1.addHeader(arr[0], arr[1], arr[2]);

                        for (var j = 0; j < data[i].courses.length; j++) {
                            arr = [];
                            for (var property in data[i].courses[j]) {
                                arr.push(data[i].courses[j][property]);
                            }
                            grid1.addRow(arr[0], arr[1], arr[2]);
                            if (data[i].courses[j].students.length != 0) {
                                var grid2 = grid1.getNestedGridView();

                                delete arr;
                                arr = new Array();
                                for (var property in data[i].courses[j].students[0]) {
                                    arr.push(property);
                                }

                                grid2.addHeader(arr[0], arr[1], arr[2], arr[3]);

                                for (var k = 0; k < data[i].courses[j].students.length; k++) {
                                    arr = [];
                                    for (var property in data[i].courses[j].students[k]) {
                                        arr.push(data[i].courses[j].students[k][property]);
                                    }
                                    grid2.addRow(arr[0], arr[1], arr[2], arr[3]);
                                }
                            }
                        }
                    }
                }

                return grid;
            }
            else {
                throw "No data!";
            }
        }
    }
})();