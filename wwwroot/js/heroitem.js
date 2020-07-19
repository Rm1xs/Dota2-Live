function GetHeroItem(id, val) {
    jQuery.ajax({
        url: '/Matches/GetImageItem/' + id,
        success: function (result) {
            if (result.isOk == false)
                alert(result.message);
            strReturn = result;
            var img = document.createElement("img");
            img.style.cssText = 'width:40px;height:30px;';
            img.src = result;
            var src = document.getElementById(val);
            src.appendChild(img);
        },
        async: false
    });
}