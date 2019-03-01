<%@ Page Language="C#"  MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="Produits.aspx.cs" Inherits="WebApplication1.produits" %>

<asp:Content ID="MainMenu1" ContentPlaceHolderID="MainMenu" runat="server">
    <li class="nav-item">
	    <a class="nav-link" href="/Default.aspx">Accueil</a>
    </li>
    <li class="nav-item active">
	    <a class="nav-link" href="/collection.aspx">Collection <span class="sr-only">(current)</span></a>
    </li>
</asp:Content>
<asp:Content ID="content1" ContentPlaceHolderID="mainContent" runat="server">
	<div class="position-relative overflow-hidden p-3 p-md-5 m-md-3 text-center bg-light">
	  <div class="col-md-6 p-lg-6 mx-auto my-6">
		<asp:Image ID="Img_prod" runat="server" CssClass="" width="250" AlternateText="Photo du produit" />
		<h1 class="display-4 font-weight-normal">
            <asp:Label ID="Lbl_nomprod" runat="server"></asp:Label>
		</h1>
		<p class="lead font-weight-normal">
            <asp:Label ID="Lbl_description" runat="server"></asp:Label>
        </p>
        <p style="color: green" class="display-4 font-weight-normal">
            <asp:Label ID="Lbl_prix" runat="server"></asp:Label>
        </p>
		<form id="form1" runat="server">
			<asp:HiddenField ID="idItem" runat="server" />
			<asp:Button  CssClass="btn btn-primary"  onclick="Button1_Click" ID="Button1" runat="server" Text="Ajouter au panier" />
		</form>
		
	  </div>
	</div>

</asp:Content>
