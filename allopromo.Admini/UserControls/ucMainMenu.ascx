<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMainMenu.ascx.cs" 
    Inherits="allopromo.Admini.UserControls.ucMainMenu"%>

<%--@ Register Assembly="allopromo.Admini.Controls"  
    Namespace="allopromo.Admini.Controls" TagPrefix="cc1" --%>

<link type="text/css" rel="stylesheet" href="../Content/Styles/ucMainMenu.css" />
<div id="" style="background-color:"><!-- forestgreen -->
    <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick">
        <Items>
            <asp:MenuItem Text="Acceuil" Value="Acceuil"></asp:MenuItem>
            <asp:MenuItem Text="Utilisateurs" Value="Utilisateurs">
                <asp:MenuItem Text="Gestion des Utilisateurs" Value="Gestion des Utilisateurs"></asp:MenuItem>
                <asp:MenuItem Text="Rechercher Utilisateurs" Value="Rechercher Utilisateurs"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="Catégorie des " Value="Catégorie des">
                <asp:MenuItem Text="Catégorie des" Value="Ajouter"></asp:MenuItem>
                <asp:MenuItem Text="Catégorie des" Value="Rechercher"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="Catégorie des" Value="Catégorie des">
                <asp:MenuItem Text="Catégorie des" Value="Aouter"></asp:MenuItem>
                <asp:MenuItem Text="Catégorie des" Value="Rechercher"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="Paramétrage" Value="Paramétrage">
                <asp:MenuItem Text="Gestion des Parametrés" Value="Gestion des Parametrés"></asp:MenuItem>
                <asp:MenuItem Text="Rechercher Utilisateurs" Value="Rechercher Utilisateurs"></asp:MenuItem>
            </asp:MenuItem>
        </Items>
    </asp:Menu>
</div>

<!--
<div id="menuTwo">
     <ul><a href="jhjhjh"></a></ul>
     <ul><a href="11">ACCEUIL</a>
         <li><a href="jhjhjh">11-11</a></li>
         <li><a href="jhjhjh">11-22</a></li>
     </ul>
      <ul><a href="jhjhjh">GESTIONS DES </a>
         <li><a href="jhjhjh">22-11</a></li>
         <li><a href="jhjhjh">22-22</a></li>
     </ul>
</div>
-->