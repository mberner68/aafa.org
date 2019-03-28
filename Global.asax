<%@ Application Language="C#" %>
<%@ Import Namespace="System.Threading" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="BlogEngine.Core" %>
<%@ Import Namespace="App_Code.Controls" %>
<%@ Import Namespace="System.Web.Optimization" %>

<script RunAt="server">
  
  /// <summary>
  /// Application Error handler
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
    void Application_Error(object sender, EventArgs e)
    {
        HttpContext context = ((HttpApplication)sender).Context;
        Exception ex = context.Server.GetLastError();
        
        if (ex == null || !(ex is HttpException) || (ex as HttpException).GetHttpCode() == 404)
        {
            return;
        }


        if ((ex as HttpException).GetHttpCode() == 404)
        {
            throw ex;
        }
        
        var sb = new StringBuilder();

        try
        {
            sb.AppendLine("Url : " + context.Request.Url);
            sb.AppendLine("Raw Url : " + context.Request.RawUrl);

            while (ex != null)
            {
                sb.AppendLine("Message : " + ex.Message);
                sb.AppendLine("Source : " + ex.Source);
                sb.AppendLine("StackTrace : " + ex.StackTrace);
                sb.AppendLine("TargetSite : " + ex.TargetSite);
                ex = ex.InnerException;
            }
        }
        catch (Exception ex2)
        {
            sb.AppendLine("Error logging error : " + ex2.Message);
        }

        if (BlogSettings.Instance.EnableErrorLogging)
        {
            // this can generate lots of errors
            // from scripts crawling the site.
            // uncomment if you want to see them
            Utils.Log(sb.ToString());
        }
        context.Items["LastErrorDetails"] = sb.ToString();
        context.Response.StatusCode = 500;
        
        // Custom errors section defined in the Web.config, will rewrite (not redirect)
        // this 500 error request to error.aspx.
    }

    void Application_Start(object sender, EventArgs e)
    {
        // intentionally not using Application_Start.  instead application
        // start code is below in FirstRequestInitialization. this is to
        // workaround IIS7 integrated mode issue where HttpContext.Request
        // is not available during Application_Start.
        
        Utils.Log("BlogEngine.NET application started");
    }

    void Application_BeginRequest(object source, EventArgs e)
    {
        HttpApplication app = (HttpApplication)source;
        HttpContext context = app.Context;
        
        // Attempt to perform first request initialization
        FirstRequestInitialization.Initialize(context);


        string x = RedirectHelper.FindRedirect(Request.Url);
        if (!String.IsNullOrEmpty(x))
        {
            Response.Redirect(x);
        }

        if (Request.Url.AbsolutePath == "/default.aspx")
            Response.Redirect(RedirectHelper.GetQueryString("/page/welcome.aspx", Request.Url));

        if (Request.Url.PathAndQuery.Contains("/recipes/showrecipe.php"))
        {
            Response.RedirectPermanent(string.Format("/page/recipe-page.aspx?recid={0}", Request["id"]));
        }

       
    }



    void HandleRedirect(string id)
    {
        if (id == null)
            return;
        
        string resp = null;
        try
        {
            Guid gid = new Guid(id);
            if (gid != Guid.Empty)
            {
                using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["BlogEngine"].ConnectionString))
                {
                    con.Open();
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(string.Format("SELECT RedirectPage  FROM [be_Pages] where PageId = '{0}'", gid), con))
                    {
                        string result = cmd.ExecuteScalar() as string;
                        if (!string.IsNullOrEmpty(result))
                        {
                            resp = result;
                        }
                    }
                }

            } 
        }
        catch (Exception ex)
        { }
        
        if(resp != null)
            HttpContext.Current.Response.Redirect(resp, true);
    }
    
    /// <summary>
    /// Sets the culture based on the language selection in the settings.
    /// </summary>
    void Application_PreRequestHandlerExecute(object sender, EventArgs e)
    {
        var culture = BlogSettings.Instance.Culture;
        if (!string.IsNullOrEmpty(culture) && !culture.Equals("Auto"))
        {
            CultureInfo defaultCulture = Utils.GetDefaultCulture();
            Thread.CurrentThread.CurrentUICulture = defaultCulture;
            Thread.CurrentThread.CurrentCulture = defaultCulture;
        }
        if (!Security.IsAuthenticated)
        {
            HandleRedirect(Request["id"] as string);
        }
    }

    private class FirstRequestInitialization
    {
        private static bool _initializedAlready = false;
        private readonly static object _SyncRoot = new Object();

        // Initialize only on the first request
        public static void Initialize(HttpContext context)
        {
            if (_initializedAlready) { return; }

            lock (_SyncRoot)
            {
                if (_initializedAlready) { return; }

                WidgetZone.PreloadWidgetsAsync("be_WIDGET_ZONE"); 
                Utils.LoadExtensions();

                BundleConfig.RegisterBundles(BundleTable.Bundles);

                WebApiConfig.Register(System.Web.Http.GlobalConfiguration.Configuration);

                UnityConfig.Register(System.Web.Http.GlobalConfiguration.Configuration);

                ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                    new ScriptResourceDefinition
                    {
                        Path = "~/Scripts/jquery-1.9.1.min.js",
                        DebugPath = "~/Scripts/jquery-1.9.1.js",
                        CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.9.1.min.js",
                        CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.9.1.js"
                    });
                
                _initializedAlready = true;
            }
        }
    }
    
</script>