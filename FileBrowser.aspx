<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileBrowser.aspx.cs" Inherits="FileBrowser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/Scripts/jquery-1.8.2.js"></script>
    <script src="/Scripts/FileBrowser/jquery.dbpas.carousel.js"></script>
    <link href="/Scripts/FileBrowser/jquery.dbpas.carousel.css" rel="stylesheet" />
    <style>
        .selectable:hover {
            cursor:pointer;
        }
    </style>
      <script>
          $(document).ready(function () {
              var funcNum = <%= Request["CKEditorFuncNum"] %>
              $('ul').dbpasCarousel();
              $('.selectable').click(function () {
                  var fileUrl = $(this).attr('rel');
                  if (confirm("Use " + fileUrl + "?")) {
                      window.opener.CKEDITOR.tools.callFunction(funcNum, fileUrl);
                      window.close();
                  }
              });
          });
  </script>
</head>
<body>
    <div id="fileExplorer">
        <ul>
                   
        <asp:Repeater ID="Repeater1" runat="server">
           
            <ItemTemplate>
                <li>
                    <img class="selectable" rel="/media/<%#Eval("Name") %>" src="<%#Eval("thumb") %>" style="max-width:180px; max-height:200px"/><br /><%#Eval("Name") %>
                </li>
            </ItemTemplate>
                
        </asp:Repeater> 



        </ul>
    </div>
</body>
</html>
