function GetImg(id, val) {
    var strReturn = "";
    jQuery.ajax({
        url: '/Matches/GetImageChar/' + id,
        success: function (result) {
            if (result.isOk == false)
                alert(result.message);
            strReturn = result;
            var img = document.createElement("img");

            var img2 = document.createElement("img");
            img.src = result;

            img2.src = result;
            var src = document.getElementById(val);
            var src2 = document.getElementById(id);
            src.appendChild(img);
            src2.appendChild(img2);
        },
        async: false
    });
}