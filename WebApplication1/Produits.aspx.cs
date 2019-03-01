using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class produits : System.Web.UI.Page
    {
        private SqlConnection cn = new SqlConnection(@"Data Source=SOUFIANE-PC\SQLEXPRESS;Initial Catalog=webShop;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["id"] != null && Exists(Request.Params["id"].ToString()))
                {
                    idItem.Value = Request.Params["id"];
                    try
                    {
                        if (cn.State == ConnectionState.Closed)
                            cn.Open();

                        SqlCommand cmd = new SqlCommand("Select * FROM produits WHERE idprod = @idItem", cn);
                        cmd.Parameters.AddWithValue("idItem", idItem.Value.ToString());
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Lbl_nomprod.Text = dr[1].ToString();
                            Lbl_description.Text = dr[2].ToString();
                            Lbl_prix.Text = dr[3].ToString() + "DH";

                            var prodPhoto = dr[4];
                            if (prodPhoto != null)
                                Img_prod.ImageUrl = prodPhoto.ToString();
                        }
                    }
                    finally
                    {
                        cn.Close();
                    }

                }
                else
                {
                    Response.Redirect("collection.aspx");
                }
  
            }

        }
        private bool Exists(string p)
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();

                SqlCommand cmd = new SqlCommand("Select * FROM produits WHERE idprod = @idItem", cn);
                cmd.Parameters.AddWithValue("idItem", p);
                if (cmd.ExecuteScalar() != null)
                {
                    return true;
                } else 
                {
                    return false;
                }

            }
            finally
            {
                cn.Close();
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.Page.Session["iduser"] != null)
            {
                if (idItem.Value != null)
                {

                    SqlCommand cmd = new SqlCommand("");
                    //cmd.Parameters.AddWithValue("idItem", idItem.Value);
                    //SqlDataReader dr = cmd.ExecuteReader();
                    if (Exists(idItem.Value.ToString()))
                    {
                        try
                        {
                            if (cn.State == ConnectionState.Closed)
                                cn.Open();

                            cmd = new SqlCommand("Select * FROM lineitems where idprod=@idprod and iduti=@iduti", cn);
                            cmd.Parameters.AddWithValue("idprod", idItem.Value);
                            cmd.Parameters.AddWithValue("iduti", this.Page.Session["iduser"]);
                            if (cmd.ExecuteScalar() == null)
                            {
                                cmd = new SqlCommand("Insert into lineitems Values(@idprod,@iduti,null,1)", cn);
                                cmd.Parameters.AddWithValue("idprod", idItem.Value);
                                cmd.Parameters.AddWithValue("iduti", this.Page.Session["iduser"]);
                                cmd.ExecuteNonQuery();
                                this.Session["CartItemsCount"] = Convert.ToInt32(this.Session["CartItemsCount"]) + 1;
                            }
                            else
                            {
                                Label label_error = (Label)this.Master.FindControl("Lbl_error");
                                label_error.Text = "Cet article a été déjà ajouté au panier";
                            }
                        }
                        finally
                        {
                            cn.Close();
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
    }
}