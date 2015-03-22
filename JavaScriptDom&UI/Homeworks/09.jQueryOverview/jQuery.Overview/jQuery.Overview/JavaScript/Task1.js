var htmlInString = [];
var position = 0;
var timeout;

htmlInString.push("<header><h1>1</h1></header><h1>My First Heading</h1><p>My first paragraph.</p>");
htmlInString.push('<header><h1>2</h1></header><p><a href="default.asp">HTML Tutorial</a> This is a link to a page on this website.</p><p>'
+'<a href="http://www.w3.org/">W3C</a> This is a link to a website on the World Wide Web.</p>');
htmlInString.push("<header><h1>3</h1></header><h1>Simple as that</h1><p>Because I'm happy.</p>");
htmlInString.push("<header><h1>4</h1></header><h1>Clap along.</h1><p>Here comes bad news.</p>");
htmlInString.push("<header><h1>5</h1></header><h1>Don't hold it back.</h1><p>Clap along if you feel like room without a roof.</p>");

function executeMe() {
    position=(position+1)%htmlInString.length;
    $('#container').html(htmlInString[position]);
}

function leftClick(){
    position -= 1;
    if (position < 0) {
        position = htmlInString.length - 1;
    }

    $('#container').html(htmlInString[position]);
    clearInterval(timeout);
    timeout = setInterval(executeMe, 5000);
}

function rightClick(){
    executeMe();
    clearInterval(timeout);
    timeout = setInterval(executeMe, 5000);
}

$('body').ready(function () {
    $('#container').html(htmlInString[0]);
    timeout = setInterval(executeMe, 5000);

    $('#left').on("click", leftClick);
    $('#right').on("click", rightClick);
});

