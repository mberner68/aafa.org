using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_controls_Test : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submit1_Click(object sender, EventArgs e)
    {
        label1.Text = text1.Text;
        text1.Text = string.Empty;
    }
}