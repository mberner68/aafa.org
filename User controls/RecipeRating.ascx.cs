using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RecipeDomain;

public partial class User_controls_RecipeRating : System.Web.UI.UserControl
{
    public int RecipeId { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();

        //if (IsPostBack)
        //{
        //    int v = ReadVote();

        //    if(v > -1 && v < 6)
        //        da.RateRecipe(RecipeId, v);
        //}

        RecipeRatingModel model = da.GetRecipeRatingModel(RecipeId);
        if (model == null)
            model = new RecipeRatingModel() { HasVotes = false, TotalVotes = 0, Rating = 0 };

        WritePage(model.Rating, model.TotalVotes, model.HasVotes, model.HasUserVoted);
    }

    private int ReadVote()
    {
        int rating = -1;

        try
        {
            string val = Request["ctl00$RecipeRating$rating"];
            rating = Convert.ToInt32(val);
        }
        catch (Exception ex)
        { }

        return rating;
    }

    protected bool HasVoted(double recipeId)
    {
        try
        {
            if (Session["votes"] != null)
            {
                string[] parts = Session["votes"].ToString().Split(",".ToCharArray());
                return parts.Contains(recipeId.ToString());
            }
        }
        catch (Exception ex)
        { }
        return false;
    }

    public void WritePage(int ratingValue, int votes, bool hasVotes, bool hasVoted)
    {
        if (hasVotes)
        {
            const string rat = @"<img src=""/themes/kfa-new-theme/img/{0}star.gif"" alt=""{0} stars"">Avg. rating: {0} from </span><span class=""style70"">{1} votes.";
            RatingDisplay.Text = string.Format(rat, ratingValue, votes);
        }

        if (hasVoted)
        {
            RatingVote.Visible = false;
        }
    }
    
    protected void RatingSubmit_Click(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
               
        int v = ReadVote();

        if (v > -1 && v < 6)
            da.RateRecipe(RecipeId, v);

        RecipeRatingModel model = da.GetRecipeRatingModel(RecipeId);
        if (model == null)
            model = new RecipeRatingModel() { HasVotes = false, TotalVotes = 0, Rating = 0 };
        
        WritePage(model.Rating, model.TotalVotes, model.HasVotes, model.HasUserVoted);
    }
}