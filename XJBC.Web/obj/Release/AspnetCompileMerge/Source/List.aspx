<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>瞎JB扯</title>
    <link rel="stylesheet" href="style/edit.css">
    <link rel="icon" href="images/favicon.ico">
</head>
<body>
    <div class="nav">
        <a href="edit.html">瞎JB扯</a>
        <%=chineseName %><span id="hi"></span>
        <a href="javascript:void(0);" onclick="if(confirm('你真的要退出吗?')){window.location='Process/ProcessLogout.ashx';} return false;" class="white">退出</a>
    </div>
    <div class="articles">
        <ul>
            <%if(articlesList != null)foreach(var item in articlesList){{%><li>
                <a href="<%=item.Id%>.html"><%=item.Title%></a>
                <a onclick="return confirm('你真的要删？');" href="Process/ProcessDelete.ashx?id=<%=item.Id%>">删</a>
                <a href="Edit.html?id=<%=item.Id%>">改</a>
            </li><%}}%>
        </ul>
    </div>
    <div class="gray"></div>
    <div class="login-box">
        <div class="titlebar">
            瞎JB扯的阿星Plus
			<a class="close"></a>
        </div>
        <form action="Process/ProcessUpdate.ashx" method="post">
            <input type="password" name="oldPwd" id="oldPwd" required="required" placeholder="请输入旧密码" autocomplete="off" value="" />
            <input type="password" name="newPwd1" id="newPwd1" required="required" placeholder="请输入新密码" autocomplete="off" value="" />
            <input type="password" name="newPwd2" id="newPwd2" required="required" placeholder="请再次输入新密码" autocomplete="off" value="" />
            <input type="submit" value="修改" />
        </form>
    </div>
</body>
</html>
<script src="js/jquery.min.js"></script>
<script src="js/hi.js"></script>
<script>
    $(function () {
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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="XJBC.Web.List" %>