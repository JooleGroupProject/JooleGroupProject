/*Preview Image*/
var previewimg = function (event) {
    var result = document.getElementById("imgpreview");
    result.src = URL.createObjectURL(event.target.files[0]);
};



