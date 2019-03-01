<%@ Page Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<asp:Content ID="MainMenu1" ContentPlaceHolderID="MainMenu" runat="server">
    <li class="nav-item active">
	    <a class="nav-link" href="/Default.aspx">Accueil <span class="sr-only">(current)</span></a>
    </li>
    <li class="nav-item">
	    <a class="nav-link" href="/Collection.aspx">Collection</a>
    </li>
</asp:Content>

<asp:Content ID="content1" ContentPlaceHolderID="mainContent" runat="server">
 <form id="form1" runat="server">
	<div>
        <asp:Label ID="Lbl_info" runat="server" ForeColor="Green" Text="Veillez entrer vos coordonnées de connexion"></asp:Label><br/>
		<asp:Label ID="Label1" runat="server" Text="Nom d'utilisateur"></asp:Label><br/>
		<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br/>
		<asp:Label ID="Label2" runat="server" Text="Mot de passe"></asp:Label><br/>
		<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox><br/>
		<asp:Button ID="btn_connexion" style="margin-top:10px" runat="server" Text="Connexion" OnClick="btn_connexion_Click" />
		<asp:Button style="margin-left:10px" ID="btn_cancel" runat="server" Text="Annuler" />
        <br />
		<asp:Label ID="Lbl_error1" runat="server" ForeColor="Red" Text=""></asp:Label>
	</div>
 </form>
</asp:Content>


