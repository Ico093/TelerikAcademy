function School(name, location, totalCourses, specialty, courses) {
    var self = this;
    self.name = name;
    self.location = location;
    self.totalCourses = totalCourses;
    self.specialty = specialty;
    self.courses = courses || [];

    self.addCourses = function (newCourses) {
        self.courses = newCourses;
    }
}

function Course(title, startDate, totalStudents, students) {
    var self = this;
    self.title = title;
    self.startDate = startDate;
    self.totalStudents = totalStudents;
    self.students = students || [];

    self.addStudents = function (newStudents) {
        self.students = newStudents;
    }
}

function Student(name, lastName, grade, marks) {
    var self = this;
    self.name = name;
    self.lastName = lastName;
    self.grade = grade;
    self.marks = marks;
}

var schoolsRepository = {
    save: function (key, obj) {
        localStorage.setItem(key, JSON.stringify(obj));
    },
    load: function (key) {
        return JSON.parse(localStorage.getItem(key));
    }
}