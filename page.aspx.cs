#region Using

using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.UI;

using BlogEngine.Core;
using BlogEngine.Core.Web.Controls;

using Resources;

using Page = BlogEngine.Core.Page;

#endregion

/// <summary>
/// The page.
/// </summary>
public partial class page : BlogBasePage
{
    public string redirectUrl=string.Empty;
    public bool redirectPage = false;
    protected override void OnPreInit(EventArgs e)
    {
       
        var qs = this.Request.QueryString;
        var id = qs["id"];

        if (id != null)
        {
            var pg = BlogEngine.Core.Page.GetPage(new Guid(id));

            if (pg != null)
            {
                if (!string.IsNullOrEmpty(pg.MasterPage))
                    SiteMasterPage = pg.MasterPage;
            }
        }

        base.OnPreInit(e);
    }
    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event to initialize the page.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
    protected override void OnInit(EventArgs e)
    {
        var queryString = this.Request.QueryString;
        var qsDeletePage = queryString["deletepage"];
        if (qsDeletePage != null && qsDeletePage.Length == 36)
        {
            this.DeletePage(new Guid(qsDeletePage));
        }

		Guid id = GetPageId();
        if (id != Guid.Empty)
        {
            this.ServePage(id);
            this.AddMetaTags();

            if (ViewState["Id"] == null)
                ViewState.Add("Id", id);
            else
                ViewState["id"] = id;
        }
        else
        {
            this.Response.Redirect(Utils.RelativeWebRoot);
        }

        base.OnInit(e);
    }

	protected Guid GetPageId()
	{
		string id = Request.QueryString["id"];
		Guid result;
		return id != null && Guid.TryParse(id, out result) ? result : Guid.Empty;
	}
    public static string StripTagsRegex(string source)
    {
        return Regex.Replace(source, "<.*?>", " ");
    }

    /// <summary>
    /// Serves the page to the containing DIV tag on the page.
    /// </summary>
    /// <param name="id">
    /// The id of the page to serve.
    /// </param>
    /// 
    private void ServePage(Guid id)
    {
        
        string bodyCopyWithoutHeader = string.Empty;
		var pg = this.Page;

        if (pg == null || (!pg.IsVisible))
        {
            this.Response.Redirect(string.Format("{0}error404.aspx", Utils.RelativeWebRoot), true);
            return; // WLF: ReSharper is stupid and doesn't know that redirect returns this method.... or does it not...?
        }
        if (pg.Content != null && pg.Content != string.Empty)
        {

            string[] arrString = pg.Content.Split(new string[] { "<br>" }, StringSplitOptions.None);
            var firstHeader = string.Empty;
            foreach (var firstSentence in arrString)
            { 
                string getSentence=firstSentence.Replace(" ","");
                if (getSentence != string.Empty)
                { firstHeader = firstSentence; break; }
            }

          // this.h1Title.InnerHtml = System.Web.HttpContext.Current.Server.HtmlEncode(StripTagsRegex(firstHeader));
            bodyCopyWithoutHeader = pg.Content;
        }
        //this.h1Title.InnerHtml = System.Web.HttpContext.Current.Server.HtmlEncode(pg.Title);

        if (pg.RedirectPage != null && pg.RedirectPage != string.Empty)
        { 
            redirectUrl = pg.RedirectPage; 
            redirectPage = true; 
        }

        StringBuilder rightCalloutBC = new StringBuilder();
        if (pg.RightCalloutOne != null)
        {
            string[] arrString = pg.RightCalloutOne.Split(new string[] { "\n" }, StringSplitOptions.None);
            var firstHeader = string.Empty;
            foreach (var firstSentence in arrString)
            {
                string getSentence = firstSentence;
                if (getSentence != string.Empty)
                { firstHeader = firstSentence; break; }
            }

            this.CategoriesTitle.InnerHtml = System.Web.HttpContext.Current.Server.HtmlEncode(StripTagsRegex(firstHeader));
            if (firstHeader != string.Empty)
                rightCalloutBC.Append(pg.RightCalloutOne.Replace(firstHeader, ""));
            else
                rightCalloutBC.Append(pg.RightCalloutOne);
        }
        if (rightCalloutBC != null && rightCalloutBC.ToString() != string.Empty)
        { Utils.InjectUserControls(this.rightCalloutBCdiv, rightCalloutBC.ToString()); }


        StringBuilder rightCallout = new StringBuilder();
        if (pg.RightCalloutTwo != null)
        { rightCallout.Append(pg.RightCalloutTwo); }

        if (pg.RightCalloutThree != null)
        { rightCallout.Append(pg.RightCalloutThree); }

        if (pg.RightCalloutFour != null)
        { rightCallout.Append(pg.RightCalloutFour); }

        if (pg.RightCalloutFive != null)
        { rightCallout.Append(pg.RightCalloutFive); }

        if (rightCallout != null && rightCallout.ToString()!=string.Empty)
        { Utils.InjectUserControls(this.rightCalloutText, rightCallout.ToString()); }


        StringBuilder leftCalloutBC = new StringBuilder();
        if (pg.LeftCalloutOne != null)
        {
            string[] arrString = pg.LeftCalloutOne.Split(new string[] { "\n" }, StringSplitOptions.None);
            var firstHeader = string.Empty;
            foreach (var firstSentence in arrString)
            {
                string getSentence = firstSentence;
                if (getSentence != string.Empty)
                { firstHeader = firstSentence; break; }
            }

            this.CategoriesTitle.InnerHtml = System.Web.HttpContext.Current.Server.HtmlEncode(StripTagsRegex(firstHeader));
            if (firstHeader != string.Empty)
                leftCalloutBC.Append(pg.LeftCalloutOne.Replace(firstHeader, ""));
            else
                leftCalloutBC.Append(pg.LeftCalloutOne);
        }
        if (leftCalloutBC != null && leftCalloutBC.ToString() != string.Empty)
        { Utils.InjectUserControls(this.leftCalloutBCdiv, leftCalloutBC.ToString()); }


        StringBuilder leftCallout = new StringBuilder();
        if (pg.LeftCalloutTwo != null)
        { leftCallout.Append(pg.LeftCalloutTwo); }

        if (pg.LeftCalloutThree != null)
        { leftCallout.Append(pg.LeftCalloutThree); }

        if (pg.LeftCalloutFour != null)
        { leftCallout.Append(pg.LeftCalloutFour); }

        if (pg.LeftCalloutFive != null)
        { leftCallout.Append(pg.LeftCalloutFive); }

        if (leftCallout != null && leftCallout.ToString() != string.Empty)
        { Utils.InjectUserControls(this.leftCalloutText, leftCallout.ToString()); }

        if (pg.Footer!=null && pg.Footer != string.Empty)
        {
            Utils.InjectUserControls(this.footerText, pg.Footer.Replace("<%=DateTime.Now.Year %>",DateTime.Now.Year.ToString())); 
        }



        var arg = new ServingEventArgs(bodyCopyWithoutHeader, ServingLocation.SinglePage);
        BlogEngine.Core.Page.OnServing(pg, arg);

        if (arg.Cancel)
        {
            this.Response.Redirect("error404.aspx", true);
        }

        if (arg.Body.Contains("[usercontrol", StringComparison.OrdinalIgnoreCase))
        {
            Utils.InjectUserControls(this.divText, arg.Body);
           // this.InjectUserControls(arg.Body);
        }
        else
        {
            this.divText.InnerHtml = arg.Body;
        }
    }

