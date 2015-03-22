/// <reference path="jQuery-1.11.0.min.js" />

var students = [{ FirstName: "Peter", LastName: "Ivanov", Grade: "3" },
                { FirstName: "Milana", LastName: "Grigorova", Grade: "6" },
                { FirstName: "Gergana", LastName: "Borisova", Grade: "12" },
                { FirstName: "Boyko", LastName: "Petrov", Grade: "7" } ]

$("body").ready(function () {
    var table = $("<table>");
    table.append($("<tr>").append("<th>First name</th><th>Last name</th><th>Grade</th>"));
    for (var i = 0; i < students.length; i++) {
        table.append($("<tr>").append("<td>" + students[i].FirstName + "</td>").append("<td>" +
            students[i].LastName + "</td>").append("<td>" + students[i].Grade + "</td>"));
    }
    $("body").append(table);
});