<%@ Control Language="C#" ClassName="Widget" Inherits="App_Code.Controls.WidgetBase" %>

<script runat="server">

    public override bool IsEditable
    {
        get { return false; }
    }

    public override string Name
    {
        //CHANGE THIS TO MATCH THE FOLDER NAME
        get { return "FundraiseTeal"; }
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


<div class="widget_ad_color"><div class="widget_ad_header"><p>ADVERTISEMENT</p></div>

<div align="center">
<!-- AdGlare Banner Zone: aafa-bike-ride-fundraiser -->
<script async src='//kidswithfoodallergies.engine.adglare.net/?796165585'></script><span id=zone796165585></span>
	</div></div>
