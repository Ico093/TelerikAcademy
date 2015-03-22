/// <reference path="RaphaelJS.js" />
window.onload = function () {
    console.log("pena");
    var stage = new Kinetic.Stage({
        container: 'myCanvas',
        width: 700,
        height: 170
    });

    var layer = new Kinetic.Layer();

    var imageObj = new Image();

    imageObj.onload = function () {
        var mario = new Kinetic.Sprite({
            x: 350,
            y: 119,
            image: imageObj,
            animation: 'idle',
            animations: {
                idle: [
                  // x, y, width, height (4 frames)
                  199, 413, 28, 37,
                  227, 413, 28, 37,
                  256, 413, 28, 37,
                  286, 413, 28, 37,
                  316, 413, 28, 37,
                  347, 413, 28, 37,
                  377, 413, 28, 37,
                  407, 413, 28, 37,
                  436, 413, 28, 37,
                  199, 451, 28, 37,
                  227, 451, 28, 37,
                  250, 451, 28, 37,
                  279, 451, 28, 37,
                  309, 451, 28, 37,
                  335, 451, 28, 37,
                  360, 451, 28, 37,
                  387, 451, 28, 37,
                  416, 451, 28, 37,
                  201, 490, 28, 37,
                  228, 490, 28, 37,
                  256, 490, 28, 37,
                  285, 490, 28, 37,
                  314, 490, 28, 37,
                  343, 490, 28, 37
                ]
            },
            frameRate: 30,
            frameIndex: 0
        });

        // add the shape to the layer
        layer.add(mario);

        // add the layer to the stage
        stage.add(layer);

        // start sprite animation
        mario.start();
    };


    imageObj.src = 'http://localhost:50585/sprites/NewSupermarioBros.png';

    var svg = document.getElementById("svg");
    svg.style.width = "700px";
    svg.style.height = "170px";
    svg.style.background = 'url("http://localhost:50585/sprites/images.jpg")';

    var i = 0;

    setInterval(function () {
        i=(--i)%284;
        svg.style.backgroundPositionX = i + "px";
        console.log(i);
    }, 5);
}