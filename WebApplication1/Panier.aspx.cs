using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private SqlConnection cn = new SqlConnection(@"Data Source=SOUFIANE-PC\SQLEXPRESS;Initial Catalog=webShop;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.Session["iduser"] == null)
                Response.Redirect("default.aspx");
            else if (!IsPostBack)
            {
                TraitementDataGrid();
            }
            
        }

        private void TraitementDataGrid()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                SqlCommand cmd = new SqlCommand("", cn);
                cmd.CommandText = "select li.idprod as 'Idprod',p.photo as 'Photo',p.nomprod as 'Nomprod',p.prix_uni as 'Prix',li.quantité as 'Quantité', (li.quantité * p.prix_uni)  as 'Sous-total' from lineitems li inner join produits p on p.idprod = li.idprod where iduti =@Iduser";
                cmd.Parameters.AddWithValue("Iduser", this.Page.Session["iduser"].ToString());
                SqlDataReader dr = cmd.ExecuteReader();
                
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                   
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    SqlCommand cmdTotal = new SqlCommand("", cn);
                    cmdTotal.CommandText = "Select SUM(li.quantité * p.prix_uni) from lineitems li inner join produits p on p.idprod = li.idprod where iduti =@Iduser";
                    cmdTotal.Parameters.AddWithValue("Iduser", this.Page.Session["iduser"].ToString());
                    Decimal total = Convert.ToDecimal(cmdTotal.ExecuteScalar());
                    (GridView1.FooterRow.FindControl("Lbl_footer_total") as Label).Text = total.ToString();

                }
                else
                {
                    Label Label_error = (Label)this.Master.FindControl("Lbl_error");
                    Label_error.Text = "Votre panier est vide";
                }

            }
            finally
            {
                cn.Close();
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            TraitementDataGrid();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            TraitementDataGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlCommand cmd = new SqlCommand("", cn);
                cmd.CommandText = @"update lineitems set quantité = @quantité where iduti =@iduser and idprod=@idprod";
                cmd.Parameters.AddWithValue("quantité", (GridView1.Rows[e.RowIndex].FindControl("Txt_EditItem_qte") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("iduser", this.Session["iduser"]);
                cmd.Parameters.AddWithValue("idprod", (GridView1.Rows[e.RowIndex].FindControl("Lbl_EditItem_idprod") as Label).Text.Trim());
                cmd.ExecuteNonQuery();
            }
            finally
            {
                GridView1.EditIndex = -1;
                TraitementDataGrid();
                cn.Close();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();

                SqlCommand cmd = new SqlCommand("", cn);
                cmd.CommandText = "Delete From lineitems where iduti = @iduser and idprod = @idprod";
                cmd.Parameters.AddWithValue("iduser", this.Session["iduser"]);
                cmd.Parameters.AddWithValue("idprod", (GridView1.Rows[e.RowIndex].FindControl("HiddenField_idprod") as HiddenField).Value);
                cmd.ExecuteNonQuery();
                this.Session["CartItemsCount"] = Convert.ToInt32(this.Session["CartItemsCount"]) - 1;
            }
            finally
            {
                TraitementDataGrid();
                cn.Close();
            }
        }
    }
}