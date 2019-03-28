<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FeaturedRecipe.ascx.cs" Inherits="User_controls_FeaturedRecipe" %>
                            
<div class="feature">
    <div class="title-bar recipes">Top-Rated Recipes</div>
    <div class="inner">
        <table class="top-rated">
            <tr>
                 <asp:Repeater runat ="server" ID="ResultsRepeater">

                    <ItemTemplate>

                        <td>
                            <a href="/page/recipe-page.aspx?recid=<%# Eval("Id")%>&name=<%# Eval("Name")%>"><img src="<%# Eval("ImageUrl") %>" alt="" width="120"></a><br />
                            <img src="/themes/kfa-new-theme/img/5star.gif" alt="5 stars"><br />
                            <a href="/page/recipe-page.aspx?recid=<%# Eval("Id")%>&name=<%# Eval("Name")%>"><%# Eval("Name")%></a>
                        </td>

                    </ItemTemplate>

                </asp:Repeater>
              
            </tr>
        </table>
        <p>Find allergy-friendly recipes recommended by other users like you.<br />
            Don't forget to rate a recipe after you have made it.</p>
    </div>
</div>