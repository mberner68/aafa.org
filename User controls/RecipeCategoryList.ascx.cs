using App_Code.Controls;
using RecipeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_controls_RecipeCategoryList : WidgetBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public override bool IsEditable
    {
        get { return false; }
    }

    public override string Name
    {
        get { return "Category"; }
    }

    public override void LoadWidget()
    {
        DataAccess da = new DataAccess();
        Repeater1.DataSource = da.GetCategoryRecipeList();
        Repeater1.DataBind();
    }
}