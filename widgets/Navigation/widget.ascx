<%@ Control Language="C#" AutoEventWireup="true" CodeFile="widget.ascx.cs" Inherits="widgets_Navigation_widget" %>
<ul>
    <asp:Repeater runat="server" ID ="Repeater1">
        <ItemTemplate>
            <li><%# Container.DataItem %><br/><br/></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>