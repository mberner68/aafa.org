<%@ Control Language="C#" ClassName="Widget" Inherits="App_Code.Controls.WidgetBase" %>

<script runat="server">

    public override bool IsEditable
    {
        get { return false; }
    }

    public override string Name
    {
        //CHANGE THIS TO MATCH THE FOLDER NAME
        get { return "PatientTalkPoints"; }
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

<!-- AdGlare Banner Zone: Patient Talk Points -->
<script async src='//kidswithfoodallergies.engine.adglare.net/?597127811'></script><span id=zone597127811></span>
	</div></div>

