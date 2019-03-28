<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecipeRating.ascx.cs" Inherits="User_controls_RecipeRating" %>
                             
    <div>
        <span class="style70">
            <asp:Literal runat="server" ID="RatingDisplay"></asp:Literal>
        </span>
    </div>

    <div runat="server" id="RatingVote">
        <label for="rate5"><input value="5" name="rating" id="rate5" type="radio" runat="server"><span class="style70">Excellent</span></label>
        <label for="rate4"><input value="4" name="rating" id="rate4" type="radio" runat="server"><span class="style70">Very Good</span></label>
        <label for="rate3"><input value="3" name="rating" id="rate3" type="radio" runat="server"><span class="style70">Good</span></label>
        <label for="rate2"><input value="2" name="rating" id="rate2" type="radio" runat="server"><span class="style70">Fair</span></label>
        <label for="rate1"><input value="1" name="rating" id="rate1" type="radio" runat="server"><span class="style70">Poor</span></label>
        &nbsp;&nbsp;
        <asp:Button runat="server" ID="RatingSubmit" Text="Rate" OnClick="RatingSubmit_Click"/>
    </div>
