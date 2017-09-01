/*
 * 看个JB看...
 */
$('input[type="button"]').click(function () {
    var inter = $("#interface :selected").val();
    var url = $("#url").val();
    var interface1 = "http://jx.71ki.com/?url=";
    var interface2 = "http://jx1.71ki.com/?url=";
    var interface3 = "http://jx2.71ki.com/?url=";
    var interface4 = "http://www.wmxz.wang/video.php?url=";
    var interface5 = "http://player.gakui.top/?url=";
    var interface6 = "http://www.yydy8.com/Common/?url=";
    var interface7 = "http://moon.moondown.net/tong.php?url=";
    var interface8 = "http://api.lree.cn/mg.php?url=";
    if (inter == 1 && url != "") {
        var path = interface1 + url;
        $("#vipUrl").attr("src", path);
    } else if (inter == 2 && url != "") {
        var path = interface2 + url;
        $("#vipUrl").attr('src', path);
    } else if (inter == 3 && url != "") {
        var path = interface3 + url;
        $("#vipUrl").attr('src', path);
    } else if (inter == 4 && url != "") {
        var path = interface4 + url;
        $("#vipUrl").attr('src', path);
    } else if (inter == 5 && url != "") {
        var path = interface5 + url;
        $("#vipUrl").attr('src', path);
    } else if (inter == 6 && url != "") {
        var path = interface6 + url;
        $("#vipUrl").attr('src', path);
    } else if (inter == 7 && url != "") {
        var path = interface7 + url;
        $("#vipUrl").attr('src', path);
    } else if (inter == 8 && url != "") {
        var path = interface8 + url;
        $("#vipUrl").attr('src', path);
    } else if (inter == 9 && url != "") {
        var path = interface1 + url;
        $("#vipUrl").attr('src', path);
    } else if (inter == 10 && url != "") {
        var path = interface1 + url;
        $("#vipUrl").attr('src', path);
    } else if (inter == 11 && url != "") {
        var path = interface1 + url;
        $("#vipUrl").attr('src', path);
    } else if (inter == 12 && url != "") {
        var path = interface1 + url;
        $("#vipUrl").attr('src', path);
    } else if (inter == 13 && url != "") {
        var path = interface1 + url;
        $("#vipUrl").attr('src', path);
    } else {
        $("#vipUrl").attr('src', "https://xj8c.cc");
    }
});
var duoshuoQuery = { short_name: "xj8c" };
(function () {
    var ds = document.createElement('script');
    ds.type = 'text/javascript'; ds.async = true;
    ds.src = (document.location.protocol == 'https:' ? 'https:' : 'http:') + '//static.duoshuo.com/embed.js';
    ds.charset = 'UTF-8';
    (document.getElementsByTagName('head')[0]
     || document.getElementsByTagName('body')[0]).appendChild(ds);
})();
$(function () {
    $("#Sponsor").click(function () {
        $(".gray").show();
        $(".Sponsor").show();
        center();
    });
    $('.close').click(function () {
        $(".gray").hide();
        $(".Sponsor").hide();
    });
    $(".titlebar").mousedown(function (e) {
        $(this).css("cursor", "move");
        var offset = $(this).offset();
        var x = e.pageX - offset.left;
        var y = e.pageY - offset.top;
        $(document).bind("mousemove", function (ev) {
            $(".Sponsor").stop();
            var _x = ev.pageX - x;
            var _y = ev.pageY - y;
            $(".Sponsor").animate({
                left: _x + "px",
                top: _y + "px"
            }, 10);
        });
    });
    $(document).mouseup(function () {
        $(".Sponsor").css("cursor", "default");
        $(this).unbind("mousemove");
    });

    $(window).resize(function () {
        center();
    });
});
function center() {
    var _top = ($(window).height() - $(".Sponsor").height()) / 2;
    var _left = ($(window).width() - $(".Sponsor").width()) / 2;
    $(".Sponsor").css({
        top: _top,
        left: _left
    });
}