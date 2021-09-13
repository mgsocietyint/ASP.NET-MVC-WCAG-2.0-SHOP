var body = document.getElementById("body");
var small = document.getElementById("small-font");
var normal = document.getElementById("normal-font");
var big = document.getElementById("big-font");

small.addEventListener("click", function (e) {
    body.style.fontSize = 16 + "px";
    e.preventDefault();
});

normal.addEventListener("click", function (e) {
    body.style.fontSize = 18 + "px";
    e.preventDefault();
});

big.addEventListener("click", function (e) {
    body.style.fontSize = 21 + "px";
    e.preventDefault();
});
