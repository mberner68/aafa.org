using App_Code.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class widgets_Navigation_edit : WidgetEditBase
{
    #region Public Methods

    /// <summary>
    /// Saves this the basic widget settings such as the Title.
    /// </summary>
    public override void Save()
    {
        var settings = this.GetSettings();
        settings["level"] = this.NavLevel.SelectedValue;
        this.SaveSettings(settings);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event.
    /// </summary>
    /// <param name="e">
    /// An <see cref="T:System.EventArgs"/> object that contains the event data.
    /// </param>
    protected override void OnInit(EventArgs e)
    {
        var settings = this.GetSettings();
        if (settings["level"] != null)
            this.NavLevel.SelectedValue = settings["level"];
        base.OnInit(e);
    }

    #endregion
}