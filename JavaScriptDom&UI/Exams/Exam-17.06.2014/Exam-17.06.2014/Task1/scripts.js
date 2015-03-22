function createImagesPreviewer(selector, items) {
    var fragment = document.createDocumentFragment();
    var content = document.createElement("div");
    content.style.width = "900px"; 
    content.style.height = "550px";
    content.style.cssFloat = "left";

    var slider = document.createElement("div");
    slider.style.width = "250px";
    slider.style.height = "550px";
    slider.style.cssFloat = "right";

    var h1Content = document.createElement("h1");
    h1Content.id = "h1Content";
    h1Content.innerText = items[0].title;
    h1Content.style.textAlign = "center";
    h1Content.style.margin = "0px";

    var imageContent = document.createElement("img");
    imageContent.id = "imageContent";
    imageContent.src = items[0].url;
    imageContent.style.width = "60%";
    imageContent.style.height = "60%";
    imageContent.style.margin = "10px 0px 10px 180px";
    imageContent.style.borderRadius = "20px";
    
    content.appendChild(h1Content);
    content.appendChild(imageContent);



    var h6 = document.createElement("h6");
    h6.innerText = "Filter";
    h6.style.textAlign = "center";
    h6.style.margin = "0px";

    var filter = document.createElement("input");
    filter.style.margin = "10px 50px";
    filter.addEventListener("keyup", function () {
        var divChildren=document.getElementById("sliderDiv").childNodes;

        for (var i = 0; i < divChildren.length; i++) {
            var sliderDivChildren = divChildren[i].childNodes;
            for (var j = 0; j < sliderDivChildren.length; j++) {
                if (sliderDivChildren[j].nodeName == "P") {
                    if (sliderDivChildren[j].innerText.toLowerCase().indexOf(this.value.toLowerCase()) == -1) {
                        divChildren[i].style.display = "none";
                    }
                    else {
                        divChildren[i].style.display = "block";
                    }
                }
            }
        }
    }, false);


    slider.appendChild(h6);
    slider.appendChild(filter);

    var sliderDiv = document.createElement("div");
    sliderDiv.id="sliderDiv";
    sliderDiv.style.height = "490px";
    sliderDiv.style.overflowY = "scroll";
    sliderDiv.style.overflowX = "hidden";

    var imageDiv = document.createElement("div");
    

    var p = document.createElement("p");
    p.style.textAlign = "center";
    p.style.margin = "0px";

    var image = document.createElement("img");
    image.style.width = "90%";
    image.style.margin = "10px 15px";
    image.style.borderRadius = "20px";


    imageDiv.appendChild(p);
    imageDiv.appendChild(image);
    
    for (var i = 0; i < items.length; i++) {
        p.innerText = items[i].title;
        image.src = items[i].url;
        var newDiv = imageDiv.cloneNode("true");
        
        newDiv.addEventListener("click", function (ev) {
            var childs = this.childNodes;
            
            for (var i = 0; i < childs.length; i++) {
                if (childs[i].nodeName === "IMG") {
                    document.getElementById("imageContent").src=childs[i].src;
                }
                if(childs[i].nodeName === "P")
                    document.getElementById("h1Content").innerText = childs[i].innerText;
            }
        }, false);

        newDiv.addEventListener("mouseover", function () {
            this.style.background = "grey";
        }, false);

        newDiv.addEventListener("mouseout", function () {
            this.style.background = "";
        }, false);

        sliderDiv.appendChild(newDiv);
    }



    slider.appendChild(sliderDiv);

    fragment.appendChild(content);
    fragment.appendChild(slider);
    document.body.querySelector(selector).appendChild(fragment);
}