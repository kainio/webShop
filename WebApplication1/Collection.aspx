<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Collection.aspx.cs" Inherits="WebApplication1.Collection" %>

<asp:Content ID="MainMenu1" ContentPlaceHolderID="MainMenu" runat="server">
    <li class="nav-item">
	    <a class="nav-link" href="/Default.aspx">Accueil</a>
    </li>
    <li class="nav-item active">
	    <a class="nav-link" href="/Produits.aspx">Collection <span class="sr-only">(current)</span></a>
    </li>
</asp:Content>
<asp:Content ID="content1" ContentPlaceHolderID="mainContent" runat="server">
    <% for (int i = 0; i < Produits.Rows.Count;i++ ){%>
    <%--TODO: Diviser l'affichage de la ligne en 2 --%>
          <%if(i%2 == 0){ %>
           <div class="d-md-flex flex-md-equal w-100 my-md-3 pl-md-3">
          <%} %>
              <div class="bg-light mr-md-3 pt-3 px-3 pt-md-5 px-md-5 text-center overflow-hidden">
                <div class="my-3 p-3">
                    <a href="produits.aspx?id=<%: Produits.Rows[i]["idprod"]%>" title="Voir la page du produit"><h2 class="display-5"><%: Produits.Rows[i]["nomprod"]%></h2></a>
                    <p class="lead"><%= Produits.Rows[i]["description"]%>.</p>
                    <span class="display-4"><%: Produits.Rows[i]["prix_uni"]%>DH</span>
                </div>
                <div class="mx-auto">
                    <img src='<%= Produits.Rows[i]["photo"]%>'  width="250" alt="Photo du produit"/>
                </div>
              </div>
        <%if((i%2 != 0) || i==Produits.Rows.Count -1){%>
           </div>
          <%} %>
    <% }%>
</asp:Content>
