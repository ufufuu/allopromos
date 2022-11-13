<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucRechercherUsers.ascx.cs" 
    Inherits="allopromo.Admini.UserControls.ucRechercherUsers"%>

<%--@ Register Assembly="allopromo.Admini.Controls"  Namespace="allopromo.Admini.Controls" 
    TagPrefix="cc1" --%>

<div id="col-md-12" style="background-color:beige">
    <asp:UpdatePanel ID="usersListPanel" runat="server">
        <ContentTemplate>
            <h3>Liste des Utilisateurs Trouv&eacute;s: --</h3>
            <asp:GridView ID="usersListGridView" runat="server" AllowPaging="true"
                AllowSorting="true" DataSourceID="">
            </asp:GridView>
            <div class="list-action">
                <asp:Button ID="btnProduire" runat="server" Text="Produire Sommaire"
                    Enabled="false" Visible="false" CausesValidation="false" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>