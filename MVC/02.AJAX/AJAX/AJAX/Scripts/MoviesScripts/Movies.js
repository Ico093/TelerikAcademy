function onMovieSuccess(obj) {
    alert(obj.msg);
}

function onMovieFailure(obj) {
    alert("Proble: " + obj.msg);
}