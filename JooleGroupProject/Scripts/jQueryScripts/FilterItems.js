function createSlider(id, min, max) {
    min = parseInt(min);
    max = parseInt(max);

    $("#slider" + id).slider({
        range: true,
        min: min,
        max: max,
        values: [min, max],
        slide: function (event, ui) {
            $("#minInput" + id).val(ui.values[0]);
            $("#maxInput" + id).val(ui.values[1]);
            filterProducts();
        }
    });
    $("#minInput" + id).val($("#slider" + id).slider("values", 0));
    $("#maxInput" + id).val($("#slider" + id).slider("values", 1));

    $("#minInput" + id).on("change", function () {
        $("#slider" + id).slider({
            values: [$("#minInput" + id).val(), $("#maxInput" + id).val()]
        })
        filterProducts();
    });
    $("#maxInput" + id).on("change", function () {
        $("#slider" + id).slider({
            values: [$("#minInput" + id).val(), $("#maxInput" + id).val()]
        });
        filterProducts();
    });
}

function filterProducts() {
    $(".productCard").each(function (i, e) {
        var show = true;

        $(e).find(".techSpecProperty").each(function (i, techSpec) {
            let propId = $(techSpec).attr("propId");
            let minValue = $("#minInput" + propId).val();
            let maxValue = $("#maxInput" + propId).val();
            let propValue = parseInt($(techSpec).text());
            console.log(propId + " " + propValue + " " + minValue + " " + maxValue);
            if (propValue > maxValue || propValue < minValue) {
                show = false;
            }
        })
        console.log(show)
        if (show) {
            $(e).show();
        } else {
            $(e).hide();
        }
    })
}

$(document).ready(function () {
    $(".typePropertySelect").on("change", function () {
        filterProducts();
    })
});

$(document).ready(function () {
    $(".modelInput").on("change", function () {
        filterProducts();
    })
});