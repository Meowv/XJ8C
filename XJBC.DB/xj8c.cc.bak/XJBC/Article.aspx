<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="keywords" content="<%=model.Title%>，瞎JB扯，阿星Plus">
    <meta name="description" content="<%=Substr(Server.HtmlDecode(model.ContentText))%>">
    <title><%=model.Title%> — 瞎JB扯</title>
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
            <li><!-- <a href="http://www.weibo.com/Tencentgou/">微博</a> --></li>
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
    <div class="nav-toggle"><ul></ul></div>
    <div class="article">
        <h2><%=model.Title%></h2>
        <%=Server.HtmlDecode(model.ContentHtml)%>
    </div>
	<i class="copy">内容来自网络,如有侵权,请联系站长24小时内删除.</i>
</body>
</html>
<script src="js/jquery.min.js"></script>
<script src="lib/js/prettify.min.js"></script>
<script>$(function () { $(".navbtn").click(function () { $(".nav-toggle ul").html($(".nav ul").html()); $(".nav-toggle").slideToggle() }) });</script>
<script>window._bd_share_config={"common":{"bdSnsKey":{},"bdText":"","bdMini":"1","bdMiniList":["mshare","sqq","tsina","weixin","qzone","tqq","youdao","copy"],"bdPic":"","bdStyle":"0","bdSize":"16"},"slide":{"type":"slide","bdImg":"2","bdPos":"left","bdTop":"250"}};with(document)0[(getElementsByTagName('head')[0]||body).appendChild(createElement('script')).src='/static/api/js/share.js?v=89860593.js?cdnversion='+~(-new Date()/36e5)];</script>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="XJBC.Web.Article" %>