$(document).ready(function () {
    $('#randomMeme').empty().html('Generating a random meme...');
    SetupRandomMeme();

    $.ajax({
        url: 'GetTags',
        type: 'GET',
        success: function (data, textStatus, jqXHR) { SetupDropDown(data); },
        error: function (jqXHR, textStatus, errorThrown) { alert("failure"); }
    });
})

function SetupDropDown(data) {
    $.each(data, function (index, value) {
        $("#tagSelect").append($("<option />").val(value).text(value));
    });
}

function SetupRandomMeme() {
    var meme = new Image();
    meme.src = "https://api.tronalddump.io/random/meme";
    meme.onload = function () {
        $('#randomMeme').empty().append(meme);
    };
    meme.onerror = function () {
        $('#randomMeme').empty().html('That image is not available.');
    }
}

$("#tagSelect").change(function (e) {
    $.ajax({
        url: 'GetQuotes',
        type: 'GET',
        data: { param: this.value },
        success: function (result, textStatus, jqXHR) { SetupQuotes(result.quotes, $("#quotesUl").empty()); },
        error: function (jqXHR, textStatus, errorThrown) { alert("failure"); }
    });
})

function SetupQuotes(data) {
    if (!data || !data.length) { return; }

    $.each(data, function (index, value) {
        var newQuote = $("<li />");
        var text = $("<span />").text("Text: " + value.value + " ").append("<br>");
        var datum = $("<span />").text("Datum: " + value.appeared_at).append("<br>");
        var autor = $("<span />").text("Autor: " + value.tags[0]).append("<br>");
        var izvor = $("<span />").text("Izvor: ").append("<a href=" + value._embedded.source[0].url + ">Source</a>").append("<br>");
        newQuote.append(text).append(datum).append(autor).append(izvor);
        $("#quotesUl").append(newQuote);
    });
}