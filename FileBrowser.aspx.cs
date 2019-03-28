using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FileBrowser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = System.IO.Path.Combine(Server.MapPath("."), "media");
        DirectoryInfo di = new DirectoryInfo(path);
        List<FileViewItem> urls = new List<FileViewItem>();
        string flashUrl = "/media/flash_player.gif";

        string extensionPattern = "(jpg|jpeg|gif|tiff|png|flv)";
        Regex reg = new Regex(extensionPattern);
                
        foreach (var file in di.GetFiles())
        {
            Match match = reg.Match(file.Extension);
            if (match.Success)
            {
                string url =  HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/media/" + file.Name;
                string thumb = file.Extension != ".flv" ? url : flashUrl;
                string name = file.Name;
                urls.Add(new FileViewItem() { Url = url, Name = name, Thumb = thumb});
            }
        }

        Repeater1.DataSource = urls;
        Repeater1.DataBind();
    }

    public class FileViewItem
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Thumb { get; set; }
    }
}