    /// <summary>
    /// Adds the meta tags and title to the HTML header.
    /// </summary>
    protected virtual void AddMetaTags()
    {
        if (this.Page == null)
        {
            return;
        }
        



        this.Title = this.Server.HtmlEncode(this.Page.Title);
        this.AddMetaTag("keywords", this.Server.HtmlEncode(this.Page.Keywords));
        this.AddMetaTag("description", this.Server.HtmlEncode(this.Page.Description));
        this.AddTitle(this.Page.Title, this.Page.PageTitle);
    }


    /// <summary>
    /// Deletes the page.
    /// </summary>
    /// <param name="id">
    /// The page id.
    /// </param>
    private void DeletePage(Guid id)
    {
        var page = BlogEngine.Core.Page.GetPage(id);
        if (page == null)
        {
            return;
        }
        if (!page.CanUserDelete)
        {
            Response.Redirect(Utils.RelativeWebRoot);
            return;
        }

        page.Delete();
        page.Save();
        this.Response.Redirect(Utils.RelativeWebRoot, true);
    }

 
 
	private Page _page;
	private bool _pageLoaded;
    /// <summary>
    ///     The Page instance to render on the page.
    /// </summary>
	public new Page Page
	{
		get
		{
			if (!_pageLoaded)
			{
				_pageLoaded = true;
				Guid id = GetPageId();
				if (id != Guid.Empty)
				{
					_page = BlogEngine.Core.Page.GetPage(id);
				}
			}

			return _page;
		}
	}

    /// <summary>
    ///     Gets the admin links to edit and delete a page.
    /// </summary>
    /// <value>The admin links.</value>
    public string AdminLinks
    {
        get
        {
            if (!Security.IsAuthenticated)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            if (this.Page.CanUserEdit)
            {
                if (sb.Length > 0) { sb.Append(" | "); }
                if (labels.edit.ToLower().Equals("footer"))
                {
                    sb.AppendFormat(
                        "<a href=\"{0}admin/editor/page.cshtml?id={1}\">{2}</a>",
                        Utils.RelativeWebRoot,
                        this.Page.Id,
                        labels.edit);
                }
                else
                {
                    sb.AppendFormat(
                           "<a href=\"{0}admin/editor/footer.cshtml?id={1}\">{2}</a>",
                           Utils.RelativeWebRoot,
                           this.Page.Id,
                           labels.edit);
                }
            }

            if (this.Page.CanUserDelete)
            {
                if (sb.Length > 0) { sb.Append(" | "); }

                sb.AppendFormat(
                    String.Concat("<a href=\"javascript:void(0);\" onclick=\"if (confirm('", labels.areYouSureDeletePage, "')) location.href='?deletepage={0}'\">{1}</a>"),
                    this.Page.Id,
                    labels.delete);
            }

            if (sb.Length > 0)
            {
                sb.Insert(0, "<div id=\"admin\">");
                sb.Append("</div>");
            }

            return sb.ToString();
        }
    }

    /// <summary>
    /// Gets PermaLink.
    /// </summary>
    public string PermaLink
    {
        get
        {
            return string.Format("{0}page.aspx?id={1}", Utils.AbsoluteWebRoot, this.Page.Id);
        }
    }
}