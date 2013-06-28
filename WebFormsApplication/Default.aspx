<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsApplication.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/js/twitter-text.js"></script>
    <title></title>
    <script type="text/javascript">
        $(function () {

            $.ajax({
                url: "/Default.aspx/GetTwitterFeed",
                data: {},
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                timeout: 10000,
                success: function (result) {
                    if (result.hasOwnProperty("d")) {
                        bindTweets(result.d);
                    }
                    else {
                        bindTweets(result);
                    }

                },
                error: function (xhr, status) {
                    alert(status + " - " + xhr.responseText);
                }
            });

            function bindTweets(result) {
                var json = $.parseJSON(result);
                for (var i = 0; i < json.length; i++) {
                    $("#results").append('<div class="tweet"><p><span><strong> - ' + json[i].created_at.substring(0, 16) + '</span></strong></span><br/>' + twttr.txt.autoLink(json[i].text) + '</p>');
                    try {
                        for (var j = 0; j < json[i].entities.media.length; j++) {
                            $("#results").append('<a href="' + json[i].entities.media[j].media_url + '" ><img src="' + json[i].entities.media[j].media_url + ':thumb" /></a>');
                        }

                    } catch (e) {
                    }
                }
            }

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" EnablePageMethods="True">
    </asp:ScriptManager>
    <div id="results" />
    </form>
</body>
</html>
