<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" Inherits="allopromo.Admini.Default" %>

<%@ Register Src="~/UserControls/ucHeader.ascx" TagName="ucHeader" TagPrefix="ucHeader1" %>
<%@ Register Src="~/UserControls/ucMain.ascx" TagName="ucMain" TagPrefix="ucMain" %>
<%@ Register Src="~/UserControls/ucMainMenu.ascx" TagName="ucMainMenu" TagPrefix="ucMainMenu" %>
<%@ Register Src="~/UserControls/ucRechercherUsers.ascx" TagName="ucRechercherUsers" TagPrefix="ucSearchUsers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--
    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>
    <div class="row">

        -->
            <!--
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
                -->
        <div class="col-md-12">
            <ucHeader1:ucHeader runat="server"/>
        </div>
    <div class="rowiu">
        <div class="col-md-12676">
            <ucMainMenu:ucMainMenu runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <ucSearchUsers:ucRechercherUsers runat="server" />
        </div>
    </div>
</asp:Content>
