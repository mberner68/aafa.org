<%@ Control Language="C#" ClassName="Widget" Inherits="App_Code.Controls.WidgetBase" %>

<script runat="server">

    public override bool IsEditable
    {
        get { return false; }
    }

    public override string Name
    {
        //CHANGE THIS TO MATCH THE FOLDER NAME
        get { return "tackleasthmaPhoto"; }
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

<div align="center">

<!-- AdGlare Banner Zone: tackle-asthma-2017 -->
<span id=zone993255068></span><script async src='//kidswithfoodallergies.engine.adglare.net/?993255068'></script></div>