<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="keywords" content="瞎JB扯，阿星Plus">
    <meta name="description" content="瞎JB扯的阿星Plus">
    <title>瞎JB扯</title>
    <link rel="stylesheet" href="style/main.css">
    <link rel="icon" href="images/favicon.ico">
</head>
<body>
    <div class="nav">
        <div class="navbar">
            <a href="index.html">瞎JB扯</a>
        </div>
        <ul>
            <li><a href="index.html">瞎JB扯</a></li>
            <!-- <li><a href="http://www.weibo.com/Tencentgou/">微博</a></li> -->
            <li><a href="http://meowv.com/">喵呜网</a></li>
			<li><a href="https://github.com/Meowv/">GitHub</a></li>
        </ul>
        <button class="navbtn" type="button">
            <span class="sr-only">导航</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </button>
    </div>
    <div class="nav-toggle">
        <ul></ul>
    </div>
    <div class="articles">
        <ul>
            <%if(articlesList != null)foreach(var item in articlesList){{%><li><a href="<%=item.Id%>.html"><%=item.Title%></a></li><%}}%>
        </ul>
    </div>
    <i>内容来自网络，如有侵权，请联系站长24小时内删除。</i>
    <div class="gray"></div>
    <div class="login-box">
        <div class="titlebar">
            瞎JB扯的阿星Plus
			<a class="close"></a>
        </div>
        <div class="qr-code"></div>
        <form action="Process/ProcessLogin.ashx" method="post">
            <input type="text" name="username" id="username" required="required" placeholder="Username" autocomplete="off" value="" />
            <input type="password" name="password" id="password" required="required" placeholder="Password" autocomplete="off" value="" />
            <input type="submit" value="登录" />
        </form>
    </div>
</body>
</html>
<script src="js/jquery.min.js"></script>
<script>
    $(function () {
        //导航按钮点击事件
        $('.navbtn').click(function () {
            //将.nav ul下li标签赋给.nav-toggle ul下的li
            $('.nav-toggle ul').html($('.nav ul').html());
            //导航按钮显示与隐藏
            $('.nav-toggle').slideToggle();
        });
        //登录窗点击事件
        $('html').dblclick(function () {
            //显示遮罩层
            $(".gray").show();
            //显示登录框
            $(".login-box").show();
            //窗口居中显示
            center();
        })
        //关闭登录框
        $('.close').click(function () {
            //隐藏遮罩层
            $(".gray").hide();
            //隐藏登录框
            $(".login-box").hide();
        })

        $(".titlebar").mousedown(function (e) {
            //改变鼠标指针的形状
            $(this).css("cursor", "move");
            //DIV在页面的位置
            var offset = $(this).offset();
            //获得鼠标指针离DIV元素左边界的距离
            var x = e.pageX - offset.left;
            //获得鼠标指针离DIV元素上边界的距离
            var y = e.pageY - offset.top;
            //绑定鼠标的移动事件，因为光标在DIV元素外面也要有效果，所以要用doucment的事件，而不用DIV元素的事件
            $(document).bind("mousemove", function (ev) {
                $(".login-box").stop();
                //获得X轴方向移动的值
                var _x = ev.pageX - x;
                //获得Y轴方向移动的值
                var _y = ev.pageY - y;
                $(".login-box").animate({
                    left: _x + "px",
                    top: _y + "px"
                }, 10);
            });
        });

        $(document).mouseup(function () {
            $(".login-box").css("cursor", "default");
            $(this).unbind("mousemove");
        });

        $(window).resize(function () {
            center();
        });
    });

    //居中显示方法
    function center() {
        var _top = ($(window).height() - $(".login-box").height()) / 2;
        var _left = ($(window).width() - $(".login-box").width()) / 2;
        $(".login-box").css({
            top: _top,
            left: _left
        });
    }
</script>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="XJBC.Web.Index" %>