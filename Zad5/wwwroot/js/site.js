// Write your Javascript code.

$(document).ready(function () {
    $.get({
        type: "GET",
        url: "https://api.tronalddump.io/tags",
        dataType: "JSONP",
        success: function (data) {
            console.log(JSON.stringify(data));
        }
    });
});

var callbackFunction = function (data) {
    console.log(data);
}

function callback(data) {
    console.log(data);
}