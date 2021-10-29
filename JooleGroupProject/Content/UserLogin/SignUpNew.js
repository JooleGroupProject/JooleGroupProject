/*Preview Image*/
var previewimg = function (event) {
    var result = document.getElementById("imgpreview");
    result.src = URL.createObjectURL(event.target.files[0]);
};



$(document).ready(function () {
    $("#submitButton").on("click", function () {
        alert('It`s Duplicate User Name');
    });

});