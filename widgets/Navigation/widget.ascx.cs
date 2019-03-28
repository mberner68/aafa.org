using App_Code.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlogEngine.Core;

public partial class widgets_Navigation_widget : WidgetBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    public override bool IsEditable
    {
        get { return true; }
    }

    public override string Name
    {
        get { return "Navigation"; }
    }

    public override void LoadWidget()
    {
        string level = null;

        var settings = this.GetSettings();
        if (settings.ContainsKey("level"))
            level = settings["level"];

        int l = 0;
        try
        {
            l = Convert.ToInt32(level);
        }
        catch (Exception ex)
        {
            l = 0;
        }

        List<string> items = NavHelper.Instance.GetNaveLinks(l, Security.IsAuthenticated);
        Repeater1.DataSource = items;
        Repeater1.DataBind();

        return;
    }
}