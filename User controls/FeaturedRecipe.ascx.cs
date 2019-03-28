using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RecipeDomain;

public partial class User_controls_FeaturedRecipe : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ResultsRepeater.DataSource = SearchRecipies(5);
            ResultsRepeater.DataBind();
        }
    }

    private IList<RecipeSearchResultItemModel> SearchRecipies(int take)
    {
        DataAccess da = new DataAccess();
        return da.TopRecipes(take);
    }
}