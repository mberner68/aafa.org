<%@ Control Language="C#" AutoEventWireup="true" CodeFile="edit.ascx.cs" Inherits="widgets_Navigation_edit" %>

NAV LEVEL
<asp:DropDownList runat ="server" ID="NavLevel">    
    <asp:ListItem Value="0" Text="AUTO"></asp:ListItem>
    <asp:ListItem Value="1" Text="Level 1"></asp:ListItem>
    <asp:ListItem Value="2" Text="Level 2"></asp:ListItem>
    <asp:ListItem Value="3" Text="Level 3"></asp:ListItem>
    <asp:ListItem Value="4" Text="Level 4"></asp:ListItem>
    <asp:ListItem Value="5" Text="Level 5"></asp:ListItem>
</asp:DropDownList>