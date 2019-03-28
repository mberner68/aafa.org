<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecipeCategoryList.ascx.cs" Inherits="User_controls_RecipeCategoryList" %>

<ul>
<asp:Repeater runat="server" ID="Repeater1">
    <ItemTemplate>
        <li><a href="/page/recipes-diet.aspx?cat=<%# Eval("Id") %>"><%# Eval("Name") %></a></li>
    </ItemTemplate>
</asp:Repeater>
</ul>