$(document).ready(function () {
    var myInterval = setInterval(function () {
        upd();
    }, 15000);
});

function upd(id) {
    jQuery.ajax({
        url: '/Matches/Index/' + id,
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            $('#DynamicContent').html(result);
        },
    });
    return;
}
