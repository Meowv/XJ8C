<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>瞎JB扯后台管理</title>
    <link rel="stylesheet" href="lib/css/editor.css">
    <link rel="stylesheet" href="lib/css/dark.css">
    <link rel="stylesheet" href="style/edit.css">
    <link rel="icon" href="images/favicon.ico">
</head>
<body>
    <form id="myform" runat="server">
        <div class="nav">
            <a href="List.html">瞎JB扯</a>
            <%=chineseName %><span id="hi"></span>
            <a href="javascript:void(0);" onclick="if(confirm('你真的要退出吗?')){window.location='Process/ProcessLogout.ashx';} return false;" class="white">退出</a>
        </div>
        <div class="insert">
            <asp:TextBox ID="Title" runat="server" placeholder="&nbsp;Title"></asp:TextBox>
            <textarea id="Editor" name="Editor" runat="server"></textarea>
            <asp:Button runat="server" Text="添加" ID="btnInsert" OnClick="btnInsert_Click"></asp:Button>
        </div>
    </form>
</body>
</html>
<script src="js/jquery.min.js"></script>
<script src="js/hi.js"></script>
<script src="lib/js/editor.js"></script>
<script src="lib/js/highlight.js"></script>
<script src="lib/qiniu/plupload/plupload.full.min.js"></script>
<script src="lib/qiniu/plupload/i18n/zh_CN.js"></script>
<script src="lib/qiniu/qiniu.min.js"></script>
<script>
    function uploadInit() {
        var editor = this;
        var btnId = editor.customUploadBtnId;
        var containerId = editor.customUploadContainerId;
        var uploader = Qiniu.uploader({
            runtimes: 'html5,flash,html4',
            browse_button: btnId,
            uptoken_url:'Process/ProcessGetToken.ashx',
            domain: 'https://ohicw3hdi.qnssl.com/',
            container: containerId,
            max_file_size: '100mb',
            flash_swf_url: 'lib/qiniu/js/plupload/Moxie.swf',
            filters: {
                mime_types: [
                  { title: "图片文件", extensions: "jpg,gif,png,bmp" }
                ]
            },
            max_retries: 3,
            dragdrop: true,
            drop_element: 'Editor',
            chunk_size: '4mb',
            auto_start: true,
            init: {
                'FilesAdded': function (up, files) {
                    plupload.each(files, function (file) {
                    });
                },
                'BeforeUpload': function (up, file) {
                },
                'UploadProgress': function (up, file) {
                    editor.showUploadProgress(file.percent);
                },
                'FileUploaded': function (up, file, info) {
                    var domain = up.getOption('domain');
                    var res = $.parseJSON(info);
                    var sourceLink = domain + res.key;
                    editor.command(null, 'insertHtml', '<img src="' + sourceLink + '"/>');
                },
                'Error': function (up, err, errTip) {
                },
                'UploadComplete': function () {
                    //editor.hideUploadProgress();
                },
                'Key': function (up, file) {
                    var key = "xj8c/" + getNowFormatDate() + "_" + file.name;
                    return key
                }
            }
        });
    }

    var editor = new wangEditor('Editor');
    editor.config.customUpload = true;
    editor.config.customUploadInit = uploadInit;
    editor.onchange = function () {
        console.log(this.$txt.html());
        localStorage.Content = editor.$txt.html();
    };
    editor.create();

    function getNowFormatDate() {
        var date = new Date();
        var month = date.getMonth() + 1;
        var strDate = date.getDate();
        if (month >= 1 && month <= 9) {
            month = "0" + month;
        }
        if (strDate >= 0 && strDate <= 9) {
            strDate = "0" + strDate;
        }
        var currentdate = date.getFullYear() + '' + month + '' + strDate + date.getHours() + '' + date.getMinutes() + '' + date.getSeconds();
        return currentdate;
    }

    $(document).ready(function () {
        //判断是否支持localStorage
        if (localStorage) {
            if (localStorage.Title) {
                $("#Title").val(localStorage.Title);
            }
            if (localStorage.Content) {
                editor.command(null, 'insertHtml', localStorage.Content);
            }
            //当数据改变时，localStorage的值跟着改变
            $("input[type=text]").change(function () {
                localStorage[$(this).attr("name")] = $(this).val();
            });
            //如果表单提交，则清空localStorage
            $("form")
            .submit(function () {
                localStorage.clear();
            })
            .change(function () {
                console.log(localStorage);
            })
        }
    });
</script>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XJBC.Web.Edit" %>