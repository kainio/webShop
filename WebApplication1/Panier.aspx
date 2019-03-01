<%@ Page Language="C#"  MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="Panier.aspx.cs" Inherits="WebApplication1.WebForm2" %>


<asp:Content ID="content1" ContentPlaceHolderID="mainContent" runat="server">

 <form id="form1" runat="server">
        <div class="mt-5">
			<asp:GridView ShowFooter="true" style="border-color: #ccc" OnRowDeleting="GridView1_RowDeleting"  OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" CssClass="table table-striped" HeaderStyle-CssClass="thead-light" ID="GridView1"  AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField Value='<%# Eval("Idprod") %>' ID="HiddenField_idprod" runat="server" />
                            <asp:LinkButton runat="server" CommandName="Delete" ToolTip="Delete">Supprimer</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Photo">
                        <ItemTemplate>
                            <asp:Image ImageUrl='<%# Eval("Photo") %>' runat="server" Width="100px" ID="image_item_photo" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nom du produit">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Nomprod") %>' runat="server" ID="Lbl_item_nomprod" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Prix">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Prix") %>' runat="server" ID="Lbl_item_prix" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantité">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Quantité") %>' runat="server" ID="Lbl_item_qte" />
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">Editer</asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="Label1" style="float:right;font-weight:bold;" runat="server" Text="Total: "></asp:Label>
                        </FooterTemplate>
                        <EditItemTemplate>
                            <asp:TextBox Text='<%# Eval("Quantité") %>' runat="server" ID="Txt_EditItem_qte"></asp:TextBox>
                             <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Update">Editer</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Cancel">Annuler</asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sous-total">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Sous-total") %>' runat="server" ID="Lbl_item_st" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="Lbl_footer_total" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
			</asp:GridView>
        </div>
 </form>
</asp:Content>

