$(document).ready(function () {
    var url = document.location.href;
    var url_array = url.split("Matches/Index/");
    var myInterval = setInterval(function () {
        upd(url_array[1]);
    }, 30000);
});

function upd(id) {
    jQuery.ajax({
        url: '/Matches/UpdatePage/' + id,
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            $('#DynamicContent').html(result);
        },
    });
    return;
}
