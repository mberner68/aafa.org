<%@ Page Language="C#" AutoEventWireup="true" CodeFile="page.aspx.cs" Inherits="page" %>
<%@ Import Namespace="BlogEngine.Core"%>
<asp:content id="Content1" contentplaceholderid="cphBody" runat="Server">
  <div id="page" class="page-global">
  <!--  <h2 class="page-global-title" runat="server" id="h1Title" style="display:none;"></h2>-->
    <div runat="server" id="divText" />  
    <%=AdminLinks %>
    
    <% if (BlogSettings.Instance.ModerationType == BlogSettings.Moderation.Disqus && BlogSettings.Instance.DisqusAddCommentsToPages)
       { %>
    <div id="disqus_box" runat="server">
    <div id="disqus_thread"></div>
    <script type="text/javascript">
        var disqus_url = '<%= PermaLink %>';
        var disqus_developer = '<%= BlogSettings.Instance.DisqusDevMode ? 1 : 0 %>';
        (function() {
            var dsq = document.createElement('script'); dsq.type = 'text/javascript'; dsq.async = true;
            dsq.src = 'http://<%=BlogSettings.Instance.DisqusWebsiteName %>.disqus.com/embed.js';
            (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(dsq);
        })();
    </script>
    <noscript>Please enable JavaScript to view the <a href="http://disqus.com/?ref_noscript=<%=BlogSettings.Instance.DisqusWebsiteName %>">comments powered by Disqus.</a></noscript>
    <a href="http://disqus.com" class="dsq-brlink">blog comments powered by <span class="logo-disqus">Disqus</span></a>
  </div>
    <%} %>
      
      </div>
</asp:content>
<asp:content id="Content6" contentplaceholderid="categoriesTitle" runat="Server">
    <div runat="server" id="CategoriesTitle"/> 
</asp:content> 

<asp:content id="Content7" contentplaceholderid="rightCalloutBC" runat="Server">
    <div runat="server" id="rightCalloutBCdiv"/> 
</asp:content> 

<asp:content id="Content2" contentplaceholderid="rightCallout" runat="Server">
    <div runat="server" id="rightCalloutText"/> 
</asp:content> 
 
<asp:content id="Content8" contentplaceholderid="leftCalloutBC" runat="Server">
    <div runat="server" id="leftCalloutBCdiv"/> 
</asp:content> 

<asp:content id="Content3" contentplaceholderid="leftCallout" runat="Server">
    <div runat="server" id="leftCalloutText"/> 
</asp:content> 

<asp:content id="Content4" contentplaceholderid="ctlfooter" runat="Server">
    <div runat="server" id="footerText"/> 
</asp:content> 

<asp:content id="Content5" contentplaceholderid="redirectCTL" runat="Server">
    <%if (redirectPage) {%>
    <script type="text/javascript">
        window.location.href = "<%=redirectUrl %>";
    </script>
    <%} %>
</asp:content> 
