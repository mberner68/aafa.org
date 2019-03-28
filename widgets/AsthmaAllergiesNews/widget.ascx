<%@ Control Language="C#" ClassName="Widget" Inherits="App_Code.Controls.WidgetBase" %>

<script runat="server">

    public override bool IsEditable
    {
        get { return false; }
    }

    public override string Name
    {
        //CHANGE THIS TO MATCH THE FOLDER NAME
        get { return "AsthmaAllergiesNews"; }
    }
    
    public override bool DisplayHeader
    {
        get { return false; }
    }

    public override void LoadWidget()
    { 
        
    }

    //LEAVE THIS TO REMOVE BORDERS
    public override string CssClasses
    {        
        get { return "noBorder"; }
    }

    
</script>
<!-- CUSTOM HTML GOES BELOW -->
<script type="text/javascript" src="https://community.aafa.org/static/wro/ecc.js"></script><iframe class="hoopla-embedded-content-iframe hoopla-widget-iframe-496282585489590878" src="https://community.aafa.org/ew/496282585489590878" width="100%" height="10" frameborder="0" onload="SocialStrataEmbed.getHeight(this);"></iframe>


