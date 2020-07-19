
function League(id) {
    var strReturn = "";
    jQuery.ajax({
        url: 'home/GetLeagueName/' + id,
        success: function (result) {
            if (result.isOk == false)
                alert(result.message);
            strReturn = result;
        },
        async: false
    });
    return strReturn;
}