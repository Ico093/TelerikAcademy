/// <reference path="jQuery-1.11.0.min.js" />

var Row = function (content) {
    var self = this;
    self.hasGridView = false;
    self.content = "<td>" + content + "</td>";
    if (content.render) {
        self.content = content;
    }


    return {
        addData: function (content) {
            if (!(self.content.render)) {
                if (content.render) {
                    alert("Can't add here!");
                }
                else {
                    self.content = self.content.concat("<td>" + content + "</td>")
                }
            }
            else {
                alert("Can't add here!");
            }
        },
        render: function () {
            if (self.content.render) {
                return self.content.render();
            }
            else {
                return self.content;
            }
        }
    };
};

var Header = function (content) {
    var self = this;
    self.hasGridView = false;
    self.content = "<th>" + content + "</th>";
    if (content.render) {
        self.content = content;
    }


    return {
        addData: function (content) {
            if (!(self.content.render)) {
                if (content.render) {
                    alert("Can't add here!");
                }
                else {
                    self.content = self.content.concat("<th>" + content + "</th>")
                }
            }
            else {
                alert("Can't add here!");
            }
        },
        render: function () {
            if (self.content.render) {
                return self.content.render();
            }
            else {
                return self.content;
            }
        }
    };
};

var GridView = function () {
    var self = this;
    self.hasGridView = false;
    self.hasHeader = false;
    self.stack = [];

    return {
        addHeader: function (content) {
            if (!self.hasHeader) {
                if (content.render) {
                    if (!self.hasGridView) {
                        var header = new Header(content);
                        self.stack.reverse();
                        self.stack.push(header);
                        self.stack.reverse();
                        self.hasHeader = true;
                        self.hasGridView = true;
                        return header;
                    }
                    else {
                        alert("Can't add new GridView because this GridView already has one.");
                    }
                }
                else {
                    var header = new Header(content);
                    self.stack.reverse();
                    self.stack.push(header);
                    self.stack.reverse();
                    self.hasHeader = true;
                    return header;
                }
            }
            else {
                alert("Can't add new header because this GridView already has one.");
            }
        },
        addRow: function (content) {
            if (content.render) {
                if (!self.hasGridView) {
                    self.stack.push(content);
                    self.hasGridView = true;
                    return content;
                }
                else {
                    alert("Can't add new GridView because this GridView already has one.");
                }
            }
            else {
                var row = new Row(content);
                self.stack.push(row);
                return row;
            }
        },
        render: function () {
            var myString = "<table>";

            for (var i = 0; i < self.stack.length; i++) {
                myString = myString.concat("<tr>"+self.stack[i].render()+"</tr>");
            }
            myString = myString.concat("</table>");
            return myString;
        }
    };
};