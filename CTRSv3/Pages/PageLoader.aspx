<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/principal.Master" AutoEventWireup="true" CodeBehind="PageLoader.aspx.cs" Inherits="CTRSv3.Pages.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function setUrl(url, target) {
            clearTimeout(window.ht);
            window.ht = setTimeout(function () {
                var div = document.getElementById(target);
                div.innerHTML = '<iframe style="width:100%;height:100%;" frameborder="1" src="' + url + '" /> ' + 
                                '<meta http-equiv="X-Frame-Options" content="allow">';

            }, 50);
        }  
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
                <div>
                    <a href="#" onclick="setUrl('https://xerox.sharepoint.com/teams/tax/Cash%20Taxes%20%20Folders/Forms/AllItems.aspx','div1')">Xerox Payroll</a>
                    <div>
                        <div id="div1" style="width: 100%; height: 800px; border: 1px solid #ddd;">
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
