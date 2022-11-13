<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" 
    CodeBehind="Liste.aspx.cs" Inherits="allopromo.Admini.Liste" %>
<%@ Register Src="~/UserControls/ucHeader.ascx" TagName="ucHeader" TagPrefix="ucHeader1" %>
<%@ Register Src="~/UserControls/ucMain.ascx" TagName="ucMain" TagPrefix="ucMain" %>
<%@ Register Src="~/UserControls/ucMainMenu.ascx" TagName="ucMainMenu" TagPrefix="ucMainMenu" %>
<%@ Register Src="~/UserControls/ucRechercherUsers.ascx" TagName="ucRechercherUsers" TagPrefix="ucSearchUsers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <!--
        <h2><%: Title %>.</h2>
    <h3>List of Users page.</h3>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>
    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
    -->
    <div class="row">
        <div class="col-md-12">
            <ucHeader1:ucHeader runat="server"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <ucMainMenu:ucMainMenu runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <ucSearchUsers:ucRechercherUsers runat="server" />
        </div>
    </div>
</asp:Content>
